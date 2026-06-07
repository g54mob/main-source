using System;
using System.Collections.Generic;

namespace Gh.Tk
{
	[Serializable]
	public class Route
	{
		public List<RouteStop> stops;

		public List<Road> roads;

		public RouteStop StopA => null;

		public RouteStop StopB => null;

		public virtual float GetTotalDistance()
		{
			return 0f;
		}

		public virtual float GetTotalEffort()
		{
			return 0f;
		}

		public virtual void SetMarkerLocation(RouteMarker marker, float totalProgressPercent)
		{
		}
	}
}
