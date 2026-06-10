using System;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.State;

namespace NSMedieval.DevConsole
{
	public class CommandSetHaulMode : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public override string Argument { get; protected set; }

		public CommandSetHaulMode()
		{
			Command = "setHaulMode";
			Description = "Changes global hauling mode for all agents.";
			Help = "Available types: \n";
			int num = 0;
			string[] names = Enum.GetNames(typeof(HaulTargetingMode));
			foreach (string arg in names)
			{
				if (num > 0)
				{
					Help += $"({num}) {arg} \n";
				}
				num++;
			}
			Help += " Specify parameter by index please.";
			Help = Help + " Current type: " + CreatureBase.GlobalHaulTargetingMode;
			Argument = InstantDig();
		}

		private void CommandMethod(int value)
		{
			HaulTargetingMode haulTargetingMode = (HaulTargetingMode)value;
			if (haulTargetingMode <= HaulTargetingMode.None || haulTargetingMode > HaulTargetingMode.TreatAllEqually)
			{
				haulTargetingMode = HaulTargetingMode.PrioritiseReLocation;
			}
			CreatureBase.GlobalHaulTargetingMode = haulTargetingMode;
			Argument = InstantDig();
			string result = "Mode set to: " + Argument;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
		}

		private string InstantDig()
		{
			return CreatureBase.GlobalHaulTargetingMode.ToString();
		}
	}
}
