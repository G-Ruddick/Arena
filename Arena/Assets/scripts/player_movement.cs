using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerBehavior : MonoBehaviour
{
    public float MoveSpeed = 10f, RotateSpeed = 75f, JumpVelocity = 10f;
    public float DistanceToGround = 0.1f;
    private float _vInput, _hInput;
    private bool _isJumping;
    private Rigidbody _rb;
    public LayerMask GroundLayer;
    private SphereCollider _col;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<SphereCollider>();
    }
    
    void Update()
    {
        _vInput = Input.GetAxis("Vertical") * MoveSpeed;
        _hInput = Input.GetAxis("Horizontal") * RotateSpeed;
        
        this.transform.Translate(Vector3.forward * _vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * _hInput * Time.deltaTime);

        _isJumping |= Input.GetKeyDown(KeyCode.J);
    }

    void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * _hInput;  
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        
        _rb.MovePosition(this.transform.position + this.transform.forward * _vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);

        if (_isJumping)
        {
            _rb.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);
        }
        _isJumping = false;

    }
}