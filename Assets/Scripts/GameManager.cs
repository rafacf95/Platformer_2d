using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{
    [Header("Player")]
    public GameObject playerPrefab;

    [Header("Enemies")]
    public List<GameObject> enemies;

    [Header("References")]
    public Transform startPoint;

    [Header("Animation Setup")]
    public float duration = .2f;
    public float delay = .05f;
    public List<GameObject> buttons;
    public Ease ease = Ease.OutBack;

    private GameObject _currentPlayer;

    public void Init()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        _currentPlayer = Instantiate(playerPrefab);
        _currentPlayer.transform.position = startPoint.transform.position;
        _currentPlayer.SetActive(true);
        _currentPlayer.transform.DOScale(0, duration).SetEase(ease).From();
    }

    void Start()
    {
        Init();
    }
}
