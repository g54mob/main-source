using FMODUnity;
using Restory.Audio;
using Restory.Data.Audio.SoundBanks;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Restory.UserInterface
{
	public class GUI_SfxEventHandler : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
	{
		[Header("General settings")]
		[SerializeField]
		protected GuiEventSoundBank soundBank;

		private IAudioPlayerService audioPlayer;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (IsCorrect())
			{
				audioPlayer.PlaySoundEventOneShot(soundBank.OnPointerEnterSound);
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (IsCorrect())
			{
				audioPlayer.PlaySoundEventOneShot(soundBank.OnPointerExitSound);
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			if (IsCorrect())
			{
				audioPlayer.PlaySoundEventOneShot(soundBank.OnPointerDownSound);
			}
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			if (IsCorrect())
			{
				audioPlayer.PlaySoundEventOneShot(soundBank.OnPointerUpSound);
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (IsCorrect())
			{
				audioPlayer.PlaySoundEventOneShot(soundBank.OnPointerClickSound);
			}
		}

		protected void TryToPlaySound(EventReference soundToPlay)
		{
			if (IsCorrect())
			{
				audioPlayer.PlaySoundEventOneShot(soundToPlay);
			}
		}

		protected virtual bool IsCorrect()
		{
			if (audioPlayer == null)
			{
				Debug.LogWarning("[GUI_SfxEventHandler] the audioPlayer is not ready", base.gameObject);
				return false;
			}
			if (soundBank == null)
			{
				Debug.LogWarning("[GUI_SfxEventHandler] the soundBank is null", base.gameObject);
				return false;
			}
			return true;
		}
	}
}
