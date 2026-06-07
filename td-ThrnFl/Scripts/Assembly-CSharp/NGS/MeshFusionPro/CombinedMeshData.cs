using System.Collections.Generic;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	public abstract class CombinedMeshData
	{
		public abstract int PartsCount { get; }

		public abstract int VertexCount { get; }

		public abstract Bounds GetBounds();

		public abstract Bounds GetBounds(CombinedMeshPart part);

		public abstract IEnumerable<CombinedMeshPart> GetParts();
	}
}
