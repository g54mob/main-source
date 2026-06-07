using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[HelpURL("http://www.procamera2d.com/user-guide/trigger-boundaries/")]
	public class ProCamera2DTriggerBoundaries : BaseTrigger, IPositionOverrider
	{
		[CompilerGenerated]
		private sealed class _003CMoveCameraToTarget_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ProCamera2DTriggerBoundaries _003C_003E4__this;

			private float _003CinitialCamPosH_003E5__2;

			private float _003CinitialCamPosV_003E5__3;

			private float _003Ct_003E5__4;

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
			public _003CMoveCameraToTarget_003Ed__43(int _003C_003E1__state)
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
		private sealed class _003CTransition_003Ed__42 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ProCamera2DTriggerBoundaries _003C_003E4__this;

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
			public _003CTransition_003Ed__42(int _003C_003E1__state)
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
		private sealed class _003CTurnOffPreviousTrigger_003Ed__39 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ProCamera2DTriggerBoundaries trigger;

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
			public _003CTurnOffPreviousTrigger_003Ed__39(int _003C_003E1__state)
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

		public static string TriggerName;

		public ProCamera2DNumericBoundaries NumericBoundaries;

		public bool AreBoundariesRelative;

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

		public bool ChangeZoom;

		public float TargetZoom;

		public float ZoomSmoothness;

		public bool _setAsStartingBoundaries;

		private float _initialCamSize;

		private BoundariesAnimator _boundsAnim;

		private float _targetTopBoundary;

		private float _targetBottomBoundary;

		private float _targetLeftBoundary;

		private float _targetRightBoundary;

		private bool _transitioning;

		private Vector3 _newPos;

		private int _poOrder;

		public bool IsCurrentTrigger => false;

		public bool SetAsStartingBoundaries
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int POOrder
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void Start()
		{
		}

		public Vector3 OverridePosition(float deltaTime, Vector3 originalPosition)
		{
			return default(Vector3);
		}

		protected override void EnteredTrigger()
		{
		}

		[IteratorStateMachine(typeof(_003CTurnOffPreviousTrigger_003Ed__39))]
		private IEnumerator TurnOffPreviousTrigger(ProCamera2DTriggerBoundaries trigger)
		{
			return null;
		}

		public void SetBoundaries()
		{
		}

		private void GetTargetBoundaries()
		{
		}

		[IteratorStateMachine(typeof(_003CTransition_003Ed__42))]
		private IEnumerator Transition()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CMoveCameraToTarget_003Ed__43))]
		private IEnumerator MoveCameraToTarget()
		{
			return null;
		}

		private void LimitToNumericBoundaries(ref float horizontalPos, ref float verticalPos)
		{
		}
	}
}
