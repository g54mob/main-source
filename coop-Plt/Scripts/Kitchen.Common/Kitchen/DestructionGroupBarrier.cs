using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(DestructionGroup), OrderLast = true)]
	public class DestructionGroupBarrier : GroupedEntityCommandBufferSystem
	{
		public override ECB ECB => ECB.DestructionGroup;

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
