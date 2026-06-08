using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(InteractionGroup), OrderLast = true)]
	public class PostInteractionBarrier : GroupedEntityCommandBufferSystem
	{
		public override ECB ECB => ECB.PostInteraction;

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
