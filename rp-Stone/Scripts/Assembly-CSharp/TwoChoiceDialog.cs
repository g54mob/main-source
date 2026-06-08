public class TwoChoiceDialog : DialogNineSlice
{
	public AsciiString question;

	public DialogButton okButton;

	public DialogButton cancelButton;

	public bool clickOutsideHides = true;

	public int clickOutsideDelay;

	private string[] questionLines;

	private int initialPosY;

	private int initialHeight;

	public virtual void Show()
	{
		UpdateContents();
		base.SetState(State.In);
	}

	public virtual void Hide()
	{
		base.SetState(State.Out);
	}

	public void SetMessage(string newMsg)
	{
		question.initialString = newMsg;
	}

	private void UpdateContents()
	{
		string text = question.initialString;
		if (question.autoLocalized)
		{
			text = Te.xt(text);
		}
		questionLines = Utils.BreakIntoLines(text, Width - 4);
		Height = initialHeight + questionLines.Length - 1;
		PositionY = initialPosY - (questionLines.Length - 1) / 2;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (okButton != null && okButton.enabled)
		{
			okButton.UpdateTic();
		}
		if (cancelButton != null && cancelButton.enabled)
		{
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
			for (int i = 0; i < questionLines.Length; i++)
			{
				question.SetValue(questionLines[i]);
				question.Draw(r, offsetX, offsetY);
				offsetY++;
			}
			offsetY--;
			if (okButton != null && okButton.enabled)
			{
				okButton.Draw(r, offsetX, offsetY);
			}
			if (cancelButton != null && cancelButton.enabled)
			{
				cancelButton.Draw(r, offsetX, offsetY);
			}
		}
	}

	protected override void Start()
	{
		base.Start();
		initialPosY = PositionY;
		initialHeight = Height;
		base.OnClickedOutside += HandleOnClickedOutside;
		if (okButton != null)
		{
			okButton.OnPressed += HandleOnOkPressed;
		}
		if (cancelButton != null)
		{
			cancelButton.OnPressed += HandleOnCancelPressed;
		}
	}

	protected virtual void OnDestroy()
	{
		base.OnClickedOutside -= HandleOnClickedOutside;
		if (okButton != null)
		{
			okButton.OnPressed -= HandleOnOkPressed;
		}
		if (cancelButton != null)
		{
			cancelButton.OnPressed -= HandleOnCancelPressed;
		}
	}

	private void HandleOnOkPressed(DialogButton button)
	{
	}

	private void HandleOnCancelPressed(DialogButton button)
	{
		Hide();
	}

	private void HandleOnClickedOutside()
	{
		if (clickOutsideHides && base.CurrentState == State.Idle && base.ElapsedStateTics > clickOutsideDelay)
		{
			Hide();
		}
	}
}
