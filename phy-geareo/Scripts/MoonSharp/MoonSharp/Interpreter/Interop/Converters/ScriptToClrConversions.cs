using System;

namespace MoonSharp.Interpreter.Interop.Converters
{
	internal static class ScriptToClrConversions
	{
		internal const int WEIGHT_MAX_VALUE = 100;

		internal const int WEIGHT_CUSTOM_CONVERTER_MATCH = 100;

		internal const int WEIGHT_EXACT_MATCH = 100;

		internal const int WEIGHT_STRING_TO_STRINGBUILDER = 99;

		internal const int WEIGHT_STRING_TO_CHAR = 98;

		internal const int WEIGHT_NIL_TO_NULLABLE = 100;

		internal const int WEIGHT_NIL_TO_REFTYPE = 100;

		internal const int WEIGHT_VOID_WITH_DEFAULT = 50;

		internal const int WEIGHT_VOID_WITHOUT_DEFAULT = 25;

		internal const int WEIGHT_NIL_WITH_DEFAULT = 25;

		internal const int WEIGHT_BOOL_TO_STRING = 5;

		internal const int WEIGHT_NUMBER_TO_STRING = 50;

		internal const int WEIGHT_NUMBER_TO_ENUM = 90;

		internal const int WEIGHT_USERDATA_TO_STRING = 5;

		internal const int WEIGHT_TABLE_CONVERSION = 90;

		internal const int WEIGHT_NUMBER_DOWNCAST = 99;

		internal const int WEIGHT_NO_MATCH = 0;

		internal const int WEIGHT_NO_EXTRA_PARAMS_BONUS = 100;

		internal const int WEIGHT_EXTRA_PARAMS_MALUS = 2;

		internal const int WEIGHT_BYREF_BONUSMALUS = -10;

		internal const int WEIGHT_VARARGS_MALUS = 1;

		internal const int WEIGHT_VARARGS_EMPTY = 40;

		internal static object DynValueToObject(DynValue value)
		{
			return null;
		}

		internal static object DynValueToObjectOfType(DynValue value, Type desiredType, object defaultValue, bool isOptional)
		{
			return null;
		}

		internal static int DynValueToObjectOfTypeWeight(DynValue value, Type desiredType, bool isOptional)
		{
			return 0;
		}

		private static int GetNumericTypeWeight(Type desiredType)
		{
			return 0;
		}
	}
}
