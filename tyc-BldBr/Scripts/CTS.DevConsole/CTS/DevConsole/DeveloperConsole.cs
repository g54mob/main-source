using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using CTS.Core;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace CTS.DevConsole
{
	[DefaultExecutionOrder(-10)]
	public class DeveloperConsole : CTSPersistentSingleton<DeveloperConsole>
	{
		public enum EColor
		{
			White = 0,
			Black = 1,
			Red = 2,
			Yellow = 3,
			Green = 4,
			Blue = 5
		}

		public struct InputReport
		{
			public EValidity Validity;

			public ConsoleCommand FoundCommand;

			public List<string> CommandArgMatches;

			public List<string> CommandHelpers;

			public string FullValidInput;

			public string ErrorMessage;

			public List<string> Arguments;

			public List<object> CastedArguments;

			public bool HasFoundCommand => FoundCommand != null;

			public List<string> CommandMatches { get; set; }

			public bool HasMatches
			{
				get
				{
					if (CommandMatches != null)
					{
						return CommandMatches.Count > 0;
					}
					return false;
				}
			}

			public void AddArgMatchWithLimit(string match, int max)
			{
				if (CommandArgMatches != null && CommandArgMatches.Count < max)
				{
					CommandArgMatches.Add(match);
				}
			}
		}

		[SerializeField]
		private int _maxLogs = 20;

		[SerializeField]
		private bool _autocompleteByContains = true;

		[SerializeField]
		private ObjectPicker _objectPicker;

		[SerializeField]
		private LogObject _logPrefab;

		private readonly SortedDictionary<string, ConsoleCommand> _commands = new SortedDictionary<string, ConsoleCommand>();

		private bool _areInputsLocked;

		private Scrollbar _scrollBar;

		private Transform _logsContentParent;

		private static readonly Dictionary<EColor, string> Colors = new Dictionary<EColor, string>
		{
			{
				EColor.White,
				"#ffffffff"
			},
			{
				EColor.Black,
				"#000000ff"
			},
			{
				EColor.Red,
				"#ff0000ff"
			},
			{
				EColor.Yellow,
				"#ffff00ff"
			},
			{
				EColor.Green,
				"#00ff00ff"
			},
			{
				EColor.Blue,
				"#0000ffff"
			}
		};

		private readonly Queue<LogObject> _logs = new Queue<LogObject>();

		private LogObject _lastLog;

		public IEnumerable<KeyValuePair<string, ConsoleCommand>> Commands => _commands;

		public static bool IsOpen
		{
			get
			{
				if (CTSSingleton<DeveloperConsole>.InstanceExists())
				{
					return CTSSingleton<DeveloperConsole>.Instance.enabled;
				}
				return false;
			}
		}

		public event Action<string> OnInputSubmit;

		public static event Action<bool> OnConsoleOpen;

		protected override void SingletonAwake()
		{
			ScrollRect componentInChildren = GetComponentInChildren<ScrollRect>();
			_scrollBar = componentInChildren.GetComponentInChildren<Scrollbar>();
			_logsContentParent = componentInChildren.content;
			RegisterAllCommands();
			LogListeningRegister();
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			DeveloperConsole.OnConsoleOpen?.Invoke(obj: true);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			DeveloperConsole.OnConsoleOpen?.Invoke(obj: false);
		}

		protected override void OnSingletonDestroy()
		{
			LogListeningUnregister();
		}

		private void LogListeningRegister()
		{
			Application.logMessageReceived -= OnLogReceived;
			Application.logMessageReceived += OnLogReceived;
		}

		private void LogListeningUnregister()
		{
			Application.logMessageReceived -= OnLogReceived;
		}

		private void RegisterAllCommands()
		{
			Dictionary<Type, List<ConsoleCommand>> dictionary = new Dictionary<Type, List<ConsoleCommand>>();
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			for (int i = 0; i < assemblies.Length; i++)
			{
				Type[] types = assemblies[i].GetTypes();
				foreach (Type type in types)
				{
					if (type.IsSubclassOf(typeof(ConsoleCommand)) && !type.IsAbstract)
					{
						if (typeof(ISubCommand).IsAssignableFrom(type))
						{
							RegisterSubCommand(type, dictionary);
						}
						else
						{
							RegisterCommand(type);
						}
					}
				}
			}
			foreach (ConsoleCommand value in _commands.Values)
			{
				value.TryRegisterSubCommands(dictionary);
			}
			if (dictionary.Count <= 0)
			{
				return;
			}
			string text = dictionary.Values.Aggregate("", (string current, List<ConsoleCommand> commandList) => current + commandList.Aggregate("", (string currentAgg, ConsoleCommand command) => currentAgg + command.Command + " | "));
			LogWarning("Couldn't register commands: " + text.Substring(0, text.Length - 3));
			void RegisterCommand(Type type2)
			{
				ConsoleCommand consoleCommand = (ConsoleCommand)Activator.CreateInstance(type2);
				string key = consoleCommand.Command.ToLowerInvariant();
				if (!_commands.ContainsKey(key))
				{
					_commands.Add(key, consoleCommand);
				}
			}
			static void RegisterSubCommand(Type type3, IDictionary<Type, List<ConsoleCommand>> subCommands)
			{
				Type type2 = null;
				Type[] interfaces = type3.GetInterfaces();
				foreach (Type type4 in interfaces)
				{
					if (type4.IsSubclassOfRawGeneric(typeof(ISubCommand<>)))
					{
						type2 = type4.GenericTypeArguments[0];
						break;
					}
				}
				if ((object)type2 != null)
				{
					ConsoleCommand item = (ConsoleCommand)Activator.CreateInstance(type3);
					if (!subCommands.ContainsKey(type2))
					{
						subCommands.Add(type2, new List<ConsoleCommand>());
					}
					subCommands[type2].Add(item);
				}
			}
		}

		public static void ExecuteCommand(string command)
		{
			CTSSingleton<DeveloperConsole>.Instance.ProcessCommand(command);
		}

		public static void ExecuteCommand<TCommand>(params string[] arguments) where TCommand : ConsoleCommand
		{
			CTSSingleton<DeveloperConsole>.Instance.ExecuteCommandInternal<TCommand>(arguments ?? Array.Empty<string>());
		}

		private void ExecuteCommandInternal<TCommand>(string[] arguments) where TCommand : ConsoleCommand
		{
			if (TryFindCommand(_commands.Values, out var outCommand))
			{
				string text = "/";
				List<string> list = new List<string>();
				ConsoleCommand consoleCommand = outCommand;
				do
				{
					list.Add(consoleCommand.Command);
					consoleCommand = consoleCommand.BaseCommand;
				}
				while (consoleCommand != null);
				for (int num = list.Count - 1; num >= 0; num--)
				{
					text = text + list[num] + " ";
				}
				foreach (string text2 in arguments)
				{
					text = text + text2 + " ";
				}
				Debug.Log(text);
				ProcessCommand(text);
			}
			else
			{
				Debug.LogError("Command " + typeof(TCommand).Name + " not found");
			}
			static bool TryFindCommand(ICollection<ConsoleCommand> commandList, out TCommand reference)
			{
				foreach (ConsoleCommand command in commandList)
				{
					if (command is TCommand val)
					{
						reference = val;
						return true;
					}
					if (command.HasSubCommands && TryFindCommand(command.SubCommands.Values, out reference))
					{
						return true;
					}
				}
				reference = null;
				return false;
			}
		}

		internal void ProcessCommand(string inputString)
		{
			inputString = inputString.TrimEnd();
			this.OnInputSubmit?.Invoke(inputString);
			InputReport report = CheckValidityOfInput(inputString);
			if (report.HasFoundCommand)
			{
				report.FoundCommand.Run(report);
			}
			else
			{
				LogError("command '" + inputString + "' doesn't exist");
			}
		}

		internal static bool TryGetSelectedObject(Type type, out Component outComponent, bool searchIfNothingFound)
		{
			if (!CTSSingleton<DeveloperConsole>.Instance._objectPicker)
			{
				outComponent = null;
				Debug.LogError("No Object Picker referenced in Dev Console");
				return false;
			}
			return CTSSingleton<DeveloperConsole>.Instance._objectPicker.TryGetSelectedObject(type, out outComponent, searchIfNothingFound);
		}

		public InputReport CheckValidityOfInput(string input)
		{
			InputReport inputReport = default(InputReport);
			if (!input.StartsWith('/'))
			{
				inputReport.Validity = EValidity.Empty;
				inputReport.ErrorMessage = "No command found.";
				return inputReport;
			}
			inputReport.FullValidInput = "/";
			List<string> list = input.Split(' ').MergeQuotes(' ').ToList();
			list[0] = list[0].Remove(0, 1);
			TryFindCommand(out var outCommand, _commands, list);
			inputReport.FoundCommand = outCommand;
			if (inputReport.HasFoundCommand)
			{
				if (inputReport.FoundCommand.IsSubCommand)
				{
					inputReport.FoundCommand.CheckValidityOfArguments(ref inputReport, list);
				}
				else if (list.Count <= 0)
				{
					inputReport.CommandMatches = GetAllMainCommandsContaining(inputReport.FoundCommand.Command);
					inputReport.Validity = (inputReport.FoundCommand.CanHaveNoArguments ? EValidity.Valid : EValidity.Incomplete);
					inputReport.ErrorMessage = "Missing arguments.";
				}
				else
				{
					inputReport.FoundCommand.CheckValidityOfArguments(ref inputReport, list);
				}
			}
			else
			{
				int count = list.Count;
				if (count == 0 || count > 1)
				{
					inputReport.Validity = EValidity.Invalid;
					inputReport.ErrorMessage = "No command found.";
				}
				else
				{
					inputReport.CommandMatches = GetAllMainCommandsContaining(list[0]);
					inputReport.Validity = ((!inputReport.HasMatches) ? EValidity.Invalid : EValidity.Incomplete);
					inputReport.ErrorMessage = (inputReport.HasMatches ? "Command incomplete." : "No command found.");
				}
			}
			return inputReport;
			List<string> GetAllMainCommandsContaining(string arg)
			{
				List<string> list2 = new List<string>();
				arg = arg.ToLowerInvariant();
				foreach (var (parent, consoleCommand2) in _commands)
				{
					if (ArgIsContainedIn(arg, parent, caseSensitive: false))
					{
						list2.Add(consoleCommand2.Command);
					}
				}
				if (list2.Count > 0)
				{
					return list2;
				}
				return null;
			}
			bool TryFindCommand(out ConsoleCommand reference, IDictionary<string, ConsoleCommand> commandList, IList<string> args)
			{
				reference = null;
				if (args.Count <= 0)
				{
					return false;
				}
				string key = args[0].ToLowerInvariant();
				if (commandList.ContainsKey(key))
				{
					reference = commandList[key];
					args.RemoveAt(0);
					if (args.Count > 0)
					{
						ref string fullValidInput = ref inputReport.FullValidInput;
						fullValidInput = fullValidInput + reference.Command + " ";
					}
					if (reference.SubCommands != null && TryFindCommand(out var outCommand2, reference.SubCommands, args))
					{
						reference = outCommand2;
					}
					return true;
				}
				reference = null;
				return false;
			}
		}

		public static bool ArgIsContainedIn(string arg, string parent, bool caseSensitive)
		{
			if (!caseSensitive)
			{
				parent = parent.ToLowerInvariant();
				arg = arg.ToLowerInvariant();
			}
			if (CTSSingleton<DeveloperConsole>.Instance._autocompleteByContains)
			{
				return parent.Contains(arg);
			}
			return parent.StartsWith(arg);
		}

		private void OnLogReceived(string p_message, string p_stack, LogType p_logType)
		{
			switch (p_logType)
			{
			case LogType.Error:
			case LogType.Exception:
				LogToConsole(p_message, EColor.Red, p_stack);
				break;
			case LogType.Assert:
				LogToConsole(p_message, EColor.Blue, p_stack);
				break;
			case LogType.Warning:
				LogToConsole(p_message, EColor.Yellow, p_stack);
				break;
			default:
				LogToConsole(p_message, EColor.White, p_stack);
				break;
			}
		}

		public static void Log(ReadOnlySpan<char> p_message, [CanBeNull] string p_desc = null)
		{
			Log(p_message.ToString(), p_desc);
		}

		public static void Log(string p_message, [CanBeNull] string p_desc = null)
		{
			CTSSingleton<DeveloperConsole>.Instance.InstanceLog(p_message, p_desc);
		}

		private void InstanceLog(string p_message, [CanBeNull] string p_desc)
		{
			LogListeningUnregister();
			LogToConsole(p_message, EColor.White, p_desc);
			Debug.Log(p_message);
			LogListeningRegister();
		}

		public static void LogError(ReadOnlySpan<char> p_message, [CanBeNull] string p_desc = null)
		{
			LogError(p_message.ToString(), p_desc);
		}

		public static void LogError(string p_message, [CanBeNull] string p_desc = null)
		{
			CTSSingleton<DeveloperConsole>.Instance.InstanceLogError(p_message, p_desc);
		}

		private void InstanceLogError(string p_message, [CanBeNull] string p_desc)
		{
			LogListeningUnregister();
			LogToConsole(p_message, EColor.Red, p_desc);
			Debug.LogError(p_message);
			LogListeningRegister();
		}

		public static void LogException(Exception exception)
		{
			CTSSingleton<DeveloperConsole>.Instance.InstanceLogException(exception);
		}

		private void InstanceLogException(Exception exception)
		{
			LogListeningUnregister();
			string p_string = Regex.Replace(exception.Message, "\\r\\n?|\\n", " / ");
			LogToConsole(p_string, EColor.Red, exception.StackTrace);
			Debug.LogException(exception);
			LogListeningRegister();
		}

		public static void LogWarning(ReadOnlySpan<char> p_message, [CanBeNull] string p_desc = null)
		{
			LogWarning(p_message.ToString(), p_desc);
		}

		public static void LogWarning(string p_message, [CanBeNull] string p_desc = null)
		{
			CTSSingleton<DeveloperConsole>.Instance.InstanceLogWarning(p_message, p_desc);
		}

		private void InstanceLogWarning(string p_message, [CanBeNull] string p_desc)
		{
			LogListeningUnregister();
			LogToConsole(p_message, EColor.Yellow, p_desc);
			Debug.LogWarning(p_message);
			LogListeningRegister();
		}

		public static void NewLine()
		{
		}

		private void LogToConsole(string p_string, EColor p_color, [CanBeNull] string p_desc)
		{
			string text = "<color=" + Colors[p_color] + ">" + p_string + "</color>\n";
			LogObject logObject = ((_logs.Count < _maxLogs) ? UnityEngine.Object.Instantiate(_logPrefab, _logsContentParent) : _logs.Dequeue());
			_logs.Enqueue(logObject);
			logObject.transform.SetSiblingIndex(0);
			if (p_desc != null)
			{
				logObject.SetTextWithStack(text, p_desc.TrimEnd());
			}
			else
			{
				logObject.SetText(text);
			}
			_lastLog = logObject;
			if (base.enabled)
			{
				_scrollBar.value = 1f;
			}
		}

		public static void OpenLastLog()
		{
			if (CTSSingleton<DeveloperConsole>.InstanceExists() && (bool)CTSSingleton<DeveloperConsole>.Instance._lastLog)
			{
				CTSSingleton<DeveloperConsole>.Instance._lastLog.SetToggleOn(value: true);
			}
		}
	}
}
