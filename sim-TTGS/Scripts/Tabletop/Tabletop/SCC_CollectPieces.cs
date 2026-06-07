using Dhs5.Utility.Console;
using Tabletop.GameWorld;

namespace Tabletop
{
	public class SCC_CollectPieces : ScriptedConsoleCommand
	{
		public SCC_CollectPieces()
			: base(new ConsoleCommandPiece(optional: false, "/collect"), new ConsoleCommandPiece(ParamType.INT))
		{
		}

		protected override void OnCommandValidated(ValidCommand validCommand)
		{
			Collection.DebugCollectPieces((int)validCommand.parameters[1]);
		}
	}
}
