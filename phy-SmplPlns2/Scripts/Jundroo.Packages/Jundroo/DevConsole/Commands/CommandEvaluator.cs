using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Jundroo.DevConsole.Commands.Arguments;
using UnityEngine;

namespace Jundroo.DevConsole.Commands
{
	internal static class CommandEvaluator
	{
		private abstract class ArgumentParserRegistration
		{
			public abstract string HelpMessage { get; }

			public abstract int Priority { get; }

			public abstract Type Type { get; }

			public abstract bool TryParse(string value, out object result);
		}

		private class ArgumentParserRegistration<T> : ArgumentParserRegistration
		{
			private IArgumentParser<T> _parser;

			public override string HelpMessage => _parser.HelpMessage;

			public override int Priority => _parser.Priority;

			public override Type Type => typeof(T);

			public ArgumentParserRegistration(IArgumentParser<T> parser)
			{
				_parser = parser;
			}

			public override bool TryParse(string value, out object result)
			{
				T result3;
				bool result2 = _parser.TryParse(value, out result3);
				result = result3;
				return result2;
			}
		}

		private class ArgumentParserResults
		{
			public object Argument { get; private set; }

			public List<string> HelpMessages { get; private set; }

			public bool ParsedSuccessfully { get; private set; }

			public int RegisteredParserCount { get; private set; }

			public ArgumentParserResults(object argument, int parserCount)
			{
				Argument = argument;
				RegisteredParserCount = parserCount;
				ParsedSuccessfully = true;
				HelpMessages = new List<string>();
			}

			public ArgumentParserResults(int parserCount, IEnumerable<string> helpMessages)
			{
				Argument = null;
				RegisteredParserCount = parserCount;
				ParsedSuccessfully = false;
				HelpMessages = ((helpMessages == null) ? new List<string>() : new List<string>(helpMessages));
			}
		}

		public const bool HiddenObjectsAccesible = false;

		private static BindingFlags _allMembersBindingFlags;

		private static Dictionary<Type, List<ArgumentParserRegistration>> _argumentParserRegistrations;

		private static Dictionary<string, Delegate> _commandRegistrations;

		public static List<RegisteredCommandInfo> RegisteredCommands => _commandRegistrations.Select((KeyValuePair<string, Delegate> x) => new RegisteredCommandInfo(x.Key, x.Value)).ToList();

		static CommandEvaluator()
		{
			_allMembersBindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
			_commandRegistrations = new Dictionary<string, Delegate>();
			_argumentParserRegistrations = new Dictionary<Type, List<ArgumentParserRegistration>>();
			RegisterArgumentParser(new BoolArgumentParser());
			RegisterArgumentParser(new BoundsArgumentParser());
			RegisterArgumentParser(new ByteArgumentParser());
			RegisterArgumentParser(new CharArgumentParser());
			RegisterArgumentParser(new Color32ArgumentParser());
			RegisterArgumentParser(new ColorArgumentParser());
			RegisterArgumentParser(new DateTimeArgumentParser());
			RegisterArgumentParser(new DecimalArgumentParser());
			RegisterArgumentParser(new DoubleArgumentParser());
			RegisterArgumentParser(new GuidArgumentParser());
			RegisterArgumentParser(new Int16ArgumentParser());
			RegisterArgumentParser(new Int32ArgumentParser());
			RegisterArgumentParser(new Int64ArgumentParser());
			RegisterArgumentParser(new QuaternionArgumentParser());
			RegisterArgumentParser(new RectArgumentParser());
			RegisterArgumentParser(new RectOffsetArgumentParser());
			RegisterArgumentParser(new SingleArgumentParser());
			RegisterArgumentParser(new StringArgumentParser());
			RegisterArgumentParser(new TimeSpanArgumentParser());
			RegisterArgumentParser(new UInt16ArgumentParser());
			RegisterArgumentParser(new UInt32ArgumentParser());
			RegisterArgumentParser(new UInt64ArgumentParser());
			RegisterArgumentParser(new Vector2ArgumentParser());
			RegisterArgumentParser(new Vector3ArgumentParser());
			RegisterArgumentParser(new Vector4ArgumentParser());
		}

