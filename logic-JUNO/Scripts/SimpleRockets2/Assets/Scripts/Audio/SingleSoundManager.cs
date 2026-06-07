using System.Collections.Generic;
using ModApi.Audio;
using UnityEngine;

namespace Assets.Scripts.Audio
{
	public class SingleSoundManager : MonoBehaviour, ISingleSoundManager
	{
		private Dictionary<string, ISingleSound> _sounds;

		public SingleSoundManager()
		{
			_sounds = new Dictionary<string, ISingleSound>();
		}

		public ISingleSound GetSingleSound(string soundResource)
		{
			ISingleSound value = null;
			if (!_sounds.TryGetValue(soundResource, out value))
			{
				value = SingleSound.Create(soundResource, base.transform, 0.5f, Game.Instance.AudioPlayer.GetGameMixerGroup());
				_sounds[soundResource] = value;
			}
			return value;
		}

		private void LateUpdate()
		{
			foreach (ISingleSound value in _sounds.Values)
			{
				value.NewFrame();
			}
		}
	}
}
