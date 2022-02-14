using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{

    [SerializeField] TMPro.TextMeshProUGUI textMesh;
    // Update is called once per frame
    private void Start()
    {
        //textMesh = GetComponentInChildren<TMPro.TextMeshPro>();
    }
    public void ClearMessage()
    {
        textMesh.text = "";
    }
    public void DrawWinningMessage()
    {
        textMesh.text = "Выиграл";
    }
    public void DrawLosingMessage()
    {
        textMesh.text = "Проиграл";
    }
    void Update()
    {
        
    }
}
