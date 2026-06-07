using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace KevinIglesias
{
	public class ChangeSpear : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CStartChange_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ChangeSpear _003C_003E4__this;

			private float _003CyRotation_003E5__2;

			private float _003Ci_003E5__3;

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
			public _003CStartChange_003Ed__16(int _003C_003E1__state)
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

		public Transform spear;

		public Transform hand;

		public bool changeActive;

		public bool secondTime;

		private Transform characterRoot;

		private Vector3 zeroPosition;

		private Vector3 zeroRotation;

		private Vector3 startPosition;

		private Quaternion startRotation;

		private Vector3 endPosition;

		private Quaternion endRotation;

		private IEnumerator changeCO;

		public void Start()
		{
		}

		public void Update()
		{
		}

		public void DoChangeSpear()
		{
		}

		[IteratorStateMachine(typeof(_003CStartChange_003Ed__16))]
		private IEnumerator StartChange()
		{
			return null;
		}
	}
}
