using Unity.Entities;

namespace Kitchen
{
	[UpdateAfter(typeof(ItemTransferResolve))]
	[UpdateInGroup(typeof(ItemTransferGroup))]
	public class ItemTransferPostResolve : ComponentSystemGroup
	{
		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
