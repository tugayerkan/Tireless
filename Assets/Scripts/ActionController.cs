using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ActionController : MonoBehaviour
{
    public Material Red;
    public GameObject Whitelight;
    public GameObject RedLight;
    public HitForce hit;
    private float MoveDuration = 1.0f;
    public GameObject cameraMove;

    void Start()
    {
        cameraMove.transform.DOLocalRotate(cameraMove.transform.localEulerAngles + new Vector3(0, 25, 0), 2f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("geçti");
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = Red;
            Whitelight.SetActive(false);
            RedLight.SetActive(true);
            StartCoroutine(hit.Triggered());
            transform.DOMoveY(transform.position.y + 1, MoveDuration).SetEase(Ease.InOutFlash).SetLoops(-1, LoopType.Yoyo);
        }
    }

    void Update()
    {
                             
    }
}
