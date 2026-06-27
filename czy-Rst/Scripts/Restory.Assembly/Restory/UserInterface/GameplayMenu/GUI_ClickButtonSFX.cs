using Restory.Audio;
using Restory.Data.Audio.SoundBanks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Restory.UserInterface.GameplayMenu
{
	[RequireComponent(typeof(Button))]
	public class GUI_ClickButtonSFX : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private GuiEventSoundBank soundBank;

		private Button button;

		private IAudioPlayerService audioPlayer;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void Awake()
		{
			TryGetComponent<Button>(out button);
		}

		private void OnEnable()
		{
			button.onClick.AddListener(ResolveButtonClicked);
		}

		private void OnDisable()
		{
			if (button != null)
			{
				button.onClick.RemoveListener(ResolveButtonClicked);
			}
		}

		private void ResolveButtonClicked()
		{
			audioPlayer.PlaySoundEventOneShot(soundBank.OnPointerClickSound);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (button.isActiveAndEnabled && button.IsInteractable())
			{
				audioPlayer.PlaySoundEventOneShot(soundBank.OnPointerEnterSound);
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (button.isActiveAndEnabled && button.IsInteractable())
			{
				audioPlayer.PlaySoundEventOneShot(soundBank.OnPointerExitSound);
			}
		}
	}
}
