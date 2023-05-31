using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable Objects/ New Shop Item")]
public class ShopItemSO : ScriptableObject
{
    public string title;
    public string describtion;
    public int baseCost;
}
