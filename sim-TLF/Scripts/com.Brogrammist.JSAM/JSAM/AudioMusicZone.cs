using System;
using System.Collections.Generic;
using UnityEngine;

namespace JSAM
{
	[AddComponentMenu("AudioManager/Audio Music Zone")]
	public class AudioMusicZone : BaseAudioMusicFeedback
	{
		[Serializable]
		public class MusicZone
		{
			public Vector3 Position;

			public float MaxDistance;

			public float MinDistance;
		}

		public bool keepPlayingWhenAway;

		public List<MusicZone> MusicZones = new List<MusicZone>();

		private MusicChannelHelper helper;

		private Transform Listener => AudioManager.AudioListener.transform;

		private void Start()
		{
			if (keepPlayingWhenAway)
			{
				helper = AudioManager.PlayMusic(audio, null, helper);
				helper.Reserved = true;
			}
		}

		private void OnDestroy()
		{
			if ((bool)helper)
			{
				helper.Stop();
			}
		}

		private void Update()
		{
			float num = 0f;
			for (int i = 0; i < MusicZones.Count; i++)
			{
				MusicZone musicZone = MusicZones[i];
				float num2 = Vector3.Distance(Listener.position, musicZone.Position);
				if (num2 <= musicZone.MaxDistance)
				{
					if (!helper)
					{
						helper = AudioManager.PlayMusic(audio, null, helper);
						helper.Reserved = true;
					}
					if (num2 <= musicZone.MinDistance)
					{
						helper.AudioSource.volume = AudioManager.InternalInstance.ModifiedMusicVolume * audio.relativeVolume;
						return;
					}
					float num3 = Mathf.InverseLerp(musicZone.MaxDistance, musicZone.MinDistance, num2);
					float num4 = AudioManager.InternalInstance.ModifiedMusicVolume * audio.relativeVolume * num3;
					if (num4 > num)
					{
						num = num4;
					}
				}
			}
			if ((bool)helper)
			{
				helper.AudioSource.volume = num;
			}
		}
	}
}
