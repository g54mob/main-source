using CommandTerminal;
using DV.Interaction.Inputs;
using Rewired;
using UnityEngine;

public class ConsoleHotkeySetter : TerminalKeyboardInputProvider
{
	private Terminal terminal;

	private void Awake()
	{
		terminal = GetComponent<Terminal>();
		if (terminal == null)
		{
			Debug.LogError("Unexpected state: Couldn't extract terminal, destroying self.");
			Object.Destroy(this);
		}
		else
		{
			terminal.inputProvider = this;
		}
	}

	public override bool GetButtonDown()
	{
		if (!ReInput.isReady)
		{
			return false;
		}
		return DV.Interaction.Inputs.InputManager.NewPlayer.GetButtonDown(DV.Interaction.Inputs.InputManager.Actions.Console);
	}

	public override void SetTerminalOpen(bool open)
	{
		DV.Interaction.Inputs.InputManager.SetAllMapsBesidesPredicateEnabled((ControllerMap m) => m.categoryId == 1, !open);
	}
}