		public static void Evaluate(ConsoleCommand command)
		{
			for (int i = 0; i < command.CommandSegments.Count; i++)
			{
				ConsoleCommandSegment consoleCommandSegment = command.CommandSegments[i];
				ConsoleCommandSegment previousCommand = ((i > 0) ? command.CommandSegments[i - 1] : null);
				if (consoleCommandSegment.Evaluated)
				{
					continue;
				}
				switch (consoleCommandSegment.CommandType)
				{
				case ConsoleCommandSegmentType.FindChildGameObjects:
					EvaluateFindChildGameObjects((GameObjectListCommandSegment)consoleCommandSegment, previousCommand);
					consoleCommandSegment.Evaluated = true;
					break;
				case ConsoleCommandSegmentType.FindAllChildGameObjects:
					EvaluateFindAllChildGameObjects((GameObjectListCommandSegment)consoleCommandSegment, previousCommand);
					consoleCommandSegment.Evaluated = true;
					break;
				case ConsoleCommandSegmentType.FindChildComponents:
					EvaluateFindChildComponents((ComponentListCommandSegment)consoleCommandSegment, previousCommand);
					consoleCommandSegment.Evaluated = true;
					break;
				case ConsoleCommandSegmentType.FindAllChildComponents:
					EvaluateFindAllChildComponents((ComponentListCommandSegment)consoleCommandSegment, previousCommand);
					consoleCommandSegment.Evaluated = true;
					break;
				case ConsoleCommandSegmentType.FindMembers:
					EvaluateFindMembers((MemberListCommandSegment)consoleCommandSegment, previousCommand);
					consoleCommandSegment.Evaluated = true;
					break;
				case ConsoleCommandSegmentType.FindAllMembers:
					EvaluateFindAllMembers((MemberListCommandSegment)consoleCommandSegment, previousCommand);
					consoleCommandSegment.Evaluated = true;
					break;
				case ConsoleCommandSegmentType.GameObjectSelector:
					if (i < command.CommandSegments.Count - 1)
					{
						EvaluateGameObjectSelector((GameObjectCommandSegment)consoleCommandSegment, previousCommand);
						consoleCommandSegment.Evaluated = true;
					}
					break;
				case ConsoleCommandSegmentType.ComponentSelector:
					if (i < command.CommandSegments.Count - 1)
					{
						EvaluateComponentSelector((ComponentCommandSegment)consoleCommandSegment, previousCommand);
						consoleCommandSegment.Evaluated = true;
					}
					break;
				case ConsoleCommandSegmentType.MemberSelector:
					if (i < command.CommandSegments.Count - 1)
					{
						EvaluateMemberSelector((MemberCommandSegment)consoleCommandSegment, previousCommand);
						consoleCommandSegment.Evaluated = true;
					}
					break;
				}
			}
		}

		public static List<LogEntry> Execute(ConsoleCommand command)
		{
			List<LogEntry> list = null;
			Evaluate(command);
			bool flag = false;
			List<string> list2 = new List<string>();
			ConsoleCommandSegment consoleCommandSegment = null;
			for (int num = command.CommandSegments.Count - 1; num >= 0 && !flag; num--)
			{
				ConsoleCommandSegment consoleCommandSegment2 = command.CommandSegments[num];
				switch (consoleCommandSegment2.CommandType)
				{
				case ConsoleCommandSegmentType.Command:
					flag = true;
					break;
				case ConsoleCommandSegmentType.MemberSelector:
					flag = ((MemberCommandSegment)consoleCommandSegment2).Member != null && num - 2 >= 0 && ConsoleCommandSegment.GetObject(command.CommandSegments[num - 2]) != null;
					break;
				case ConsoleCommandSegmentType.GameObjectSelector:
					flag = ((GameObjectCommandSegment)consoleCommandSegment2).GameObject != null;
					break;
				case ConsoleCommandSegmentType.ComponentSelector:
					flag = ((ComponentCommandSegment)consoleCommandSegment2).Component != null;
					break;
				case ConsoleCommandSegmentType.FindAllChildGameObjects:
				case ConsoleCommandSegmentType.FindChildGameObjects:
					flag = ((GameObjectListCommandSegment)consoleCommandSegment2).GameObjects != null;
					break;
				case ConsoleCommandSegmentType.FindChildComponents:
				case ConsoleCommandSegmentType.FindAllChildComponents:
					flag = ((ComponentListCommandSegment)consoleCommandSegment2).Components != null;
					break;
				case ConsoleCommandSegmentType.FindMembers:
				case ConsoleCommandSegmentType.FindAllMembers:
					flag = ((MemberListCommandSegment)consoleCommandSegment2).Members != null;
					break;
				case ConsoleCommandSegmentType.Argument:
					list2.Insert(0, consoleCommandSegment2.CommandText);
					continue;
				}
				if (consoleCommandSegment == null || !flag)
				{
					consoleCommandSegment = consoleCommandSegment2;
				}
			}
			if (consoleCommandSegment == null)
			{
				list = new List<LogEntry>();
				list.Add(new LogEntry($"Unable to execute command: {command.ToString()}", string.Empty, LogType.Error));
			}
			else
			{
				list = Execute(command, consoleCommandSegment, list2);
			}
			return list ?? new List<LogEntry>();
		}

