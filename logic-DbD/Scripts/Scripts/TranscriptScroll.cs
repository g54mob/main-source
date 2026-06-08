using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TranscriptScroll : Transcript
{
	protected new const int VERTICAL_MARGIN = 90;

	private new const int HORIZONTAL_MARGIN = 75;

	protected const int MAX_HEIGHT = 500;

	public override void Resize()
	{
		RectTransform component = GetComponent<RectTransform>();
		int num = Math.Min(lines * LINE_SIZE + 90, 500);
		component.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, num);
		component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, message.preferredWidth + 75f);
	}

	public override void OpenPanel()
	{
		base.OpenPanel();
		StartCoroutine(OnPanelOpen(0.1f));
	}

	protected virtual IEnumerator OnPanelOpen(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		GetComponentInChildren<ScrollRect>().verticalNormalizedPosition = 1f;
	}
}
