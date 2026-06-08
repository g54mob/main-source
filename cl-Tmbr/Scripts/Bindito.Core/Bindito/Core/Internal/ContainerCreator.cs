using System;
using System.Collections.Generic;

namespace Bindito.Core.Internal
{
	public class ContainerCreator : IContainerCreator
	{
		private readonly IInstanceProviderBank _parentInstanceProviderBank;

		private readonly IBinder _parentBinder;

		private IInstanceProviderBank _ownInstanceProviderBank;

		private IBinder _ownBinder;

		private bool _created;

		public ContainerCreator()
			: this(null, null)
		{
		}

		private ContainerCreator(IInstanceProviderBank parentInstanceProviderBank, IBinder parentBinder)
		{
			_parentInstanceProviderBank = parentInstanceProviderBank;
			_parentBinder = parentBinder;
		}

		public IContainer CreateContainer(IEnumerable<IConfigurator> configurators)
		{
			if (_created)
			{
				throw new InvalidOperationException("One ContainerCreator can only be used to create one container.");
			}
			Binder binder = new Binder(_parentBinder);
			ProvisionListenerNotifier provisionListenerNotifier = new ProvisionListenerNotifier();
			InjectionListenerNotifier injectionListenerNotifier = new InjectionListenerNotifier();
			ConstructorRetriever constructorRetriever = new ConstructorRetriever();
			MethodRetriever methodRetriever = new MethodRetriever();
			DependencyRetriever dependencyRetriever = new DependencyRetriever(constructorRetriever, methodRetriever);
			MultiBindingService multiBindingService = new MultiBindingService();
			BindingResolver bindingResolver = new BindingResolver(multiBindingService, binder, _parentBinder);
			BindingValidator bindingValidator = new BindingValidator(new BindingAnalyser(dependencyRetriever, bindingResolver));
			InstanceProviderBank instanceProviderBank = new InstanceProviderBank(binder, _parentInstanceProviderBank);
			InstanceBank instanceBank = new InstanceBank(instanceProviderBank);
			ParameterProvider parameterProvider = new ParameterProvider(instanceBank, multiBindingService);
			MethodInjector methodInjector = new MethodInjector(parameterProvider, methodRetriever, injectionListenerNotifier);
			InstanceCreator instanceCreator = new InstanceCreator(parameterProvider, constructorRetriever);
			ValidatingMethodInjector validatingMethodInjector = new ValidatingMethodInjector(methodInjector, bindingValidator);
			InstanceProviderFuncFactory instanceProviderFuncFactory = new InstanceProviderFuncFactory(instanceCreator, methodInjector, provisionListenerNotifier, validatingMethodInjector, instanceBank);
			Scoper scoper = new Scoper();
			InstanceProviderFactory instanceProviderFactory = new InstanceProviderFactory(instanceProviderFuncFactory, scoper);
			instanceProviderBank.InstanceProviderFactory = instanceProviderFactory;
			BoundInstanceService boundInstanceService = new BoundInstanceService(binder);
			Container container = new Container(instanceBank, validatingMethodInjector, boundInstanceService, this);
			ConfigureContainer(container, configurators, binder, provisionListenerNotifier, injectionListenerNotifier);
			ValidateConfiguration(bindingValidator, binder);
			InitializeInstanceProviders(instanceProviderBank, binder);
			PostCreate(instanceProviderBank, binder);
			return container;
		}

		public IContainer CreateChildContainer(IEnumerable<IConfigurator> configurators)
		{
			if (!_created)
			{
				throw new InvalidOperationException("Can't create a child container before parent.");
			}
			return new ContainerCreator(_ownInstanceProviderBank, _ownBinder).CreateContainer(configurators);
		}

		private static void ConfigureContainer(IContainer container, IEnumerable<IConfigurator> configurators, IBinder binder, IProvisionListenerNotifier provisionListenerNotifier, IInjectionListenerNotifier injectionListenerNotifier)
		{
			BindingBuilderRegistry bindingBuilderRegistry = new BindingBuilderRegistry(binder);
			ContainerDefinition containerDefinition = new ContainerDefinition(bindingBuilderRegistry, provisionListenerNotifier, injectionListenerNotifier);
			ConfiguratorRunner configuratorRunner = new ConfiguratorRunner(containerDefinition);
			containerDefinition.Bind<IContainer>().ToInstance(container);
			configuratorRunner.RunConfigurators(configurators);
			bindingBuilderRegistry.BuildAllBindings();
		}

		private static void ValidateConfiguration(IBindingValidator bindingValidator, IBinder binder)
		{
			new BinderValidator(bindingValidator, binder).Validate();
		}

		private static void InitializeInstanceProviders(InstanceProviderBank instanceProviderBank, Binder binder)
		{
			new InstanceProviderInitializer(instanceProviderBank, binder).InitializeAllInstanceProviders();
		}

		private void PostCreate(IInstanceProviderBank instanceProviderBank, IBinder binder)
		{
			_ownInstanceProviderBank = instanceProviderBank;
			_ownBinder = binder;
			_created = true;
		}
	}
}
