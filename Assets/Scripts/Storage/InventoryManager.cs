using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public ShopItemSO shopItemSO;
    public List<ShopItemSO> Items = new List<ShopItemSO>();
    private void Awake()
    {
        Instance = this;
    }

    public void Add(ShopItemSO shopItemSO)
    {
        Items.Add(shopItemSO);
        print(Items);
        print(shopItemSO.title + "liegt im Inventar!");
    }

    public void Test()
    {
        print("Hat geklappt");
    }
    /*
    public void ListItem()
    {
        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("Item/ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("Item/ItemIcon").GetComponent<Image>();
            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }
    }*/
}
