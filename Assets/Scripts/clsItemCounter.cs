using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clsItemCounter : MonoBehaviour
{
    public Text CoinCount;
    public int coins = 0;
    public Text WoolCount;
    public int wool;
    public Text FoodCount;
    public int food;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CoinCount.text = "Coins : " + coins;
    }
}
