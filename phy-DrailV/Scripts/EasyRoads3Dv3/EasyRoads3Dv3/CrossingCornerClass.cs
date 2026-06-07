using System;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class CrossingCornerClass
	{
		public string presetName = "";

		public double id;

		public double timestamp;

		public float cornerRadius = 1f;

		public int cornerSegments = 5;

		public float innerSegmentDistance = 0.5f;

		public CrossingCornerClass(QDOQDSQOOQDDD sw, string name)
		{
			presetName = name;
			cornerRadius = sw.cornerRadius;
			cornerSegments = sw.cornerSegments;
			innerSegmentDistance = sw.innerSegmentDistance;
		}
	}
}
