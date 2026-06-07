using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class spiderTrigger : MonoBehaviour
{
	public GameObject Spider;

	public GameObject spiderbackOfPoint;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}

	public virtual void OnTriggerStay(Collider other)
	{
	}

	public virtual void OnTriggerExit(Collider other)
	{
	}
}
[RequireComponent(typeof(AudioSource))]
public class SpiderTrigger : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CTriggerSpiderScare_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SpiderTrigger _003C_003E4__this;

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
		public _003CTriggerSpiderScare_003Ed__14(int _003C_003E1__state)
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
	private GameObject spiderObject;

	[SerializeField]
	private float animationDuration;

	[SerializeField]
	private string playerTag;

	[SerializeField]
	private float gizmoVisualLength;

	[SerializeField]
	private float directionalTriggerAngle;

	[SerializeField]
	private AudioClip scareSound;

	[SerializeField]
	private float cooldownDuration;

	private AudioSource audioSource;

	private bool isEventActive;

	private bool isOnCooldown;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private bool IsEnteringFromCorrectDirection(Collider playerCollider, Vector3 triggerForward)
	{
		return false;
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	[IteratorStateMachine(typeof(_003CTriggerSpiderScare_003Ed__14))]
	private IEnumerator TriggerSpiderScare()
	{
		return null;
	}

	private void OnDrawGizmos()
	{
	}
}
