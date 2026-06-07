using System;
using System.Reflection;

namespace Coherence.Utils
{
	internal static class ReflectionUtils
	{
		public static bool MethodExists(Type targetType, string methodName, BindingFlags bindingFlags)
		{
			return false;
		}

		public static bool TryGetMethod(Type targetType, string methodName, BindingFlags bindingFlags, out MethodInfo method)
		{
			method = null;
			return false;
		}
	}
}
