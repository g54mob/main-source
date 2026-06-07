using Dhs5.Utility.Console;

namespace Tabletop.GameWorld
{
	public class SCC_AssembleMiniatures : ScriptedConsoleCommand
	{
		public SCC_AssembleMiniatures()
			: base(new ConsoleCommandPiece(optional: false, "/assemble"))
		{
		}

		protected override void OnCommandValidated(ValidCommand validCommand)
		{
			base.OnCommandValidated(validCommand);
			Collection.DebugAssembleAllMiniatures();
		}
	}
}
