using System;
using System.Collections.Generic;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS.DevConsole.Commands
{
	public class CommandDebug : ConsoleCommand
	{
		public override string Command { get; } = "Debug";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[2]
		{
			EArgType.Type,
			EArgType.String
		};

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			if (args.Count < 2)
			{
				throw ConsoleCommand.ErrorBadNumberOfArguments();
			}
			if (!(args[0] is Type type))
			{
				throw ConsoleCommand.ErrorBadArgument(rawArgs[0], "[Type]");
			}
			if (!type.IsSubclassOf(typeof(Component)))
			{
				throw ConsoleCommand.ErrorBadArgument(rawArgs[0], "Type should be a Component");
			}
			if (!ConsoleCommand.TryGetSelectedObject(type, out var component, searchIfNothingSelected: true))
			{
				DeveloperConsole.LogError("Selected object doesn't have a component of type " + type.Name);
				return;
			}
			DeveloperConsole.Log("Found component " + type.Name + " on " + component.name);
			bool flag = false;
			string text = "";
			object outObject = null;
			object target = component;
			for (int i = 1; i < rawArgs.Length; i++)
			{
				text = rawArgs[i];
				flag = target.TryGetField(text, out outObject);
				if (flag)
				{
					if (outObject == null)
					{
						break;
					}
					target = outObject;
					continue;
				}
				flag = target.TryGetProperty<object>(text, out outObject);
				if (!flag || outObject == null)
				{
					break;
				}
				target = outObject;
			}
			if (!flag)
			{
				DeveloperConsole.Log("Couldn't find variable " + text);
				return;
			}
			if (outObject == null)
			{
				DeveloperConsole.Log(text + " is null");
				return;
			}
			DeveloperConsole.Log(text + ": [" + outObject.GetType().Name + " | '" + outObject.ToString() + "']");
		}

		public override string GetCommandDescription()
		{
			return "Shows the value of a specified variable of the selected object";
		}

		protected override bool IsArgumentIndexOutOfBounds(int argIndex)
		{
			if (argIndex < 0)
			{
				return true;
			}
			return false;
		}

		protected override EValidity CheckArgumentValidity(ref DeveloperConsole.InputReport inputReport, string arg, int argIndex, bool isLastArg)
		{
			if (argIndex == 0)
			{
				return base.CheckArgumentValidity(ref inputReport, arg, argIndex, isLastArg);
			}
			if (!isLastArg && arg == "")
			{
				return EValidity.Invalid;
			}
			return base.CheckArgumentValidity(ref inputReport, arg, 1, isLastArg);
		}
	}
}
