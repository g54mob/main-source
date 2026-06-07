using UnityEngine;

namespace CommandTerminal
{
	public class TerminalKeyboardHandler : MonoBehaviour
	{
		private Terminal terminal;

		private void OnEnable()
		{
			if (terminal == null)
			{
				terminal = GetComponent<Terminal>();
			}
			Terminal.Buffer = new CommandLog(terminal.BufferSize);
			Terminal.Shell = new CommandShell();
			Terminal.History = new CommandHistory();
			Terminal.Autocomplete = new CommandAutocomplete();
			Application.logMessageReceivedThreaded += terminal.HandleUnityLog;
		}

		private void OnDisable()
		{
			Application.logMessageReceivedThreaded -= terminal.HandleUnityLog;
		}

		private void Update()
		{
			if (!terminal.inputProvider.GetButtonDown())
			{
				return;
			}
			bool flag = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
			if (!terminal.enabled)
			{
				terminal.enabled = true;
				if (flag)
				{
					terminal.SetState(TerminalState.OpenFull);
				}
				else
				{
					terminal.SetState(TerminalState.OpenSmall);
				}
				terminal.initial_open = true;
			}
			else if (flag)
			{
				terminal.ToggleState(TerminalState.OpenFull);
			}
			else
			{
				terminal.SetState(TerminalState.Close);
			}
		}
	}
}
