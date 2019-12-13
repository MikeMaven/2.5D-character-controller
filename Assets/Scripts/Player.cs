using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _speed = 3.0f;
    private float _gravity=  1.3f;
    private CharacterController _controller;
    private float _jumpHeight = 22.0f;
    private float _yVelocity;
    private bool _canDoubleJump;
    private int _coins = 0;
    [SerializeField]
    private UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("UICanvas").GetComponent<UIManager>();
        if(!_uiManager)
        {
            Debug.Log("UI Manager is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0 , 0);
        Vector3 velocity = direction * _speed;
        // if !grounded
        // apply gravity
        if (_controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && _canDoubleJump)
            {
                _yVelocity += _jumpHeight;
                _canDoubleJump = false;
            }
            _yVelocity  -= _gravity;
        }
        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }

    public void AddCoinToInventory()
    {
        _coins++;
        _uiManager.UpdateCoins(_coins);
    }
}
