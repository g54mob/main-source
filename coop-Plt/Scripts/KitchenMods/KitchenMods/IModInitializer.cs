namespace KitchenMods
{
	public interface IModInitializer
	{
		void PostActivate(Mod mod);

		void PreInject();

		void PostInject();
	}
}
