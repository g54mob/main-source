using Dhs5.Utility.Console;
using Simulator.GameWorld;

namespace Simulator
{
	public class SCC_ShopLevel : ScriptedConsoleCommand
	{
		public SCC_ShopLevel()
			: base(new ConsoleCommandPiece(optional: false, "/shop level"), new ConsoleCommandPiece(ParamType.INT))
		{
		}

		protected override void OnCommandValidated(ValidCommand validCommand)
		{
			World.GameState.Debug_SetShopLevel((int)validCommand.parameters[1]);
		}
	}
}
