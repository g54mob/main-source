using System.Collections.Generic;
using UnityEngine;

namespace PajamaLlama.Flotsam.World
{
	[CreateAssetMenu(fileName = "First Landmark Cluster Generator", menuName = "Flotsam/Procedural Generation/Landmarks/First Cluster Generator")]
	public class FirstLandmarkClusterGenerator : LandmarkClusterGeneratorBase
	{
		[SerializeField]
		private ClusterLandmarkProvider _scoutCluster;

		[SerializeField]
		private WeightedList<ClusterLandmarkProvider> _otherClusters;

		private LandmarkGeneratorBase _landmarkGenerator;

		public override void Run<T>(IRegion region, List<T> clusters)
		{
			base.GeneratedLandmarks.Clear();
			GenerateClusterLandmarks(clusters[0], _scoutCluster);
			for (int i = 1; i < clusters.Count; i++)
			{
				GenerateClusterLandmarks(clusters[i], _otherClusters.ReturnRandom());
			}
		}

		private void GenerateClusterLandmarks(ILandmarkCluster cluster, ClusterLandmarkProvider clusterLandmarkProvider)
		{
			IEnumerator<ILandmarkBehaviourProvider> enumerator = clusterLandmarkProvider.GetEnumerator();
			Vector2 position;
			while (enumerator.MoveNext() && TryReturnLandmarkPosition(out position, cluster.Position, clusterLandmarkProvider, enumerator.Current))
			{
				AddLandmark(enumerator.Current, position);
			}
		}

		private bool TryReturnLandmarkPosition(out Vector2 position, Vector2 clusterPosition, ClusterLandmarkProvider landmarkProvider, ILandmarkBehaviourProvider landmarkBehaviourProvider, int maxItterations = 100)
		{
			for (int i = 0; i < maxItterations; i++)
			{
				position = landmarkProvider.GetRandomSpawnPosition(clusterPosition, landmarkBehaviourProvider);
				if (IsValidPosition(landmarkBehaviourProvider, position))
				{
					return true;
				}
			}
			position = default(Vector2);
			return false;
		}
	}
}
