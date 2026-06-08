using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(InteractionGroup), OrderFirst = true)]
	[UpdateAfter(typeof(AttemptInteraction))]
	public class PausedInteractionGroup : ComponentSystemGroup
	{
		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
