using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using DevCmdLine.UI;
using UnityEngine;

namespace DevCmdLine
{
	public static class DevCmdManager
	{
		private struct DevCmdInfo
		{
			public Action<DevCmdArg[]> func;

			public string description;

			public string[] regexPatterns;

			public string[] argNames;
		}

		private struct ArgInfo
		{
			public bool completingValue;

			public int index;

			public bool quoted;

			public char quoteChar;
		}

		private struct CmdArgKey : IEquatable<CmdArgKey>
		{
			public readonly string cmdName;

			public readonly string argName;

			public readonly int varIndex;

			public CmdArgKey(string cmdName, string argName, int varIndex)
			{
				this.cmdName = cmdName;
				this.argName = argName;
				this.varIndex = varIndex;
			}

			public bool Equals(CmdArgKey other)
			{
				if (cmdName == other.cmdName && argName == other.argName)
				{
					return varIndex == other.varIndex;
				}
				return false;
			}

			public override bool Equals(object obj)
			{
				if (obj is CmdArgKey other)
				{
					return Equals(other);
				}
				return false;
			}

			public override int GetHashCode()
			{
				return HashCode.Combine(cmdName, argName, varIndex);
			}
		}

		private struct CompleteInfo
		{
			public Func<string[]> func;

			public DevCmdCompleteFlags flags;
		}

		private static Dictionary<string, DevCmdInfo> _commands;

		private static Dictionary<string, Trie> _cmdArgTries;

		private static Dictionary<CmdArgKey, CompleteInfo> _completes;

		private static Dictionary<CmdArgKey, Trie> _argOptionsCache;

		private static HashSet<Assembly> _assembliesRegistered;

		private static Trie _cmdTrie;

		private static Action<string> _onRunningCmd;

		private const string CMD_VERIFY_PATTERN = "^ *(?<cmd>[a-zA-Z][a-zA-Z0-9\\-_]*) *(?<args>(?:(?:-[a-zA-Z][a-zA-Z0-9\\-_]*(?: +|$)?)?(?:(?:[^ \\-\"'\\n][^ \"'\\n]*|(?<quote>[\"']).*?\\k<quote>)(?: +|$))*)*)? *$";

		private const string ARGS_MATCHES_PATTERN = "(?:-(?<arg_name>[a-zA-Z][a-zA-Z0-9\\-_]*)(?: +|$)?)?(?<arg_values>(?:(?:[^ \\-\"\"'\\n][^ \"\"'\\n]*|(?<quote>[\"\"']).*?\\k<quote>) *)+)?";

		private const string ARG_VALUE_MATCHES_PATTERN = "(?:(?<arg_value>[^ \\-\"'\\n][^ \"'\\n]*)|(?:(?<quote>[\"'])(?<arg_quoted>.*?)\\k<quote>))";

		private const string CMD_INC_VERIFY_PATTERN = "^ *(?<cmd_inc>[a-zA-Z][a-zA-Z0-9\\-_]*) *(?<args_inc>(?:(?:-([a-zA-Z][a-zA-Z0-9\\-_]*)?(?: +|$)?)?(?:(?:[^ \\-\"'\\n][^ \"'\\n]*|(?<quote>[\"']).*?\\k<quote>||([\"'].*))(?: +|$))*)*)? *$";

		private const string ARGS_INC_MATCHES_PATTERN = "(?:-(?<arg_inc_name>[a-zA-Z][a-zA-Z0-9\\-_]*)(?: +|$)?)?(?<arg_inc_values>(?:(?:[^ \\-\"'\\n][^ \"'\\n]*|(?<quote>[\"']).*?\\k<quote>|[\"'].*?) *)*)";

		private const string ARG_VALUE_INC_MATCHES_PATTERN = "(?:(?<arg_inc_value>[^ \\-\"'\\n][^ \"'\\n]*)|(?:(?<quote>[\"']).*?\\k<quote>)|[\"'](?<arg_inc_quote>.*))";

		private const string MULTIPLE_SPACES_PATTERN = "[ ]{2,}(?=([^\"]*\"[^\"]*\")*[^\"]*$)(?=([^']*'[^']*')*[^']*$)";

