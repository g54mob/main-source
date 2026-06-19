#define LOG_LEVEL_VERBOSE
using UnityEngine;
using UnityEngine.Audio;

namespace TH20
{
	public class AudioEmitter : MonoBehaviour
	{
		private struct CullState
		{
			public byte ActiveAudioSource;

			public float Time;

			public bool Finished;
		}

		private AudioSource _mainAudioSource;

		private AudioSource _introAudioSource;

		private AudioSource _outroAudioSource;

		private bool _isPaused;

		private float _volume = 1f;

		private float _mainAudioVolume;

		private float _introAudioVolume;

		private float _outroAudioVolume;

		private bool _isCulled;

		private byte _activeAudioSourceOnPause;

		private AudioLowPassFilter _mainAudioLowPassFilter;

		private AudioLowPassFilter _introAudioLowPassFilter;

		private AudioLowPassFilter _outroAudioLowPassFilter;

		private CullState _cullState;

		public Transform AttachedTo;

		public AudioEvent AudioEvent;

		public bool AutoRolloff;

		public float AutoRolloffMinRadiusMultiplier = 1f;

		public float AutoRolloffMaxRadiusMultiplier = 1f;

		public GameObject _gameObjectMain;

		public GameObject _gameObjectIntro;

		public GameObject _gameObjectOutro;

		public float Volume
		{
			get
			{
				return _volume;
			}
			set
			{
				_volume = Mathf.Clamp01(value);
			}
		}

		public bool IsPaused => _isPaused;

		public AudioMixerGroup AudioMixerGroup => AudioEvent.OutputAudioMixerGroup;

		public bool Finished
		{
			get
			{
				if (_isCulled)
				{
					return _cullState.Finished;
				}
				if (!_isPaused)
				{
					bool num = !_introAudioSource.enabled || !_introAudioSource.isPlaying;
					bool flag = !_mainAudioSource.enabled || !_mainAudioSource.isPlaying;
					bool flag2 = !_outroAudioSource.enabled || !_outroAudioSource.isPlaying;
					return num && flag && flag2;
				}
				if (!_introAudioSource.enabled && !_mainAudioSource.enabled)
				{
					return !_outroAudioSource.enabled;
				}
				return false;
			}
		}

		private AudioSource CurrentAudioSource
		{
			get
			{
				if (!_isPaused)
				{
					if (_introAudioSource.enabled && _introAudioSource.isPlaying)
					{
						return _introAudioSource;
					}
					if (_mainAudioSource.enabled && _mainAudioSource.isPlaying)
					{
						return _mainAudioSource;
					}
					if (_outroAudioSource.enabled && _outroAudioSource.isPlaying)
					{
						return _outroAudioSource;
					}
				}
				else
				{
					switch (_activeAudioSourceOnPause)
					{
					case 0:
						return _introAudioSource;
					case 1:
						return _mainAudioSource;
					case 2:
						return _outroAudioSource;
					}
				}
				return null;
			}
		}

		private void EnterCullMode()
		{
			if (_isCulled || Finished)
			{
				return;
			}
			AudioSource currentAudioSource = CurrentAudioSource;
			if (currentAudioSource == null)
			{
				Logging.Error(LogChannels.Audio, "CurrentAudioSource on {0} is null when Entering Cull State", base.name);
				return;
			}
			if (_introAudioSource.enabled && _introAudioSource == currentAudioSource)
			{
				_cullState.ActiveAudioSource = 0;
			}
			else if (_mainAudioSource.enabled && _mainAudioSource == currentAudioSource)
			{
				_cullState.ActiveAudioSource = 1;
			}
			else if (_outroAudioSource.enabled && _outroAudioSource == currentAudioSource)
			{
				_cullState.ActiveAudioSource = 2;
			}
			else
			{
				Logging.Error(LogChannels.Audio, "CurrentAudioSource {0} on {1} does not fit criteria for Entering Cull State", currentAudioSource.name, base.name);
			}
			_cullState.Time = currentAudioSource.time;
			if (_gameObjectIntro.activeSelf)
			{
				_gameObjectIntro.SetActive(value: false);
			}
			if (_gameObjectMain.activeSelf)
			{
				_gameObjectMain.SetActive(value: false);
			}
			if (_gameObjectOutro.activeSelf)
			{
				_gameObjectOutro.SetActive(value: false);
			}
			_isCulled = true;
		}

