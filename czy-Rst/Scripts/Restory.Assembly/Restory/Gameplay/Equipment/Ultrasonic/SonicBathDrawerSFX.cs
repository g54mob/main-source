using FMODUnity;
using Restory.Audio;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment.Ultrasonic
{
	public sealed class SonicBathDrawerSFX : MonoBehaviour
	{
		[SerializeField]
		private SonicBathDrawer sonicBathDrawer;

		[SerializeField]
		private EventReference pullingSound;

		[SerializeField]
		private EventReference pushingSound;

		private IAudioPlayerService audioPlayer;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnEnable()
		{
			sonicBathDrawer.OnPullingAnimationStarted += ResolveStartedPulling;
			sonicBathDrawer.OnPushingAnimationStarted += ResolveStartedPushing;
		}

		private void OnDisable()
		{
			if (sonicBathDrawer.MonoShellExists())
			{
				sonicBathDrawer.OnPullingAnimationStarted -= ResolveStartedPulling;
				sonicBathDrawer.OnPushingAnimationStarted -= ResolveStartedPushing;
			}
		}

		private void ResolveStartedPulling()
		{
			audioPlayer.PlaySoundEventOneShot(pullingSound, base.gameObject);
		}

		private void ResolveStartedPushing()
		{
			audioPlayer.PlaySoundEventOneShot(pushingSound, base.gameObject);
		}
	}
}
