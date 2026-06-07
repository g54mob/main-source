using System;

namespace MagicaCloth2
{
	[Serializable]
	public class ClothDebugSettings
	{
		public enum DebugAxis
		{
			None = 0,
			Normal = 1,
			All = 2
		}

		public bool enable;

		public bool ztest;

		public bool position;

		public DebugAxis axis;

		public bool shape;

		public bool baseLine;

		public bool depth;

		public bool collider;

		public bool animatedPosition;

		public DebugAxis animatedAxis;

		public bool animatedShape;

		public bool inertiaCenter;

		public bool customSkinningBone;

		public bool CheckParticleDrawing(int index)
		{
			return false;
		}

		public bool CheckTriangleDrawing(int index)
		{
			return false;
		}

		public bool CheckRadiusDrawing()
		{
			return false;
		}

		public float GetPointSize()
		{
			return 0f;
		}

		public float GetLineSize()
		{
			return 0f;
		}

		public float GetInertiaCenterRadius()
		{
			return 0f;
		}

		public float GetCustomSkinningRadius()
		{
			return 0f;
		}

		public bool IsReferOldPos()
		{
			return false;
		}
	}
}
