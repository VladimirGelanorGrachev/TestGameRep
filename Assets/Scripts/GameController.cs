using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace Asteroid
{
    public class GameController : MonoBehaviour
    {
        public GameObject[] _hazards;
        public Vector3 _spawnValues;
        public int _hazardCount;
        public float _spawnWait;
        public float _startWave;
        public float _waveWait;
        public Text _scoreText;
        private int _score;
        public Text _restartText;
        public Text _gameOverText;
        private bool _gameOver;
        public bool _restart;

        void Start()
        {
            _gameOver = false;
            _restart = false;

            _restartText.text = "";
            _gameOverText.text = "";
            _score = 0;
            UpdateScore();

            StartCoroutine(SpawnWaves());
        }
        void Update()
        {
            if (_restart)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
        IEnumerator SpawnWaves()
        {
            yield return new WaitForSeconds(_startWave);
            while (true)
            {
                for (int i = 0; i < _hazardCount; i++)
                {
                    Vector3 spawnPosition = new Vector3(Random.Range(-_spawnValues.x, _spawnValues.x), _spawnValues.y, _spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    GameObject _hazard = _hazards[Random.Range(0, _hazards.Length)];
                    Instantiate(_hazard, spawnPosition, spawnRotation);

                    yield return new WaitForSeconds(Random.Range(0.5f, _spawnWait));
                }
                yield return new WaitForSeconds(_waveWait);
                if (_gameOver)
                {
                    _restartText.text = "Press 'R' for restart";
                    _restart = true;
                    break;
                }
            }
        }
        void UpdateScore()
        {
            _scoreText.text = "Points: " + _score;
        }
        public void AddScore(int newScoreValue)
        {
            _score += newScoreValue;
            UpdateScore();
        }

        public void GameOver()
        {
            _gameOverText.text = "GameOver";
            _gameOver = true;
        }
    }
}