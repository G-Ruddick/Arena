using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float originalSpeed;
    public float RotateSpeed = 100f;
    public float JumpVelocity = 10f;
    public bool isJumping;
    public float _vInput;
    public float _hInput;
    private bool jumpInput;
    private bool isGrounded;
    private Rigidbody _rb;
    private SphereCollider _col;
    public LayerMask GroundLayer;

    public GameObject Bullet;
    public float BulletSpeed = 100f;
    private bool isShooting;

    public bool speedBoost;
    
    void Start()
    {
        Physics.gravity = new Vector3(0, -20f, 0);
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<SphereCollider>();
        originalSpeed = MoveSpeed;
    }
    
    void Update()
    {
        _vInput = Input.GetAxis("Vertical");
        _hInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetKey(KeyCode.Space);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isShooting = true;
        }

        if (speedBoost)
        {
            StartCoroutine(SpeedDecrease());
            speedBoost = false;
        }
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * _vInput * MoveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * _hInput * RotateSpeed * Time.deltaTime);

        Vector3 groundCheckPos = transform.position + Vector3.down * (_col.radius - 0.05f);
        isGrounded = Physics.CheckSphere(groundCheckPos, 0.1f, GroundLayer);

        // Jump
        if (jumpInput && isGrounded)
        {
            _rb.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);
        }

        // Shooting
        if (isShooting)
        {
            Vector3 spawnPos = transform.position + transform.forward * 1f;
            GameObject newBullet = Instantiate(Bullet, spawnPos, transform.rotation);
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();

            bulletRB.linearVelocity = transform.forward * BulletSpeed;
        }

        isShooting = false;
    }

    IEnumerator SpeedDecrease()
    {        
        yield return new WaitForSeconds(3f);

        while (MoveSpeed > originalSpeed)
        {
            yield return new WaitForSeconds(.05f);
            MoveSpeed -= 0.3f;

        }
        if (MoveSpeed < originalSpeed)
        {
            MoveSpeed = originalSpeed;
        }
    }    
}