using System.Collections;
using FMODUnity;
using Restory.Gameplay.InteractiveObjects;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Audio
{
	public class InteractiveTriggerSFX : MonoBehaviour
	{
		[SerializeField]
		private InteractiveObject interactiveObject;

		[SerializeField]
		private EventReference triggerEnterSound;

		[SerializeField]
		private EventReference triggerExitSound;

		[SerializeField]
		private EventReference draggingStartSound;

		[SerializeField]
		private EventReference draggingCompleteSound;

		[SerializeField]
		private EventReference draggingCancelSound;

		private IAudioPlayerService audioPlayer;

		private Coroutine soundPlayingCallback;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnEnable()
		{
			interactiveObject.OnSelected += ResolvePointerEnter;
			interactiveObject.OnDeselected += ResolvePointerExit;
			interactiveObject.OnDragStarted += ResolveDraggingStarted;
			interactiveObject.OnDragComplete += ResolveDraggingCompleted;
			interactiveObject.OnDragStarted += ResolveDraggingCancelled;
		}

		private void OnDisable()
		{
			if (soundPlayingCallback != null)
			{
				StopCoroutine(soundPlayingCallback);
				soundPlayingCallback = null;
			}
			if (interactiveObject.MonoShellExists())
			{
				interactiveObject.OnSelected -= ResolvePointerEnter;
				interactiveObject.OnDeselected -= ResolvePointerExit;
				interactiveObject.OnDragStarted -= ResolveDraggingStarted;
				interactiveObject.OnDragComplete -= ResolveDraggingCompleted;
				interactiveObject.OnDragStarted -= ResolveDraggingCancelled;
			}
		}

		private void ResolvePointerEnter()
		{
			TryToPlaySoundAfterEndOfFrame(triggerEnterSound);
		}

		private void ResolvePointerExit()
		{
			TryToPlaySoundAfterEndOfFrame(triggerExitSound);
		}

		private void ResolveDraggingStarted()
		{
			TryToPlaySoundAfterEndOfFrame(draggingStartSound);
		}

		private void ResolveDraggingCompleted()
		{
			TryToPlaySoundAfterEndOfFrame(draggingCompleteSound);
		}

		private void ResolveDraggingCancelled()
		{
			TryToPlaySoundAfterEndOfFrame(draggingCancelSound);
		}

		private bool TryToPlaySoundAfterEndOfFrame(EventReference soundToPlay)
		{
			if (soundToPlay.IsNull || soundPlayingCallback != null)
			{
				return false;
			}
			soundPlayingCallback = StartCoroutine(SoundPlayingCoroutine(soundToPlay));
			return true;
		}

		private IEnumerator SoundPlayingCoroutine(EventReference soundToPlay)
		{
			yield return new WaitForEndOfFrame();
			audioPlayer?.PlaySoundEventOneShot(soundToPlay, base.gameObject);
			if (soundToPlay.Guid == draggingStartSound.Guid || soundToPlay.Guid == draggingCancelSound.Guid || soundToPlay.Guid == draggingCompleteSound.Guid)
			{
				yield return null;
			}
			soundPlayingCallback = null;
		}
	}
}
