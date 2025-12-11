using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [Header("Setup")]
    public BoxCollider2D boxCollider2D;
    public string compareTag = "Player";
    public GameObject endGameUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            endGameUI.SetActive(true);
            PauseManager.Instance.Pause();
        }
    }
}
