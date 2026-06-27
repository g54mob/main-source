using System.Collections;
using FMODUnity;
using Restory.Audio;
using Restory.Gameplay.Common;
using Restory.Gameplay.Elements;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment.Ultrasonic
{
	public sealed class SonicBathSFX : MonoBehaviour, IActiveStateSwitchRequester
	{
		[SerializeField]
		private SonicBath sonicBath;

		[SerializeField]
		private EventReference elementInsertSound;

		[SerializeField]
		private EventReference elementRetrievedSound;

		private IAudioPlayerService audioPlayer;

		private Coroutine unblockElementSoundsAfterOneFrameCoroutine;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnEnable()
		{
			sonicBath.OnElementInserted += ResolveElementInserted;
			sonicBath.OnElementRetrieved += ResolveElementRetrieved;
		}

		private void OnDisable()
		{
			if (sonicBath.MonoShellExists())
			{
				sonicBath.OnElementInserted -= ResolveElementInserted;
				sonicBath.OnElementRetrieved -= ResolveElementRetrieved;
			}
			if (unblockElementSoundsAfterOneFrameCoroutine != null)
			{
				StopCoroutine(unblockElementSoundsAfterOneFrameCoroutine);
				unblockElementSoundsAfterOneFrameCoroutine = null;
			}
		}

		private void ResolveElementInserted(ElementBase element)
		{
			if (element.TryGetComponent<RemovableElementBaseSFX>(out var component))
			{
				component.BlockSounds(this);
			}
			audioPlayer.PlaySoundEventOneShot(elementInsertSound, element.transform.position);
		}

		private void ResolveElementRetrieved(ElementBase element)
		{
			audioPlayer.PlaySoundEventOneShot(elementRetrievedSound, element.transform.position);
			if (element.TryGetComponent<RemovableElementBaseSFX>(out var component))
			{
				if (unblockElementSoundsAfterOneFrameCoroutine != null)
				{
					StopCoroutine(unblockElementSoundsAfterOneFrameCoroutine);
				}
				unblockElementSoundsAfterOneFrameCoroutine = StartCoroutine(UnblockElementSoundsAfterOneFrameCoroutine(element, component));
			}
		}

		private IEnumerator UnblockElementSoundsAfterOneFrameCoroutine(ElementBase element, RemovableElementBaseSFX elementSfx)
		{
			yield return null;
			if (element.MonoShellExists() && elementSfx.MonoShellExists() && !sonicBath.InsertedElements.ContainsKey(element))
			{
				elementSfx.UnBlockSounds(this);
			}
			unblockElementSoundsAfterOneFrameCoroutine = null;
		}
	}
}
