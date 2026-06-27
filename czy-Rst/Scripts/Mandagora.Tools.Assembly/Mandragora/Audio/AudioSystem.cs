using System.Collections.Generic;
using UnityEngine;

namespace Mandragora.Audio
{
	public class AudioSystem
	{
		private List<AudioTrack> _tracks = new List<AudioTrack>();

		public AudioTrack Add<T>(string soundName, bool loop, float volume, bool dontDestroyOnLoad) where T : AudioTrack
		{
			GameObject gameObject = new GameObject(soundName, typeof(T));
			if (dontDestroyOnLoad)
			{
				Object.DontDestroyOnLoad(gameObject);
			}
			AudioTrack component = gameObject.GetComponent<AudioTrack>();
			_tracks.Add(component);
			return component;
		}

		public AudioClip Get(string name)
		{
			return LevelResourcesPreloader.getSound(name);
		}

		public bool Remove(AudioTrack track, bool withoutAction = false)
		{
			if (_tracks.Contains(track))
			{
				if (!withoutAction)
				{
					track.OnDestroyAction();
				}
				_tracks.Remove(track);
				if (track != null && track.gameObject != null)
				{
					Object.Destroy(track.gameObject);
				}
				return true;
			}
			return false;
		}

		public void Stop(AudioThread thread = AudioThread.baseThread)
		{
			for (int i = 0; i < _tracks.Count; i++)
			{
				_tracks[i].Stop(thread);
			}
		}

		public void Clear()
		{
			for (int i = 0; i < _tracks.Count; i++)
			{
				Remove(_tracks[i], withoutAction: true);
			}
			_tracks.Clear();
		}

		public void Pause(AudioThread thread = AudioThread.baseThread)
		{
			for (int i = 0; i < _tracks.Count; i++)
			{
				_tracks[i].Pause(thread);
			}
		}

		public void UnPause(AudioThread thread = AudioThread.baseThread)
		{
			for (int i = 0; i < _tracks.Count; i++)
			{
				_tracks[i].UnPause(thread);
			}
		}

		public void RemoveEmptyLinks()
		{
			for (int i = 0; i < _tracks.Count; i++)
			{
				if (_tracks[i] == null)
				{
					_tracks.RemoveAt(i);
					i--;
				}
			}
		}
	}
}
