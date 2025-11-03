using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] public float speed;
    [SerializeField] public float runSpeed;

    private Rigidbody2D rig;

    private float initialSpeed;
    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;
    private Vector2 _direction;

    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }
    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    public bool IsCutting { get => _isCutting; set => _isCutting = value; }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }

    private void Update()
    {
        onImput();
        onRun();
        onRolling();
        onCutting();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    #region Moviment
    void onImput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    }

    void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void onRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            _isRunning = false;
        }
    }

    void onRolling()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _isRolling = true;
            speed = runSpeed;
        }
        if (Input.GetMouseButtonUp(1))
        {
            _isRolling = false;
            speed = initialSpeed;
        }

    }
    
    void onCutting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isCutting = true;
            speed = 0;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _isCutting = false;
            speed = initialSpeed;
            
        }

    }


    #endregion
}
