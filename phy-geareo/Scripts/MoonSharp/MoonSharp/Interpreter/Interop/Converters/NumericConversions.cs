using System;
using System.Collections.Generic;

namespace MoonSharp.Interpreter.Interop.Converters
{
	internal static class NumericConversions
	{
		internal static readonly HashSet<Type> NumericTypes;

		internal static readonly Type[] NumericTypesOrdered;

		static NumericConversions()
		{
		}

		internal static object DoubleToType(Type type, double d)
		{
			return null;
		}

		internal static double TypeToDouble(Type type, object d)
		{
			return 0.0;
		}
	}
}
