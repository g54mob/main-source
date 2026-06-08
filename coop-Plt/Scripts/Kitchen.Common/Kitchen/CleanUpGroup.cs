using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(EndOfFrameGroup), OrderLast = true)]
	public class CleanUpGroup : ComponentSystemGroup
	{
		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
