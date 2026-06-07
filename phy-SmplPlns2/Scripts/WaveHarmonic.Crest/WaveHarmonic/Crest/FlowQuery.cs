using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest
{
	internal sealed class FlowQuery : QueryBaseSimple, IFlowProvider, IQueryProvider
	{
		protected override int Kernel => 1;

		public FlowQuery()
			: base(ManagerBehaviour<WaterRenderer>.Instance.FlowLod)
		{
		}

		public FlowQuery(WaterRenderer water)
			: base(water.FlowLod)
		{
		}
	}
}
