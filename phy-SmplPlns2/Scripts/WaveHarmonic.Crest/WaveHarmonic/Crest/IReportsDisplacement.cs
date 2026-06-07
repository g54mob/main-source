using UnityEngine;

namespace WaveHarmonic.Crest
{
	internal interface IReportsDisplacement
	{
		bool ReportDisplacement(WaterRenderer water, ref Rect bounds, ref float horizontal, ref float vertical);
	}
}
