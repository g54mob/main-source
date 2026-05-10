using System;
using System.Collections.Generic;
using CTS.Core;
using CTS.DevConsole;
using Newtonsoft.Json;
using UnityEngine;

namespace CTS
{
	public class CommandMacro : ConsoleCommand
	{
		public const string PlayerPrefsKey = "ConsoleMacros";

		internal static SafeEnumerable<KeyCode, string> Macros { get; }

		public override string Command { get; } = "Macro";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[2]
		{
			typeof(KeyCode),
			EArgType.String
		};

		static CommandMacro()
		{
			Macros = new SafeEnumerable<KeyCode, string>();
			string value = PlayerPrefs.GetString("ConsoleMacros");
			if (string.IsNullOrEmpty(value))
			{
				return;
			}
			try
			{
				foreach (var (key, value2) in JsonConvert.DeserializeObject<Dictionary<KeyCode, string>>(value))
				{
					if (Macros.ContainsKey(key))
					{
						break;
					}
					Macros.Add(key, value2);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		[RuntimeInitializeOnLoadMethod]
		private static void InitializeOnLoad()
		{
			GameObject gameObject = new GameObject("Console Macros Player");
			UnityEngine.Object.DontDestroyOnLoad(gameObject);
			gameObject.AddComponent<MacroPlayer>();
		}

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			if (args.Count == 2 && args[0] is KeyCode keyCode)
			{
				Macros[keyCode] = rawArgs[1];
				string value = JsonConvert.SerializeObject(Macros.ToDictionary(), Formatting.None);
				PlayerPrefs.SetString("ConsoleMacros", value);
				DeveloperConsole.Log($"Assigned '{rawArgs[1]}' to '{keyCode}'");
			}
		}

		public override string GetCommandDescription()
		{
			return "Sets a command to a keyboard key";
		}
	}
}
