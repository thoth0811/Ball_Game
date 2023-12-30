using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonBalls : MonoBehaviour
{
    public GameObject Lv1s;
    public GameObject Lv2s;
    public GameObject Lv3s;
    public GameObject Lv4s;

    public GameObject Lv1;
    public GameObject Lv2;
    public GameObject Lv3;
    public GameObject Lv4;
    public GameObject Lv5;
    public GameObject Lv6;
    public GameObject Lv7;
    public GameObject Lv8;
    public GameObject Lv9;
    public GameObject Lv10;
    public GameObject Lv11;

    public int Score = 0;

    public GameObject SpawnPoint;
    public float SpawnCool = 0.5f;
    float NextSpawn;
    Queue<int> NextBallsNum = new Queue<int>(3);
    int[] NextBall = new int[3];
    bool isSampleSpawn = false;
    GameObject Ball;
    GameObject[] Balls = new GameObject[3];
    // Start is called before the first frame update
    void Start()
    {
        NextBallsNum.Enqueue(Random.Range(1, 5));
        NextBallsNum.Enqueue(Random.Range(1, 5));
        NextBallsNum.Enqueue(Random.Range(1, 5));
    }

    void RemoveSample()
    {
        NextBallsNum.Enqueue(Random.Range(1, 5));
        foreach (GameObject ball in Balls)
        {
            Destroy(ball, 0f);
        }

        isSampleSpawn = false;
    }

    public void ClearBalls()
    {
        GameObject[] GameBalls = GameObject.FindGameObjectsWithTag("Balls");
        foreach (GameObject ball in GameBalls)
        {
            Destroy(ball, 0f);
        }
    }

    public void Summon(int Lv, Vector3 pos)
    {
        switch (Lv)
        {
            case 1: Instantiate(Lv1, pos, Quaternion.identity); break;
            case 2: Instantiate(Lv2, pos, Quaternion.identity); break;
            case 3: Instantiate(Lv3, pos, Quaternion.identity); break;
            case 4: Instantiate(Lv4, pos, Quaternion.identity); break;
            case 5: Instantiate(Lv5, pos, Quaternion.identity); break;
            case 6: Instantiate(Lv6, pos, Quaternion.identity); break;
            case 7: Instantiate(Lv7, pos, Quaternion.identity); break;
            case 8: Instantiate(Lv8, pos, Quaternion.identity); break;
            case 9: Instantiate(Lv9, pos, Quaternion.identity); break;
            case 10: Instantiate(Lv10, pos, Quaternion.identity); break;
            case 11: Instantiate(Lv11, pos, Quaternion.identity); break;
            default: break;
        }
    }

    void SpawnSample()
    {
        isSampleSpawn = true;
        NextBall = NextBallsNum.ToArray();
        switch (NextBall[0])
        {
            case 1: Ball = Instantiate(Lv1s, gameObject.transform.position, Quaternion.identity); break;
            case 2: Ball = Instantiate(Lv2s, gameObject.transform.position, Quaternion.identity); break;
            case 3: Ball = Instantiate(Lv3s, gameObject.transform.position, Quaternion.identity); break;
            case 4: Ball = Instantiate(Lv4s, gameObject.transform.position, Quaternion.identity); break;
            default: break;
        }
        Balls[0] = Ball;
        Ball.gameObject.GetComponent<BallsSample>().isNext = true;
        switch (NextBall[1])
        {
            case 1: Balls[1] = Instantiate(Lv1s, new Vector3(-5, 4.5f, 0), Quaternion.identity); break;
            case 2: Balls[1] = Instantiate(Lv2s, new Vector3(-5, 4.5f, 0), Quaternion.identity); break;
            case 3: Balls[1] = Instantiate(Lv3s, new Vector3(-5, 4.5f, 0), Quaternion.identity); break;
            case 4: Balls[1] = Instantiate(Lv4s, new Vector3(-5, 4.5f, 0), Quaternion.identity); break;
            default: break;          
        }                            
        switch (NextBall[2])         
        {                            
            case 1: Balls[2] = Instantiate(Lv1s, new Vector3(-7, 4.5f, 0), Quaternion.identity); break;
            case 2: Balls[2] = Instantiate(Lv2s, new Vector3(-7, 4.5f, 0), Quaternion.identity); break;
            case 3: Balls[2] = Instantiate(Lv3s, new Vector3(-7, 4.5f, 0), Quaternion.identity); break;
            case 4: Balls[2] = Instantiate(Lv4s, new Vector3(-7, 4.5f, 0), Quaternion.identity); break;
            default: break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSampleSpawn)
        {
            SpawnSample();

        }
        if (Input.GetKey(KeyCode.Space)){
            if (NextSpawn <= Time.time) {
                Summon(NextBallsNum.Dequeue(), gameObject.transform.position);
                NextSpawn = Time.time + SpawnCool;
                RemoveSample();
            }
        }
        if (Input.GetKey(KeyCode.RightArrow)) { 
            if(gameObject.transform.position.x < 2.85) {
                gameObject.transform.position += new Vector3(0.01f, 0, 0);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (gameObject.transform.position.x > -2.85)
            {
                gameObject.transform.position += new Vector3(-0.01f, 0, 0);
            }
        }
    }
}