		public static void RegisterArgumentParser<T>(IArgumentParser<T> parser)
		{
			if (!_argumentParserRegistrations.TryGetValue(typeof(T), out var value))
			{
				value = new List<ArgumentParserRegistration>();
			}
			value.Add(new ArgumentParserRegistration<T>(parser));
			_argumentParserRegistrations[typeof(T)] = value.OrderBy((ArgumentParserRegistration x) => x.Priority).ToList();
		}

		public static void RegisterCommand(string command, Delegate commandAction)
		{
			_commandRegistrations[command] = commandAction;
		}

		public static void UnregisterCommand(string command)
		{
			if (_commandRegistrations.ContainsKey(command))
			{
				_commandRegistrations.Remove(command);
			}
		}

		private static void EvaluateComponentSelector(ComponentCommandSegment command, ConsoleCommandSegment previousCommand)
		{
			List<Component> componentList = ConsoleCommandSegment.GetComponentList(previousCommand);
			if (componentList != null)
			{
				command.Component = componentList.FirstOrDefault((Component x) => x != null && x.GetType().Name.ToLower() == command.CommandText.ToLower());
			}
		}

		private static void EvaluateFindAllChildComponents(ComponentListCommandSegment command, ConsoleCommandSegment previousCommand)
		{
			GameObject gameObject = ConsoleCommandSegment.GetGameObject(previousCommand);
			if (gameObject == null)
			{
				if (previousCommand == null)
				{
					command.Components = (from x in UnityEngine.Object.FindObjectsByType<Component>(FindObjectsSortMode.None)
						where !IsComponentHidden(x)
						select x).ToList();
				}
			}
			else
			{
				command.Components = (from x in gameObject.GetComponentsInChildren<Component>(includeInactive: true)
					where !IsComponentHidden(x)
					select x).ToList();
			}
		}

		private static void EvaluateFindAllChildGameObjects(GameObjectListCommandSegment command, ConsoleCommandSegment previousCommand)
		{
			GameObject gameObject = ConsoleCommandSegment.GetGameObject(previousCommand);
			if (gameObject == null)
			{
				if (previousCommand == null)
				{
					command.GameObjects = (from x in UnityEngine.Object.FindObjectsByType<GameObject>(FindObjectsSortMode.None)
						where !IsGameObjectHidden(x)
						select x).ToList();
				}
			}
			else
			{
				command.GameObjects = (from t in gameObject.GetComponentsInChildren<Transform>(includeInactive: true)
					where !IsGameObjectHidden(t.gameObject)
					select t.gameObject).ToList();
			}
		}

		private static void EvaluateFindAllMembers(MemberListCommandSegment command, ConsoleCommandSegment previousCommand)
		{
			UnityEngine.Object obj = ConsoleCommandSegment.GetObject(previousCommand);
			if (obj != null)
			{
				BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
				MemberTypes memberTypes = MemberTypes.Field | MemberTypes.Method | MemberTypes.Property;
				command.Members = (from x in obj.GetType().GetMembers(bindingAttr)
					where (x.MemberType & memberTypes) != 0
					select x).ToList();
			}
			else
			{
				command.Members = new List<MemberInfo>();
			}
		}

		private static void EvaluateFindChildComponents(ComponentListCommandSegment command, ConsoleCommandSegment previousCommand)
		{
			GameObject gameObject = ConsoleCommandSegment.GetGameObject(previousCommand);
			if (gameObject == null)
			{
				if (previousCommand == null)
				{
					command.Components = (from x in UnityEngine.Object.FindObjectsByType<Component>(FindObjectsSortMode.None)
						where x.gameObject.transform.parent == null && !IsComponentHidden(x)
						select x).ToList();
				}
			}
			else
			{
				command.Components = (from x in gameObject.GetComponents<Component>()
					where !IsComponentHidden(x)
					select x).ToList();
			}
		}

		private static void EvaluateFindChildGameObjects(GameObjectListCommandSegment command, ConsoleCommandSegment previousCommand)
		{
			GameObject gameObject = ConsoleCommandSegment.GetGameObject(previousCommand);
			if (gameObject == null)
			{
				if (previousCommand == null)
				{
					command.GameObjects = (from t in UnityEngine.Object.FindObjectsByType<Transform>(FindObjectsSortMode.None)
						where t.parent == null && !IsGameObjectHidden(t.gameObject)
						select t.gameObject).ToList();
				}
				return;
			}
			command.GameObjects = new List<GameObject>();
			foreach (Transform item in gameObject.transform)
			{
				if (!IsGameObjectHidden(item.gameObject))
				{
					command.GameObjects.Add(item.gameObject);
				}
			}
		}

