using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            EnemyScript enemyScript = collision.transform.GetComponent<EnemyScript>();
            enemyScript.isDead = true;
        }
        Destroy(this.gameObject, 0.1f);
    }
}