		private void ExitCullMode()
		{
			if (!_isCulled)
			{
				return;
			}
			if (!_gameObjectIntro.activeSelf)
			{
				_gameObjectIntro.SetActive(value: true);
			}
			if (!_gameObjectMain.activeSelf)
			{
				_gameObjectMain.SetActive(value: true);
			}
			if (!_gameObjectOutro.activeSelf)
			{
				_gameObjectOutro.SetActive(value: true);
			}
			switch (_cullState.ActiveAudioSource)
			{
			case 0:
				_introAudioSource.Play();
				_introAudioSource.time = _cullState.Time;
				if (_mainAudioSource.enabled)
				{
					_mainAudioSource.Stop();
					_mainAudioSource.PlayDelayed(Mathf.Max(0f, (_introAudioSource.clip.length - _introAudioSource.time) * _introAudioSource.pitch));
				}
				break;
			case 1:
				if (_introAudioSource.enabled)
				{
					_introAudioSource.Stop();
					_introAudioSource.enabled = false;
				}
				if (_mainAudioSource.enabled)
				{
					_mainAudioSource.Play();
					_mainAudioSource.time = _cullState.Time;
				}
				break;
			case 2:
				if (_introAudioSource.enabled)
				{
					_introAudioSource.Stop();
					_introAudioSource.enabled = false;
				}
				if (_mainAudioSource.enabled)
				{
					_mainAudioSource.Stop();
					_mainAudioSource.enabled = false;
				}
				if (_outroAudioSource.enabled)
				{
					_outroAudioSource.Play();
					_outroAudioSource.time = _cullState.Time;
				}
				break;
			}
			_isCulled = false;
		}

		public void LateUpdate()
		{
			UpdateAudioSourceRadius();
			float num = _introAudioVolume * _volume;
			float num2 = _mainAudioVolume * _volume;
			float num3 = _outroAudioVolume * _volume;
			if (AudioListenerManager.Instance != null && AutoRolloff && AudioListenerManager.Instance.InHositalAudioMixerGroups.Contains(AudioEvent.OutputAudioMixerGroup))
			{
				float num4 = AudioListenerManager.Instance.Get3DHospitalFalloffValue(base.transform.position);
				num *= num4;
				num2 *= num4;
				num3 *= num4;
			}
			if (_introAudioSource.enabled)
			{
				_introAudioSource.volume = num;
			}
			if (_mainAudioSource.enabled)
			{
				_mainAudioSource.volume = num2;
			}
			if (_outroAudioSource.enabled)
			{
				_outroAudioSource.volume = num3;
			}
			if (num < 0.001f && num2 < 0.001f && num3 < 0.001f)
			{
				EnterCullMode();
			}
			else
			{
				ExitCullMode();
			}
			if (!AudioEvent.DoNotTrackSourceMovement && AttachedTo != null && AttachedTo.hasChanged)
			{
				base.transform.position = AttachedTo.position;
			}
			if (AudioEvent.StopWhenSourceDies && AttachedTo == null)
			{
				if (_isCulled)
				{
					_cullState.Finished = true;
				}
				else
				{
					if (_introAudioSource.enabled && _introAudioSource.isPlaying)
					{
						_introAudioSource.Stop();
						_introAudioSource.enabled = false;
					}
					if (_outroAudioSource.enabled && _outroAudioSource.isPlaying)
					{
						_outroAudioSource.Stop();
						_outroAudioSource.enabled = false;
					}
					if (_mainAudioSource.enabled && _mainAudioSource.isPlaying)
					{
						_mainAudioSource.Stop();
						_mainAudioSource.enabled = false;
					}
				}
			}
			if (_mainAudioSource.enabled && _mainAudioSource.loop && AttachedTo == null && !AudioEvent.KeepLoopingWhenSourceDies)
			{
				_mainAudioSource.loop = false;
			}
			if (_isCulled)
			{
				if (_cullState.Finished)
				{
					return;
				}
				switch (_cullState.ActiveAudioSource)
				{
				case 0:
					if (!_introAudioSource.enabled || SimulateAudioSourceUpdate(ref _cullState.Time, Time.deltaTime * _introAudioSource.pitch, _introAudioSource.clip.length, _introAudioSource.loop))
					{
						if (_mainAudioSource.enabled)
						{
							_cullState.Time = 0f;
							_cullState.ActiveAudioSource = 1;
						}
						else if (_outroAudioSource.enabled)
						{
							_cullState.Time = 0f;
							_cullState.ActiveAudioSource = 2;
						}
						else
						{
							_cullState.Finished = true;
						}
					}
					break;
				case 1:
					if (!_mainAudioSource.enabled || SimulateAudioSourceUpdate(ref _cullState.Time, Time.deltaTime * _mainAudioSource.pitch, _mainAudioSource.clip.length, _mainAudioSource.loop))
					{
						if (_outroAudioSource.enabled)
						{
							_cullState.Time = 0f;
							_cullState.ActiveAudioSource = 2;
						}
						else
						{
							_cullState.Finished = true;
						}
					}
					break;
				case 2:
					if (!_outroAudioSource.enabled || SimulateAudioSourceUpdate(ref _cullState.Time, Time.deltaTime * _outroAudioSource.pitch, _outroAudioSource.clip.length, _outroAudioSource.loop))
					{
						_cullState.Finished = true;
					}
					break;
				}
				return;
			}
			UpdateLowPassFilter();
			if (AudioListenerManager.Instance != null && AudioListenerManager.Instance.ShowDebugRadius)
			{
				AudioSource currentAudioSource = CurrentAudioSource;
				if (currentAudioSource != null && currentAudioSource.isPlaying && AutoRolloff && currentAudioSource.spatialBlend > 0.001f)
				{
					DebugDrawUtils.Circle(base.transform.position, currentAudioSource.minDistance, Color.green, 0f, 40);
					DebugDrawUtils.Circle(base.transform.position, currentAudioSource.minDistance + 0.05f, Color.green, 0f, 40);
					DebugDrawUtils.Circle(base.transform.position, currentAudioSource.maxDistance - 0.05f, Color.red, 0f, 40);
					DebugDrawUtils.Circle(base.transform.position, currentAudioSource.maxDistance, Color.red, 0f, 40);
				}
			}
		}

