using System;
using UnityEngine;

namespace NGS.MeshFusionPro.Example
{
	public class SpawnZone : MonoBehaviour
	{
		[SerializeField]
		private GameObject[] _sources;

		[SerializeField]
		private float _spawnRadius;

		[SerializeField]
		private int _spawnCount;

		[SerializeField]
		private float _minExtrude;

		[SerializeField]
		private float _maxExtrude;

		private void Awake()
		{
			base.enabled = false;
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Spawn();
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			base.enabled = true;
		}

		private void OnTriggerExit(Collider other)
		{
			base.enabled = false;
		}

		private void Spawn()
		{
			for (int i = 0; i < _spawnCount; i++)
			{
				GameObject obj = UnityEngine.Object.Instantiate(_sources[UnityEngine.Random.Range(0, _sources.Length)]);
				Vector3 spawnPosition = GetSpawnPosition();
				obj.transform.position = spawnPosition;
				obj.transform.rotation = UnityEngine.Random.rotation;
			}
		}

		private Vector3 GetSpawnPosition()
		{
			Vector3 position = base.transform.position;
			position.x += UnityEngine.Random.insideUnitCircle.x * _spawnRadius;
			position.y = 1000f;
			position.z += UnityEngine.Random.insideUnitCircle.y * _spawnRadius;
			if (Physics.Raycast(new Ray(position, Vector3.down), out var hitInfo))
			{
				Vector3 point = hitInfo.point;
				point.y += UnityEngine.Random.Range(_minExtrude, _maxExtrude);
				return point;
			}
			throw new InvalidOperationException();
		}
	}
}