		private static void EvaluateFindMembers(MemberListCommandSegment command, ConsoleCommandSegment previousCommand)
		{
			UnityEngine.Object obj = ConsoleCommandSegment.GetObject(previousCommand);
			if (obj != null)
			{
				BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy;
				MemberTypes memberTypes = MemberTypes.Field | MemberTypes.Method | MemberTypes.Property;
				command.Members = (from x in obj.GetType().GetMembers(bindingAttr)
					where (x.MemberType & memberTypes) != 0
					select x).ToList();
			}
			else
			{
				command.Members = new List<MemberInfo>();
			}
		}

		private static void EvaluateGameObjectSelector(GameObjectCommandSegment command, ConsoleCommandSegment previousCommand)
		{
			List<GameObject> gameObjectList = ConsoleCommandSegment.GetGameObjectList(previousCommand);
			if (gameObjectList != null)
			{
				command.GameObject = gameObjectList.FirstOrDefault((GameObject x) => x != null && x.name.ToLower() == command.CommandText.ToLower());
			}
		}

		private static void EvaluateMemberSelector(MemberCommandSegment command, ConsoleCommandSegment previousCommand)
		{
			List<MemberInfo> memberList = ConsoleCommandSegment.GetMemberList(previousCommand);
			if (memberList != null)
			{
				command.Member = memberList.FirstOrDefault((MemberInfo x) => x.Name.ToLower() == command.CommandText.ToLower());
			}
		}

		private static List<LogEntry> Execute(ConsoleCommand command, ConsoleCommandSegment commandSegment, List<string> arguments)
		{
			switch (commandSegment.CommandType)
			{
			case ConsoleCommandSegmentType.Argument:
				return ExecuteArgument(command, commandSegment);
			case ConsoleCommandSegmentType.Command:
				return ExecuteCommand(command, commandSegment, arguments);
			case ConsoleCommandSegmentType.MemberSelector:
				return ExecuteMemberSelector(command, (MemberCommandSegment)commandSegment, arguments);
			case ConsoleCommandSegmentType.GameObjectSelector:
				return ExecuteGameObjectSelector(command, (GameObjectCommandSegment)commandSegment);
			case ConsoleCommandSegmentType.ComponentSelector:
				return ExecuteComponentSelector(command, (ComponentCommandSegment)commandSegment);
			case ConsoleCommandSegmentType.FindAllChildGameObjects:
			case ConsoleCommandSegmentType.FindChildGameObjects:
				return ExecuteFindGameObjects(command, (GameObjectListCommandSegment)commandSegment);
			case ConsoleCommandSegmentType.FindChildComponents:
			case ConsoleCommandSegmentType.FindAllChildComponents:
				return ExecuteFindComponents(command, (ComponentListCommandSegment)commandSegment);
			case ConsoleCommandSegmentType.FindMembers:
			case ConsoleCommandSegmentType.FindAllMembers:
				return ExecuteFindMembers(command, (MemberListCommandSegment)commandSegment);
			case ConsoleCommandSegmentType.Unknown:
				return ExecuteUnknown(command, commandSegment);
			default:
				return ExecuteUnknown(command, commandSegment);
			}
		}

		private static List<LogEntry> ExecuteArgument(ConsoleCommand command, ConsoleCommandSegment commandSegment)
		{
			return new List<LogEntry>
			{
				new LogEntry("Unable to execute command: " + command.ToString(), null, LogType.Error)
			};
		}

