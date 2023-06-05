using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ShopItemSO shopItemSO;

    public void Pickup()
    {
        InventoryManager.Instance.Add(shopItemSO);
    }
}

