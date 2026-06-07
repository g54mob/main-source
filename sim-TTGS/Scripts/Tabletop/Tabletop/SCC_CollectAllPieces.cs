using Dhs5.Utility.Console;
using Tabletop.GameWorld;

namespace Tabletop
{
	public class SCC_CollectAllPieces : ScriptedConsoleCommand
	{
		public SCC_CollectAllPieces()
			: base(new ConsoleCommandPiece(optional: false, "/collect all"))
		{
		}

		protected override void OnCommandValidated(ValidCommand validCommand)
		{
			Collection.DebugCollectAllPieces(5);
		}
	}
}
