using CTS;
using CTS.Core;
using UnityEngine.InputSystem;

public class ConstructionSystemExit : CTSBehaviour
{
	protected override void OnEnabled()
	{
		base.OnEnabled();
		InputManager.pause.pause.onComplete += OnPauseInput;
	}

	protected override void OnDisabled()
	{
		base.OnDisabled();
		InputManager.pause.pause.onComplete -= OnPauseInput;
	}

	private void OnPauseInput(InputAction.CallbackContext ctx)
	{
		if (MonoSingleton<ConstructionSystem>.Instance.CurrentMode != EConstructionMode.None)
		{
			if (WorldSelector.IsAnythingSelected())
			{
				WorldSelector.DeselectAll();
			}
			else
			{
				MonoSingleton<UI_ConstructionSystem>.Instance.CloseConstructionFromAnywhere();
			}
		}
	}
}
