using Dhs5.Utility.Console;
using Simulator.GameWorld;

namespace Simulator
{
	public class SCC_DayTime : ScriptedConsoleCommand
	{
		public SCC_DayTime()
			: base(new ConsoleCommandPiece(optional: false, "/daytime"), new ConsoleCommandPiece(ParamType.FLOAT))
		{
		}

		protected override void OnCommandValidated(ValidCommand validCommand)
		{
			World.TimeController.SetNormalizedTime((float)validCommand.parameters[1]);
		}
	}
}
