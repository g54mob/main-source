using Unity.Entities;

namespace Kitchen
{
	[UpdateAfter(typeof(ItemTransferEarlyPrune))]
	[UpdateInGroup(typeof(ItemTransferGroup))]
	public class ItemTransferAccept : ComponentSystemGroup
	{
		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
