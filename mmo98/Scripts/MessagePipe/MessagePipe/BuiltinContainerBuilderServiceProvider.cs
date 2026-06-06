using System;
using System.Collections.Generic;

namespace MessagePipe
{
	internal class BuiltinContainerBuilderServiceProvider : IServiceProvider
	{
		private readonly Dictionary<Type, Lazy<object>> singletonInstances;

		private readonly Dictionary<Type, ServiceProviderType> transientTypes;

		public BuiltinContainerBuilderServiceProvider(BuiltinContainerBuilder builder)
		{
			singletonInstances = new Dictionary<Type, Lazy<object>>(builder.singletonInstances.Count + builder.singleton.Count);
			transientTypes = new Dictionary<Type, ServiceProviderType>(builder.transient.Count);
			foreach (KeyValuePair<Type, object> item in builder.singletonInstances)
			{
				singletonInstances[item.Key] = new Lazy<object>(() => item.Value);
			}
			foreach (var item2 in builder.singleton)
			{
				Type implType = item2.implementationType;
				singletonInstances[item2.serviceType] = new Lazy<object>(() => new ServiceProviderType(implType).Instantiate(this, 0));
			}
			foreach (var item3 in builder.transient)
			{
				transientTypes[item3.serviceType] = new ServiceProviderType(item3.implementationType);
			}
		}

		public object GetService(Type serviceType)
		{
			return GetService(serviceType, 0);
		}

		public object GetService(Type serviceType, int depth)
		{
			if (serviceType == typeof(IServiceProvider))
			{
				return this;
			}
			if (singletonInstances.TryGetValue(serviceType, out var value))
			{
				return value.Value;
			}
			if (transientTypes.TryGetValue(serviceType, out var value2))
			{
				return value2.Instantiate(this, depth);
			}
			return null;
		}
	}
}
