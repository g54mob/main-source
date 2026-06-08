using System;
using System.Collections.Generic;

namespace Bindito.Core.Internal
{
	public class InstanceProviderFuncFactory : IInstanceProviderFuncFactory
	{
		private readonly IInstanceCreator _instanceCreator;

		private readonly IMethodInjector _methodInjector;

		private readonly IProvisionListenerNotifier _provisionListenerNotifier;

		private readonly IValidatingMethodInjector _validatingMethodInjector;

		private readonly IInstanceBank _instanceBank;

		private readonly Dictionary<Type, IProvider<object>> _providers = new Dictionary<Type, IProvider<object>>();

		public InstanceProviderFuncFactory(IInstanceCreator instanceCreator, IMethodInjector methodInjector, IProvisionListenerNotifier provisionListenerNotifier, IValidatingMethodInjector validatingMethodInjector, IInstanceBank instanceBank)
		{
			_instanceCreator = instanceCreator;
			_methodInjector = methodInjector;
			_provisionListenerNotifier = provisionListenerNotifier;
			_validatingMethodInjector = validatingMethodInjector;
			_instanceBank = instanceBank;
		}

		public Func<object> CreateInstanceProviderFunc(ProvisionBinding provisionBinding)
		{
			if (provisionBinding.Instance != null)
			{
				return () => ProvideBoundInstance(provisionBinding.Instance);
			}
			if (provisionBinding.ProviderType != null)
			{
				return () => ProvideInstanceFromProviderType(provisionBinding.ProviderType);
			}
			if (provisionBinding.ProviderInstance != null)
			{
				return () => ProvideInstanceFromProviderInstance(provisionBinding.ProviderInstance);
			}
			if (provisionBinding.ProvidingMethod != null)
			{
				return () => ProvideInstanceFromProvidingMethod(provisionBinding.ProvidingMethod);
			}
			if (provisionBinding.Type != null)
			{
				return () => ProvideCreatedInstance(provisionBinding.Type);
			}
			if (provisionBinding.ExistingType != null)
			{
				return () => ProvideInstanceFromExistingBinding(provisionBinding.ExistingType);
			}
			throw new InvalidOperationException($"{provisionBinding} has an unknown binding. This is an internal Bindito error!");
		}

		private object ProvideBoundInstance(object instance)
		{
			return PostInitializeValidatedInstance(instance);
		}

		private object ProvideInstanceFromProviderType(Type providerType)
		{
			IProvider<object> provider = GetProvider(providerType);
			return ProvideInstanceFromProviderInstance(provider);
		}

		private IProvider<object> GetProvider(Type providerType)
		{
			if (!_providers.TryGetValue(providerType, out var value))
			{
				value = ProvideCreatedInstance(providerType) as IProvider<object>;
				_providers[providerType] = value;
			}
			return value;
		}

		private object ProvideInstanceFromProviderInstance(IProvider<object> provider)
		{
			return ProvideInstanceFromProvidingMethod(provider.Get);
		}

		private object ProvideInstanceFromProvidingMethod(Func<object> providingMethod)
		{
			return PostInitializeUnvalidatedInstance(providingMethod());
		}

		private object ProvideCreatedInstance(Type type)
		{
			return PostInitializeValidatedInstance(_instanceCreator.CreateInstance(type));
		}

		private object PostInitializeValidatedInstance(object instance)
		{
			_methodInjector.Inject(instance);
			return PostInitializeInstance(instance);
		}

		private object PostInitializeUnvalidatedInstance(object instance)
		{
			_validatingMethodInjector.Inject(instance);
			return PostInitializeInstance(instance);
		}

		private object PostInitializeInstance(object instance)
		{
			_provisionListenerNotifier.NotifyAllListeners(instance);
			return instance;
		}

		private object ProvideInstanceFromExistingBinding(Type existingType)
		{
			if (_instanceBank.TryGetInstance(existingType, out var instance))
			{
				return instance;
			}
			throw new InvalidOperationException("Couldn't get an instance of " + TypeFormatting.Format(existingType) + " from an existing binding. This is an internal Bindito error!");
		}
	}
}
