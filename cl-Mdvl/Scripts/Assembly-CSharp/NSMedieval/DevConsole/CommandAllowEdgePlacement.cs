using NSEipix.Base;
using NSMedieval.Map;

namespace NSMedieval.DevConsole
{
	public class CommandAllowEdgePlacement : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public override string Argument { get; protected set; }

		public CommandAllowEdgePlacement()
		{
			Command = "toggleAllowEdgePlacement";
			Description = "Allow or forbid building placement on the edge of the map.";
			Help = "Use this command to allow or forbid building placement on the edge of the map.";
			Argument = AllowEdgePlacement();
		}

		private void CommandMethod()
		{
			World.AllowEdgePlacement = !World.AllowEdgePlacement;
			Argument = AllowEdgePlacement();
			string result = "AllowEdgePlacement " + Argument;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
		}

		private string AllowEdgePlacement()
		{
			if (!World.AllowEdgePlacement)
			{
				return "off";
			}
			return "on";
		}
	}
}
