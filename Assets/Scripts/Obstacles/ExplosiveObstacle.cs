using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveObstacle : MonoBehaviour
{
    public GameObject explosionPrefab;
    public int damage;
    
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            other.gameObject.GetComponent<PlayerHealth>().Damage(damage);
            Destroy(this.gameObject, 0.2f);
        }

        if(other.gameObject.tag == "Bullet")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject, 0.2f);
        }
    }
}
