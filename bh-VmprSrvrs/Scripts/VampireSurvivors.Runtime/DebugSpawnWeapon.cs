using System.Collections.Generic;
using UnityEngine;

public class DebugSpawnWeapon : MonoBehaviour
{
	[SerializeField]
	private bool Loop;

	[SerializeField]
	private GameObject _particleSystemToSpawn;

	[SerializeField]
	private List<GameObject> SpawnedFXs;

	[SerializeField]
	private float _spawnTimeInterval;

	private float _time;

	private Vector3 offset;

	[SerializeField]
	private Vector3 offsetAmount;

	private void Start()
	{
	}

	private void Update()
	{
	}
}
