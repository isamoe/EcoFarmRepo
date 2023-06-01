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
    public GameObject[] shopPanelsGO;
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseBtns;
    
    // Gekaufte GameObjects
    public GameObject Field;


    private void Start()
    {
        for(int i = 0; i < shopItemSO.Length; i++)
        {
            shopPanelsGO[i].SetActive(true);
        }
        coinUI.text = "Coins: " + coins.ToString();
        LoadPanels();
        CheckPurchaseable();
    }

    public void addCoins()
    {
        coins++;
        coinUI.text = "Coins: " + coins.ToString();
        CheckPurchaseable();
    }

    public void CheckPurchaseable()
    {
        for( int i = 0; i < shopItemSO.Length; i++)
        {
            if (coins >= shopItemSO[i].baseCost)
                myPurchaseBtns[i].interactable = true;
            else
                myPurchaseBtns[i].interactable = false;
        }
    }

    public void PurchaseItem(int btnNo)
    {
        if(coins >= shopItemSO[btnNo].baseCost)
        {
            // Active Element 
            String elementName = shopItemSO[btnNo].title;

            /*
            GameObject inactiveObject = GameObject.FindGameObjectWithTag("InactiveGameObject");
            inactiveObject.SetActive(true);
            bool isActive = inactiveObject.activeSelf;
            print("gefunden: " + isActive);
            */

            GameObject[] allObjects = FindObjectsOfType<GameObject>(true);
            bool gefunden = false;
            foreach (GameObject go in allObjects)
            {
                if (go.name == elementName)
                {
                    go.SetActive(true);
                    gefunden = true;
                }
            }
            print("gefunden: " + gefunden);
            
            coins = coins - shopItemSO[btnNo].baseCost;
            coinUI.text = "Coins: " + coins.ToString();
            CheckPurchaseable();
        }
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

