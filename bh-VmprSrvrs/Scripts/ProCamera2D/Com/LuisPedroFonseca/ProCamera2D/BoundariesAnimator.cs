using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	public class BoundariesAnimator
	{
		[CompilerGenerated]
		private sealed class _003CBottomTransitionRoutine_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BoundariesAnimator _003C_003E4__this;

			public float duration;

			public bool turnOffBoundaryAfterwards;

			private float _003CinitialBottomBoundary_003E5__2;

			private float _003Ct_003E5__3;

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
			public _003CBottomTransitionRoutine_003Ed__22(int _003C_003E1__state)
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
		private sealed class _003CLeftTransitionRoutine_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BoundariesAnimator _003C_003E4__this;

			public float duration;

			public bool turnOffBoundaryAfterwards;

			private float _003CinitialLeftBoundary_003E5__2;

			private float _003Ct_003E5__3;

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
			public _003CLeftTransitionRoutine_003Ed__19(int _003C_003E1__state)
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
		private sealed class _003CRightTransitionRoutine_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BoundariesAnimator _003C_003E4__this;

			public float duration;

			public bool turnOffBoundaryAfterwards;

			private float _003CinitialRightBoundary_003E5__2;

			private float _003Ct_003E5__3;

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
			public _003CRightTransitionRoutine_003Ed__20(int _003C_003E1__state)
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
		private sealed class _003CTopTransitionRoutine_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BoundariesAnimator _003C_003E4__this;

			public float duration;

			public bool turnOffBoundaryAfterwards;

			private float _003CinitialTopBoundary_003E5__2;

			private float _003Ct_003E5__3;

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
			public _003CTopTransitionRoutine_003Ed__21(int _003C_003E1__state)
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

		public Action OnTransitionStarted;

		public Action OnTransitionFinished;

		public bool UseTopBoundary;

		public float TopBoundary;

		public bool UseBottomBoundary;

		public float BottomBoundary;

		public bool UseLeftBoundary;

		public float LeftBoundary;

		public bool UseRightBoundary;

		public float RightBoundary;

		public float TransitionDuration;

		public EaseType TransitionEaseType;

		private ProCamera2D ProCamera2D;

		private ProCamera2DNumericBoundaries NumericBoundaries;

		private Func<Vector3, float> Vector3H;

		private Func<Vector3, float> Vector3V;

		public BoundariesAnimator(ProCamera2D proCamera2D, ProCamera2DNumericBoundaries numericBoundaries)
		{
		}

		public int GetAnimsCount()
		{
			return 0;
		}

		public void Transition()
		{
		}

		[IteratorStateMachine(typeof(_003CLeftTransitionRoutine_003Ed__19))]
		private IEnumerator LeftTransitionRoutine(float duration, bool turnOffBoundaryAfterwards = false)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CRightTransitionRoutine_003Ed__20))]
		private IEnumerator RightTransitionRoutine(float duration, bool turnOffBoundaryAfterwards = false)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CTopTransitionRoutine_003Ed__21))]
		private IEnumerator TopTransitionRoutine(float duration, bool turnOffBoundaryAfterwards = false)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CBottomTransitionRoutine_003Ed__22))]
		private IEnumerator BottomTransitionRoutine(float duration, bool turnOffBoundaryAfterwards = false)
		{
			return null;
		}
	}
}
