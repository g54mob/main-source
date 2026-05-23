using UnityEngine;
using UnityEngine.Localization;

public class DonationBox : MonoBehaviour, IInteractable
{
	public LocalizedString doNateText;

	public Outline outLine;

	public Grocery grocery;

	public string InteractionText
	{
		get
		{
			if (grocery.stolen)
			{
				doNateText.Arguments = new object[1] { grocery.DonateNeeded() };
				return doNateText.GetLocalizedString();
			}
			doNateText.Arguments = new object[1] { 1f };
			return doNateText.GetLocalizedString();
		}
	}

	private void Start()
	{
		outLine = GetComponent<Outline>();
		if (outLine != null)
		{
			outLine.enabled = false;
		}
	}

	public void Interact()
	{
		if (grocery.stolen)
		{
			float num = grocery.DonateNeeded();
			if (FirstPersonController.S.money >= num)
			{
				AudioManager.S.PlaySFX(AudioManager.S.coin);
				FirstPersonController.S.MoneyUpdated(0f - num);
				grocery.UnlockStore();
			}
			else
			{
				AudioManager.S.PlaySFX(AudioManager.S.notEnoughMoney);
			}
		}
		else if (FirstPersonController.S.money >= 1f)
		{
			FirstPersonController.S.MoneyUpdated(-1f);
			AudioManager.S.PlaySFX(AudioManager.S.coin);
		}
	}

	public void OnDetected()
	{
		if (outLine != null)
		{
			outLine.enabled = true;
		}
	}

	public void OnLost()
	{
		if (outLine != null)
		{
			outLine.enabled = false;
		}
	}
}
