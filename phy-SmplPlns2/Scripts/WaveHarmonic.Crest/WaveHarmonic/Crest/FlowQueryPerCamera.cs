namespace WaveHarmonic.Crest
{
	internal sealed class FlowQueryPerCamera : QueryPerCameraSimple<FlowQuery>, IFlowProvider, IQueryProvider
	{
		public FlowQueryPerCamera(WaterRenderer water)
			: base(water)
		{
		}
	}
}
