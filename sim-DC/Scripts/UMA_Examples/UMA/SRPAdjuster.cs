using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace UMA
{
	public class SRPAdjuster : MonoBehaviour
	{
		[Serializable]
		public struct lightAdjustment
		{
			private UMAUtils.PipelineType pipeline;

			public GameObject light;

			public float intensity;

			public Color color;

			public bool disabled;
		}

		[CompilerGenerated]
		private sealed class _003CUpdateAdjustments_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SRPAdjuster _003C_003E4__this;

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
			public _003CUpdateAdjustments_003Ed__4(int _003C_003E1__state)
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

		public lightAdjustment[] HDRPAdjustments;

		public lightAdjustment[] URPAdjustments;

		private void Start()
		{
		}

		[IteratorStateMachine(typeof(_003CUpdateAdjustments_003Ed__4))]
		private IEnumerator UpdateAdjustments()
		{
			return null;
		}

		private void DoUpdate()
		{
		}
	}
}
