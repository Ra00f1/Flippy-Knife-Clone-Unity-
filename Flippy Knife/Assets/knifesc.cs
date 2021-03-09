using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class knifesc : MonoBehaviour
{
    public Rigidbody rb;

    public float force = 5f;
    public float torque = 20f;

    public GameObject text;
    public GameObject particles;

    public AudioClip sfx;

    private Vector3 startswipe;
    private Vector3 endswipe;

    private float swipedelay;

    int score = 0;

    void Update()
    {
        text.GetComponent<UnityEngine.UI.Text>().text = score.ToString();

        if (!rb.isKinematic)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            startswipe = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            endswipe = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            swipe();
        }
    }

    void swipe()
    {
        swipedelay = Time.time;
        rb.isKinematic = false;
        Vector2 swipe = endswipe - startswipe;
        rb.AddForce(swipe * force, ForceMode.Impulse);
        rb.AddTorque(0f, 0f, torque, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Log")
        {
            rb.isKinematic = true;
            score += 1;
            gameObject.GetComponent<AudioSource>().PlayOneShot(sfx,1);

            Vector3 pos = new Vector3();
            pos = transform.position;
            pos.y = pos.y - 0.25f;
            Instantiate(particles, pos, Quaternion.identity);
        }
        else
        {
            Debug.Log("Fail");
            Restart();
        }

    }
    void OnCollisionEnter()
    {
        float TimeInAir = Time.time - swipedelay;
        if (!rb.isKinematic && TimeInAir >= 0.07f)
        {
            Restart();
            Debug.Log("Fail");
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}