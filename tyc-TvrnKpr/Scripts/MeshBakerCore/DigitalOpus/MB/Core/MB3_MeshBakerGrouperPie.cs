using System.Collections.Generic;
using UnityEngine;

namespace DigitalOpus.MB.Core
{
	public class MB3_MeshBakerGrouperPie : MB3_MeshBakerGrouperBehaviour
	{
		public override Dictionary<string, List<Renderer>> FilterIntoGroups(List<GameObject> selection, GrouperData d)
		{
			return null;
		}

		public override void DrawGizmos(Bounds sourceObjectBounds, GrouperData d)
		{
		}

		private static int MaxIndexInVector3(Vector3 v)
		{
			return 0;
		}

		public static void DrawCircle(Vector3 axis, Vector3 center, float radius, int subdiv)
		{
		}

		public override MB3_MeshBakerGrouper.ClusterType GetClusterType()
		{
			return default(MB3_MeshBakerGrouper.ClusterType);
		}
	}
}
