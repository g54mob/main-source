namespace Simulator.GameWorld
{
	public class IndoorShopExtensionModifier : ShopExtensionModifier
	{
		protected override bool Activate(int level)
		{
			bool flag = base.Activate(level);
			if (flag && base.Level > level + 2)
			{
				flag = false;
			}
			return flag;
		}
	}
}
