using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingHay : MonoBehaviour
{
    public float limitHayMov = 21;
    public GameObject hayBalePrefab;
    public Transform haySpawnpoint;
    public float shootInterval;
    private float shootTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalInput = Input.GetAxisRaw("Horizontal");   

        if (HorizontalInput < 0 && transform.position.x > -limitHayMov){
            transform.Translate(-transform.right * 10 * Time.deltaTime);

        } if (HorizontalInput > 0 && transform.position.x < limitHayMov)
        {
            transform.Translate(transform.right * 10 * Time.deltaTime);
        }

        UpdateShooting();

    }

    private void UpdateShooting()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space))
        {
            shootTimer = shootInterval;
            ShootHay();
        }
    }

    private void ShootHay()
    {
        Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);
    }
}
