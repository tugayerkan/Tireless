using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset;

    //public IEnumerator Shake(float duration, float magnitude)
    //{
    //    Vector3 originalPos = transform.localPosition;
    //    float elapsed = 0.0f;

    //    while (elapsed < duration)
    //    {
    //        float x = Random.Range(-1f, 1f) * magnitude;
    //        float y = Random.Range(-1f, 1f) * magnitude;

    //        transform.localPosition = new Vector3(x, y, originalPos.z);

    //        elapsed += Time.deltaTime;

    //        yield return null;
    //    }
    //    transform.localPosition = originalPos;
    //}
    void Update()
    {
        transform.position = Player.position + offset;
    }
}
