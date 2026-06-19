using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

namespace JSAM
{
	public abstract class BaseAudioChannelHelper<T> : MonoBehaviour, IAudioHelperEvents where T : BaseAudioFileObject
	{
		public bool Reserved;

		protected T audioFile;

		protected AudioChorusFilter chorusFilter;

		protected AudioDistortionFilter distortionFilter;

		protected AudioEchoFilter echoFilter;

		protected AudioHighPassFilter highPassFilter;

		protected AudioLowPassFilter lowPassFilter;

		protected AudioReverbFilter reverbFilter;

		protected AudioMixerGroup defaultMixerGroup;

		protected Transform originalParent;

		private Coroutine fadeInRoutine;

		private Coroutine fadeOutRoutine;

		private bool subscribedToEvents;

		private bool applicationPaused;

		public bool IsFree
		{
			get
			{
				if (!Reserved)
				{
					return !base.enabled;
				}
				return false;
			}
		}

		public T AudioFile => audioFile;

		protected abstract VolumeChannel DefaultChannel { get; }

		public VolumeChannel Channel
		{
			get
			{
				VolumeChannel result = DefaultChannel;
				if (!audioFile)
				{
					return result;
				}
				if (audioFile.channelOverride != VolumeChannel.None)
				{
					result = audioFile.channelOverride;
				}
				return result;
			}
		}

		public float Volume
		{
			get
			{
				float num = 0f;
				switch (Channel)
				{
				case VolumeChannel.Music:
					num = AudioManager.InternalInstance.ModifiedMusicVolume;
					break;
				case VolumeChannel.Sound:
					num = AudioManager.InternalInstance.ModifiedSoundVolume;
					break;
				case VolumeChannel.Voice:
					num = AudioManager.InternalInstance.ModifiedVoiceVolume;
					break;
				}
				if ((bool)audioFile)
				{
					num *= audioFile.relativeVolume;
				}
				return num;
			}
		}

		public Transform SpatializationTarget { get; private set; }

		public Vector3 SpatializationPosition { get; private set; }

		protected int LoopStart => (int)(audioFile.loopStart * (float)AudioSource.clip.frequency);

		protected int LoopEnd => (int)(audioFile.loopEnd * (float)AudioSource.clip.frequency);

		public AudioSource AudioSource { get; private set; }

		protected void OnApplicationPause(bool pause)
		{
			applicationPaused = pause && !Application.runInBackground;
		}

		public void Init(AudioMixerGroup defaultGroup)
		{
			AudioSource = GetComponent<AudioSource>();
			base.enabled = false;
			originalParent = base.transform.parent;
			defaultMixerGroup = defaultGroup;
		}

		protected virtual void OnEnable()
		{
			if (JSAMSettings.Settings.TimeScaledSounds)
			{
				AudioManagerInternal.OnTimeScaleChanged.Add(this);
			}
			if ((bool)audioFile && audioFile.spatialize)
			{
				switch (JSAMSettings.Settings.SpatializationMode)
				{
				case JSAMSettings.SpatializeUpdateMode.Default:
					AudioManagerInternal.OnSpatializeUpdate.Add(this);
					break;
				case JSAMSettings.SpatializeUpdateMode.FixedUpdate:
					AudioManagerInternal.OnSpatializeFixedUpdate.Add(this);
					break;
				case JSAMSettings.SpatializeUpdateMode.LateUpdate:
					AudioManagerInternal.OnSpatializeLateUpdate.Add(this);
					break;
				case JSAMSettings.SpatializeUpdateMode.Parented:
					break;
				}
			}
		}

		protected virtual void OnDisable()
		{
			if (JSAMSettings.Settings.TimeScaledSounds)
			{
				AudioManagerInternal.OnTimeScaleChanged.Remove(this);
			}
			if ((bool)audioFile && audioFile.spatialize)
			{
				switch (JSAMSettings.Settings.SpatializationMode)
				{
				case JSAMSettings.SpatializeUpdateMode.Default:
					AudioManagerInternal.OnSpatializeUpdate.Remove(this);
					break;
				case JSAMSettings.SpatializeUpdateMode.FixedUpdate:
					AudioManagerInternal.OnSpatializeFixedUpdate.Remove(this);
					break;
				case JSAMSettings.SpatializeUpdateMode.LateUpdate:
					AudioManagerInternal.OnSpatializeLateUpdate.Remove(this);
					break;
				}
			}
			if (subscribedToEvents)
			{
				UnsubscribeFromAudioEvents();
			}
		}

