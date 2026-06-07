namespace EasyRoads3Dv3
{
	public struct ERNode
	{
		public long id;

		public double lat;

		public double lon;

		public float height;

		public ERNode(long mid, double mlat, double mlon, float mheight)
		{
			id = mid;
			lat = mlat;
			lon = mlon;
			height = mheight;
		}
	}
}
