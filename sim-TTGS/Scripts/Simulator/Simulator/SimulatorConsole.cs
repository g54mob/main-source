using Dhs5.Utility.Console;

namespace Simulator
{
	public class SimulatorConsole : OnScreenConsole
	{
		private InputManager.EMap m_previousMap;

		protected override void OnOpenConsole()
		{
			base.OnOpenConsole();
			m_previousMap = TransientManager<InputManager>.Instance.CurrentMap;
			TransientManager<InputManager>.Instance.SetMap(InputManager.EMap.NONE);
			TransientManager<InputManager>.Instance.SetCursorActive(active: true);
		}

		protected override void OnCloseConsole()
		{
			base.OnCloseConsole();
			TransientManager<InputManager>.Instance.SetCursorActive(active: false);
			TransientManager<InputManager>.Instance.SetMap(m_previousMap);
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			ScriptedConsoleCommand scriptedConsoleCommand = new SCC_MoneyGain();
			BaseOnScreenConsole<OnScreenConsole>.Register(scriptedConsoleCommand, scriptedConsoleCommand.Callback);
			scriptedConsoleCommand = new SCC_Timescale();
			BaseOnScreenConsole<OnScreenConsole>.Register(scriptedConsoleCommand, scriptedConsoleCommand.Callback);
			scriptedConsoleCommand = new SCC_Delivery();
			BaseOnScreenConsole<OnScreenConsole>.Register(scriptedConsoleCommand, scriptedConsoleCommand.Callback);
			scriptedConsoleCommand = new SCC_ShopLevel();
			BaseOnScreenConsole<OnScreenConsole>.Register(scriptedConsoleCommand, scriptedConsoleCommand.Callback);
			scriptedConsoleCommand = new SCC_ShopExtension();
			BaseOnScreenConsole<OnScreenConsole>.Register(scriptedConsoleCommand, scriptedConsoleCommand.Callback);
			scriptedConsoleCommand = new SCC_ReserveExtension();
			BaseOnScreenConsole<OnScreenConsole>.Register(scriptedConsoleCommand, scriptedConsoleCommand.Callback);
			scriptedConsoleCommand = new SCC_XP();
			BaseOnScreenConsole<OnScreenConsole>.Register(scriptedConsoleCommand, scriptedConsoleCommand.Callback);
			scriptedConsoleCommand = new SCC_PurchaseProbaTest();
			BaseOnScreenConsole<OnScreenConsole>.Register(scriptedConsoleCommand, scriptedConsoleCommand.Callback);
			scriptedConsoleCommand = new SCC_DayCycleTimescale();
			BaseOnScreenConsole<OnScreenConsole>.Register(scriptedConsoleCommand, scriptedConsoleCommand.Callback);
			scriptedConsoleCommand = new SCC_DayTime();
			BaseOnScreenConsole<OnScreenConsole>.Register(scriptedConsoleCommand, scriptedConsoleCommand.Callback);
		}
	}
}
