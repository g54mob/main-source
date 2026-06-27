using FMODUnity;
using Restory.Gameplay.Equipment;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Audio
{
	public class ClickableTriggerSFX : MonoBehaviour
	{
		[SerializeField]
		private ClickableTrigger trigger;

		[SerializeField]
		private EventReference triggerEnterSound;

		[SerializeField]
		private EventReference triggerExitSound;

		[SerializeField]
		private EventReference clickSound;

		private IAudioPlayerService audioPlayer;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnEnable()
		{
			trigger.OnPointerEntered += ResolvePointerEnter;
			trigger.OnPointerExited += ResolvePointerExit;
			trigger.OnClick += ResolveClick;
		}

		private void OnDisable()
		{
			if (trigger.MonoShellExists())
			{
				trigger.OnPointerEntered -= ResolvePointerEnter;
				trigger.OnPointerExited -= ResolvePointerExit;
				trigger.OnClick -= ResolveClick;
			}
		}

		private void ResolveClick()
		{
			audioPlayer?.PlaySoundEventOneShot(clickSound, base.gameObject);
		}

		private void ResolvePointerEnter()
		{
			audioPlayer?.PlaySoundEventOneShot(triggerEnterSound, base.gameObject);
		}

		private void ResolvePointerExit()
		{
			audioPlayer?.PlaySoundEventOneShot(triggerExitSound, base.gameObject);
		}
	}
}
