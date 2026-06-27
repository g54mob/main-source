using FMODUnity;
using Restory.Audio;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment.Levers
{
	public class VerticalLeverSFX : MonoBehaviour
	{
		[SerializeField]
		private VerticalLever lever;

		[SerializeField]
		private EventReference pointerEnterSound;

		[SerializeField]
		private EventReference pointerExitSound;

		private IAudioPlayerService audioPlayer;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnEnable()
		{
			lever.OnPointerEntered += ResolvePointerEntered;
			lever.OnPointerExited += ResolvePointerExited;
		}

		private void OnDisable()
		{
			if (lever.MonoShellExists())
			{
				lever.OnPointerEntered -= ResolvePointerEntered;
				lever.OnPointerExited -= ResolvePointerExited;
			}
		}

		private void ResolvePointerEntered()
		{
			audioPlayer.PlaySoundEventOneShot(pointerEnterSound, base.gameObject);
		}

		private void ResolvePointerExited()
		{
			audioPlayer.PlaySoundEventOneShot(pointerExitSound, base.gameObject);
		}
	}
}
