using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Audio;

namespace MoreMountains.Feedbacks
{
	[ExecuteAlways]
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback lets you play the specified AudioClip, either via event (you'll need something in your scene to catch a MMSfxEvent, for example a MMSoundManager), or cached (AudioSource gets created on init, and is then ready to be played), or on demand (instantiated on Play). For all these methods you can define a random volume between min/max boundaries (just set the same value in both fields if you don't want randomness), random pitch, and an optional AudioMixerGroup.")]
	[FeedbackPath("Audio/Sound")]
	public class MMFeedbackSound : MMFeedback
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
		private struct _003CTestPlaySound_003Ed__29 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public MMFeedbackSound _003C_003E4__this;

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

		[Header("Random Sound")]
		[Tooltip("an array to pick a random sfx from")]
		public AudioClip[] RandomSfx;

		[MMFInspectorButton("TestPlaySound")]
		[Header("Test")]
		public bool TestButton;

		[MMFInspectorButton("TestStopSound")]
		public bool TestStopButton;

		[Header("Method")]
		[Tooltip("the play method to use when playing the sound (event, cached or on demand)")]
		public PlayMethods PlayMethod;

		[Tooltip("the size of the pool when in Pool mode")]
		[MMFEnumCondition("PlayMethod", new int[] { 3 })]
		public int PoolSize;

		[Header("Volume")]
		[Tooltip("the minimum volume to play the sound at")]
		public float MinVolume;

		[Tooltip("the maximum volume to play the sound at")]
		public float MaxVolume;

		[Header("Pitch")]
		[Tooltip("the minimum pitch to play the sound at")]
		public float MinPitch;

		[Tooltip("the maximum pitch to play the sound at")]
		public float MaxPitch;

		[Header("Mixer")]
		[Tooltip("the audiomixer to play the sound with (optional)")]
		public AudioMixerGroup SfxAudioMixerGroup;

		[Tooltip("the audiosource priority, to be specified if needed between 0 (highest) and 256")]
		public int Priority;

		protected AudioClip _randomClip;

		protected AudioSource _cachedAudioSource;

		protected AudioSource[] _pool;

		protected AudioSource _tempAudioSource;

		protected float _duration;

		protected AudioSource _editorAudioSource;

		public override float FeedbackDuration => 0f;

		protected override void CustomInitialization(GameObject owner)
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

		protected virtual void PlayAudioSource(AudioSource audioSource, AudioClip sfx, float volume, float pitch, int timeSamples, AudioMixerGroup audioMixerGroup = null, int priority = 128)
		{
		}

		protected virtual AudioSource GetAudioSourceFromPool()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CTestPlaySound_003Ed__29))]
		protected virtual void TestPlaySound()
		{
		}

		protected virtual void TestStopSound()
		{
		}
	}
}
