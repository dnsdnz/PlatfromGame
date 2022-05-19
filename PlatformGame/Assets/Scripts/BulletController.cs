using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform shotPoint;
    private void Update()
    {
        if (InputController.Instance.isStarted)
        {
            Instantiate(bullet,shotPoint.position,Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
        }    
    }
}