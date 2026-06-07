namespace Simulator.GameWorld
{
	public class ReserveExtensionModifier : ExtensionModifier
	{
		protected virtual void Awake()
		{
			ShopExtensionSystem.ReserveExtensionBought += OnExtensionBought;
		}

		protected virtual void OnDestroy()
		{
			ShopExtensionSystem.ReserveExtensionBought -= OnExtensionBought;
		}

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
