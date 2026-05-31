using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Photon.Pun;
using UnityEngine;

namespace __Project__.Scripts.Multiplayer.Customers
{
	public class NetworkCustomer : MonoBehaviourPunCallbacks
	{
		[CompilerGenerated]
		private sealed class _003CCustomerCacheCoroutine_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public NetworkCustomer _003C_003E4__this;

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
			public _003CCustomerCacheCoroutine_003Ed__27(int _003C_003E1__state)
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

		private Customer m_Customer;

		private Shoplifter m_Shoplifter;

		private PhotonView m_PhotonView;

		private NetworkCustomerTransform m_NetworkCustomerTransform;

		public NetworkCustomerTransform NetworkCustomerTransform => null;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnSyncRequestHandler(string userID)
		{
		}

		public void SyncCustomerPosition_Broadcast(string userID)
		{
		}

		[PunRPC]
		public void ShoplifterSync()
		{
		}

		public void HoldProduct_Broadcast(int productId, Vector3 fromPosition)
		{
		}

		[PunRPC]
		public void HoldProduct_RPC(int productId, Vector3 fromPosition)
		{
		}

		public void ReleaseProduct_Broadcast()
		{
		}

		[PunRPC]
		public void ReleaseProduct_RPC()
		{
		}

		public void TakeProduct_Broadcast(DisplaySlot displaySlot)
		{
		}

		[PunRPC]
		public void TakeProductCustomer_RPC(int displayViewId, int displaySlotIndex)
		{
		}

		public void DoPayment_Broadcast(bool viaCreditCard, float cashValue)
		{
		}

		[PunRPC]
		public void DoPayment_RPC(bool viaCreditCard, float cashValue)
		{
		}

		public void SwitchShoppingBag_Broadcast(bool value)
		{
		}

		[PunRPC]
		public void SwitchShoppingBag_RPC(bool value)
		{
		}

		public void ForceRun_Broadcast()
		{
		}

		[PunRPC]
		public void ForceRun_RPC()
		{
		}

		public void GotHitLayer_Broadcast()
		{
		}

		[PunRPC]
		public void GotHitLayer_RPC()
		{
		}

		public void AddShoplifterComponent_Broadcast()
		{
		}

		[PunRPC]
		public void AddShoplifterComponent_RPC()
		{
		}

		[IteratorStateMachine(typeof(_003CCustomerCacheCoroutine_003Ed__27))]
		private IEnumerator CustomerCacheCoroutine()
		{
			return null;
		}
	}
}
