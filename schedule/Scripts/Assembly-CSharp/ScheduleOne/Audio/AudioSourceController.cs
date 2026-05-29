using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ScheduleOne.Audio
{
	[RequireComponent(typeof(AudioSource))]
	public class AudioSourceController : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CStart_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AudioSourceController _003C_003E4__this;

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
			public _003CStart_003Ed__23(int _003C_003E1__state)
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

		public bool DEBUG;

		public AudioSource AudioSource;

		[Header("Settings")]
		public EAudioType AudioType;

		[Range(0f, 1f)]
		public float DefaultVolume;

		public bool RandomizePitch;

		public float MinPitch;

		public float MaxPitch;

		[SerializeField]
		[Range(0f, 2f)]
		private float VolumeMultiplier;

		[SerializeField]
		[Range(0f, 2f)]
		private float PitchMultiplier;

		private float basePitch;

		public float Volume { get; protected set; }

		public bool isPlaying => false;

		public float volumeMultiplier
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float pitchMultiplier
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

		[IteratorStateMachine(typeof(_003CStart_003Ed__23))]
		private IEnumerator Start()
		{
			return null;
		}

		private void OnDestroy()
		{
		}

		private void OnValidate()
		{
		}

		private void Pause()
		{
		}

		private void Unpause()
		{
		}

		public void SetVolume(float volume)
		{
		}

		public void ApplyVolume()
		{
		}

		public void ApplyPitch()
		{
		}

		public virtual void Play()
		{
		}

		public virtual void PlayOneShot()
		{
		}

		public void DuplicateAndPlayOneShot()
		{
		}

		public virtual void DuplicateAndPlayOneShot(Transform parent)
		{
		}

		public void Stop()
		{
		}
	}
}
