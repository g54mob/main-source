using Unity.Entities;

namespace Kitchen
{
	[UpdateAfter(typeof(ItemTransferSetup))]
	[UpdateInGroup(typeof(ItemTransferGroup))]
	public class ItemTransferPropose : ComponentSystemGroup
	{
		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
