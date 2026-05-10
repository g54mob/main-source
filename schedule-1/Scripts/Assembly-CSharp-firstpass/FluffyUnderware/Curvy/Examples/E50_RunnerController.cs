using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FluffyUnderware.Curvy.Controllers;
using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Examples
{
	public class E50_RunnerController : SplineController
	{
		private enum GuideMode
		{
			Guided = 0,
			Jumping = 1,
			FreeFall = 2
		}

		[CompilerGenerated]
		private sealed class _003CJump_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public E50_RunnerController _003C_003E4__this;

			private float _003Cstart_003E5__2;

			private float _003Cf_003E5__3;

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
			public _003CJump_003Ed__13(int _003C_003E1__state)
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

		[Section("Jump", true, false, 100)]
		public float JumpHeight;

		public float JumpSpeed;

		public AnimationCurve JumpCurve;

		public float Gravity;

		private GuideMode mMode;

		private float jumpHeight;

		private float fallingSpeed;

		private E50_SplineRefMetadata mPossibleSwitchTarget;

		private int mSwitchInProgress;

		protected override void OnDisable()
		{
		}

		protected override void InitializedApplyDeltaTime(float deltaTime)
		{
		}

		private void Switch(int dir)
		{
		}

		[IteratorStateMachine(typeof(_003CJump_003Ed__13))]
		private IEnumerator Jump()
		{
			return null;
		}

		public void OnCPReached(CurvySplineMoveEventArgs e)
		{
		}

		public void UseFollowUpOrFall(CurvySplineMoveEventArgs e)
		{
		}
	}
}
