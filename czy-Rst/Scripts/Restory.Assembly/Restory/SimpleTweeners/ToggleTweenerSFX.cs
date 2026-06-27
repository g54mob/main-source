using FMODUnity;
using Restory.Audio;
using UnityEngine;
using Zenject;

namespace Restory.SimpleTweeners
{
	public class ToggleTweenerSFX : MonoBehaviour
	{
		[SerializeField]
		private ToggleTweenerBase toggleTweener;

		[SerializeField]
		private EventReference activateSound;

		[SerializeField]
		private EventReference deactivateSound;

		private IAudioPlayerService audioPlayer;

		[Inject]
		public void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
			if (base.isActiveAndEnabled)
			{
				Subscribe();
			}
		}

		private void OnEnable()
		{
			if (audioPlayer != null)
			{
				Subscribe();
			}
		}

		private void OnDisable()
		{
			if (audioPlayer != null)
			{
				Unsubscribe();
			}
		}

		private void Subscribe()
		{
			toggleTweener.TweenEvents.OnComplete.AddListener(ResolveOnComplete);
		}

		private void Unsubscribe()
		{
			toggleTweener.TweenEvents.OnComplete.RemoveListener(ResolveOnComplete);
		}

		private void ResolveOnComplete()
		{
			audioPlayer.PlaySoundEventOneShot(toggleTweener.IsOn ? activateSound : deactivateSound);
		}
	}
}
