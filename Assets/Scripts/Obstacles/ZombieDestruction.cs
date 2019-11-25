using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDestruction : MonoBehaviour
{
    public GameObject bloodFXPrefab;
    public float speed;
    private Rigidbody _myBody;
    private bool _isAlive;

    // Start is called before the first frame update
    void Start()
    {
        _myBody = GetComponent<Rigidbody>();
        _isAlive = true;
        speed = Random.Range(1.0f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if(_isAlive)
        {
            _myBody.velocity = new Vector3(0f, 0f, -speed);

        }

        if(transform.position.y < -8.0f)
        {
            Destroy(this.gameObject, 2.0f);
        }
    }

    void Die()
    {
        _isAlive = false;
        _myBody.velocity = Vector3.zero;
        GetComponent<Collider>().enabled = false;
        GetComponentInChildren<Animator>().Play("Idle");

        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        transform.localScale = new Vector3(1f, 1f, 0.2f);
        transform.position = new Vector3(transform.position.x, 0.2f, transform.position.z);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Bullet")
        {
            Instantiate(bloodFXPrefab, new Vector3(transform.position.x, 1.0f, transform.position.z), Quaternion.identity);
            Die();
            //Increase Score
            Destroy(this.gameObject, 3.0f);
        }    
    }
}