		protected virtual void Update()
		{
			if (audioFile.fadeInOut)
			{
				float num = audioFile.fadeInDuration * AudioSource.clip.length;
				float num2 = audioFile.fadeOutDuration * AudioSource.clip.length;
				if (AudioSource.time < AudioSource.clip.length - num2)
				{
					if (num > 0f)
					{
						AudioSource.volume = Mathf.Lerp(0f, audioFile.relativeVolume, AudioSource.time / num);
					}
				}
				else if (num2 > 0f)
				{
					AudioSource.volume = Mathf.Lerp(0f, audioFile.relativeVolume, (AudioSource.clip.length - AudioSource.time) / num2);
				}
			}
			if (audioFile.loopMode >= LoopMode.LoopWithLoopPoints)
			{
				if (AudioSource.timeSamples >= LoopEnd || !AudioSource.isPlaying)
				{
					AudioSource.Play();
					AudioSource.timeSamples = LoopStart;
				}
				if (audioFile.loopMode == LoopMode.ClampedLoopPoints && AudioSource.timeSamples < LoopStart)
				{
					AudioSource.timeSamples = LoopStart;
				}
			}
			else if (audioFile.loopMode <= LoopMode.LoopWithLoopPoints && !applicationPaused)
			{
				base.enabled = AudioSource.isPlaying;
			}
		}

		protected void SubscribeToVolumeEvents()
		{
			switch (Channel)
			{
			case VolumeChannel.Music:
				AudioManagerInternal.OnMusicVolumeChanged.Add(this);
				break;
			case VolumeChannel.Sound:
				AudioManagerInternal.OnSoundVolumeChanged.Add(this);
				break;
			case VolumeChannel.Voice:
				AudioManagerInternal.OnVoiceVolumeChanged.Add(this);
				break;
			}
			subscribedToEvents = true;
		}

		protected void UnsubscribeFromAudioEvents()
		{
			switch (Channel)
			{
			case VolumeChannel.Music:
				AudioManagerInternal.OnMusicVolumeChanged.Remove(this);
				break;
			case VolumeChannel.Sound:
				AudioManagerInternal.OnSoundVolumeChanged.Remove(this);
				break;
			case VolumeChannel.Voice:
				AudioManagerInternal.OnVoiceVolumeChanged.Remove(this);
				break;
			}
			subscribedToEvents = false;
		}

		protected void ClearProperties()
		{
			StopAllCoroutines();
			AudioSource.Stop();
			if ((object)AudioSource.clip != null)
			{
				AudioSource.timeSamples = 0;
			}
			if ((bool)audioFile)
			{
				UnsubscribeFromAudioEvents();
			}
		}

		public void AssignNewFile(T file)
		{
			ClearProperties();
			audioFile = file;
		}

		public virtual AudioSource Play()
		{
			if (!AssignNewAudioClip())
			{
				return AudioSource;
			}
			if (JSAMSettings.Settings.Spatialize && audioFile.spatialize)
			{
				AudioSource.spatialBlend = 1f;
				if (audioFile.maxDistance != 0f)
				{
					AudioSource.maxDistance = audioFile.maxDistance;
				}
				else
				{
					AudioSource.maxDistance = JSAMSettings.Settings.DefaultSoundMaxDistance;
				}
			}
			else
			{
				AudioSource.spatialBlend = 0f;
			}
			if (!subscribedToEvents)
			{
				SubscribeToVolumeEvents();
			}
			AudioSource.volume = Volume;
			AudioSource.outputAudioMixerGroup = (audioFile.mixerGroupOverride ? audioFile.mixerGroupOverride : defaultMixerGroup);
			AudioSource.priority = (int)audioFile.priority;
			AudioSource.pitch = audioFile.GetRandomPitch();
			switch (audioFile.loopMode)
			{
			case LoopMode.NoLooping:
				AudioSource.loop = false;
				break;
			case LoopMode.Looping:
			case LoopMode.LoopWithLoopPoints:
			case LoopMode.ClampedLoopPoints:
				AudioSource.loop = true;
				break;
			}
			ApplyEffects();
			AudioSource.PlayDelayed(audioFile.delay);
			base.enabled = true;
			return AudioSource;
		}

		public virtual void Stop(bool stopInstantly = true)
		{
			if (stopInstantly)
			{
				AudioSource.Stop();
			}
			StopAllCoroutines();
			base.enabled = false;
			AudioSource.loop = false;
		}

		public virtual void TimeScaleChanged(float previousTimeScale)
		{
			if (!audioFile.ignoreTimeScale)
			{
				float num = AudioSource.pitch - previousTimeScale;
				AudioSource.pitch = Time.timeScale;
				AudioSource.pitch += num;
			}
		}

