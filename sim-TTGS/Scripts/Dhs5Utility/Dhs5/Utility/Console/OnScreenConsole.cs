using UnityEngine;

namespace Dhs5.Utility.Console
{
	public class OnScreenConsole : BaseOnScreenConsole<OnScreenConsole>
	{
		protected override int GetInputFontSize()
		{
			return OnScreenConsoleSettings.InputFontSize;
		}

		protected override Color GetInputTextColor()
		{
			return OnScreenConsoleSettings.InputTextColor;
		}

		protected override Color GetValidInputTextColor()
		{
			return OnScreenConsoleSettings.InputValidTextColor;
		}

		protected override int GetOptionFontSize()
		{
			return OnScreenConsoleSettings.OptionFontSize;
		}

		protected override Color GetOptionTextColor()
		{
			return OnScreenConsoleSettings.OptionTextColor;
		}

		protected override float GetInputRectHeight()
		{
			return OnScreenConsoleSettings.InputRectHeight;
		}

		protected override float GetOptionRectHeight()
		{
			return OnScreenConsoleSettings.OptionRectHeight;
		}

		protected override int GetMaxOptionsDisplayed()
		{
			return OnScreenConsoleSettings.MaxOptionsDisplayed;
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			RegisterPredefinedCommands(register: true);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			RegisterPredefinedCommands(register: false);
		}

		protected override void InitInputs()
		{
			if (OnScreenConsoleSettings.HasOpenConsoleInput(out var action))
			{
				m_openConsoleAction = action;
			}
			if (OnScreenConsoleSettings.HasCloseConsoleInput(out var action2))
			{
				m_closeConsoleAction = action2;
			}
			base.InitInputs();
		}

		private void RegisterPredefinedCommands(bool register)
		{
			if (register)
			{
				foreach (PredefinedConsoleCommand predefinedCommand in OnScreenConsoleSettings.PredefinedCommands)
				{
					RegisterCommand(predefinedCommand, predefinedCommand.Callback);
				}
				return;
			}
			foreach (PredefinedConsoleCommand predefinedCommand2 in OnScreenConsoleSettings.PredefinedCommands)
			{
				UnregisterCommand(predefinedCommand2, predefinedCommand2.Callback);
			}
		}
	}
}
