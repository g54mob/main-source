using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using Dreamteck.Splines;
using UnityEngine;

namespace VampireSurvivors
{
	public class UISplineFollower : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CBeginPlaying_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float initialDelay;

			public UISplineFollower _003C_003E4__this;

			public float duration;

			public bool shouldLoop;

			public int loopCount;

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
			public _003CBeginPlaying_003Ed__16(int _003C_003E1__state)
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
		private sealed class _003CWaitAndMove_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UISplineFollower _003C_003E4__this;

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
			public _003CWaitAndMove_003Ed__20(int _003C_003E1__state)
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

		[SerializeField]
		private SplineComputer Spline;

		[SerializeField]
		private float Duration;

		[SerializeField]
		private float InitialDelay;

		[SerializeField]
		private bool ShouldLoop;

		[SerializeField]
		private int LoopCount;

		[SerializeField]
		private float LoopInterval;

		[SerializeField]
		private bool PlayOnAwake;

		private Tween _toTween;

		private Tween _fromTween;

		private TrailRenderer _trail;

		private Sequence _sequence;

		private void OnEnable()
		{
		}

		public void Play()
		{
		}

		public void Complete()
		{
		}

		public void Play(float duration, float initialDelay = 0f, bool shouldLoop = false, int loopCount = 1, Ease ease = Ease.Linear)
		{
		}

		public SplineComputer GetCurve()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CBeginPlaying_003Ed__16))]
		private IEnumerator BeginPlaying(float duration, float initialDelay = 0f, bool shouldLoop = false, int loopCount = 1, Ease ease = Ease.Linear)
		{
			return null;
		}

		private void DoAnimation(float duration, bool shouldLoop = false, int loopCount = 1, Ease ease = Ease.Linear)
		{
		}

		private void OnDestroy()
		{
		}

		public void SetSpline(SplineComputer spline)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndMove_003Ed__20))]
		private IEnumerator WaitAndMove()
		{
			return null;
		}
	}
}
