using System;
using CloudOnce;
using UnityEngine;

public class MainMenuButtons : AsciiObject
{
	public AsciiSprite buttonsBorder;

	public DialogButton playButton;

	public DialogButton optionsButton;

	public DialogButton exitButton;

	public DialogButton signInButton;

	public AsciiString signInSubtitle;

	public DialogButton subscriptionButton;

	public AsciiTextBox subscriptionLabel;

	private readonly string MAIN_MENU_SUBSCRIPTION_WAS_PRESSED_KEY = "MM_SUB_PRESD";

	public event Action OnSignInPressed_iOS;

	private void Awake()
	{
		if (signInButton != null)
		{
			signInButton.enabled = false;
		}
		if (subscriptionButton != null)
		{
			UpdateSubscriptionButtonBadge();
			subscriptionButton.OnPressed += HandleSubscriptionButtonPressed;
		}
	}

	public override void UpdateTic()
	{
		playButton.UpdateTic();
		optionsButton.UpdateTic();
		if (exitButton != null)
		{
			exitButton.UpdateTic();
		}
		if (signInButton != null)
		{
			signInButton.enabled = !Cloud.IsSignedIn;
			if (signInButton.enabled)
			{
				signInButton.UpdateTic();
			}
		}
		if (subscriptionButton != null && subscriptionButton.enabled)
		{
			subscriptionButton.UpdateTic();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		offsetX += PositionX;
		offsetY += PositionY;
		if (buttonsBorder != null)
		{
			buttonsBorder.Draw(r, offsetX, offsetY);
		}
		playButton.Draw(r, offsetX, offsetY);
		optionsButton.Draw(r, offsetX, offsetY);
		if (exitButton != null)
		{
			exitButton.Draw(r, offsetX, offsetY);
		}
		if (signInButton != null && signInButton.enabled)
		{
			signInButton.Draw(r, offsetX, offsetY);
			int offsetX2 = offsetX + signInButton.PositionX + signInButton.label.PositionX;
			int offsetY2 = offsetY + signInButton.PositionY + signInButton.label.PositionY + 1;
			signInSubtitle.Draw(r, offsetX2, offsetY2);
		}
		if (subscriptionButton != null && subscriptionButton.enabled && !SubscriptionController.singleton.HasSubscription(SubscriptionController.EVENTS_SUBSCRIPTION_ID))
		{
			subscriptionButton.Draw(r, offsetX, offsetY);
			int offsetX3 = offsetX + subscriptionButton.PositionX;
			int offsetY3 = offsetY + subscriptionButton.PositionY;
			if (subscriptionButton.isDisabledState)
			{
				subscriptionLabel.Draw(r, offsetX3, offsetY3, subscriptionButton.edgeSymbols.color);
			}
			else
			{
				subscriptionLabel.Draw(r, offsetX3, offsetY3);
			}
		}
	}

	private void HandleSignInPressed(DialogButton btn)
	{
		(SaveFiles.singleton.storage as CloudOneStorage).RetrySignIn();
		GameStates.Singleton.SetState(GameStates.State.StorageLoading);
	}

	private void HandleSignInPressed_iOS(DialogButton btn)
	{
		if (this.OnSignInPressed_iOS != null)
		{
			this.OnSignInPressed_iOS();
		}
	}

	private void HandleSubscriptionButtonPressed(DialogButton btn)
	{
		SetPressedSubscriptionButton();
		UpdateSubscriptionButtonBadge();
	}

	private void UpdateSubscriptionButtonBadge()
	{
		subscriptionButton.badge.number = ((!HasPressedSubscriptionButton()) ? (-1) : 0);
	}

	private bool HasPressedSubscriptionButton()
	{
		return PlayerPrefs.HasKey(MAIN_MENU_SUBSCRIPTION_WAS_PRESSED_KEY);
	}

	private void SetPressedSubscriptionButton()
	{
		PlayerPrefs.SetInt(MAIN_MENU_SUBSCRIPTION_WAS_PRESSED_KEY, 1);
	}

	public void ResetSubscriptionButtonBadge()
	{
		PlayerPrefs.DeleteKey(MAIN_MENU_SUBSCRIPTION_WAS_PRESSED_KEY);
	}
}
