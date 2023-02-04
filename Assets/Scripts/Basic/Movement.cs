using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    private void Update()
    {
        float currPositionX = Mathf.MoveTowards(transform.position.x, _target.position.x, _speed * Time.deltaTime);
        transform.position = new Vector3(currPositionX, transform.position.y, transform.position.z);
    }
}
