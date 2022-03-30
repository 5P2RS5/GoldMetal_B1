using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    public float JumpPower = 10f;
    public int itemCount;
    public GameManagerLogic manager;
    Rigidbody _rigidbody;
    AudioSource _audioSource;
    bool isJumping;
    void Awake()
    {
        isJumping = false;
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            isJumping = true;
            _rigidbody.AddForce(new Vector3(0, JumpPower, 0), ForceMode.Impulse);
        }
        
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        
        _rigidbody.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJumping = false;
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemCount++;
            _audioSource.Play();
            other.gameObject.SetActive(false);
            manager.getItem(itemCount);
        }
        else if (other.tag == "Finish")
        {
            if (manager.TotalItmeCount == itemCount)
            { // Game Clear
                if (manager.stage == 2)
                    SceneManager.LoadScene(0);
                //SceneManager.LoadScene("SampleScene1_0");
                //SceneManager.LoadScene("SampleScene1_" + (manager.stage + 1));
                else
                {
                    SceneManager.LoadScene("SampleScene1_" + (manager.stage + 1).ToString());
                }
            }
            else
            { // Game Restart
                SceneManager.LoadScene("SampleScene1_"+ manager.stage.ToString());
                //SceneManager.LoadScene("SampleScene1_"+ manager.stage);
            }
        }
    }
}
