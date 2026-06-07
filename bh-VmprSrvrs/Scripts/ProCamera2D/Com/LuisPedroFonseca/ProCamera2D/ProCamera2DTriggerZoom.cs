using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[HelpURL("http://www.procamera2d.com/user-guide/trigger-zoom/")]
	public class ProCamera2DTriggerZoom : BaseTrigger
	{
		[CompilerGenerated]
		private sealed class _003CInsideTriggerRoutine_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ProCamera2DTriggerZoom _003C_003E4__this;

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
			public _003CInsideTriggerRoutine_003Ed__17(int _003C_003E1__state)
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
		private sealed class _003COutsideTriggerRoutine_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ProCamera2DTriggerZoom _003C_003E4__this;

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
			public _003COutsideTriggerRoutine_003Ed__18(int _003C_003E1__state)
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

		public bool SetSizeAsMultiplier;

		public float TargetZoom;

		public float ZoomSmoothness;

		[Range(0f, 1f)]
		public float ExclusiveInfluencePercentage;

		public bool ResetSizeOnExit;

		public float ResetSizeSmoothness;

		private float _startCamSize;

		private float _initialCamSize;

		private float _targetCamSize;

		private float _targetCamSizeSmoothed;

		private float _previousCamSize;

		private float _zoomVelocity;

		private float _initialCamDepth;

		private void Start()
		{
		}

		protected override void EnteredTrigger()
		{
		}

		protected override void ExitedTrigger()
		{
		}

		[IteratorStateMachine(typeof(_003CInsideTriggerRoutine_003Ed__17))]
		private IEnumerator InsideTriggerRoutine()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003COutsideTriggerRoutine_003Ed__18))]
		private IEnumerator OutsideTriggerRoutine()
		{
			return null;
		}

		protected void UpdateScreenSize(float smoothness)
		{
		}
	}
}
