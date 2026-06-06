using I2.Loc;
using UnityEngine;

public class UIInteractableTooltippedToggle : UIInteractableToggle
{
	[SerializeField]
	private Tooltip _tooltip;

	[SerializeField]
	private LocalizedString EnabledTooltip = null;

	[SerializeField]
	private LocalizedString DisabledTooltip = null;

	public override void Toggle(bool toggled, bool sendEvent = false)
	{
		base.Toggle(toggled, sendEvent);
		_tooltip.LocalizedText = (toggled ? EnabledTooltip : DisabledTooltip);
	}
}
