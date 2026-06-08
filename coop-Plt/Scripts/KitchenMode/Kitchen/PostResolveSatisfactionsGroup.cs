using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(ItemTransferPostResolve), OrderFirst = true)]
	public class PostResolveSatisfactionsGroup : ComponentSystemGroup
	{
		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
