using UnityEngine;
namespace Asteroid
{

    [System.Serializable]
    public class Boundary
    {
        public float xMin, xMax, zMin, zMax;
    }

    public class Player : MonoBehaviour
    {
        [SerializeField] float _maxHealth = 100;
        [SerializeField] float _currentHealth;
        [SerializeField] float _speed;
        public Boundary _boundary;
        public float tilt;
        public GameObject _shot;
        public Transform _shotSpawn;
        public float _fireRate = 0.5f;
        public float _nextFire = 0.0f;


        private void Update()
        {
            if (Input.GetButton("Fire1") && Time.time > _nextFire)
            {
                _nextFire = Time.time + _fireRate;
                Instantiate(_shot, _shotSpawn.transform.position, _shotSpawn.rotation);
                GetComponent<AudioSource>().Play();
            }

        }


        void FixedUpdate()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            GetComponent<Rigidbody>().rotation = Quaternion.Euler
                (
                0f,
                0f,
                GetComponent<Rigidbody>().velocity.x * -tilt
                );
            GetComponent<Rigidbody>().velocity = new Vector3(moveHorizontal, 0f, moveVertical) * _speed;

            GetComponent<Rigidbody>().position = new Vector3
            (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, _boundary.xMin, _boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, _boundary.zMin, _boundary.zMax)
            );


        }
    }
}
