using System;
using System.Collections.Generic;

namespace Bindito.Core.Internal
{
	public class InstanceProviderInitializer
	{
		private readonly IBinder _binder;

		private readonly IInstanceProviderBank _instanceProviderBank;

		public InstanceProviderInitializer(IInstanceProviderBank instanceProviderBank, IBinder binder)
		{
			_instanceProviderBank = instanceProviderBank;
			_binder = binder;
		}

		public void InitializeAllInstanceProviders()
		{
			InitializeAllSingleInstanceProviders();
			InitializeAllMutliInstanceProviders();
		}

		private void InitializeAllSingleInstanceProviders()
		{
			foreach (KeyValuePair<Type, Binding> binding in _binder.Bindings)
			{
				Type key = binding.Key;
				if (!_instanceProviderBank.TryGetInstanceProvider(key, out var _))
				{
					throw new InvalidOperationException("Failed to initialize InstanceProvider for " + TypeFormatting.Format(key) + ".");
				}
			}
		}

		private void InitializeAllMutliInstanceProviders()
		{
			foreach (KeyValuePair<Type, IReadOnlyList<Binding>> multiBinding in _binder.MultiBindings)
			{
				_instanceProviderBank.GetInstanceProviders(multiBinding.Key);
			}
		}
	}
}
