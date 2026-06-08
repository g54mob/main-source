using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(SimulationSystemGroup), OrderLast = true)]
	[UpdateAfter(typeof(EndSimulationEntityCommandBufferSystem))]
	public class EndOfFrameGroup : ComponentSystemGroup
	{
		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
