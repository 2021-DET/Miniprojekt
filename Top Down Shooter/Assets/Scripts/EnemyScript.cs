using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public bool isDead = false;
    public GameObject player;
    public float speed = 4f;
    private Rigidbody rb;
    float rotationSpeed = 1f;
    public GameObject explosionPrototype;
    public GameObject score;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        score = GameObject.FindGameObjectWithTag("Canvas") as GameObject;
        // get target object tobe rotated at
        player = GameObject.FindGameObjectWithTag("Player") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == true)
        {
            Instantiate (explosionPrototype , transform.position , transform.rotation);
            if (score != null)
            {
                score.GetComponent<ScoreScript>().scoreValue++;
            }
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
