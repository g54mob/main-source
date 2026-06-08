using System;
using UnityEngine;

public class LostBoostIngredientCountDialog : DialogNineSlice
{
	public DialogButton closeButton;

	public AsciiString title;

	public AsciiString percentBG;

	public AsciiString percentValue;

	public ItemSlot slot;

	public PlusMinusButtons plusMinusButtons;

	public DialogButton jumpToEndButton;

	public AsciiString amountLabel;

	public DialogButton confirmationButton;

	private int maxAmount;

	private int startingAmount;

	private int lostBoostPointsWithoutThisItem;

	private int lostBoostPointsGoal;

	private int lostBoostPointsPerCopyOfThisItem;

	private int totalLostBoostPoints;

	public int amountToAdd { get; private set; }

	public bool canJumpToEnd { get; set; }

	public void Show(Item item, int startingAmount, int lostBoostPointsWithoutThisItem, int lostBoostPointsGoal)
	{
		base.SetState(State.In);
		this.lostBoostPointsWithoutThisItem = lostBoostPointsWithoutThisItem;
		this.lostBoostPointsGoal = lostBoostPointsGoal;
		lostBoostPointsPerCopyOfThisItem = item.GetLostBoostPoints();
		slot.SetContent(item, 1);
		maxAmount = Mathf.CeilToInt((float)(lostBoostPointsGoal - lostBoostPointsWithoutThisItem) / (float)lostBoostPointsPerCopyOfThisItem);
		maxAmount = Mathf.Min(item.count, maxAmount);
		this.startingAmount = startingAmount;
		amountToAdd = startingAmount;
		amountLabel.SetValue(amountToAdd.ToString());
		UpdatePercentage();
		plusMinusButtons.Show();
		plusMinusButtons.plusButton.enabled = maxAmount > 1;
		plusMinusButtons.minusButton.enabled = startingAmount > 0;
		SetEnabledJumpToEndButton(plusMinusButtons.plusButton.enabled);
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
			if (jumpToEndButton.enabled && canJumpToEnd)
			{
				jumpToEndButton.UpdateTic();
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetY += PositionY;
		if (base.CurrentState == State.Idle)
		{
			closeButton.Draw(r, offsetX, offsetY);
			title.Draw(r, offsetX, offsetY);
			percentBG.Draw(r, offsetX, offsetY);
			percentValue.Draw(r, offsetX, offsetY);
			slot.Draw(r, offsetX, offsetY);
			amountLabel.Draw(r, offsetX, offsetY);
			plusMinusButtons.Draw(r, offsetX, offsetY);
			confirmationButton.Draw(r, offsetX, offsetY);
			if (canJumpToEnd)
			{
				jumpToEndButton.Draw(r, offsetX, offsetY);
			}
		}
	}

	private void UpdatePercentage()
	{
		totalLostBoostPoints = lostBoostPointsWithoutThisItem;
		totalLostBoostPoints += lostBoostPointsPerCopyOfThisItem * amountToAdd;
		float p = (float)totalLostBoostPoints / (float)lostBoostPointsGoal;
		percentValue.SetValue(LostBoostIngredientsDialog.ConvertPercentageToString(p));
	}

	private void Cancel()
	{
		amountToAdd = startingAmount;
		Hide();
	}

	protected virtual void Update()
	{
		if (base.CurrentState == State.Idle && Input.GetKeyDown(KeyCode.Escape))
		{
			Cancel();
		}
	}

	private void HandleConfirmationButtonPressed(DialogButton btn)
	{
		Hide();
	}

	private void HandleJumpToEndButtonPressed(DialogButton btn)
	{
		plusMinusButtons.minusButton.enabled = true;
		plusMinusButtons.plusButton.enabled = false;
		SetEnabledJumpToEndButton(value: false);
		amountToAdd = maxAmount;
		amountLabel.SetValue(amountToAdd.ToString());
		UpdatePercentage();
	}

	private void SetEnabledJumpToEndButton(bool value)
	{
		jumpToEndButton.enabled = value;
		if (value)
		{
			jumpToEndButton.edgeSymbols.color = ColorConstants.grey;
			jumpToEndButton.label.color = ColorConstants.white;
		}
		else
		{
			jumpToEndButton.edgeSymbols.color = ColorConstants.black;
			jumpToEndButton.label.color = ColorConstants.thirdGrey;
		}
	}

	private void HandlePlusButtonPressed(PlusMinusButtons buttons, bool isRepeating)
	{
		if (amountToAdd < maxAmount)
		{
			plusMinusButtons.minusButton.enabled = true;
			int num = 1;
			if (amountToAdd >= 50 && isRepeating)
			{
				num = 16;
				num = Mathf.Min(num, maxAmount - amountToAdd);
			}
			amountToAdd += num;
			if (amountToAdd >= maxAmount)
			{
				plusMinusButtons.plusButton.enabled = false;
				SetEnabledJumpToEndButton(value: false);
			}
			amountLabel.SetValue(amountToAdd.ToString());
			plusMinusButtons.repeatFrameSkip = ((amountToAdd < 10) ? 1 : 0);
			UpdatePercentage();
		}
	}

	private void HandleMinusButtonPressed(PlusMinusButtons buttons, bool isRepeating)
	{
		if (amountToAdd == 1)
		{
			plusMinusButtons.minusButton.enabled = false;
		}
		plusMinusButtons.plusButton.enabled = true;
		SetEnabledJumpToEndButton(value: true);
		int num = 1;
		if (amountToAdd > 100 && isRepeating)
		{
			num = 11;
		}
		amountToAdd = Mathf.Max(0, amountToAdd - num);
		if (amountToAdd == 0)
		{
			plusMinusButtons.minusButton.enabled = false;
			Hide();
		}
		amountLabel.SetValue(amountToAdd.ToString());
		plusMinusButtons.repeatFrameSkip = ((amountToAdd < 10) ? 2 : 0);
		UpdatePercentage();
	}

	private void HandleCloseButtonPressed(DialogButton btn)
	{
		Cancel();
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
		jumpToEndButton.OnPressed += HandleJumpToEndButtonPressed;
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
		jumpToEndButton.OnPressed -= HandleJumpToEndButtonPressed;
	}
}
