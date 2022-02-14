using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Vector3 _direction;
    private string _enemyTag;
    public float speed;
    public float livingTimer = 3f;
    public float knockupRate = 1f;

    [SerializeField] public GameObject _particlePrefab;
    private GameObject _gameManager;
    IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(livingTimer);
        _gameManager.GetComponent<LevelManager>().AddLog(4);
        GameObject.Destroy(gameObject);
    }
    void Start()
    {
        _gameManager = GameObject.Find("Game Manager");
        _gameManager.GetComponent<LevelManager>().AddLog(1);
        StartCoroutine(Lifetime());
    }
    public void SetupBullet(Vector3 vector,string enemyTag)
    {
        _enemyTag = enemyTag;
        _direction = vector;
    }
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().velocity = _direction * speed;
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, 0.1f);
        if (hitColliders.Length > 0)
        {
            foreach(Collider collider in hitColliders)
            {
                if (collider.tag == _enemyTag)
                {
                    _gameManager.GetComponent<LevelManager>().AddLog(2);
                    GameObject particleObject = Instantiate(_particlePrefab, transform.position, Quaternion.identity);
                    
                    if (_enemyTag == "Player")
                    {
                        GameObject.Find("Player").GetComponent<CharacterController>().
                            Move(new Vector3(gameObject.transform.forward.x, 0
                            , gameObject.transform.forward.z) * knockupRate);
                        GameObject.Destroy(gameObject);
                    }
                    else
                    {
                        GameObject.Destroy(collider.gameObject);
                    }
                }
                if (collider.tag == "Block")
                {
                    _gameManager.GetComponent<LevelManager>().AddLog(3);
                    GameObject particleObject = Instantiate(_particlePrefab, transform.position, Quaternion.identity);
                    GameObject.Destroy(gameObject);
                }
            }
            
        }
    }
}
