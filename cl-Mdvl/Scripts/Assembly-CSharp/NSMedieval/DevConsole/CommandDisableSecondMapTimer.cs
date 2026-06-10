using NSEipix.Base;
using NSMedieval.Village;
using NSMedieval.Village.Map;

namespace NSMedieval.DevConsole
{
	public class CommandDisableSecondMapTimer : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public override string Argument { get; protected set; }

		public CommandDisableSecondMapTimer()
		{
			Command = "commandDisableSecondMapTimer";
			Description = "Disables/enables second map timer.";
			Help = "Use this command to disable/enable the second map timer.";
			Argument = DisableSecondMapTimerResult();
		}

		private void CommandMethod()
		{
			VillageMap map = VillageManager.ActiveVillage.Map;
			map.SecondMapLeaveManager.TimerDisabledDebug = !map.SecondMapLeaveManager.TimerDisabledDebug;
			Argument = DisableSecondMapTimerResult();
			string result = "SecondMapTimer " + Argument;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
		}

		private string DisableSecondMapTimerResult()
		{
			VillageMap map = VillageManager.ActiveVillage.Map;
			if (map?.SecondMapLeaveManager == null)
			{
				return "on";
			}
			if (!map.SecondMapLeaveManager.TimerDisabledDebug)
			{
				return "on";
			}
			return "off";
		}
	}
}
