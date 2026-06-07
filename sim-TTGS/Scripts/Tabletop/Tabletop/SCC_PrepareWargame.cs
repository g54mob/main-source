using Dhs5.Utility.Console;
using Simulator.GameWorld;
using Tabletop.GameWorld;

namespace Tabletop
{
	public class SCC_PrepareWargame : ScriptedConsoleCommand
	{
		public SCC_PrepareWargame()
			: base(new ConsoleCommandPiece(optional: false, "/prepare wargame"))
		{
		}

		protected override void OnCommandValidated(ValidCommand validCommand)
		{
			Collection.DebugCollectAllMiniatures(5);
			Collection.DebugPaintAllMiniatures();
			World.DeliverySystem.Deliver(24);
		}
	}
}
