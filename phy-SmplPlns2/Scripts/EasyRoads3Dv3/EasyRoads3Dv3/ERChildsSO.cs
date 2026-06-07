using System;

namespace EasyRoads3Dv3
{
	[Serializable]
	public struct ERChildsSO
	{
		public double id;

		public float startOffset;

		public float endOffset;

		public float xOffset;

		public float yOffset;

		public ERChildsSO(int _id)
		{
			id = _id;
			startOffset = 0f;
			endOffset = 0f;
			xOffset = 0f;
			yOffset = 0f;
		}
	}
}