		private static List<LogEntry> ExecuteCommand(ConsoleCommand command, ConsoleCommandSegment commandSegment, List<string> arguments)
		{
			List<LogEntry> list = new List<LogEntry>();
			try
			{
				if (!_commandRegistrations.TryGetValue(commandSegment.CommandText, out var value))
				{
					list.Add(new LogEntry($"Command '{commandSegment.CommandText}' not found.", null, LogType.Error));
					return list;
				}
				ParameterInfo[] parameters = value.Method.GetParameters();
				if (parameters.Length != arguments.Count)
				{
					string message = string.Format("Wrong number of arguments specified. {0} arguments were specified when {1} were expected for command '{2}' {3}.", arguments.Count, parameters.Length, commandSegment.CommandText, string.Join(" ", parameters.Select((ParameterInfo x) => "[" + x.ParameterType.Name + "]").ToArray()));
					list.Add(new LogEntry(message, "Console command executed: " + command.ToString(), LogType.Error));
					return list;
				}
				object[] array = new object[arguments.Count];
				for (int num = 0; num < arguments.Count; num++)
				{
					ArgumentParserResults argumentParserResults = ParseArgument(arguments[num], parameters[num].ParameterType);
					if (!argumentParserResults.ParsedSuccessfully)
					{
						string text = string.Format("Unable to parse the argument '{0}' to type '{1}' for argument #{2} of command '{3}' {4}.", arguments[num], parameters[num].ParameterType.Name, num + 1, commandSegment.CommandText, string.Join(" ", parameters.Select((ParameterInfo x) => "[" + x.ParameterType.Name + "]").ToArray()));
						if (argumentParserResults.RegisteredParserCount == 0)
						{
							text += $" No argument parsers were registered for type '{parameters[num].ParameterType.Name}'";
						}
						string text2 = string.Empty;
						if (argumentParserResults.HelpMessages.Count > 0)
						{
							text2 = $"See the following suggestions to help in the formatting of your argument: {Environment.NewLine}{string.Join(Environment.NewLine, argumentParserResults.HelpMessages.ToArray())}";
						}
						text2 = text2 + (string.IsNullOrEmpty(text2) ? string.Empty : Environment.NewLine) + "Console command executed: " + command.ToString();
						list.Add(new LogEntry(text, text2, LogType.Error));
						return list;
					}
					array[num] = argumentParserResults.Argument;
				}
				object obj = value.DynamicInvoke(array);
				string text3 = string.Empty;
				for (int num2 = 0; num2 < arguments.Count; num2++)
				{
					text3 += $" [{parameters[num2].ParameterType.Name}]\"{arguments[num2]}\"";
				}
				string text4 = $"Invoked command '{commandSegment.CommandText}'{text3}.";
				if (value.Method.ReturnType != typeof(void))
				{
					text4 = text4 + " Returned result: " + ((obj == null) ? "null" : obj.ToString());
				}
				list.Add(new LogEntry(text4, "Console command executed: " + command.ToString(), LogType.Log));
			}
			catch (Exception ex)
			{
				string message2 = $"{((ex.GetType() == typeof(TargetInvocationException) && ex.InnerException != null) ? ex.InnerException.Message : ex.Message)}{Environment.NewLine}Error invoking command: {command.ToString()}";
				list.Add(new LogEntry(message2, ex.ToString(), LogType.Error));
			}
			return list;
		}

		private static List<LogEntry> ExecuteComponentSelector(ConsoleCommand command, ComponentCommandSegment commandSegment)
		{
			List<LogEntry> list = new List<LogEntry>();
			if (commandSegment.Component == null)
			{
				string message = $"Unable to find component '{commandSegment.CommandText}' at: {command.ToString(command.CommandSegments.IndexOf(commandSegment) + 1)}";
				list.Add(new LogEntry(message, "Console command executed: " + command.ToString(), LogType.Error));
			}
			else
			{
				string text = "/" + commandSegment.Component.gameObject.name;
				Transform transform = commandSegment.Component.gameObject.transform;
				while ((transform = transform.transform.parent) != null)
				{
					text = "/" + transform.gameObject.name + text;
				}
				string message2 = $"{commandSegment.Component.GetType().FullName}  Path: {text}";
				list.Add(new LogEntry(message2, null, LogType.Log));
			}
			return list;
		}

		private static void ExecuteFieldOrPropertyCommand(object objectInstance, MemberInfo member, List<string> arguments, string fullCommand, List<LogEntry> logEntries)
		{
			if (arguments.Count > 1)
			{
				string message = string.Format("Too many arguments specified. Setting a {0} requires 1 argument be specified, however {1} arguments were detected.", (member.MemberType == MemberTypes.Property) ? "property" : "field", arguments.Count);
				logEntries.Add(new LogEntry(message, "Console command executed: " + fullCommand, LogType.Error));
			}
			else if (arguments.Count == 1)
			{
				SetFieldOrProperty(objectInstance, member, arguments[0], fullCommand, logEntries);
			}
			else
			{
				GetFieldOrProperty(objectInstance, member, fullCommand, logEntries);
			}
		}

		private static List<LogEntry> ExecuteFindComponents(ConsoleCommand command, ComponentListCommandSegment commandSegment)
		{
			List<LogEntry> list = new List<LogEntry>();
			List<Component> list2 = commandSegment.Components ?? new List<Component>();
			string message = $"{list2.Count} components found at {command.ToString(command.CommandSegments.IndexOf(commandSegment) + 1)}";
			list.Add(new LogEntry(message, null, LogType.Log));
			return list;
		}

