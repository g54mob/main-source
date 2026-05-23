using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIParentResizer : MonoBehaviour
{
	public enum Mode
	{
		Vertical = 0
	}

	public Mode mode;

	public float minHeight;

	public float padding = 30f;

	public List<RectTransform> observedElements;

	private RectTransform ownRT;

	private bool dirty;

	public void Trigger()
	{
		dirty = true;
	}

	private void Resize()
	{
		if (ownRT == null)
		{
			ownRT = GetComponent<RectTransform>();
		}
		float num = 0f;
		foreach (RectTransform observedElement in observedElements)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(observedElement);
			num += observedElement.sizeDelta.y;
		}
		if (num < minHeight)
		{
			num = minHeight;
		}
		ownRT.sizeDelta = new Vector2(ownRT.sizeDelta.x, num + 2f * padding);
	}

	private void LateUpdate()
	{
		if (dirty)
		{
			Resize();
			dirty = false;
		}
	}
}
