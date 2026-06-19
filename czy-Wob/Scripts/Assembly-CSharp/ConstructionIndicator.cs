using UnityEngine;

public class ConstructionIndicator : MonoBehaviour
{
	public bool canHighlight = true;

	public Color standardColor;

	public Color highlightedColor;

	public SpriteRenderer mainSpriteRenderer;

	public CursorController.CursorType mouseOverCursorType = CursorController.CursorType.CLICKABLE;

	private CursorController cursorRef;

	private void Awake()
	{
		if (canHighlight)
		{
			cursorRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<CursorController>(GlobalObject.CURSOR);
		}
	}

	public void Highlight()
	{
		if (canHighlight)
		{
			cursorRef.SetCursor(mouseOverCursorType);
			mainSpriteRenderer.color = highlightedColor;
		}
	}

	public void RemoveHighlight()
	{
		if (canHighlight)
		{
			mainSpriteRenderer.color = standardColor;
		}
	}
}
