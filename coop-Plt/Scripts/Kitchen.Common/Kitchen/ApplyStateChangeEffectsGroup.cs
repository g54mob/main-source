using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(UpdateCustomerStatesGroup), OrderLast = true)]
	[UpdateAfter(typeof(CustomerStateChangesBarrier))]
	public class ApplyStateChangeEffectsGroup : ComponentSystemGroup
	{
		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
