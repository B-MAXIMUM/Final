using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
[SerializeField] private float _moveSpeed = 10f;

    // Start is called before the first frame update
    public AudioClip walk;
    private AudioSource _Paud;
    private float movementThreshold = 0.1f; // Adjust this value to set the minimum movement required
    private Vector3 lastPosition;
    public float turnsmoothTime = 0.1f;
    public float turnSmoothVelocity;
    private float xValue;
    private float zValue;
    public Transform Cam;
    void Start()
    {
       lastPosition = transform.position;
        _Paud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Vector3 currentPosition = transform.position;
        float distance = Vector3.Distance(currentPosition, lastPosition);

        if (distance > movementThreshold)
        {
            float targetAngle = Mathf.Atan2(xValue , zValue) * Mathf.Rad2Deg + Cam.eulerAngles.y;
            float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnsmoothTime);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            Debug.Log("Movement detected!");
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            _Paud.loop = true;
            _Paud.clip = walk;
            _Paud.Play();

            // Additional logic or actions can be performed here
        }
        else
        {
            _Paud.Stop();
        }

        lastPosition = currentPosition;
    }

    void Movement()
    {
        xValue = Input.GetAxis("Horizontal") * _moveSpeed * Time.deltaTime;
        zValue = Input.GetAxis("Vertical") * _moveSpeed * Time.deltaTime;

        transform.Translate(xValue, 0f, zValue);
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Heal"))
        {
            Gamemanager.Instance.GainHp();
        }
        if(other.gameObject.CompareTag("Enemy"))
        {
            Gamemanager.Instance.looseHpOrDeath();
        }
        if(other.gameObject.CompareTag("Win"))
        {
            Gamemanager.Instance.win();
        }
    }
}