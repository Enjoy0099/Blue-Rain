using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fireball; 

    private float max_X = 8.5f;     //2.7f
    private float min_X = -8.5f;    //-2.7f

    private float fireball_min_Range = 0.4f;
    private float fireball_max_Range = 0.8f;

    private PlayerMove PM;
    private int timer_1;
    private int Sec;

    void Awake()
    {
        PM = GameObject.FindObjectOfType<PlayerMove>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Sec = 13;
        StartCoroutine(StartSpawning());
    }

    void Update()
    {
        timer_1 = PM.timer;
    }

    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(Random.Range(fireball_min_Range, fireball_max_Range));

        GameObject k = Instantiate(fireball);

        float x = Random.Range(min_X, max_X);

        k.transform.position = new Vector2(x, transform.position.y);

        if (timer_1 > Sec)
        {
            fireball_max_Range -= 0.2f;
            fireball_min_Range -= 0.2f;

            if (fireball_min_Range <= 0f)
            {
                fireball_min_Range = 0.02f;
            }
            if (fireball_max_Range <= 0.2f)
            {
                fireball_max_Range = 0.09f;
            }
            Sec += 16;
        }

        StartCoroutine(StartSpawning());

    }
}
