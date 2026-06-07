using Dhs5.Utility.Console;

namespace Tabletop.GameWorld
{
	public class SCC_Wargame : ScriptedConsoleCommand
	{
		public SCC_Wargame()
			: base(new ConsoleCommandPiece(optional: false, "/wargame"))
		{
		}

		protected override void OnCommandValidated(ValidCommand validCommand)
		{
			base.OnCommandValidated(validCommand);
			BaseOnScreenConsole<OnScreenConsole>.Close();
			TabletopWorld.WargameManager.StartDebugWargame();
		}
	}
}
