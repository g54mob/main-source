using System;

namespace Castle.Core.Internal
{
	internal static class TypeExtensions
	{
		public static string GetBestName(this Type type)
		{
			return type.FullName ?? type.Name;
		}
	}
}
