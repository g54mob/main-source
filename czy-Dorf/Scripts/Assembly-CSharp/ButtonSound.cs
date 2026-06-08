using Michsky.UI.ModernUIPack;
using UnityEngine;

[RequireComponent(typeof(ButtonManager))]
public class ButtonSound : MonoBehaviour
{
	[SerializeField]
	private AudioClipOptions clickSound;

	[SerializeField]
	private AudioClipOptions hoverSound;

	private ButtonManager buttonManager;

	private void Awake()
	{
		buttonManager = GetComponent<ButtonManager>();
		buttonManager.hoverEvent.AddListener(PlayHoverSound);
		buttonManager.clickEvent.AddListener(PlayClickSound);
	}

	private void PlayClickSound()
	{
		AudioManager.Instance.PlayGlobalSound(clickSound);
	}

	private void PlayHoverSound()
	{
		AudioManager.Instance.PlayGlobalSound(hoverSound);
	}
}
