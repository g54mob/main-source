using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TeslaFXController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CKillMyself_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float t;

		public TeslaFXController _003C_003E4__this;

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
		public _003CKillMyself_003Ed__10(int _003C_003E1__state)
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

	public Transform start;

	public Transform end;

	public GameObject disableController;

	private bool active;

	private float maxDistance;

	public float destroyMeTime;

	private float duration;

	private float timeActive;

	private Transform spherePos;

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CKillMyself_003Ed__10))]
	private IEnumerator KillMyself(float t)
	{
		return null;
	}

	public void InitializeEffect(Transform transstart, Vector3 transend, float maxRange = 12f, float dur = 3f)
	{
	}
}
