using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(CreationGroup), OrderLast = true)]
	public class PostCreationBarrier : GroupedEntityCommandBufferSystem
	{
		public override ECB ECB => ECB.PostCreation;

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
