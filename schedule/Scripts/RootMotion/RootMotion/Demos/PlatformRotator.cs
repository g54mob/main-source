using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RootMotion.Demos
{
	public class PlatformRotator : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CSwitchRotation_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlatformRotator _003C_003E4__this;

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
			public _003CSwitchRotation_003Ed__14(int _003C_003E1__state)
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

		public float maxAngle;

		public float switchRotationTime;

		public float random;

		public float rotationSpeed;

		public Vector3 movePosition;

		public float moveSpeed;

		public int characterLayer;

		private Quaternion defaultRotation;

		private Quaternion targetRotation;

		private Vector3 targetPosition;

		private Vector3 velocity;

		private Rigidbody r;

		private void Start()
		{
		}

		private void FixedUpdate()
		{
		}

		[IteratorStateMachine(typeof(_003CSwitchRotation_003Ed__14))]
		private IEnumerator SwitchRotation()
		{
			return null;
		}

		private void OnCollisionEnter(Collision collision)
		{
		}

		private void OnCollisionExit(Collision collision)
		{
		}
	}
}
