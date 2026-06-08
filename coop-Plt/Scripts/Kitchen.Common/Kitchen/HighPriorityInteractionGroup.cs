using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(InteractionGroup), OrderFirst = true)]
	[UpdateAfter(typeof(PausedInteractionGroup))]
	public class HighPriorityInteractionGroup : ComponentSystemGroup
	{
		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
