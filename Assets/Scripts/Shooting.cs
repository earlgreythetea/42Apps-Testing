using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    [SerializeField] public GameObject bulletPrefab;

    public float raycastDistance = 2f;
    
    [SerializeField] Camera _camera;
    private ReactiveTarget currentTarget;
    private GameObject hitObject;
    private Ray ray;

    void Start()
    {
        _camera = Camera.main;
        //_camera.GetComponentInParent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    void Update()
    {

        Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
        ray = _camera.ScreenPointToRay(point);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        { 
            hitObject = hit.transform.gameObject;
            ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
            if (target != null)
            {
                if (currentTarget != null)
                    currentTarget.SwitchColor(Color.red);
                currentTarget = target;
                currentTarget.SwitchColor(Color.yellow);
            }
            else if (currentTarget != null)
            {
                currentTarget.SwitchColor(Color.red);
            }
            
        }
        else if (currentTarget != null)
        {
            currentTarget.SwitchColor(Color.red);
        }
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.identity);
            bullet.GetComponent<BulletBehaviour>().SetupBullet(ray.direction,"Enemy");
        }
    }
}