		private static List<LogEntry> ExecuteFindGameObjects(ConsoleCommand command, GameObjectListCommandSegment commandSegment)
		{
			List<LogEntry> list = new List<LogEntry>();
			List<GameObject> list2 = commandSegment.GameObjects ?? new List<GameObject>();
			string message = $"{list2.Count} child game objects found at {command.ToString(command.CommandSegments.IndexOf(commandSegment) + 1)}";
			list.Add(new LogEntry(message, null, LogType.Log));
			return list;
		}

		private static List<LogEntry> ExecuteFindMembers(ConsoleCommand command, MemberListCommandSegment commandSegment)
		{
			List<LogEntry> list = new List<LogEntry>();
			List<MemberInfo> list2 = commandSegment.Members ?? new List<MemberInfo>();
			string message = $"{list2.Count} properties, fields, and methods found at {command.ToString(command.CommandSegments.IndexOf(commandSegment) + 1)}";
			list.Add(new LogEntry(message, null, LogType.Log));
			return list;
		}

		private static List<LogEntry> ExecuteGameObjectSelector(ConsoleCommand command, GameObjectCommandSegment commandSegment)
		{
			List<LogEntry> list = new List<LogEntry>();
			if (commandSegment.GameObject == null)
			{
				string message = $"Unable to find game object '{commandSegment.CommandText}' at: {command.ToString(command.CommandSegments.IndexOf(commandSegment) + 1)}";
				list.Add(new LogEntry(message, "Console command executed: " + command.ToString(), LogType.Error));
			}
			else
			{
				string text = "/" + commandSegment.GameObject.name;
				Transform transform = commandSegment.GameObject.transform;
				while ((transform = transform.transform.parent) != null)
				{
					text = "/" + transform.gameObject.name + text;
				}
				string message2 = $"{commandSegment.GameObject.name}  Path: {text}";
				string messageDetails = string.Format("name: {1} {0}activeSelf: {2} {0}activeInHierarchy: {3} {0}# of components: {4} {0}", Environment.NewLine, commandSegment.GameObject.name, commandSegment.GameObject.activeSelf, commandSegment.GameObject.activeInHierarchy, commandSegment.GameObject.GetComponents<Component>().Length);
				list.Add(new LogEntry(message2, messageDetails, LogType.Log));
			}
			return list;
		}

		private static List<LogEntry> ExecuteMemberSelector(ConsoleCommand command, MemberCommandSegment commandSegment, List<string> arguments)
		{
			List<LogEntry> list = new List<LogEntry>();
			try
			{
				int num = command.CommandSegments.IndexOf(commandSegment) - 2;
				if (num < 0)
				{
					list.Add(new LogEntry("An unexpected error occurred executing command: " + command.ToString(), "Could not find the command segment index associated with the object on which the member is being invoked", LogType.Error));
					return list;
				}
				UnityEngine.Object obj = ConsoleCommandSegment.GetObject(command.CommandSegments[num]);
				if (obj == null)
				{
					list.Add(new LogEntry("An unexpected error occurred executing command: " + command.ToString(), "Could not find the object instance on which the member is being invoked", LogType.Error));
					return list;
				}
				if (commandSegment.Member == null)
				{
					string message = $"Unable to find member '{commandSegment.CommandText}' on object '{obj.name}' of type '{obj.GetType().FullName}'";
					list.Add(new LogEntry(message, "Console command executed: " + command.ToString(), LogType.Error));
					return list;
				}
				if (commandSegment.Member.MemberType == MemberTypes.Method)
				{
					ExecuteMethodCommand(obj, (MethodInfo)commandSegment.Member, arguments, command.ToString(), list);
				}
				else
				{
					ExecuteFieldOrPropertyCommand(obj, commandSegment.Member, arguments, command.ToString(), list);
				}
			}
			catch (Exception ex)
			{
				string message2 = $"{((ex.GetType() == typeof(TargetInvocationException) && ex.InnerException != null) ? ex.InnerException.Message : ex.Message)}{Environment.NewLine}Error invoking command: {command.ToString()}";
				list.Add(new LogEntry(message2, ex.ToString(), LogType.Error));
			}
			return list;
		}

