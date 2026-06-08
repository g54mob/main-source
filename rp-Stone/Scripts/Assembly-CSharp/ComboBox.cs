using System;
using System.Collections.Generic;
using UnityEngine;

public class ComboBox : ScrollContainer
{
	public enum State
	{
		Closed = 0,
		Open = 1,
		Closing = 2
	}

	public DialogNineSlice border;

	public DialogButton arrowButton;

	public DialogButton rowPrototype;

	public Color highlightColor = Color.white;

	public int maxHeight = 100;

	private List<string> allValues = new List<string>();

	private List<DialogButton> allButtons = new List<DialogButton>();

	private DialogButton activeButton;

	private ModalFade modalFade;

	public State currentState { get; private set; }

	public int currentIndex { get; set; }

	public string currentValue
	{
		get
		{
			if (currentIndex < 0 || currentIndex >= allValues.Count)
			{
				return "";
			}
			return allValues[currentIndex];
		}
	}

	public event Action<ComboBox> OnIndexChanged;

	public void SetState(State newState)
	{
		switch (newState)
		{
		case State.Closed:
			if (modalFade != null)
			{
				modalFade.active = false;
			}
			break;
		case State.Open:
		{
			activeButton = null;
			for (int i = 0; i < allButtons.Count; i++)
			{
				DialogButton dialogButton = allButtons[i];
				dialogButton.Width = Width - 2;
				if (currentValue == allValues[i])
				{
					activeButton = dialogButton;
				}
			}
			UpdateHeight();
			RefreshPrecompute();
			UpdatePrecompute();
			if (currentIndex < 0)
			{
				ScrollToBottom();
			}
			else if (currentIndex < visibleRowBegin)
			{
				int num = visibleRowBegin - currentIndex;
				scrollY -= num;
				displayScrollY = scrollY;
			}
			else if (currentIndex > visibleRowEnd)
			{
				int num2 = currentIndex - visibleRowEnd;
				scrollY += num2;
			}
			displayScrollY = scrollY;
			RefreshPrecompute();
			if (modalFade != null)
			{
				modalFade.active = true;
			}
			break;
		}
		}
		currentState = newState;
	}

	public override void Clear()
	{
		base.Clear();
		currentIndex = 0;
		allValues.Clear();
		for (int i = 0; i < allButtons.Count; i++)
		{
			allButtons[i].OnPressed -= HandleRowPressed;
		}
		allButtons.Clear();
		activeButton = null;
	}

	public void AddRow(string value)
	{
		value = " " + value;
		DialogButton dialogButton = UnityEngine.Object.Instantiate(rowPrototype);
		dialogButton.label.initialString = value;
		AddRow(dialogButton);
		allValues.Add(value);
		allButtons.Add(dialogButton);
		dialogButton.OnPressed += HandleRowPressed;
	}

	public void SetValues(string[] values)
	{
		Clear();
		for (int i = 0; i < values.Length; i++)
		{
			AddRow(values[i]);
		}
	}

	public void SetValues(List<string> values)
	{
		Clear();
		for (int i = 0; i < values.Count; i++)
		{
			AddRow(values[i]);
		}
	}

	public override void UpdateTic()
	{
		if (currentState == State.Closed)
		{
			arrowButton.UpdateTic();
		}
		else if (currentState == State.Open)
		{
			base.UpdateTic();
			if (AsciiMouse.singleton.up0 && IsMouseOutside())
			{
				SetState(State.Closing);
			}
		}
		else if (currentState == State.Closing)
		{
			SetState(State.Closed);
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (modalFade != null)
		{
			modalFade.Draw(r);
		}
		offsetX += PositionX;
		offsetY += PositionY;
		border.Width = Width;
		if (currentState == State.Open)
		{
			border.Height = 2 + Height;
			border.Draw(r, offsetX, offsetY);
			offsetX -= PositionX - 1;
			offsetY -= PositionY - 1;
			scrollBar.PositionX = border.lastDrawX + border.Width - offsetX - 1;
			scrollBar.PositionY = border.lastDrawY - offsetY + 1;
			scrollBar.Height = border.Height - 2;
			base.Draw(r, offsetX, offsetY);
			if (activeButton != null && !activeButton.activated && IsRowVisible(currentIndex))
			{
				for (int i = 0; i < activeButton.Width; i++)
				{
					AsciiCellProcedural cell = r.GetCell(i + activeButton.lastDrawnX, activeButton.lastDrawnY);
					cell.SetForeground(ColorConstants.black);
					cell.SetBackground(highlightColor);
				}
			}
		}
		else
		{
			border.Height = 3;
			border.Draw(r, offsetX, offsetY);
			rowPrototype.label.SetValue(currentValue);
			rowPrototype.Draw(r, offsetX + 1, offsetY + 1);
			arrowButton.clickPaddingLeft = Width - arrowButton.Width;
			offsetX += Width;
			arrowButton.Draw(r, offsetX, offsetY);
		}
	}

	private void UpdateHeight()
	{
		int a = Mathf.Min(maxHeight, GameStates.Singleton.asciiRenderer.height);
		Height = Mathf.Min(a, base.totalContentLength);
		RefreshPrecompute();
	}

	private bool IsMouseOutside()
	{
		if (AsciiMouse.singleton.x >= border.lastDrawX && AsciiMouse.singleton.y >= border.lastDrawY && AsciiMouse.singleton.x < border.lastDrawX + border.Width)
		{
			return AsciiMouse.singleton.y >= border.lastDrawY + border.Height;
		}
		return true;
	}

	private void HandleRowPressed(DialogButton btn)
	{
		int num = currentIndex;
		for (int i = 0; i < allButtons.Count; i++)
		{
			if (btn == allButtons[i])
			{
				num = i;
				break;
			}
		}
		SetState(State.Closed);
		if (currentIndex != num)
		{
			currentIndex = num;
			if (this.OnIndexChanged != null)
			{
				this.OnIndexChanged(this);
			}
		}
	}

	private void HandleArrowButtonPressed(DialogButton btn)
	{
		SetState(State.Open);
	}

	protected override void Awake()
	{
		base.Awake();
		modalFade = GetComponent<ModalFade>();
		arrowButton.OnPressed += HandleArrowButtonPressed;
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		arrowButton.OnPressed -= HandleArrowButtonPressed;
		Clear();
	}

	public void DebugTestData()
	{
		AddRow("Row 0");
		AddRow("Row 1");
		AddRow("Row 2");
		AddRow("Row 3");
		AddRow("Row 4");
		AddRow("Row 5");
		AddRow("Row 6");
		AddRow("Row 7");
		AddRow("Row 8");
		AddRow("Row 9");
	}
}
