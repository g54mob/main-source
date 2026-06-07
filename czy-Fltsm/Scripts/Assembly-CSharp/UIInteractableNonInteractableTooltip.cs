using I2.Loc;
using UnityEngine;

[RequireComponent(typeof(UIInteractable))]
public class UIInteractableNonInteractableTooltip : NonInteractableTooltipBase
{
	[SerializeField]
	private UIInteractable _uiInteractable;

	protected override bool Interactable
	{
		get
		{
			if ((bool)_uiInteractable)
			{
				return _uiInteractable.IsInteractable;
			}
			return false;
		}
	}

	protected override bool TryGetMessage(out LocalizedString message)
	{
		if ((bool)_uiInteractable)
		{
			message = _uiInteractable.NonInteractableTooltipMessage;
			return (string)message != null;
		}
		message = null;
		return false;
	}
}
