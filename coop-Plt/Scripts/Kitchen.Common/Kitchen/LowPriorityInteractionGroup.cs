using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(InteractionGroup), OrderLast = true)]
	[UpdateBefore(typeof(PostInteractionBarrier))]
	public class LowPriorityInteractionGroup : ComponentSystemGroup
	{
		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
