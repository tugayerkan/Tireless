using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenContoller : MonoBehaviour
{
    [Range(1.0f, 10.0f), SerializeField]
    private float MoveDuration = 1.0f;

    void Start()
    {
        transform.DOMoveY(transform.position.y + 1, MoveDuration).SetEase(Ease.InOutFlash).SetLoops(-1, LoopType.Yoyo);
        transform.DOLocalRotate(new Vector3(0, transform.eulerAngles.y + 30, 0), 1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);

    }
}
