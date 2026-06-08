using System;
using SafeTypes;
using UnityEngine;

public class AnvilMakeAnotherDialog : DialogNineSlice
{
	public DialogButton closeButton;

	public AsciiString title;

	public int iconPosX;

	public int iconPosY;

	public PlusMinusButtons plusMinusButtons;

	public AsciiString amountLabel;

	public DialogButton confirmationButton;

	private SafeInt _maxAmount;

	private SafeInt _amountToMake;

	private AsciiSprite icon;

	public AnvilScreen anvilScreen { get; set; }

	public Item item { get; set; }

	public int maxAmount
	{
		get
		{
			return _maxAmount.GetValue();
		}
		set
		{
			_maxAmount = new SafeInt(value);
		}
	}

	public bool automationEnabled { get; set; }

	public int amountToMake
	{
		get
		{
			return _amountToMake.GetValue();
		}
		set
		{
			_amountToMake = new SafeInt(value);
		}
	}

	public void Show()
	{
		base.SetState(State.In);
		if (item != null)
		{
			string text = item.GetName();
			if (item.level >= 1 && item.showLevelInTitle)
			{
				string starRatingStringForItem = ItemFactory.GetStarRatingStringForItem(item);
				text = starRatingStringForItem + " " + text + " " + starRatingStringForItem;
			}
			title.SetValue(text);
			icon = IconLoader.Singleton.GetSharedIcon(item.iconPath, 'o', ItemData.CharForElement(item.element));
		}
		amountToMake = 1;
		amountLabel.SetValue("1");
		plusMinusButtons.Show();
		plusMinusButtons.plusButton.enabled = maxAmount > 1;
		plusMinusButtons.minusButton.enabled = false;
		automationEnabled = false;
	}

	public void Hide()
	{
		base.SetState(State.Out);
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.CurrentState == State.Idle)
		{
			closeButton.UpdateTic();
			plusMinusButtons.UpdateTic();
			confirmationButton.UpdateTic();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (base.CurrentState == State.Idle)
		{
			offsetX += PositionX;
			offsetY += PositionY;
			closeButton.Draw(r, offsetX, offsetY);
			title.Draw(r, offsetX, offsetY);
			if (icon != null)
			{
				icon.Draw(r, offsetX + iconPosX, offsetY + iconPosY);
			}
			amountLabel.Draw(r, offsetX, offsetY);
			plusMinusButtons.Draw(r, offsetX, offsetY);
			confirmationButton.Draw(r, offsetX, offsetY);
		}
	}

	private void HandleConfirmationButtonPressed(DialogButton btn)
	{
		automationEnabled = true;
		Hide();
	}

	private void HandlePlusButtonPressed(PlusMinusButtons buttons, bool isRepeating)
	{
		if (amountToMake < maxAmount)
		{
			plusMinusButtons.minusButton.enabled = true;
			int num = 1;
			if (amountToMake >= 50 && isRepeating)
			{
				num = 11;
				num = Mathf.Min(num, maxAmount - amountToMake);
			}
			amountToMake += num;
			if (amountToMake >= maxAmount)
			{
				plusMinusButtons.plusButton.enabled = false;
			}
			amountLabel.SetValue(amountToMake.ToString());
			plusMinusButtons.repeatFrameSkip = ((amountToMake < 10) ? 2 : 0);
		}
	}

	private void HandleMinusButtonPressed(PlusMinusButtons buttons, bool isRepeating)
	{
		if (amountToMake == 1)
		{
			plusMinusButtons.minusButton.enabled = false;
		}
		plusMinusButtons.plusButton.enabled = true;
		int num = 1;
		if (amountToMake > 100 && isRepeating)
		{
			num = 11;
		}
		amountToMake = Mathf.Max(1, amountToMake - num);
		if (amountToMake == 1)
		{
			plusMinusButtons.minusButton.enabled = false;
		}
		amountLabel.SetValue(amountToMake.ToString());
		plusMinusButtons.repeatFrameSkip = ((amountToMake < 10) ? 2 : 0);
	}

	private void HandleCloseButtonPressed(DialogButton btn)
	{
		Hide();
	}

	private void HandleClickedOutside()
	{
		Hide();
	}

	protected override void Awake()
	{
		base.Awake();
		base.OnClickedOutside += HandleClickedOutside;
		closeButton.OnPressed += HandleCloseButtonPressed;
		PlusMinusButtons obj = plusMinusButtons;
		obj.OnPlus = (Action<PlusMinusButtons, bool>)Delegate.Combine(obj.OnPlus, new Action<PlusMinusButtons, bool>(HandlePlusButtonPressed));
		PlusMinusButtons obj2 = plusMinusButtons;
		obj2.OnMinus = (Action<PlusMinusButtons, bool>)Delegate.Combine(obj2.OnMinus, new Action<PlusMinusButtons, bool>(HandleMinusButtonPressed));
		confirmationButton.OnPressed += HandleConfirmationButtonPressed;
	}

	protected void OnDestroy()
	{
		base.OnClickedOutside -= HandleClickedOutside;
		closeButton.OnPressed -= HandleCloseButtonPressed;
		PlusMinusButtons obj = plusMinusButtons;
		obj.OnPlus = (Action<PlusMinusButtons, bool>)Delegate.Remove(obj.OnPlus, new Action<PlusMinusButtons, bool>(HandlePlusButtonPressed));
		PlusMinusButtons obj2 = plusMinusButtons;
		obj2.OnMinus = (Action<PlusMinusButtons, bool>)Delegate.Remove(obj2.OnMinus, new Action<PlusMinusButtons, bool>(HandleMinusButtonPressed));
		confirmationButton.OnPressed -= HandleConfirmationButtonPressed;
	}
}
