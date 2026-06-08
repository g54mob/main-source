using UnityEngine;

public class EventPremiumInfoDialog : TwoChoiceDialog
{
	public AsciiString title;

	public AsciiSprite icon;

	public AsciiMultiColorTextBox description;

	public AsciiMultiColorTextBox subPerks;

	public DialogButton subscriptionButton;

	public AsciiString cancelSubMessage;

	private int iconOffsetY;

	public override void Show()
	{
		base.Show();
		subPerks.positionY = description.positionY + description.lineCount + 6;
		iconOffsetY = description.positionY + description.lineCount + 1;
		int num = GameStates.Singleton.asciiRenderer.height - 1;
		int num2 = description.lineCount + subPerks.lineCount + 14;
		if (num2 > num)
		{
			num2--;
			iconOffsetY--;
			subPerks.positionY--;
		}
		if (num2 > num)
		{
			num2--;
			subPerks.positionY--;
		}
		Height = Mathf.Min(num, num2);
		PositionY = Height / -2;
		okButton.PositionY = Height - okButton.Height - 1;
		subscriptionButton.PositionY = okButton.PositionY;
		cancelSubMessage.PositionY = subscriptionButton.PositionY + subscriptionButton.Height;
		if (subscriptionButton.enabled)
		{
			okButton.enabled = false;
			cancelButton.enabled = true;
			string text = Te.xt("tid_shop_4b") + " ";
			string localizedPriceString = InAppPurchaseController.singleton.GetLocalizedPriceString(SubscriptionController.EVENTS_SUBSCRIPTION_ID);
			if (text.Length + localizedPriceString.Length <= subscriptionButton.Width - 4)
			{
				subscriptionButton.label.SetValue(text + localizedPriceString);
			}
			else
			{
				subscriptionButton.label.SetValue(localizedPriceString);
			}
		}
		else
		{
			okButton.enabled = true;
			cancelButton.enabled = false;
		}
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.CurrentState == State.Idle && subscriptionButton.enabled)
		{
			subscriptionButton.UpdateTic();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX += PositionX;
		offsetY += PositionY;
		if (base.CurrentState == State.Idle)
		{
			title.Draw(r, offsetX, offsetY);
			icon.Draw(r, offsetX + Width / 2, offsetY + iconOffsetY);
			description.Draw(r, offsetX, offsetY);
			subPerks.Draw(r, offsetX, offsetY);
			if (subscriptionButton.enabled)
			{
				subscriptionButton.Draw(r, offsetX, offsetY);
			}
		}
	}

	private void HandleOkPressed(DialogButton btn)
	{
		Hide();
	}

	private void HandleSubscriptionPressed(DialogButton btn)
	{
		InAppPurchaseController.singleton.BuyProduct(SubscriptionController.EVENTS_SUBSCRIPTION_ID);
		Hide();
	}

	protected override void Awake()
	{
		base.Awake();
		okButton.OnPressed += HandleOkPressed;
		subscriptionButton.OnPressed += HandleSubscriptionPressed;
	}
}
