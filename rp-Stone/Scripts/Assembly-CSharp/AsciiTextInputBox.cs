using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class AsciiTextInputBox : ScrollContainer
{
	private enum TouchState
	{
		Idle = 0,
		TouchingUndecided = 1,
		Scrolling = 2,
		PositioningCaret = 3,
		EditContextButtons = 4,
		DraggingLeftHandle = 5,
		DraggingRightHandle = 6,
		InputKeyboard = 7
	}

	private struct UndoStep
	{
		public string text;

		public int caretPosition;
	}

	private List<AsciiStringRow> _rows = new List<AsciiStringRow>();

	private Stack<AsciiStringRow> rowPool = new Stack<AsciiStringRow>();

	public float cursorBlinkPeriod = 1f;

	public AsciiStringRow prototypeRow;

	public AsciiSprite touchZoom;

	public bool truncateHorizontal = true;

	public bool useReplaceMap;

	public Dictionary<string, string> replaceMap = new Dictionary<string, string> { { "\t", "  " } };

	private UUInputField _input;

	private string[] _text;

	private float elapsedTime;

	private int activeRowIndex;

	private int _lastCaretPosition = -1;

	private int _lastSelectionStart;

	private int _lastSelectionEnd;

	private int idealCaretX;

	private bool isDragging;

	private int dragStartPos;

	private int dragHandleOffsetX;

	private int dragHandleOffsetY;

	private float repeatKeyDelay;

	private TouchState currentTouchState;

	private int elapsedTouchStateTics;

	private bool prevEditingContextButtons;

	private bool editContextButtonsCanGoBackToPositionCaret;

	private int activationHack;

	private const int UNDO_LIMIT = 100;

	private List<UndoStep> undoStack = new List<UndoStep>();

	private List<UndoStep> redoStack = new List<UndoStep>();

	private string previousValue;

	private string currentValue;

	private int scheduledCaretPosition = -1;

	public bool overdrawTouchZoomSprite { get; private set; }

	public UUInputField inputBox => _input;

	public string[] text
	{
		get
		{
			return _text;
		}
		set
		{
			_text = value;
			UpdateContents();
		}
	}

	public string fullText { get; private set; }

	public int caretX { get; private set; }

	public int caretY { get; private set; }

	public TouchSelectionContextButtons touchSelectionContextButtons { get; set; }

	public event Action OnLinesChanged;

	public List<AsciiStringRow> GetTextInputBoxRows()
	{
		return _rows;
	}

	protected override void Update()
	{
		base.Update();
		if (_text == null)
		{
			return;
		}
		elapsedTime += Time.deltaTime;
		if (activationHack > 0)
		{
			activationHack--;
		}
		else if (IsControlHeld() && Input.GetKeyDown(KeyCode.Z))
		{
			if (IsShiftHeld())
			{
				Redo();
			}
			else
			{
				Undo();
			}
		}
	}

	private void UpdateInputMovement(KeyCode kc, Action func)
	{
		if (Input.GetKeyDown(kc))
		{
			func();
			repeatKeyDelay = 0.4f;
		}
		else if (Input.GetKey(kc) && repeatKeyDelay < 0f)
		{
			func();
		}
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (AsciiMouse.singleton.down0)
		{
			if (IsInBounds(AsciiMouse.singleton.x, AsciiMouse.singleton.y))
			{
				ActivateInputAt(AsciiMouse.singleton.x - base.lastContainerDrawX, AsciiMouse.singleton.y - base.lastContainerDrawY);
				isDragging = true;
				dragStartPos = _lastCaretPosition;
			}
			else
			{
				_input.DeactivateInputField();
			}
		}
		else if (AsciiMouse.singleton.up0)
		{
			isDragging = false;
		}
		else if (isDragging && AsciiMouse.singleton.isDown0 && activationHack <= 0)
		{
			int x = AsciiMouse.singleton.x - base.lastContainerDrawX;
			int y = AsciiMouse.singleton.y - base.lastContainerDrawY + displayScrollY;
			int num = CaretCoordinateToPosition(ref x, ref y);
			_input.caretPosition = num;
			_input.selectionFocusPosition = num;
			_input.selectionAnchorPosition = dragStartPos;
		}
	}

	private void SetTouchState(TouchState newState)
	{
		if (currentTouchState == TouchState.PositioningCaret)
		{
			touchZoom.enabled = false;
			base.isScrollingLocked = false;
		}
		else if (currentTouchState == TouchState.InputKeyboard)
		{
			_input.DeactivateInputField();
		}
		switch (newState)
		{
		case TouchState.Idle:
			prevEditingContextButtons = false;
			touchSelectionContextButtons.isShowing = false;
			Deselect();
			break;
		case TouchState.PositioningCaret:
			overdrawTouchZoomSprite = false;
			touchZoom.enabled = true;
			base.isScrollingLocked = true;
			touchSelectionContextButtons.isShowing = false;
			Deselect();
			break;
		case TouchState.InputKeyboard:
			touchSelectionContextButtons.isShowing = false;
			Deselect();
			ActivateInputAt(AsciiMouse.singleton.x - base.lastContainerDrawX, AsciiMouse.singleton.y - base.lastContainerDrawY);
			break;
		}
		currentTouchState = newState;
		elapsedTouchStateTics = 0;
	}

	private void UpdateTouch()
	{
		elapsedTouchStateTics++;
		AsciiMouse singleton = AsciiMouse.singleton;
		if (currentTouchState == TouchState.Idle)
		{
			if (singleton.down0 && IsInBounds(singleton.x, singleton.y) && !IsButton(singleton.x, singleton.y))
			{
				SetTouchState(TouchState.TouchingUndecided);
			}
		}
		else if (currentTouchState == TouchState.TouchingUndecided)
		{
			if (singleton.down0Duration >= 0.2f || Mathf.Abs(singleton.dragAccumulatedX) >= 2)
			{
				if (IsNearText(singleton.x, singleton.y))
				{
					SetTouchState(TouchState.PositioningCaret);
				}
				else
				{
					SetTouchState(TouchState.Scrolling);
				}
			}
			else if (singleton.isDragging0 && Mathf.Abs(singleton.dragAccumulatedY) >= 2 && Mathf.Abs(singleton.dragAccumulatedX) <= 1)
			{
				SetTouchState(TouchState.Scrolling);
			}
			else if (singleton.up0)
			{
				if (IsInBounds(singleton.x, singleton.y))
				{
					SetTouchState(TouchState.InputKeyboard);
				}
				else
				{
					SetTouchState(TouchState.Idle);
				}
			}
		}
		else if (currentTouchState == TouchState.Scrolling)
		{
			if (!singleton.isDown0)
			{
				if (prevEditingContextButtons)
				{
					SetTouchState(TouchState.EditContextButtons);
				}
				else
				{
					SetTouchState(TouchState.Idle);
				}
			}
		}
		else if (currentTouchState == TouchState.PositioningCaret)
		{
			SetCaretTo(singleton.x - base.lastContainerDrawX, singleton.y - base.lastContainerDrawY + displayScrollY);
			if (singleton.up0)
			{
				if (IsInBounds(singleton.x, singleton.y))
				{
					SetTouchState(TouchState.InputKeyboard);
				}
				else
				{
					SetTouchState(TouchState.Idle);
				}
			}
			else if (singleton.dragX != 0 || singleton.dragY != 0)
			{
				elapsedTouchStateTics = 0;
			}
			else if (elapsedTouchStateTics >= 20)
			{
				SfxController.singleton.Play("click");
				TryToSelectAt(inputBox.selectionAnchorPosition);
				touchSelectionContextButtons.isShowing = true;
				editContextButtonsCanGoBackToPositionCaret = true;
				SetTouchState(TouchState.EditContextButtons);
			}
		}
		else if (currentTouchState == TouchState.EditContextButtons)
		{
			if (singleton.down0 && !IsButton(singleton.x, singleton.y))
			{
				if (IsInBounds(singleton.x, singleton.y))
				{
					prevEditingContextButtons = true;
					SetTouchState(TouchState.TouchingUndecided);
				}
				else
				{
					SetTouchState(TouchState.Idle);
				}
			}
			else if (singleton.up0)
			{
				editContextButtonsCanGoBackToPositionCaret = false;
			}
			else if (editContextButtonsCanGoBackToPositionCaret && singleton.isDown0 && elapsedTouchStateTics >= 6 && (singleton.dragX != 0 || singleton.dragY != 0))
			{
				SetTouchState(TouchState.PositioningCaret);
			}
		}
		else if (currentTouchState == TouchState.DraggingLeftHandle)
		{
			if (singleton.isDown0)
			{
				int x = singleton.x + dragHandleOffsetX - base.lastContainerDrawX + 3;
				int y = singleton.y + dragHandleOffsetY - base.lastContainerDrawY + displayScrollY;
				int a = CaretCoordinateToPosition(ref x, ref y);
				_input.selectionAnchorPosition = Mathf.Min(a, _input.selectionFocusPosition - 1);
			}
			else
			{
				SetTouchState(TouchState.EditContextButtons);
			}
		}
		else if (currentTouchState == TouchState.DraggingRightHandle)
		{
			if (singleton.isDown0)
			{
				int x2 = singleton.x + dragHandleOffsetX - base.lastContainerDrawX - 1;
				int y2 = singleton.y + dragHandleOffsetY - base.lastContainerDrawY + displayScrollY;
				int a2 = CaretCoordinateToPosition(ref x2, ref y2) + 1;
				_input.selectionFocusPosition = Mathf.Max(a2, _input.selectionAnchorPosition + 1);
			}
			else
			{
				SetTouchState(TouchState.EditContextButtons);
			}
		}
		else
		{
			if (currentTouchState != TouchState.InputKeyboard)
			{
				return;
			}
			if (!HasFocus())
			{
				SetTouchState(TouchState.Idle);
			}
			else if (singleton.down0)
			{
				if (IsInBounds(singleton.x, singleton.y))
				{
					ActivateInputAt(singleton.x - base.lastContainerDrawX, singleton.y - base.lastContainerDrawY);
				}
				else
				{
					SetTouchState(TouchState.Idle);
				}
			}
		}
	}

	private bool IsButton(int x, int y)
	{
		AsciiCellProcedural cell = GameStates.Singleton.asciiRenderer.GetCell(x, y);
		if (cell != null)
		{
			return cell.GetInteractionLayer() != null;
		}
		return false;
	}

	private bool IsNearText(int x, int y)
	{
		AsciiRenderProcedural asciiRenderer = GameStates.Singleton.asciiRenderer;
		for (int i = y - 1; i <= y + 1; i++)
		{
			for (int j = x - 4; j <= x + 4; j++)
			{
				AsciiCellProcedural cell = asciiRenderer.GetCell(j, i);
				if (cell != null)
				{
					int value = cell.GetValue();
					if (value != 32 && value != 9 && value != 10 && value != 13)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	public bool HasFocus()
	{
		return _input.isFocused;
	}

	private bool IsInBounds(int x, int y)
	{
		int num = base.lastContainerDrawX;
		int num2 = num + Width - 1;
		int num3 = base.lastContainerDrawY;
		int num4 = num3 + Height - 1;
		if (x >= num && x <= num2 && y >= num3)
		{
			return y <= num4;
		}
		return false;
	}

	private void CheckHorizontalLimit()
	{
		if (!truncateHorizontal)
		{
			return;
		}
		CaretCoordinateFromPosition(_input.caretPosition, out var _, out var y);
		if (y >= 0 && y < _text.Length)
		{
			string text = _text[y];
			if (text.Length >= Width)
			{
				text = text.Substring(0, Width);
				_text[y] = text;
				fullText = string.Join("\n", _text);
				_input.text = fullText;
			}
		}
	}

	public void ActivateInputAt(int x, int y)
	{
		if (_text == null || _text.Length == 0)
		{
			text = new string[1] { "" };
		}
		_input.ActivateInputField();
		_input.Select();
		SetCaretTo(x, y + displayScrollY);
		activationHack = 2;
	}

	public bool IsSelected()
	{
		return _input.selectionAnchorPosition != _input.selectionFocusPosition;
	}

	private void SetCaretTo(int x, int y)
	{
		_lastCaretPosition = CaretCoordinateToPosition(ref x, ref y);
		idealCaretX = x;
		_input.caretPosition = _lastCaretPosition;
		_input.selectionAnchorPosition = _lastCaretPosition;
		_input.selectionFocusPosition = _lastCaretPosition;
		elapsedTime = 0f;
		caretX = x;
		caretY = y;
	}

	private int CaretCoordinateToPosition(ref int x, ref int y)
	{
		y = Mathf.Clamp(y, 0, _text.Length - 1);
		int num = _text[y].Length;
		if (truncateHorizontal && num > Width)
		{
			num = Width;
		}
		x = Mathf.Clamp(x, 0, num);
		int num2 = 0;
		for (int i = 0; i < _text.Length; i++)
		{
			if (i < y)
			{
				num2 += _text[i].Length + 1;
				continue;
			}
			num2 += x;
			break;
		}
		return num2;
	}

	private void CaretCoordinateFromPosition(int caretPosition, out int x, out int y)
	{
		x = 0;
		y = 0;
		for (int i = 0; i < _text.Length; i++)
		{
			if (caretPosition > _text[i].Length)
			{
				caretPosition -= _text[i].Length + 1;
				y++;
				continue;
			}
			x = caretPosition;
			break;
		}
	}

	public void DeactivateInput()
	{
		_input.DeactivateInputField();
	}

	public void Deselect()
	{
		inputBox.selectionFocusPosition = inputBox.selectionAnchorPosition;
	}

	public void TryToSelectAt(int index)
	{
		string text = fullText;
		int length = text.Length;
		if (index < 0 || index >= length || IsSpace(text[index]))
		{
			return;
		}
		int selectionAnchorPosition = index;
		int selectionFocusPosition = index;
		for (int num = index - 1; num >= 0; num--)
		{
			if (num == 0)
			{
				selectionAnchorPosition = num;
				break;
			}
			if (IsSpace(text[num]))
			{
				selectionAnchorPosition = num + 1;
				break;
			}
		}
		for (int i = index + 1; i <= length; i++)
		{
			if (i == length || IsSpace(text[i]))
			{
				selectionFocusPosition = i;
				break;
			}
		}
		inputBox.selectionAnchorPosition = selectionAnchorPosition;
		inputBox.selectionFocusPosition = selectionFocusPosition;
	}

	public static bool IsSpace(char c)
	{
		if (c != ' ' && c != '\t' && c != '\n')
		{
			return c == '\r';
		}
		return true;
	}

	private void UpdateContents()
	{
		UpdateLines();
		fullText = string.Join("\n", _text);
		_input.text = fullText;
	}

	private void UpdateLines()
	{
		RecycleRows();
		for (int i = 0; i < _text.Length; i++)
		{
			AsciiStringRow asciiStringRow = NewRow();
			asciiStringRow.text = _text[i];
			AddRow(asciiStringRow);
			_rows.Add(asciiStringRow);
		}
		if (this.OnLinesChanged != null)
		{
			this.OnLinesChanged();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (activationHack > 0)
		{
			_input.caretPosition = _lastCaretPosition;
			_input.selectionAnchorPosition = _lastCaretPosition;
			_input.selectionFocusPosition = _lastCaretPosition;
		}
		else
		{
			if (fullText != _input.text)
			{
				SaveForUndo();
				fullText = _input.text;
				_text = fullText.Split(new char[1] { '\n' });
				CheckHorizontalLimit();
				UpdateLines();
			}
			if (scheduledCaretPosition >= 0)
			{
				CaretCoordinateFromPosition(scheduledCaretPosition, out var x, out var y);
				SetCaretTo(x, y);
				scheduledCaretPosition = -1;
			}
			if (HasFocus() && (_lastCaretPosition != _input.caretPosition || _lastSelectionStart != _input.selectionAnchorPosition || _lastSelectionEnd != _input.selectionFocusPosition))
			{
				_lastCaretPosition = _input.caretPosition;
				_lastSelectionStart = _input.selectionAnchorPosition;
				_lastSelectionEnd = _input.selectionFocusPosition;
				elapsedTime = 0f;
				CaretCoordinateFromPosition(_input.caretPosition, out var x2, out var y2);
				caretX = x2;
				caretY = y2;
				int num = caretY - scrollY;
				if (num >= Height - 1)
				{
					SetScrollY(scrollY - (Height - 1 - num));
					RefreshPrecompute();
				}
				else if (num < 0)
				{
					SetScrollY(scrollY + num);
					RefreshPrecompute();
				}
			}
		}
		base.Draw(r, offsetX, offsetY);
		offsetX += PositionX;
		offsetY += PositionY;
		if (_input.selectionAnchorPosition != _input.selectionFocusPosition)
		{
			GetSelectionStartAndEndIndexes(out var start, out var end);
			CaretCoordinateFromPosition(start, out var x3, out var y3);
			CaretCoordinateFromPosition(end - 1, out var x4, out var y4);
			if (touchSelectionContextButtons != null)
			{
				touchSelectionContextButtons.leftDragHandle.PositionX = x3 - 3 + offsetX;
				touchSelectionContextButtons.leftDragHandle.PositionY = y3 + offsetY - displayScrollY;
				touchSelectionContextButtons.rightDragHandle.PositionX = x4 + 1 + offsetX;
				touchSelectionContextButtons.rightDragHandle.PositionY = y4 + offsetY - displayScrollY;
			}
			for (int i = y3; i <= y4; i++)
			{
				int y5 = offsetY + i - displayScrollY;
				if (!IsInBounds(base.lastContainerDrawX, y5))
				{
					continue;
				}
				for (int j = 0; j < _text[i].Length; j++)
				{
					if (i != y3 || j >= x3)
					{
						int x5 = offsetX + j;
						AsciiCellProcedural cell = r.GetCell(x5, y5);
						if (cell != null)
						{
							Color background = cell.GetBackground();
							cell.SetBackground(ColorConstants.lightGrey);
							cell.SetForeground(background);
						}
						if (j == x4 && i == y4)
						{
							break;
						}
					}
				}
			}
		}
		else if ((HasFocus() || currentTouchState == TouchState.PositioningCaret || currentTouchState == TouchState.EditContextButtons) && Mathf.Repeat(elapsedTime, cursorBlinkPeriod) < cursorBlinkPeriod / 2f)
		{
			int x6 = caretX + offsetX;
			int num2 = caretY + offsetY - displayScrollY;
			if (IsInBounds(x6, num2))
			{
				AsciiCellProcedural cell2 = r.GetCell(x6, num2);
				if (cell2 != null)
				{
					Color background2 = cell2.GetBackground();
					cell2.SetBackground(Color.white);
					cell2.SetForeground(background2);
				}
			}
			if (touchSelectionContextButtons != null)
			{
				touchSelectionContextButtons.leftDragHandle.PositionY = num2;
			}
		}
		if (touchZoom.enabled)
		{
			DrawTouchZoom(r, offsetX, offsetY);
		}
	}

	private void DrawTouchZoom(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (touchZoom == null)
		{
			return;
		}
		int num = caretX + offsetX;
		int num2 = caretY + offsetY - displayScrollY;
		if (Mathf.Abs(num - AsciiMouse.singleton.x) > 3 || num2 < base.lastContainerDrawY)
		{
			overdrawTouchZoomSprite = false;
			return;
		}
		overdrawTouchZoomSprite = true;
		AsciiCellProcedural cell = r.GetCell(num, num2);
		AsciiCellProcedural cell2 = r.GetCell(num - 1, num2);
		AsciiCellProcedural cell3 = r.GetCell(num + 1, num2);
		int value = cell?.Value ?? (-1);
		int value2 = cell2?.Value ?? (-1);
		int value3 = cell3?.Value ?? (-1);
		touchZoom.Draw(r, num, num2);
		try
		{
			num2 -= 3;
			r.SetCell(num, num2, value, ColorConstants.white);
			r.SetCell(num - 1, num2, value2, ColorConstants.lightGrey);
			r.SetCell(num + 1, num2, value3, ColorConstants.lightGrey);
			r.SetCell(num - 3, num2, ' ');
			r.SetCell(num + 3, num2, ' ');
			r.SetCell(num - 2, num2 - 1, ' ');
			r.SetCell(num + 2, num2 - 1, ' ');
			r.SetCell(num - 2, num2 + 1, ' ');
			r.SetCell(num + 2, num2 + 1, ' ');
		}
		catch (Exception)
		{
		}
	}

	private void SaveForUndo()
	{
		undoStack.Add(CreateUndoStepFromCurrentState());
		redoStack.Clear();
		if (undoStack.Count > 100)
		{
			undoStack.RemoveAt(0);
		}
	}

	private UndoStep CreateUndoStepFromCurrentState()
	{
		return new UndoStep
		{
			text = fullText,
			caretPosition = _lastCaretPosition
		};
	}

	private void Undo()
	{
		if (undoStack.Count > 0)
		{
			redoStack.Add(CreateUndoStepFromCurrentState());
			UndoStep inUndoStep = undoStack[undoStack.Count - 1];
			undoStack.RemoveAt(undoStack.Count - 1);
			ApplyAfterUndo(inUndoStep);
		}
	}

	private void Redo()
	{
		if (redoStack.Count > 0)
		{
			undoStack.Add(CreateUndoStepFromCurrentState());
			UndoStep inUndoStep = redoStack[redoStack.Count - 1];
			redoStack.RemoveAt(redoStack.Count - 1);
			ApplyAfterUndo(inUndoStep);
		}
	}

	private void ApplyAfterUndo(UndoStep inUndoStep)
	{
		fullText = inUndoStep.text;
		_input.text = inUndoStep.text;
		_text = fullText.Split(new char[1] { '\n' });
		UpdateLines();
		_input.caretPosition = inUndoStep.caretPosition;
	}

	private bool IsControlHeld()
	{
		if (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl) && !Input.GetKey(KeyCode.LeftMeta))
		{
			return Input.GetKey(KeyCode.RightMeta);
		}
		return true;
	}

	private bool IsShiftHeld()
	{
		if (!Input.GetKey(KeyCode.LeftShift))
		{
			return Input.GetKey(KeyCode.RightShift);
		}
		return true;
	}

	private AsciiStringRow InstantiateNewLine()
	{
		AsciiStringRow asciiStringRow = UnityEngine.Object.Instantiate(prototypeRow);
		asciiStringRow.transform.parent = base.transform;
		return asciiStringRow;
	}

	private AsciiStringRow NewRow()
	{
		AsciiStringRow asciiStringRow;
		if (rowPool.Count > 0)
		{
			asciiStringRow = rowPool.Pop();
			asciiStringRow.Clear();
		}
		else
		{
			asciiStringRow = InstantiateNewLine();
		}
		return asciiStringRow;
	}

	private void RecycleRows()
	{
		base.Clear();
		for (int i = 0; i < _rows.Count; i++)
		{
			rowPool.Push(_rows[i]);
		}
		_rows.Clear();
	}

	private void HandleEndEdit(string value)
	{
		if (_input.wasCanceled && previousValue != null)
		{
			_input.text = previousValue;
		}
		previousValue = null;
		currentValue = null;
	}

	private void HandleValueChanged(string value)
	{
		string text = value;
		if (useReplaceMap)
		{
			bool flag = false;
			int num = _input.caretPosition;
			foreach (string key in replaceMap.Keys)
			{
				string text2 = replaceMap[key];
				int num2 = text2.Length - key.Length;
				int num3 = 0;
				while ((num3 = text.IndexOf(key, num3)) >= 0)
				{
					flag = true;
					text = text.Remove(num3, key.Length).Insert(num3, text2);
					if (num3 < num)
					{
						num += num2;
					}
				}
				text = text.Replace(key, replaceMap[key]);
			}
			if (flag)
			{
				fullText = text;
				_input.text = text;
				_text = fullText.Split(new char[1] { '\n' });
				UpdateLines();
				_input.caretPosition = num;
			}
		}
		previousValue = currentValue;
		currentValue = text;
		if (previousValue == null)
		{
			previousValue = text;
		}
	}

	private void GetSelectionStartAndEndIndexes(out int start, out int end)
	{
		start = _input.selectionAnchorPosition;
		end = _input.selectionFocusPosition;
		if (start > end)
		{
			int num = start;
			start = end;
			end = num;
		}
	}

	private void HandleLeftDragHandleDown(DialogButton btn)
	{
		SetTouchState(TouchState.DraggingLeftHandle);
		dragHandleOffsetX = btn.lastDrawnX - AsciiMouse.singleton.x;
		dragHandleOffsetY = btn.lastDrawnY - AsciiMouse.singleton.y;
	}

	private void HandleRightDragHandleDown(DialogButton btn)
	{
		SetTouchState(TouchState.DraggingRightHandle);
		dragHandleOffsetX = btn.lastDrawnX - AsciiMouse.singleton.x;
		dragHandleOffsetY = btn.lastDrawnY - AsciiMouse.singleton.y;
	}

	private void HandleTouchContextCut(DialogButton btn)
	{
		GetSelectionStartAndEndIndexes(out var start, out var end);
		CaretCoordinateFromPosition(start, out var x, out var y);
		SetCaretTo(x, y);
		GUIUtility.systemCopyBuffer = _input.text.Substring(start, end - start);
		string text = _input.text.Substring(0, start);
		string text2 = _input.text.Substring(end);
		_input.text = text + text2;
		touchSelectionContextButtons.skipCopy = true;
		touchSelectionContextButtons.UpdateContents();
	}

	private void HandleTouchContextCopy(DialogButton btn)
	{
		GetSelectionStartAndEndIndexes(out var start, out var end);
		GUIUtility.systemCopyBuffer = _input.text.Substring(start, end - start);
		touchSelectionContextButtons.skipCopy = true;
		touchSelectionContextButtons.UpdateContents();
	}

	private void HandleTouchContextPaste(DialogButton btn)
	{
		GetSelectionStartAndEndIndexes(out var start, out var end);
		string value = _input.text.Substring(0, start);
		string value2 = _input.text.Substring(end);
		string systemCopyBuffer = GUIUtility.systemCopyBuffer;
		StringBuilder stringBuilder = new StringBuilder(value);
		int i = 0;
		for (int length = systemCopyBuffer.Length; i < length; i++)
		{
			char c = systemCopyBuffer[i];
			if (c >= ' ' || c == '\t' || c == '\n' || c == '\n')
			{
				stringBuilder.Append(c);
			}
		}
		scheduledCaretPosition = stringBuilder.Length;
		stringBuilder.Append(value2);
		_input.text = stringBuilder.ToString();
		touchSelectionContextButtons.skipPaste = true;
		touchSelectionContextButtons.UpdateContents();
	}

	private void HandleTouchContextSelect(DialogButton btn)
	{
		TryToSelectAt(inputBox.selectionAnchorPosition - 1);
		touchSelectionContextButtons.UpdateContents();
	}

	private void HandleTouchContextSelectAll(DialogButton btn)
	{
		_input.selectionAnchorPosition = 0;
		_input.selectionFocusPosition = fullText.Length;
		touchSelectionContextButtons.skipSelectAll = true;
		touchSelectionContextButtons.UpdateContents();
	}

	private void Start()
	{
		if (touchSelectionContextButtons != null)
		{
			touchSelectionContextButtons.leftDragHandle.OnDown += HandleLeftDragHandleDown;
			touchSelectionContextButtons.rightDragHandle.OnDown += HandleRightDragHandleDown;
			touchSelectionContextButtons.cutButton.OnPressed += HandleTouchContextCut;
			touchSelectionContextButtons.copyButton.OnPressed += HandleTouchContextCopy;
			touchSelectionContextButtons.pasteButton.OnPressed += HandleTouchContextPaste;
			touchSelectionContextButtons.selectButton.OnPressed += HandleTouchContextSelect;
			touchSelectionContextButtons.selectAllButton.OnPressed += HandleTouchContextSelectAll;
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		_rows.Clear();
		rowPool.Clear();
		if (touchSelectionContextButtons != null)
		{
			touchSelectionContextButtons.leftDragHandle.OnDown -= HandleLeftDragHandleDown;
			touchSelectionContextButtons.rightDragHandle.OnDown -= HandleRightDragHandleDown;
			touchSelectionContextButtons.cutButton.OnPressed -= HandleTouchContextCut;
			touchSelectionContextButtons.copyButton.OnPressed -= HandleTouchContextCopy;
			touchSelectionContextButtons.pasteButton.OnPressed -= HandleTouchContextPaste;
			touchSelectionContextButtons.selectButton.OnPressed -= HandleTouchContextSelect;
			touchSelectionContextButtons.selectAllButton.OnPressed -= HandleTouchContextSelectAll;
			touchSelectionContextButtons = null;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		_input = GetComponentInChildren<UUInputField>();
		_input.onEndEdit.AddListener(HandleEndEdit);
		_input.onValueChanged.AddListener(HandleValueChanged);
	}
}
