using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class bqe : MonoBehaviour
{
	private sealed class bqd : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int uku;

		private object ukv;

		public bqe ukw;

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
		public bqd(int a)
		{
		}

		[DebuggerHidden]
		private void lgu()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in lgu
			this.lgu();
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
		private void lgw()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in lgw
			this.lgw();
		}
	}

	public float maxAngle;

	public float switchRotationTime;

	public float random;

	public float rotationSpeed;

	public Vector3 movePosition;

	public float moveSpeed;

	public int characterLayer;

	private Quaternion ukx;

	private Quaternion uky;

	private Vector3 ukz;

	private Vector3 ula;

	private Rigidbody ulb;

	private void OnCollisionEnter(Collision collision)
	{
	}

	[IteratorStateMachine(typeof(bqd))]
	private IEnumerator lgy()
	{
		return null;
	}

	private void OnCollisionExit(Collision collision)
	{
	}

	private void Start()
	{
	}

	private void FixedUpdate()
	{
	}
}
