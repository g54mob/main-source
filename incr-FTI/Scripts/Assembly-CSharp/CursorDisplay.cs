using UnityEngine;

public class CursorDisplay : MonoBehaviour
{
	public Texture2D cursorDefault;

	public Texture2D cursorResizeHorizontal;

	public Texture2D cursorResizeVertical;

	public Texture2D cursorResizeRightCorner;

	public Texture2D cursorResizeLeftCorner;

	public bool isResizingHorizontal;

	public bool isResizingVertical;

	public bool isResizingRightCorner;

	public bool isResizingLeftCorner;

	public void UpdateCursorState()
	{
		if (isResizingHorizontal)
		{
			SetCursor(cursorResizeHorizontal);
		}
		else if (isResizingVertical)
		{
			SetCursor(cursorResizeVertical);
		}
		else if (isResizingLeftCorner)
		{
			SetCursor(cursorResizeLeftCorner);
		}
		else if (isResizingRightCorner)
		{
			SetCursor(cursorResizeRightCorner);
		}
		else
		{
			SetCursor(cursorDefault);
		}
	}

	public void SetCursorDefault()
	{
		isResizingVertical = false;
		isResizingHorizontal = false;
		isResizingLeftCorner = false;
		isResizingRightCorner = false;
		UpdateCursorState();
	}

	public void SetCursorResizeHorizontal()
	{
		isResizingHorizontal = true;
		UpdateCursorState();
	}

	public void SetCursorResizeVertical()
	{
		isResizingVertical = true;
		UpdateCursorState();
	}

	public void SetCursorResizeRightCorner()
	{
		isResizingRightCorner = true;
		UpdateCursorState();
	}

	public void SetCursorResizeLeftCorner()
	{
		isResizingLeftCorner = true;
		UpdateCursorState();
	}

	private void SetCursor(Texture2D cursorTexture)
	{
		if (cursorTexture == cursorDefault)
		{
			Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
			return;
		}
		Vector2 hotspot = new Vector2((float)cursorTexture.width / 2f, (float)cursorTexture.height / 2f);
		Cursor.SetCursor(cursorTexture, hotspot, CursorMode.Auto);
	}
}
