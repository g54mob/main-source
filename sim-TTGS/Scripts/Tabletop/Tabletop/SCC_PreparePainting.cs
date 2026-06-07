using Dhs5.Utility.Console;
using Simulator.GameWorld;
using Tabletop.GameWorld;

namespace Tabletop
{
	public class SCC_PreparePainting : ScriptedConsoleCommand
	{
		public SCC_PreparePainting()
			: base(new ConsoleCommandPiece(optional: false, "/prepare painting"))
		{
		}

		protected override void OnCommandValidated(ValidCommand validCommand)
		{
			Collection.DebugCollectAllMiniatures(5);
			World.DeliverySystem.Deliver(25);
		}
	}
}
