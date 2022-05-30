using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroid
{
    public class DestroyByContact : MonoBehaviour
    {
        public GameObject _explosion;
        public GameObject _explosionPlayer;
        private GameObject _cloneExplosion;
        public int _scoreValue;
        private GameController _gameController;        
        private void Start()
        {
            GameObject GameControllerObject = GameObject.FindWithTag("GameController");
            if (GameControllerObject != null)
            {
                _gameController = GameControllerObject.GetComponent<GameController>();
            }
            if (GameControllerObject == null)
            {
                Debug.Log("GameController not find");
            }            
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Bolt")
            {
                _cloneExplosion = Instantiate(_explosion, GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().rotation) as GameObject;
                Destroy(other.gameObject);
                Destroy(gameObject);
                Destroy(_cloneExplosion, 1f);
                _gameController.AddScore(_scoreValue);

            }
            if (other.tag == "Player")
            {         
              
                    _cloneExplosion = Instantiate(_explosionPlayer, GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().rotation);
                    _gameController.GameOver();
                    Destroy(other.gameObject);
                    Destroy(gameObject);
                    Destroy(_cloneExplosion, 1f);
                
            }
        }
    }
}
