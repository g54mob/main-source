using System;
using PixelCrushers.DialogueSystem;
using Restory.Gameplay.DemoEnd;
using Zenject;

namespace Restory.Scripts.Restory.UI.LuaWrappers
{
	public class GuiFromDialogueControllingLuaWrappers : IInitializable, IDisposable
	{
		private static class LuaNames
		{
			public static readonly string ShowDemoEndWindow = "GUI_ShowDemoEndWindowAfterConversation";
		}

		private readonly DemoEndWindowSwitcher demoEndWindowSwitcher;

		public GuiFromDialogueControllingLuaWrappers(DemoEndWindowSwitcher demoEndWindowSwitcher)
		{
			this.demoEndWindowSwitcher = demoEndWindowSwitcher;
		}

		public void Initialize()
		{
			Subscribe();
		}

		public void Dispose()
		{
			Unsubscribe();
		}

		private void Subscribe()
		{
			Lua.RegisterFunction(LuaNames.ShowDemoEndWindow, this, SymbolExtensions.GetMethodInfo(() => ShowDemoEndWindowAfterConversationEnds()));
		}

		private void Unsubscribe()
		{
			Lua.UnregisterFunction(LuaNames.ShowDemoEndWindow);
		}

		private void ShowDemoEndWindowAfterConversationEnds()
		{
			demoEndWindowSwitcher.PrepareToShowGameEndWindowAfterConversationEnds();
		}
	}
}
