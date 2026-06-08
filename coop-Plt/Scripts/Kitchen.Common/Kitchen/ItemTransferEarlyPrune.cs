using Unity.Entities;

namespace Kitchen
{
	[UpdateAfter(typeof(ItemTransferPropose))]
	[UpdateInGroup(typeof(ItemTransferGroup))]
	public class ItemTransferEarlyPrune : ComponentSystemGroup
	{
		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
