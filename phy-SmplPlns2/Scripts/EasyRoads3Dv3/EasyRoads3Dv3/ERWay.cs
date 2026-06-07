using System.Collections.Generic;

namespace EasyRoads3Dv3
{
	public struct ERWay
	{
		public int id;

		public List<long> nodes;

		public string t1;

		public string t2;

		public string name;

		public bool oneWay;

		public bool bridge;

		public int lanes;

		public string surface;

		public string speed;

		public ERWay(int mid)
		{
			id = mid;
			nodes = new List<long>();
			t1 = "";
			t2 = "";
			name = "";
			oneWay = false;
			bridge = false;
			lanes = 0;
			surface = "";
			speed = "";
		}
	}
}
