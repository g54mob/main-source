using FMOD.Studio;
using FMODUnity;
using Restory.Audio;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment.Ultrasonic
{
	public class SonicBathCleaningEffectsPlayer : MonoBehaviour
	{
		[SerializeField]
		private SonicBathVibration vibration;

		[SerializeField]
		private SonicBathBacklight backlight;

		[SerializeField]
		private SonicBathWater water;

		[SerializeField]
		private EventReference vibrationSoundLoop;

		[SerializeField]
		private EventReference bubblesSoundLoop;

		private IAudioPlayerService audioPlayerService;

		private EventInstance vibrationLoopSoundInstance;

		private EventInstance bubblesLoopSoundInstance;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayerService)
		{
			this.audioPlayerService = audioPlayerService;
		}

		private void OnDisable()
		{
			KillSoundLoops();
		}

		public void Play()
		{
			vibration.StartVibration();
			backlight.TurnOn();
			water.StartBubbling();
			StartSoundLoops();
		}

		public void Stop()
		{
			vibration.StopVibration();
			backlight.TurnOff();
			water.StopBubbling();
			KillSoundLoops();
		}

		private void StartSoundLoops()
		{
			StartSoundLoop(vibrationSoundLoop, ref vibrationLoopSoundInstance);
			StartSoundLoop(bubblesSoundLoop, ref bubblesLoopSoundInstance);
		}

		private void StartSoundLoop(EventReference soundEventReference, ref EventInstance soundEventInstance)
		{
			audioPlayerService.TryToStartSoundEvent(soundEventReference, base.gameObject, out soundEventInstance);
		}

		private void KillSoundLoops()
		{
			audioPlayerService.StopSoundEventInstance(vibrationLoopSoundInstance);
			audioPlayerService.StopSoundEventInstance(bubblesLoopSoundInstance);
			vibrationLoopSoundInstance.release();
			bubblesLoopSoundInstance.release();
		}
	}
}
