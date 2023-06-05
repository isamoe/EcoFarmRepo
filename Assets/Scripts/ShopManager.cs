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

    // Fürs Platzieren
    // Liste der Objects (Nummerierung) muss Liste der Scriptable Objects entsprechen!
    public GameObject[] objects;

    private Vector3 pos;
    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;

    private GameObject selectedObject;


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

    public void Update()
    {
        if(selectedObject != null)
        {
            selectedObject.transform.position = pos;
            if(Input.GetMouseButtonDown(0))
            {
                PlaceObject();
            }
        }
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
        if (coins >= shopItemSO[btnNo].baseCost)
        {
            // Active Element 
            String elementName = shopItemSO[btnNo].title;

            // Select Object zum Platzieren
            // Liste der Objects (Nummerierung) muss Liste der Scriptable Objects entsprechen!
            selectedObject = Instantiate(objects[btnNo], pos, transform.rotation);

            /* 
            GameObject[] allObjects = FindObjectsOfType<GameObject>(true);
            foreach (GameObject go in allObjects)
            {
                if (go.name == elementName)
                {
                    go.SetActive(true);
                }
            }
            */

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


    // Platzieren der Objekte

    // Wird am Ende jedes Frames aufgerufen, updated Physics 
    private void FixedUpdate()
    {
        if(selectedObject != null)
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.z = 0f;
            selectedObject.transform.position = mouseWorldPosition;

            pos = mouseWorldPosition;
        }
    }

    public void PlaceObject()
    {
        selectedObject = null;
    }

}

