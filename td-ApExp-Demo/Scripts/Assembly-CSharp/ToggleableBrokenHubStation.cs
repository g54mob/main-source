using UnityEngine;
using UnityEngine.Localization;

public class ToggleableBrokenHubStation : BrokenHubStation
{
	[Header("Toggleable Station Settings")]
	[SerializeField]
	protected Sprite activatedSprite;

	[SerializeField]
	private new AudioClip enabled;

	[SerializeField]
	private AudioClip disabled;

	[Header("Localization")]
	[SerializeField]
	protected LocalizedString enabledLocalizedKey;

	[SerializeField]
	protected LocalizedString disabledLocalizedKey;

	protected virtual void ToggleOn()
	{
		sr.sprite = activatedSprite;
		interactable.actionNameLocalized = enabledLocalizedKey;
		audioSource.PlayOneShot(enabled);
	}

	protected virtual void ToggleOff()
	{
		sr.sprite = fixedSprite;
		interactable.actionNameLocalized = disabledLocalizedKey;
		audioSource.PlayOneShot(disabled);
	}
}
