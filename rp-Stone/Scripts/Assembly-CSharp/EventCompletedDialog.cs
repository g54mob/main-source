public class EventCompletedDialog : DialogNineSlice
{
	public AsciiString titleLabel;

	private AsciiSprite icon;

	public int iconOffsetX;

	public int iconOffsetY;

	public AsciiString completedLabel;

	public DialogButton okButton;

	private string[] titleLines;

	private int initialPosY;

	private int initialHeight;

	public virtual void Show()
	{
		SfxController.singleton.Play("pickup_success");
		base.SetState(State.In);
	}

	public virtual void Hide()
	{
		base.SetState(State.Out);
	}

	public void Setup(string titleStr, AsciiSprite icon)
	{
		titleStr = ((titleStr == null) ? "..." : titleStr.Trim());
		titleLines = Utils.BreakIntoLines(titleStr, Width - 4);
		int num = titleLines.Length - 1;
		this.icon = icon;
		if (icon != null)
		{
			icon.Load();
			num += icon.height;
		}
		Height = initialHeight + num + 2;
		PositionY = initialPosY - num / 2;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		okButton.UpdateTic();
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (base.CurrentState == State.Idle)
		{
			offsetX += PositionX;
			offsetY += PositionY;
			offsetY += 2;
			for (int i = 0; i < titleLines.Length; i++)
			{
				titleLabel.SetValue(titleLines[i]);
				titleLabel.Draw(r, offsetX, offsetY);
				offsetY++;
			}
			offsetY++;
			if (icon != null)
			{
				icon.Draw(r, offsetX + Width / 2 + iconOffsetX, offsetY + icon.pivotY);
				offsetY += icon.height + 1;
			}
			completedLabel.Draw(r, offsetX, offsetY);
			okButton.Draw(r, offsetX, offsetY);
		}
	}

	protected override void Start()
	{
		base.Start();
		initialPosY = PositionY;
		initialHeight = Height;
		okButton.OnPressed += HandleOnOkPressed;
		base.OnClickedOutside += HandleOnClickedOutside;
	}

	protected void OnDestroy()
	{
		okButton.OnPressed -= HandleOnOkPressed;
		base.OnClickedOutside -= HandleOnClickedOutside;
	}

	private void HandleOnOkPressed(DialogButton button)
	{
		Hide();
	}

	private void HandleOnClickedOutside()
	{
		Hide();
	}
}
