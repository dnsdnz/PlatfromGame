using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public static BulletController Instance; 
    
    public float bulletSpeed;  //how fast bullet go
    public float fireRate;  //bullet's creation frequency
    
    [SerializeField]
    private GameObject bullet;  //bullet's prefab
    [SerializeField]
    private Transform shotPoint;  //bullet's creation position
    [SerializeField]
    private float lastShoot;  //last time that bullet shooted
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (InputController.Instance.isStarted) //shoot starts with game start
        {
            CreateBullets();
        }    
    }
    private void CreateBullets()
    {
        if (Time.time > fireRate + lastShoot)  //compare with current time
        {
            Instantiate(bullet, shotPoint.position, Quaternion.identity);  //bullet creation
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;  //bullet's speed and direction
            lastShoot = Time.time;
        }
    }
}