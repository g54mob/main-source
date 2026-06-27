using System.Collections;
using FMODUnity;
using Restory.Audio;
using Restory.Gameplay.InteractiveObjects;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Storages
{
	public class DevicesFromNpcsServiceSFX : MonoBehaviour
	{
		[SerializeField]
		private DevicesFromNpcsService devicesFromNpcsService;

		[SerializeField]
		private EventReference objectAddedSound;

		private IAudioPlayerService audioPlayer;

		private Coroutine playSoundAtEndOfFrameCoroutine;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnEnable()
		{
			devicesFromNpcsService.OnInteractiveObjectAdded += ResolveNewObjectsAdded;
		}

		private void OnDisable()
		{
			if (devicesFromNpcsService.MonoShellExists())
			{
				devicesFromNpcsService.OnInteractiveObjectAdded -= ResolveNewObjectsAdded;
			}
			if (playSoundAtEndOfFrameCoroutine != null)
			{
				StopCoroutine(playSoundAtEndOfFrameCoroutine);
				playSoundAtEndOfFrameCoroutine = null;
			}
		}

		private void ResolveNewObjectsAdded(InteractiveObject newObject)
		{
			if (playSoundAtEndOfFrameCoroutine == null)
			{
				playSoundAtEndOfFrameCoroutine = StartCoroutine(PlaySoundAtEndOfFrameCoroutine(newObject.gameObject));
			}
		}

		private IEnumerator PlaySoundAtEndOfFrameCoroutine(GameObject soundSource)
		{
			yield return new WaitForEndOfFrame();
			if ((bool)soundSource)
			{
				audioPlayer.PlaySoundEventOneShot(objectAddedSound, soundSource);
			}
			playSoundAtEndOfFrameCoroutine = null;
		}
	}
}
