using UnityEngine;
using UnityEngine.EventSystems;

public class RetroUITextInput_DefaultInputManager : RetroUITextInput_InputManager
{
	private enum ActionType
	{
		None = 0,
		Insert = 1,
		Delete = 2,
		Backspace = 3,
		Cut = 4,
		Paste = 5
	}

	private static readonly char[] kSeparators;

	private ActionType lastActionType;

	private RetroUIText.TextCoord? lastCaretPosition;

	public RetroUITextInput_DefaultInputManager(RetroUITextInput textInput, IListener listener)
	{
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
	}

	public override void OnSelect(BaseEventData eventData)
	{
	}

	public override void OnDeselect(BaseEventData eventData)
	{
	}

	public override void OnUpdateSelected(BaseEventData eventData)
	{
	}

	public override void OnSetReadOnly(bool readOnly)
	{
	}

	public override bool CommandEvent(Event m_ProcessingEvent)
	{
		return false;
	}

	public override RetroUITextInput.EditState KeyPressed(Event evt)
	{
		return default(RetroUITextInput.EditState);
	}

	private int FindNextWordBegin(RetroUIText.TextCoord coord)
	{
		return 0;
	}

	private int FindPrevWordBegin(RetroUIText.TextCoord coord)
	{
		return 0;
	}

	public override void OnBeginDrag(PointerEventData eventData)
	{
	}

	public override void OnDrag(PointerEventData eventData)
	{
	}

	public override void OnEndDrag(PointerEventData eventData)
	{
	}

	public override void OnPointerDown(PointerEventData eventData)
	{
	}
}