		private static bool SimulateAudioSourceUpdate(ref float time, float deltaTime, float length, bool loop)
		{
			time += deltaTime;
			if (loop)
			{
				while (time > length)
				{
					time -= length;
				}
				return false;
			}
			return time > length;
		}

		private void UpdateLowPassFilter()
		{
			if (AudioListenerManager.Instance != null && (_mainAudioLowPassFilter.enabled || _introAudioLowPassFilter.enabled || _outroAudioLowPassFilter.enabled))
			{
				float a = AudioListenerManager.Instance.ClosestLowPassCutoffFrequency * AutoRolloffMinRadiusMultiplier;
				float b = AudioListenerManager.Instance.FurthestLowPassCutoffFrequency * AutoRolloffMaxRadiusMultiplier;
				float value = Vector3.Distance(AudioListenerManager.Instance.ListenerPosition, base.transform.position);
				float t = Mathf.InverseLerp(AudioListenerManager.Instance.ClosestLowPassRadius, AudioListenerManager.Instance.FurthestLowPassRadius, value);
				if (_mainAudioLowPassFilter.enabled)
				{
					_mainAudioLowPassFilter.cutoffFrequency = Mathf.Lerp(a, b, t);
				}
				if (_introAudioLowPassFilter.enabled)
				{
					_introAudioLowPassFilter.cutoffFrequency = Mathf.Lerp(a, b, t);
				}
				if (_outroAudioLowPassFilter.enabled)
				{
					_outroAudioLowPassFilter.cutoffFrequency = Mathf.Lerp(a, b, t);
				}
			}
		}

		private void UpdateAudioSourceRadius()
		{
			if (AutoRolloff && AudioListenerManager.Instance != null)
			{
				float b = AudioListenerManager.Instance.StandardMaxRadius * AutoRolloffMaxRadiusMultiplier;
				float num = AudioListenerManager.Instance.StandardMinRadius * AutoRolloffMinRadiusMultiplier;
				b = Mathf.Max(num, b);
				if (_introAudioSource.enabled)
				{
					_introAudioSource.maxDistance = b;
					_introAudioSource.minDistance = num;
				}
				if (_mainAudioSource.enabled)
				{
					_mainAudioSource.maxDistance = b;
					_mainAudioSource.minDistance = num;
				}
				if (_outroAudioSource.enabled)
				{
					_outroAudioSource.maxDistance = b;
					_outroAudioSource.minDistance = num;
				}
			}
		}

		public void Pause()
		{
			if (!_isPaused)
			{
				_isPaused = true;
				if (_introAudioSource.enabled && _introAudioSource.isPlaying)
				{
					_activeAudioSourceOnPause = 0;
					_introAudioSource.Pause();
				}
				if (_mainAudioSource.enabled && _mainAudioSource.isPlaying)
				{
					_activeAudioSourceOnPause = 1;
					_mainAudioSource.Pause();
				}
				if (_outroAudioSource.enabled && _outroAudioSource.isPlaying)
				{
					_activeAudioSourceOnPause = 2;
					_outroAudioSource.Pause();
				}
			}
		}

