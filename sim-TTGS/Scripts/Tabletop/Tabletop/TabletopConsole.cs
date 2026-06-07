using Dhs5.Utility.Console;
using Simulator;
using Tabletop.GameWorld;

namespace Tabletop
{
	public class TabletopConsole : SimulatorConsole
	{
		protected override void OnOpenConsole()
		{
			base.OnOpenConsole();
			TransientManager<InputManager>.Instance.UseCursor(useCursor: true);
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			ScriptedConsoleCommand scriptedConsoleCommand = new SCC_UnpackMiniatures();
			BaseOnScreenConsole<OnScreenConsole>.Register(scriptedConsoleCommand, scriptedConsoleCommand.Callback);
			scriptedConsoleCommand = new SCC_Wargame();
			BaseOnScreenConsole<OnScreenConsole>.Register(scriptedConsoleCommand, scriptedConsoleCommand.Callback);
			scriptedConsoleCommand = new SCC_AssembleMiniatures();
			BaseOnScreenConsole<OnScreenConsole>.Register(scriptedConsoleCommand, scriptedConsoleCommand.Callback);
			scriptedConsoleCommand = new SCC_PaintMiniatures();
			BaseOnScreenConsole<OnScreenConsole>.Register(scriptedConsoleCommand, scriptedConsoleCommand.Callback);
			scriptedConsoleCommand = new SCC_PrepareWargame();
			BaseOnScreenConsole<OnScreenConsole>.Register(scriptedConsoleCommand, scriptedConsoleCommand.Callback);
			scriptedConsoleCommand = new SCC_PreparePainting();
			BaseOnScreenConsole<OnScreenConsole>.Register(scriptedConsoleCommand, scriptedConsoleCommand.Callback);
			scriptedConsoleCommand = new SCC_CollectAllPieces();
			BaseOnScreenConsole<OnScreenConsole>.Register(scriptedConsoleCommand, scriptedConsoleCommand.Callback);
			scriptedConsoleCommand = new SCC_CollectPieces();
			BaseOnScreenConsole<OnScreenConsole>.Register(scriptedConsoleCommand, scriptedConsoleCommand.Callback);
		}
	}
}
