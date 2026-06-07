using System;

namespace Gh.Tk
{
	[Serializable]
	public class DragonRoute : Route
	{
		private static float FlightHeight;

		private const float DragonEffortMultiplier = 0.2f;

		public override float GetTotalDistance()
		{
			return 0f;
		}

		public override float GetTotalEffort()
		{
			return 0f;
		}

		public override void SetMarkerLocation(RouteMarker marker, float totalProgressPercent)
		{
		}
	}
}
