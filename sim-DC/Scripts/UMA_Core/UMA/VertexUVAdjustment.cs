using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class VertexUVAdjustment : VertexAdjustment
	{
		public Vector2 uv;

		public override string Name => null;

		public override VertexAdjustmentCollection VertexAdjustmentCollection => null;

		public override void Apply(MeshDetails mesh, MeshDetails src)
		{
		}

		public override void ApplyScaled(MeshDetails mesh, MeshDetails src, float scale)
		{
		}

		public static void Apply(MeshDetails mesh, MeshDetails src, List<VertexAdjustment> adjustments)
		{
		}

		public static void ApplyScaled(MeshDetails mesh, MeshDetails src, List<VertexAdjustment> adjustments, float scale)
		{
		}

		public override VertexAdjustment ShallowCopy()
		{
			return null;
		}
	}
}
