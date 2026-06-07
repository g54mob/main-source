using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace KevinIglesias
{
	public class ThrowBigAxe : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CStartSpin_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ThrowBigAxe _003C_003E4__this;

			private float _003Ci_003E5__2;

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
			public _003CStartSpin_003Ed__20(int _003C_003E1__state)
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

		public Transform retargeter;

		public Transform propToSpin;

		public Transform hand;

		public float spinDistance;

		public float translationSpeed;

		public float spinSpeed;

		public bool spinActive;

		public Vector3 endPositionOffset;

		public Vector3 returningPositionOffset;

		private Transform characterRoot;

		private Vector3 zeroPosition;

		private Quaternion zeroRotation;

		private Vector3 startPosition;

		private Quaternion startRotation;

		private Vector3 endPosition;

		private Quaternion endRotation;

		private IEnumerator spinCO;

		public void Awake()
		{
		}

		public void Update()
		{
		}

		public void SpinProp()
		{
		}

		[IteratorStateMachine(typeof(_003CStartSpin_003Ed__20))]
		private IEnumerator StartSpin()
		{
			return null;
		}
	}
}
