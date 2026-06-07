using Rewired;
using UnityEngine;

public class ScrollArea : MonoBehaviour
{
	public UIFrame target;

	[Range(0f, 1f)]
	public float scrollValue;

	public RectTransform mask;

	public RectTransform content;

	public RectTransform scrollBarBackground;

	public RectTransform scrollBarBlock;

	public int startToScrollAfterElement = 4;

	public float dampTime = 0.5f;

	private float endBuffer = 50f;

	private Vector2 initialContentPosition;

	private float desiredScrollValue;

	private float scrollVelocityRef;

	private Player input;

	private void Start()
	{
		initialContentPosition = content.anchoredPosition;
		input = ReInput.players.GetPlayer(0);
	}

	private void Update()
	{
		if (UIFrameManager.instance.ActiveFrame == target)
		{
			desiredScrollValue -= Input.mouseScrollDelta.y;
			if (desiredScrollValue > 1f)
			{
				desiredScrollValue = 1f;
			}
			else if (desiredScrollValue < 0f)
			{
				desiredScrollValue = 0f;
			}
		}
		endBuffer = mask.rect.height * 0.2f;
		float num = content.rect.height - mask.rect.height;
		if (num < 0f)
		{
			num = 0f;
		}
		if (num != 0f)
		{
			num += endBuffer;
		}
		if (num == 0f)
		{
			scrollBarBackground.gameObject.SetActive(value: false);
		}
		else
		{
			scrollBarBackground.gameObject.SetActive(value: true);
		}
		scrollBarBlock.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, scrollBarBackground.rect.height * (mask.rect.height / (content.rect.height + endBuffer)));
		float num2 = scrollBarBackground.rect.height - scrollBarBlock.rect.height;
		scrollValue = Mathf.SmoothDamp(scrollValue, desiredScrollValue, ref scrollVelocityRef, dampTime, float.PositiveInfinity, Time.unscaledDeltaTime);
		content.anchoredPosition = new Vector2(initialContentPosition.x, initialContentPosition.y + num * scrollValue);
		scrollBarBlock.anchoredPosition = new Vector2(0f, (0f - num2) * scrollValue);
	}

	public void OnNewSelection()
	{
		ScrollElementID component = target.CurrentSelection.GetComponent<ScrollElementID>();
		if (component == null)
		{
			desiredScrollValue = 0f;
			return;
		}
		int num = content.childCount - 1;
		desiredScrollValue = Mathf.InverseLerp(startToScrollAfterElement, num, component.id);
	}

	public void OnDragStart()
	{
		desiredScrollValue = scrollValue;
	}

	public void OnDrag(Vector2 point)
	{
		SetValueByScreenPoint(point);
	}

	public void OnDragEnd()
	{
	}

	public void SetValueByScreenPoint(Vector2 point)
	{
		RectTransformUtility.ScreenPointToLocalPointInRectangle(scrollBarBackground, input.controllers.Mouse.screenPosition, null, out point);
		float height = scrollBarBackground.rect.height;
		if (point.y < (0f - height) / 2f)
		{
			point.y = (0f - height) / 2f;
		}
		if (point.y > height / 2f)
		{
			point.y = height / 2f;
		}
		scrollValue = Mathf.InverseLerp(height / 2f, (0f - height) / 2f, point.y);
		desiredScrollValue = scrollValue;
	}
}
