using System;
using System.Collections.Generic;

namespace UMA
{
	[Serializable]
	public abstract class VertexAdjustmentCollection
	{
		public List<VertexAdjustment> vertexAdjustments;

		public virtual bool SupportWeightedAdjustments => false;

		public abstract void Apply(MeshDetails mesh, MeshDetails src);

		public abstract void ApplyScaled(MeshDetails mesh, MeshDetails src, float scale);

		public void Add(VertexAdjustment adjustment)
		{
		}

		public int Count()
		{
			return 0;
		}
	}
}
