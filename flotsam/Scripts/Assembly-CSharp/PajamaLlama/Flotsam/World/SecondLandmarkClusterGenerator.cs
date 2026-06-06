using System.Collections.Generic;
using UnityEngine;

namespace PajamaLlama.Flotsam.World
{
	[CreateAssetMenu(fileName = "Second Landmark Cluster Generator", menuName = "Flotsam/Procedural Generation/Landmarks/Second Cluster Generator")]
	public class SecondLandmarkClusterGenerator : LandmarkClusterGeneratorBase
	{
		[SerializeField]
		private float _density = 100f;

		[SerializeField]
		private LandmarkBehaviourCollection _scoutLandmarkBehaviourCollection;

		[SerializeField]
		private WeightedList<WeightedList<LandmarkBehaviourCollection>> _distributer;

		[SerializeField]
		private int _clusterMinimumCount;

		[SerializeField]
		private int _clusterMaximumCount;

		[SerializeField]
		private float _clusterSpawnRadius;

		private LandmarkGeneratorBase _landmarkGenrator;

		private List<LandmarkBehaviourCollection> _distributionList = new List<LandmarkBehaviourCollection>();

		public override void Run<T>(IRegion region, List<T> clusters)
		{
			float num = region.ReturnSurface();
			int num2 = Mathf.RoundToInt(num / _density);
			using ListPool<T>.List list = ListPool<T>.Get(clusters);
			Debug.Log($"Spawning {num2} landmarks, in a region with a surface of {num}m2.");
			base.GeneratedLandmarks.Clear();
			if (!TryAddLandmark(clusters[0], _scoutLandmarkBehaviourCollection))
			{
				Debug.LogError("Unable to add scout landmark");
			}
			for (int i = 0; i < _clusterMinimumCount; i++)
			{
				foreach (T item in list)
				{
					ILandmarkCluster landmarkCluster = item;
					num2--;
					if (landmarkCluster.Count != i)
					{
						DistributeLandmark(landmarkCluster);
					}
				}
			}
			while (0 < num2-- && 0 < list.Count)
			{
				int index = Random.Range(0, list.Count);
				ILandmarkCluster landmarkCluster2 = list[index];
				if (!DistributeLandmark(landmarkCluster2) || landmarkCluster2.Count >= _clusterMaximumCount)
				{
					list.RemoveAt(index);
				}
			}
		}

		private bool DistributeLandmark(ILandmarkCluster cluster)
		{
			if (TryAddLandmark(cluster, _distributer.ReturnRandom().ReturnRandom()))
			{
				return true;
			}
			return false;
		}

		private bool TryAddLandmark(ILandmarkCluster cluster, ILandmarkBehaviourProvider landmarkBehaviourProvider)
		{
			if (TryGetValidPosition(out var position, cluster, landmarkBehaviourProvider))
			{
				AddLandmark(landmarkBehaviourProvider, position);
				return true;
			}
			return false;
		}

		public bool TryGetValidPosition(out Vector2 position, ILandmarkCluster cluster, ILandmarkBehaviourProvider landmarkBehaviourProvider, int maxItterations = 25)
		{
			for (int i = 0; i < maxItterations; i++)
			{
				position = GetRandomSpawnPosition(cluster.Position, landmarkBehaviourProvider);
				if (IsValidPosition(landmarkBehaviourProvider, position))
				{
					return true;
				}
			}
			position = default(Vector2);
			return false;
		}

		public Vector2 GetRandomSpawnPosition(Vector2 position, ILandmarkBehaviourProvider landmarkBehaviourProvider)
		{
			return position + Random.insideUnitCircle * (_clusterSpawnRadius - landmarkBehaviourProvider.Radius);
		}
	}
}
