using System.Collections.Generic;
using UnityEngine;

namespace DigitalOpus.MB.Core
{
	public abstract class MB3_MeshBakerGrouperBehaviour
	{
		public abstract Dictionary<string, List<Renderer>> FilterIntoGroups(List<GameObject> selection, GrouperData d);

		public abstract void DrawGizmos(Bounds sourceObjectBounds, GrouperData d);

		public List<MB3_MeshBakerCommon> DoClustering(MB3_TextureBaker tb, MB3_MeshBakerGrouper grouper, GrouperData d)
		{
			return null;
		}

		private Dictionary<int, List<Renderer>> GroupByLightmapIndex(List<Renderer> gaws)
		{
			return null;
		}

		private MB3_MeshBakerCommon AddMeshBaker(MB3_MeshBakerGrouper grouper, MB3_TextureBaker tb, string key, List<Renderer> gaws)
		{
			return null;
		}

		public virtual MB3_MeshBakerGrouper.ClusterType GetClusterType()
		{
			return default(MB3_MeshBakerGrouper.ClusterType);
		}
	}
}
