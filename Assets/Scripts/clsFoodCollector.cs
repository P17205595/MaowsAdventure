using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clsFoodCollector : MonoBehaviour
{

    public Text foodCounter;
    public AudioClip collectSound;
    public float volume = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        foodCounter = GameObject.Find("FoodCounter").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        foodCounter.text = "Food: " + clsPM.foodAmount + " / 10";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            clsPM.incrementFood();
            AudioSource.PlayClipAtPoint(collectSound, transform.position, 0.1f);
            Destroy(gameObject);
        }

    }
}
