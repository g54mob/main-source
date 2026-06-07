using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.Audio
{
	[RequireComponent(typeof(AudioSourceController))]
	public class MusicTrack : MonoBehaviour
	{
		public bool Enabled;

		[SerializeField]
		[FormerlySerializedAs("TrackName")]
		private string _trackName;

		[SerializeField]
		[FormerlySerializedAs("Priority")]
		private int _priority;

		[SerializeField]
		[FormerlySerializedAs("VolumeMultiplier")]
		protected float _volumeMultiplier;

		[FormerlySerializedAs("FadeInTime")]
		[SerializeField]
		protected float _fadeInTime;

		[SerializeField]
		[FormerlySerializedAs("FadeOutTime")]
		protected float _fadeOutTime;

		[FormerlySerializedAs("AutoFadeOut")]
		[SerializeField]
		protected bool _autoFadeOut;

		protected AudioSourceController _audioSource;

		protected float _fadeVolumeMultiplier;

		public bool IsPlaying { get; private set; }

		public string TrackName => null;

		public int Priority => 0;

		protected virtual void Awake()
		{
		}

		private void OnValidate()
		{
		}

		public void Enable()
		{
		}

		public void Disable()
		{
		}

		public virtual void Play()
		{
		}

		public virtual void Stop()
		{
		}

		protected virtual void Update()
		{
		}
	}
}
