using System;

namespace UMA
{
	[Serializable]
	public class VertexScaleAdjustmentCollection : VertexAdjustmentCollection
	{
		public override bool SupportWeightedAdjustments => false;

		public override void Apply(MeshDetails mesh, MeshDetails src)
		{
		}

		public override void ApplyScaled(MeshDetails mesh, MeshDetails src, float scale)
		{
		}
	}
}
