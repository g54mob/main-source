using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(InteractionGroup))]
	public class ItemTransferGroup : ComponentSystemGroup
	{
		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
