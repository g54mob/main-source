#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpConfig;
using UnityConsole;
using UnityEngine;

namespace TH20
{
	internal class ConsoleKeyBindingManager
	{
		private struct Binding
		{
			public KeyCode KeyCode;

			public string Command;

			public string[] Args;
		}

		private readonly InputManager _inputManager;

		private readonly List<Binding> _bindings = new List<Binding>();

		public ConsoleKeyBindingManager(InputManager inputManager)
		{
			_inputManager = inputManager;
			ConsoleCommandsDatabase.RegisterCommand("BindKey", "Binds a key to a console command. A key can be bound to multiple commands.", "BindKey D SetDebugGUIEnabled 1", BindKeyCallback);
			ConsoleCommandsDatabase.RegisterCommand("UnBindKey", "Un-binds a key from a console command, or from all console commands if no command is given", "UnBindKey D SetDebugGUIEnabled 1", UnBindKeyCallback);
			ConsoleCommandsDatabase.RegisterCommand("ListKeyBindings", "Prints a list of bound keys", "ListKeyBindings", ListKeyBindingsCallback);
		}

		public void BindDebugKeys(Configuration developerPreferences)
		{
			try
			{
				foreach (Setting item in developerPreferences["KeyBindings"])
				{
					try
					{
						TryAddBinding(item.Name, item.StringValue);
					}
					catch (Exception ex)
					{
						Logging.Warning("Couldn't add console command: {0}", ex);
					}
				}
			}
			catch (Exception)
			{
			}
		}

		public void TryAddBinding(string keyCodeAsString, string commandAndArgs)
		{
			KeyCode? parsedKeyCode = TryParseKeyCode(keyCodeAsString);
			if (!parsedKeyCode.HasValue)
			{
				throw new Exception($"Couldn't parse {keyCodeAsString} as a KeyCode");
			}
			string[] array = commandAndArgs.Split(' ');
			string command = array[0];
			string[] args = array.Skip(1).ToArray();
			if (!_bindings.Any((Binding binding) => binding.Command == command && binding.KeyCode == parsedKeyCode.Value))
			{
				_bindings.Add(new Binding
				{
					KeyCode = parsedKeyCode.Value,
					Command = command,
					Args = args
				});
			}
		}

		private ConsoleCommandResult BindKeyCallback(params string[] args)
		{
			if (args.Length < 2)
			{
				return ConsoleCommandResult.Failed($"Not enough arguments - expected at least a KeyCode and command argument - only had {args.Length}");
			}
			KeyCode? keyCode = TryParseKeyCode(args[0]);
			if (!keyCode.HasValue)
			{
				return ConsoleCommandResult.Failed($"Couldn't parse {args[0]} as a KeyCode");
			}
			string command = args[1];
			string[] args2 = args.Skip(2).ToArray();
			_bindings.Add(new Binding
			{
				KeyCode = keyCode.Value,
				Command = command,
				Args = args2
			});
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult UnBindKeyCallback(params string[] args)
		{
			if (args.Length == 0)
			{
				return ConsoleCommandResult.Failed("Not enough arguments - expected at least a KeyCode argument");
			}
			KeyCode? parsedKeyCode = TryParseKeyCode(args[0]);
			if (!parsedKeyCode.HasValue)
			{
				return ConsoleCommandResult.Failed($"Couldn't parse {args[0]} as a KeyCode");
			}
			string command = ((args.Length != 0) ? args[0] : null);
			string[] commandArgs = ((args.Length > 1) ? args.Skip(1).ToArray() : null);
			int num = _bindings.RemoveAll((Binding kvp) => kvp.KeyCode == parsedKeyCode.Value && (command == null || kvp.Command == command) && (commandArgs == null || commandArgs.SequenceEqual(kvp.Args)));
			return ConsoleCommandResult.Succeeded($"Removed {num} bindings");
		}

		private ConsoleCommandResult ListKeyBindingsCallback(params string[] args)
		{
			StringBuilder builder = StringBuilderPool.GlobalStringBuilderPool.GetBuilder();
			for (int i = 0; i < _bindings.Count; i++)
			{
				builder.AppendFormat("{0}: {1} {2}\n", _bindings[i].KeyCode, _bindings[i].Command, string.Join(" ", _bindings[i].Args));
			}
			string output = builder.ToString();
			StringBuilderPool.GlobalStringBuilderPool.ReturnBuilder(builder);
			return ConsoleCommandResult.Succeeded(output);
		}

		private KeyCode? TryParseKeyCode(string keyCodeAsString)
		{
			try
			{
				KeyCode keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), keyCodeAsString, ignoreCase: true);
				if (!Enum.IsDefined(typeof(KeyCode), keyCode))
				{
					return null;
				}
				return keyCode;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public void Update()
		{
			if (!DebugVars.EnableKeyBindings.Value)
			{
				return;
			}
			bool num = _inputManager.GetKey(KeyCode.LeftShift) || _inputManager.GetKey(KeyCode.RightShift);
			bool flag = _inputManager.GetKey(KeyCode.LeftControl) || _inputManager.GetKey(KeyCode.RightControl);
			if (num || flag)
			{
				return;
			}
			for (int i = 0; i < _bindings.Count; i++)
			{
				Binding binding = _bindings[i];
				if (!_inputManager.GetKeyDown(binding.KeyCode))
				{
					continue;
				}
				Logging.Info(LogChannels.Debug, "Key binding " + binding.KeyCode.ToString() + " pressed. Executing: " + binding.Command + " " + string.Join(" ", binding.Args));
				ConsoleCommandResult consoleCommandResult = ConsoleCommandsDatabase.ExecuteCommand(binding.Command, binding.Args);
				Logging.Info(LogChannels.Debug, consoleCommandResult.succeeded ? "Done" : "Failed");
				if (!string.IsNullOrEmpty(consoleCommandResult.Output))
				{
					if (consoleCommandResult.succeeded)
					{
						Logging.Info(LogChannels.Debug, consoleCommandResult.Output);
					}
					else
					{
						Logging.Error(LogChannels.Debug, consoleCommandResult.Output);
					}
				}
			}
		}
	}
}
