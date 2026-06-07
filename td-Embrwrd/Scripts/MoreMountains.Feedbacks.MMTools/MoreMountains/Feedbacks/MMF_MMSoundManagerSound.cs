using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Audio;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu(null)]
	[FeedbackPath("Audio/MMSoundManager Sound")]
	[FeedbackHelp("This feedback will let you play a sound via the MMSoundManager. You will need a game object in your scene with a MMSoundManager object on it for this to work.")]
	[ExecuteAlways]
	public class MMF_MMSoundManagerSound : MMF_Feedback
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CTestPlaySound_003Ed__80 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public MMF_MMSoundManagerSound _003C_003E4__this;

			private GameObject _003CtemporaryAudioHost_003E5__2;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		public static bool FeedbackTypeAuthorized;

		[MMFInspectorGroup("Sound", true, 14, true, false)]
		[Tooltip("the sound clip to play")]
		public AudioClip Sfx;

		[MMFInspectorGroup("Random Sound", true, 34, true, false)]
		[Tooltip("an array to pick a random sfx from")]
		public AudioClip[] RandomSfx;

		[Tooltip("if this is true, random sfx audio clips will be played in sequential order instead of at random")]
		public bool SequentialOrder;

		[MMFCondition("SequentialOrder", true)]
		[Tooltip("if we're in sequential order, determines whether or not to hold at the last index, until either a cooldown is met, or the ResetSequentialIndex method is called")]
		public bool SequentialOrderHoldLast;

		[Tooltip("if we're in sequential order hold last mode, index will reset to 0 automatically after this duration, unless it's 0, in which case it'll be ignored")]
		[MMFCondition("SequentialOrderHoldLast", true)]
		public float SequentialOrderHoldCooldownDuration;

		[Tooltip("if this is true, sfx will be picked at random until all have been played. once this happens, the list is shuffled again, and it starts over")]
		public bool RandomUnique;

		[Tooltip("a scriptable object (created via the Create/MoreMountains/Audio/MMF_SoundData menu) to define settings that will override all other settings on this feedback")]
		[MMFInspectorGroup("Scriptable Object", true, 14, true, false)]
		public MMF_MMSoundManagerSoundData SoundDataSO;

		[Tooltip("the minimum volume to play the sound at")]
		[MMFInspectorGroup("Sound Properties", true, 24, false, false)]
		[Range(0f, 2f)]
		[Header("Volume")]
		public float MinVolume;

		[Range(0f, 2f)]
		[Tooltip("the maximum volume to play the sound at")]
		public float MaxVolume;

		[Range(-3f, 3f)]
		[Header("Pitch")]
		[Tooltip("the minimum pitch to play the sound at")]
		public float MinPitch;

		[Tooltip("the maximum pitch to play the sound at")]
		[Range(-3f, 3f)]
		public float MaxPitch;

		[Tooltip("the track on which to play the sound. Pick the one that matches the nature of your sound")]
		[MMFInspectorGroup("SoundManager Options", true, 28, false, false)]
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

		[Tooltip("whether or not to fade this sound in when playing it")]
		[MMFInspectorGroup("Fade", true, 30, false, false)]
		public bool Fade;

		[MMCondition("Fade", true)]
		[Tooltip("if fading, the volume at which to start the fade")]
		public float FadeInitialVolume;

		[MMCondition("Fade", true)]
		[Tooltip("if fading, the duration of the fade, in seconds")]
		public float FadeDuration;

		[Tooltip("if fading, the tween over which to fade the sound ")]
		[MMCondition("Fade", true)]
		public MMTweenType FadeTween;

		[Tooltip("whether or not this sound should play in solo mode over its destination track. If yes, all other sounds on that track will be muted when this sound starts playing")]
		[MMFInspectorGroup("Solo", true, 32, false, false)]
		public bool SoloSingleTrack;

		[Tooltip("whether or not this sound should play in solo mode over all other tracks. If yes, all other tracks will be muted when this sound starts playing")]
		public bool SoloAllTracks;

		[Tooltip("if in any of the above solo modes, AutoUnSoloOnEnd will unmute the track(s) automatically once that sound stops playing")]
		public bool AutoUnSoloOnEnd;

		[Range(-1f, 1f)]
		[MMFInspectorGroup("Spatial Settings", true, 33, false, false)]
		[Tooltip("Pans a playing sound in a stereo way (left or right). This only applies to sounds that are Mono or Stereo.")]
		public float PanStereo;

		[Range(0f, 1f)]
		[Tooltip("Sets how much this AudioSource is affected by 3D spatialisation calculations (attenuation, doppler etc). 0.0 makes the sound full 2D, 1.0 makes it full 3D.")]
		public float SpatialBlend;

		[Tooltip("a Transform this sound can 'attach' to and follow it along as it plays")]
		public Transform AttachToTransform;

		[Tooltip("Bypass effects (Applied from filter components or global listener filters).")]
		[MMFInspectorGroup("Effects", true, 36, false, false)]
		public bool BypassEffects;

		[Tooltip("When set global effects on the AudioListener will not be applied to the audio signal generated by the AudioSource. Does not apply if the AudioSource is playing into a mixer group.")]
		public bool BypassListenerEffects;

		[Tooltip("When set doesn't route the signal from an AudioSource into the global reverb associated with reverb zones.")]
		public bool BypassReverbZones;

		[Range(0f, 256f)]
		[Tooltip("Sets the priority of the AudioSource.")]
		public int Priority;

		[Tooltip("The amount by which the signal from the AudioSource will be mixed into the global reverb associated with the Reverb Zones.")]
		[Range(0f, 1.1f)]
		public float ReverbZoneMix;

		[MMVector(new string[] { "Min", "Max" })]
		[Tooltip("a timestamp (in seconds, randomized between the defined min and max) at which the sound will start playing, equivalent to the Audiosource API's Time)")]
		[MMFInspectorGroup("Time Options", true, 15, false, false)]
		public Vector2 PlaybackTime;

		[MMVector(new string[] { "Min", "Max" })]
		[Tooltip("a duration (in seconds, randomized between the defined min and max) for which the sound will play before stopping. Ignored if min and max are zero.")]
		public Vector2 PlaybackDuration;

		[Range(0f, 5f)]
		[MMFInspectorGroup("3D Sound Settings", true, 37, false, false)]
		[Tooltip("Sets the Doppler scale for this AudioSource.")]
		public float DopplerLevel;

		[Tooltip("Sets the spread angle (in degrees) of a 3d stereo or multichannel sound in speaker space.")]
		[Range(0f, 360f)]
		public int Spread;

		[Tooltip("Sets/Gets how the AudioSource attenuates over distance.")]
		public AudioRolloffMode RolloffMode;

		[Tooltip("Within the Min distance the AudioSource will cease to grow louder in volume.")]
		public float MinDistance;

		[Tooltip("(Logarithmic rolloff) MaxDistance is the distance a sound stops attenuating at.")]
		public float MaxDistance;

		[Tooltip("whether or not to use a custom curve for custom volume rolloff")]
		public bool UseCustomRolloffCurve;

		[MMFCondition("UseCustomRolloffCurve", true)]
		[Tooltip("the curve to use for custom volume rolloff if UseCustomRolloffCurve is true")]
		public AnimationCurve CustomRolloffCurve;

		[Tooltip("whether or not to use a custom curve for spatial blend")]
		public bool UseSpatialBlendCurve;

		[MMFCondition("UseSpatialBlendCurve", true)]
		[Tooltip("the curve to use for custom spatial blend if UseSpatialBlendCurve is true")]
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

		[Tooltip("whether or not to draw sound falloff gizmos when this MMF Player is selected")]
		[MMFInspectorGroup("Debug", true, 31, false, false)]
		public bool DrawGizmos;

		[MMFCondition("DrawGizmos", true)]
		[Tooltip("an object to use as the center of the gizmos. If left empty, this MMF Player's position will be used.")]
		public Transform GizmosCenter;

		[Tooltip("the color to use to draw the min distance sphere of the sound falloff gizmos")]
		[MMFCondition("DrawGizmos", true)]
		public Color MinDistanceColor;

		[MMFCondition("DrawGizmos", true)]
		[Tooltip("the color to use to draw the max distance sphere of the sound falloff gizmos")]
		public Color MaxDistanceColor;

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

		public override float FeedbackDuration => 0f;

		public override bool HasRandomness => false;

		protected override void CustomInitialization(MMF_Player owner)
		{
		}

		public override void InitializeCustomAttributes()
		{
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected virtual void HandleSO()
		{
		}

		public virtual void RandomizeTimes()
		{
		}

		protected virtual void PlaySound(AudioClip sfx, Vector3 position, float intensity)
		{
		}

		protected virtual float GetDuration()
		{
			return 0f;
		}

		protected virtual float ComputeDuration(AudioClip sfx, AudioClip[] randomSfx)
		{
			return 0f;
		}

		public override void OnDrawGizmosSelectedHandler()
		{
		}

		[AsyncStateMachine(typeof(_003CTestPlaySound_003Ed__80))]
		protected virtual void TestPlaySound()
		{
		}

		protected virtual void TestStopSound()
		{
		}

		protected virtual void PlayAudioSource(AudioSource audioSource, AudioClip sfx, float volume, float pitch, float time, float playbackDuration)
		{
		}

		protected virtual AudioClip PickRandomClip()
		{
			return null;
		}

		public virtual void ResetSequentialIndex()
		{
		}

		public virtual void SetSequentialIndex(int newIndex)
		{
		}

		public override void OnValidate()
		{
		}
	}
}
