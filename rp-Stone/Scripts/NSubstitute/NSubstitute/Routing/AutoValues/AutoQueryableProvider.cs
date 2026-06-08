using System;
using System.Linq;
using System.Reflection;

namespace NSubstitute.Routing.AutoValues
{
	public class AutoQueryableProvider : IAutoValueProvider
	{
		public bool CanProvideValueFor(Type type)
		{
			if (type.GetTypeInfo().IsGenericType)
			{
				return type.GetGenericTypeDefinition() == typeof(IQueryable<>);
			}
			return false;
		}

		public object GetValue(Type type)
		{
			if (!CanProvideValueFor(type))
			{
				throw new InvalidOperationException();
			}
			return Array.CreateInstance(type.GetGenericArguments()[0], 0).AsQueryable();
		}
	}
}