		public bool AssignNewAudioClip()
		{
			if (audioFile.Files.Count > 1)
			{
				int num;
				do
				{
					num = Random.Range(0, audioFile.Files.Count);
					AudioSource.clip = audioFile.Files[num];
					if (AudioSource.clip == null)
					{
						Debug.LogWarning("Missing AudioClip at index " + num + " in " + audioFile.SafeName + "'s library!");
					}
				}
				while (num == audioFile.lastClipIndex && audioFile.neverRepeat);
				if (audioFile.neverRepeat)
				{
					audioFile.lastClipIndex = num;
				}
				return true;
			}
			if (audioFile.Files.Count == 1)
			{
				AudioSource.clip = audioFile.Files[0];
				return true;
			}
			return false;
		}

		public void Spatialize()
		{
			if (SpatializationTarget != null)
			{
				base.transform.position = SpatializationTarget.position;
			}
		}

		public virtual void SetSpatializationTarget(Transform target)
		{
			if (!(target == null) && (bool)audioFile && audioFile.spatialize && JSAMSettings.Settings.Spatialize)
			{
				switch (JSAMSettings.Settings.SpatializationMode)
				{
				case JSAMSettings.SpatializeUpdateMode.Default:
				case JSAMSettings.SpatializeUpdateMode.FixedUpdate:
				case JSAMSettings.SpatializeUpdateMode.LateUpdate:
					base.transform.SetParent(originalParent);
					SpatializationTarget = target;
					break;
				case JSAMSettings.SpatializeUpdateMode.Parented:
					base.transform.SetParent(target);
					break;
				}
				base.transform.position = target.position;
			}
		}

		public virtual void SetSpatializationTarget(Vector3 position)
		{
			if ((bool)audioFile && audioFile.spatialize && JSAMSettings.Settings.Spatialize)
			{
				SpatializationTarget = null;
				SpatializationPosition = position;
				base.transform.position = position;
			}
		}

		public void VolumeChanged(float channelVolume, float realVolume)
		{
			AudioSource.volume = realVolume * audioFile.relativeVolume;
		}

		public void BeginFadeIn(float fadeTime)
		{
			if (fadeInRoutine != null)
			{
				StopCoroutine(fadeInRoutine);
			}
			fadeInRoutine = StartCoroutine(FadeIn(fadeTime));
		}

		public void BeginFadeOut(float fadeTime)
		{
			if (fadeOutRoutine != null)
			{
				StopCoroutine(fadeOutRoutine);
			}
			fadeOutRoutine = StartCoroutine(FadeOut(fadeTime));
		}

		protected IEnumerator FadeIn(float fadeTime)
		{
			if (fadeTime != 0f)
			{
				float timer = 0f;
				while (timer < fadeTime)
				{
					timer = ((!audioFile.ignoreTimeScale) ? (timer + Time.deltaTime) : (timer + Time.unscaledDeltaTime));
					AudioSource.volume = Mathf.Lerp(0f, Volume, timer / fadeTime);
					yield return null;
				}
			}
			fadeInRoutine = null;
		}

		protected virtual IEnumerator FadeOut(float fadeTime)
		{
			if (fadeTime > 0f)
			{
				float startingVolume = AudioSource.volume;
				float timer = 0f;
				while (timer < fadeTime)
				{
					timer = ((!audioFile.ignoreTimeScale) ? (timer + Time.deltaTime) : (timer + Time.unscaledDeltaTime));
					AudioSource.volume = Mathf.Lerp(startingVolume, 0f, timer / fadeTime);
					yield return null;
				}
				AudioSource.Stop();
			}
			fadeOutRoutine = null;
		}

