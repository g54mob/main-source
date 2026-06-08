namespace Rhizomatic
{
	public abstract class Thing<TConfig> : Thing where TConfig : Config
	{
		public new TConfig config => null;
	}
	public abstract class Thing : IWithContext, IWithContextDispose
	{
		public Config config;

		public Context context { get; set; }

		public virtual void OnContext()
		{
		}

		public virtual void OnContextDispose()
		{
		}

		public void DisposeOne()
		{
		}

		protected T CreateThing<T>(Config config, Context context = null) where T : Thing
		{
			return null;
		}

		protected Thing CreateThing<T>(T config, Context context = null) where T : Config, IThingCreator
		{
			return null;
		}
	}
}
