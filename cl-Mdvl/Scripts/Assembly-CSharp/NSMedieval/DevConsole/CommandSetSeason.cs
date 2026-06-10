using NSEipix.Base;
using NSMedieval.Manager;

namespace NSMedieval.DevConsole
{
	public class CommandSetSeason : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSetSeason()
		{
			Command = "setSeason";
			Description = "Sets season";
			Help = "Use this command with int argument for season and float argument as percent for day in season";
		}

		private void CommandMethod(int season, float percent)
		{
			MonoSingleton<WeatherManager>.Instance.DebugSetSeasonTime(season, percent);
		}
	}
}
