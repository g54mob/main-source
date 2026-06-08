using System.Collections.Generic;
using UnityEngine;

public class AsciiColorPicker : DialogNineSlice
{
	private enum ColorPickerState
	{
		Idle = 0,
		HexTyping = 1
	}

	public DialogNineSlice mainColorBox;

	public AsciiTextInputField hexInputField;

	public DialogButton hexInputButton;

	public int colorPresetX;

	public int colorPresetY;

	public int colorPresetPerRow = 5;

	public List<DialogButton> colorPresetButtons;

	public Slider redSlider;

	public Slider greenSlider;

	public Slider blueSlider;

	public DialogButton okButton;

	public DialogButton cancelButton;

	private Color previousColor;

	private ColorPickerState currentColorPickerState;

	private string lastHexText;

	public Color currentColor { get; private set; }

	public void SetStartingColor(Color startingColor)
	{
		previousColor = startingColor;
		_SetColor(startingColor);
		UpdateSliderPositions();
	}

	public void Show()
	{
		SetState(State.In);
	}

	public void Hide()
	{
		SetState(State.Out);
	}

	private void SetColorPickerState(ColorPickerState newState)
	{
		if (newState == ColorPickerState.HexTyping)
		{
			hexInputField.ActivateInput();
		}
		currentColorPickerState = newState;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (currentColorPickerState == ColorPickerState.Idle)
		{
			hexInputButton.UpdateTic();
			for (int i = 0; i < colorPresetButtons.Count; i++)
			{
				colorPresetButtons[i].UpdateTic();
			}
			redSlider.UpdateTic();
			greenSlider.UpdateTic();
			blueSlider.UpdateTic();
			okButton.UpdateTic();
			cancelButton.UpdateTic();
		}
		else
		{
			if (currentColorPickerState != ColorPickerState.HexTyping)
			{
				return;
			}
			hexInputField.UpdateTic();
			if (!(lastHexText != hexInputField.text))
			{
				return;
			}
			lastHexText = hexInputField.text;
			int num = lastHexText.Length;
			if (num >= 1 && lastHexText[0] != '#')
			{
				lastHexText = "#" + lastHexText;
				hexInputField.text = lastHexText;
				num++;
				hexInputField.SetCaretPosition(hexInputField.GetCaretPosition() + 1);
			}
			if (num <= 0)
			{
				lastHexText = "#";
				hexInputField.text = lastHexText;
				num = 1;
				hexInputField.SetCaretPosition(1);
			}
			else if (num > 7)
			{
				lastHexText = lastHexText.Substring(0, 7);
				hexInputField.text = lastHexText;
				num = lastHexText.Length;
				hexInputField.SetCaretPosition(num);
			}
			lastHexText = lastHexText.ToUpperInvariant();
			for (int j = 1; j < num; j++)
			{
				char c = lastHexText[j];
				if ((c < '0' || c > '9') && (c < 'A' || c > 'F'))
				{
					if (j < num)
					{
						lastHexText = lastHexText.Substring(0, j) + "0" + lastHexText.Substring(j + 1);
					}
					else
					{
						lastHexText = lastHexText.Substring(0, j) + "0";
					}
				}
			}
			hexInputField.text = lastHexText;
			_UpdateColorFromHex(lastHexText);
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (base.CurrentState != State.Idle)
		{
			return;
		}
		offsetX += PositionX;
		offsetY += PositionY;
		mainColorBox.Draw(r, offsetX, offsetY);
		hexInputField.Draw(r, offsetX, offsetY);
		hexInputButton.Draw(r, offsetX, offsetY);
		int num = colorPresetX + offsetX;
		int num2 = colorPresetY + offsetY;
		int num3 = 0;
		for (int i = 0; i < colorPresetButtons.Count; i++)
		{
			DialogButton dialogButton = colorPresetButtons[i];
			dialogButton.Draw(r, num, num2);
			num3++;
			if (num3 >= colorPresetPerRow)
			{
				num3 = 0;
				num = colorPresetX + offsetX;
				num2 += dialogButton.Height;
			}
			else
			{
				num += dialogButton.Width + 1;
			}
		}
		redSlider.Draw(r, offsetX, offsetY);
		greenSlider.Draw(r, offsetX, offsetY);
		blueSlider.Draw(r, offsetX, offsetY);
		okButton.Draw(r, offsetX, offsetY);
		cancelButton.Draw(r, offsetX, offsetY);
	}

	private void UpdateSliderPositions()
	{
		redSlider.percent = currentColor.r;
		greenSlider.percent = currentColor.g;
		blueSlider.percent = currentColor.b;
	}

	private void HandleEndEdit(string textValue)
	{
		SetColorPickerState(ColorPickerState.Idle);
		UpdateSliderPositions();
	}

	private void HandleInputFieldPressed(DialogButton btn)
	{
		SetColorPickerState(ColorPickerState.HexTyping);
	}

	private void _SetColor(Color c)
	{
		mainColorBox.edgeSymbols.color = c;
		currentColor = c;
		hexInputField.text = "#" + ColorUtility.ToHtmlStringRGB(c);
	}

	private void _UpdateColorFromHex(string colorStr)
	{
		if (colorStr.Length >= 7 && ColorUtility.TryParseHtmlString(colorStr, out var color))
		{
			mainColorBox.edgeSymbols.color = color;
			currentColor = color;
			UpdateSliderPositions();
		}
	}

	private void HandleColorPresetPressed(DialogButton btn)
	{
		_SetColor(btn.edgeSymbols.color);
		UpdateSliderPositions();
	}

	private void HandleRedSliderChanged(Slider slider)
	{
		Color c = currentColor;
		c.r = slider.percent;
		_SetColor(c);
	}

	private void HandleGreenSliderChanged(Slider slider)
	{
		Color c = currentColor;
		c.g = slider.percent;
		_SetColor(c);
	}

	private void HandleBlueSliderChanged(Slider slider)
	{
		Color c = currentColor;
		c.b = slider.percent;
		_SetColor(c);
	}

	private void HandleOkPressed(DialogButton btn)
	{
		Hide();
	}

	private void HandleCancelPressed(DialogButton btn)
	{
		_SetColor(previousColor);
		UpdateSliderPositions();
		Hide();
	}

	protected override void Awake()
	{
		base.Awake();
		hexInputField.OnEndEdit += HandleEndEdit;
		hexInputButton.OnPressed += HandleInputFieldPressed;
		for (int i = 0; i < colorPresetButtons.Count; i++)
		{
			colorPresetButtons[i].OnPressed += HandleColorPresetPressed;
		}
		redSlider.OnPercentChanged += HandleRedSliderChanged;
		greenSlider.OnPercentChanged += HandleGreenSliderChanged;
		blueSlider.OnPercentChanged += HandleBlueSliderChanged;
		okButton.OnPressed += HandleOkPressed;
		cancelButton.OnPressed += HandleCancelPressed;
	}
}
