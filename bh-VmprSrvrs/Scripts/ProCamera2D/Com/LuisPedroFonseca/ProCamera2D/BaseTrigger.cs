using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	public abstract class BaseTrigger : BasePC2D
	{
		[CompilerGenerated]
		private sealed class _003CTestTriggerRoutine_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BaseTrigger _003C_003E4__this;

			private WaitForSeconds _003CwaitForSeconds_003E5__2;

			private WaitForSecondsRealtime _003CwaitForSecondsRealtime_003E5__3;

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
			public _003CTestTriggerRoutine_003Ed__19(int _003C_003E1__state)
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

		public Action OnEnteredTrigger;

		public Action OnExitedTrigger;

		[Tooltip("Every X seconds detect collision. Smaller intervals are more precise but also require more processing.")]
		public float UpdateInterval;

		public TriggerShape TriggerShape;

		[Tooltip("If enabled, use the targets mid point to know when inside/outside the trigger.")]
		public bool UseTargetsMidPoint;

		[Tooltip("If UseTargetsMidPoint is disabled, use this transform to know when inside/outside the trigger.")]
		public Transform TriggerTarget;

		protected float _exclusiveInfluencePercentage;

		private Coroutine _testTriggerRoutine;

		protected bool _insideTrigger;

		protected Vector2 _vectorFromPointToCenter;

		protected int _instanceID;

		private bool _triggerEnabled;

		protected override void Awake()
		{
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		public void Toggle(bool value)
		{
		}

		public void TestTrigger()
		{
		}

		protected virtual void EnteredTrigger()
		{
		}

		protected virtual void ExitedTrigger()
		{
		}

		[IteratorStateMachine(typeof(_003CTestTriggerRoutine_003Ed__19))]
		private IEnumerator TestTriggerRoutine()
		{
			return null;
		}

		protected float GetDistanceToCenterPercentage(Vector2 point)
		{
			return 0f;
		}
	}
}
