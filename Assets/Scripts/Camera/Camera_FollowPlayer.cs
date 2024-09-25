using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
/// <summary>
/// This class is responsible for following the player by the camera smoothly.
/// </summary>
public class Camera_FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform Player;
    void FixedUpdate()
    {
        CameraFollowPlayer();
    }



    [SerializeField] Vector3 CurrentVelocity;
    [SerializeField] float SmoothTime;
    [SerializeField] float MaxSpeed;
    Vector3 pos;
    void CameraFollowPlayer()
    {
        pos = new Vector3(Player.position.x, Player.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref CurrentVelocity, SmoothTime * Time.deltaTime, MaxSpeed);
    }
}
