using System;
using System.Collections.Generic;
using System.Reflection;

namespace CLanguage
{
	internal static class ValueReflection
	{
		public static readonly Dictionary<Type, FieldInfo> TypedFields;

		public static readonly Dictionary<Type, MethodInfo> CreateValueFromTypeMethods;

		static ValueReflection()
		{
		}
	}
}
