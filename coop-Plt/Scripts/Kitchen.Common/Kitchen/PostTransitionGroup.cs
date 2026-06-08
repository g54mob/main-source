using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(GameTransitionsCreateGroup), OrderLast = true)]
	public class PostTransitionGroup : ComponentSystemGroup
	{
		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
