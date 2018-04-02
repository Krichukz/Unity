using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCount : MonoBehaviour {

    public static int coinCount = 0;

    private void OnGUI()
    {
        string coinText = "Total Coins: " + coinCount;
        GUI.Box(new Rect(Screen.width - 150, 20, 130, 20), coinText);
    }
}
