using System.Collections.Generic;
using UnityEngine;

namespace DigitalOpus.MB.Core
{
	public class MB3_MeshBakerGrouperGrid : MB3_MeshBakerGrouperBehaviour
	{
		public override Dictionary<string, List<Renderer>> FilterIntoGroups(List<GameObject> selection, GrouperData d)
		{
			return null;
		}

		public override void DrawGizmos(Bounds sourceObjectBounds, GrouperData d)
		{
		}

		public override MB3_MeshBakerGrouper.ClusterType GetClusterType()
		{
			return default(MB3_MeshBakerGrouper.ClusterType);
		}
	}
}