		private static void ExecuteMethodCommand(object objectInstance, MethodInfo method, List<string> arguments, string fullCommand, List<LogEntry> logEntries)
		{
			Type type = objectInstance.GetType();
			ParameterInfo[] parameters = method.GetParameters();
			if (parameters.Length != arguments.Count)
			{
				string message = string.Format("Wrong number of arguments specified. {0} arguments were specified when {1} were expected for method '{2}({3})' on type '{4}'", arguments.Count, parameters.Length, method.Name, string.Join(", ", parameters.Select((ParameterInfo x) => x.ParameterType.Name).ToArray()), type);
				logEntries.Add(new LogEntry(message, "Console command executed: " + fullCommand, LogType.Error));
				return;
			}
			object[] array = new object[arguments.Count];
			for (int num = 0; num < arguments.Count; num++)
			{
				ArgumentParserResults argumentParserResults = ParseArgument(arguments[num], parameters[num].ParameterType);
				if (!argumentParserResults.ParsedSuccessfully)
				{
					string text = string.Format("Unable to parse the argument '{0}' to type '{1}' for argument #{2} of method '{3}({4})' on type '{5}'.", arguments[num], parameters[num].ParameterType.Name, num + 1, method.Name, string.Join(", ", parameters.Select((ParameterInfo x) => x.ParameterType.Name).ToArray()), objectInstance.GetType().FullName);
					if (argumentParserResults.RegisteredParserCount == 0)
					{
						text += $" No argument parsers were registered for type '{parameters[num].ParameterType.Name}'";
					}
					string text2 = string.Empty;
					if (argumentParserResults.HelpMessages.Count > 0)
					{
						text2 = $"See the following suggestions to help in the formatting of your argument: {Environment.NewLine}{string.Join(Environment.NewLine, argumentParserResults.HelpMessages.ToArray())}";
					}
					text2 = text2 + (string.IsNullOrEmpty(text2) ? string.Empty : Environment.NewLine) + "Console command executed: " + fullCommand;
					logEntries.Add(new LogEntry(text, text2, LogType.Error));
					return;
				}
				array[num] = argumentParserResults.Argument;
			}
			object obj = method.Invoke(method.IsStatic ? null : objectInstance, _allMembersBindingFlags, null, array, null);
			string text3 = string.Empty;
			for (int num2 = 0; num2 < arguments.Count; num2++)
			{
				text3 += string.Format("{0}[{1}] \"{2}\"", (num2 == 0) ? string.Empty : ", ", parameters[num2].ParameterType.Name, arguments[num2]);
			}
			string empty = string.Empty;
			string text4 = string.Format(arg2: typeof(Component).IsAssignableFrom(type) ? $"component '{type.Name}' on game object '{((Component)objectInstance).gameObject.name}'" : ((!typeof(GameObject).IsAssignableFrom(type)) ? $"object of type '{type.Name}'" : $"game object '{((GameObject)objectInstance).name}'"), format: "Invoked method '{0}({1}) on {2}.", arg0: method.Name, arg1: text3);
			if (method.ReturnType != typeof(void))
			{
				text4 = text4 + " Returned result: " + ((obj == null) ? "null" : obj.ToString());
			}
			logEntries.Add(new LogEntry(text4, "Console command executed: " + fullCommand, LogType.Log));
		}

		private static List<LogEntry> ExecuteUnknown(ConsoleCommand command, ConsoleCommandSegment commandSegment)
		{
			return new List<LogEntry>
			{
				new LogEntry("Unknown command: " + command.ToString(command.CommandSegments.IndexOf(commandSegment) + 1), "Console command executed: " + command.ToString(), LogType.Error)
			};
		}

		private static void GetFieldOrProperty(object objectInstance, MemberInfo member, string fullCommand, List<LogEntry> logEntries)
		{
			object obj = null;
			if (member.MemberType == MemberTypes.Property)
			{
				PropertyInfo propertyInfo = (PropertyInfo)member;
				MethodInfo getMethod = propertyInfo.GetGetMethod(nonPublic: true);
				if (getMethod == null)
				{
					logEntries.Add(new LogEntry($"The property '{propertyInfo.Name}' on type '{objectInstance.GetType().FullName}' has no getter", "Console command executed: " + fullCommand, LogType.Error));
					return;
				}
				obj = getMethod.Invoke(getMethod.IsStatic ? null : objectInstance, _allMembersBindingFlags, null, new object[0], null);
			}
			else
			{
				FieldInfo obj2 = (FieldInfo)member;
				obj = obj2.GetValue(obj2.IsStatic ? null : objectInstance);
			}
			logEntries.Add(new LogEntry((obj == null) ? "(null)" : obj.ToString(), "Console command executed: " + fullCommand, LogType.Log));
		}

		private static bool IsComponentHidden(Component component)
		{
			if ((component.hideFlags & HideFlags.HideInHierarchy) == HideFlags.HideInHierarchy)
			{
				return (component.gameObject.hideFlags & HideFlags.HideInHierarchy) == HideFlags.HideInHierarchy;
			}
			return false;
		}

		private static bool IsGameObjectHidden(GameObject obj)
		{
			return (obj.hideFlags & HideFlags.HideInHierarchy) == HideFlags.HideInHierarchy;
		}

