using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{

    public static PlayerMove playerMoveIn;

    private Animator anim;
    private SpriteRenderer sr;

    private AudioSource boom;


    private float speed = 3f;

    private float max_X = 8.5f;     //2.7f
    private float min_X = -8.5f;    //-2.7f

    public Text Timer_Text;
    [HideInInspector]
    public int timer;
    [HideInInspector]
    public static int HScore;

    // Start is called before the first frame update
    void Awake()
    {
        if (playerMoveIn == null)
            playerMoveIn = this;
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        boom = GetComponent<AudioSource>();
    }

    void Start()
    {
        Time.timeScale = 1f;
        timer = 0;
        StartCoroutine(Counttime());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        PlayerBound();
    }

    void PlayerBound()
    {
        Vector3 temp = transform.position;

        if (temp.x > max_X)
        {
            temp.x = max_X;
        }
        else if (temp.x < min_X)
        {
            temp.x = min_X;
        }

        transform.position = temp;
    }

    IEnumerator Counttime()
    {
        yield return new WaitForSeconds(1f);
        timer++;
        
        if (timer < 10)
        {
            Timer_Text.text = "Score: 0" + timer;
        }
        else
        {
            Timer_Text.text = "Score: " + timer;
        }

        StartCoroutine(Counttime());
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");

        Vector3 temp = transform.position;

        //Debug.Log(h);

        if (h == 1)
        {
            temp.x += speed * Time.deltaTime;
            sr.flipX = false;
            anim.SetBool("Walk", true);
        }
        else if (h == -1)
        {
            temp.x -= speed * Time.deltaTime;
            sr.flipX = true;
            anim.SetBool("Walk", true);
        }
        else 
        {
            anim.SetBool("Walk", false);
        }

        transform.position = temp;
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSecondsRealtime(2f);

        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "fireball")
        {

            Time.timeScale = 0f;

            HScore = timer;

            boom.Play();

            StartCoroutine(RestartLevel());
        }
    }

    public int SendCurrentScore()
    {
        return HScore; 
    }
}
