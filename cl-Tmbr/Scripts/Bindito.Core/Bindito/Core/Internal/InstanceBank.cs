using System;
using System.Collections.Generic;
using System.Linq;

namespace Bindito.Core.Internal
{
	public class InstanceBank : IInstanceBank
	{
		private readonly IInstanceProviderBank _instanceProviderBank;

		public InstanceBank(IInstanceProviderBank instanceProviderBank)
		{
			_instanceProviderBank = instanceProviderBank;
		}

		public bool TryGetInstance(Type type, out object instance)
		{
			if (_instanceProviderBank.TryGetInstanceProvider(type, out var instanceProvider))
			{
				instance = instanceProvider.GetInstance();
				return true;
			}
			instance = null;
			return false;
		}

		public bool TryGetExportedInstance(Type type, out object instance)
		{
			if (_instanceProviderBank.TryGetExportedInstanceProvider(type, out var instanceProvider))
			{
				instance = instanceProvider.GetInstance();
				return true;
			}
			instance = null;
			return false;
		}

		public IEnumerable<object> GetInstances(Type type)
		{
			return from provider in _instanceProviderBank.GetInstanceProviders(type)
				select provider.GetInstance();
		}

		public IEnumerable<object> GetExportedInstances(Type type)
		{
			return from provider in _instanceProviderBank.GetExportedInstanceProviders(type)
				select provider.GetInstance();
		}
	}
}
