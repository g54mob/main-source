using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Scrollable : MonoBehaviour
{
	private Canvas canvas;

	private const float extraBorder = 0f;

	private PageTemplate pageTemplate;

	private int screenHeight
	{
		get
		{
			return 360;
		}
	}

	private void Awake()
	{
		canvas = GetComponentInParent<Canvas>();
		pageTemplate = base.gameObject.GetComponentInParentAnyActive<PageTemplate>();
	}

	private void Update()
	{
		if (!pageTemplate.interactable)
		{
			return;
		}
		if (RInput.mouseIsActive)
		{
			ApplyWheelMovement(-300f * Clock.menu.deltaTime * RInput.GetAxis(49));
			Vector2 posInCanvas = MouseCursor.GetPosInCanvas();
			posInCanvas = ApplyCursorMovement(posInCanvas);
			MouseCursor.SetPosInCanvas(posInCanvas);
		}
		else
		{
			if (LocReview.active)
			{
				return;
			}
			Selectable currentSelectable = SelectionHelper.GetCurrentSelectable();
			if (currentSelectable == null)
			{
				return;
			}
			Vector3 vector = canvas.transform.worldToLocalMatrix.MultiplyPoint(currentSelectable.transform.position);
			if (RInput.GetButtonRepeating(38))
			{
				Selectable nextSelectableNeighbor = SelectionHelper.GetNextSelectableNeighbor(currentSelectable, MoveDirection.Down, 3);
				if (nextSelectableNeighbor != null)
				{
					SelectionHelper.SetCurrent(nextSelectableNeighbor);
				}
			}
			else if (RInput.GetButtonRepeating(37))
			{
				Selectable nextSelectableNeighbor2 = SelectionHelper.GetNextSelectableNeighbor(currentSelectable, MoveDirection.Up, 3);
				if (nextSelectableNeighbor2 != null)
				{
					SelectionHelper.SetCurrent(nextSelectableNeighbor2);
				}
			}
			ApplyCursorMovement(vector);
		}
	}

	private Vector2 ApplyCursorMovement(Vector2 cursorPosInCanvas)
	{
		RectTransform rectTransform = base.transform as RectTransform;
		float y = rectTransform.anchoredPosition.y;
		float f = y;
		float num = (float)(screenHeight / 2) - 80f;
		float num2 = 0f - ((float)(screenHeight / 2) - 80f);
		if (cursorPosInCanvas.y > num)
		{
			f = Mathf.Max(0f, y - (cursorPosInCanvas.y - num));
		}
		if (cursorPosInCanvas.y < num2)
		{
			f = Mathf.Min(rectTransform.sizeDelta.y - (float)screenHeight, y + (num2 - cursorPosInCanvas.y));
		}
		f = Mathf.Round(f);
		y = Mathf.Round(y);
		rectTransform.anchoredPosition = new Vector2(0f, f);
		cursorPosInCanvas.y += f - y;
		return cursorPosInCanvas;
	}

	private void ApplyWheelMovement(float delta)
	{
		if (!(Mathf.Abs(delta) < 0.001f))
		{
			if (delta < 0f && delta > -1f)
			{
				delta = -1f;
			}
			else if (delta > 0f && delta < 1f)
			{
				delta = 1f;
			}
			RectTransform rectTransform = base.transform as RectTransform;
			float y = rectTransform.anchoredPosition.y;
			y = Mathf.Max(-0f, Mathf.Min(rectTransform.sizeDelta.y - (float)screenHeight, y + delta));
			y = Mathf.Round(y);
			rectTransform.anchoredPosition = new Vector2(0f, y);
		}
	}
}
