using System;
using System.Threading.Tasks;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[ExecuteAlways]
	[AddComponentMenu("")]
	[FeedbackPath("Audio/Sound")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.MMTools", null)]
	[FeedbackHelp("WARNING: this is a very simple feedback, that will let you play a sound. Nothing wrong with it being simple of course, but if you want more features, you'll want to look at the MMSoundManager Sound feedback.\n\nThis feedback lets you play the specified AudioClip, either via event (you'll need something in your scene to catch a MMSfxEvent, for example a MMSoundManager), or cached (AudioSource gets created on init, and is then ready to be played), or on demand (instantiated on Play). For all these methods you can define a random volume between min/max boundaries (just set the same value in both fields if you don't want randomness), random pitch, and an optional AudioMixerGroup.")]
	public class MMF_Sound : MMF_Feedback
	{
		public enum PlayMethods
		{
			Event = 0,
			Cached = 1,
			OnDemand = 2,
			Pool = 3
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Sound", true, 14, true, false)]
		[Tooltip("the sound clip to play")]
		public AudioClip Sfx;

		[Tooltip("an array to pick a random sfx from")]
		public AudioClip[] RandomSfx;

		public MMF_Button TestPlayButton;

		public MMF_Button TestStopButton;

		[MMFInspectorGroup("Play Method", true, 27, false, false)]
		[Tooltip("the play method to use when playing the sound (event, cached or on demand)")]
		public PlayMethods PlayMethod;

		[Tooltip("the size of the pool when in Pool mode")]
		[MMFEnumCondition("PlayMethod", new int[] { 3 })]
		public int PoolSize = 10;

		[Tooltip("in event mode, whether to use legacy events (MMSfxEvent) or the current events (MMSoundManagerSoundPlayEvent)")]
		[MMFEnumCondition("PlayMethod", new int[] { 0 })]
		public bool UseLegacyEventsMode;

		[Tooltip("if this is true, calling Stop on this feedback will also stop the sound from playing further")]
		public bool StopSoundOnFeedbackStop = true;

		[MMFInspectorGroup("Sound Properties", true, 28, false, false)]
		[Header("Volume")]
		[Tooltip("the minimum volume to play the sound at")]
		[Range(0f, 2f)]
		public float MinVolume = 1f;

		[Tooltip("the maximum volume to play the sound at")]
		[Range(0f, 2f)]
		public float MaxVolume = 1f;

		[Header("Pitch")]
		[Tooltip("the minimum pitch to play the sound at")]
		[Range(-3f, 3f)]
		public float MinPitch = 1f;

		[Tooltip("the maximum pitch to play the sound at")]
		[Range(-3f, 3f)]
		public float MaxPitch = 1f;

		[Header("Mixer")]
		[Tooltip("the audiomixer to play the sound with (optional)")]
		public AudioMixerGroup SfxAudioMixerGroup;

		[Tooltip("the audiosource priority, to be specified if needed between 0 (highest) and 256")]
		public int Priority = 128;

		[MMFInspectorGroup("Spatial Settings", true, 33, false, true)]
		[Tooltip("Pans a playing sound in a stereo way (left or right). This only applies to sounds that are Mono or Stereo.")]
		[Range(-1f, 1f)]
		public float PanStereo;

		[Tooltip("Sets how much this AudioSource is affected by 3D spatialisation calculations (attenuation, doppler etc). 0.0 makes the sound full 2D, 1.0 makes it full 3D.")]
		[Range(0f, 1f)]
		public float SpatialBlend;

		[MMFInspectorGroup("3D Sound Settings", true, 37, false, true)]
		[Tooltip("Sets the Doppler scale for this AudioSource.")]
		[Range(0f, 5f)]
		public float DopplerLevel = 1f;

		[Tooltip("Sets the spread angle (in degrees) of a 3d stereo or multichannel sound in speaker space.")]
		[Range(0f, 360f)]
		public int Spread;

		[Tooltip("Sets/Gets how the AudioSource attenuates over distance.")]
		public AudioRolloffMode RolloffMode;

		[Tooltip("Within the Min distance the AudioSource will cease to grow louder in volume.")]
		public float MinDistance = 1f;

		[Tooltip("(Logarithmic rolloff) MaxDistance is the distance a sound stops attenuating at.")]
		public float MaxDistance = 500f;

		[Tooltip("whether or not to use a custom curve for custom volume rolloff")]
		public bool UseCustomRolloffCurve;

		[Tooltip("the curve to use for custom volume rolloff if UseCustomRolloffCurve is true")]
		[MMFCondition("UseCustomRolloffCurve", true)]
		public AnimationCurve CustomRolloffCurve;

		[Tooltip("whether or not to use a custom curve for spatial blend")]
		public bool UseSpatialBlendCurve;

		[Tooltip("the curve to use for custom spatial blend if UseSpatialBlendCurve is true")]
		[MMFCondition("UseSpatialBlendCurve", true)]
		public AnimationCurve SpatialBlendCurve;

		[Tooltip("whether or not to use a custom curve for reverb zone mix")]
		public bool UseReverbZoneMixCurve;

		[Tooltip("the curve to use for custom reverb zone mix if UseReverbZoneMixCurve is true")]
		[MMFCondition("UseReverbZoneMixCurve", true)]
		public AnimationCurve ReverbZoneMixCurve;

		[Tooltip("whether or not to use a custom curve for spread")]
		public bool UseSpreadCurve;

		[Tooltip("the curve to use for custom spread if UseSpreadCurve is true")]
		[MMFCondition("UseSpreadCurve", true)]
		public AnimationCurve SpreadCurve;

		protected AudioClip _randomClip;

		protected AudioSource _cachedAudioSource;

		protected AudioSource[] _pool;

		protected AudioSource _tempAudioSource;

		protected float _duration;

		protected AudioSource _editorAudioSource;

		protected AudioSource _audioSource;

		protected AudioClip _lastPlayedClip;

		public override bool HasRandomness => true;

		public override float FeedbackDuration => GetDuration();

		public override void InitializeCustomAttributes()
		{
			base.InitializeCustomAttributes();
			TestPlayButton = new MMF_Button("Debug Play Sound", TestPlaySound);
			TestStopButton = new MMF_Button("Debug Stop Sound", TestStopSound);
		}

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			if (RandomSfx == null)
			{
				RandomSfx = Array.Empty<AudioClip>();
			}
			if (PlayMethod == PlayMethods.Cached && _cachedAudioSource == null)
			{
				_cachedAudioSource = CreateAudioSource(owner.gameObject, "CachedFeedbackAudioSource");
			}
			_lastPlayedClip = null;
			if (PlayMethod == PlayMethods.Pool)
			{
				_pool = new AudioSource[PoolSize];
				for (int i = 0; i < PoolSize; i++)
				{
					_pool[i] = CreateAudioSource(owner.gameObject, "PooledAudioSource" + i);
				}
			}
		}

		protected virtual AudioSource CreateAudioSource(GameObject owner, string audioSourceName)
		{
			GameObject gameObject = new GameObject(audioSourceName);
			SceneManager.MoveGameObjectToScene(gameObject.gameObject, Owner.gameObject.scene);
			gameObject.transform.position = owner.transform.position;
			gameObject.transform.SetParent(owner.transform);
			_tempAudioSource = gameObject.AddComponent<AudioSource>();
			_tempAudioSource.playOnAwake = false;
			return _tempAudioSource;
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (!Active || !FeedbackTypeAuthorized)
			{
				return;
			}
			float intensity = ComputeIntensity(feedbacksIntensity, position);
			if (Sfx != null)
			{
				_duration = Sfx.length;
				PlaySound(Sfx, position, intensity);
			}
			else if (RandomSfx.Length != 0)
			{
				_randomClip = RandomSfx[UnityEngine.Random.Range(0, RandomSfx.Length)];
				if (_randomClip != null)
				{
					_duration = _randomClip.length;
					PlaySound(_randomClip, position, intensity);
				}
			}
		}

		protected virtual float GetDuration()
		{
			if (Sfx != null)
			{
				return Sfx.length;
			}
			float num = 0f;
			if (RandomSfx != null && RandomSfx.Length != 0)
			{
				if (_lastPlayedClip != null)
				{
					return _lastPlayedClip.length;
				}
				AudioClip[] randomSfx = RandomSfx;
				foreach (AudioClip audioClip in randomSfx)
				{
					if (audioClip != null && audioClip.length > num)
					{
						num = audioClip.length;
					}
				}
				return num;
			}
			return 0f;
		}

		protected virtual void PlaySound(AudioClip sfx, Vector3 position, float intensity)
		{
			float num = UnityEngine.Random.Range(MinVolume, MaxVolume);
			if (!Timing.ConstantIntensity)
			{
				num *= intensity;
			}
			float num2 = UnityEngine.Random.Range(MinPitch, MaxPitch);
			int timeSamples = ((!NormalPlayDirection) ? (sfx.samples - 1) : 0);
			if (!NormalPlayDirection)
			{
				num2 = 0f - num2;
			}
			_lastPlayedClip = sfx;
			Owner.ComputeCachedTotalDuration();
			switch (PlayMethod)
			{
			case PlayMethods.Event:
			{
				if (UseLegacyEventsMode)
				{
					MMSfxEvent.Trigger(sfx, SfxAudioMixerGroup, num, num2, Priority);
					break;
				}
				MMSoundManagerPlayOptions mMSoundManagerPlayOptions = default(MMSoundManagerPlayOptions);
				mMSoundManagerPlayOptions = MMSoundManagerPlayOptions.Default;
				mMSoundManagerPlayOptions.Location = Owner.transform.position;
				mMSoundManagerPlayOptions.AudioGroup = SfxAudioMixerGroup;
				mMSoundManagerPlayOptions.DoNotAutoRecycleIfNotDonePlaying = true;
				mMSoundManagerPlayOptions.Volume = num;
				mMSoundManagerPlayOptions.Pitch = num2;
				mMSoundManagerPlayOptions.PanStereo = PanStereo;
				mMSoundManagerPlayOptions.SpatialBlend = SpatialBlend;
				mMSoundManagerPlayOptions.Priority = Priority;
				mMSoundManagerPlayOptions.DopplerLevel = DopplerLevel;
				mMSoundManagerPlayOptions.Spread = Spread;
				mMSoundManagerPlayOptions.RolloffMode = RolloffMode;
				mMSoundManagerPlayOptions.MinDistance = MinDistance;
				mMSoundManagerPlayOptions.MaxDistance = MaxDistance;
				mMSoundManagerPlayOptions.UseSpreadCurve = UseSpreadCurve;
				mMSoundManagerPlayOptions.SpreadCurve = SpreadCurve;
				mMSoundManagerPlayOptions.UseCustomRolloffCurve = UseCustomRolloffCurve;
				mMSoundManagerPlayOptions.CustomRolloffCurve = CustomRolloffCurve;
				mMSoundManagerPlayOptions.UseSpatialBlendCurve = UseSpatialBlendCurve;
				mMSoundManagerPlayOptions.SpatialBlendCurve = SpatialBlendCurve;
				mMSoundManagerPlayOptions.UseReverbZoneMixCurve = UseReverbZoneMixCurve;
				mMSoundManagerPlayOptions.ReverbZoneMixCurve = ReverbZoneMixCurve;
				if (Priority >= 0)
				{
					mMSoundManagerPlayOptions.Priority = Mathf.Min(Priority, 256);
				}
				mMSoundManagerPlayOptions.MmSoundManagerTrack = MMSoundManager.MMSoundManagerTracks.Sfx;
				mMSoundManagerPlayOptions.Loop = false;
				_audioSource = MMSoundManagerSoundPlayEvent.Trigger(sfx, mMSoundManagerPlayOptions);
				break;
			}
			case PlayMethods.Cached:
				PlayAudioSource(_cachedAudioSource, sfx, num, num2, timeSamples, SfxAudioMixerGroup, Priority);
				break;
			case PlayMethods.OnDemand:
			{
				GameObject gameObject = new GameObject("TempAudio");
				SceneManager.MoveGameObjectToScene(gameObject.gameObject, Owner.gameObject.scene);
				gameObject.transform.position = position;
				AudioSource audioSource = gameObject.AddComponent<AudioSource>();
				PlayAudioSource(audioSource, sfx, num, num2, timeSamples, SfxAudioMixerGroup, Priority);
				Owner.ProxyDestroy(gameObject, sfx.length * Time.timeScale);
				break;
			}
			case PlayMethods.Pool:
				_tempAudioSource = GetAudioSourceFromPool();
				if (_tempAudioSource != null)
				{
					PlayAudioSource(_tempAudioSource, sfx, num, num2, timeSamples, SfxAudioMixerGroup, Priority);
				}
				break;
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && StopSoundOnFeedbackStop && _audioSource != null)
			{
				_audioSource.Stop();
			}
		}

		protected virtual void PlayAudioSource(AudioSource audioSource, AudioClip sfx, float volume, float pitch, int timeSamples, AudioMixerGroup audioMixerGroup = null, int priority = 128)
		{
			_audioSource = audioSource;
			audioSource.clip = sfx;
			audioSource.timeSamples = timeSamples;
			audioSource.volume = volume;
			audioSource.pitch = pitch;
			audioSource.priority = priority;
			audioSource.panStereo = PanStereo;
			audioSource.spatialBlend = SpatialBlend;
			audioSource.dopplerLevel = DopplerLevel;
			audioSource.spread = Spread;
			audioSource.rolloffMode = RolloffMode;
			audioSource.minDistance = MinDistance;
			audioSource.maxDistance = MaxDistance;
			if (UseSpreadCurve)
			{
				audioSource.SetCustomCurve(AudioSourceCurveType.Spread, SpreadCurve);
			}
			if (UseCustomRolloffCurve)
			{
				audioSource.SetCustomCurve(AudioSourceCurveType.CustomRolloff, CustomRolloffCurve);
			}
			if (UseSpatialBlendCurve)
			{
				audioSource.SetCustomCurve(AudioSourceCurveType.SpatialBlend, SpatialBlendCurve);
			}
			if (UseReverbZoneMixCurve)
			{
				audioSource.SetCustomCurve(AudioSourceCurveType.ReverbZoneMix, ReverbZoneMixCurve);
			}
			audioSource.loop = false;
			if (audioMixerGroup != null)
			{
				audioSource.outputAudioMixerGroup = audioMixerGroup;
			}
			audioSource.Play();
		}

		protected virtual AudioSource GetAudioSourceFromPool()
		{
			for (int i = 0; i < PoolSize; i++)
			{
				if (!_pool[i].isPlaying)
				{
					return _pool[i];
				}
			}
			return null;
		}

		protected virtual async void TestPlaySound()
		{
			AudioClip audioClip = null;
			if (Sfx != null)
			{
				audioClip = Sfx;
			}
			if (RandomSfx.Length != 0)
			{
				audioClip = RandomSfx[UnityEngine.Random.Range(0, RandomSfx.Length)];
			}
			if (audioClip == null)
			{
				Debug.LogError(Label + " on " + Owner.gameObject.name + " can't play in editor mode, you haven't set its Sfx.");
				return;
			}
			float volume = UnityEngine.Random.Range(MinVolume, MaxVolume);
			float pitch = UnityEngine.Random.Range(MinPitch, MaxPitch);
			GameObject temporaryAudioHost = new GameObject("EditorTestAS_WillAutoDestroy");
			SceneManager.MoveGameObjectToScene(temporaryAudioHost.gameObject, Owner.gameObject.scene);
			temporaryAudioHost.transform.position = Owner.transform.position;
			_editorAudioSource = temporaryAudioHost.AddComponent<AudioSource>();
			PlayAudioSource(_editorAudioSource, audioClip, volume, pitch, 0);
			await Task.Delay((int)(1000f * audioClip.length));
			Owner.ProxyDestroyImmediate(temporaryAudioHost);
		}

		protected virtual void TestStopSound()
		{
			if (_editorAudioSource != null)
			{
				_editorAudioSource.Stop();
			}
		}

		public override void AutomaticShakerSetup()
		{
			if (PlayMethod == PlayMethods.Event && (MMSoundManager)UnityEngine.Object.FindAnyObjectByType(typeof(MMSoundManager)) == null)
			{
				new GameObject("MMSoundManager").AddComponent<MMSoundManager>();
				MMDebug.DebugLogInfo("Added a MMSoundManager to the scene. You're all set.");
			}
		}
	}
}
