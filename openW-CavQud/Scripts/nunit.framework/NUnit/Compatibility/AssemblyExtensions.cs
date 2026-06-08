using System;
using System.Reflection;

namespace NUnit.Compatibility
{
	public static class AssemblyExtensions
	{
		public static T GetCustomAttribute<T>(this Assembly assembly) where T : Attribute
		{
			T[] array = (T[])assembly.GetCustomAttributes(typeof(T), inherit: false);
			if (array.Length == 0)
			{
				return null;
			}
			return array[0];
		}
	}
}
