using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clsCoinCollector : MonoBehaviour
{

    public Text coinCounter;
    public AudioClip collectSound;
    public float volume = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        coinCounter = GameObject.Find("CoinCounter").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        coinCounter.text = "Coins: " + clsPM.coinAmount + " / 10";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            clsPM.incrementCoins();
            AudioSource.PlayClipAtPoint(collectSound, transform.position, 0.1f);
            Destroy(gameObject);
        }

    }
}
