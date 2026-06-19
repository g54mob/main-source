using Aggro.Core;
using UnityEngine;

public class SettingsUI : EntityBehaviourBase, IInputController
{
	public GameObject clickCatch;

	public Transform settingsParent;

	protected override void OnEntityCreated()
	{
		AggroSettings.SetOnClosedCallback(OnClosed);
		clickCatch.SetActive(value: false);
	}

	private void OnClosed()
	{
		clickCatch.SetActive(value: false);
		if (AggroInputManager.IsControllerInStack(this))
		{
			AggroInputManager.RemoveController(this);
		}
	}

	protected override void OnUpdatePresentation()
	{
		if (AggroSettings.isShowing && AggroInputManager.mode != AggroSettings.inputMode)
		{
			AggroSettings.SetInputMode(AggroInputManager.mode);
		}
	}

	public void OpenSettings()
	{
		clickCatch.SetActive(value: true);
		AggroInputManager.PushController(this);
		AggroSettings.ShowSettings("game", settingsParent, AggroInputManager.mode);
	}

	public void CloseSettings()
	{
		AggroSettings.CloseSettings();
	}

	public void OnInputControlGained()
	{
		AggroInputManager.EnableUIModule();
	}

	public void OnInputControlLost()
	{
		AggroInputManager.DisableUIModule();
	}
}
