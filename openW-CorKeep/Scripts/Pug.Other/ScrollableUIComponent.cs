using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;

public class ScrollableUIComponent : UIComponentMonoBehaviour
{
	public float width;

	public float height;

	public float scrollMultiplierSpeedMouse = 1f;

	public float scrollMultiplierSpeedJoystick = 0.3f;

	private float scrollPosition;

	[CanBeNull]
	private UIComponentMonoBehaviour child;

	private float scrollableHeight;

	protected override bool IsUIComponentRenderingDependentOnChildren()
	{
		return false;
	}

	public override float GetUIComponentRenderWidth()
	{
		return width;
	}

	public override float GetUIComponentRenderHeight()
	{
		return height;
	}

	private void LateUpdate()
	{
		List<UIComponentMonoBehaviour> directUIComponentChildren = GetDirectUIComponentChildren();
		if (directUIComponentChildren.Count != 1)
		{
			Debug.LogError("ScrollableUIComponent must have one child");
			return;
		}
		bool num = !Manager.input.SystemPrefersKeyboardAndMouse();
		child = directUIComponentChildren[0];
		scrollableHeight = child.GetUIComponentRenderHeight();
		scrollableHeight -= height;
		float num2 = 0f;
		float num3 = 0f;
		num2 = 0f - Manager.input.GetScrollValue();
		num3 = scrollMultiplierSpeedMouse;
		if (num)
		{
			num3 = scrollMultiplierSpeedJoystick;
			num2 *= Time.unscaledDeltaTime * 50f;
		}
		MoveScroll(num2 * num3);
	}

	public void MoveScroll(float scrollValue)
	{
		if (!(child == null))
		{
			float target = scrollPosition + scrollValue;
			ScrollTo(target, 0f, scrollIntoView: false);
		}
	}

	public void ScrollTo(float target, float targetHeight = 0f, bool scrollIntoView = true)
	{
		if (child == null)
		{
			return;
		}
		if (scrollIntoView)
		{
			float num = scrollPosition;
			float num2 = scrollPosition + height;
			bool num3 = target < num;
			bool flag = target + targetHeight > num2;
			if (!num3 && !flag)
			{
				return;
			}
			if (flag)
			{
				target = target + targetHeight - height;
			}
		}
		scrollPosition = math.clamp(target, 0f, scrollableHeight);
		float y = scrollPosition - scrollPosition % 0.0625f;
		Transform obj = child.transform;
		Vector3 localPosition = obj.localPosition;
		obj.localPosition = new Vector3(localPosition.x, y, localPosition.z);
		Manager.ui.mouse.PlaceMousePositionOnSelectedUIElementWhenControlledByJoystick();
	}

	public void ScrollToTop()
	{
		MoveScroll(0f - scrollableHeight);
	}

	public void ScrollToBottom()
	{
		MoveScroll(scrollableHeight);
	}
}
