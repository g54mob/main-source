using System;
using System.Collections.Generic;

namespace Dhs5.Utility.Console
{
	public static class ConsoleCommandUtility
	{
		public const string PARAM_INT = "$INT$";

		public const string PARAM_FLOAT = "$FLOAT$";

		public const string PARAM_BOOL = "$BOOL$";

		public const string PARAM_STR = "$STRING$";

		internal static List<CommandArray> GetCommandOptions(this IConsoleCommand consoleCommand)
		{
			List<CommandArray> list = new List<CommandArray>();
			if (consoleCommand.IsValid())
			{
				Recursive_GetCommand(consoleCommand, list, default(CommandArray), 0);
			}
			return list;
		}

		internal static List<CommandArray> GetCommandOptionsStartingWith(this IConsoleCommand consoleCommand, string commandStart)
		{
			List<CommandArray> list = new List<CommandArray>();
			CommandArray startArray = new CommandArray(commandStart);
			if (consoleCommand.IsValid())
			{
				Recursive_GetCommandStartingWith(consoleCommand, list, default(CommandArray), 0, startArray);
			}
			return list;
		}

		private static void Recursive_GetCommand(IConsoleCommand consoleCommand, List<CommandArray> commandArrays, CommandArray currentArray, int pieceIndex)
		{
			foreach (string option in consoleCommand[pieceIndex].GetOptions())
			{
				CommandArray commandArray = new CommandArray(currentArray);
				commandArray.Push(option);
				if (pieceIndex == consoleCommand.Count - 1)
				{
					commandArrays.Add(commandArray);
				}
				else
				{
					Recursive_GetCommand(consoleCommand, commandArrays, commandArray, pieceIndex + 1);
				}
			}
		}

		private static void Recursive_GetCommandStartingWith(IConsoleCommand consoleCommand, List<CommandArray> commandArrays, CommandArray currentArray, int pieceIndex, CommandArray startArray)
		{
			foreach (string option in consoleCommand[pieceIndex].GetOptions())
			{
				CommandArray commandArray = new CommandArray(currentArray);
				commandArray.Push(option);
				if (!startArray.StartsTheSameAs(commandArray))
				{
					continue;
				}
				if (pieceIndex == consoleCommand.Count - 1)
				{
					if (startArray.Count <= commandArray.Count)
					{
						commandArrays.Add(commandArray);
					}
				}
				else if (commandArray.Count > startArray.Count)
				{
					Recursive_GetCommand(consoleCommand, commandArrays, commandArray, pieceIndex + 1);
				}
				else
				{
					Recursive_GetCommandStartingWith(consoleCommand, commandArrays, commandArray, pieceIndex + 1, startArray);
				}
			}
		}

		internal static bool IsCommandValid(this IConsoleCommand consoleCommand, string rawCommand, out ValidCommand validCommand)
		{
			rawCommand = rawCommand.Trim();
			string text = rawCommand;
			object[] array = new object[consoleCommand.Count];
			for (int i = 0; i < consoleCommand.Count; i++)
			{
				if (consoleCommand[i].IsCommandValid(text, out var parameter, out var rawCommandLeft))
				{
					array[i] = parameter;
					text = rawCommandLeft;
					continue;
				}
				validCommand = ValidCommand.Invalid();
				return false;
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				validCommand = ValidCommand.Invalid();
				return false;
			}
			validCommand = new ValidCommand(consoleCommand, rawCommand, array);
			return true;
		}

		public static bool IsParameterString(string str, out ParamType paramType)
		{
			switch (str)
			{
			case "$BOOL$":
				paramType = ParamType.BOOL;
				return true;
			case "$INT$":
				paramType = ParamType.INT;
				return true;
			case "$FLOAT$":
				paramType = ParamType.FLOAT;
				return true;
			case "$STRING$":
				paramType = ParamType.STRING;
				return true;
			default:
				paramType = ParamType.BOOL;
				return false;
			}
		}

		public static string GetParameterString(ParamType paramType)
		{
			return paramType switch
			{
				ParamType.BOOL => "$BOOL$", 
				ParamType.INT => "$INT$", 
				ParamType.FLOAT => "$FLOAT$", 
				ParamType.STRING => "$STRING$", 
				_ => null, 
			};
		}

		public static bool IsParameterValid(string paramStr, ParamType paramType, out object param)
		{
			param = null;
			switch (paramType)
			{
			case ParamType.BOOL:
				if (paramStr == "T")
				{
					param = true;
					return true;
				}
				if (paramStr == "F")
				{
					param = false;
					return true;
				}
				return false;
			case ParamType.INT:
			{
				if (int.TryParse(paramStr, out var result2))
				{
					param = result2;
					return true;
				}
				return false;
			}
			case ParamType.FLOAT:
			{
				if (float.TryParse(paramStr, out var result))
				{
					param = result;
					return true;
				}
				return false;
			}
			case ParamType.STRING:
				param = paramStr;
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		public static string ParamDefaultValueAsString(ParamType paramType)
		{
			return paramType switch
			{
				ParamType.BOOL => "F", 
				ParamType.INT => "0", 
				ParamType.FLOAT => "0.0", 
				ParamType.STRING => "_", 
				_ => throw new NotImplementedException(), 
			};
		}
	}
}
