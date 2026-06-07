using UnityEngine;
using UnityEngine.Localization;

public class Dollars : MonoBehaviour, IInteractable
{
	public int amount = 4;

	protected virtual LocalizedString interactionText { get; } = new LocalizedString("MyTable", "interaction-grab");

	public virtual string InteractionText
	{
		get
		{
			if (interactionText != null && !interactionText.IsEmpty)
			{
				return interactionText.GetLocalizedString();
			}
			return "Grab";
		}
	}

	public void Interact()
	{
		FirstPersonController.S.MoneyUpdated(amount);
		AudioManager.S.PlaySFX(AudioManager.S.grabItem);
		Object.Destroy(base.gameObject);
	}

	public void OnDetected()
	{
	}

	public void OnLost()
	{
	}
}
