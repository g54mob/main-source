using System.Collections.Generic;
using System.Linq;
using CTS.DevConsole.Variables;

namespace CTS.DevConsole.Commands
{
	internal class CommandVar : ConsoleCommand
	{
		private ConsoleVar _foundVar;

		public override string Command => "Var";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; }

		public override string GetCommandDescription()
		{
			return "Shows or modifies a Global Variable.";
		}

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			if (args.Count <= 0)
			{
				throw ConsoleCommand.ErrorBadNumberOfArguments();
			}
			if (args[0] is ConsoleVar consoleVar)
			{
				consoleVar.Execute(rawArgs.Skip(1).ToArray());
			}
			else
			{
				DeveloperConsole.LogError("Global variable '" + rawArgs[0] + "' doesn't exist");
			}
		}

		public override void CheckValidityOfArguments(ref DeveloperConsole.InputReport inputReport, List<string> args)
		{
			_foundVar = null;
			base.CheckValidityOfArguments(ref inputReport, args);
		}

		protected override EValidity CheckArgumentValidity(ref DeveloperConsole.InputReport inputReport, string arg, int argIndex, bool isLastArg)
		{
			if (argIndex == 0)
			{
				arg = arg.ToLowerInvariant();
				bool flag = false;
				foreach (var (parent, cVarReference2) in ConsoleVar.Vars)
				{
					if (DeveloperConsole.ArgIsContainedIn(arg, parent, caseSensitive: false))
					{
						flag = true;
						inputReport.CommandMatches.Add(cVarReference2.GetVariable().ConsoleKey);
					}
				}
				if (!ConsoleVar.Vars.TryGetValue(arg, out var value))
				{
					if (!flag)
					{
						return EValidity.Invalid;
					}
					return EValidity.Incomplete;
				}
				_foundVar = value.GetVariable();
				inputReport.CastedArguments.Insert(argIndex, _foundVar);
				return EValidity.Valid;
			}
			inputReport.CommandMatches.Clear();
			if (_foundVar == null)
			{
				return EValidity.Invalid;
			}
			return _foundVar.CheckArgumentValidity(ref inputReport, arg, argIndex, argIndex);
		}

		protected override bool IsArgumentIndexOutOfBounds(int argIndex)
		{
			if (_foundVar != null)
			{
				return _foundVar.IsArgumentIndexOutOfBounds(argIndex);
			}
			if (argIndex >= 0)
			{
				return argIndex > 1;
			}
			return true;
		}
	}
}