		public static void RunCommand(string cmd)
		{
			Debug.Log("<color=#00ffff>$ " + cmd + "</color>");
			if (TryParseCommand(cmd, out var cmdName, out var argsString, out var argsParsed))
			{
				if (!_commands.TryGetValue(cmdName, out var value))
				{
					Debug.LogWarning("Command " + cmdName + " not found\nUse 'help' for a list of commands");
					return;
				}
				argsString = Regex.Replace(argsString.Trim(' '), "[ ]{2,}(?=([^\"]*\"[^\"]*\")*[^\"]*$)(?=([^']*'[^']*')*[^']*$)", " ");
				if (value.regexPatterns.Length != 0)
				{
					bool flag = false;
					string[] regexPatterns = value.regexPatterns;
					foreach (string pattern in regexPatterns)
					{
						if (Regex.IsMatch(argsString, pattern))
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						Debug.LogWarning("Invalid format for " + cmdName + "\nUse 'help " + cmdName + "' for a description");
						return;
					}
				}
				if (_onRunningCmd != null)
				{
					_onRunningCmd(cmd);
				}
				value.func(argsParsed);
			}
			else
			{
				Debug.LogWarning("Could not process cmd");
			}
		}

		public static string CompleteCmd(string cmd)
		{
			if (TryParseForComplete(cmd, out var cmdName, out var incompleteCmd, out var argName, out var argValue, out var argValueIndex, out var info))
			{
				if (incompleteCmd)
				{
					cmd = CompleteWithTrie(cmd, cmdName, GetCmdTrie(), 0);
				}
				else if (info.completingValue)
				{
					DevCmdCompleteFlags flags;
					Trie argValueCompleteTrie = GetArgValueCompleteTrie(cmdName, argName, argValueIndex, out flags);
					if (argValueCompleteTrie != null)
					{
						cmd = CompleteWithTrie(cmd, argValue, argValueCompleteTrie, (flags & DevCmdCompleteFlags.ValueCaseInsensitive) != 0, info.quoted, info.quoteChar, info.index);
					}
				}
				else
				{
					Trie argNameCompleteTrie = GetArgNameCompleteTrie(cmdName);
					if (argNameCompleteTrie != null)
					{
						cmd = CompleteWithTrie(cmd, argName, argNameCompleteTrie, info.index);
					}
				}
			}
			return cmd;
		}

		public static string[] GetCompleteOptions(string cmd)
		{
			if (TryParseForComplete(cmd, out var cmdName, out var incompleteCmd, out var argName, out var argValue, out var argValueIndex, out var info))
			{
				if (incompleteCmd)
				{
					return GetCompleteOptions(GetCmdTrie(), cmdName, DevCmdCompleteFlags.ValueCaseInsensitive | DevCmdCompleteFlags.Sort);
				}
				if (info.completingValue)
				{
					DevCmdCompleteFlags flags;
					Trie argValueCompleteTrie = GetArgValueCompleteTrie(cmdName, argName, argValueIndex, out flags);
					if (argValueCompleteTrie != null)
					{
						return GetCompleteOptions(argValueCompleteTrie, argValue, flags);
					}
				}
				else
				{
					Trie argNameCompleteTrie = GetArgNameCompleteTrie(cmdName);
					if (argNameCompleteTrie != null)
					{
						return GetCompleteOptions(argNameCompleteTrie, argName, DevCmdCompleteFlags.ValueCaseInsensitive | DevCmdCompleteFlags.Sort);
					}
				}
			}
			return new string[0];
		}

		static DevCmdManager()
		{
			_commands = new Dictionary<string, DevCmdInfo>();
			_cmdArgTries = new Dictionary<string, Trie>();
			_completes = new Dictionary<CmdArgKey, CompleteInfo>();
			_argOptionsCache = new Dictionary<CmdArgKey, Trie>();
			_assembliesRegistered = new HashSet<Assembly>();
			RegisterSelfAssembly();
		}

		public static void RegisterOnRunningCommand(Action<string> onRunningCmd)
		{
			_onRunningCmd = onRunningCmd;
		}

