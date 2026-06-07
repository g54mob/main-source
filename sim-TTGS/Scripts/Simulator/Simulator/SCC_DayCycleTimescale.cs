using Dhs5.Utility.Console;
using Simulator.GameWorld;

namespace Simulator
{
	public class SCC_DayCycleTimescale : ScriptedConsoleCommand
	{
		public SCC_DayCycleTimescale()
			: base(new ConsoleCommandPiece(optional: false, "/dayCycle_timescale"), new ConsoleCommandPiece(ParamType.FLOAT))
		{
		}

		protected override void OnCommandValidated(ValidCommand validCommand)
		{
			World.TimeController.SetTimescale((float)validCommand.parameters[1]);
		}
	}
}
