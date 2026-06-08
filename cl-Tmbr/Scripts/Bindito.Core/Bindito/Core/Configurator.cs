using JetBrains.Annotations;

namespace Bindito.Core
{
	[UsedImplicitly]
	public abstract class Configurator : IConfigurator
	{
		private IContainerDefinition _containerDefinition;

		public void Configure(IContainerDefinition containerDefinition)
		{
			_containerDefinition = containerDefinition;
			Configure();
			_containerDefinition = null;
		}

		protected abstract void Configure();

		[UsedImplicitly]
		protected ISingleBindingBuilder<T> Bind<[MeansImplicitUse(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)] T>() where T : class
		{
			return _containerDefinition.Bind<T>();
		}

		[UsedImplicitly]
		protected IMultiBindingBuilder<T> MultiBind<[MeansImplicitUse(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)] T>() where T : class
		{
			return _containerDefinition.MultiBind<T>();
		}

		[UsedImplicitly]
		protected void AddProvisionListener(IProvisionListener provisionListener)
		{
			_containerDefinition.AddProvisionListener(provisionListener);
		}

		[UsedImplicitly]
		protected void AddInjectionListener(IInjectionListener injectionListener)
		{
			_containerDefinition.AddInjectionListener(injectionListener);
		}

		[UsedImplicitly]
		protected void Install(IConfigurator configurator)
		{
			_containerDefinition.Install(configurator);
		}

		[UsedImplicitly]
		protected void InstallAll(string contextName)
		{
			_containerDefinition.InstallAll(contextName);
		}
	}
}
