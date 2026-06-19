using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Water2D
{
	public class duck : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CgoToP_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public duck _003C_003E4__this;

			private Vector2 _003Cpp_003E5__2;

			private float _003Cxs_003E5__3;

			private float _003Cxe_003E5__4;

			private float _003Ct_003E5__5;

			private float _003Ctime_003E5__6;

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
			public _003CgoToP_003Ed__6(int _003C_003E1__state)
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
		private float speed;

		[SerializeField]
		private float pathLength;

		[SerializeField]
		private bool flip;

		private bool right;

		private Vector2 NextPoint()
		{
			return default(Vector2);
		}

		private void Start()
		{
		}

		[IteratorStateMachine(typeof(_003CgoToP_003Ed__6))]
		private IEnumerator goToP()
		{
			return null;
		}
	}
}
