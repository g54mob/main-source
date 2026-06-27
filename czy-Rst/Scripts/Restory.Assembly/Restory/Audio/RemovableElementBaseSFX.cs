using System;
using System.Collections;
using FMODUnity;
using Restory.Gameplay.Common;
using Restory.Gameplay.Elements;
using UnityEngine;
using Zenject;

namespace Restory.Audio
{
	public class RemovableElementBaseSFX : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("This sound will play if the player is trying to execute the action, and it successfully starts executing.")]
		protected EventReference successSoundEvent;

		[SerializeField]
		[Tooltip("This sound will play if the player is trying to execute the action, but it can't be executed.")]
		protected EventReference failSoundEvent;

		[SerializeField]
		protected EventReference dropSoundEvent;

		[SerializeField]
		protected EventReference installSoundEvent;

		[SerializeField]
		protected ElementBase removableElement;

		[SerializeField]
		protected FallingElementCollisionsDetector elementCollisionsDetector;

		protected IAudioPlayerService audioPlayer;

		private CollidingObjectsSfxService collidingObjectsSfxService;

		private ActiveStateSwitcher activeStateSwitcher;

		private Coroutine invokeCallbackAfterEndOfFrameCoroutine;

		[Inject]
		public void Construct(IAudioPlayerService audioPlayer, CollidingObjectsSfxService collidingObjectsSfxService)
		{
			this.audioPlayer = audioPlayer;
			this.collidingObjectsSfxService = collidingObjectsSfxService;
			activeStateSwitcher = new ActiveStateSwitcher(ActiveStateSwitcher.WorkMode.ActiveByDefaultAndRequestersMakeItInactive);
		}

		protected virtual void OnEnable()
		{
			removableElement.OnDetached.AddListener(ResolveObjectSuccessfullyDetached);
			removableElement.OnDragging.AddListener(ResolveDragging);
			removableElement.OnInteractionCanceled.AddListener(ResolveObjectInteractionCancelled);
			removableElement.OnInstalled.AddListener(ResolveObjectInstalledIntoDevice);
			if ((bool)elementCollisionsDetector)
			{
				elementCollisionsDetector.OnDropHitDetected += ResolveDropHit;
			}
		}

		protected virtual void OnDisable()
		{
			if (invokeCallbackAfterEndOfFrameCoroutine != null)
			{
				StopCoroutine(invokeCallbackAfterEndOfFrameCoroutine);
				invokeCallbackAfterEndOfFrameCoroutine = null;
			}
			if (removableElement != null)
			{
				removableElement.OnDetached.RemoveListener(ResolveObjectSuccessfullyDetached);
				removableElement.OnDragging.RemoveListener(ResolveDragging);
				removableElement.OnInteractionCanceled.RemoveListener(ResolveObjectInteractionCancelled);
				removableElement.OnInstalled.RemoveListener(ResolveObjectInstalledIntoDevice);
			}
			if ((bool)elementCollisionsDetector)
			{
				elementCollisionsDetector.OnDropHitDetected -= ResolveDropHit;
			}
			activeStateSwitcher?.Clear();
		}

		public void BlockSounds(IActiveStateSwitchRequester blocker)
		{
			activeStateSwitcher.AddRequester(blocker);
		}

		public void UnBlockSounds(IActiveStateSwitchRequester blocker)
		{
			activeStateSwitcher.RemoveRequester(blocker);
		}

		protected virtual void ResolveObjectSuccessfullyDetached()
		{
			PlaySound(successSoundEvent);
		}

		private void ResolveDragging()
		{
			if (activeStateSwitcher.ShouldSystemBeActive)
			{
				PlaySound(successSoundEvent);
			}
		}

		private void ResolveObjectInteractionCancelled()
		{
			PlaySound(failSoundEvent);
		}

		protected virtual void ResolveObjectInstalledIntoDevice()
		{
			PlaySound(installSoundEvent);
		}

		protected virtual void ResolveDropHit(Collision hitCollision)
		{
			if (invokeCallbackAfterEndOfFrameCoroutine != null)
			{
				return;
			}
			if (hitCollision == null && activeStateSwitcher.ShouldSystemBeActive)
			{
				PlaySound(dropSoundEvent);
				return;
			}
			Vector3 collisionPoint = ((hitCollision.contactCount > 0) ? hitCollision.GetContact(0).point : base.transform.position);
			RemovableElementBaseSFX component;
			bool hitRemovableElement = (bool)hitCollision.gameObject && hitCollision.gameObject.TryGetComponent<RemovableElementBaseSFX>(out component);
			invokeCallbackAfterEndOfFrameCoroutine = StartCoroutine(InvokeCallbackAfterEndOfFrameCoroutine(delegate
			{
				if (activeStateSwitcher.ShouldSystemBeActive)
				{
					if (hitRemovableElement)
					{
						collidingObjectsSfxService.TryToPlayCollisionSound(collisionPoint, dropSoundEvent);
					}
					else
					{
						PlaySound(dropSoundEvent);
					}
				}
			}));
		}

		private IEnumerator InvokeCallbackAfterEndOfFrameCoroutine(Action callback)
		{
			yield return new WaitForEndOfFrame();
			callback?.Invoke();
			invokeCallbackAfterEndOfFrameCoroutine = null;
		}

		private void PlaySound(EventReference soundEvent)
		{
			audioPlayer.PlaySoundEventOneShot(soundEvent, base.gameObject);
		}
	}
}