		public void UnPause()
		{
			if (_isPaused)
			{
				_isPaused = false;
				if (_introAudioSource.enabled && !_introAudioSource.isPlaying)
				{
					_introAudioSource.UnPause();
				}
				if (_mainAudioSource.enabled && !_mainAudioSource.isPlaying)
				{
					_mainAudioSource.UnPause();
				}
				if (_outroAudioSource.enabled && !_outroAudioSource.isPlaying)
				{
					_outroAudioSource.UnPause();
				}
			}
		}

		public void Play()
		{
			if (_introAudioSource.enabled)
			{
				_introAudioSource.Play();
				if (_mainAudioSource.enabled)
				{
					_mainAudioSource.PlayDelayed(Mathf.Max(0f, _introAudioSource.clip.length * _introAudioSource.pitch));
				}
			}
			else if (_mainAudioSource.enabled)
			{
				_mainAudioSource.Play();
			}
			UpdateAudioSourceRadius();
		}

		public static AudioEmitter Create(Transform attachedTo, AudioEvent audioEvent)
		{
			GameObject obj = new GameObject("AudioEmitter");
			AudioEmitter audioEmitter = obj.AddComponent<AudioEmitter>();
			obj.transform.parent = AudioManager.Instance.GameObject.transform;
			audioEmitter._gameObjectMain = new GameObject("Main");
			audioEmitter._gameObjectMain.transform.SetParent(audioEmitter.transform, worldPositionStays: false);
			audioEmitter._mainAudioSource = audioEmitter._gameObjectMain.AddComponent<AudioSource>();
			audioEmitter._mainAudioSource.enabled = false;
			audioEmitter._mainAudioSource.playOnAwake = false;
			audioEmitter._gameObjectIntro = new GameObject("Intro");
			audioEmitter._gameObjectIntro.transform.SetParent(audioEmitter.transform, worldPositionStays: false);
			audioEmitter._introAudioSource = audioEmitter._gameObjectIntro.AddComponent<AudioSource>();
			audioEmitter._introAudioSource.enabled = false;
			audioEmitter._introAudioSource.playOnAwake = false;
			audioEmitter._gameObjectOutro = new GameObject("Outro");
			audioEmitter._gameObjectOutro.transform.SetParent(audioEmitter.transform, worldPositionStays: false);
			audioEmitter._outroAudioSource = audioEmitter._gameObjectOutro.AddComponent<AudioSource>();
			audioEmitter._outroAudioSource.enabled = false;
			audioEmitter._outroAudioSource.playOnAwake = false;
			audioEmitter._mainAudioLowPassFilter = audioEmitter._gameObjectMain.AddComponent<AudioLowPassFilter>();
			audioEmitter._mainAudioLowPassFilter.enabled = false;
			audioEmitter._introAudioLowPassFilter = audioEmitter._gameObjectIntro.AddComponent<AudioLowPassFilter>();
			audioEmitter._introAudioLowPassFilter.enabled = false;
			audioEmitter._outroAudioLowPassFilter = audioEmitter._gameObjectOutro.AddComponent<AudioLowPassFilter>();
			audioEmitter._outroAudioLowPassFilter.enabled = false;
			if (attachedTo != null && audioEvent != null)
			{
				SetupAudioEmitter(audioEmitter, attachedTo, audioEvent);
			}
			return audioEmitter;
		}

