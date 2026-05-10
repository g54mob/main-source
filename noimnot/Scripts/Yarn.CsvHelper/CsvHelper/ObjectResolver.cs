using System;

namespace CsvHelper
{
	public class ObjectResolver : IObjectResolver
	{
		private static readonly object locker;

		private static IObjectResolver current;

		public static IObjectResolver Current
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool UseFallback { get; private set; }

		public Func<Type, bool> CanResolve { get; private set; }

		public Func<Type, object[], object> ResolveFunction { get; private set; }

		public ObjectResolver()
		{
		}

		public ObjectResolver(Func<Type, bool> canResolve, Func<Type, object[], object> resolveFunction, bool useFallback = true)
		{
		}

		public object Resolve(Type type, params object[] constructorArgs)
		{
			return null;
		}

		public T Resolve<T>(params object[] constructorArgs)
		{
			return default(T);
		}
	}
}
