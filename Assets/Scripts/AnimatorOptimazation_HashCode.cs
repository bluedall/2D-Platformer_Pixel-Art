using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  This class is responsible for Getting HashCode to Optimaze using Animator.
/// </summary>
public class AnimatorOptimazation_HashCode : MonoBehaviour
{
    [HideInInspector] public int ID_Jump;
    [HideInInspector] public int ID_IsRuning;
    public void Start()
    {
        ID_Jump = Animator.StringToHash("Jump");
        ID_IsRuning = Animator.StringToHash("IsRuning");
    }
}
