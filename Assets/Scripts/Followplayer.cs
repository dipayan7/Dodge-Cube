using UnityEngine;

public class Followplayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = player.position + offset;
    }
}
