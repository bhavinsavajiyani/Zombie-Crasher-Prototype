using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public Vector3 speed;
    public float x_Speed = 8.0f, z_Speed = 15.0f; // _xSpeed = Left/Right Movement Speed & _zSpeed = Forward/Backward Movement Speed

    //Speed when moving forward and slowing down
    public float accelarated = 25.0f, deaccelarated = 10.0f;

    protected float rotationSpeed = 10.0f;
    protected float maxAngle = 10.0f;

    public float low_Sound_Pitch, normal_Sound_Pitch, high_Sound_Pitch;
    private AudioSource _audioSource;
    public AudioClip engine_On_Sound, engine_Off_Sound;
    private bool _isSlow;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        speed = new Vector3(0f, 0f, z_Speed);    
    }

    protected void MoveLeft()
    {
        speed = new Vector3(-x_Speed / 2.0f, 0f, speed.z);
    }

    protected void MoveRight()
    {
        speed = new Vector3(x_Speed / 2.0f, 0f, speed.z);
    }

    protected void MoveStraight()
    {
        speed = new Vector3(0f, 0f, speed.z);
    }

    protected void MoveNormal()
    {
        if(_isSlow)
        {
            _isSlow = false;

            _audioSource.Stop();
            _audioSource.clip = engine_On_Sound;
            _audioSource.volume = 0.3f;
            _audioSource.Play();
        }

        speed = new Vector3(speed.x, 0f, z_Speed);
    }

    protected void MoveSlow()
    {
        if(!_isSlow)
        {
            _isSlow = true;

            _audioSource.Stop();
            _audioSource.clip = engine_Off_Sound;
            _audioSource.volume = 0.5f;
            _audioSource.Play();
        }

        speed = new Vector3(speed.x, 0f, deaccelarated);
    }

    protected void MoveFast()
    {
        speed = new Vector3(speed.x, 0f, accelarated);
    }
}
