using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBullet : MonoBehaviour
{
    public Transform firePoint;

    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    private bool canshoot = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") &&(!canshoot) )
        {
            StartCoroutine (FireShot ());
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rd = bullet.GetComponent<Rigidbody>();
        rd.AddForce(firePoint.up * bulletForce, ForceMode.Impulse);
    }

    IEnumerator FireShot() {
         
             canshoot = true;
             Shoot ();
             yield return new WaitForSeconds (0.5f);
             canshoot = false;
 
    }
}
