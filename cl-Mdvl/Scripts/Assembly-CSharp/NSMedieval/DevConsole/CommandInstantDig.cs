using NSEipix.Base;
using NSMedieval.Terrain;

namespace NSMedieval.DevConsole
{
	public class CommandInstantDig : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public override string Argument { get; protected set; }

		public CommandInstantDig()
		{
			Command = "toggleinstantdig";
			Description = "Toggles between instant and goap dig.";
			Help = "Use this command to toggle instant dig.";
			Argument = InstantDig();
		}

		private void CommandMethod()
		{
			MonoSingleton<GroundManager>.Instance.InstantDig = !MonoSingleton<GroundManager>.Instance.InstantDig;
			Argument = InstantDig();
			string result = "InstantDig " + Argument;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
		}

		private string InstantDig()
		{
			if (!MonoSingleton<GroundManager>.IsInstantiated() || !MonoSingleton<GroundManager>.Instance.InstantDig)
			{
				return "off";
			}
			return "on";
		}
	}
}
