using UnityEngine;

public class CoolRectButton : CoolButton
{
	[NamedArray(typeof(CoolButtonState))]
	public RectTransform[] Overlays;

	protected override void Awake()
	{
	}

	public override void SetButtonState(CoolButtonState btnState, bool force)
	{
	}
}
