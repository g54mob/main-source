using System;
using UnityEngine;
using UnityEngine.UI;

public class HighlightEffect : MonoBehaviour
{
	private bool kicked;

	private float startTime = -1f;

	private LayoutGroup layoutGroup;

	private RectOffset defaultPadding;

	private static int suppressedUntilFrame;

	public static void SupressForOneFrame()
	{
		suppressedUntilFrame = Time.frameCount + 1;
	}

	private void OnEnable()
	{
		if (layoutGroup == null)
		{
			layoutGroup = GetComponent<LayoutGroup>();
			defaultPadding = layoutGroup.padding;
		}
		Stop();
	}

	private void OnDisable()
	{
		Stop();
	}

	private void Update()
	{
		if (startTime < 0f)
		{
			return;
		}
		if (suppressedUntilFrame >= Time.frameCount)
		{
			Stop();
			return;
		}
		float num = (Clock.menu.time - startTime) / 0.2f;
		if (base.gameObject == SelectionHelper.GetCurrentGameObject() && num < 1f)
		{
			Apply(num);
		}
		else
		{
			Stop();
		}
	}

	private void Apply(float age_)
	{
		RectOffset rectOffset = new RectOffset(defaultPadding.left, defaultPadding.right, defaultPadding.top, defaultPadding.bottom);
		int num = Mathf.FloorToInt(Mathf.Sin(age_ * (float)Math.PI * 3f) * 8f);
		rectOffset.left += num;
		rectOffset.right -= num;
		layoutGroup.padding = rectOffset;
	}

	public void Kick()
	{
		if (!kicked)
		{
			startTime = Clock.menu.time;
		}
	}

	private void Stop()
	{
		if (startTime >= 0f)
		{
			Apply(0f);
		}
		kicked = false;
		startTime = -1f;
	}
}
