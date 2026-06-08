using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(EndOfFrameGroup))]
	[UpdateAfter(typeof(DestructionGroup))]
	public class GameTransitionsCreateGroup : ComponentSystemGroup
	{
		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
