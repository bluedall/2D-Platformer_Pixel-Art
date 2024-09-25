using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class is responsible for Destroy this Gameobject After delay.
/// </summary>
public class Item_AutoDelete : MonoBehaviour
{
    public IEnumerator DeleteWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        DestroyImmediate(gameObject);
    }
}
