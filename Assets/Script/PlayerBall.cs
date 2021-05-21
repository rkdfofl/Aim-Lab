using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    Rigidbody rigid;
    public float jump;
    public int score;
    public GM manager;
    bool isJump;
    AudioSource audio;

    // Start is called before the first frame update
    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, jump, 0), ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }
       void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
            isJump = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "target")
        {
            score++;
            audio.Play();
            other.gameObject.SetActive(false);
            manager.GetItem(score);
        }
        else if(other.tag == "Finish")
        {
            if (score == manager.TotalItemCount)
            {
                if (manager.stage == 2)
                    SceneManager.LoadScene(0);
                else
                    SceneManager.LoadScene(manager.stage + 1);
            }
            else
                SceneManager.LoadScene(manager.stage);

        }
    }
}

// add

