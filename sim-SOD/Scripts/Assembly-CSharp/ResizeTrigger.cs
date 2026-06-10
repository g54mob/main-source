using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class ResizeTrigger : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDoResizeTrigger_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ResizeTrigger _003C_003E4__this;

		private bool _003Cobscured_003E5__2;

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
		public _003CDoResizeTrigger_003Ed__8(int _003C_003E1__state)
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

	public LayerMask layerMask;

	public DecalProjector decal;

	[Range(-0.1f, 0.2f)]
	public float hitboxSizeModifier;

	public float pixelScaleMultiplier;

	[Range(0f, 3000f)]
	public int maxResizeTimes;

	[Range(0f, 3000f)]
	public int maxRepositionTimes;

	[Range(0f, 10f)]
	public float maxRepositionDistance;

	public void TriggerGraffitiChecks()
	{
	}

	[IteratorStateMachine(typeof(_003CDoResizeTrigger_003Ed__8))]
	private IEnumerator DoResizeTrigger()
	{
		return null;
	}
}
