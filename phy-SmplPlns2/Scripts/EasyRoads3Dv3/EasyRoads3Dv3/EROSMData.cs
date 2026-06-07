using UnityEngine;

namespace EasyRoads3Dv3
{
	public struct EROSMData
	{
		public Bounds bounds;

		public double latitudeTop;

		public double latitudeBottom;

		public double longitudeLeft;

		public double longitudeRight;

		public int Motorway;

		public int MotorwayLink;

		public int Trunk;

		public int Primary;

		public int Secondary;

		public int Tertiary;

		public int Unclassified;

		public int Residential;

		public int Service;

		public int Track;

		public int Path;

		public int Walkway;

		public int Raceway;

		public int total;

		public EROSMData(float width, float length)
		{
			bounds = default(Bounds);
			bounds.size = new Vector3(width, 0f, length);
			Motorway = 0;
			MotorwayLink = 0;
			Trunk = 0;
			Primary = 0;
			Secondary = 0;
			Tertiary = 0;
			Unclassified = 0;
			Residential = 0;
			Service = 0;
			Track = 0;
			Path = 0;
			Walkway = 0;
			Raceway = 0;
			total = 0;
			latitudeTop = 0.0;
			latitudeBottom = 0.0;
			longitudeLeft = 0.0;
			longitudeRight = 0.0;
		}
	}
}
