using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _pointA, _pointB;
    private Transform _currentTarget;
    private float _speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        _currentTarget = _pointB;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, _speed * Time.deltaTime);
        if (transform.position == _pointB.position)
        {
            _currentTarget = _pointA;
        }
        else if (transform.position == _pointA.position)
        {
            _currentTarget = _pointB;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }    
    }
}