		private static bool TryParseCommand(string cmd, out string cmdName, out string argsString, out DevCmdArg[] argsParsed)
		{
			cmdName = null;
			argsString = null;
			argsParsed = null;
			Match match = Regex.Match(cmd, "^ *(?<cmd>[a-zA-Z][a-zA-Z0-9\\-_]*) *(?<args>(?:(?:-[a-zA-Z][a-zA-Z0-9\\-_]*(?: +|$)?)?(?:(?:[^ \\-\"'\\n][^ \"'\\n]*|(?<quote>[\"']).*?\\k<quote>)(?: +|$))*)*)? *$");
			if (!match.Success)
			{
				return false;
			}
			cmdName = match.Groups["cmd"].Value.ToLower();
			argsString = match.Groups["args"].Value;
			MatchCollection matchCollection = Regex.Matches(argsString, "(?:-(?<arg_name>[a-zA-Z][a-zA-Z0-9\\-_]*)(?: +|$)?)?(?<arg_values>(?:(?:[^ \\-\"\"'\\n][^ \"\"'\\n]*|(?<quote>[\"\"']).*?\\k<quote>) *)+)?");
			List<DevCmdArg> list = new List<DevCmdArg>();
			List<string> list2 = new List<string>();
			for (int i = 0; i < matchCollection.Count; i++)
			{
				Match match2 = matchCollection[i];
				DevCmdArg devCmdArg = new DevCmdArg();
				Group obj = match2.Groups["arg_name"];
				if (obj.Success)
				{
					devCmdArg.name = obj.Value.ToLower();
				}
				Group obj2 = match2.Groups["arg_values"];
				if (obj2.Success)
				{
					MatchCollection matchCollection2 = Regex.Matches(obj2.Value, "(?:(?<arg_value>[^ \\-\"'\\n][^ \"'\\n]*)|(?:(?<quote>[\"'])(?<arg_quoted>.*?)\\k<quote>))");
					for (int j = 0; j < matchCollection2.Count; j++)
					{
						Match match3 = matchCollection2[j];
						Group obj3 = match3.Groups["arg_value"];
						if (obj3.Success)
						{
							list2.Add(obj3.Value);
							continue;
						}
						Group obj4 = match3.Groups["arg_quoted"];
						if (obj4.Success)
						{
							list2.Add(obj4.Value);
						}
					}
				}
				if (!string.IsNullOrEmpty(devCmdArg.name) || list2.Count > 0)
				{
					devCmdArg.values = list2.ToArray();
					list2.Clear();
					list.Add(devCmdArg);
				}
			}
			argsParsed = list.ToArray();
			return true;
		}

