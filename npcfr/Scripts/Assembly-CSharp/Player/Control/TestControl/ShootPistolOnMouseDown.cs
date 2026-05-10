using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Spawnables.Weapons;
using UnityEngine;

namespace Player.Control.TestControl
{
	public class ShootPistolOnMouseDown : MonoBehaviour
	{
		private sealed class mu : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int qql;

			private object qqm;

			public ShootPistolOnMouseDown qqn;

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
			public mu(int a)
			{
			}

			[DebuggerHidden]
			private void fnh()
			{
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in fnh
				this.fnh();
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
			private void fnj()
			{
			}

			void IEnumerator.Reset()
			{
				//ILSpy generated this explicit interface implementation from .override directive in fnj
				this.fnj();
			}
		}

		[SerializeField]
		private Glock17 m_glock17;

		private bool qqo;

		private Coroutine qqp;

		private void Start()
		{
		}

		private void Update()
		{
		}

		[IteratorStateMachine(typeof(mu))]
		private IEnumerator fnl()
		{
			return null;
		}
	}
}
