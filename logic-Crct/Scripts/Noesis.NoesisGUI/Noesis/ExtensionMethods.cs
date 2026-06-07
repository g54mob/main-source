using System;
using System.Reflection;

namespace Noesis
{
	public static class ExtensionMethods
	{
		public static Type GetTypeInfo(this Type type)
		{
			return null;
		}

		public static T GetCustomAttribute<T>(this MemberInfo member) where T : Attribute
		{
			return null;
		}

		public static Delegate CreateDelegate(this MethodInfo method, Type type)
		{
			return null;
		}
	}
}
