using UnityEngine;
using UnityEngine.UI;

public class TooltipContentSizeFitter : ContentSizeFitter
{
	public override void SetLayoutHorizontal()
	{
		base.SetLayoutHorizontal();
		RectTransform rectTransform = base.transform as RectTransform;
		rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Mathf.Clamp(rectTransform.sizeDelta.x, 0f, 384f));
	}
}
