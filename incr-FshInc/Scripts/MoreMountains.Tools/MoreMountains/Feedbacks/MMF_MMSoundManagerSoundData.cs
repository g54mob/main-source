using System;
using System.Threading.Tasks;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace MoreMountains.Feedbacks
{
	[Serializable]
	[CreateAssetMenu(menuName = "MoreMountains/Audio/MMF_SoundData")]
	public class MMF_MMSoundManagerSoundData : ScriptableObject
	{
		[Header("Sound")]
		[Tooltip("the sound clip to play")]
		public AudioClip Sfx;

		[Header("Random Sound")]
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

		[Header("Sound Properties")]
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

		[Header("Time")]
		[Tooltip("a timestamp (in seconds, randomized between the defined min and max) at which the sound will start playing, equivalent to the Audiosource API's Time)")]
		[MMFVector(new string[] { "Min", "Max" })]
		public Vector2 PlaybackTime = new Vector2(0f, 0f);

		[Tooltip("a duration (in seconds, randomized between the defined min and max) for which the sound will play before stopping. Ignored if min and max are zero.")]
		[MMVector(new string[] { "Min", "Max" })]
		public Vector2 PlaybackDuration = new Vector2(0f, 0f);

		[Header("Sound Manager Options")]
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

		[Tooltip("the maximum amount of instances of this sound allowed to play at once. use -1 for unlimited concurrent plays")]
		public int MaximumConcurrentInstances = -1;

		[Tooltip("if this is true, this sound will stop playing when stopping the feedback")]
		public bool StopSoundOnFeedbackStop;

		[Header("Fade In")]
		[Tooltip("whether or not to fade this sound in when playing it")]
		public bool FadeIn;

		[Tooltip("if fading, the volume at which to start the fade")]
		[MMCondition("FadeIn", true)]
		public float FadeInInitialVolume;

		[Tooltip("if fading, the duration of the fade, in seconds")]
		[MMCondition("FadeIn", true)]
		public float FadeInDuration = 1f;

		[Tooltip("if fading, the tween over which to fade the sound ")]
		public MMTweenType FadeInTween = new MMTweenType(MMTween.MMTweenCurve.EaseInOutQuartic, "FadeIn", "");

		[Header("Fade Out")]
		[Tooltip("whether or not to fade this sound in when stopping the feedback")]
		public bool FadeOutOnStop;

		[Tooltip("if fading out, the duration of the fade, in seconds")]
		[MMCondition("FadeOutOnStop", true)]
		public float FadeOutDuration = 1f;

		[Tooltip("if fading out, the tween over which to fade the sound ")]
		public MMTweenType FadeOutTween = new MMTweenType(MMTween.MMTweenCurve.EaseInOutQuartic, "FadeOutOnStop", "");

		[Header("Solo")]
		[Tooltip("whether or not this sound should play in solo mode over its destination track. If yes, all other sounds on that track will be muted when this sound starts playing")]
		public bool SoloSingleTrack;

		[Tooltip("whether or not this sound should play in solo mode over all other tracks. If yes, all other tracks will be muted when this sound starts playing")]
		public bool SoloAllTracks;

		[Tooltip("if in any of the above solo modes, AutoUnSoloOnEnd will unmute the track(s) automatically once that sound stops playing")]
		public bool AutoUnSoloOnEnd;

		[Header("Spatial Settings")]
		[Tooltip("Pans a playing sound in a stereo way (left or right). This only applies to sounds that are Mono or Stereo.")]
		[Range(-1f, 1f)]
		public float PanStereo;

		[Tooltip("Sets how much this AudioSource is affected by 3D spatialisation calculations (attenuation, doppler etc). 0.0 makes the sound full 2D, 1.0 makes it full 3D.")]
		[Range(0f, 1f)]
		public float SpatialBlend;

		[Tooltip("a Transform this sound can 'attach' to and follow it along as it plays - when used on a feedback, will only apply if the feedback's AttachToTransform is empty")]
		public Transform AttachToTransform;

		[Header("Effects")]
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

		[Header("3D Sound Settings")]
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
		[MMCondition("UseCustomRolloffCurve", true)]
		public AnimationCurve CustomRolloffCurve;

		[Tooltip("whether or not to use a custom curve for spatial blend")]
		public bool UseSpatialBlendCurve;

		[Tooltip("the curve to use for custom spatial blend if UseSpatialBlendCurve is true")]
		[MMCondition("UseSpatialBlendCurve", true)]
		public AnimationCurve SpatialBlendCurve;

		[Tooltip("whether or not to use a custom curve for reverb zone mix")]
		public bool UseReverbZoneMixCurve;

		[Tooltip("the curve to use for custom reverb zone mix if UseReverbZoneMixCurve is true")]
		[MMCondition("UseReverbZoneMixCurve", true)]
		public AnimationCurve ReverbZoneMixCurve;

		[Tooltip("whether or not to use a custom curve for spread")]
		public bool UseSpreadCurve;

		[Tooltip("the curve to use for custom spread if UseSpreadCurve is true")]
		[MMCondition("UseSpreadCurve", true)]
		public AnimationCurve SpreadCurve;

		[MMInspectorButton("TestPlaySound")]
		public bool TestPlaySoundButton;

		protected AudioClip _randomClip;

		protected MMShufflebag<int> _randomUniqueShuffleBag;

		protected int _currentIndex;

		protected float _randomPlaybackTime;

		protected float _randomPlaybackDuration;

		protected MMSoundManagerPlayOptions _options;

		protected AudioSource _playedAudioSource;

		protected AudioClip _lastPlayedClip;

		protected bool _initialized;

		protected AudioSource _editorAudioSource;

		protected float _lastPlayTimestamp = float.MinValue;

		protected virtual void Initialization()
		{
			_lastPlayedClip = null;
			if (RandomSfx == null)
			{
				RandomSfx = Array.Empty<AudioClip>();
			}
			if (RandomUnique)
			{
				_randomUniqueShuffleBag = new MMShufflebag<int>(RandomSfx.Length);
				for (int i = 0; i < RandomSfx.Length; i++)
				{
					_randomUniqueShuffleBag.Add(i, 1);
				}
			}
			_initialized = true;
		}

		public virtual void Play(Vector3 position)
		{
			if (!_initialized || (RandomUnique && _randomUniqueShuffleBag == null))
			{
				Initialization();
			}
			if (RandomSfx.Length != 0)
			{
				_randomClip = PickRandomClip();
				if (_randomClip != null)
				{
					PlaySound(_randomClip, position);
					return;
				}
			}
			if (Sfx != null)
			{
				PlaySound(Sfx, position);
			}
		}

		protected virtual AudioSource PlaySound(AudioClip sfx, Vector3 position)
		{
			if (DoNotPlayIfClipAlreadyPlaying && MMPersistentSingleton<MMSoundManager>.Instance.FindByClip(sfx) != null && MMPersistentSingleton<MMSoundManager>.Instance.FindByClip(sfx).isPlaying)
			{
				return null;
			}
			if (MaximumConcurrentInstances >= 0 && MMPersistentSingleton<MMSoundManager>.Instance.CurrentlyPlayingCount(sfx) >= MaximumConcurrentInstances)
			{
				return null;
			}
			_lastPlayedClip = null;
			float volume = UnityEngine.Random.Range(MinVolume, MaxVolume);
			float pitch = UnityEngine.Random.Range(MinPitch, MaxPitch);
			RandomizeTimes();
			_options.MmSoundManagerTrack = MmSoundManagerTrack;
			_options.Location = position;
			_options.Loop = Loop;
			_options.Volume = volume;
			_options.ID = ID;
			_options.Fade = FadeIn;
			_options.FadeInitialVolume = FadeInInitialVolume;
			_options.FadeDuration = FadeInDuration;
			_options.FadeTween = FadeInTween;
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
			_lastPlayedClip = sfx;
			return _playedAudioSource;
		}

		public virtual void RandomizeTimes()
		{
			_randomPlaybackTime = UnityEngine.Random.Range(PlaybackTime.x, PlaybackTime.y);
			_randomPlaybackDuration = UnityEngine.Random.Range(PlaybackDuration.x, PlaybackDuration.y);
		}

		protected virtual AudioClip PickRandomClip()
		{
			int num = 0;
			if (!SequentialOrder)
			{
				num = ((!RandomUnique) ? UnityEngine.Random.Range(0, RandomSfx.Length) : _randomUniqueShuffleBag.Pick());
			}
			else
			{
				num = _currentIndex;
				if (num >= RandomSfx.Length)
				{
					if (SequentialOrderHoldLast)
					{
						num--;
						if (SequentialOrderHoldCooldownDuration > 0f)
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

		public virtual async void TestPlaySound()
		{
			if (!_initialized || (RandomUnique && _randomUniqueShuffleBag == null))
			{
				Initialization();
			}
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
				Debug.LogError("This SoundData can't play in editor mode, you haven't set its Sfx.");
				return;
			}
			float volume = UnityEngine.Random.Range(MinVolume, MaxVolume);
			float num = UnityEngine.Random.Range(MinPitch, MaxPitch);
			RandomizeTimes();
			GameObject temporaryAudioHost = new GameObject("EditorTestAS_WillAutoDestroy");
			SceneManager.MoveGameObjectToScene(temporaryAudioHost.gameObject, SceneManager.GetActiveScene());
			temporaryAudioHost.transform.position = Vector3.zero;
			if (!Application.isPlaying)
			{
				temporaryAudioHost.AddComponent<MMForceDestroyInPlayMode>();
			}
			_editorAudioSource = temporaryAudioHost.AddComponent<AudioSource>();
			PlayAudioSource(_editorAudioSource, audioClip, volume, num, _randomPlaybackTime, _randomPlaybackDuration);
			_lastPlayTimestamp = Time.time;
			_lastPlayedClip = audioClip;
			float num2 = ((!(audioClip != null)) ? 10f : ((_randomPlaybackDuration > 0f) ? _randomPlaybackDuration : audioClip.length));
			num2 *= 1000f;
			num2 /= Mathf.Abs(num);
			await Task.Delay((int)num2);
			UnityEngine.Object.DestroyImmediate(temporaryAudioHost);
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
	}
}
