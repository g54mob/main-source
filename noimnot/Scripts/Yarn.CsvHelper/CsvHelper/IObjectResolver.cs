using System;

namespace CsvHelper
{
	public interface IObjectResolver
	{
		bool UseFallback { get; }

		Func<Type, bool> CanResolve { get; }

		Func<Type, object[], object> ResolveFunction { get; }

		object Resolve(Type type, params object[] constructorArgs);

		T Resolve<T>(params object[] constructorArgs);
	}
}
