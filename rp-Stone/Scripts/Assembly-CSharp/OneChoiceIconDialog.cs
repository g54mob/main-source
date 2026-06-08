public class OneChoiceIconDialog : DialogNineSlice
{
	public DialogButton okButton;

	public AsciiString title;

	public AsciiSprite icon;

	public AsciiMultiColorTextBox description;

	public bool clickOutsideHides = true;

	public int clickOutsideDelay;

	private int initialPosY;

	private int initialHeight;

	private bool isCompact;

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
		description.Text = newMsg;
	}

	private void UpdateContents()
	{
		description.height = description.lineCount;
		isCompact = description.lineCount >= 13;
		Height = initialHeight + description.height;
		if (isCompact)
		{
			Height -= 2;
		}
		PositionY = initialPosY - (description.height - 1) / 2;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (okButton != null && okButton.enabled)
		{
			okButton.UpdateTic();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (base.CurrentState == State.Idle)
		{
			offsetX += PositionX;
			offsetY += PositionY;
			if (isCompact)
			{
				offsetY--;
			}
			title.Draw(r, offsetX, offsetY);
			offsetY += 2;
			if (icon != null)
			{
				icon.Draw(r, offsetX + Width / 2, offsetY + icon.height);
				offsetY += icon.height;
			}
			description.Draw(r, offsetX, offsetY);
			offsetY += description.height;
			if (isCompact)
			{
				offsetY--;
			}
			if (okButton != null && okButton.enabled)
			{
				okButton.Draw(r, offsetX, offsetY);
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
	}

	protected virtual void OnDestroy()
	{
		base.OnClickedOutside -= HandleOnClickedOutside;
		if (okButton != null)
		{
			okButton.OnPressed -= HandleOnOkPressed;
		}
	}

	private void HandleOnOkPressed(DialogButton button)
	{
	}

	private void HandleOnClickedOutside()
	{
		if (clickOutsideHides && base.CurrentState == State.Idle && base.ElapsedStateTics > clickOutsideDelay)
		{
			Hide();
		}
	}
}
