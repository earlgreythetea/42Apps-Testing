using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] public Canvas targetCanvas;
    [SerializeField] public GameObject gameManager;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Player")
        {
            gameManager.GetComponent<LevelManager>().AddLog(5);
            targetCanvas.GetComponent<CanvasManager>().DrawWinningMessage();
            StartCoroutine(gameManager.GetComponent<LevelManager>().GameEnding());
        }
    }
}
