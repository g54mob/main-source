using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(UpdateCustomerStatesGroup), OrderLast = true)]
	public class CustomerStateChangesBarrier : GroupedEntityCommandBufferSystem
	{
		public override ECB ECB => ECB.StateChanges;

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
