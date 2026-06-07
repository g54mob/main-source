using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollToContent : MonoBehaviour, ISelectHandler, IEventSystemHandler, IPointerDownHandler
{
	[Tooltip("If turned off then it will do nothing.")]
	public new bool enabled = true;

	public bool scrollOnEnable;

	public bool onlyGamepad;

	[Tooltip("If true, selecting with mouse will not scroll.")]
	public bool disableMouse = true;

	[Tooltip("Additional margins in clockwise order: TOP, RIGHT, BOTTOM, LEFT")]
	public Vector4 MarginTRBL;

	private bool selectedByMouse;

	public void OnEnable()
	{
		if (scrollOnEnable)
		{
			CheckConditions();
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		selectedByMouse = true;
	}

	public void OnSelect(BaseEventData eventData)
	{
		CheckConditions();
	}

	private void CheckConditions()
	{
		if (!enabled || (onlyGamepad && InputDetection.Instance != null && !InputDetection.Instance.GamepadEnabled))
		{
			return;
		}
		if (disableMouse && selectedByMouse)
		{
			selectedByMouse = false;
			return;
		}
		selectedByMouse = false;
		ScrollRect componentInParent = GetComponentInParent<ScrollRect>();
		if (componentInParent != null)
		{
			BringChildIntoView(componentInParent, base.transform as RectTransform, MarginTRBL);
		}
	}

	public static void BringChildIntoView(ScrollRect instance, RectTransform child, Vector4 margin)
	{
		instance.content.ForceUpdateRectTransforms();
		instance.viewport.ForceUpdateRectTransforms();
		Rect rect = TransformRectFrom(instance.viewport, child);
		rect.xMin -= margin[3];
		rect.xMax += margin[1];
		rect.yMin -= margin[2];
		rect.yMax += margin[0];
		Rect rect2 = instance.viewport.rect;
		Vector3 localPosition = instance.content.localPosition;
		bool flag = false;
		float num = rect2.xMin - rect.xMin;
		if (num > 0.001f)
		{
			localPosition.x += num;
			flag = true;
		}
		float num2 = rect2.xMax - rect.xMax;
		if (num2 < -0.001f)
		{
			localPosition.x += num2;
			flag = true;
		}
		float num3 = rect2.yMin - rect.yMin;
		if (num3 > 0.001f)
		{
			localPosition.y += num3;
			flag = true;
		}
		float num4 = rect2.yMax - rect.yMax;
		if (num4 < -0.001f)
		{
			localPosition.y += num4;
			flag = true;
		}
		if (flag)
		{
			instance.content.localPosition = localPosition;
			instance.content.ForceUpdateRectTransforms();
		}
	}

	public static Rect TransformRectFrom(Transform to, Transform from)
	{
		RectTransform component = from.GetComponent<RectTransform>();
		RectTransform component2 = to.GetComponent<RectTransform>();
		if (component != null && component2 != null)
		{
			Vector3[] array = new Vector3[4];
			Vector3[] array2 = new Vector3[4];
			Matrix4x4 worldToLocalMatrix = to.worldToLocalMatrix;
			component.GetWorldCorners(array);
			for (int i = 0; i < 4; i++)
			{
				array2[i] = worldToLocalMatrix.MultiplyPoint3x4(array[i]);
			}
			return new Rect(array2[0].x, array2[0].y, array2[2].x - array2[1].x, array2[1].y - array2[0].y);
		}
		return default(Rect);
	}
}
