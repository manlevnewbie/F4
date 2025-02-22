using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferMap : MonoBehaviour
{
    public string transferMapName;
    public Transform target;
    public BoxCollider2D targetBound;
    private PlayerManager thePlayer;
    private CameraManager theCamera;
    private FadeManager theFade;
    void Start()
    {
        theCamera = FindObjectOfType<CameraManager>();
        thePlayer = FindObjectOfType<PlayerManager>();
        theFade = FindObjectOfType<FadeManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player(Main)")
        {
            StopAllCoroutines();
            StartCoroutine(TransforCoroutine());
        }
    }
    IEnumerator TransforCoroutine()
    {
        theFade.FadeOut();
        yield return new WaitForSeconds(1.0f);
        thePlayer.currentMapName = transferMapName;
        theCamera.SetBound(targetBound);
        theCamera.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, theCamera.transform.position.z);
        thePlayer.transform.position = target.transform.position;
        theFade.FadeIn();
    }
}
