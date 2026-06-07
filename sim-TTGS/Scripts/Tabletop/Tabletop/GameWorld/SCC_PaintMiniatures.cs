using Dhs5.Utility.Console;

namespace Tabletop.GameWorld
{
	public class SCC_PaintMiniatures : ScriptedConsoleCommand
	{
		public SCC_PaintMiniatures()
			: base(new ConsoleCommandPiece(optional: false, "/paint"))
		{
		}

		protected override void OnCommandValidated(ValidCommand validCommand)
		{
			base.OnCommandValidated(validCommand);
			Collection.DebugPaintAllMiniatures();
		}
	}
}
