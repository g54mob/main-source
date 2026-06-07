using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
	[Tooltip("Seed to use for spawning the obstacles for a consistent test environment.")]
	[SerializeField]
	private int _seed = 20171108;

	[Tooltip("Obstacle prefab to spawn.")]
	[SerializeField]
	private Obstacle _obstaclePrefab;

	[Tooltip("Interval to spawn obstacles.")]
	[SerializeField]
	private float _spawnTimer = 10f;

	[SerializeField]
	private float _obstacleSpeed = 1f;

	private float _timer;

	private List<Obstacle> _obstaclesInGame = new List<Obstacle>();

	private void Start()
	{
		Random.InitState(_seed);
	}

	private void Update()
	{
		_timer -= Time.deltaTime;
		if (_timer <= 0f)
		{
			Vector3 position = new Vector3(Random.Range(20, 480), 0f, 0f);
			_ = Random.rotation;
			Obstacle obstacle = Object.Instantiate(_obstaclePrefab, position, Quaternion.identity);
			obstacle.transform.localScale = Vector3.one * Random.Range(1, 20);
			obstacle.SetRadius();
			_obstaclesInGame.Add(obstacle);
			_timer = _spawnTimer;
		}
		foreach (Obstacle item in _obstaclesInGame)
		{
			item.transform.Translate(Vector3.forward * Time.deltaTime * _obstacleSpeed);
		}
	}
}
