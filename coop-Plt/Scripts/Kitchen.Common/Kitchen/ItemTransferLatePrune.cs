using Unity.Entities;

namespace Kitchen
{
	[UpdateAfter(typeof(ItemTransferAccept))]
	[UpdateInGroup(typeof(ItemTransferGroup))]
	public class ItemTransferLatePrune : ComponentSystemGroup
	{
		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
