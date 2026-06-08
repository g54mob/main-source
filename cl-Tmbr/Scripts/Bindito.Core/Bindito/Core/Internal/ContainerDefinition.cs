using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bindito.Core.Internal
{
	public class ContainerDefinition : IContainerDefinition
	{
		private readonly IBindingBuilderRegistry _bindingBuilderRegistry;

		private readonly IProvisionListenerNotifier _provisionListenerNotifier;

		private readonly IInjectionListenerNotifier _injectionListenerNotifier;

		public ContainerDefinition(IBindingBuilderRegistry bindingBuilderRegistry, IProvisionListenerNotifier provisionListenerNotifier, IInjectionListenerNotifier injectionListenerNotifier)
		{
			_bindingBuilderRegistry = bindingBuilderRegistry;
			_provisionListenerNotifier = provisionListenerNotifier;
			_injectionListenerNotifier = injectionListenerNotifier;
		}

		public ISingleBindingBuilder<T> Bind<T>() where T : class
		{
			BindingBuilder<T> bindingBuilder = new BindingBuilder<T>();
			_bindingBuilderRegistry.RegisterBindingBuilder(bindingBuilder);
			return bindingBuilder;
		}

		public IMultiBindingBuilder<T> MultiBind<T>() where T : class
		{
			BindingBuilder<T> bindingBuilder = new BindingBuilder<T>();
			_bindingBuilderRegistry.RegisterMultiBindingBuilder(bindingBuilder);
			return bindingBuilder;
		}

		public void AddProvisionListener(IProvisionListener provisionListener)
		{
			_provisionListenerNotifier.AddListener(provisionListener);
		}

		public void AddInjectionListener(IInjectionListener injectionListener)
		{
			_injectionListenerNotifier.AddListener(injectionListener);
		}

		public void Install(IConfigurator configurator)
		{
			configurator.Configure(this);
		}

		public void InstallAll(string contextName)
		{
			foreach (Type item in FindConfigurators())
			{
				if (HasContext(item, contextName))
				{
					Install((IConfigurator)Activator.CreateInstance(item));
				}
			}
		}

		private static IEnumerable<Type> FindConfigurators()
		{
			Type configuratorType = typeof(IConfigurator);
			return from type in AppDomain.CurrentDomain.GetAssemblies().SelectMany((Assembly assembly) => assembly.GetTypes())
				where !type.IsAbstract && configuratorType.IsAssignableFrom(type)
				select type;
		}

		private static bool HasContext(Type type, string contextName)
		{
			return type.GetCustomAttributes<ContextAttribute>().Any((ContextAttribute attribute) => attribute.ContextName == contextName);
		}
	}
}