		public void ApplyEffects()
		{
			AudioSource.bypassEffects = audioFile.bypassEffects;
			AudioSource.bypassListenerEffects = audioFile.bypassListenerEffects;
			AudioSource.bypassReverbZones = audioFile.bypassReverbZones;
			if (audioFile.chorusFilter.enabled)
			{
				if (!chorusFilter)
				{
					chorusFilter = base.gameObject.AddComponent<AudioChorusFilter>();
				}
				chorusFilter.enabled = true;
				chorusFilter.dryMix = audioFile.chorusFilter.dryMix;
				chorusFilter.wetMix1 = audioFile.chorusFilter.wetMix1;
				chorusFilter.wetMix2 = audioFile.chorusFilter.wetMix2;
				chorusFilter.wetMix3 = audioFile.chorusFilter.wetMix3;
				chorusFilter.delay = audioFile.chorusFilter.delay;
				chorusFilter.rate = audioFile.chorusFilter.rate;
				chorusFilter.depth = audioFile.chorusFilter.depth;
			}
			else if (!audioFile.chorusFilter.enabled && (bool)chorusFilter)
			{
				chorusFilter.enabled = false;
			}
			if (audioFile.distortionFilter.enabled)
			{
				if (!distortionFilter)
				{
					distortionFilter = base.gameObject.AddComponent<AudioDistortionFilter>();
				}
				distortionFilter.enabled = true;
				distortionFilter.distortionLevel = audioFile.distortionFilter.distortionLevel;
			}
			else if (!audioFile.distortionFilter.enabled && (bool)distortionFilter)
			{
				distortionFilter.enabled = false;
			}
			if (audioFile.echoFilter.enabled)
			{
				if (!echoFilter)
				{
					echoFilter = base.gameObject.AddComponent<AudioEchoFilter>();
				}
				echoFilter.enabled = true;
				echoFilter.delay = audioFile.echoFilter.delay;
				echoFilter.decayRatio = audioFile.echoFilter.decayRatio;
				echoFilter.wetMix = audioFile.echoFilter.wetMix;
				echoFilter.dryMix = audioFile.echoFilter.dryMix;
			}
			else if (!audioFile.echoFilter.enabled && (bool)echoFilter)
			{
				echoFilter.enabled = false;
			}
			if (audioFile.highPassFilter.enabled)
			{
				if (!highPassFilter)
				{
					highPassFilter = base.gameObject.AddComponent<AudioHighPassFilter>();
				}
				highPassFilter.enabled = true;
				highPassFilter.cutoffFrequency = audioFile.highPassFilter.cutoffFrequency;
				highPassFilter.highpassResonanceQ = audioFile.highPassFilter.highpassResonanceQ;
			}
			else if (!audioFile.highPassFilter.enabled && (bool)highPassFilter)
			{
				highPassFilter.enabled = false;
			}
			if (audioFile.lowPassFilter.enabled)
			{
				if (!lowPassFilter)
				{
					lowPassFilter = base.gameObject.AddComponent<AudioLowPassFilter>();
				}
				lowPassFilter.enabled = true;
				lowPassFilter.cutoffFrequency = audioFile.lowPassFilter.cutoffFrequency;
				lowPassFilter.lowpassResonanceQ = audioFile.lowPassFilter.lowpassResonanceQ;
			}
			else if (!audioFile.lowPassFilter.enabled && (bool)lowPassFilter)
			{
				lowPassFilter.enabled = false;
			}
			if (audioFile.reverbFilter.enabled)
			{
				if (!reverbFilter)
				{
					reverbFilter = base.gameObject.AddComponent<AudioReverbFilter>();
				}
				reverbFilter.enabled = true;
				reverbFilter.reverbPreset = audioFile.reverbFilter.reverbPreset;
				reverbFilter.dryLevel = audioFile.reverbFilter.dryLevel;
				reverbFilter.room = audioFile.reverbFilter.room;
				reverbFilter.roomHF = audioFile.reverbFilter.roomHF;
				reverbFilter.roomLF = audioFile.reverbFilter.roomLF;
				reverbFilter.decayTime = audioFile.reverbFilter.decayTime;
				reverbFilter.decayHFRatio = audioFile.reverbFilter.decayHFRatio;
				reverbFilter.reflectionsLevel = audioFile.reverbFilter.reflectionsLevel;
				reverbFilter.reflectionsDelay = audioFile.reverbFilter.reflectionsDelay;
				reverbFilter.reverbLevel = audioFile.reverbFilter.reverbLevel;
				reverbFilter.reverbDelay = audioFile.reverbFilter.reverbDelay;
				reverbFilter.hfReference = audioFile.reverbFilter.hFReference;
				reverbFilter.lfReference = audioFile.reverbFilter.lFReference;
				reverbFilter.diffusion = audioFile.reverbFilter.diffusion;
				reverbFilter.density = audioFile.reverbFilter.density;
			}
			else if (!audioFile.reverbFilter.enabled && (bool)reverbFilter)
			{
				reverbFilter.enabled = false;
			}
		}

		public void ClearEffects()
		{
			if (this.TryForComponent<AudioChorusFilter>(out var comp))
			{
				comp.enabled = false;
			}
			if (this.TryForComponent<AudioDistortionFilter>(out var comp2))
			{
				comp2.enabled = false;
			}
			if (this.TryForComponent<AudioEchoFilter>(out var comp3))
			{
				comp3.enabled = false;
			}
			if (this.TryForComponent<AudioHighPassFilter>(out var comp4))
			{
				comp4.enabled = false;
			}
			if (this.TryForComponent<AudioLowPassFilter>(out var comp5))
			{
				comp5.enabled = false;
			}
			if (this.TryForComponent<AudioReverbFilter>(out var comp6))
			{
				comp6.enabled = false;
			}
		}
	}
}
