using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(SimulationSystemGroup), OrderLast = true)]
	[UpdateAfter(typeof(ViewSystemsGroup))]
	public class PostViewSystemsBarrier : GroupedEntityCommandBufferSystem
	{
		public override ECB ECB => ECB.ViewSystems;

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
