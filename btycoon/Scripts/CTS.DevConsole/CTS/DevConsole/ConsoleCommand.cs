using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace CTS.DevConsole
{
	public abstract class ConsoleCommand
	{
		public enum EArgType
		{
			Float = 0,
			Int = 1,
			String = 2,
			StringList = 3,
			Bool = 4,
			Type = 5
		}

		private Dictionary<string, ConsoleCommand> _subCommands;

		protected const string HelperEmpty = "[...]";

		protected const string HelperString = "[String]";

		protected const string HelperInt = "[Int]";

		protected const string HelperFloat = "[Float]";

		protected const string HelperBool = "[True/False]";

		protected const string HelperType = "[Type]";

		public abstract string Command { get; }

		public abstract bool CanHaveNoArguments { get; }

		public abstract bool EnableHelpCommand { get; }

		public int ArgumentCount
		{
			get
			{
				object[] argumentTypes = ArgumentTypes;
				if (argumentTypes == null)
				{
					return 0;
				}
				return argumentTypes.Length;
			}
		}

		public abstract object[] ArgumentTypes { get; }

		public ConsoleCommand BaseCommand { get; private set; }

		public IDictionary<string, ConsoleCommand> SubCommands => _subCommands;

		internal bool HasSubCommands
		{
			get
			{
				if (_subCommands != null)
				{
					return _subCommands.Count > 0;
				}
				return false;
			}
		}

		public bool IsSubCommand => BaseCommand != null;

		protected virtual List<string> GetStringListArgument(int argIndex, out bool caseSensitive)
		{
			caseSensitive = false;
			return null;
		}

		public void Run(DeveloperConsole.InputReport report)
		{
			try
			{
				if (report.Validity == EValidity.Valid)
				{
					string[] rawArgs = ((report.Arguments == null) ? Array.Empty<string>() : report.Arguments.ToArray());
					if (EnableHelpCommand && report.HasMatches && report.CommandMatches.Contains("Help"))
					{
						string fullCommandHelper = GetFullCommandHelper();
						DeveloperConsole.Log("'" + fullCommandHelper + "': " + GetCommandDescription() + " -> ", GetFullCommandList(fullCommandHelper) ?? "");
						DeveloperConsole.OpenLastLog();
					}
					else
					{
						if (report.CastedArguments == null)
						{
							report.CastedArguments = new List<object>();
						}
						RunCommand(report.CastedArguments, rawArgs);
					}
					return;
				}
				throw new Exception(report.ErrorMessage);
			}
			catch (Exception exception)
			{
				DeveloperConsole.LogException(exception);
			}
		}

		protected abstract void RunCommand(List<object> args, string[] rawArgs);

		public virtual string GetFullCommandList(string baseCommand = "")
		{
			string text = "";
			baseCommand += " ";
			if (CanHaveNoArguments)
			{
				text = text + baseCommand + "\n";
			}
			if (ArgumentCount > 0)
			{
				text += ArgumentTypes.Aggregate(baseCommand, (string text2, object argType) => text2 + GetHelperFromArgType(argType) + " ");
				text += " \n";
			}
			text = text + "\t " + GetCommandDescription() + " \n";
			if (_subCommands == null || _subCommands.Count <= 0)
			{
				return text;
			}
			foreach (KeyValuePair<string, ConsoleCommand> subCommand in _subCommands)
			{
				text += subCommand.Value.GetFullCommandList(baseCommand + subCommand.Value.Command);
			}
			return text;
		}

		public abstract string GetCommandDescription();

		public string GetHelperFromArgType(object arg)
		{
			if (!(arg is EArgType basicType))
			{
				if (arg is Type type)
				{
					return GetEnumType(type);
				}
				return "[Invalid Helper Definition]";
			}
			return GetBasicType(basicType);
			static string GetBasicType(EArgType eArgType)
			{
				switch (eArgType)
				{
				case EArgType.Float:
					return "[Float]";
				case EArgType.Int:
					return "[Int]";
				case EArgType.String:
				case EArgType.StringList:
					return "[String]";
				case EArgType.Bool:
					return "[True/False]";
				case EArgType.Type:
					return "[Type]";
				default:
					return "[...]";
				}
			}
			static string GetEnumType(Type type2)
			{
				if (!type2.IsEnum)
				{
					return "[Invalid Helper Type Definition]";
				}
				return "[" + type2.Name + "]";
			}
		}

		private string GetFullCommandHelper()
		{
			string text = Command;
			for (ConsoleCommand baseCommand = BaseCommand; baseCommand != null; baseCommand = baseCommand.BaseCommand)
			{
				text = baseCommand.Command + " " + text;
			}
			return "/" + text;
		}

		public void TryRegisterSubCommands(IDictionary<Type, List<ConsoleCommand>> registeredSubCommands)
		{
			Type type = GetType();
			if (registeredSubCommands.ContainsKey(type))
			{
				RegisterSubCommands(registeredSubCommands[type]);
			}
			registeredSubCommands.Remove(type);
			if (_subCommands == null)
			{
				return;
			}
			foreach (ConsoleCommand value in _subCommands.Values)
			{
				value.TryRegisterSubCommands(registeredSubCommands);
			}
			void RegisterSubCommands(IEnumerable<ConsoleCommand> subCommands)
			{
				_subCommands = new Dictionary<string, ConsoleCommand>();
				foreach (ConsoleCommand subCommand in subCommands)
				{
					string key = subCommand.Command.ToLowerInvariant();
					if (!_subCommands.ContainsKey(key))
					{
						_subCommands.Add(key, subCommand);
						subCommand.BaseCommand = this;
					}
				}
			}
		}

		public virtual void CheckValidityOfArguments(ref DeveloperConsole.InputReport inputReport, List<string> args)
		{
			inputReport.CommandMatches = new List<string>();
			inputReport.Validity = EValidity.Empty;
			if (args.Count <= 0)
			{
				inputReport.Validity = (CanHaveNoArguments ? EValidity.Valid : EValidity.Incomplete);
				inputReport.CommandMatches.Add(Command);
				inputReport.ErrorMessage = "Missing arguments.";
				return;
			}
			EValidity val = CheckSubCommands(ref inputReport);
			inputReport.CommandArgMatches = new List<string>();
			EValidity val2 = CheckArguments(ref inputReport);
			inputReport.Validity = (EValidity)Math.Max((int)val, (int)val2);
			if (inputReport.Validity == EValidity.Invalid)
			{
				inputReport.ErrorMessage = "Arguments invalid";
			}
			else if (inputReport.Validity == EValidity.Incomplete)
			{
				inputReport.ErrorMessage = "Arguments incomplete";
			}
			if (args.Count == 1 && args[0] == "" && CanHaveNoArguments)
			{
				inputReport.Validity = EValidity.Valid;
			}
			EValidity CheckArguments(ref DeveloperConsole.InputReport reference)
			{
				reference.Arguments = new List<string>();
				reference.CastedArguments = new List<object>();
				reference.CommandHelpers = new List<string>();
				EValidity eValidity = EValidity.Invalid;
				for (int i = 0; i < args.Count; i++)
				{
					string text = args[i];
					reference.CommandArgMatches.Clear();
					if (eValidity == EValidity.Valid)
					{
						reference.CommandHelpers.Clear();
					}
					if (IsArgumentIndexOutOfBounds(i))
					{
						if (!(text == ""))
						{
							reference.ErrorMessage = "Too many arguments";
							return EValidity.Invalid;
						}
					}
					else
					{
						reference.Arguments.Add(text);
						EValidity eValidity2 = CheckArgumentValidity(ref reference, text, i, i == args.Count - 1);
						if (eValidity2 == EValidity.Invalid || eValidity2 == EValidity.Incomplete)
						{
							if (i < args.Count - 1)
							{
								eValidity2 = EValidity.Invalid;
							}
							return eValidity2;
						}
						eValidity = EValidity.Valid;
						if (i < args.Count - 1)
						{
							ref string fullValidInput = ref reference.FullValidInput;
							fullValidInput = fullValidInput + text + " ";
						}
					}
				}
				return eValidity;
			}
			EValidity CheckSubCommands(ref DeveloperConsole.InputReport reference)
			{
				if (args.Count > 1)
				{
					return EValidity.Invalid;
				}
				string text = args[0].ToLowerInvariant();
				if (_subCommands != null)
				{
					foreach (var (text3, consoleCommand2) in _subCommands)
					{
						if (DeveloperConsole.ArgIsContainedIn(text, text3, caseSensitive: false))
						{
							reference.CommandMatches.Add(consoleCommand2.Command);
							if (text3 == text && consoleCommand2.CanHaveNoArguments)
							{
								return EValidity.Valid;
							}
						}
					}
				}
				if (EnableHelpCommand && DeveloperConsole.ArgIsContainedIn(text, "help", caseSensitive: false))
				{
					if (args.Count <= 1)
					{
						reference.CommandMatches.Add("Help");
					}
					if (text == "help")
					{
						return EValidity.Valid;
					}
				}
				if (reference.CommandMatches.Count <= 0)
				{
					return EValidity.Invalid;
				}
				return EValidity.Incomplete;
			}
		}

		protected virtual bool IsArgumentIndexOutOfBounds(int argIndex)
		{
			if (ArgumentTypes == null)
			{
				return true;
			}
			if (argIndex < 0)
			{
				return true;
			}
			if (argIndex >= ArgumentTypes.Length)
			{
				return true;
			}
			return false;
		}

		protected virtual EValidity CheckArgumentValidity(ref DeveloperConsole.InputReport inputReport, string arg, int argIndex, bool isLastArg)
		{
			object obj = ArgumentTypes[argIndex];
			EValidity eValidity;
			if (!(obj is EArgType argType))
			{
				if (!(obj is Type type))
				{
					return EValidity.Invalid;
				}
				if ((object)type == null)
				{
					goto IL_00dc;
				}
				if (type == typeof(float))
				{
					eValidity = CheckBasicTypeArgument(ref inputReport, this, arg, argIndex, EArgType.Float, isLastArg);
				}
				else if (type == typeof(int))
				{
					eValidity = CheckBasicTypeArgument(ref inputReport, this, arg, argIndex, EArgType.Int, isLastArg);
				}
				else if (type == typeof(string))
				{
					eValidity = CheckBasicTypeArgument(ref inputReport, this, arg, argIndex, EArgType.String, isLastArg);
				}
				else if (type == typeof(bool))
				{
					eValidity = CheckBasicTypeArgument(ref inputReport, this, arg, argIndex, EArgType.Bool, isLastArg);
				}
				else
				{
					if (!type.IsEnum)
					{
						goto IL_00dc;
					}
					eValidity = CheckEnumTypeArgument(ref inputReport, arg, argIndex, type);
				}
			}
			else
			{
				eValidity = CheckBasicTypeArgument(ref inputReport, this, arg, argIndex, argType, isLastArg);
			}
			goto IL_00ed;
			IL_00ed:
			if (eValidity == EValidity.Invalid || eValidity == EValidity.Incomplete)
			{
				inputReport.ErrorMessage = "Invalid argument '" + arg + "'.";
			}
			return eValidity;
			IL_00dc:
			eValidity = CheckBasicTypeArgument(ref inputReport, this, arg, argIndex, EArgType.Type, isLastArg);
			goto IL_00ed;
		}

		public static EValidity CheckBasicTypeArgument(ref DeveloperConsole.InputReport inputReport, ConsoleCommand command, string arg, int argIndex, EArgType argType, bool isLastArg)
		{
			switch (argType)
			{
			case EArgType.Float:
				return CheckFloat(inputReport);
			case EArgType.Int:
				return CheckInt(inputReport);
			case EArgType.Type:
				return CheckType(inputReport);
			case EArgType.StringList:
				return CheckStringList(inputReport);
			case EArgType.String:
				inputReport.CommandHelpers.Add("[String]");
				inputReport.CastedArguments.Insert(argIndex, arg);
				if (!(arg == ""))
				{
					return EValidity.Valid;
				}
				return EValidity.Incomplete;
			case EArgType.Bool:
				return CheckBool(inputReport);
			default:
				return EValidity.Invalid;
			}
			EValidity CheckBool(DeveloperConsole.InputReport inputReport2)
			{
				if (bool.TryParse(arg, out var result))
				{
					inputReport2.CastedArguments.Insert(argIndex, result);
					return EValidity.Valid;
				}
				EValidity result2 = EValidity.Invalid;
				if (DeveloperConsole.ArgIsContainedIn(arg, "true", caseSensitive: false))
				{
					inputReport2.CommandArgMatches.Add("True");
					result2 = EValidity.Incomplete;
				}
				if (DeveloperConsole.ArgIsContainedIn(arg, "false", caseSensitive: false))
				{
					inputReport2.CommandArgMatches.Add("False");
					result2 = EValidity.Incomplete;
				}
				return result2;
			}
			EValidity CheckFloat(DeveloperConsole.InputReport inputReport2)
			{
				if (float.TryParse(arg, NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
				{
					inputReport2.CommandHelpers.Add("[Float]");
					inputReport2.CastedArguments.Insert(argIndex, result);
					return EValidity.Valid;
				}
				if (arg == "")
				{
					inputReport2.CommandHelpers.Add("[Float]");
					return EValidity.Incomplete;
				}
				return EValidity.Invalid;
			}
			EValidity CheckInt(DeveloperConsole.InputReport inputReport2)
			{
				if (int.TryParse(arg, out var result))
				{
					inputReport2.CommandHelpers.Add("[Int]");
					inputReport2.CastedArguments.Insert(argIndex, result);
					return EValidity.Valid;
				}
				if (arg == "")
				{
					inputReport2.CommandHelpers.Add("[Int]");
					return EValidity.Incomplete;
				}
				return EValidity.Invalid;
			}
			EValidity CheckStringList(DeveloperConsole.InputReport inputReport2)
			{
				inputReport2.CastedArguments.Insert(argIndex, arg);
				if (command == null)
				{
					if (!(arg == ""))
					{
						return EValidity.Valid;
					}
					return EValidity.Incomplete;
				}
				bool caseSensitive;
				List<string> stringListArgument = command.GetStringListArgument(argIndex, out caseSensitive);
				inputReport2.CommandArgMatches.Clear();
				StringComparison comparisonType = (caseSensitive ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase);
				EValidity eValidity = EValidity.Invalid;
				foreach (string item in stringListArgument)
				{
					if (string.Equals(arg, item, comparisonType))
					{
						inputReport2.CommandArgMatches.Add(item);
						return EValidity.Valid;
					}
					if (inputReport2.CommandArgMatches.Count <= 30 && DeveloperConsole.ArgIsContainedIn(arg, item, caseSensitive))
					{
						if (eValidity < EValidity.Incomplete)
						{
							eValidity = EValidity.Incomplete;
						}
						inputReport2.CommandArgMatches.Add(item);
					}
				}
				return eValidity;
			}
			EValidity CheckType(DeveloperConsole.InputReport inputReport2)
			{
				EValidity eValidity = EValidity.Invalid;
				inputReport2.CommandHelpers.Add("[Type]");
				if (arg.Length == 0)
				{
					return EValidity.Incomplete;
				}
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				for (int i = 0; i < assemblies.Length; i++)
				{
					Type[] types = assemblies[i].GetTypes();
					foreach (Type type in types)
					{
						string name = type.Name;
						if (name == arg)
						{
							inputReport2.CommandArgMatches.Add(name);
							inputReport2.CastedArguments.Insert(argIndex, type);
							eValidity = EValidity.Valid;
							if (!isLastArg)
							{
								break;
							}
						}
						else if (inputReport2.CommandArgMatches.Count >= 15)
						{
							if (eValidity == EValidity.Valid)
							{
								break;
							}
						}
						else if (name.StartsWith(arg))
						{
							inputReport2.CommandArgMatches.Add(name);
							if (eValidity < EValidity.Incomplete)
							{
								eValidity = EValidity.Incomplete;
							}
						}
					}
				}
				return eValidity;
			}
		}

		public static EValidity CheckEnumTypeArgument(ref DeveloperConsole.InputReport inputReport, string arg, int argIndex, Type type)
		{
			if (!type.IsEnum)
			{
				throw new Exception(type.Name + " is not an enum type");
			}
			if (Enum.TryParse(type, arg, ignoreCase: true, out var result))
			{
				inputReport.CastedArguments.Insert(argIndex, result);
				return EValidity.Valid;
			}
			string[] names = Enum.GetNames(type);
			arg = arg.ToLowerInvariant();
			EValidity result2 = EValidity.Invalid;
			string[] array = names;
			foreach (string text in array)
			{
				if (DeveloperConsole.ArgIsContainedIn(arg, text, caseSensitive: false))
				{
					inputReport.CommandArgMatches.Add(text);
					result2 = EValidity.Incomplete;
				}
			}
			return result2;
		}

		protected static bool TryGetSelectedObject(Type type, out Component component, bool searchIfNothingSelected)
		{
			return DeveloperConsole.TryGetSelectedObject(type, out component, searchIfNothingSelected);
		}

		protected static Exception ErrorBadNumberOfArguments()
		{
			return new Exception("Invalid number of arguments");
		}

		protected static Exception ErrorBadArgument(string arg, params string[] correctArgs)
		{
			string text = "";
			if (correctArgs.Length != 0)
			{
				text = text + "'" + correctArgs[0] + "'";
				for (int i = 1; i < correctArgs.Length - 1; i++)
				{
					text = text + ", '" + correctArgs[i] + "'";
				}
				if (correctArgs.Length > 1)
				{
					text = text + " or '" + correctArgs[^1] + "'.";
				}
			}
			return new ArgumentException("Invalid argument " + arg + ".", text);
		}

		protected static Exception ErrorNotANumber(string p_arg)
		{
			return new Exception("Invalid argument: " + p_arg + " is not a number!");
		}

		protected static string Lower(ref string arg)
		{
			arg = arg.ToLowerInvariant();
			return arg;
		}

		protected bool TryParseInt(string text, out int outValue)
		{
			return int.TryParse(text, out outValue);
		}

		protected bool TryParseBool(string text, out bool outValue)
		{
			return bool.TryParse(text, out outValue);
		}
	}
}
