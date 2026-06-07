using UnityEngine;

namespace Gh.Tk
{
	public class LightAdjustTimeOfDayAndWorldmapZoomLevel : WorldmapTimeOfDayAndZoomLevelAdjustmentBase
	{
		[SerializeField]
		protected Light _light;

		private float _maxIntensity;

		private bool _lightIsEnabled;

		protected override void OnStart()
		{
		}

		protected override void Recalculate()
		{
		}
	}
}
