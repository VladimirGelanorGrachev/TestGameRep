using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroid
{
    public class DestroyByBoundary : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            Destroy(other.gameObject);
        }
    }
}
