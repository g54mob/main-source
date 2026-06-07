using System;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class ERBlendVecs
	{
		public int verticeIndex;

		public int meshIndex;

		public float blendWeight;

		public int connection;

		public int blendType;

		public ERBlendVecs(int index, int mIndex, float weight, int conn, int type)
		{
			verticeIndex = index;
			meshIndex = mIndex;
			blendWeight = weight;
			connection = conn;
			blendType = type;
		}
	}
}
