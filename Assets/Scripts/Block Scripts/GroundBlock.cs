using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBlock : MonoBehaviour
{
    public Transform otherBlock;
    public float halfLength = 100f;
    private Transform _player;
    private float endOffset = 10f;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        MoveGround();
    }

    void MoveGround()
    {
        if(transform.position.z + halfLength < _player.transform.position.z - endOffset)
        {
            transform.position = new Vector3(otherBlock.position.x, otherBlock.position.y, 
                otherBlock.position.z + halfLength * 2);
        }
    }
}
