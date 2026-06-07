using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class LoopingAudioScript : MonoBehaviour
	{
		private AudioSource _audioLooping;

		private AudioSource _audioStart;

		private AudioSource _audioStop;

		[SerializeField]
		private float _basePitch = 1f;

		private float _baseVolume = 1f;

		[SerializeField]
		private AudioClip _clipLoop;

		[SerializeField]
		private AudioClip _clipStart;

		[SerializeField]
		private AudioClip _clipStop;

		private float _distanceScale = 1f;

		private bool _initialized;

		private bool _isStarted;

		[SerializeField]
		private float _lerpRate = 10f;

		[SerializeField]
		private float _maxDistance = 5000f;

		[SerializeField]
		private float _minDistance = 100f;

		[SerializeField]
		private AudioMixerGroup _output;

		public float BasePitch
		{
			get
			{
				return _basePitch;
			}
			set
			{
				_basePitch = value;
			}
		}

		public float LerpRate
		{
			get
			{
				return _lerpRate;
			}
			set
			{
				_lerpRate = value;
			}
		}

		public float LoopVolume
		{
			get
			{
				return _audioLooping.volume;
			}
			set
			{
				_audioLooping.volume = value;
			}
		}

		public void Configure(float basePitch, float baseVolume, float distanceScale)
		{
			_basePitch = basePitch;
			_baseVolume = baseVolume;
			_distanceScale = distanceScale;
		}

		public void Initialize()
		{
			if (!_initialized)
			{
				_initialized = true;
				_audioStart = CreateAudioSource(_clipStart);
				_audioStop = CreateAudioSource(_clipStop);
				_audioLooping = CreateAudioSource(_clipLoop, loop: true);
				_audioLooping.time = Random.Range(0f, _audioLooping.clip.length);
			}
			base.gameObject.SetActive(value: true);
		}

		public void PlayStartSound(float volume, float pitch)
		{
			if (_audioStart != null && !_audioStart.isPlaying && _audioStart.gameObject.activeInHierarchy)
			{
				_audioStart.pitch = _basePitch * pitch;
				_audioStart.volume = _baseVolume * volume;
				_audioStart.PlayDelayed(Random.Range(0f, 0.05f));
			}
		}

		public void PlayStopSound(float volume, float pitch)
		{
			if (_audioStop != null && !_audioStop.isPlaying && _audioStop.gameObject.activeInHierarchy)
			{
				_audioStop.pitch = _basePitch * pitch;
				_audioStop.volume = _baseVolume * volume;
				_audioStop.PlayDelayed(Random.Range(0f, 0.05f));
			}
		}

		public void UpdateLoopAudio(float targetVolume, float targetPitch = 1f, float waitForStart = 0f)
		{
			if (_audioLooping == null)
			{
				Initialize();
			}
			float volume = _audioLooping.volume;
			_audioLooping.volume = Mathf.Lerp(volume, targetVolume * _baseVolume, _lerpRate * Time.unscaledDeltaTime);
			_audioLooping.pitch = targetPitch * _basePitch;
			if (targetVolume > 0f)
			{
				if (_audioLooping.isPlaying || !_audioLooping.gameObject.activeInHierarchy)
				{
					return;
				}
				if (_isStarted && (_audioStart.time > waitForStart || !_audioStart.isPlaying))
				{
					_audioLooping.Play();
					return;
				}
				PlayStartSound(targetVolume, targetPitch);
				_isStarted = true;
				if (waitForStart == 0f)
				{
					_audioLooping.Play();
				}
			}
			else if (_audioLooping.isPlaying)
			{
				if (_audioStop != null && volume > 0.01f)
				{
					PlayStopSound(volume, targetPitch);
				}
				_isStarted = false;
				_audioLooping.volume = 0f;
				_audioLooping.Stop();
			}
		}

		private AudioSource CreateAudioSource(AudioClip clip, bool loop = false)
		{
			AudioSource audioSource = null;
			AudioMixerGroup outputAudioMixerGroup = ((_output != null) ? _output : Game.Instance.AudioPlayer.GetGameMixerGroup());
			if (clip != null)
			{
				audioSource = base.gameObject.AddComponent<AudioSource>();
				audioSource.clip = clip;
				audioSource.minDistance = _minDistance * _distanceScale;
				audioSource.maxDistance = _maxDistance * _distanceScale;
				audioSource.loop = loop;
				audioSource.pitch = _basePitch;
				audioSource.outputAudioMixerGroup = outputAudioMixerGroup;
				audioSource.dopplerLevel = 0f;
				audioSource.spread = 0f;
				audioSource.reverbZoneMix = 0f;
				audioSource.spatialBlend = 1f;
				audioSource.playOnAwake = false;
			}
			return audioSource;
		}
	}
}