		public static void SetupAudioEmitter(AudioEmitter emitter, Transform attachedTo, AudioEvent audioEvent)
		{
			emitter._volume = 1f;
			emitter._cullState = default(CullState);
			emitter._isPaused = false;
			emitter._isCulled = false;
			emitter._activeAudioSourceOnPause = 0;
			emitter.transform.position = attachedTo.position;
			emitter.AttachedTo = attachedTo;
			emitter.AudioEvent = audioEvent;
			emitter.AutoRolloff = audioEvent.Auto3DRolloff;
			emitter.AutoRolloffMinRadiusMultiplier = audioEvent.Auto3DMinRadiusMultiplier;
			emitter.AutoRolloffMaxRadiusMultiplier = audioEvent.Auto3DMaxRadiusMultiplier;
			emitter._mainAudioSource.time = 0f;
			emitter._introAudioSource.time = 0f;
			emitter._outroAudioSource.time = 0f;
			emitter._gameObjectIntro.SetActive(value: true);
			emitter._gameObjectMain.SetActive(value: true);
			emitter._gameObjectOutro.SetActive(value: true);
			emitter._mainAudioSource.enabled = false;
			emitter._introAudioSource.enabled = false;
			emitter._outroAudioSource.enabled = false;
			emitter._mainAudioSource.clip = null;
			emitter._introAudioSource.clip = null;
			emitter._outroAudioSource.clip = null;
			emitter._mainAudioLowPassFilter.enabled = false;
			emitter._introAudioLowPassFilter.enabled = false;
			emitter._outroAudioLowPassFilter.enabled = false;
			emitter.ApplyAudioEvent(audioEvent);
			if (AudioListenerManager.Instance != null && emitter.AutoRolloff && AudioListenerManager.Instance.InHositalAudioMixerGroups.Contains(audioEvent.OutputAudioMixerGroup))
			{
				if (emitter._mainAudioSource.enabled)
				{
					emitter._mainAudioLowPassFilter.enabled = true;
				}
				if (emitter._introAudioSource.enabled)
				{
					emitter._introAudioLowPassFilter.enabled = true;
				}
				if (emitter._outroAudioSource.enabled)
				{
					emitter._outroAudioLowPassFilter.enabled = true;
				}
			}
		}

		public void Stop(bool playOutro = true)
		{
			if (_introAudioSource.enabled)
			{
				_introAudioSource.Stop();
				_introAudioSource.enabled = false;
			}
			if (_mainAudioSource.enabled)
			{
				_mainAudioSource.Stop();
				_mainAudioSource.enabled = false;
			}
			if (!_outroAudioSource.enabled)
			{
				return;
			}
			if (_isCulled)
			{
				if (playOutro && _cullState.ActiveAudioSource != 2)
				{
					_cullState.ActiveAudioSource = 2;
					_cullState.Time = 0f;
				}
				else
				{
					_cullState.Finished = true;
				}
			}
			else if (playOutro && !_outroAudioSource.isPlaying)
			{
				_outroAudioSource.Play();
			}
			else
			{
				_outroAudioSource.Stop();
				_outroAudioSource.enabled = false;
			}
		}

		private void ApplyAudioEvent(AudioEvent audioEvent)
		{
			AudioEvent.Clip randomClip = AudioEvent.GetRandomClip(audioEvent.Clips);
			if (randomClip != null && randomClip.AudioClip != null)
			{
				_mainAudioSource.enabled = true;
				_mainAudioSource.clip = GetLocalizedClip(randomClip);
				_mainAudioSource.volume = randomClip.Volume;
				_mainAudioVolume = randomClip.Volume;
				audioEvent.TransferToAudioSource(_mainAudioSource);
			}
			else
			{
				_mainAudioSource.enabled = false;
			}
			if (audioEvent.Loop)
			{
				AudioEvent.Clip randomClip2 = AudioEvent.GetRandomClip(audioEvent.IntroClips);
				if (randomClip2 != null && randomClip2.AudioClip != null)
				{
					_introAudioSource.enabled = true;
					_introAudioSource.clip = GetLocalizedClip(randomClip2);
					_introAudioSource.volume = randomClip2.Volume;
					_introAudioVolume = randomClip2.Volume;
					audioEvent.TransferToAudioSource(_introAudioSource);
					_introAudioSource.loop = false;
				}
				else
				{
					_introAudioSource.enabled = false;
				}
				AudioEvent.Clip randomClip3 = AudioEvent.GetRandomClip(audioEvent.OutroClips);
				if (randomClip3 != null && randomClip3.AudioClip != null)
				{
					_outroAudioSource.enabled = true;
					_outroAudioSource.clip = GetLocalizedClip(randomClip3);
					_outroAudioSource.volume = randomClip3.Volume;
					_outroAudioVolume = randomClip3.Volume;
					audioEvent.TransferToAudioSource(_outroAudioSource);
					_outroAudioSource.loop = false;
				}
				else
				{
					_outroAudioSource.enabled = false;
				}
			}
		}

		private AudioClip GetLocalizedClip(AudioEvent.Clip clip)
		{
			if (string.IsNullOrEmpty(clip.AudioClipTag))
			{
				return clip.AudioClip;
			}
			return AudioManager.VOManager.GetLocalizedVO(clip.AudioClipTag) ?? clip.AudioClip;
		}
	}
}
