using UnityEngine;

public class CoolDepthButton : CoolButton
{
	public RectTransform XfmContent;

	private Vector2 _defaultOffsetMin;

	private Vector2 _defaultOffsetMax;

	protected override void Awake()
	{
	}

	public override void SetButtonState(CoolButtonState btnState, bool force)
	{
	}
}
