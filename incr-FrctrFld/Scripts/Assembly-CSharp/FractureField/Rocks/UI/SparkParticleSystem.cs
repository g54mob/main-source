using System.Collections.Generic;
using UnityEngine;

namespace FractureField.Rocks.UI
{
	public class SparkParticleSystem : MonoBehaviour
	{
		private struct SparkRequest
		{
			public Vector3 Position;

			public RockLayerType LayerType;

			public int RequestedCount;
		}

		private static SparkParticleSystem instance;

		[Header("Spark Prefab")]
		[SerializeField]
		private GameObject sparkPrefab;

		[Header("Spawn Settings")]
		[SerializeField]
		private int sparkCount;

		[SerializeField]
		private float minSpeed;

		[SerializeField]
		private float maxSpeed;

		[SerializeField]
		private float sparkLifetime;

		[SerializeField]
		private float spreadAngle;

		[SerializeField]
		private float upwardBias;

		[Header("Efficiency Settings")]
		[SerializeField]
		private int maxTotalSparks;

		[SerializeField]
		private int minSparksPerLayer;

		[SerializeField]
		private int maxSparksPerLayer;

		[Header("Frame Budget")]
		[SerializeField]
		private int maxSparksPerFrame;

		private List<SparkRequest> _sparkRequests;

		public static SparkParticleSystem Instance => null;

		private void Awake()
		{
		}

		private void LateUpdate()
		{
		}

		private void ProcessBatchedSparks()
		{
		}

		public void SpawnSparksForLayers(Vector3 position, List<RockLayerHitResult> layerResults)
		{
		}

		public void SpawnSparks(Vector3 position, RockLayerType layerType, int count = -1)
		{
		}

		private void SpawnSparksImmediate(Vector3 position, RockLayerType layerType, int count)
		{
		}
	}
}
