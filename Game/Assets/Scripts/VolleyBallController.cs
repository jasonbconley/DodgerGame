using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolleyBallController : MonoBehaviour
{
    public Transform spawn;
    bool isSpawning = false;
    public float FiveSeconds = 5;
    public UnityEngine.UI.Text Timer;
    bool runTimer = false;
    public static bool grounded = false;
    public static bool infiniteArms = false;
    bool playerTouch = false;
    bool enemyTouch = false;
    public Transform spikeAim;
    public static bool disable = false;

    // Code used from https://www.youtube.com/watch?v=1Srb6r5Kle4

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !playerJump.grounded)
        {
            TryHitSpike();
        }
        else if (Input.GetKeyDown(KeyCode.E)) 
        {
            TryHitBump();
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            TryHitBall();
        }

        if (runTimer) // https://www.youtube.com/watch?v=GPwp0Bd7WnA
        {
            if (FiveSeconds > 0)
            {
                FiveSeconds -= Time.deltaTime;
                int seconds = Mathf.FloorToInt(FiveSeconds % 60F);
                int milliseconds = Mathf.FloorToInt((FiveSeconds * 100f) % 100F);
                Timer.text = seconds.ToString("00") + ":" + milliseconds.ToString("00");
            }
        }
        if (FiveSeconds <= 0)
        {
            runTimer = false;
            Timer.text = "";
            FiveSeconds = 5;
        }

        if (disable)
        {
            this.gameObject.GetComponent<VolleyBallController>().enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "Environment" && !isSpawning && !grounded)
        {
            if (playerTouch)
            {
                EnemyScore.collided = true;
                grounded = true;
                runTimer = true;
                Spawn();
            }
            else if (enemyTouch)
            {
                PlayerScoreBoard.collided = true;
                grounded = true;
                runTimer = true;
                Spawn();
            }
            else
            {
                grounded = true;
                runTimer = true;
                Spawn();
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "EnemyCourt" && !grounded)
        {
            grounded = true;
            PlayerScoreBoard.collided = true;
            runTimer = true;
            Spawn();
        }
        else if (collision.gameObject.name == "PlayerCourt" && !grounded)
        {
            grounded = true;
            EnemyScore.collided = true;
            runTimer = true;
            Spawn();
        }
        else if (collision.gameObject.name == "EnemyBack" || collision.gameObject.name == "EnemyFront")
        {
            enemyTouch = true;
            GetComponent<Rigidbody>().AddForce(new Vector3(0, -5, 5) + spawn.position, ForceMode.Impulse);
        }
    }

    private void TryHitBall()
    {
        float power = GetPower();
        if (power > 0 && !grounded)
        {
            playerTouch = true;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = GetReflected() * power;
        }
    }

    private void TryHitBump()
    {
        float power = GetPower();
        if (power > 0 && !grounded)
        {
            playerTouch = true;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce((Vector3.up * power * 1.5f) + Vector3.forward + Vector3.up, ForceMode.Impulse);
        }
    }

    private void TryHitSpike()
    {
        float power = GetPower();
        if (power > 0 && !grounded)
        {
            playerTouch = true;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = Spike() * power * 2;
        }
    }

    private Vector3 GetReflected()
    {
        Vector3 volleyBallVector = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        Vector3 tangentVector = Vector3.Cross(volleyBallVector, Camera.main.transform.forward);
        Vector3 planeNormal = Vector3.Cross(tangentVector, volleyBallVector);
        Vector3 reflected = Vector3.Reflect(Camera.main.transform.forward, planeNormal);
        return reflected.normalized;
    }

    private Vector3 Spike()
    {
        return spikeAim.position.normalized;
    }

    private float GetPower()
    {
        if (infiniteArms)
        {
            return 10;
        }

        float ideal = 3;
        float maxPower = 15;

        float x = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
        float y = -Mathf.Abs(x-ideal)/3 + 1;
        float power = y * maxPower;
        power = Mathf.Clamp(power, 0, maxPower);
        return power;
    }

    async void Spawn()
    {
        isSpawning = true;
        await System.Threading.Tasks.Task.Delay(5000);
        if (spawn.position != null)
        {
            transform.position = spawn.position;
        }
        GetComponent<Rigidbody>().velocity = new Vector3(0, 3, -3);
        isSpawning = false;
        grounded = false;
        enemyTouch = false;
        playerTouch = false;
    }
}
