using Unity.Entities;

namespace Kitchen
{
	[UpdateAfter(typeof(ItemTransferLatePrune))]
	[UpdateInGroup(typeof(ItemTransferGroup))]
	public class ItemTransferResolve : ComponentSystemGroup
	{
		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
