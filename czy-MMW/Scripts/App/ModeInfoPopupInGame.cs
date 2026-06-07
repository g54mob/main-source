using UnityEngine;

public class ModeInfoPopupInGame : ModeInfoPopup
{
	[SerializeField]
	private float BlurOffsetOverrideDay = 0.6f;

	[SerializeField]
	private float BlurOffsetOverrideNight = 0.35f;

	public override void OnOpened(float delay)
	{
		_popupParent.SetTempOffset(BlurOffsetOverrideDay, BlurOffsetOverrideNight);
		base.OnOpened(delay);
	}

	public override void OnPopupClosed()
	{
		_popupParent.ClearTempRange();
		base.OnPopupClosed();
	}
}
