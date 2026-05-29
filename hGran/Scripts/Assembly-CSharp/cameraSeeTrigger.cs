using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class cameraSeeTrigger : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003COnTriggerEnter_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Collider other;

		public cameraSeeTrigger _003C_003E4__this;

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
		public _003COnTriggerEnter_003Ed__18(int _003C_003E1__state)
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

	public GameObject noiceObject1;

	public GameObject noiceObject2;

	public GameObject noiceObject3;

	public GameObject noiceObject4;

	public bool camSee;

	public bool camActivated;

	public bool doorClosed;

	public GameObject Granny;

	public GameObject player;

	public GameObject doorTrigger;

	public GameObject planka1;

	public GameObject planka2;

	public GameObject planka3;

	public GameObject cameraAlarm;

	public GameObject galler;

	public GameObject gallerColliders;

	public GameObject prisonDoor;

	public virtual void Start()
	{
	}

	[IteratorStateMachine(typeof(_003COnTriggerEnter_003Ed__18))]
	public virtual IEnumerator OnTriggerEnter(Collider other)
	{
		return null;
	}
}
