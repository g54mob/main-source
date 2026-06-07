using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Doozy.Engine.UI.Base;
using UnityEngine;

namespace Doozy.Engine.Progress
{
	[AddComponentMenu("Doozy/Progress/Targets/Progress Target Action", 13)]
	[DefaultExecutionOrder(-99)]
	public class ProgressTargetAction : ProgressTarget
	{
		[CompilerGenerated]
		private sealed class _003CExecuteResetTrigger_003Ed__36 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ProgressTargetAction _003C_003E4__this;

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
			public _003CExecuteResetTrigger_003Ed__36(int _003C_003E1__state)
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

		private const float TRIGGER_VALUE_DEFAULT_VALUE = 1f;

		private const float TOLERANCE_DEFAULT_VALUE = 0.01f;

		private const bool DISABLE_TRIGGER_AFTER_ACTIVATION_DEFAULT_VALUE = true;

		private const bool RESET_ON_ENABLE_DEFAULT_VALUE = true;

		private const bool RESET_ON_DISABLE_DEFAULT_VALUE = true;

		private const bool RESET_AFTER_DELAY_DEFAULT_VALUE = true;

		private const float RESET_DELAY_DEFAULT_VALUE = 3f;

		private const bool USE_UNSCALED_TIME_DEFAULT_VALUE = true;

		public UIAction Actions;

		public CompareType CompareMethod;

		public bool DisableTriggerAfterActivation;

		public bool ResetAfterDelay;

		public float ResetDelay;

		public bool ResetOnDisable;

		public bool ResetOnEnable;

		public float TriggerValue;

		public float TriggerMinValue;

		public float TriggerMaxValue;

		public ProgressorVariable TargetVariable;

		public float Tolerance;

		public bool UseUnscaledTime;

		private bool m_actionTriggered;

		private Coroutine m_resetCoroutine;

		private Progressor m_progressor;

		private float m_updateInterval;

		private float m_nextUpdateTime;

		public bool IsActive => false;

		private void Awake()
		{
		}

		public override void OnEnable()
		{
		}

		public override void OnDisable()
		{
		}

		private void Update()
		{
		}

		public void ResetTrigger()
		{
		}

		public void TriggerActions()
		{
		}

		public override void UpdateTarget(Progressor progressor)
		{
		}

		private void CheckTriggerValue()
		{
		}

		[IteratorStateMachine(typeof(_003CExecuteResetTrigger_003Ed__36))]
		private IEnumerator ExecuteResetTrigger()
		{
			return null;
		}
	}
}
