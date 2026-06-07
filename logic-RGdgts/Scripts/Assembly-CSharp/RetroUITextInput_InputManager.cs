using UnityEngine;
using UnityEngine.EventSystems;

public abstract class RetroUITextInput_InputManager
{
	public interface IListener
	{
		void OnNewLine(RetroUITextInput_InputManager inputManager);

		void OnInsertFromKeyboard(RetroUITextInput_InputManager inputManager);

		void OnAutocompleteRequest(RetroUITextInput_InputManager inputManager);
	}

	protected RetroUITextInput textInput;

	protected IListener listener;

	public CodeEditorPopup popup;

	public abstract void OnBeginDrag(PointerEventData eventData);

	public abstract void OnDrag(PointerEventData eventData);

	public abstract void OnEndDrag(PointerEventData eventData);

	public abstract void OnPointerDown(PointerEventData eventData);

	public abstract void OnPointerClick(PointerEventData eventData);

	public abstract void OnSelect(BaseEventData eventData);

	public abstract void OnDeselect(BaseEventData eventData);

	public abstract void OnSetReadOnly(bool readOnly);

	public abstract void OnUpdateSelected(BaseEventData eventData);

	public abstract RetroUITextInput.EditState KeyPressed(Event evt);

	public abstract bool CommandEvent(Event evt);

	public virtual void OnEndEditCommandBar()
	{
	}

	public virtual void OnSubmitCommandBar(string text)
	{
	}

	protected virtual bool IsValidChar(char c)
	{
		return false;
	}

	protected void OnNewLineInput()
	{
	}
}
