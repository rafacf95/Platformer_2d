using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    public int coins;
    public TextMeshProUGUI coinText;

    private void Reset()
    {
        coins = 0;
        coinText.text = "x " + ItemManager.Instance.coins.ToString();
    }

    public void AddCoin(int amount = 1)
    {
        coins += amount;
        coinText.text = "x " + ItemManager.Instance.coins.ToString();
    }

    void Start()
    {
        Reset();
    }
}
