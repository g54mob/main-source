using System.Collections;
using FMOD.Studio;
using FMODUnity;
using Restory.Data.Equipment;
using Restory.Gameplay.Equipment;
using UnityEngine;
using Zenject;

namespace Restory.Audio
{
	public class CleanerBrushSFX : MonoBehaviour
	{
		[SerializeField]
		private CleanerBrush cleanerBrush;

		[SerializeField]
		private EventReference defaultCleaningLoop;

		[SerializeField]
		private EventReference defaultEmptyCleaningLoop;

		[SerializeField]
		[Min(0f)]
		private float continuousExecutionStopDelay = 0.2f;

		private EventReference currentToolCleaningLoop;

		private EventReference currentEmptyToolCleaningLoop;

		private EventInstance cleaningLoopInstance;

		private bool isPlayingEmptyLoop;

		private Coroutine stopSoundCoroutine;

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

		public void SetCleaningTool(CleaningToolInfo cleaningTool)
		{
			StopSound();
			currentToolCleaningLoop = (cleaningTool.ToolWorkProcessSoundLoop.IsNull ? defaultCleaningLoop : cleaningTool.ToolWorkProcessSoundLoop);
			currentEmptyToolCleaningLoop = (cleaningTool.ToolWorkProcessEmptySoundLoop.IsNull ? defaultEmptyCleaningLoop : cleaningTool.ToolWorkProcessEmptySoundLoop);
		}

		public void PlaySound(bool isEmpty)
		{
			if (!cleaningLoopInstance.isValid() || isPlayingEmptyLoop != isEmpty)
			{
				StopSound();
				isPlayingEmptyLoop = isEmpty;
				if (isPlayingEmptyLoop)
				{
					audioPlayer.TryToStartSoundEvent(currentEmptyToolCleaningLoop, out cleaningLoopInstance);
				}
				else
				{
					audioPlayer.TryToStartSoundEvent(currentToolCleaningLoop, out cleaningLoopInstance);
				}
			}
			if (stopSoundCoroutine != null)
			{
				StopCoroutine(stopSoundCoroutine);
			}
			stopSoundCoroutine = StartCoroutine(StopSoundWithDelay());
		}

		private IEnumerator StopSoundWithDelay()
		{
			yield return new WaitForSeconds(continuousExecutionStopDelay);
			stopSoundCoroutine = null;
			StopSound();
		}

		private void StopSound()
		{
			if (stopSoundCoroutine != null)
			{
				StopCoroutine(stopSoundCoroutine);
				stopSoundCoroutine = null;
			}
			if (cleaningLoopInstance.isValid())
			{
				audioPlayer.StopSoundEventInstance(cleaningLoopInstance, allowFadeOut: false);
				cleaningLoopInstance.clearHandle();
			}
		}
	}
}
