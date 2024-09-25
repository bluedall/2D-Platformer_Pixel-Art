using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEditor.Progress;
/// <summary>
/// This class is responsible for managing the Inventory System and Add or delete Items.
/// </summary>
public class InventorySystem : MonoBehaviour
{
    #region Singletoon
    public static InventorySystem Instance;
    private void Awake() // If there is an instance, and it's not me, delete myself.
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public int AppleCount;
    public int BannanaCount;
    public int CherryCount;
    [Space(8)]
    [Header("--------TextMeshPro Propeties--------")]
    [SerializeField] TMP_Text Text_AppleCount;
    [SerializeField] TMP_Text Text_CherryCount;
    [SerializeField] TMP_Text Text_BannanaCount;

    public void AddItem_to_Inventory(string tag, GameObject gameobject_Item)// when the player collide with Items this method called to Save Items in Inventory.
    {
        switch (tag)
        {
            case "Item_Apple":
                AppleCount++;
                UpdateTextUi(AppleCount, Text_AppleCount);
                Destroy(gameobject_Item);
                print(" AppleCount++");
                break;
            //------------------------------------
            case "Item_Bannana":
                BannanaCount++;
                UpdateTextUi(BannanaCount, Text_BannanaCount);
                Destroy(gameobject_Item);
                print(" BannanaCount++");
                break;
            //------------------------------------
            case "Item_Cherry":
                CherryCount++;
                UpdateTextUi(CherryCount, Text_CherryCount);
                Destroy(gameobject_Item);
                print("  CherryCount++");
                break;
            //------------------------------------
        }
    }

    void UpdateTextUi(int Count, TMP_Text text)
    {
        text.text = Count.ToString();
    }

    #region Instatiate Item
    [Space(8)]
    [Header("-----Instatiate Item Propeties-----")]
    [SerializeField] Transform InstatiateItemPosition;
    [SerializeField] GameObject Apple;
    [SerializeField] GameObject Bannana;
    [SerializeField] GameObject Cherry;
    public void InstantiateItem_Apple()//---------------This method is called by the unityEvent (Ui Button).
    {
        InstatiateItem(ref AppleCount, Apple, Text_AppleCount);
    }
    public void InstantiateItem_Bannana()//---------------This method is called by the unityEvent (Ui Button).
    {
        InstatiateItem(ref BannanaCount, Bannana, Text_BannanaCount);
    }

    public void InstantiateItem_Cherry()//---------------This method is called by the unityEvent (Ui Button).
    {
        InstatiateItem(ref CherryCount, Cherry, Text_CherryCount);
    }


    IEnumerator enumerator;
    void InstatiateItem(ref int count, GameObject item, TMP_Text text)
    {
        if (count > 0)
        {

            count -= 1;
            UpdateTextUi(count, text);
            GameObject Gm = Instantiate(item, InstatiateItemPosition.position, Quaternion.identity);

            //Destroy(Gm, 10);
            enumerator = Gm.GetComponent<Item_AutoDelete>().DeleteWithDelay(10);
            StartCoroutine(enumerator);
            print("Instantiate Item : " + item.name);
        }

    }
    #endregion

    #region Destroy All Item
    GameObject[] apples;
    GameObject[] bananas;
    GameObject[] cherries;
    public void DestroyAllItem()//---------------This method is called by the unityEvent (Ui Button).
    {
        // Find all GameObjects with the required tags
        apples = GameObject.FindGameObjectsWithTag("Item_Apple");
        bananas = GameObject.FindGameObjectsWithTag("Item_Bannana");
        cherries = GameObject.FindGameObjectsWithTag("Item_Cherry");

        // Loop through each array and destroy the gameObjects
        foreach (GameObject apple in apples)
        {
            Destroy(apple);
        }

        foreach (GameObject banana in bananas)
        {
            Destroy(banana);
        }

        foreach (GameObject cherry in cherries)
        {
            Destroy(cherry);
        }

        print("Destroy All Item");
    }
    #endregion
}

