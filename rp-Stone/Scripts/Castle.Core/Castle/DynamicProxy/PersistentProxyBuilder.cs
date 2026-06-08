namespace Castle.DynamicProxy
{
	public class PersistentProxyBuilder : DefaultProxyBuilder
	{
		public PersistentProxyBuilder()
			: base(new ModuleScope(savePhysicalAssembly: true))
		{
		}

		public string SaveAssembly()
		{
			return base.ModuleScope.SaveAssembly();
		}
	}
}
