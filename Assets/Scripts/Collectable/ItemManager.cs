using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    public SOInt coins;
    public SOInt lifes;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI lifeText;

    private void Reset()
    {
        coins.value = 0;
        lifes.value = 0;
    }

    public void AddCoin(int amount = 1)
    {
        coins.value += amount;
    }

    public void AddLife(int amount = 1)
    {
        lifes.value += amount;
    }
    void Start()
    {
        Reset();
    }
}
