using System;

namespace Bindito.Core.Internal
{
	public class Scoper : IScoper
	{
		public Func<object> PlaceInScope(Func<object> provider, Scope scope)
		{
			if (!IsSingleton(scope))
			{
				return provider;
			}
			return WrapInInstanceCacher(provider);
		}

		private static bool IsSingleton(Scope scope)
		{
			return scope == Scope.Singleton;
		}

		private static Func<object> WrapInInstanceCacher(Func<object> provider)
		{
			object instance = provider();
			return () => instance;
		}
	}
}
