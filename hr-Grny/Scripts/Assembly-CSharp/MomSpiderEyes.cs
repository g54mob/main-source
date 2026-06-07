using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MomSpiderEyes : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CStart_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MomSpiderEyes _003C_003E4__this;

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
		public _003CStart_003Ed__13(int _003C_003E1__state)
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

	public Transform myTransform;

	public Transform target;

	public Camera cam;

	public GameObject momSpider;

	public float seeRange;

	public bool seePlayer;

	public Transform targetR;

	public bool seePlayerR;

	public Transform targetL;

	public bool seePlayerL;

	public float SeeAngle;

	public bool NotSeePlayer;

	[IteratorStateMachine(typeof(_003CStart_003Ed__13))]
	public virtual IEnumerator Start()
	{
		return null;
	}

	public virtual void Update()
	{
	}
}
