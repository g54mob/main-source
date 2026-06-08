using Unity.Entities;

namespace Kitchen.ShopBuilder
{
	[UpdateInGroup(typeof(EndOfDayProgressionGroup), OrderFirst = true)]
	public class ShopOptionGroup : ComponentSystemGroup
	{
		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
