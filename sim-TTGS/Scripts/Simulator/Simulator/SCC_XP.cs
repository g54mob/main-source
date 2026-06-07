using Dhs5.Utility.Console;
using Simulator.GameWorld;

namespace Simulator
{
	public class SCC_XP : ScriptedConsoleCommand
	{
		public SCC_XP()
			: base(new ConsoleCommandPiece(optional: false, "/xp"), new ConsoleCommandPiece(ParamType.INT))
		{
		}

		protected override void OnCommandValidated(ValidCommand validCommand)
		{
			World.GameState.Debug_GainShopXP((int)validCommand.parameters[1]);
		}
	}
}
