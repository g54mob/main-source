using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace IngameDebugConsole
{
	public static class DebugLogConsole
	{
		public delegate bool ParseFunction(string input, out object output);

		private static readonly List<ConsoleMethodInfo> methods;

		private static readonly List<ConsoleMethodInfo> matchingMethods;

		private static readonly Dictionary<Type, ParseFunction> parseFunctions;

		private static readonly Dictionary<Type, string> typeReadableNames;

		private static readonly List<string> commandArguments;

		private static readonly string[] inputDelimiters;

		private static readonly CompareInfo caseInsensitiveComparer;

		static DebugLogConsole()
		{
		}

		public static void LogAllCommands()
		{
		}

		public static void LogAllCommandsWithName(string commandName)
		{
		}

		public static void LogSystemInfo()
		{
		}

		private static StringBuilder AppendSysInfoIfPresent(this StringBuilder sb, string info, string postfix = null)
		{
			return null;
		}

		private static StringBuilder AppendSysInfoIfPresent(this StringBuilder sb, int info, string postfix = null)
		{
			return null;
		}

		public static void AddCustomParameterType(Type type, ParseFunction parseFunction, string typeReadableName = null)
		{
		}

		public static void RemoveCustomParameterType(Type type)
		{
		}

		public static void AddCommandInstance(string command, string description, string methodName, object instance, params string[] parameterNames)
		{
		}

		public static void AddCommandStatic(string command, string description, string methodName, Type ownerType, params string[] parameterNames)
		{
		}

		public static void AddCommand(string command, string description, Action method)
		{
		}

		public static void AddCommand<T1>(string command, string description, Action<T1> method)
		{
		}

		public static void AddCommand<T1>(string command, string description, Func<T1> method)
		{
		}

		public static void AddCommand<T1, T2>(string command, string description, Action<T1, T2> method)
		{
		}

		public static void AddCommand<T1, T2>(string command, string description, Func<T1, T2> method)
		{
		}

		public static void AddCommand<T1, T2, T3>(string command, string description, Action<T1, T2, T3> method)
		{
		}

		public static void AddCommand<T1, T2, T3>(string command, string description, Func<T1, T2, T3> method)
		{
		}

		public static void AddCommand<T1, T2, T3, T4>(string command, string description, Action<T1, T2, T3, T4> method)
		{
		}

		public static void AddCommand<T1, T2, T3, T4>(string command, string description, Func<T1, T2, T3, T4> method)
		{
		}

		public static void AddCommand<T1, T2, T3, T4, T5>(string command, string description, Func<T1, T2, T3, T4, T5> method)
		{
		}

		public static void AddCommand(string command, string description, Delegate method)
		{
		}

		public static void AddCommand<T1>(string command, string description, Action<T1> method, string parameterName)
		{
		}

		public static void AddCommand<T1, T2>(string command, string description, Action<T1, T2> method, string parameterName1, string parameterName2)
		{
		}

		public static void AddCommand<T1, T2>(string command, string description, Func<T1, T2> method, string parameterName)
		{
		}

		public static void AddCommand<T1, T2, T3>(string command, string description, Action<T1, T2, T3> method, string parameterName1, string parameterName2, string parameterName3)
		{
		}

		public static void AddCommand<T1, T2, T3>(string command, string description, Func<T1, T2, T3> method, string parameterName1, string parameterName2)
		{
		}

		public static void AddCommand<T1, T2, T3, T4>(string command, string description, Action<T1, T2, T3, T4> method, string parameterName1, string parameterName2, string parameterName3, string parameterName4)
		{
		}

		public static void AddCommand<T1, T2, T3, T4>(string command, string description, Func<T1, T2, T3, T4> method, string parameterName1, string parameterName2, string parameterName3)
		{
		}

		public static void AddCommand<T1, T2, T3, T4, T5>(string command, string description, Func<T1, T2, T3, T4, T5> method, string parameterName1, string parameterName2, string parameterName3, string parameterName4)
		{
		}

		public static void AddCommand(string command, string description, Delegate method, params string[] parameterNames)
		{
		}

		private static void AddCommand(string command, string description, string methodName, Type ownerType, object instance, string[] parameterNames)
		{
		}

		private static void AddCommand(string command, string description, MethodInfo method, object instance, string[] parameterNames)
		{
		}

		public static void RemoveCommand(string command)
		{
		}

		public static void RemoveCommand(Action method)
		{
		}

		public static void RemoveCommand<T1>(Action<T1> method)
		{
		}

		public static void RemoveCommand<T1>(Func<T1> method)
		{
		}

		public static void RemoveCommand<T1, T2>(Action<T1, T2> method)
		{
		}

		public static void RemoveCommand<T1, T2>(Func<T1, T2> method)
		{
		}

		public static void RemoveCommand<T1, T2, T3>(Action<T1, T2, T3> method)
		{
		}

		public static void RemoveCommand<T1, T2, T3>(Func<T1, T2, T3> method)
		{
		}

		public static void RemoveCommand<T1, T2, T3, T4>(Action<T1, T2, T3, T4> method)
		{
		}

		public static void RemoveCommand<T1, T2, T3, T4>(Func<T1, T2, T3, T4> method)
		{
		}

		public static void RemoveCommand<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5> method)
		{
		}

		public static void RemoveCommand(Delegate method)
		{
		}

		public static void RemoveCommand(MethodInfo method)
		{
		}

		public static string GetAutoCompleteCommand(string commandStart, string previousSuggestion)
		{
			return null;
		}

		public static void ExecuteCommand(string command)
		{
		}

		public static void FetchArgumentsFromCommand(string command, List<string> commandArguments)
		{
		}

		public static void FindCommands(string commandName, bool allowSubstringMatching, List<ConsoleMethodInfo> matchingCommands)
		{
		}

		internal static void GetCommandSuggestions(string command, List<ConsoleMethodInfo> matchingCommands, List<int> caretIndexIncrements, ref string commandName, out int numberOfParameters)
		{
			numberOfParameters = default(int);
		}

		private static int IndexOfDelimiterGroup(char c)
		{
			return 0;
		}

		private static int IndexOfDelimiterGroupEnd(string command, int delimiterIndex, int startIndex)
		{
			return 0;
		}

		private static int IndexOfChar(string command, char c, int startIndex)
		{
			return 0;
		}

		private static int FindCommandIndex(string command)
		{
			return 0;
		}

		public static bool IsSupportedArrayType(Type type)
		{
			return false;
		}

		public static string GetTypeReadableName(Type type)
		{
			return null;
		}

		public static bool ParseArgument(string input, Type argumentType, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseString(string input, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseBool(string input, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseInt(string input, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseUInt(string input, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseLong(string input, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseULong(string input, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseByte(string input, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseSByte(string input, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseShort(string input, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseUShort(string input, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseChar(string input, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseFloat(string input, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseDouble(string input, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseDecimal(string input, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseVector2(string input, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseVector3(string input, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseVector4(string input, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseQuaternion(string input, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseColor(string input, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseColor32(string input, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseRect(string input, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseRectOffset(string input, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseBounds(string input, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseVector2Int(string input, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseVector3Int(string input, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseRectInt(string input, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseBoundsInt(string input, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseGameObject(string input, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseComponent(string input, Type componentType, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseEnum(string input, Type enumType, out object output)
		{
			output = null;
			return false;
		}

		public static bool ParseArray(string input, Type arrayType, out object output)
		{
			output = null;
			return false;
		}

		private static bool ParseVector(string input, Type vectorType, out object output)
		{
			output = null;
			return false;
		}
	}
}
