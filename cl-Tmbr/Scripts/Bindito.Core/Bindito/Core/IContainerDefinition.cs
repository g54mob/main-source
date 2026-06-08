using JetBrains.Annotations;

namespace Bindito.Core
{
	public interface IContainerDefinition
	{
		ISingleBindingBuilder<T> Bind<[MeansImplicitUse(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)] T>() where T : class;

		IMultiBindingBuilder<T> MultiBind<[MeansImplicitUse(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)] T>() where T : class;

		void AddProvisionListener(IProvisionListener provisionListener);

		void AddInjectionListener(IInjectionListener injectionListener);

		void Install(IConfigurator configurator);

		void InstallAll(string contextName);
	}
}
