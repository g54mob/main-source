using UnityEngine;
using UnityEngine.EventSystems;

public class WindowResizer : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, ICursorOverride
{
	public GUIWindow Parent;

	public RectTransform Self;

	public string CursorOverrideName
	{
		get
		{
			Vector2 localPoint;
			if (Parent.CanSize && RectTransformUtility.ScreenPointToLocalPointInRectangle(Self, Input.mousePosition, UICamSize.GetUICam(), out localPoint))
			{
				localPoint = new Vector2(localPoint.x + Self.pivot.x * Self.rect.width, Self.rect.height - localPoint.y - Self.pivot.y * Self.rect.height);
				if (localPoint.y > 24f && localPoint.y < Self.rect.height - 24f && (localPoint.x < 8f || localPoint.x > Self.rect.width - 8f))
				{
					return "HorizontalStretch";
				}
				if (localPoint.x > 24f && localPoint.x < Self.rect.width - 24f && localPoint.y > Self.rect.height - 8f)
				{
					return "VerticalStretch";
				}
			}
			return null;
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		Vector2 localPoint;
		if (!Parent.CanSize || !RectTransformUtility.ScreenPointToLocalPointInRectangle(Self, Input.mousePosition, UICamSize.GetUICam(), out localPoint))
		{
			return;
		}
		localPoint = new Vector2(localPoint.x + Self.pivot.x * Self.rect.width, Self.rect.height - localPoint.y - Self.pivot.y * Self.rect.height);
		if (localPoint.y > 24f && localPoint.y < Self.rect.height - 24f)
		{
			if (localPoint.x < 8f)
			{
				Parent.BeginSize(true, false, true);
				return;
			}
			if (localPoint.x > Self.rect.width - 8f)
			{
				Parent.BeginSize(true, false, false);
				return;
			}
		}
		if (localPoint.x > 24f && localPoint.x < Self.rect.width - 24f && localPoint.y > Self.rect.height - 8f)
		{
			Parent.BeginSize(false, true, false);
		}
	}
}
