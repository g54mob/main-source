using System.Collections;
using FMOD.Studio;
using FMODUnity;
using Restory.Data.Equipment;
using Restory.Gameplay.Elements;
using UnityEngine;

namespace Restory.Audio
{
	[RequireComponent(typeof(ThreadedElement))]
	public class ThreadedElementSFX : RemovableElementBaseSFX
	{
		[SerializeField]
		private EventReference holdSoundEvent;

		[SerializeField]
		private EventReference shortSoundEvent;

		private ThreadedElement disassembleElement;

		private EventInstance shortSoundInstance;

		private EventInstance holdSoundInstance;

		private Coroutine repeatingSoundCoroutine;

		private void Awake()
		{
			disassembleElement = removableElement as ThreadedElement;
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			disassembleElement.OnStartedHolding.AddListener(ResolveStartedHolding);
			disassembleElement.OnStoppedHolding.AddListener(ResolveStoppedHolding);
			disassembleElement.OnImmediateShortInteraction.AddListener(ResolveImmediateShortInteraction);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (disassembleElement != null)
			{
				disassembleElement.OnStartedHolding.RemoveListener(ResolveStartedHolding);
				disassembleElement.OnStoppedHolding.RemoveListener(ResolveStoppedHolding);
				disassembleElement.OnImmediateShortInteraction.RemoveListener(ResolveImmediateShortInteraction);
			}
			if (audioPlayer != null)
			{
				KillHoldSound();
			}
		}

		private void ResolveImmediateShortInteraction(ThreadedElement shortActionElement, ToolInfo toolInfo)
		{
			KillShortSound();
			EventReference soundEvent = ((!disassembleElement.IsSelfScrewingWithoutTool && toolInfo is UnscrewingToolInfo { ScrewingSound: { IsNull: false } } unscrewingToolInfo) ? unscrewingToolInfo.ScrewingSound : shortSoundEvent);
			audioPlayer.TryToStartSoundEvent(soundEvent, base.gameObject, out shortSoundInstance);
		}

		private void ResolveStartedHolding(ThreadedElement longActionElement, ToolInfo toolInfo)
		{
			KillShortSound();
			EventReference soundEvent = ((!disassembleElement.IsSelfScrewingWithoutTool && toolInfo is UnscrewingToolInfo { ScrewingSound: { IsNull: false } } unscrewingToolInfo) ? unscrewingToolInfo.ScrewingSound : holdSoundEvent);
			audioPlayer.TryToStartSoundEvent(soundEvent, base.gameObject, out holdSoundInstance);
			holdSoundInstance.getDescription(out var description);
			description.isOneshot(out var oneshot);
			if (oneshot && repeatingSoundCoroutine == null)
			{
				repeatingSoundCoroutine = StartCoroutine(RepeatingSoundCoroutine());
			}
		}

		private IEnumerator RepeatingSoundCoroutine()
		{
			while (holdSoundInstance.isValid())
			{
				holdSoundInstance.getPlaybackState(out var state);
				if (state == PLAYBACK_STATE.STOPPED)
				{
					holdSoundInstance.start();
				}
				yield return null;
			}
			repeatingSoundCoroutine = null;
		}

		private void ResolveStoppedHolding()
		{
			KillHoldSound();
		}

		protected override void ResolveObjectSuccessfullyDetached()
		{
			KillHoldSound();
			base.ResolveObjectSuccessfullyDetached();
		}

		protected override void ResolveDropHit(Collision hitCollision)
		{
			KillHoldSound();
			base.ResolveDropHit(hitCollision);
		}

		protected override void ResolveObjectInstalledIntoDevice()
		{
			KillHoldSound();
			base.ResolveObjectInstalledIntoDevice();
		}

		private void KillHoldSound()
		{
			audioPlayer.StopSoundEventInstance(holdSoundInstance, allowFadeOut: false);
			holdSoundInstance.clearHandle();
			if (repeatingSoundCoroutine != null)
			{
				StopCoroutine(repeatingSoundCoroutine);
				repeatingSoundCoroutine = null;
			}
		}

		private void KillShortSound()
		{
			audioPlayer.StopSoundEventInstance(shortSoundInstance, allowFadeOut: false);
			shortSoundInstance.clearHandle();
		}
	}
}
