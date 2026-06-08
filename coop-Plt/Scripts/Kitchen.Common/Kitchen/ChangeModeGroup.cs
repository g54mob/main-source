using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(GameTransitionsCreateGroup), OrderFirst = true)]
	public class ChangeModeGroup : ComponentSystemGroup
	{
		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
