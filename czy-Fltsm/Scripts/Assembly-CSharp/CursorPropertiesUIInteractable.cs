using I2.Loc;
using UnityEngine;

public class CursorPropertiesUIInteractable : UIInteractable
{
	[SerializeField]
	private CursorProperties _cursorProperties;

	[SerializeField]
	protected LocalizedString _tooltipMessageDefault;

	[SerializeField]
	protected LocalizedString _tooltipMessageActive;

	public override void Interact()
	{
		if (GameManager.CursorManager.Properties == _cursorProperties)
		{
			if (_cursorProperties.CanBeDeactivated)
			{
				GameManager.CursorManager.Deactivate(cancelled: true);
			}
			else
			{
				_cursorProperties.DisplayExitPanel();
			}
			return;
		}
		base.Interact();
		GameManager.CursorManager.Activate(_cursorProperties, InvokeOnTrigger);
		if (_linkedSelectable is TooltipButton tooltipButton)
		{
			tooltipButton.SetTooltipMessage(_tooltipMessageActive);
		}
	}

	private void InvokeOnTrigger(CursorProperties cursorProperties, bool cancelled)
	{
		if (cancelled)
		{
			if (_linkedSelectable is TooltipButton tooltipButton)
			{
				tooltipButton.SetTooltipMessage(_tooltipMessageDefault);
			}
			base.OnTrigger.Invoke();
		}
	}

	public void DisplayExitPanel()
	{
		_cursorProperties.DisplayExitPanel();
	}
}
