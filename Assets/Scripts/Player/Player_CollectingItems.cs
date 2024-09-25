using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// this class is responsible for destroy Item after add it to Inventory.
/// </summary>
public class Player_CollectingItems : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        InventoryManagment.Instance.AddItem(collision.transform.tag, collision.gameObject);

        //Play Particle 
        //Play Sound Effect
    }

}
