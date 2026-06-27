using FMODUnity;
using Restory.Audio;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment.Levers
{
	public class LeverMovementSFX : MonoBehaviour
	{
		[SerializeField]
		private LeverMovementVisualizer leverMovementVisualizer;

		[SerializeField]
		private EventReference leverStartMovementSound;

		[SerializeField]
		private EventReference leverEndMovementSound;

		private IAudioPlayerService audioPlayer;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnEnable()
		{
			leverMovementVisualizer.OnMovementStarted += ResolveMovementStarted;
			leverMovementVisualizer.OnMovementEnded += ResolveMovementEnded;
		}

		private void OnDisable()
		{
			if (leverMovementVisualizer.MonoShellExists())
			{
				leverMovementVisualizer.OnMovementStarted -= ResolveMovementStarted;
				leverMovementVisualizer.OnMovementEnded -= ResolveMovementEnded;
			}
		}

		private void ResolveMovementStarted()
		{
			audioPlayer.PlaySoundEventOneShot(leverStartMovementSound, base.gameObject);
		}

		private void ResolveMovementEnded()
		{
			audioPlayer.PlaySoundEventOneShot(leverEndMovementSound, base.gameObject);
		}
	}
}
