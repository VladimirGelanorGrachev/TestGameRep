using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroid
{
    public class Mover : MonoBehaviour
    {
        public float _speed;
        private void Start()
        {
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().transform.forward * _speed;
        }
    }
}
