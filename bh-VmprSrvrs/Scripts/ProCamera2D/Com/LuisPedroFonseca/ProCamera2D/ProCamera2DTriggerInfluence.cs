using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[HelpURL("http://www.procamera2d.com/user-guide/trigger-influence/")]
	public class ProCamera2DTriggerInfluence : BaseTrigger
	{
		public enum TriggerInfluenceMode
		{
			BothAxis = 0,
			HorizontalAxis = 1,
			VerticalAxis = 2
		}

		[CompilerGenerated]
		private sealed class _003CInsideTriggerRoutine_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ProCamera2DTriggerInfluence _003C_003E4__this;

			private float _003CpreviousDistancePercentage_003E5__2;

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
			public _003CInsideTriggerRoutine_003Ed__13(int _003C_003E1__state)
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
		private sealed class _003COutsideTriggerRoutine_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ProCamera2DTriggerInfluence _003C_003E4__this;

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
			public _003COutsideTriggerRoutine_003Ed__14(int _003C_003E1__state)
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

		public Transform FocusPoint;

		public float InfluenceSmoothness;

		[Range(0f, 1f)]
		public float ExclusiveInfluencePercentage;

		public TriggerInfluenceMode Mode;

		private Vector2 _influence;

		private Vector2 _velocity;

		private Vector3 _exclusivePointVelocity;

		private Vector3 _tempExclusivePoint;

		private void Start()
		{
		}

		protected override void EnteredTrigger()
		{
		}

		protected override void ExitedTrigger()
		{
		}

		[IteratorStateMachine(typeof(_003CInsideTriggerRoutine_003Ed__13))]
		private IEnumerator InsideTriggerRoutine()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003COutsideTriggerRoutine_003Ed__14))]
		private IEnumerator OutsideTriggerRoutine()
		{
			return null;
		}
	}
}
