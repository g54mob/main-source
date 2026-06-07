using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ScheduleOne.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.Audio
{
	[RequireComponent(typeof(AudioSource))]
	public class AudioSourceController : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CDelayIE_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

			public Action callback;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CDelayIE_003Ed__43(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[Header("Settings")]
		[SerializeField]
		private string _id;

		[SerializeField]
		[FormerlySerializedAs("AudioType")]
		private EAudioType _audioType;

		[FormerlySerializedAs("DefaultVolume")]
		[SerializeField]
		[Header("Volume")]
		[Range(0f, 1f)]
		private float _defaultBaseVolume;

		[Range(0f, 2f)]
		[SerializeField]
		[FormerlySerializedAs("VolumeMultiplier")]
		private float _volumeMultiplier;

		[Range(0.1f, 3f)]
		[Header("Pitch")]
		[SerializeField]
		private float _defaultBasePitch;

		[Range(0f, 2f)]
		[FormerlySerializedAs("PitchMultiplier")]
		[SerializeField]
		private float _pitchMultiplier;

		[SerializeField]
		[FormerlySerializedAs("RandomizePitch")]
		private bool _randomizePitch;

		[SerializeField]
		[ScheduleOne.Core.Conditional("_randomizePitch", false)]
		[FormerlySerializedAs("MinPitch")]
		private float _minRandomPitch;

		[SerializeField]
		[FormerlySerializedAs("MaxPitch")]
		[ScheduleOne.Core.Conditional("_randomizePitch", false)]
		private float _maxRandomPitch;

		[ScheduleOne.Core.Conditional("_lowPassFilter", false)]
		[SerializeField]
		[FormerlySerializedAs("LowPassFilter")]
		private AudioLowPassFilter _lowPassFilter;

		protected AudioSource _audioSource;

		protected float _baseVolume;

		protected float _basePitch;

		public bool IsPlaying => false;

		public float Time => 0f;

		public AudioClip Clip => null;

		public string Id => null;

		public float VolumeMultiplier
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float PitchMultiplier
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void ApplyMixer()
		{
		}

		private void OnPause()
		{
		}

		private void OnUnpause()
		{
		}

		public void SetBaseVolume(float baseVolume)
		{
		}

		protected void ApplyVolume()
		{
		}

		public void SetBasePitch(float basePitch)
		{
		}

		private void ApplyPitch()
		{
		}

		public virtual void Play()
		{
		}

		public virtual void PlayOneShot()
		{
		}

		public void PlayOneShotDelayed(float delay)
		{
		}

		public void DuplicateAndPlayOneShot()
		{
		}

		public virtual void DuplicateAndPlayOneShot(Transform parent)
		{
		}

		protected void Delay(float delay, Action callback)
		{
		}

		[IteratorStateMachine(typeof(_003CDelayIE_003Ed__43))]
		protected IEnumerator DelayIE(float delay, Action callback)
		{
			return null;
		}

		public void ApplyAudioSettings(AudioSettingsWrapper settings)
		{
		}

		public AudioSettingsWrapper ExtractAudioSettings()
		{
			return null;
		}

		public void SetTime(float time)
		{
		}

		public void SetClip(AudioClip clip)
		{
		}

		public void SetLoop(bool loop)
		{
		}

		public void Stop()
		{
		}
	}
}
