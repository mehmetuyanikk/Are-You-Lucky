using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform _body;
    [SerializeField] float _speed;

    private void FixedUpdate()
    {
        _body.transform.position += new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * _speed, Input.GetAxis("Vertical") * Time.deltaTime * _speed);
    }

}
