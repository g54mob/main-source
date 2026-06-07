using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Audio;

namespace MoreMountains.Feedbacks
{
	[ExecuteAlways]
	[AddComponentMenu(null)]
	[FeedbackPath("Audio/MMSoundManager Sound")]
	[FeedbackHelp("This feedback will let you play a sound via the MMSoundManager. You will need a game object in your scene with a MMSoundManager object on it for this to work.")]
	public class MMFeedbackMMSoundManagerSound : MMFeedback
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CTestPlaySound_003Ed__47 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public MMFeedbackMMSoundManagerSound _003C_003E4__this;

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

		[Header("Sound")]
		[Tooltip("the sound clip to play")]
		public AudioClip Sfx;

		[Tooltip("an array to pick a random sfx from")]
		[Header("Random Sound")]
		public AudioClip[] RandomSfx;

		[MMFInspectorButton("TestPlaySound")]
		[Header("Test")]
		public bool TestButton;

		[MMFInspectorButton("TestStopSound")]
		public bool TestStopButton;

		[Header("Volume")]
		[Range(0f, 2f)]
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

		[Tooltip("the track on which to play the sound. Pick the one that matches the nature of your sound")]
		[Header("SoundManager Options")]
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

		[Tooltip("if this is true, this sound won't be recycled if it's not done playing")]
		public bool DoNotAutoRecycleIfNotDonePlaying;

		[Header("Fade")]
		[Tooltip("whether or not to fade this sound in when playing it")]
		public bool Fade;

		[MMCondition("Fade", true)]
		[Tooltip("if fading, the volume at which to start the fade")]
		public float FadeInitialVolume;

		[MMCondition("Fade", true)]
		[Tooltip("if fading, the duration of the fade, in seconds")]
		public float FadeDuration;

		[MMCondition("Fade", true)]
		[Tooltip("if fading, the tween over which to fade the sound ")]
		public MMTweenType FadeTween;

		[Header("Solo")]
		[Tooltip("whether or not this sound should play in solo mode over its destination track. If yes, all other sounds on that track will be muted when this sound starts playing")]
		public bool SoloSingleTrack;

		[Tooltip("whether or not this sound should play in solo mode over all other tracks. If yes, all other tracks will be muted when this sound starts playing")]
		public bool SoloAllTracks;

		[Tooltip("if in any of the above solo modes, AutoUnSoloOnEnd will unmute the track(s) automatically once that sound stops playing")]
		public bool AutoUnSoloOnEnd;

		[Tooltip("Pans a playing sound in a stereo way (left or right). This only applies to sounds that are Mono or Stereo.")]
		[Range(-1f, 1f)]
		[Header("Spatial Settings")]
		public float PanStereo;

		[Tooltip("Sets how much this AudioSource is affected by 3D spatialisation calculations (attenuation, doppler etc). 0.0 makes the sound full 2D, 1.0 makes it full 3D.")]
		[Range(0f, 1f)]
		public float SpatialBlend;

		[Tooltip("Bypass effects (Applied from filter components or global listener filters).")]
		[Header("Effects")]
		public bool BypassEffects;

		[Tooltip("When set global effects on the AudioListener will not be applied to the audio signal generated by the AudioSource. Does not apply if the AudioSource is playing into a mixer group.")]
		public bool BypassListenerEffects;

		[Tooltip("When set doesn't route the signal from an AudioSource into the global reverb associated with reverb zones.")]
		public bool BypassReverbZones;

		[Range(0f, 256f)]
		[Tooltip("Sets the priority of the AudioSource.")]
		public int Priority;

		[Range(0f, 1.1f)]
		[Tooltip("The amount by which the signal from the AudioSource will be mixed into the global reverb associated with the Reverb Zones.")]
		public float ReverbZoneMix;

		[Header("3D Sound Settings")]
		[Range(0f, 5f)]
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

		protected AudioClip _randomClip;

		protected AudioSource _editorAudioSource;

		protected MMSoundManagerPlayOptions _options;

		protected AudioSource _playedAudioSource;

		public override float FeedbackDuration => 0f;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected virtual void PlaySound(AudioClip sfx, Vector3 position, float intensity)
		{
		}

		protected virtual float GetDuration()
		{
			return 0f;
		}

		[AsyncStateMachine(typeof(_003CTestPlaySound_003Ed__47))]
		protected virtual void TestPlaySound()
		{
		}

		protected virtual void TestStopSound()
		{
		}

		protected virtual void PlayAudioSource(AudioSource audioSource, AudioClip sfx, float volume, float pitch, int timeSamples)
		{
		}
	}
}
