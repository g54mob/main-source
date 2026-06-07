using UnityEngine;

namespace WaveHarmonic.Crest
{
	internal interface IReportsHeight
	{
		bool ReportHeight(WaterRenderer water, ref Rect bounds, ref float minimum, ref float maximum);
	}
}
