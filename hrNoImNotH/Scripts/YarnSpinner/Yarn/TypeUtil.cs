using System;

namespace Yarn
{
	internal static class TypeUtil
	{
		internal static Delegate GetMethod<TResult>(Func<Value, Value, TResult> f)
		{
			return null;
		}

		internal static Delegate GetMethod<T>(Func<Value, T> f)
		{
			return null;
		}

		internal static Delegate GetMethod<T>(Func<T> f)
		{
			return null;
		}

		internal static IType FindImplementingTypeForMethod(IType type, string methodName)
		{
			return null;
		}

		internal static string GetCanonicalNameForMethod(IType implementingType, string methodName)
		{
			return null;
		}

		internal static void GetNamesFromCanonicalName(string canonicalName, out string typeName, out string methodName)
		{
			typeName = null;
			methodName = null;
		}

		internal static bool IsSubType(IType parentType, IType subType)
		{
			return false;
		}
	}
}
