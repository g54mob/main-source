using System;
using UnityEngine;
using UnityEngine.UI;

public class AsciiTextInputField : DialogNineSlice
{
	public AsciiTextBox textBox;

	public int maxSymbols = -1;

	public string cursorSymbol = "█";

	public Color cursorColor = Color.white;

	public float cursorBlinkPeriod = 1f;

	private UUInputField _input;

	private string _text;

	private float elapsedTime;

	private int _lastCaretPosition;

	private int setCaretDelay;

	private int delayedCaretPosition = -1;

	public string text
	{
		get
		{
			return _text;
		}
		set
		{
			_input.text = value;
		}
	}

	public event Action<string> OnEndEdit;

	private void Update()
	{
		if (_text != _input.text || _lastCaretPosition != _input.caretPosition)
		{
			_text = _input.text;
			_lastCaretPosition = _input.caretPosition;
			if (maxSymbols > 0 && _text.Length > maxSymbols)
			{
				_text = _text.Substring(0, maxSymbols);
				_input.text = _text;
			}
			textBox.Text = _text;
			elapsedTime = 0f;
		}
		else
		{
			elapsedTime += Utils.deltaTime;
		}
		if (--setCaretDelay == 0)
		{
			_input.caretPosition = delayedCaretPosition;
			delayedCaretPosition = -1;
		}
	}

	public int GetCaretPosition()
	{
		if (delayedCaretPosition >= 0)
		{
			return delayedCaretPosition;
		}
		return _input.caretPosition;
	}

	public void SetCaretPosition(int value)
	{
		setCaretDelay = 2;
		delayedCaretPosition = value;
	}

	public void ResetBlink()
	{
		elapsedTime = 0f;
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX += PositionX;
		offsetY += PositionY;
		textBox.Draw(r, offsetX, offsetY);
		if (_input.isFocused && Mathf.Repeat(elapsedTime, cursorBlinkPeriod) < cursorBlinkPeriod / 2f)
		{
			int x = offsetX + textBox.positionX;
			int y = offsetY + textBox.positionY;
			if (textBox.lineCount > 0)
			{
				int num = Mathf.Max(_input.caretPosition, delayedCaretPosition);
				x = textBox.lastSymbolDrawX + 1 + (num - _input.text.Length);
				y = textBox.lastSymbolDrawY;
			}
			AsciiCellProcedural cell = r.GetCell(x, y);
			if (cell != null)
			{
				Color background = cell.GetBackground();
				cell.SetBackground(cursorColor);
				cell.SetForeground(background);
			}
		}
	}

	public void ActivateInput()
	{
		_input.ActivateInputField();
		_input.Select();
		Update();
		SetCaretPosition(text.Length);
	}

	public void DeactivateInput()
	{
		_input.DeactivateInputField();
	}

	public bool IsActive()
	{
		return _input.isFocused;
	}

	private void HandleEndEdit(string value)
	{
		if (this.OnEndEdit != null)
		{
			this.OnEndEdit(value);
		}
	}

	protected override void Start()
	{
		base.Start();
		SetState(State.Idle);
	}

	protected override void Awake()
	{
		base.Awake();
		_input = GetComponentInChildren<UUInputField>();
		_input.onEndEdit.AddListener(HandleEndEdit);
	}
}
