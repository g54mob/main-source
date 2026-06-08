using System;
using System.Collections.Generic;
using System.Linq;

namespace Bindito.Core.Internal
{
	public class InstanceProviderBank : IInstanceProviderBank
	{
		private readonly IBinder _binder;

		private readonly IInstanceProviderBank _parent;

		private readonly Dictionary<Type, InstanceProvider> _singleInstanceProviders = new Dictionary<Type, InstanceProvider>();

		private readonly Dictionary<Type, List<InstanceProvider>> _multiInstanceProviders = new Dictionary<Type, List<InstanceProvider>>();

		public IInstanceProviderFactory InstanceProviderFactory { private get; set; }

		public InstanceProviderBank(IBinder binder, IInstanceProviderBank parent)
		{
			_binder = binder;
			_parent = parent;
		}

		public bool TryGetInstanceProvider(Type type, out InstanceProvider instanceProvider)
		{
			if (!_singleInstanceProviders.TryGetValue(type, out instanceProvider) && !TryGetInstanceProviderFromParent(type, out instanceProvider))
			{
				return TryInitializeInstanceProvider(type, out instanceProvider);
			}
			return true;
		}

		public bool TryGetExportedInstanceProvider(Type type, out InstanceProvider instanceProvider)
		{
			if (TryGetInstanceProvider(type, out instanceProvider) && instanceProvider.Exported)
			{
				return true;
			}
			instanceProvider = null;
			return false;
		}

		public IEnumerable<InstanceProvider> GetInstanceProviders(Type type)
		{
			IEnumerable<InstanceProvider> first;
			if (!_multiInstanceProviders.TryGetValue(type, out var value))
			{
				first = InitializeMultiInstanceProviders(type);
			}
			else
			{
				IEnumerable<InstanceProvider> enumerable = value;
				first = enumerable;
			}
			return first.Concat(GetInstanceProvidersFromParent(type));
		}

		public IEnumerable<InstanceProvider> GetExportedInstanceProviders(Type type)
		{
			return from instanceProvider in GetInstanceProviders(type)
				where instanceProvider.Exported
				select instanceProvider;
		}

		private bool TryGetInstanceProviderFromParent(Type type, out InstanceProvider instanceProvider)
		{
			if (_parent != null && _parent.TryGetExportedInstanceProvider(type, out instanceProvider))
			{
				return true;
			}
			instanceProvider = null;
			return false;
		}

		private IEnumerable<InstanceProvider> GetInstanceProvidersFromParent(Type type)
		{
			if (_parent == null)
			{
				return Enumerable.Empty<InstanceProvider>();
			}
			return _parent.GetExportedInstanceProviders(type);
		}

		private bool TryInitializeInstanceProvider(Type type, out InstanceProvider instanceProvider)
		{
			if (_binder.TryGetBinding(type, out var binding))
			{
				instanceProvider = InstanceProviderFactory.CreateInstanceProvider(binding);
				_singleInstanceProviders[type] = instanceProvider;
				return true;
			}
			instanceProvider = null;
			return false;
		}

		private IEnumerable<InstanceProvider> InitializeMultiInstanceProviders(Type type)
		{
			List<InstanceProvider> list = (from binding in _binder.GetMultiBindings(type)
				select InstanceProviderFactory.CreateInstanceProvider(binding)).ToList();
			_multiInstanceProviders[type] = list;
			return list;
		}
	}
}
