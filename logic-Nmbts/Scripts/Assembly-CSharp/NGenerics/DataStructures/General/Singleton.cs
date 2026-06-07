using System;
using System.Runtime.CompilerServices;

namespace NGenerics.DataStructures.General
{
	public static class Singleton<T>
	{
		public delegate T FactoryDelegate();

		private static class Container
		{
			internal static readonly T Instance = Singleton<T>.createInstance();
		}

		private static FactoryDelegate createInstance = Activator.CreateInstance<T>;

		public static FactoryDelegate ConstructWith
		{
			set
			{
				if (value != null)
				{
					createInstance = value;
					RuntimeHelpers.RunClassConstructor(typeof(Container).TypeHandle);
				}
			}
		}

		public static T Instance
		{
			get
			{
				return Container.Instance;
			}
		}
	}
}
