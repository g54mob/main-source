using System;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class ERSORoadLog
	{
		public double id = 0.0;

		public bool active = false;

		public ERSORoadLog(double so)
		{
			id = so;
		}
	}
}
