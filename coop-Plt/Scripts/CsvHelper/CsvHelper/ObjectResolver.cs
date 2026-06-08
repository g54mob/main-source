using System;

namespace CsvHelper
{
	public class ObjectResolver : IObjectResolver
	{
		private static IObjectResolver current;

		private readonly ObjectCreator objectCreator = new ObjectCreator();

		public static IObjectResolver Current
		{
			get
			{
				return current;
			}
			set
			{
				if (value == null)
				{
					throw new InvalidOperationException("IObjectResolver cannot be null.");
				}
				current = value;
			}
		}

		public bool UseFallback { get; private set; }

		public Func<Type, bool> CanResolve { get; private set; }

		public Func<Type, object[], object> ResolveFunction { get; private set; }

		static ObjectResolver()
		{
			ObjectCreator objectCreator = new ObjectCreator();
			object locker = new object();
			current = new ObjectResolver((Type type) => true, delegate(Type type, object[] args)
			{
				lock (locker)
				{
					return objectCreator.CreateInstance(type, args);
				}
			});
		}

		public ObjectResolver()
		{
			CanResolve = (Type type) => true;
			ResolveFunction = ResolveWithObjectCreator;
			UseFallback = true;
		}

		public ObjectResolver(Func<Type, bool> canResolve, Func<Type, object[], object> resolveFunction, bool useFallback = true)
		{
			CanResolve = canResolve ?? throw new ArgumentNullException("canResolve");
			ResolveFunction = resolveFunction ?? throw new ArgumentNullException("resolveFunction");
			UseFallback = useFallback;
		}

		public object Resolve(Type type, params object[] constructorArgs)
		{
			if (CanResolve(type))
			{
				return ResolveFunction(type, constructorArgs);
			}
			if (UseFallback)
			{
				return objectCreator.CreateInstance(type, constructorArgs);
			}
			throw new CsvHelperException("Type '" + type.FullName + "' can't be resolved and fallback is turned off.");
		}

		public T Resolve<T>(params object[] constructorArgs)
		{
			return (T)Resolve(typeof(T), constructorArgs);
		}

		private object ResolveWithObjectCreator(Type type, params object[] args)
		{
			return objectCreator.CreateInstance(type, args);
		}
	}
}
