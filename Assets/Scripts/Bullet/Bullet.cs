using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _myBody;

    public void Move(float speed)
    {
        _myBody.AddForce(transform.forward.normalized * speed);
        Invoke("DestroyBullet", 1.0f);
    }

    void DestroyBullet()
    {
        Destroy(this.gameObject, 3.0f);
    }
}
