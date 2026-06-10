using System;

namespace UnityMeshSimplifier
{
	[Serializable]
	public struct BlendShape
	{
		public string ShapeName;

		public BlendShapeFrame[] Frames;

		public BlendShape(string shapeName, BlendShapeFrame[] frames)
		{
			ShapeName = null;
			Frames = null;
		}
	}
}
