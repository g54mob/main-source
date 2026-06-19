using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMODUnity;
using UnityEngine;

public class AutoCollector : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CStartCollectingRoutine_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AutoCollector _003C_003E4__this;

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
		public _003CStartCollectingRoutine_003Ed__11(int _003C_003E1__state)
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

	public float CollectItemDistance;

	public RadiusProvider RadiusProvider;

	public float AttractItemForce;

	public DropCollector DropCollector;

	public EventReference CollectSound;

	private List<FloorItem> _nearbyItems;

	public float AttractItemDist => 0f;

	private void Update()
	{
	}

	private void Start()
	{
	}

	public void StartCollecting()
	{
	}

	[IteratorStateMachine(typeof(_003CStartCollectingRoutine_003Ed__11))]
	public IEnumerator StartCollectingRoutine()
	{
		return null;
	}
}
