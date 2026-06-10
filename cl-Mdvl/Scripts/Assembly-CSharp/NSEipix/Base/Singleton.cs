using System;
using System.Reflection;

namespace NSEipix.Base
{
	public abstract class Singleton<T> where T : class
	{
		private static readonly Lazy<T> LazyInstance = new Lazy<T>(delegate
		{
			ConstructorInfo[] constructors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
			if (typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.Public).Length != 0)
			{
				throw new Exception("Singleton can not have public constructors.");
			}
			if (Array.Exists(constructors, (ConstructorInfo constructor) => constructor.GetParameters().Length != 0))
			{
				throw new Exception("Singleton can not have constructors with parameters.");
			}
			return Array.Find(constructors, (ConstructorInfo constructor) => constructor.IsPrivate && constructor.GetParameters().Length == 0).Invoke(new object[0]) as T;
		});

		public static T Instance => LazyInstance.Value;
	}
}
