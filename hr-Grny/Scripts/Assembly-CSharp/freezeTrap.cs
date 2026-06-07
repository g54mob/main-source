using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class freezeTrap : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003Ctimer_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public freezeTrap _003C_003E4__this;

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
		public _003Ctimer_003Ed__12(int _003C_003E1__state)
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

	public Transform spawnObject;

	public GameObject Granny;

	public GameObject gameController;

	public bool trapActivated;

	public bool GrannyFreeze;

	public ParticleSystem steam;

	public Texture red;

	public Texture green;

	public Renderer rend;

	public AudioClip freezeSound;

	private void Start()
	{
	}

	public virtual void OnTriggerEnter(Collider other)
	{
	}

	[IteratorStateMachine(typeof(_003Ctimer_003Ed__12))]
	public virtual IEnumerator timer()
	{
		return null;
	}
}
