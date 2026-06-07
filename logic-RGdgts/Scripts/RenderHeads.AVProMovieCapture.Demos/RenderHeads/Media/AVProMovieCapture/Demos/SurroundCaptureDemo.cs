using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture.Demos
{
	public class SurroundCaptureDemo : MonoBehaviour
	{
		[SerializeField]
		private Transform _spawnPoint;

		[SerializeField]
		private GameObject _cubePrefab;

		[SerializeField]
		private bool _spawn;

		private const int MaxCubes = 48;

		private const float SpawnTime = 0.25f;

		private float _timer;

		private List<GameObject> _cubes;

		private void Update()
		{
		}

		private void SpawnCube()
		{
		}

		private void RemoveCube()
		{
		}

		private IEnumerator KillCube(GameObject go)
		{
			return null;
		}
	}
}
