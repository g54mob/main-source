using NSEipix.Base;
using NSMedieval.Manager;

namespace NSMedieval.DevConsole
{
	public class CommandSetTimeInDay : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSetTimeInDay()
		{
			Command = "setTimeInDay";
			Description = "Sets to given time in day";
			Help = "Use this command with argument from 0 to 1";
		}

		private void CommandMethod(float percent)
		{
			MonoSingleton<WeatherManager>.Instance.DebugSetDayTime(percent);
		}
	}
}
