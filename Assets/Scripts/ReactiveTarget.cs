using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    // Start is called before the first frame update
    private Color _agentColor;

    public float agentSpeed = 1f;
    void Start()
    {
        
    }
    public void SwitchColor(Color color)
    {
        gameObject.GetComponent<Renderer>().material.color = color;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
