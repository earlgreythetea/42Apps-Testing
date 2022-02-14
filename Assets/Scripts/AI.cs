using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 3.0f;
    public bool strandingMode = false;
    public float obstacleRange = 5.0f;
    public float shootingTimer = 3f;

    [SerializeField] GameObject bulletPrefab;
    IEnumerator ShootingTimer()
    {
        yield return new WaitForSeconds(shootingTimer);
        GameObject bullet = Instantiate(bulletPrefab, gameObject.transform.position, GameObject.Find("Player").transform.rotation);
        bullet.transform.LookAt(GameObject.Find("Player").transform.position, Vector3.down);
        bullet.GetComponent<BulletBehaviour>().SetupBullet(bullet.transform.forward, "Player");
        StartCoroutine(ShootingTimer());
    }
    private void Start()
    {
        StartCoroutine(ShootingTimer());
    }
    void Update()
    {
        if (strandingMode)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit; if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                if (hit.distance < obstacleRange)
                {
                    transform.Rotate(0, 180, 0);
                }
            }
        }
    }
}

