using System;
using System.Reflection;

namespace FullInspector.Internal
{
	public static class fiAssemblyExtensions
	{
		private static Type[] s_EmptyArray = new Type[0];

		public static Type[] GetTypesWithoutException(this Assembly assembly)
		{
			try
			{
				return assembly.GetTypes();
			}
			catch
			{
				return s_EmptyArray;
			}
		}
	}
}
