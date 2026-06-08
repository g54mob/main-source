using System;

public class UpgradeWeaponDialog : DialogNineSlice
{
	public AsciiString title;

	public AsciiString upgradeCost;

	public DialogButton cancelButton;

	public DialogButton damageButton;

	public DialogButton rangeButton;

	public DialogButton speedButton;

	public AsciiString speedSubLabel;

	public event Action OnPurchase;

	private void HandleOnClickedOutside()
	{
		Hide();
	}

	private void HandleOnCancelPressed(DialogButton button)
	{
		Hide();
	}

	private void HandleOnDamagePressed(DialogButton button)
	{
	}

	private void HandleOnRangePressed(DialogButton button)
	{
	}

	private void HandleOnSpeedPressed(DialogButton button)
	{
	}

	public void Show()
	{
		base.SetState(State.In);
	}

	public void Hide()
	{
		base.SetState(State.Out);
	}

	private void Pay()
	{
	}

	private void FireOnPurchase()
	{
		if (this.OnPurchase != null)
		{
			this.OnPurchase();
		}
		Hide();
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		cancelButton.UpdateTic();
		damageButton.UpdateTic();
		rangeButton.UpdateTic();
		speedButton.UpdateTic();
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX += PositionX;
		offsetY += PositionY;
		if (base.CurrentState == State.Idle)
		{
			title.Draw(r, offsetX, offsetY);
			upgradeCost.Draw(r, offsetX, offsetY);
			speedSubLabel.Draw(r, offsetX, offsetY);
			cancelButton.Draw(r, offsetX, offsetY);
			damageButton.Draw(r, offsetX, offsetY);
			rangeButton.Draw(r, offsetX, offsetY);
			speedButton.Draw(r, offsetX, offsetY);
		}
	}

	protected override void Start()
	{
		base.Start();
		speedSubLabel.Init();
		base.OnClickedOutside += HandleOnClickedOutside;
		cancelButton.OnPressed += HandleOnCancelPressed;
		damageButton.OnPressed += HandleOnDamagePressed;
		rangeButton.OnPressed += HandleOnRangePressed;
		speedButton.OnPressed += HandleOnSpeedPressed;
	}

	private void OnDestroy()
	{
		base.OnClickedOutside -= HandleOnClickedOutside;
		cancelButton.OnPressed -= HandleOnCancelPressed;
		damageButton.OnPressed -= HandleOnDamagePressed;
		rangeButton.OnPressed -= HandleOnRangePressed;
		speedButton.OnPressed -= HandleOnSpeedPressed;
	}
}
