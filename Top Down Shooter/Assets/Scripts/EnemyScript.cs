using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public bool isDead = false;
    public GameObject player;
    public float speed = 6f;
    private Rigidbody rb;
    float rotationSpeed = 1f;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

        // get target object tobe rotated at
        player = GameObject.FindGameObjectWithTag("Player") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == true)
        {
            Destroy(this.gameObject, 0f);
        }


        if (player == null) 
        { Debug.Log("[ERROR] => Traget object is null , Can't Rotate"); 
            return; } 

        // get position of player
        Vector3 playerPosition = player.transform.position; 
        Quaternion playerRotation = Quaternion.LookRotation(playerPosition - transform.position); 
        transform.rotation = Quaternion.Slerp(transform.rotation, playerRotation, rotationSpeed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.fixedDeltaTime);
        rb.MovePosition(pos);
        transform.LookAt(player.transform);
    }
}
