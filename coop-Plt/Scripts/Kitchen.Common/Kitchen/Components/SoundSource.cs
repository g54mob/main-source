using UnityEngine;

namespace Kitchen.Components
{
	public class SoundSource : BaseSoundSource
	{
		public float VolumeMultiplier = 1f;

		public AudioClip Clip;

		public float TransitionTime = 0.5f;

		public float TargetVolume;

		public bool ShouldLoop = true;

		public float Pitch = 1f;

		private float _Volume;

		public bool IsPlaying
		{
			get
			{
				if (Audio != null)
				{
					return Audio.isPlaying;
				}
				return false;
			}
		}

		public void Play()
		{
			TargetVolume = 1f;
			if (!(Audio == null) && (!ShouldLoop || !Audio.isPlaying))
			{
				Audio.Play();
			}
		}

		public void Stop()
		{
			TargetVolume = 0f;
			if (!(Audio == null) && !ShouldLoop)
			{
				Audio.Stop();
			}
		}

		public void Toggle(bool play)
		{
			if (play)
			{
				Play();
			}
			else
			{
				Stop();
			}
		}

		public void Configure(SoundCategory cat, AudioClip clip)
		{
			if (!base.gameObject.TryGetComponent<AudioSource>(out Audio))
			{
				Audio = base.gameObject.AddComponent<AudioSource>();
			}
			Category = cat;
			Clip = clip;
		}

		protected override void Initialise()
		{
			Audio.loop = ShouldLoop;
			Audio.volume = 0f;
		}

		protected virtual void Update()
		{
			if (!base.gameObject.TryGetComponent<AudioSource>(out Audio))
			{
				Audio = base.gameObject.AddComponent<AudioSource>();
			}
			_Volume = Mathf.MoveTowards(_Volume, TargetVolume, Time.unscaledDeltaTime / TransitionTime);
			Volume = _Volume * VolumeMultiplier;
			Audio.pitch = Pitch;
			if (Audio.clip != Clip)
			{
				Audio.clip = Clip;
				Audio.Play();
			}
			SetVolume();
		}
	}
}
