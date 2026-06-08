using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(DestructionGroup), OrderFirst = true)]
	public class GameTransitionsCleanupGroup : ComponentSystemGroup
	{
		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
