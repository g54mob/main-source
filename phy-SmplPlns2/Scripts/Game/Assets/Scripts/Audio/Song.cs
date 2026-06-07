using UnityEngine;

namespace Assets.Scripts.Audio
{
	[CreateAssetMenu(fileName = "New Song", menuName = "SimplePlanes 2/Song")]
	public class Song : ScriptableObject
	{
		[SerializeField]
		private AudioClip _clip;

		[SerializeField]
		private bool _danceSong;

		[SerializeField]
		private SongTags _tags;

		[SerializeField]
		private string _title;

		public bool DanceSong => _danceSong;

		public AudioClip MainClip
		{
			get
			{
				return _clip;
			}
			internal set
			{
				_clip = value;
			}
		}

		public virtual SongTags SupportedTags => Tags;

		public SongTags Tags
		{
			get
			{
				return _tags;
			}
			internal set
			{
				_tags = value;
			}
		}

		public string Title
		{
			get
			{
				return _title;
			}
			internal set
			{
				_title = value;
			}
		}

		public virtual AudioDataLoadState GetLoadState()
		{
			return MainClip.loadState;
		}

		public virtual void LoadAudioData()
		{
			MainClip.LoadAudioData();
		}

		public virtual void UnloadAudioData()
		{
			MainClip.UnloadAudioData();
		}

		protected static void CreateSongImpl<T>() where T : Song
		{
		}

		protected virtual void OnValidate()
		{
			if (_clip != null && _clip.preloadAudioData)
			{
				Debug.LogWarning($"Clip {_clip} is set to preload audio data, turn this off for songs to let the music player load/unload the audio data at will!", _clip);
			}
		}
	}
}
