using System.Collections.Generic;
using CTS.Core;
using CTS.DevConsole;
using UnityEngine.Scripting;

namespace CTS
{
	[Preserve]
	public class CommandUnlockLevel : ConsoleCommand
	{
		private readonly List<string> _arguments = new List<string> { "Level_01", "Level_02", "Level_03", "Level_04", "Level_05", "Level_06" };

		public override string Command { get; } = "UnlockLevel";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { EArgType.StringList };

		protected override List<string> GetStringListArgument(int argIndex, out bool caseSensitive)
		{
			caseSensitive = false;
			return _arguments;
		}

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			if (!(CTSSingleton<ProfileManager>.Instance.CurrentProfile is CareerProfile careerProfile))
			{
				DeveloperConsole.LogError("Current profile isn't a career");
			}
			else
			{
				careerProfile.Unlock(rawArgs[0]);
			}
		}

		public override string GetCommandDescription()
		{
			return "Unlocks a specified level. *USE INSIDE A LEVEL*";
		}
	}
}
