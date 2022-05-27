using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroid
{
    public class ScrollBackGround : MonoBehaviour
    {
        public float _scrollSpeed;
        public float _tileSize;
        private Transform _currentObject;

        private void Start()
        {
            _currentObject = GetComponent<Transform>();
        }

        private void Update()
        {
            _currentObject.position = new Vector3
                (
                _currentObject.position.x,
                _currentObject.position.y,
                Mathf.Repeat(Time.time * _scrollSpeed, _tileSize)
                );
        }
    }
}
