using UnityEngine;
using UnityEngine.Audio;

namespace CTS
{
	[CreateAssetMenu(fileName = "Music Track", menuName = "BBT/Music/Music Track")]
	public class MusicTrack : ScriptableObject
	{
		[SerializeField]
		private AudioMixerGroup _mixerGroup;

		[SerializeField]
		private AudioMixerSnapshot _snapshot;

		private AudioSource _source;

		public bool IsPlaying => _source.isPlaying;

		public bool IsNotPlaying => !IsPlaying;

		public float PlayingMusicTimeLeft => _source.clip.length - _source.time;

		public void Initialize(MusicManager musicManager)
		{
			GameObject gameObject = new GameObject(base.name + " Audio Source");
			gameObject.transform.SetParent(musicManager.transform);
			_source = gameObject.AddComponent<AudioSource>();
			_source.playOnAwake = false;
			_source.loop = false;
			_source.outputAudioMixerGroup = _mixerGroup;
			_source.ignoreListenerPause = true;
		}

		public void PlayClip(AudioClip clipToPlay, float crossfadeDuration)
		{
			_source.clip = clipToPlay;
			_source.PlayDelayed(1f);
			_snapshot.TransitionTo(crossfadeDuration);
		}

		public void PlayClipFromPlaylist(MusicPlaylist playlist, float crossfadeDuration)
		{
			PlayClip(playlist.GetNextMusicClip(), crossfadeDuration);
		}

		public void Stop()
		{
			_source.Stop();
		}
	}
}
