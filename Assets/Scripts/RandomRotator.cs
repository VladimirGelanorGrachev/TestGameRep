using UnityEngine;
using System.Collections;
namespace Asteroid
{
    public class RandomRotator : MonoBehaviour
    {
        [SerializeField]
        private float tumble;
        void Start()
        {
            GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
        }
    }
}