using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Photon.Pun;

namespace __Project__.Scripts.Multiplayer
{
	public class NetworkSecurityDetechArea : MonoBehaviourPun
	{
		[CompilerGenerated]
		private sealed class _003CDelay_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public double remainingTime;

			public NetworkSecurityDetechArea _003C_003E4__this;

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
			public _003CDelay_003Ed__6(int _003C_003E1__state)
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

		private SecurityAntenna m_SecurityAntenna;

		public SecurityAntenna SecurityAntenna => null;

		private void Start()
		{
		}

		private void OnSyncRequestHandler(string invokerUserID)
		{
		}

		[PunRPC]
		public void AntennaSync(double alertTime)
		{
		}

		[IteratorStateMachine(typeof(_003CDelay_003Ed__6))]
		private IEnumerator Delay(double remainingTime)
		{
			return null;
		}

		public void DetechBroadcast(int viewID)
		{
		}

		[PunRPC]
		public void ShoplifterTrigger_RPC(int viewID)
		{
		}
	}
}
