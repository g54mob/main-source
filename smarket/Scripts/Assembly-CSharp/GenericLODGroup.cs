using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GenericLODGroup : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CSetAvailabilityDelayed_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GenericLODGroup _003C_003E4__this;

		public LODInstance inst;

		public bool availability;

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
		public _003CSetAvailabilityDelayed_003Ed__23(int _003C_003E1__state)
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
	private float m_Radius;

	public int Index;

	[SerializeField]
	private GenericLODInstanceList[] m_Instances;

	[SerializeField]
	private int m_GroupId;

	[SerializeField]
	private bool m_UpdateNonCanvasesFrameDelayed;

	private WaitForEndOfFrame k_WaitForEndOfFrame;

	public int CurrentDistance { get; private set; }

	public float Radius => 0f;

	public int InstanceCount => 0;

	public IEnumerable<GenericLODInstanceList> Instances => null;

	public int GroupId => 0;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void OnRemoved()
	{
	}

	public void OnStateChanged(CullingGroupEvent ev)
	{
	}

	[IteratorStateMachine(typeof(_003CSetAvailabilityDelayed_003Ed__23))]
	private IEnumerator SetAvailabilityDelayed(LODInstance inst, bool availability)
	{
		return null;
	}
}
