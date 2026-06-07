using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.Audio
{
	public class StartLoopStopAudio : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CStartAudioRoutine_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public StartLoopStopAudio _003C_003E4__this;

			private float _003Ctimer_003E5__2;

			private float _003Cduration_003E5__3;

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
			public _003CStartAudioRoutine_003Ed__10(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CStopAudioRoutine_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public StartLoopStopAudio _003C_003E4__this;

			private float _003Ctimer_003E5__2;

			private float _003Cduration_003E5__3;

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
			public _003CStopAudioRoutine_003Ed__11(int _003C_003E1__state)
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

		[FormerlySerializedAs("FadeLoopIn")]
		[SerializeField]
		private bool _fadeLoopIn;

		[FormerlySerializedAs("FadeLoopOut")]
		[SerializeField]
		private bool _fadeLoopOut;

		[FormerlySerializedAs("StartSound")]
		[SerializeField]
		private AudioSourceController _startSound;

		[FormerlySerializedAs("LoopSound")]
		[SerializeField]
		private AudioSourceController _loopSound;

		[FormerlySerializedAs("StopSound")]
		[SerializeField]
		private AudioSourceController _stopSound;

		private Coroutine _audioRoutine;

		private bool _isRunning;

		private void Awake()
		{
		}

		public void StartAudio()
		{
		}

		public void StopAudio()
		{
		}

		[IteratorStateMachine(typeof(_003CStartAudioRoutine_003Ed__10))]
		private IEnumerator StartAudioRoutine()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CStopAudioRoutine_003Ed__11))]
		private IEnumerator StopAudioRoutine()
		{
			return null;
		}

		private void TryStartAudio()
		{
		}

		private void TryStopAudio()
		{
		}
	}
}
