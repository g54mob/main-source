using System;
using System.Collections.Generic;
using CTS.Core;
using CTS.DevConsole;

namespace CTS
{
	public class CommandSaveProfile : ConsoleCommand, ISubCommand<CommandSave>, ISubCommand
	{
		public override string Command { get; } = "Profile";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; }

		public override object[] ArgumentTypes { get; } = new object[1] { EArgType.Int };

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			if (CTSSingleton<ProfileManager>.TryGetInstance(out var outInstance) && args[0] is int profileIndex)
			{
				if (outInstance.CurrentProfile is CareerProfile careerProfile)
				{
					careerProfile.ProfileIndex = profileIndex;
				}
				CTSSingleton<ProfileManager>.Instance.Save();
			}
		}

		public override string GetCommandDescription()
		{
			throw new NotImplementedException();
		}
	}
}
