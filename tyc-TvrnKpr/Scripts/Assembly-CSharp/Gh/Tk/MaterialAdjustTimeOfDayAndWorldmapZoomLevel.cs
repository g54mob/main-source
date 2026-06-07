using UnityEngine;

namespace Gh.Tk
{
	public class MaterialAdjustTimeOfDayAndWorldmapZoomLevel : WorldmapTimeOfDayAndZoomLevelAdjustmentBase
	{
		[SerializeField]
		protected Material _material;

		public bool adjustAlpha;

		public bool adjustEmissionColor;

		public Gradient emissionDayTimeCurve;

		public Gradient emissionZoomLevelCurve;

		private static readonly int EmissionColor;

		public bool adjustColor;

		public Gradient colorDayTimeCurve;

		protected override void OnStart()
		{
		}

		protected override void Recalculate()
		{
		}
	}
}
