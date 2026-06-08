using System;

public class UpgradeWeaponDialog2 : DialogNineSlice
{
	public DialogButton cancelButton;

	public DialogButton damageButton;

	public DialogButton speedButton;

	public DialogButton rangeButton;

	public AsciiString damageTitle;

	public AsciiString speedTitle;

	public AsciiString rangeTitle;

	public AsciiString damageSpecs;

	public AsciiString speedSpecs;

	public AsciiString rangeSpecs;

	public AsciiString damageCost;

	public AsciiString speedCost;

	public AsciiString rangeCost;

	public bool showDamageButton;

	public bool showSpeedButton;

	public bool showRangeButton;

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

	private void HandleOnSpeedPressed(DialogButton button)
	{
	}

	private void HandleOnRangePressed(DialogButton button)
	{
	}

	public void Show()
	{
		base.SetState(State.In);
		UpdateContents();
	}

	private void UpdateContents()
	{
	}

	public void Hide()
	{
		base.SetState(State.Out);
	}

	private void FireOnPurchase()
	{
		if (this.OnPurchase != null)
		{
			this.OnPurchase();
		}
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		cancelButton.UpdateTic();
		if (showDamageButton)
		{
			damageButton.UpdateTic();
		}
		if (showSpeedButton)
		{
			speedButton.UpdateTic();
		}
		if (showRangeButton)
		{
			rangeButton.UpdateTic();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX += PositionX;
		offsetY += PositionY;
		if (base.CurrentState == State.Idle)
		{
			damageTitle.Draw(r, offsetX, offsetY);
			speedTitle.Draw(r, offsetX, offsetY);
			rangeTitle.Draw(r, offsetX, offsetY);
			damageSpecs.Draw(r, offsetX, offsetY);
			speedSpecs.Draw(r, offsetX, offsetY);
			rangeSpecs.Draw(r, offsetX, offsetY);
			damageCost.Draw(r, offsetX, offsetY);
			speedCost.Draw(r, offsetX, offsetY);
			rangeCost.Draw(r, offsetX, offsetY);
			cancelButton.Draw(r, offsetX, offsetY);
			if (showDamageButton)
			{
				damageButton.Draw(r, offsetX, offsetY);
			}
			if (showSpeedButton)
			{
				speedButton.Draw(r, offsetX, offsetY);
			}
			if (showRangeButton)
			{
				rangeButton.Draw(r, offsetX, offsetY);
			}
		}
	}

	protected override void Start()
	{
		base.Start();
		base.OnClickedOutside += HandleOnClickedOutside;
		cancelButton.OnPressed += HandleOnCancelPressed;
		damageButton.OnPressed += HandleOnDamagePressed;
		speedButton.OnPressed += HandleOnSpeedPressed;
		rangeButton.OnPressed += HandleOnRangePressed;
	}

	private void OnDestroy()
	{
		base.OnClickedOutside -= HandleOnClickedOutside;
		cancelButton.OnPressed -= HandleOnCancelPressed;
		damageButton.OnPressed -= HandleOnDamagePressed;
		speedButton.OnPressed -= HandleOnSpeedPressed;
		rangeButton.OnPressed -= HandleOnRangePressed;
	}
}
