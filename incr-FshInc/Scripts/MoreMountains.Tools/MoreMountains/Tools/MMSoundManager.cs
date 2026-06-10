using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace MoreMountains.Tools
{
	[AddComponentMenu("More Mountains/Tools/Audio/MM Sound Manager")]
	public class MMSoundManager : MMPersistentSingleton<MMSoundManager>, MMEventListener<MMSoundManagerTrackEvent>, MMEventListenerBase, MMEventListener<MMSoundManagerEvent>, MMEventListener<MMSoundManagerSoundControlEvent>, MMEventListener<MMSoundManagerSoundFadeEvent>, MMEventListener<MMSoundManagerAllSoundsControlEvent>, MMEventListener<MMSoundManagerTrackFadeEvent>
	{
		public enum MMSoundManagerTracks
		{
			Sfx = 0,
			Music = 1,
			UI = 2,
			Master = 3,
			Other = 4
		}

		public enum ControlTrackModes
		{
			Mute = 0,
			Unmute = 1,
			SetVolume = 2
		}

		[Header("Settings")]
		[Tooltip("the current sound settings ")]
		public MMSoundManagerSettingsSO settingsSo;

		[Header("Pool")]
		[Tooltip("the size of the AudioSource pool, a reserve of ready-to-use sources that will get recycled. Should be approximately equal to the maximum amount of sounds that you expect to be playing at once")]
		public int AudioSourcePoolSize = 10;

		[Tooltip("whether or not the pool can expand (create new audiosources on demand). In a perfect world you'd want to avoid this, and have a sufficiently big pool, to avoid costly runtime creations.")]
		public bool PoolCanExpand = true;

		protected MMSoundManagerAudioPool _pool;

		protected GameObject _tempAudioSourceGameObject;

		protected MMSoundManagerSound _sound;

		protected List<MMSoundManagerSound> _sounds;

		protected AudioSource _tempAudioSource;

		protected Dictionary<AudioSource, Coroutine> _fadeInSoundCoroutines;

		protected Dictionary<AudioSource, Coroutine> _fadeOutSoundCoroutines;

		protected Dictionary<MMSoundManagerTracks, Coroutine> _fadeTrackCoroutines;

		protected Dictionary<MMSoundManagerTracks, bool> _pausedTracks = new Dictionary<MMSoundManagerTracks, bool>();

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		protected static void InitializeStatics()
		{
			MMPersistentSingleton<MMSoundManager>._instance = null;
		}

		protected override void Awake()
		{
			base.Awake();
			InitializeSoundManager();
		}

		protected virtual void Start()
		{
			if (settingsSo != null && settingsSo.Settings.AutoLoad)
			{
				settingsSo.LoadSoundSettings();
			}
		}

		protected virtual void InitializeSoundManager()
		{
			if (_pool == null)
			{
				_pool = new MMSoundManagerAudioPool();
			}
			_sounds = new List<MMSoundManagerSound>();
			_pool.FillAudioSourcePool(AudioSourcePoolSize, base.transform);
			_fadeInSoundCoroutines = new Dictionary<AudioSource, Coroutine>();
			_fadeOutSoundCoroutines = new Dictionary<AudioSource, Coroutine>();
			_fadeTrackCoroutines = new Dictionary<MMSoundManagerTracks, Coroutine>();
		}

		public virtual AudioSource PlaySound(AudioClip audioClip, MMSoundManagerPlayOptions options)
		{
			return PlaySound(audioClip, options.MmSoundManagerTrack, options.Location, options.Loop, options.Volume, options.ID, options.Fade, options.FadeInitialVolume, options.FadeDuration, options.FadeTween, options.Persistent, options.RecycleAudioSource, options.AudioGroup, options.Pitch, options.PanStereo, options.SpatialBlend, options.SoloSingleTrack, options.SoloAllTracks, options.AutoUnSoloOnEnd, options.BypassEffects, options.BypassListenerEffects, options.BypassReverbZones, options.Priority, options.ReverbZoneMix, options.DopplerLevel, options.Spread, options.RolloffMode, options.MinDistance, options.MaxDistance, options.DoNotAutoRecycleIfNotDonePlaying, options.PlaybackTime, options.PlaybackDuration, options.AttachToTransform, options.UseSpreadCurve, options.SpreadCurve, options.UseCustomRolloffCurve, options.CustomRolloffCurve, options.UseSpatialBlendCurve, options.SpatialBlendCurve, options.UseReverbZoneMixCurve, options.ReverbZoneMixCurve, options.AudioResourceToPlay, options.InitialDelay);
		}

		public virtual AudioSource PlaySound(AudioClip audioClip, MMSoundManagerTracks mmSoundManagerTrack, Vector3 location, bool loop = false, float volume = 1f, int ID = 0, bool fade = false, float fadeInitialVolume = 0f, float fadeDuration = 1f, MMTweenType fadeTween = null, bool persistent = false, AudioSource recycleAudioSource = null, AudioMixerGroup audioGroup = null, float pitch = 1f, float panStereo = 0f, float spatialBlend = 0f, bool soloSingleTrack = false, bool soloAllTracks = false, bool autoUnSoloOnEnd = false, bool bypassEffects = false, bool bypassListenerEffects = false, bool bypassReverbZones = false, int priority = 128, float reverbZoneMix = 1f, float dopplerLevel = 1f, int spread = 0, AudioRolloffMode rolloffMode = AudioRolloffMode.Logarithmic, float minDistance = 1f, float maxDistance = 500f, bool doNotAutoRecycleIfNotDonePlaying = false, float playbackTime = 0f, float playbackDuration = 0f, Transform attachToTransform = null, bool useSpreadCurve = false, AnimationCurve spreadCurve = null, bool useCustomRolloffCurve = false, AnimationCurve customRolloffCurve = null, bool useSpatialBlendCurve = false, AnimationCurve spatialBlendCurve = null, bool useReverbZoneMixCurve = false, AnimationCurve reverbZoneMixCurve = null, AudioResource audioResourceToPlay = null, float initialDelay = 0f)
		{
			if (this == null)
			{
				return null;
			}
			if (!audioClip && !audioResourceToPlay)
			{
				return null;
			}
			AudioSource audioSource = recycleAudioSource;
			if (!audioSource)
			{
				audioSource = _pool.GetAvailableAudioSource(PoolCanExpand, base.transform);
				if (!audioSource)
				{
					Debug.LogError("There are no available audiosources, this sound won't play. You should probably consider a bigger pool size, or let your pool expand by setting PoolCanExpand to true on your MM Sound Manager.");
					return null;
				}
				audioSource.clip = audioClip;
				if ((bool)audioSource && !loop)
				{
					recycleAudioSource = audioSource;
					float duration = ((audioClip != null) ? (audioClip.length / Mathf.Abs(pitch)) : 1f);
					StartCoroutine(_pool.AutoDisableAudioSource(duration, audioSource, audioClip, doNotAutoRecycleIfNotDonePlaying, playbackTime, playbackDuration));
				}
			}
			if (!audioSource)
			{
				_tempAudioSourceGameObject = new GameObject("MMAudio_" + audioClip.name);
				SceneManager.MoveGameObjectToScene(_tempAudioSourceGameObject, base.gameObject.scene);
				audioSource = _tempAudioSourceGameObject.AddComponent<AudioSource>();
			}
			audioSource.transform.position = location;
			if (audioResourceToPlay == null)
			{
				audioSource.clip = audioClip;
			}
			else
			{
				audioSource.resource = audioResourceToPlay;
			}
			audioSource.pitch = pitch;
			audioSource.spatialBlend = spatialBlend;
			audioSource.panStereo = panStereo;
			audioSource.loop = loop;
			audioSource.bypassEffects = bypassEffects;
			audioSource.bypassListenerEffects = bypassListenerEffects;
			audioSource.bypassReverbZones = bypassReverbZones;
			audioSource.priority = priority;
			audioSource.reverbZoneMix = reverbZoneMix;
			audioSource.dopplerLevel = dopplerLevel;
			audioSource.spread = spread;
			audioSource.rolloffMode = rolloffMode;
			audioSource.minDistance = minDistance;
			audioSource.maxDistance = maxDistance;
			if (audioSource.clip != null)
			{
				audioSource.time = playbackTime;
			}
			if (useSpreadCurve)
			{
				audioSource.SetCustomCurve(AudioSourceCurveType.Spread, spreadCurve);
			}
			if (useCustomRolloffCurve)
			{
				audioSource.SetCustomCurve(AudioSourceCurveType.CustomRolloff, customRolloffCurve);
			}
			if (useSpatialBlendCurve)
			{
				audioSource.SetCustomCurve(AudioSourceCurveType.SpatialBlend, spatialBlendCurve);
			}
			if (useReverbZoneMixCurve)
			{
				audioSource.SetCustomCurve(AudioSourceCurveType.ReverbZoneMix, reverbZoneMixCurve);
			}
			if (attachToTransform != null)
			{
				MMFollowTarget mMFollowTarget = audioSource.gameObject.MMGetComponentNoAlloc<MMFollowTarget>();
				if (mMFollowTarget == null)
				{
					mMFollowTarget = audioSource.gameObject.AddComponent<MMFollowTarget>();
				}
				mMFollowTarget.Target = attachToTransform;
				mMFollowTarget.InterpolatePosition = false;
				mMFollowTarget.InterpolateRotation = false;
				mMFollowTarget.InterpolateScale = false;
				mMFollowTarget.FollowRotation = false;
				mMFollowTarget.FollowScale = false;
				mMFollowTarget.enabled = true;
			}
			if (settingsSo != null)
			{
				audioSource.outputAudioMixerGroup = settingsSo.MasterAudioMixerGroup;
				switch (mmSoundManagerTrack)
				{
				case MMSoundManagerTracks.Master:
					audioSource.outputAudioMixerGroup = settingsSo.MasterAudioMixerGroup;
					break;
				case MMSoundManagerTracks.Music:
					audioSource.outputAudioMixerGroup = settingsSo.MusicAudioMixerGroup;
					break;
				case MMSoundManagerTracks.Sfx:
					audioSource.outputAudioMixerGroup = settingsSo.SfxAudioMixerGroup;
					break;
				case MMSoundManagerTracks.UI:
					audioSource.outputAudioMixerGroup = settingsSo.UIAudioMixerGroup;
					break;
				}
			}
			if ((bool)audioGroup)
			{
				audioSource.outputAudioMixerGroup = audioGroup;
			}
			audioSource.volume = volume;
			if (initialDelay > 0f)
			{
				audioSource.PlayDelayed(initialDelay);
			}
			else
			{
				audioSource.Play();
			}
			if (!loop && !recycleAudioSource)
			{
				float t = ((playbackDuration > 0f) ? playbackDuration : (audioClip.length - playbackTime));
				Object.Destroy(_tempAudioSourceGameObject, t);
			}
			if (fade)
			{
				FadeSound(audioSource, fadeDuration, fadeInitialVolume, volume, fadeTween);
			}
			if (soloSingleTrack)
			{
				MuteSoundsOnTrack(mmSoundManagerTrack, mute: true);
				audioSource.mute = false;
				if (autoUnSoloOnEnd)
				{
					MuteSoundsOnTrack(mmSoundManagerTrack, mute: false, audioClip.length);
				}
			}
			else if (soloAllTracks)
			{
				MuteAllSounds();
				audioSource.mute = false;
				if (autoUnSoloOnEnd)
				{
					StartCoroutine(MuteAllSoundsCoroutine(audioClip.length - playbackTime, mute: false));
				}
			}
			_sound.ID = ID;
			_sound.Track = mmSoundManagerTrack;
			_sound.Source = audioSource;
			_sound.Persistent = persistent;
			_sound.PlaybackTime = playbackTime;
			_sound.PlaybackDuration = playbackDuration;
			bool flag = false;
			for (int i = 0; i < _sounds.Count; i++)
			{
				if (_sounds[i].Source == audioSource)
				{
					_sounds[i] = _sound;
					flag = true;
				}
			}
			if (!flag)
			{
				_sounds.Add(_sound);
			}
			return audioSource;
		}

		public virtual void PauseSound(AudioSource source)
		{
			source.Pause();
		}

		public virtual void ResumeSound(AudioSource source)
		{
			source.Play();
		}

		public virtual void StopSound(AudioSource source)
		{
			source.Stop();
		}

		public virtual void FreeSound(AudioSource source)
		{
			source.Stop();
			if (!_pool.FreeSound(source))
			{
				Object.Destroy(source.gameObject);
			}
		}

		public virtual bool IsPaused(MMSoundManagerTracks track)
		{
			if (_pausedTracks.TryGetValue(track, out var value))
			{
				return value;
			}
			return false;
		}

		public virtual void MuteTrack(MMSoundManagerTracks track)
		{
			ControlTrack(track, ControlTrackModes.Mute, 0f);
		}

		public virtual void UnmuteTrack(MMSoundManagerTracks track)
		{
			ControlTrack(track, ControlTrackModes.Unmute, 0f);
		}

		public virtual void SetTrackVolume(MMSoundManagerTracks track, float volume)
		{
			ControlTrack(track, ControlTrackModes.SetVolume, volume);
		}

		public virtual float GetTrackVolume(MMSoundManagerTracks track, bool mutedVolume)
		{
			switch (track)
			{
			case MMSoundManagerTracks.Master:
				if (mutedVolume)
				{
					return settingsSo.Settings.MutedMasterVolume;
				}
				return settingsSo.Settings.MasterVolume;
			case MMSoundManagerTracks.Music:
				if (mutedVolume)
				{
					return settingsSo.Settings.MutedMusicVolume;
				}
				return settingsSo.Settings.MusicVolume;
			case MMSoundManagerTracks.Sfx:
				if (mutedVolume)
				{
					return settingsSo.Settings.MutedSfxVolume;
				}
				return settingsSo.Settings.SfxVolume;
			case MMSoundManagerTracks.UI:
				if (mutedVolume)
				{
					return settingsSo.Settings.MutedUIVolume;
				}
				return settingsSo.Settings.UIVolume;
			default:
				return 1f;
			}
		}

		public virtual void PauseTrack(MMSoundManagerTracks track)
		{
			_pausedTracks[track] = true;
			foreach (MMSoundManagerSound sound in _sounds)
			{
				if (sound.Track == track)
				{
					sound.Source.Pause();
				}
			}
		}

		public virtual void PlayTrack(MMSoundManagerTracks track)
		{
			_pausedTracks[track] = false;
			foreach (MMSoundManagerSound sound in _sounds)
			{
				if (sound.Track == track)
				{
					sound.Source.Play();
				}
			}
		}

		public virtual void StopTrack(MMSoundManagerTracks track)
		{
			foreach (MMSoundManagerSound sound in _sounds)
			{
				if (sound.Track == track)
				{
					sound.Source.Stop();
				}
			}
		}

		public virtual bool HasSoundsPlaying(MMSoundManagerTracks track)
		{
			foreach (MMSoundManagerSound sound in _sounds)
			{
				if (sound.Track == track && sound.Source.isPlaying)
				{
					return true;
				}
			}
			return false;
		}

		public virtual List<MMSoundManagerSound> GetSoundsPlaying(MMSoundManagerTracks track)
		{
			List<MMSoundManagerSound> list = new List<MMSoundManagerSound>();
			foreach (MMSoundManagerSound sound in _sounds)
			{
				if (sound.Track == track && sound.Source.isPlaying)
				{
					list.Add(sound);
				}
			}
			return list;
		}

		public virtual void FreeTrack(MMSoundManagerTracks track)
		{
			foreach (MMSoundManagerSound sound in _sounds)
			{
				if (sound.Track == track)
				{
					sound.Source.Stop();
					sound.Source.gameObject.SetActive(value: false);
				}
			}
		}

		public virtual void MuteMusic()
		{
			MuteTrack(MMSoundManagerTracks.Music);
		}

		public virtual void UnmuteMusic()
		{
			UnmuteTrack(MMSoundManagerTracks.Music);
		}

		public virtual void MuteSfx()
		{
			MuteTrack(MMSoundManagerTracks.Sfx);
		}

		public virtual void UnmuteSfx()
		{
			UnmuteTrack(MMSoundManagerTracks.Sfx);
		}

		public virtual void MuteUI()
		{
			MuteTrack(MMSoundManagerTracks.UI);
		}

		public virtual void UnmuteUI()
		{
			UnmuteTrack(MMSoundManagerTracks.UI);
		}

		public virtual void MuteMaster()
		{
			MuteTrack(MMSoundManagerTracks.Master);
		}

		public virtual void UnmuteMaster()
		{
			UnmuteTrack(MMSoundManagerTracks.Master);
		}

		public virtual void SetVolumeMusic(float newVolume)
		{
			SetTrackVolume(MMSoundManagerTracks.Music, newVolume);
		}

		public virtual void SetVolumeSfx(float newVolume)
		{
			SetTrackVolume(MMSoundManagerTracks.Sfx, newVolume);
		}

		public virtual void SetVolumeUI(float newVolume)
		{
			SetTrackVolume(MMSoundManagerTracks.UI, newVolume);
		}

		public virtual void SetVolumeMaster(float newVolume)
		{
			SetTrackVolume(MMSoundManagerTracks.Master, newVolume);
		}

		public virtual bool IsMuted(MMSoundManagerTracks track)
		{
			return track switch
			{
				MMSoundManagerTracks.Master => !settingsSo.Settings.MasterOn, 
				MMSoundManagerTracks.Music => !settingsSo.Settings.MusicOn, 
				MMSoundManagerTracks.Sfx => !settingsSo.Settings.SfxOn, 
				MMSoundManagerTracks.UI => !settingsSo.Settings.UIOn, 
				_ => false, 
			};
		}

		protected virtual void ControlTrack(MMSoundManagerTracks track, ControlTrackModes trackMode, float volume = 0.5f)
		{
			string text = "";
			float mixerVolume = 0f;
			switch (track)
			{
			case MMSoundManagerTracks.Master:
				text = settingsSo.Settings.MasterVolumeParameter;
				switch (trackMode)
				{
				case ControlTrackModes.Mute:
					settingsSo.TargetAudioMixer.GetFloat(text, out settingsSo.Settings.MutedMasterVolume);
					settingsSo.Settings.MasterOn = false;
					break;
				case ControlTrackModes.Unmute:
					mixerVolume = settingsSo.Settings.MutedMasterVolume;
					settingsSo.Settings.MasterOn = true;
					break;
				}
				break;
			case MMSoundManagerTracks.Music:
				text = settingsSo.Settings.MusicVolumeParameter;
				switch (trackMode)
				{
				case ControlTrackModes.Mute:
					settingsSo.TargetAudioMixer.GetFloat(text, out settingsSo.Settings.MutedMusicVolume);
					settingsSo.Settings.MusicOn = false;
					break;
				case ControlTrackModes.Unmute:
					mixerVolume = settingsSo.Settings.MutedMusicVolume;
					settingsSo.Settings.MusicOn = true;
					break;
				}
				break;
			case MMSoundManagerTracks.Sfx:
				text = settingsSo.Settings.SfxVolumeParameter;
				switch (trackMode)
				{
				case ControlTrackModes.Mute:
					settingsSo.TargetAudioMixer.GetFloat(text, out settingsSo.Settings.MutedSfxVolume);
					settingsSo.Settings.SfxOn = false;
					break;
				case ControlTrackModes.Unmute:
					mixerVolume = settingsSo.Settings.MutedSfxVolume;
					settingsSo.Settings.SfxOn = true;
					break;
				}
				break;
			case MMSoundManagerTracks.UI:
				text = settingsSo.Settings.UIVolumeParameter;
				switch (trackMode)
				{
				case ControlTrackModes.Mute:
					settingsSo.TargetAudioMixer.GetFloat(text, out settingsSo.Settings.MutedUIVolume);
					settingsSo.Settings.UIOn = false;
					break;
				case ControlTrackModes.Unmute:
					mixerVolume = settingsSo.Settings.MutedUIVolume;
					settingsSo.Settings.UIOn = true;
					break;
				}
				break;
			}
			switch (trackMode)
			{
			case ControlTrackModes.Mute:
				settingsSo.SetTrackVolume(track, 0f);
				break;
			case ControlTrackModes.Unmute:
				settingsSo.SetTrackVolume(track, settingsSo.MixerVolumeToNormalized(mixerVolume));
				break;
			case ControlTrackModes.SetVolume:
				settingsSo.SetTrackVolume(track, volume);
				break;
			}
			settingsSo.GetTrackVolumes();
			if (settingsSo.Settings.AutoSave)
			{
				settingsSo.SaveSoundSettings();
			}
		}

		public virtual void FadeTrack(MMSoundManagerTracks track, float duration, float initialVolume = 0f, float finalVolume = 1f, MMTweenType tweenType = null)
		{
			Coroutine value = StartCoroutine(FadeTrackCoroutine(track, duration, initialVolume, finalVolume, tweenType));
			_fadeTrackCoroutines[track] = value;
		}

		public virtual void FadeSound(AudioSource source, float duration, float initialVolume, float finalVolume, MMTweenType tweenType, bool freeAfterFade = false)
		{
			Coroutine value = StartCoroutine(FadeCoroutine(source, duration, initialVolume, finalVolume, tweenType, freeAfterFade));
			if (initialVolume < finalVolume)
			{
				_fadeInSoundCoroutines[source] = value;
			}
			else
			{
				_fadeOutSoundCoroutines[source] = value;
			}
		}

		public virtual bool SoundIsFadingIn(AudioSource source)
		{
			if (_fadeInSoundCoroutines.TryGetValue(source, out var _))
			{
				return _fadeInSoundCoroutines[source] != null;
			}
			return false;
		}

		public virtual bool SoundIsFadingOut(AudioSource source)
		{
			if (_fadeOutSoundCoroutines.TryGetValue(source, out var _))
			{
				return _fadeOutSoundCoroutines[source] != null;
			}
			return false;
		}

		public virtual void StopFadeTrack(MMSoundManagerTracks track)
		{
			if (_fadeTrackCoroutines.TryGetValue(track, out var value))
			{
				StopCoroutine(value);
				_fadeTrackCoroutines.Remove(track);
			}
		}

		public virtual void StopFadeSound(AudioSource source)
		{
			if (source != null && _fadeInSoundCoroutines.TryGetValue(source, out var value) && value != null)
			{
				StopCoroutine(value);
				_fadeInSoundCoroutines.Remove(source);
			}
			if (source != null && _fadeOutSoundCoroutines.TryGetValue(source, out value) && value != null)
			{
				StopCoroutine(value);
				_fadeOutSoundCoroutines.Remove(source);
			}
		}

		protected virtual IEnumerator FadeTrackCoroutine(MMSoundManagerTracks track, float duration, float initialVolume, float finalVolume, MMTweenType tweenType)
		{
			float startedAt = Time.unscaledTime;
			if (tweenType == null)
			{
				tweenType = new MMTweenType(MMTween.MMTweenCurve.EaseInOutQuartic, "", "");
			}
			while (Time.unscaledTime - startedAt <= duration)
			{
				float volume = MMTween.Tween(Time.unscaledTime - startedAt, 0f, duration, initialVolume, finalVolume, tweenType);
				settingsSo.SetTrackVolume(track, volume);
				yield return null;
			}
			settingsSo.SetTrackVolume(track, finalVolume);
		}

		protected virtual IEnumerator FadeCoroutine(AudioSource source, float duration, float initialVolume, float finalVolume, MMTweenType tweenType, bool freeAfterFade = false)
		{
			float startedAt = Time.unscaledTime;
			if (tweenType == null)
			{
				tweenType = new MMTweenType(MMTween.MMTweenCurve.EaseInOutQuartic, "", "");
			}
			while (Time.unscaledTime - startedAt <= duration)
			{
				float volume = MMTween.Tween(Time.unscaledTime - startedAt, 0f, duration, initialVolume, finalVolume, tweenType);
				source.volume = volume;
				yield return null;
			}
			source.volume = finalVolume;
			if (freeAfterFade)
			{
				FreeSound(source);
			}
			if (initialVolume < finalVolume)
			{
				_fadeInSoundCoroutines[source] = null;
			}
			else
			{
				_fadeOutSoundCoroutines[source] = null;
			}
		}

		public virtual void MuteSoundsOnTrack(MMSoundManagerTracks track, bool mute, float delay = 0f)
		{
			StartCoroutine(MuteSoundsOnTrackCoroutine(track, mute, delay));
		}

		public virtual void MuteAllSounds(bool mute = true)
		{
			StartCoroutine(MuteAllSoundsCoroutine(0f, mute));
		}

		protected virtual IEnumerator MuteSoundsOnTrackCoroutine(MMSoundManagerTracks track, bool mute, float delay)
		{
			if (delay > 0f)
			{
				yield return MMCoroutine.WaitForUnscaled(delay);
			}
			foreach (MMSoundManagerSound sound in _sounds)
			{
				if (sound.Track == track)
				{
					sound.Source.mute = mute;
				}
			}
		}

		protected virtual IEnumerator MuteAllSoundsCoroutine(float delay, bool mute = true)
		{
			if (delay > 0f)
			{
				yield return MMCoroutine.WaitForUnscaled(delay);
			}
			foreach (MMSoundManagerSound sound in _sounds)
			{
				sound.Source.mute = mute;
			}
		}

		public virtual AudioSource FindByID(int ID)
		{
			foreach (MMSoundManagerSound sound in _sounds)
			{
				if (sound.ID == ID)
				{
					return sound.Source;
				}
			}
			return null;
		}

		public virtual AudioSource FindByClip(AudioClip clip)
		{
			foreach (MMSoundManagerSound sound in _sounds)
			{
				if (sound.Source != null && sound.Source.clip == clip)
				{
					return sound.Source;
				}
			}
			return null;
		}

		public virtual int CurrentlyPlayingCount(AudioClip clip)
		{
			int num = 0;
			foreach (MMSoundManagerSound sound in _sounds)
			{
				if (sound.Source != null && sound.Source.clip == clip && sound.Source.isPlaying)
				{
					num++;
				}
			}
			return num;
		}

		public virtual void PauseAllSounds()
		{
			foreach (MMSoundManagerSound sound in _sounds)
			{
				sound.Source.Pause();
			}
		}

		public virtual void PlayAllSounds()
		{
			foreach (MMSoundManagerSound sound in _sounds)
			{
				if (sound.Source.isActiveAndEnabled)
				{
					sound.Source.Play();
				}
			}
		}

		public virtual void StopAllSounds()
		{
			foreach (MMSoundManagerSound sound in _sounds)
			{
				sound.Source.Stop();
			}
		}

		public virtual void FreeAllSounds()
		{
			foreach (MMSoundManagerSound sound in _sounds)
			{
				if (sound.Source != null)
				{
					FreeSound(sound.Source);
				}
			}
		}

		public virtual void FreeAllSoundsButPersistent()
		{
			foreach (MMSoundManagerSound sound in _sounds)
			{
				if (!sound.Persistent && sound.Source != null)
				{
					FreeSound(sound.Source);
				}
			}
		}

		public virtual void FreeAllLoopingSounds()
		{
			foreach (MMSoundManagerSound sound in _sounds)
			{
				if (sound.Source.loop && sound.Source != null)
				{
					FreeSound(sound.Source);
				}
			}
		}

		protected virtual void OnSceneLoaded(Scene arg0, LoadSceneMode loadSceneMode)
		{
			FreeAllSoundsButPersistent();
		}

		public virtual void OnMMEvent(MMSoundManagerTrackEvent soundManagerTrackEvent)
		{
			switch (soundManagerTrackEvent.TrackEventType)
			{
			case MMSoundManagerTrackEventTypes.MuteTrack:
				MuteTrack(soundManagerTrackEvent.Track);
				break;
			case MMSoundManagerTrackEventTypes.UnmuteTrack:
				UnmuteTrack(soundManagerTrackEvent.Track);
				break;
			case MMSoundManagerTrackEventTypes.SetVolumeTrack:
				SetTrackVolume(soundManagerTrackEvent.Track, soundManagerTrackEvent.Volume);
				break;
			case MMSoundManagerTrackEventTypes.PlayTrack:
				PlayTrack(soundManagerTrackEvent.Track);
				break;
			case MMSoundManagerTrackEventTypes.PauseTrack:
				PauseTrack(soundManagerTrackEvent.Track);
				break;
			case MMSoundManagerTrackEventTypes.StopTrack:
				StopTrack(soundManagerTrackEvent.Track);
				break;
			case MMSoundManagerTrackEventTypes.FreeTrack:
				FreeTrack(soundManagerTrackEvent.Track);
				break;
			}
		}

		public virtual void OnMMEvent(MMSoundManagerEvent soundManagerEvent)
		{
			switch (soundManagerEvent.EventType)
			{
			case MMSoundManagerEventTypes.SaveSettings:
				SaveSettings();
				break;
			case MMSoundManagerEventTypes.LoadSettings:
				settingsSo.LoadSoundSettings();
				break;
			case MMSoundManagerEventTypes.ResetSettings:
				settingsSo.ResetSoundSettings();
				break;
			}
		}

		public virtual void SaveSettings()
		{
			settingsSo.SaveSoundSettings();
		}

		public virtual void LoadSettings()
		{
			settingsSo.LoadSoundSettings();
		}

		public virtual void ResetSettings()
		{
			settingsSo.ResetSoundSettings();
		}

		public virtual void OnMMEvent(MMSoundManagerSoundControlEvent soundControlEvent)
		{
			if (soundControlEvent.TargetSource == null)
			{
				_tempAudioSource = FindByID(soundControlEvent.SoundID);
			}
			else
			{
				_tempAudioSource = soundControlEvent.TargetSource;
			}
			if (_tempAudioSource != null)
			{
				switch (soundControlEvent.MMSoundManagerSoundControlEventType)
				{
				case MMSoundManagerSoundControlEventTypes.Pause:
					PauseSound(_tempAudioSource);
					break;
				case MMSoundManagerSoundControlEventTypes.Resume:
					ResumeSound(_tempAudioSource);
					break;
				case MMSoundManagerSoundControlEventTypes.Stop:
					StopSound(_tempAudioSource);
					break;
				case MMSoundManagerSoundControlEventTypes.Free:
					FreeSound(_tempAudioSource);
					break;
				}
			}
		}

		public virtual void OnMMEvent(MMSoundManagerTrackFadeEvent trackFadeEvent)
		{
			switch (trackFadeEvent.Mode)
			{
			case MMSoundManagerTrackFadeEvent.Modes.PlayFade:
				FadeTrack(trackFadeEvent.Track, trackFadeEvent.FadeDuration, settingsSo.GetTrackVolume(trackFadeEvent.Track), trackFadeEvent.FinalVolume, trackFadeEvent.FadeTween);
				break;
			case MMSoundManagerTrackFadeEvent.Modes.StopFade:
				StopFadeTrack(trackFadeEvent.Track);
				break;
			}
		}

		public virtual void OnMMEvent(MMSoundManagerSoundFadeEvent soundFadeEvent)
		{
			_tempAudioSource = FindByID(soundFadeEvent.SoundID);
			switch (soundFadeEvent.Mode)
			{
			case MMSoundManagerSoundFadeEvent.Modes.PlayFade:
				if (_tempAudioSource != null)
				{
					FadeSound(_tempAudioSource, soundFadeEvent.FadeDuration, _tempAudioSource.volume, soundFadeEvent.FinalVolume, soundFadeEvent.FadeTween);
				}
				break;
			case MMSoundManagerSoundFadeEvent.Modes.StopFade:
				StopFadeSound(_tempAudioSource);
				break;
			}
		}

		public virtual void OnMMEvent(MMSoundManagerAllSoundsControlEvent allSoundsControlEvent)
		{
			switch (allSoundsControlEvent.EventType)
			{
			case MMSoundManagerAllSoundsControlEventTypes.Pause:
				PauseAllSounds();
				break;
			case MMSoundManagerAllSoundsControlEventTypes.Play:
				PlayAllSounds();
				break;
			case MMSoundManagerAllSoundsControlEventTypes.Stop:
				StopAllSounds();
				break;
			case MMSoundManagerAllSoundsControlEventTypes.Free:
				FreeAllSounds();
				break;
			case MMSoundManagerAllSoundsControlEventTypes.FreeAllButPersistent:
				FreeAllSoundsButPersistent();
				break;
			case MMSoundManagerAllSoundsControlEventTypes.FreeAllLooping:
				FreeAllLoopingSounds();
				break;
			}
		}

		public virtual void OnMMSfxEvent(AudioClip clipToPlay, AudioMixerGroup audioGroup = null, float volume = 1f, float pitch = 1f, int priority = 128)
		{
			MMSoundManagerPlayOptions options = MMSoundManagerPlayOptions.Default;
			options.Location = base.transform.position;
			options.AudioGroup = audioGroup;
			options.Volume = volume;
			options.Pitch = pitch;
			if (priority >= 0)
			{
				options.Priority = Mathf.Min(priority, 256);
			}
			options.MmSoundManagerTrack = MMSoundManagerTracks.Sfx;
			options.Loop = false;
			PlaySound(clipToPlay, options);
		}

		public virtual AudioSource OnMMSoundManagerSoundPlayEvent(AudioClip clip, MMSoundManagerPlayOptions options)
		{
			return PlaySound(clip, options);
		}

		protected virtual void OnEnable()
		{
			if (_enabled)
			{
				MMSfxEvent.Register(OnMMSfxEvent);
				MMSoundManagerSoundPlayEvent.Register(OnMMSoundManagerSoundPlayEvent);
				this.MMEventStartListening<MMSoundManagerEvent>();
				this.MMEventStartListening<MMSoundManagerTrackEvent>();
				this.MMEventStartListening<MMSoundManagerSoundControlEvent>();
				this.MMEventStartListening<MMSoundManagerTrackFadeEvent>();
				this.MMEventStartListening<MMSoundManagerSoundFadeEvent>();
				this.MMEventStartListening<MMSoundManagerAllSoundsControlEvent>();
				SceneManager.sceneLoaded += OnSceneLoaded;
			}
		}

		protected virtual void OnDisable()
		{
			if (_enabled)
			{
				MMSfxEvent.Unregister(OnMMSfxEvent);
				MMSoundManagerSoundPlayEvent.Unregister(OnMMSoundManagerSoundPlayEvent);
				this.MMEventStopListening<MMSoundManagerEvent>();
				this.MMEventStopListening<MMSoundManagerTrackEvent>();
				this.MMEventStopListening<MMSoundManagerSoundControlEvent>();
				this.MMEventStopListening<MMSoundManagerTrackFadeEvent>();
				this.MMEventStopListening<MMSoundManagerSoundFadeEvent>();
				this.MMEventStopListening<MMSoundManagerAllSoundsControlEvent>();
				SceneManager.sceneLoaded -= OnSceneLoaded;
			}
		}
	}
}
