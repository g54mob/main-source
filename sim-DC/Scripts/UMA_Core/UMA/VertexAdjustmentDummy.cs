using System;

namespace UMA
{
	[Serializable]
	public class VertexAdjustmentDummy : VertexAdjustment
	{
		public override string Name => null;

		public override VertexAdjustmentCollection VertexAdjustmentCollection => null;

		public override void Apply(MeshDetails mesh, MeshDetails src)
		{
		}

		public override void ApplyScaled(MeshDetails mesh, MeshDetails src, float scale)
		{
		}

		public override VertexAdjustment ShallowCopy()
		{
			return null;
		}
	}
}
