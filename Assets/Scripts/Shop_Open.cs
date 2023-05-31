using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Open : MonoBehaviour
{
    public GameObject ShopPanel;
    //public GameObject Button;
    public void OpenPanel()
    {
        if (ShopPanel != null)
        {
            bool isActive = ShopPanel.activeSelf;
            //Console.WriteLine(isActive);
            print(isActive);
            ShopPanel.SetActive(!isActive);
            print(isActive);
            /*Button.transform.TransformPoint(-220, 0, 0);*/
            if (isActive == false)
            {
                var shop_icon = GameObject.Find("Canvas").transform.Find("Button").GetComponent<RectTransform>();
                var pos = shop_icon.localPosition;
                shop_icon.localPosition = new Vector3(-80, pos.y, pos.z);
            }
            if (isActive == true)
            {
                var shop_icon = GameObject.Find("Canvas").transform.Find("Button").GetComponent<RectTransform>();
                var pos = shop_icon.localPosition;
                shop_icon.localPosition = new Vector3(-290, pos.y, pos.z);
            }
        }
    }
}
