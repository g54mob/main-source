using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NSubstitute.Core;

namespace NSubstitute.Routing.AutoValues
{
	public class AutoObservableProvider : IAutoValueProvider
	{
		private readonly Lazy<IReadOnlyCollection<IAutoValueProvider>> _autoValueProviders;

		public AutoObservableProvider(Lazy<IReadOnlyCollection<IAutoValueProvider>> autoValueProviders)
		{
			_autoValueProviders = autoValueProviders;
		}

		public bool CanProvideValueFor(Type type)
		{
			if (type.GetTypeInfo().IsGenericType)
			{
				return type.GetGenericTypeDefinition() == typeof(IObservable<>);
			}
			return false;
		}

		public object? GetValue(Type type)
		{
			if (!CanProvideValueFor(type))
			{
				throw new InvalidOperationException();
			}
			Type innerType = type.GetGenericArguments()[0];
			IAutoValueProvider autoValueProvider = _autoValueProviders.Value.FirstOrDefault((IAutoValueProvider vp) => vp.CanProvideValueFor(innerType));
			object obj = ((autoValueProvider == null) ? GetDefault(type) : autoValueProvider.GetValue(innerType));
			return Activator.CreateInstance(typeof(ReturnObservable<>).MakeGenericType(innerType), obj);
		}

		private static object? GetDefault(Type type)
		{
			if (!type.GetTypeInfo().IsValueType)
			{
				return null;
			}
			return Activator.CreateInstance(type);
		}
	}
}
