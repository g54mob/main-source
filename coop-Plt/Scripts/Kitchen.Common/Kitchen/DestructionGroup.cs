using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(EndOfFrameGroup), OrderFirst = true)]
	public class DestructionGroup : ComponentSystemGroup
	{
		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
