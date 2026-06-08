using System.Text;
using UnityEngine;

public class ReferralCodeInputDialog : DialogNineSlice
{
	public AsciiString title;

	public AsciiString errorMessage;

	public AsciiTextInputField inputField;

	public DialogButton inputFieldButton;

	public DialogButton confirmButton;

	public DialogButton cancelButton;

	private int standaloneOffsetY = 5;

	private const float errorDuration = 1.2f;

	private float errorTimeRemaining;

	public string textToSubmit { get; private set; }

	public virtual void Show()
	{
		base.SetState(State.In);
		textToSubmit = null;
		inputField.text = "";
		inputField.ActivateInput();
	}

	public virtual void Hide()
	{
		base.SetState(State.Out);
	}

	protected override void SetState(State newState)
	{
		base.SetState(newState);
		base.enabled = newState != State.Disabled;
	}

	private void Update()
	{
		errorTimeRemaining -= Utils.deltaTime;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.CurrentState == State.Idle)
		{
			if (!inputField.IsActive())
			{
				inputFieldButton.UpdateTic();
			}
			confirmButton.UpdateTic();
			cancelButton.UpdateTic();
		}
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
			inputFieldButton.Draw(r, offsetX, offsetY);
			if (errorTimeRemaining > 0f)
			{
				Color colorOverride = Color.Lerp(Color.red, Color.black, 1f - errorTimeRemaining / 1.2f);
				errorMessage.Draw(r, offsetX, offsetY, colorOverride);
			}
			confirmButton.Draw(r, offsetX, offsetY);
			cancelButton.Draw(r, offsetX, offsetY);
		}
	}

	private void HandleEndEdit(string textValue)
	{
		if (base.CurrentState == State.Idle || base.CurrentState == State.In)
		{
			inputField.ActivateInput();
		}
	}

	private void ShowError()
	{
		errorMessage.SetValue(Te.xt("Too short."));
		errorTimeRemaining = 1.2f;
	}

	private void HandleInputFieldPressed(DialogButton btn)
	{
		inputField.ActivateInput();
	}

	private void HandleConfirmButtonPressed(DialogButton btn)
	{
		string text = Sanitize(inputField.text);
		if (text.Length < 4)
		{
			ShowError();
			inputField.ActivateInput();
		}
		else
		{
			textToSubmit = text;
			Hide();
		}
	}

	private string Sanitize(string inStr)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char c in inStr)
		{
			if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '1' && c <= '9'))
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}

	private void HandleCancelButtonPressed(DialogButton btn)
	{
		textToSubmit = null;
		Hide();
	}

	protected override void Awake()
	{
		base.Awake();
		inputField.OnEndEdit += HandleEndEdit;
		PositionY += standaloneOffsetY;
		inputFieldButton.OnPressed += HandleInputFieldPressed;
		confirmButton.OnPressed += HandleConfirmButtonPressed;
		cancelButton.OnPressed += HandleCancelButtonPressed;
	}
}
