using UnityEngine;

namespace AudioSystem
{
	public class SoundBuilder
	{
		private readonly SoundEmitterManager soundManager;

		public SoundBuilder(SoundEmitterManager soundManager)
		{
			this.soundManager = soundManager;
		}

		public SoundEmitter Play(SoundData soundData, float targetPitch = 0f, bool matchVolumeWithTrainSpeed = false)
		{
			if (soundData == null)
			{
				Debug.LogError("SoundData is null");
				return null;
			}
			if (!soundManager.CanPlaySound(soundData))
			{
				return null;
			}
			SoundEmitter soundEmitter = soundManager.Get();
			soundEmitter.Initialize(soundData);
			soundEmitter.transform.parent = soundManager.transform;
			if (soundData.frequentSound)
			{
				soundEmitter.Node = soundManager.FrequentSoundEmitters[soundData.frequentSoundType].AddLast(soundEmitter);
			}
			soundEmitter.Play(targetPitch, matchVolumeWithTrainSpeed);
			return soundEmitter;
		}

		public void FindAndStop(SoundData soundData, bool stopAll = false)
		{
			if (soundData == null)
			{
				Debug.LogError("SoundData is null");
			}
			else
			{
				if (PersistentSingleton<SoundEmitterManager>.Instance.activeSoundEmitters.Count == 0)
				{
					return;
				}
				for (int i = 0; i < PersistentSingleton<SoundEmitterManager>.Instance.activeSoundEmitters.Count; i++)
				{
					SoundEmitter soundEmitter = PersistentSingleton<SoundEmitterManager>.Instance.activeSoundEmitters[i];
					if (soundEmitter.Data == soundData)
					{
						soundEmitter.Stop();
					}
					if (!stopAll)
					{
						break;
					}
				}
			}
		}
	}
}
