using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ARPGFX
{
	public class ARPGFXPortalScript : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CPortalLoop_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ARPGFXPortalScript _003C_003E4__this;

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
			public _003CPortalLoop_003Ed__8(int _003C_003E1__state)
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

		public GameObject portalOpenPrefab;

		public GameObject portalIdlePrefab;

		public GameObject portalClosePrefab;

		private GameObject portalOpen;

		private GameObject portalIdle;

		private GameObject portalClose;

		public float portalLifetime;

		private void Start()
		{
		}

		[IteratorStateMachine(typeof(_003CPortalLoop_003Ed__8))]
		private IEnumerator PortalLoop()
		{
			return null;
		}
	}
}
