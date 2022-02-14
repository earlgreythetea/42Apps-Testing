using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Lifetime());
    }
    IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject.Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
