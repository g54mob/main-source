using UnityEngine;
using UnityEngine.UI;

public class ContentSizeFitterEx : ContentSizeFitter
{
	public Vector2 sizeMin;

	public Vector2 sizeMax;

	protected override void OnRectTransformDimensionsChange()
	{
	}

	public void ForceUpdate()
	{
	}

	public override void SetLayoutHorizontal()
	{
	}

	public override void SetLayoutVertical()
	{
	}
}