		private static ArgumentParserResults ParseArgument(string value, Type type)
		{
			if (type.IsValueType)
			{
				Type underlyingType = Nullable.GetUnderlyingType(type);
				if (underlyingType != null)
				{
					if (value.ToLower() == "null")
					{
						return new ArgumentParserResults(null, 1);
					}
					type = underlyingType;
				}
			}
			if (_argumentParserRegistrations.TryGetValue(type, out var value2))
			{
				for (int i = 0; i < value2.Count; i++)
				{
					if (value2[i].TryParse(value, out var result))
					{
						return new ArgumentParserResults(result, value2.Count);
					}
				}
				IEnumerable<string> helpMessages = from x in value2
					select x.HelpMessage into x
					where x != null && x.Trim() != string.Empty
					select x;
				return new ArgumentParserResults(value2.Count, helpMessages);
			}
			if (type.IsEnum)
			{
				try
				{
					return new ArgumentParserResults(Enum.Parse(type, value, ignoreCase: true), 1);
				}
				catch
				{
					return new ArgumentParserResults(1, new string[1] { "The argument must be a string matching one of the enumeration values." });
				}
			}
			return new ArgumentParserResults(0, null);
		}

		private static void SetFieldOrProperty(object objectInstance, MemberInfo member, string argument, string fullCommand, List<LogEntry> logEntries)
		{
			Type type = ((member.MemberType == MemberTypes.Property) ? ((PropertyInfo)member).PropertyType : ((FieldInfo)member).FieldType);
			ArgumentParserResults argumentParserResults = ParseArgument(argument, type);
			if (!argumentParserResults.ParsedSuccessfully)
			{
				string text = string.Format("Unable to parse the argument '{0}' to type '{1}' when attempting to set {2} '{3}' on type '{4}'.", argument, type, (member.MemberType == MemberTypes.Property) ? "property" : "field", member.Name, objectInstance.GetType().FullName);
				if (argumentParserResults.RegisteredParserCount == 0)
				{
					text += $" No argument parsers were registered for type '{type}'";
				}
				string text2 = string.Empty;
				if (argumentParserResults.HelpMessages.Count > 0)
				{
					text2 = $"See the following suggestions to help in the formatting of your argument: {Environment.NewLine}{string.Join(Environment.NewLine, argumentParserResults.HelpMessages.ToArray())}";
				}
				text2 = text2 + (string.IsNullOrEmpty(text2) ? string.Empty : Environment.NewLine) + "Console command executed: " + fullCommand;
				logEntries.Add(new LogEntry(text, text2, LogType.Error));
				return;
			}
			if (member.MemberType == MemberTypes.Property)
			{
				PropertyInfo propertyInfo = (PropertyInfo)member;
				MethodInfo setMethod = propertyInfo.GetSetMethod(nonPublic: true);
				if (setMethod == null)
				{
					logEntries.Add(new LogEntry($"The property '{propertyInfo.Name}' on type '{objectInstance.GetType().FullName}' has no setter", "Console command executed: " + fullCommand, LogType.Error));
					return;
				}
				setMethod.Invoke(setMethod.IsStatic ? null : objectInstance, _allMembersBindingFlags, null, new object[1] { argumentParserResults.Argument }, null);
			}
			else
			{
				FieldInfo obj = (FieldInfo)member;
				obj.SetValue(obj.IsStatic ? null : objectInstance, argumentParserResults.Argument, _allMembersBindingFlags, null, null);
			}
			string text3 = null;
			Type type2 = objectInstance.GetType();
			if (typeof(Component).IsAssignableFrom(type2))
			{
				Component component = (Component)objectInstance;
				text3 = string.Format("{0} '{1}' on component {2} was set to: {3}", (member.MemberType == MemberTypes.Property) ? "Property" : "Field", member.Name, $"'{component.gameObject.name}' ({component.GetType().FullName})", argument);
			}
			else if (typeof(GameObject).IsAssignableFrom(type2))
			{
				GameObject gameObject = (GameObject)objectInstance;
				text3 = string.Format("{0} '{1}' on game object '{2}' was set to: {3}", (member.MemberType == MemberTypes.Property) ? "Property" : "Field", member.Name, gameObject.name, argument);
			}
			else
			{
				text3 = string.Format("{0} '{1}' on object of type '{2}' was set to: {3}", (member.MemberType == MemberTypes.Property) ? "Property" : "Field", member.Name, type2.FullName, argument);
			}
			logEntries.Add(new LogEntry(text3, "Console command executed: " + fullCommand, LogType.Log));
		}
	}
}
