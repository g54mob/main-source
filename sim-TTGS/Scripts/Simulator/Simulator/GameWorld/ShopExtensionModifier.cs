namespace Simulator.GameWorld
{
	public class ShopExtensionModifier : ExtensionModifier
	{
		protected virtual void Awake()
		{
			ShopExtensionSystem.ShopExtensionBought += OnExtensionBought;
		}

		protected virtual void OnDestroy()
		{
			ShopExtensionSystem.ShopExtensionBought -= OnExtensionBought;
		}
	}
}
