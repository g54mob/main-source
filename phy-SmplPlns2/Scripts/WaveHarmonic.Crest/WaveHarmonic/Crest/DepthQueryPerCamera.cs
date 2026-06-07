namespace WaveHarmonic.Crest
{
	internal sealed class DepthQueryPerCamera : QueryPerCameraSimple<DepthQuery>, IDepthProvider, IQueryProvider
	{
		public DepthQueryPerCamera(WaterRenderer water)
			: base(water)
		{
		}
	}
}
