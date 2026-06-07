using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RetroUITextInput : Selectable, IUpdateSelectedHandler, IEventSystemHandler, IPointerClickHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, RetroUIText.IViewListener
{
	public enum EditState
	{
		Continue = 0,
		Finish = 1
	}

	public RetroUIText uiText;

	public RetroUITextLineNumbers uiLineNumbers;

	public Scrollbar horizontalScrollbar;

	public Scrollbar verticalScrollbar;

	public CodeEditorCommandBar commandBar;

	public RetroLanguageDefinition languageDefinition;

	public float scrollWheelSpeed;

	public bool autoIndent;

	private bool isPointerDown;

	private RetroUIText.TextCoord pointerDownCoord;

	protected bool readOnly;

	private RetroUIText.TextCoord? verticalMovementCaretColumn;

	private RetroUITextUndoQueue undoQueue;

	private static HashSet<char> wordSeparators;

	private static float horizontalDragScrollDelay;

	private static float verticalDragScrollDelay;

	public RetroUITextInput_InputManager inputManager;

	private bool _init;

	private float lastPointerDownTime;

	private RetroUIText.TextCoord lastPointerDownCoord;

	private Event processingEvent;

	private float horizontalScrollChangeTime;

	private float verticalScrollChangeTime;

	protected bool verticalScrollChanged;

	protected bool horizontalScrollChanged;

	public RetroUIText.CaretStyle caretStyle
	{
		get
		{
			return default(RetroUIText.CaretStyle);
		}
		set
		{
		}
	}

	public RetroUIText.CaretBlockStyle caretBlockStyle
	{
		get
		{
			return default(RetroUIText.CaretBlockStyle);
		}
		set
		{
		}
	}

	public RetroUIText.WrapMode wrapMode
	{
		get
		{
			return default(RetroUIText.WrapMode);
		}
		set
		{
		}
	}

	public static string clipboard
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public string text
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public RetroUIText.TextCoord? caretPosition
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public RetroUIText.TextData.Line caretLine => null;

	public RetroUIText.TextAreaCoord? selectionArea
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool hasTextSelection => false;

	private EventSystem eventSystem => null;

	private void SetText(string value)
	{
	}

	protected override void Awake()
	{
	}

	public void Init()
	{
	}

	protected virtual void InitInputManager()
	{
	}

	protected override void Start()
	{
	}

	public RetroUIText.TextData.Line GetLine(int lineIndex)
	{
		return null;
	}

	public RetroUIText.TextData.Line GetLine(RetroUIText.TextCoord coord)
	{
		return null;
	}

	public void Deselect()
	{
	}

	public virtual void ShowCommandBar()
	{
	}

	public virtual void HideCommandBar()
	{
	}

	public override void OnPointerDown(PointerEventData eventData)
	{
	}

	protected virtual void OnLineNumberClick(RetroUIText.TextData.VisibleLine visibleLine)
	{
	}

	public virtual void OnCaretMoved(RetroUIText uiText)
	{
	}

	public virtual void OnVisibleTextChanged(RetroUIText uiText)
	{
	}

	public virtual void OnTextChanged(RetroUIText uiText)
	{
	}

	public virtual void OnNewLineInput()
	{
	}

	public override void OnPointerUp(PointerEventData eventData)
	{
	}

	public void OnDrag(PointerEventData eventData)
	{
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
	}

	public void OnEndDrag(PointerEventData eventData)
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}

	public override void OnSelect(BaseEventData eventData)
	{
	}

	public override void OnDeselect(BaseEventData eventData)
	{
	}

	public virtual void OnUpdateSelected(BaseEventData eventData)
	{
	}

	public RetroUIText.TextCoord GetMaxCoord()
	{
		return default(RetroUIText.TextCoord);
	}

	public void OnHorizontalScrollChange(RetroUIText renderer)
	{
	}

	public void OnVerticalScrollChange(RetroUIText renderer)
	{
	}

	protected virtual void LateUpdate()
	{
	}

	private void UpdateHorizontalScrollbar()
	{
	}

	private void UpdateVerticalScrollbar()
	{
	}

	public RetroUIText.OverlapPoinResult OverlapPoint(Vector2 point)
	{
		return default(RetroUIText.OverlapPoinResult);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool IsValidChar(char c)
	{
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private string ToValidChars(string txt)
	{
		return null;
	}

	public void ReleaseSelection()
	{
	}

	public void SetReadOnly(bool readOnly)
	{
	}

	public void DisableUndoQueue()
	{
	}

	public void EnableUndoQueue()
	{
	}

	public void ClearUndoHistory()
	{
	}

	public void RegisterChangeToUndoHistory()
	{
	}

	public bool DoUndo()
	{
		return false;
	}

	public bool DoRedo()
	{
		return false;
	}

	private bool IsWordChar(char c)
	{
		return false;
	}

	public Tuple<RetroUIText.TextCoord, RetroUIText.TextCoord> GetWord(RetroUIText.TextCoord coord)
	{
		return null;
	}

	public Vector3 GetWorldPosition(RetroUIText.TextCoord textCoord)
	{
		return default(Vector3);
	}

	public void DoSelectAll()
	{
	}

	public void DoBackspace()
	{
	}

	public void DoDeleteSelection()
	{
	}

	public void DoDeleteKey()
	{
	}

	public void DoMoveLeft(bool canChangeLine)
	{
	}

	public void DoMoveRight(bool canChangeLine)
	{
	}

	public void DoMoveUpLine()
	{
	}

	public void DoMoveDownLine()
	{
	}

	public void DoMoveUpVisibleLine()
	{
	}

	public void DoMoveDownVisibleLine()
	{
	}

	public void DoSetCaretPosition(RetroUIText.TextCoord newCoord)
	{
	}

	public void DoCopy()
	{
	}

	public void DoCut()
	{
	}

	public void DoPaste()
	{
	}

	public void DoAppend(string str)
	{
	}

	public void DoAppend(string str, RetroUIText.TextCoord coord)
	{
	}

	public void DoAppend(char c)
	{
	}
}