		private static bool TryParseForComplete(string cmd, out string cmdName, out bool incompleteCmd, out string argName, out string argValue, out int argValueIndex, out ArgInfo info)
		{
			cmdName = null;
			argName = null;
			argValue = null;
			argValueIndex = 0;
			info = default(ArgInfo);
			incompleteCmd = false;
			Match match = Regex.Match(cmd, "^ *(?<cmd_inc>[a-zA-Z][a-zA-Z0-9\\-_]*) *(?<args_inc>(?:(?:-([a-zA-Z][a-zA-Z0-9\\-_]*)?(?: +|$)?)?(?:(?:[^ \\-\"'\\n][^ \"'\\n]*|(?<quote>[\"']).*?\\k<quote>||([\"'].*))(?: +|$))*)*)? *$");
			if (!match.Success)
			{
				return false;
			}
			cmdName = match.Groups["cmd_inc"].Value.ToLower();
			Group obj = match.Groups["args_inc"];
			bool flag = cmd[cmd.Length - 1] == ' ';
			if (string.IsNullOrEmpty(obj.Value))
			{
				if (flag)
				{
					argName = "";
					argValue = "";
					argValueIndex = 0;
					info.completingValue = true;
					info.index = cmd.Length;
					return true;
				}
				incompleteCmd = true;
				return true;
			}
			MatchCollection matchCollection = Regex.Matches(obj.Value, "(?:-(?<arg_inc_name>[a-zA-Z][a-zA-Z0-9\\-_]*)(?: +|$)?)?(?<arg_inc_values>(?:(?:[^ \\-\"'\\n][^ \"'\\n]*|(?<quote>[\"']).*?\\k<quote>|[\"'].*?) *)*)");
			Match match2 = matchCollection[matchCollection.Count - 2];
			Group obj2 = match2.Groups["arg_inc_values"];
			Group obj3 = match2.Groups["arg_inc_name"];
			if (obj3.Success)
			{
				argName = obj3.Value;
			}
			else
			{
				argName = "";
			}
			if (string.IsNullOrEmpty(obj2.Value))
			{
				if (flag)
				{
					argValue = "";
					argValueIndex = 0;
					info.completingValue = true;
					info.index = cmd.Length;
					return true;
				}
				argName = obj3.Value;
				info.index = obj.Index + match2.Index + obj3.Index;
				if (string.IsNullOrEmpty(argName))
				{
					info.index++;
				}
				return true;
			}
			matchCollection = Regex.Matches(obj2.Value, "(?:(?<arg_inc_value>[^ \\-\"'\\n][^ \"'\\n]*)|(?:(?<quote>[\"']).*?\\k<quote>)|[\"'](?<arg_inc_quote>.*))");
			Match match3 = matchCollection[matchCollection.Count - 1];
			Group obj4 = match3.Groups["arg_inc_quote"];
			if (obj4.Success)
			{
				argValue = obj4.Value;
				argValueIndex = matchCollection.Count - 1;
				info.index = obj.Index + obj2.Index + match3.Index + obj4.Index;
				info.quoted = true;
				info.quoteChar = obj2.Value[obj4.Index - 1];
				info.completingValue = true;
				return true;
			}
			if (flag)
			{
				argValue = "";
				argValueIndex = matchCollection.Count;
				info.index = cmd.Length;
				info.completingValue = true;
				return true;
			}
			Group obj5 = match3.Groups["arg_inc_value"];
			if (obj5.Success)
			{
				argValue = obj5.Value;
				argValueIndex = matchCollection.Count - 1;
				info.index = obj.Index + obj2.Index + match3.Index + obj5.Index;
				info.completingValue = true;
				return true;
			}
			return false;
		}

		private static string CompleteWithTrie(string cmd, string completing, Trie trie, int startIndex)
		{
			return CompleteWithTrie(cmd, completing, trie, caseInsensitive: true, quoted: false, '\0', startIndex);
		}

		private static string CompleteWithTrie(string cmd, string completing, Trie trie, bool caseInsensitive, bool quoted, char quote, int startIndex)
		{
			Trie.Node node = trie.Prefix(completing, caseInsensitive);
			if (node.depth == completing.Length)
			{
				StringBuilder stringBuilder = new StringBuilder(cmd);
				if (caseInsensitive)
				{
					Trie.Node node2 = trie.root;
					for (int i = startIndex; i < stringBuilder.Length; i++)
					{
						node2 = node2.GetChild(stringBuilder[i], caseInsensitive: true);
						stringBuilder[i] = node2.value;
					}
				}
				bool flag = false;
				Trie.Node node3 = node;
				while (!node3.isCompleteString && node3.childrenCount == 1)
				{
					Trie.Node firstChild = node3.GetFirstChild();
					if (!quoted && !flag && char.IsWhiteSpace(firstChild.value))
					{
						flag = true;
						stringBuilder.Insert(startIndex, "\"");
						quote = '"';
					}
					stringBuilder.Append(firstChild.value);
					node3 = firstChild;
				}
				if ((flag || quoted) && node3.isCompleteString)
				{
					stringBuilder.Append(quote);
				}
				if (node3.isCompleteString && node3.childrenCount == 0)
				{
					stringBuilder.Append(' ');
				}
				cmd = stringBuilder.ToString();
			}
			return cmd;
		}

		private static string[] GetCompleteOptions(Trie trie, string completing, DevCmdCompleteFlags flags)
		{
			Trie.Node node = trie.Prefix(completing, (flags & DevCmdCompleteFlags.ValueCaseInsensitive) != 0);
			if (node.depth == completing.Length)
			{
				List<string> list = new List<string>();
				StringBuilder current = new StringBuilder(completing);
				GetCompleteOptionsHelper(node, list, current);
				if ((flags & DevCmdCompleteFlags.Sort) != DevCmdCompleteFlags.None)
				{
					list.Sort();
				}
				return list.ToArray();
			}
			return new string[0];
		}

