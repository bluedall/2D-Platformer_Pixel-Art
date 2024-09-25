using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class is responsible for Destroy this Gameobject After delay.
/// </summary>
public class Item_AutoDelete : MonoBehaviour
{
    private bool isDestroyed = false;
    public IEnumerator DeleteWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (!isDestroyed)
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        isDestroyed = true;
        print("OnDestroy Method");
    }
}
