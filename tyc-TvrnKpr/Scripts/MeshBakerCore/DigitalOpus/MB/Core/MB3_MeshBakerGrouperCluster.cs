using System.Collections.Generic;
using UnityEngine;

namespace DigitalOpus.MB.Core
{
	public class MB3_MeshBakerGrouperCluster : MB3_MeshBakerGrouperBehaviour
	{
		public override Dictionary<string, List<Renderer>> FilterIntoGroups(List<GameObject> selection, GrouperData d)
		{
			return null;
		}

		public void BuildClusters(List<GameObject> gos, ProgressUpdateCancelableDelegate progFunc, GrouperData d)
		{
		}

		public void _BuildListOfClustersToDraw(ProgressUpdateCancelableDelegate progFunc, out float smallest, out float largest, GrouperData d)
		{
			smallest = default(float);
			largest = default(float);
		}

		public override void DrawGizmos(Bounds sceneObjectBounds, GrouperData d)
		{
		}

		public override MB3_MeshBakerGrouper.ClusterType GetClusterType()
		{
			return default(MB3_MeshBakerGrouper.ClusterType);
		}
	}
}
