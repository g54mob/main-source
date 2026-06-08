using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(ItemTransferGroup))]
	public class ItemTransferSetup : ComponentSystemGroup
	{
		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
