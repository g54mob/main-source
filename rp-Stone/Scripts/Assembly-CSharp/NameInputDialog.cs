using System;
using UnityEngine;

public class NameInputDialog : DialogNineSlice
{
	public AsciiString title;

	public AsciiString errorMessage;

	public AsciiTextInputField inputField;

	private int standaloneOffsetY = 5;

	private const float errorDuration = 1.2f;

	private float errorTimeRemaining;

	public event Action<string> OnComplete;

	public virtual void Show()
	{
		base.SetState(State.In);
		inputField.text = "";
		inputField.ActivateInput();
	}

	public virtual void Hide()
	{
		base.SetState(State.Out);
	}

	private void Update()
	{
		errorTimeRemaining -= Utils.deltaTime;
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (base.CurrentState == State.Idle)
		{
			offsetX += PositionX;
			offsetY += PositionY;
			title.Draw(r, offsetX, offsetY);
			inputField.Draw(r, offsetX, offsetY);
			if (errorTimeRemaining > 0f)
			{
				Color colorOverride = Color.Lerp(Color.red, Color.black, 1f - errorTimeRemaining / 1.2f);
				errorMessage.Draw(r, offsetX, offsetY, colorOverride);
			}
		}
	}

	private void HandleEndEdit(string textValue)
	{
		textValue = inputField.text.Trim();
		if (textValue.Length <= 0)
		{
			ShowError();
			inputField.ActivateInput();
			return;
		}
		Hide();
		if (this.OnComplete != null)
		{
			this.OnComplete(textValue);
		}
	}

	private void ShowError()
	{
		errorMessage.SetValue(Te.xt("Too short."));
		errorTimeRemaining = 1.2f;
	}

	protected override void Awake()
	{
		base.Awake();
		inputField.OnEndEdit += HandleEndEdit;
		PositionY += standaloneOffsetY;
	}
}
