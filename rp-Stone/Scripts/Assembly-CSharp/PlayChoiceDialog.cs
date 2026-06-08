using UnityEngine;

public class PlayChoiceDialog : DialogNineSlice
{
	public AsciiTextBox textBox;

	public DialogButton button1;

	public DialogButton button2;

	public DialogButton buttonSingle;

	public AsciiString supertitleSingle;

	public AsciiString supertitle1;

	public AsciiString supertitle2;

	public AsciiString subtitle1;

	public AsciiString subtitle2;

	public void SetupText(string dialogText, string buttonLabel, KeyCode keyCodeForButton)
	{
		_SetupText(dialogText, buttonLabel);
		button1.keyCode = KeyCode.None;
		button2.keyCode = KeyCode.None;
		buttonSingle.keyCode = keyCodeForButton;
		button1.action = Binding.Action.None;
		button2.action = Binding.Action.None;
		buttonSingle.action = Binding.Action.None;
	}

	public void SetupText(string dialogText, string buttonLabel1, string buttonLabel2, KeyCode keyCodeForButton1, KeyCode keyCodeForButton2)
	{
		_SetupText(dialogText, buttonLabel1, buttonLabel2);
		button1.keyCode = keyCodeForButton1;
		button2.keyCode = keyCodeForButton2;
		buttonSingle.keyCode = KeyCode.None;
		button1.action = Binding.Action.None;
		button2.action = Binding.Action.None;
		buttonSingle.action = Binding.Action.None;
	}

	public void SetupText(string dialogText, string buttonLabel, Binding.Action actionForButton)
	{
		_SetupText(dialogText, buttonLabel);
		button1.keyCode = KeyCode.None;
		button2.keyCode = KeyCode.None;
		buttonSingle.keyCode = KeyCode.None;
		button1.action = Binding.Action.None;
		button2.action = Binding.Action.None;
		buttonSingle.action = actionForButton;
	}

	public void SetupText(string dialogText, string buttonLabel1, string buttonLabel2, Binding.Action actionForButton1, Binding.Action actionForButton2)
	{
		_SetupText(dialogText, buttonLabel1, buttonLabel2);
		button1.keyCode = KeyCode.None;
		button2.keyCode = KeyCode.None;
		buttonSingle.keyCode = KeyCode.None;
		button1.action = actionForButton1;
		button2.action = actionForButton2;
		buttonSingle.action = Binding.Action.None;
	}

	private void _SetupText(string dialogText, string buttonLabel)
	{
		textBox.Text = Te.xt(dialogText);
		buttonLabel = Te.xt(buttonLabel);
		int num = buttonSingle.Width - 2;
		supertitleSingle.Clear();
		if (buttonLabel.Length > num)
		{
			string[] array = Utils.BreakIntoLines(buttonLabel, num);
			if (array.Length > 1)
			{
				supertitleSingle.SetValue(array[0]);
				buttonSingle.label.SetValue(array[1]);
			}
			else
			{
				buttonSingle.label.SetValue(buttonLabel);
			}
		}
		else
		{
			buttonSingle.label.SetValue(buttonLabel);
		}
		button1.enabled = false;
		button2.enabled = false;
		buttonSingle.enabled = true;
	}

	private void _SetupText(string dialogText, string buttonLabel1, string buttonLabel2)
	{
		textBox.Text = Te.xt(dialogText);
		buttonLabel1 = Te.xt(buttonLabel1);
		buttonLabel2 = Te.xt(buttonLabel2);
		int num = button1.Width - 2;
		supertitle1.Clear();
		supertitle2.Clear();
		subtitle1.Clear();
		subtitle2.Clear();
		if (buttonLabel1.Length > num)
		{
			string[] array = Utils.BreakIntoLines(buttonLabel1, num);
			if (array.Length > 1)
			{
				supertitle1.SetValue(array[0]);
				button1.label.SetValue(array[1]);
				if (array.Length > 2)
				{
					subtitle1.SetValue(array[2]);
				}
			}
			else
			{
				button1.label.SetValue(buttonLabel1);
			}
		}
		else
		{
			button1.label.SetValue(buttonLabel1);
		}
		if (buttonLabel2.Length > num)
		{
			string[] array2 = Utils.BreakIntoLines(buttonLabel2, num);
			if (array2.Length > 1)
			{
				supertitle2.SetValue(array2[0]);
				button2.label.SetValue(array2[1]);
				if (array2.Length > 2)
				{
					subtitle2.SetValue(array2[2]);
				}
			}
			else
			{
				button2.label.SetValue(buttonLabel2);
			}
		}
		else
		{
			button2.label.SetValue(buttonLabel2);
		}
		button1.enabled = true;
		button2.enabled = true;
		buttonSingle.enabled = false;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (buttonSingle.enabled)
		{
			buttonSingle.UpdateTic();
			return;
		}
		button1.UpdateTic();
		button2.UpdateTic();
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX += PositionX;
		offsetY += PositionY;
		if (base.CurrentState == State.Idle)
		{
			textBox.Draw(r, offsetX, offsetY - textBox.lineCount);
			if (buttonSingle.enabled)
			{
				buttonSingle.Draw(r, offsetX, offsetY);
				supertitleSingle.Draw(r, offsetX, offsetY);
				return;
			}
			button1.Draw(r, offsetX, offsetY);
			button2.Draw(r, offsetX, offsetY);
			supertitle1.Draw(r, offsetX, offsetY);
			supertitle2.Draw(r, offsetX, offsetY);
			subtitle1.Draw(r, offsetX, offsetY);
			subtitle2.Draw(r, offsetX, offsetY);
		}
	}

	public void Show()
	{
		base.SetState(State.In);
	}

	public void Hide()
	{
		base.SetState(State.Out);
	}
}
