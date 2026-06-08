using Unity.Entities;

namespace Kitchen
{
	[UpdateAfter(typeof(EndOfFrameGroup))]
	[UpdateInGroup(typeof(SimulationSystemGroup), OrderLast = true)]
	public class ViewSystemsGroup : ComponentSystemGroup
	{
		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
