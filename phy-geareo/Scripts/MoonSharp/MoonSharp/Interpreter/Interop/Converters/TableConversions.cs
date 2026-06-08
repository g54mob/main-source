using System;
using System.Collections;
using System.Collections.Generic;

namespace MoonSharp.Interpreter.Interop.Converters
{
	internal static class TableConversions
	{
		internal static Table ConvertIListToTable(Script script, IList list)
		{
			return null;
		}

		internal static Table ConvertIDictionaryToTable(Script script, IDictionary dict)
		{
			return null;
		}

		internal static bool CanConvertTableToType(Table table, Type t)
		{
			return false;
		}

		internal static object ConvertTableToType(Table table, Type t)
		{
			return null;
		}

		internal static object ConvertTableToDictionaryOfGenericType(Type dictionaryType, Type keyType, Type valueType, Table table)
		{
			return null;
		}

		internal static object ConvertTableToArrayOfGenericType(Type arrayType, Type itemType, Table table)
		{
			return null;
		}

		internal static object ConvertTableToListOfGenericType(Type listType, Type itemType, Table table)
		{
			return null;
		}

		internal static List<T> TableToList<T>(Table table, Func<DynValue, T> converter)
		{
			return null;
		}

		internal static Dictionary<TK, TV> TableToDictionary<TK, TV>(Table table, Func<DynValue, TK> keyconverter, Func<DynValue, TV> valconverter)
		{
			return null;
		}
	}
}
