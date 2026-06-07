using UnityEngine;

namespace CommandTerminal
{
	public class TerminalKeyboardInputProviderMock : TerminalKeyboardInputProvider
	{
		public override bool GetButtonDown()
		{
			return Input.GetKeyDown(KeyCode.BackQuote);
		}

		public override void SetTerminalOpen(bool open)
		{
		}
	}
}
