using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Audio;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("Audio/Sound")]
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback lets you play the specified AudioClip, either via event (you'll need something in your scene to catch a MMSfxEvent, for example a MMSoundManager), or cached (AudioSource gets created on init, and is then ready to be played), or on demand (instantiated on Play). For all these methods you can define a random volume between min/max boundaries (just set the same value in both fields if you don't want randomness), random pitch, and an optional AudioMixerGroup.")]
	[ExecuteAlways]
	public class MMF_Sound : MMF_Feedback
	{
		public enum PlayMethods
		{
			Event = 0,
			Cached = 1,
			OnDemand = 2,
			Pool = 3
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CTestPlaySound_003Ed__50 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public MMF_Sound _003C_003E4__this;

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

		[Tooltip("an array to pick a random sfx from")]
		public AudioClip[] RandomSfx;

		public MMF_Button TestPlayButton;

		public MMF_Button TestStopButton;

		[MMFInspectorGroup("Play Method", true, 27, false, false)]
		[Tooltip("the play method to use when playing the sound (event, cached or on demand)")]
		public PlayMethods PlayMethod;

		[Tooltip("the size of the pool when in Pool mode")]
		[MMFEnumCondition("PlayMethod", new int[] { 3 })]
		public int PoolSize;

		[Tooltip("if this is true, calling Stop on this feedback will also stop the sound from playing further")]
		public bool StopSoundOnFeedbackStop;

		[Range(0f, 2f)]
		[MMFInspectorGroup("Sound Properties", true, 28, false, false)]
		[Header("Volume")]
		[Tooltip("the minimum volume to play the sound at")]
		public float MinVolume;

		[Range(0f, 2f)]
		[Tooltip("the maximum volume to play the sound at")]
		public float MaxVolume;

		[Range(-3f, 3f)]
		[Tooltip("the minimum pitch to play the sound at")]
		[Header("Pitch")]
		public float MinPitch;

		[Range(-3f, 3f)]
		[Tooltip("the maximum pitch to play the sound at")]
		public float MaxPitch;

		[Tooltip("the audiomixer to play the sound with (optional)")]
		[Header("Mixer")]
		public AudioMixerGroup SfxAudioMixerGroup;

		[Tooltip("the audiosource priority, to be specified if needed between 0 (highest) and 256")]
		public int Priority;

		[Range(-1f, 1f)]
		[Tooltip("Pans a playing sound in a stereo way (left or right). This only applies to sounds that are Mono or Stereo.")]
		[MMFInspectorGroup("Spatial Settings", true, 33, false, true)]
		public float PanStereo;

		[Tooltip("Sets how much this AudioSource is affected by 3D spatialisation calculations (attenuation, doppler etc). 0.0 makes the sound full 2D, 1.0 makes it full 3D.")]
		[Range(0f, 1f)]
		public float SpatialBlend;

		[Tooltip("Sets the Doppler scale for this AudioSource.")]
		[MMFInspectorGroup("3D Sound Settings", true, 37, false, true)]
		[Range(0f, 5f)]
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

		[Tooltip("the curve to use for custom volume rolloff if UseCustomRolloffCurve is true")]
		[MMFCondition("UseCustomRolloffCurve", true)]
		public AnimationCurve CustomRolloffCurve;

		[Tooltip("whether or not to use a custom curve for spatial blend")]
		public bool UseSpatialBlendCurve;

		[MMFCondition("UseSpatialBlendCurve", true)]
		[Tooltip("the curve to use for custom spatial blend if UseSpatialBlendCurve is true")]
		public AnimationCurve SpatialBlendCurve;

		[Tooltip("whether or not to use a custom curve for reverb zone mix")]
		public bool UseReverbZoneMixCurve;

		[MMFCondition("UseReverbZoneMixCurve", true)]
		[Tooltip("the curve to use for custom reverb zone mix if UseReverbZoneMixCurve is true")]
		public AnimationCurve ReverbZoneMixCurve;

		[Tooltip("whether or not to use a custom curve for spread")]
		public bool UseSpreadCurve;

		[MMFCondition("UseSpreadCurve", true)]
		[Tooltip("the curve to use for custom spread if UseSpreadCurve is true")]
		public AnimationCurve SpreadCurve;

		protected AudioClip _randomClip;

		protected AudioSource _cachedAudioSource;

		protected AudioSource[] _pool;

		protected AudioSource _tempAudioSource;

		protected float _duration;

		protected AudioSource _editorAudioSource;

		protected AudioSource _audioSource;

		public override bool HasRandomness => false;

		public override float FeedbackDuration => 0f;

		public override void InitializeCustomAttributes()
		{
		}

		protected override void CustomInitialization(MMF_Player owner)
		{
		}

		protected virtual AudioSource CreateAudioSource(GameObject owner, string audioSourceName)
		{
			return null;
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected virtual float GetDuration()
		{
			return 0f;
		}

		protected virtual void PlaySound(AudioClip sfx, Vector3 position, float intensity)
		{
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected virtual void PlayAudioSource(AudioSource audioSource, AudioClip sfx, float volume, float pitch, int timeSamples, AudioMixerGroup audioMixerGroup = null, int priority = 128)
		{
		}

		protected virtual AudioSource GetAudioSourceFromPool()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CTestPlaySound_003Ed__50))]
		protected virtual void TestPlaySound()
		{
		}

		protected virtual void TestStopSound()
		{
		}
	}
}
