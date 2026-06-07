using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class bnj : MonoBehaviour
{
	private sealed class bni : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int udf;

		private object udg;

		public bnj udh;

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
		public bni(int a)
		{
		}

		[DebuggerHidden]
		private void kyz()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in kyz
			this.kyz();
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
		private void kzb()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in kzb
			this.kzb();
		}
	}

	public bmd ik;

	[Range(0f, 1f)]
	public float weight;

	public Transform target;

	public float targetSwitchSmoothTime;

	public float weightSmoothTime;

	public bool smoothTurnTowardsTarget;

	public float maxRadiansDelta;

	public float maxMagnitudeDelta;

	public float slerpSpeed;

	public float smoothDampTime;

	public Vector3 pivotOffsetFromRoot;

	public float minDistance;

	public Vector3 offset;

	[Range(0f, 180f)]
	public float maxRootAngle;

	public bool turnToTarget;

	public float turnToTargetTime;

	public bool useAnimatedAimDirection;

	public Vector3 animatedAimDirection;

	private Transform udi;

	private float udj;

	private float udk;

	private float udl;

	private Vector3 udm;

	private Vector3 udn;

	private bool udo;

	private bool udp;

	private float udq;

	private float udr;

	private float uds;

	private float udt;

	private float udu;

	private Vector3 xta => default(Vector3);

	private void ivy()
	{
	}

	[IteratorStateMachine(typeof(bni))]
	private IEnumerator kzg()
	{
		return null;
	}

	private void kzf()
	{
	}

	private void kze()
	{
	}

	private void LateUpdate()
	{
	}

	private void khf()
	{
	}

	private void Start()
	{
	}

	private void geo()
	{
	}
}
