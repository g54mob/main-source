using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(UpdateCustomerStatesGroup))]
	public class CustomerAssignmentGroup : ComponentSystemGroup
	{
		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
