using System;
using FMOD.Studio;
using FMODUnity;
using Restory.Audio;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment.DevicePaintingTools
{
	public sealed class PaintingBrushSFX : MonoBehaviour
	{
		[SerializeField]
		private PaintingBrush paintingBrush;

		[SerializeField]
		private EventReference bigBrushPaintingLoop;

		[SerializeField]
		private EventReference smallBrushPaintingLoop;

		private EventInstance bigBrushPaintingLoopInstance;

		private EventInstance smallBrushPaintingLoopInstance;

		private IAudioPlayerService audioPlayer;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnDisable()
		{
			if (audioPlayer != null)
			{
				StopSound();
			}
		}

		public void StartOrContinueSound()
		{
			switch (paintingBrush.BrushRaycastingMode)
			{
			case BrushRaycastingMode.ConcentricCirclesMultiRaycasts:
				StartOrContinueLoopAExclusively(bigBrushPaintingLoop, ref bigBrushPaintingLoopInstance, ref smallBrushPaintingLoopInstance);
				break;
			case BrushRaycastingMode.SingleRaycastWithAddedRaycastsLine:
				StartOrContinueLoopAExclusively(smallBrushPaintingLoop, ref smallBrushPaintingLoopInstance, ref bigBrushPaintingLoopInstance);
				break;
			default:
				throw new NotImplementedException();
			}
		}

		public void StopSound()
		{
			audioPlayer.StopSoundEventInstance(bigBrushPaintingLoopInstance);
			audioPlayer.StopSoundEventInstance(smallBrushPaintingLoopInstance);
			bigBrushPaintingLoopInstance.clearHandle();
			smallBrushPaintingLoopInstance.clearHandle();
		}

		private void StartOrContinueLoopAExclusively(EventReference loopAEventReference, ref EventInstance loopAEventInstance, ref EventInstance loopBEventInstance)
		{
			if (loopBEventInstance.isValid())
			{
				audioPlayer.StopSoundEventInstance(loopBEventInstance, allowFadeOut: false);
				loopBEventInstance.clearHandle();
			}
			if (loopAEventInstance.isValid())
			{
				loopAEventInstance.getPlaybackState(out var state);
				if (state != PLAYBACK_STATE.PLAYING)
				{
					audioPlayer.RestartSoundEventInstance(loopAEventInstance);
				}
			}
			else
			{
				audioPlayer.TryToStartSoundEvent(loopAEventReference, out loopAEventInstance);
			}
		}
	}
}
