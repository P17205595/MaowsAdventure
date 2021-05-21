using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clsBallCollector : MonoBehaviour
{

    public Text ballCounter;
    public AudioClip collectSound;
    public float volume = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        ballCounter = GameObject.Find("BallCounter").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ballCounter.text = "Ball: " + clsPM.ballAmount + " / 10";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            clsPM.incrementBall();
            AudioSource.PlayClipAtPoint(collectSound, transform.position, 0.1f);
            Destroy(gameObject);
        }

    }
}
