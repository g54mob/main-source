using System.Collections.Generic;
using UnityEngine;

namespace Synty.SidekickCharacters.SkinnedMesh
{
	public class BlendShapeData
	{
		public string blendShapeFrameName;

		public int blendShapeFrameIndex;

		public float blendShapeCurrentValue;

		public List<Vector3> startDeltaVertices;

		public List<Vector3> startDeltaNormals;

		public List<Vector3> startDeltaTangents;

		public List<Vector3> finalDeltaVertices;

		public List<Vector3> finalDeltaNormals;

		public List<Vector3> finalDeltaTangents;

		public string blendShapeNameOnCombinedMesh;

		protected bool Equals(BlendShapeData other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
