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
	[MovedFrom(false, null, "MoreMountains.Feedbacks.MMTools", null)]
	[FeedbackPath("Audio/MMSoundManager Sound")]
	[FeedbackHelp("This feedback will let you play a sound via the MMSoundManager. You will need a game object in your scene with a MMSoundManager object on it for this to work.")]
	public class MMF_MMSoundManagerSound : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Sound", true, 14, true, false)]
		[Tooltip("the sound clip to play")]
		public AudioClip Sfx;

		[MMFInspectorGroup("Random Sound", true, 34, true, false)]
		[Tooltip("an array to pick a random sfx from")]
		public AudioClip[] RandomSfx;

		[Tooltip("if this is true, random sfx audio clips will be played in sequential order instead of at random")]
		public bool SequentialOrder;

		[Tooltip("if we're in sequential order, determines whether or not to hold at the last index, until either a cooldown is met, or the ResetSequentialIndex method is called")]
		[MMFCondition("SequentialOrder", true)]
		public bool SequentialOrderHoldLast;

		[Tooltip("if we're in sequential order hold last mode, index will reset to 0 automatically after this duration, unless it's 0, in which case it'll be ignored")]
		[MMFCondition("SequentialOrderHoldLast", true)]
		public float SequentialOrderHoldCooldownDuration = 2f;

		[Tooltip("if this is true, sfx will be picked at random until all have been played. once this happens, the list is shuffled again, and it starts over")]
		public bool RandomUnique;

		[MMFInspectorGroup("Scriptable Object", true, 14, true, false)]
		[Tooltip("a scriptable object (created via the Create/MoreMountains/Audio/MMF_SoundData menu) to define settings that will override all other settings on this feedback")]
		public MMF_MMSoundManagerSoundData SoundDataSO;

		[MMFInspectorGroup("Sound Properties", true, 24, false, false)]
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

		[MMFInspectorGroup("SoundManager Options", true, 28, false, false)]
		[Tooltip("the track on which to play the sound. Pick the one that matches the nature of your sound")]
		public MMSoundManager.MMSoundManagerTracks MmSoundManagerTrack;

		[Tooltip("the ID of the sound. This is useful if you plan on using sound control feedbacks on it afterwards.")]
		public int ID;

		[Tooltip("the AudioGroup on which to play the sound. If you're already targeting a preset track, you can leave it blank, otherwise the group you specify here will override it.")]
		public AudioMixerGroup AudioGroup;

		[Tooltip("if (for some reason) you've already got an audiosource and wouldn't like to use the built-in pool system, you can specify it here")]
		public AudioSource RecycleAudioSource;

		[Tooltip("whether or not this sound should loop")]
		public bool Loop;

		[Tooltip("whether or not this sound should continue playing when transitioning to another scene")]
		public bool Persistent;

		[Tooltip("whether or not this sound should play if the same sound clip is already playing")]
		public bool DoNotPlayIfClipAlreadyPlaying;

		[Tooltip("if this is true, this sound will stop playing when stopping the feedback")]
		public bool StopSoundOnFeedbackStop;

		[MMFInspectorGroup("Fade", true, 30, false, false)]
		[Tooltip("whether or not to fade this sound in when playing it")]
		public bool Fade;

		[Tooltip("if fading, the volume at which to start the fade")]
		[MMCondition("Fade", true)]
		public float FadeInitialVolume;

		[Tooltip("if fading, the duration of the fade, in seconds")]
		[MMCondition("Fade", true)]
		public float FadeDuration = 1f;

		[Tooltip("if fading, the tween over which to fade the sound ")]
		[MMCondition("Fade", true)]
		public MMTweenType FadeTween = new MMTweenType(MMTween.MMTweenCurve.EaseInOutQuartic);

		[MMFInspectorGroup("Solo", true, 32, false, false)]
		[Tooltip("whether or not this sound should play in solo mode over its destination track. If yes, all other sounds on that track will be muted when this sound starts playing")]
		public bool SoloSingleTrack;

		[Tooltip("whether or not this sound should play in solo mode over all other tracks. If yes, all other tracks will be muted when this sound starts playing")]
		public bool SoloAllTracks;

		[Tooltip("if in any of the above solo modes, AutoUnSoloOnEnd will unmute the track(s) automatically once that sound stops playing")]
		public bool AutoUnSoloOnEnd;

		[MMFInspectorGroup("Spatial Settings", true, 33, false, false)]
		[Tooltip("Pans a playing sound in a stereo way (left or right). This only applies to sounds that are Mono or Stereo.")]
		[Range(-1f, 1f)]
		public float PanStereo;

		[Tooltip("Sets how much this AudioSource is affected by 3D spatialisation calculations (attenuation, doppler etc). 0.0 makes the sound full 2D, 1.0 makes it full 3D.")]
		[Range(0f, 1f)]
		public float SpatialBlend;

		[Tooltip("a Transform this sound can 'attach' to and follow it along as it plays")]
		public Transform AttachToTransform;

		[MMFInspectorGroup("Effects", true, 36, false, false)]
		[Tooltip("Bypass effects (Applied from filter components or global listener filters).")]
		public bool BypassEffects;

		[Tooltip("When set global effects on the AudioListener will not be applied to the audio signal generated by the AudioSource. Does not apply if the AudioSource is playing into a mixer group.")]
		public bool BypassListenerEffects;

		[Tooltip("When set doesn't route the signal from an AudioSource into the global reverb associated with reverb zones.")]
		public bool BypassReverbZones;

		[Tooltip("Sets the priority of the AudioSource.")]
		[Range(0f, 256f)]
		public int Priority = 128;

		[Tooltip("The amount by which the signal from the AudioSource will be mixed into the global reverb associated with the Reverb Zones.")]
		[Range(0f, 1.1f)]
		public float ReverbZoneMix = 1f;

		[MMFInspectorGroup("Time Options", true, 15, false, false)]
		[Tooltip("a timestamp (in seconds, randomized between the defined min and max) at which the sound will start playing, equivalent to the Audiosource API's Time)")]
		[MMVector(new string[] { "Min", "Max" })]
		public Vector2 PlaybackTime = new Vector2(0f, 0f);

		[Tooltip("a duration (in seconds, randomized between the defined min and max) for which the sound will play before stopping. Ignored if min and max are zero.")]
		[MMVector(new string[] { "Min", "Max" })]
		public Vector2 PlaybackDuration = new Vector2(0f, 0f);

		[MMFInspectorGroup("3D Sound Settings", true, 37, false, false)]
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

		[MMFInspectorGroup("Debug", true, 31, false, false)]
		[Tooltip("whether or not to draw sound falloff gizmos when this MMF Player is selected")]
		public bool DrawGizmos;

		[Tooltip("an object to use as the center of the gizmos. If left empty, this MMF Player's position will be used.")]
		[MMFCondition("DrawGizmos", true)]
		public Transform GizmosCenter;

		[Tooltip("the color to use to draw the min distance sphere of the sound falloff gizmos")]
		[MMFCondition("DrawGizmos", true)]
		public Color MinDistanceColor = MMColors.CadetBlue;

		[Tooltip("the color to use to draw the max distance sphere of the sound falloff gizmos")]
		[MMFCondition("DrawGizmos", true)]
		public Color MaxDistanceColor = MMColors.Orangered;

		public MMF_Button TestPlayButton;

		public MMF_Button TestStopButton;

		public MMF_Button ResetSequentialIndexButton;

		protected AudioClip _randomClip;

		protected AudioSource _editorAudioSource;

		protected MMSoundManagerPlayOptions _options;

		protected AudioSource _playedAudioSource;

		protected float _randomPlaybackTime;

		protected float _randomPlaybackDuration;

		protected int _currentIndex;

		protected Vector3 _gizmoCenter;

		protected MMShufflebag<int> _randomUniqueShuffleBag;

		protected AudioClip _lastPlayedClip;

		public override float FeedbackDuration => GetDuration();

		public override bool HasRandomness => true;

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			HandleSO();
			_lastPlayedClip = null;
			if (RandomUnique)
			{
				_randomUniqueShuffleBag = new MMShufflebag<int>(RandomSfx.Length);
				for (int i = 0; i < RandomSfx.Length; i++)
				{
					_randomUniqueShuffleBag.Add(i, 1);
				}
			}
		}

		public override void InitializeCustomAttributes()
		{
			base.InitializeCustomAttributes();
			TestPlayButton = new MMF_Button("Debug Play Sound", TestPlaySound);
			TestStopButton = new MMF_Button("Debug Stop Sound", TestStopSound);
			ResetSequentialIndexButton = new MMF_Button("Reset Sequential Index", ResetSequentialIndex);
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (!Active || !FeedbackTypeAuthorized)
			{
				return;
			}
			float intensity = ComputeIntensity(feedbacksIntensity, position);
			if (RandomSfx.Length != 0)
			{
				_randomClip = PickRandomClip();
				if (_randomClip != null)
				{
					PlaySound(_randomClip, position, intensity);
					return;
				}
			}
			if (Sfx != null)
			{
				PlaySound(Sfx, position, intensity);
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && StopSoundOnFeedbackStop && _playedAudioSource != null)
			{
				_playedAudioSource.Stop();
				MMPersistentSingleton<MMSoundManager>.Instance.FreeSound(_playedAudioSource);
			}
		}

		protected virtual void HandleSO()
		{
			if (!(SoundDataSO == null))
			{
				Sfx = SoundDataSO.Sfx;
				RandomSfx = SoundDataSO.RandomSfx;
				SequentialOrder = SoundDataSO.SequentialOrder;
				SequentialOrderHoldLast = SoundDataSO.SequentialOrderHoldLast;
				SequentialOrderHoldCooldownDuration = SoundDataSO.SequentialOrderHoldCooldownDuration;
				RandomUnique = SoundDataSO.RandomUnique;
				MinVolume = SoundDataSO.MinVolume;
				MaxVolume = SoundDataSO.MaxVolume;
				MinPitch = SoundDataSO.MinPitch;
				MaxPitch = SoundDataSO.MaxPitch;
				PlaybackTime = SoundDataSO.PlaybackTime;
				PlaybackDuration = SoundDataSO.PlaybackDuration;
				MmSoundManagerTrack = SoundDataSO.MmSoundManagerTrack;
				ID = SoundDataSO.ID;
				AudioGroup = SoundDataSO.AudioGroup;
				RecycleAudioSource = SoundDataSO.RecycleAudioSource;
				Loop = SoundDataSO.Loop;
				Persistent = SoundDataSO.Persistent;
				DoNotPlayIfClipAlreadyPlaying = SoundDataSO.DoNotPlayIfClipAlreadyPlaying;
				StopSoundOnFeedbackStop = SoundDataSO.StopSoundOnFeedbackStop;
				Fade = SoundDataSO.Fade;
				FadeInitialVolume = SoundDataSO.FadeInitialVolume;
				FadeDuration = SoundDataSO.FadeDuration;
				FadeTween = SoundDataSO.FadeTween;
				SoloSingleTrack = SoundDataSO.SoloSingleTrack;
				SoloAllTracks = SoundDataSO.SoloAllTracks;
				AutoUnSoloOnEnd = SoundDataSO.AutoUnSoloOnEnd;
				PanStereo = SoundDataSO.PanStereo;
				SpatialBlend = SoundDataSO.SpatialBlend;
				AttachToTransform = SoundDataSO.AttachToTransform;
				BypassEffects = SoundDataSO.BypassEffects;
				BypassListenerEffects = SoundDataSO.BypassListenerEffects;
				BypassReverbZones = SoundDataSO.BypassReverbZones;
				Priority = SoundDataSO.Priority;
				ReverbZoneMix = SoundDataSO.ReverbZoneMix;
				DopplerLevel = SoundDataSO.DopplerLevel;
				Spread = SoundDataSO.Spread;
				RolloffMode = SoundDataSO.RolloffMode;
				MinDistance = SoundDataSO.MinDistance;
				MaxDistance = SoundDataSO.MaxDistance;
				UseCustomRolloffCurve = SoundDataSO.UseCustomRolloffCurve;
				CustomRolloffCurve = SoundDataSO.CustomRolloffCurve;
				UseSpatialBlendCurve = SoundDataSO.UseSpatialBlendCurve;
				SpatialBlendCurve = SoundDataSO.SpatialBlendCurve;
				UseReverbZoneMixCurve = SoundDataSO.UseReverbZoneMixCurve;
				ReverbZoneMixCurve = SoundDataSO.ReverbZoneMixCurve;
				UseSpreadCurve = SoundDataSO.UseSpreadCurve;
				SpreadCurve = SoundDataSO.SpreadCurve;
			}
		}

		public virtual void RandomizeTimes()
		{
			_randomPlaybackTime = Random.Range(PlaybackTime.x, PlaybackTime.y);
			_randomPlaybackDuration = Random.Range(PlaybackDuration.x, PlaybackDuration.y);
			Owner.ComputeCachedTotalDuration();
		}

		protected virtual void PlaySound(AudioClip sfx, Vector3 position, float intensity)
		{
			if (!DoNotPlayIfClipAlreadyPlaying || !(MMPersistentSingleton<MMSoundManager>.Instance.FindByClip(sfx) != null) || !MMPersistentSingleton<MMSoundManager>.Instance.FindByClip(sfx).isPlaying)
			{
				float num = Random.Range(MinVolume, MaxVolume);
				if (!Timing.ConstantIntensity)
				{
					num *= intensity;
				}
				float pitch = Random.Range(MinPitch, MaxPitch);
				RandomizeTimes();
				if (!NormalPlayDirection)
				{
					_ = sfx.samples;
				}
				_options.MmSoundManagerTrack = MmSoundManagerTrack;
				_options.Location = position;
				_options.Loop = Loop;
				_options.Volume = num;
				_options.ID = ID;
				_options.Fade = Fade;
				_options.FadeInitialVolume = FadeInitialVolume;
				_options.FadeDuration = FadeDuration;
				_options.FadeTween = FadeTween;
				_options.Persistent = Persistent;
				_options.RecycleAudioSource = RecycleAudioSource;
				_options.AudioGroup = AudioGroup;
				_options.Pitch = pitch;
				_options.PlaybackTime = _randomPlaybackTime;
				_options.PlaybackDuration = _randomPlaybackDuration;
				_options.PanStereo = PanStereo;
				_options.SpatialBlend = SpatialBlend;
				_options.SoloSingleTrack = SoloSingleTrack;
				_options.SoloAllTracks = SoloAllTracks;
				_options.AutoUnSoloOnEnd = AutoUnSoloOnEnd;
				_options.BypassEffects = BypassEffects;
				_options.BypassListenerEffects = BypassListenerEffects;
				_options.BypassReverbZones = BypassReverbZones;
				_options.Priority = Priority;
				_options.ReverbZoneMix = ReverbZoneMix;
				_options.DopplerLevel = DopplerLevel;
				_options.Spread = Spread;
				_options.RolloffMode = RolloffMode;
				_options.MinDistance = MinDistance;
				_options.MaxDistance = MaxDistance;
				_options.AttachToTransform = AttachToTransform;
				_options.UseSpreadCurve = UseSpreadCurve;
				_options.SpreadCurve = SpreadCurve;
				_options.UseCustomRolloffCurve = UseCustomRolloffCurve;
				_options.CustomRolloffCurve = CustomRolloffCurve;
				_options.UseSpatialBlendCurve = UseSpatialBlendCurve;
				_options.SpatialBlendCurve = SpatialBlendCurve;
				_options.UseReverbZoneMixCurve = UseReverbZoneMixCurve;
				_options.ReverbZoneMixCurve = ReverbZoneMixCurve;
				_options.DoNotAutoRecycleIfNotDonePlaying = true;
				_playedAudioSource = MMSoundManagerSoundPlayEvent.Trigger(sfx, _options);
				_lastPlayTimestamp = FeedbackTime;
				_lastPlayedClip = sfx;
			}
		}

		protected virtual float GetDuration()
		{
			if (SoundDataSO != null)
			{
				return ComputeDuration(SoundDataSO.Sfx, SoundDataSO.RandomSfx);
			}
			return ComputeDuration(Sfx, RandomSfx);
		}

		protected virtual float ComputeDuration(AudioClip sfx, AudioClip[] randomSfx)
		{
			if (sfx != null)
			{
				if (!(_randomPlaybackDuration > 0f))
				{
					return sfx.length - _randomPlaybackTime;
				}
				return _randomPlaybackDuration;
			}
			float num = 0f;
			if (randomSfx != null && randomSfx.Length != 0)
			{
				if (_lastPlayedClip != null)
				{
					return _lastPlayedClip.length;
				}
				foreach (AudioClip audioClip in randomSfx)
				{
					if (audioClip != null && audioClip.length > num)
					{
						num = audioClip.length;
					}
				}
				if (!(_randomPlaybackDuration > 0f))
				{
					return num - _randomPlaybackTime;
				}
				return _randomPlaybackDuration;
			}
			return 0f;
		}

		public override void OnDrawGizmosSelectedHandler()
		{
			if (DrawGizmos)
			{
				_gizmoCenter = ((GizmosCenter != null) ? GizmosCenter.position : Owner.transform.position);
				Gizmos.color = MinDistanceColor;
				Gizmos.DrawWireSphere(_gizmoCenter, MinDistance);
				Gizmos.color = MaxDistanceColor;
				Gizmos.DrawWireSphere(_gizmoCenter, MaxDistance);
			}
		}

		public override void AutomaticShakerSetup()
		{
			if ((MMSoundManager)Object.FindFirstObjectByType(typeof(MMSoundManager)) == null)
			{
				new GameObject("MMSoundManager").AddComponent<MMSoundManager>();
				MMDebug.DebugLogInfo("Added a MMSoundManager to the scene. You're all set.");
			}
		}

		protected virtual async void TestPlaySound()
		{
			AudioClip audioClip = null;
			if (Sfx != null)
			{
				audioClip = Sfx;
			}
			if (RandomSfx != null && RandomSfx.Length != 0)
			{
				audioClip = PickRandomClip();
			}
			if (audioClip == null)
			{
				Debug.LogError(Label + " on " + Owner.gameObject.name + " can't play in editor mode, you haven't set its Sfx.");
				return;
			}
			float volume = Random.Range(MinVolume, MaxVolume);
			float num = Random.Range(MinPitch, MaxPitch);
			RandomizeTimes();
			GameObject temporaryAudioHost = new GameObject("EditorTestAS_WillAutoDestroy");
			SceneManager.MoveGameObjectToScene(temporaryAudioHost.gameObject, Owner.gameObject.scene);
			temporaryAudioHost.transform.position = Owner.transform.position;
			_editorAudioSource = temporaryAudioHost.AddComponent<AudioSource>();
			PlayAudioSource(_editorAudioSource, audioClip, volume, num, _randomPlaybackTime, _randomPlaybackDuration);
			_lastPlayTimestamp = FeedbackTime;
			_lastPlayedClip = audioClip;
			await Task.Delay((int)(((_randomPlaybackDuration > 0f) ? _randomPlaybackDuration : audioClip.length) * 1000f / Mathf.Abs(num)));
			Object.DestroyImmediate(temporaryAudioHost);
		}

		protected virtual void TestStopSound()
		{
			if (_editorAudioSource != null)
			{
				_editorAudioSource.Stop();
			}
		}

		protected virtual void PlayAudioSource(AudioSource audioSource, AudioClip sfx, float volume, float pitch, float time, float playbackDuration)
		{
			audioSource.clip = sfx;
			audioSource.time = time;
			audioSource.volume = volume;
			audioSource.pitch = pitch;
			audioSource.loop = false;
			audioSource.Play();
		}

		protected virtual AudioClip PickRandomClip()
		{
			int num = 0;
			if (!SequentialOrder)
			{
				num = ((!RandomUnique) ? Random.Range(0, RandomSfx.Length) : _randomUniqueShuffleBag.Pick());
			}
			else
			{
				num = _currentIndex;
				if (num >= RandomSfx.Length)
				{
					if (SequentialOrderHoldLast)
					{
						num--;
						if (SequentialOrderHoldCooldownDuration > 0f && FeedbackTime - _lastPlayTimestamp > SequentialOrderHoldCooldownDuration)
						{
							num = 0;
						}
					}
					else
					{
						num = 0;
					}
				}
				_currentIndex = num + 1;
			}
			return RandomSfx[num];
		}

		public virtual void ResetSequentialIndex()
		{
			_currentIndex = 0;
		}

		public virtual void SetSequentialIndex(int newIndex)
		{
			_currentIndex = newIndex;
		}

		public override void OnValidate()
		{
			base.OnValidate();
			RandomizeTimes();
			if (RandomSfx != null && RandomSfx.Length != 0)
			{
				_randomUniqueShuffleBag = new MMShufflebag<int>(RandomSfx.Length);
				for (int i = 0; i < RandomSfx.Length; i++)
				{
					_randomUniqueShuffleBag.Add(i, 1);
				}
			}
		}
	}
}