		private static void GetCompleteOptionsHelper(Trie.Node node, List<string> options, StringBuilder current)
		{
			if (node.isCompleteString)
			{
				options.Add(current.ToString());
			}
			Trie.Node[] children = node.GetChildren();
			foreach (Trie.Node node2 in children)
			{
				StringBuilder stringBuilder = new StringBuilder(current.ToString());
				stringBuilder.Append(node2.value);
				GetCompleteOptionsHelper(node2, options, stringBuilder);
			}
		}

		private static Trie GetCmdTrie()
		{
			if (_cmdTrie == null)
			{
				_cmdTrie = new Trie();
				_cmdTrie.Add(_commands.Keys);
			}
			return _cmdTrie;
		}

		private static Trie GetArgNameCompleteTrie(string cmdName)
		{
			if (_cmdArgTries.TryGetValue(cmdName, out var value))
			{
				return value;
			}
			if (_commands.TryGetValue(cmdName, out var value2) && value2.argNames != null)
			{
				value = new Trie();
				value.Add(value2.argNames);
				_cmdArgTries[cmdName] = value;
			}
			return value;
		}

		private static Trie GetArgValueCompleteTrie(string cmdName, string argName, int varIndex, out DevCmdCompleteFlags flags)
		{
			flags = DevCmdCompleteFlags.None;
			CmdArgKey key = new CmdArgKey(cmdName, argName, varIndex);
			if (!_completes.TryGetValue(key, out var value))
			{
				return null;
			}
			bool flag = (value.flags & DevCmdCompleteFlags.Cache) != 0;
			flags = value.flags;
			Trie value2 = null;
			if (!flag || !_argOptionsCache.TryGetValue(key, out value2))
			{
				string[] array = value.func();
				if (array != null && array.Length != 0)
				{
					value2 = new Trie();
					value2.Add(array);
					if (flag)
					{
						_argOptionsCache[key] = value2;
					}
				}
			}
			return value2;
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RegisterSelfAssembly()
		{
			RegisterAssembly(typeof(DevCmdManager).Assembly);
		}

		public static void RegisterAssembly(Assembly asm)
		{
			if (_assembliesRegistered.Contains(asm))
			{
				return;
			}
			_assembliesRegistered.Add(asm);
			Type[] types = asm.GetTypes();
			foreach (Type type in types)
			{
				if (type.IsGenericTypeDefinition)
				{
					continue;
				}
				MethodInfo[] methods = type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (MethodInfo methodInfo in methods)
				{
					DevCmdAttribute customAttribute = methodInfo.GetCustomAttribute<DevCmdAttribute>();
					if (customAttribute != null)
					{
						if (string.IsNullOrEmpty(customAttribute.name))
						{
							Debug.LogError("Method " + methodInfo.Name + " of " + type.Name + " has an empty cmd name!");
							continue;
						}
						if (_commands.ContainsKey(customAttribute.name))
						{
							Debug.LogError("Duplicate cmd name! Method " + methodInfo.Name + " of " + type.Name + "!");
							continue;
						}
						if (methodInfo.ReturnType != typeof(void))
						{
							Debug.LogError("Method " + methodInfo.Name + " of " + type.Name + " does not have void return type!");
							continue;
						}
						ParameterInfo[] parameters = methodInfo.GetParameters();
						if (parameters.Length != 1)
						{
							Debug.LogError("Method " + methodInfo.Name + " of " + type.Name + " has incorrect number of parameters!");
							continue;
						}
						if (parameters[0].ParameterType != typeof(DevCmdArg[]))
						{
							Debug.LogError("Method " + methodInfo.Name + " of " + type.Name + " has invalid parameter type!");
							continue;
						}
						DevCmdInfo value = new DevCmdInfo
						{
							func = (Action<DevCmdArg[]>)Delegate.CreateDelegate(typeof(Action<DevCmdArg[]>), null, methodInfo),
							description = customAttribute.description
						};
						if (customAttribute.args != null)
						{
							value.argNames = new string[customAttribute.args.Length];
							for (int k = 0; k < value.argNames.Length; k++)
							{
								value.argNames[k] = customAttribute.args[k].ToLower();
							}
						}
						List<string> list = new List<string>();
						foreach (DevCmdVerifyAttribute customAttribute2 in methodInfo.GetCustomAttributes<DevCmdVerifyAttribute>())
						{
							if (customAttribute2.regexPattern != null)
							{
								list.Add(customAttribute2.regexPattern);
							}
						}
						value.regexPatterns = list.ToArray();
						_commands[customAttribute.name] = value;
						foreach (DevCmdCompleteAttribute customAttribute3 in methodInfo.GetCustomAttributes<DevCmdCompleteAttribute>())
						{
							string[] options = customAttribute3.options;
							if (options != null && options.Length != 0)
							{
								CompleteInfo value2 = new CompleteInfo
								{
									flags = customAttribute3.flags,
									func = () => options
								};
								_completes[new CmdArgKey(customAttribute.name, customAttribute3.name, customAttribute3.varIndex)] = value2;
							}
						}
					}
					foreach (DevCmdCompleteFunctionAttribute customAttribute4 in methodInfo.GetCustomAttributes<DevCmdCompleteFunctionAttribute>())
					{
						if (customAttribute4 != null)
						{
							if (string.IsNullOrEmpty(customAttribute4.cmdName))
							{
								Debug.LogError("Method " + methodInfo.Name + " of " + type.Name + " has an empty cmd name!");
							}
							else if (_completes.ContainsKey(new CmdArgKey(customAttribute4.cmdName, customAttribute4.argName, customAttribute4.varIndex)))
							{
								Debug.LogError("Duplicate cmd name! Method " + methodInfo.Name + " of " + type.Name + "!");
							}
							else if (methodInfo.ReturnType != typeof(string[]))
							{
								Debug.LogError("Method " + methodInfo.Name + " of " + type.Name + " does not have correct return type!");
							}
							else if (methodInfo.GetParameters().Length != 0)
							{
								Debug.LogError("Method " + methodInfo.Name + " of " + type.Name + " has incorrect number of parameters!");
							}
							else
							{
								CompleteInfo value3 = new CompleteInfo
								{
									func = (Func<string[]>)Delegate.CreateDelegate(typeof(Func<string[]>), null, methodInfo),
									flags = customAttribute4.flags
								};
								_completes[new CmdArgKey(customAttribute4.cmdName, customAttribute4.argName, customAttribute4.varIndex)] = value3;
							}
						}
					}
				}
			}
		}

		[DevCmd("help", "List all available commands or show the description of a command.\r\n\r\nUsage:\r\n    help              \r\n        List all available commands\r\n\r\n    help <command>    \r\n        Show the description of a command", new string[] { })]
		[DevCmdVerify("^$")]
		[DevCmdVerify("^[a-zA-Z0-9][a-zA-Z0-9_-]*$")]
		private static void DevCmdHelp(DevCmdArg[] args)
		{
			DevCmdInfo value;
			if (args.Length == 0)
			{
				List<string> list = new List<string>();
				foreach (string key in _commands.Keys)
				{
					list.Add(key);
				}
				list.Sort();
				string text = "Available Commands:\n";
				foreach (string item in list)
				{
					text = text + "    " + item + "\n";
				}
				Debug.Log(text);
			}
			else if (_commands.TryGetValue(args[0].value, out value))
			{
				Debug.Log(value.description);
			}
			else
			{
				Debug.LogWarning("Command " + args[0].value + " not found");
			}
		}

		[DevCmd("clear", "Clears the console.\r\n\r\nUsage:\r\n    clear", new string[] { })]
		[DevCmdVerify("^$")]
		private static void DevCmdClear(DevCmdArg[] args)
		{
			DevCmdConsole.ClearConsole();
		}

		[DevCmdCompleteFunction("help", "", DevCmdCompleteFlags.Default)]
		private static string[] DevCmdHelpComplete()
		{
			List<string> list = new List<string>();
			foreach (string key in _commands.Keys)
			{
				list.Add(key);
			}
			return list.ToArray();
		}
	}
}
