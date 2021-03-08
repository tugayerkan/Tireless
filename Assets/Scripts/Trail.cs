using UnityEngine;

public class Trail : MonoBehaviour
{
    public Rigidbody player;
    void Update()
    {
        Vector3 pos = player.transform.position;
        transform.position = pos;
    }
}
