using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ShopManager : MonoBehaviour
{
    public int coins;
    public TMP_Text coinUI;
    public ShopItemSO[] shopItemSO;
    public ShopTemplate[] shopPanels;



    private void Start()
    {
        coinUI.text = "Coins: " + coins.ToString();
        LoadPanels();
    }

    public void addCoins()
    {
        coins++;
        coinUI.text = "Coins: " + coins.ToString();
        CheckPurchaseable();
    }

    public void CheckPurchaseable()
    {
        throw new NotImplementedException();
    }

    
    public void LoadPanels()
    {
        for (int i = 0; i < shopItemSO.Length; i++)
        {
            shopPanels[i].titleTxt.text = shopItemSO[i].title;
            shopPanels[i].describtionTxt.text = shopItemSO[i].describtion;
            shopPanels[i].costTxt.text = "Coins: " + shopItemSO[i].baseCost.ToString();
        }
    }
    
}

