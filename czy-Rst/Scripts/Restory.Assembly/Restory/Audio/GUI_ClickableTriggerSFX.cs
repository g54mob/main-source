using FMODUnity;
using Restory.UI.Common;
using UnityEngine;
using Zenject;

namespace Restory.Audio
{
	public class GUI_ClickableTriggerSFX : MonoBehaviour
	{
		[SerializeField]
		private GUI_ClickableTrigger trigger;

		[SerializeField]
		private EventReference triggerClickSound;

		[SerializeField]
		private EventReference triggerEnterSound;

		[SerializeField]
		private EventReference triggerExitSound;

		private IAudioPlayerService audioPlayer;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnEnable()
		{
			trigger.OnClick += ResolveClick;
			trigger.OnPointerEntered += ResolvePointerEnter;
			trigger.OnPointerExited += ResolvePointerExit;
		}

		private void OnDisable()
		{
			if ((bool)trigger)
			{
				trigger.OnClick -= ResolveClick;
				trigger.OnPointerEntered -= ResolvePointerEnter;
				trigger.OnPointerExited -= ResolvePointerExit;
			}
		}

		private void ResolveClick()
		{
			audioPlayer?.PlaySoundEventOneShot(triggerClickSound);
		}

		private void ResolvePointerEnter()
		{
			audioPlayer?.PlaySoundEventOneShot(triggerEnterSound);
		}

		private void ResolvePointerExit()
		{
			audioPlayer?.PlaySoundEventOneShot(triggerExitSound);
		}
	}
}
