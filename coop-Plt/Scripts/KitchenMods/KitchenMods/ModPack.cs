namespace KitchenMods
{
	public abstract class ModPack
	{
		public string Name;

		protected byte[] Data;

		public Mod Mod;

		public ModPack(string name, byte[] data)
		{
			Name = name;
			Data = data;
		}

		public abstract void Activate();

		public virtual void PostActivate()
		{
		}

		public abstract void Inject(ModInjectionContext injection_context);
	}
}
