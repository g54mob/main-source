using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Photon.Pun;
using UnityEngine;
using __Project__.Scripts.Multiplayer.NetworkInteractions;

public class NetworkOnlineOrderInteraction : NetworkInteraction
{
	[CompilerGenerated]
	private sealed class _003CUpdateIndicatorsDelayed_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NetworkOnlineOrderInteraction _003C_003E4__this;

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
		public _003CUpdateIndicatorsDelayed_003Ed__12(int _003C_003E1__state)
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

	public void ToggleAttachments_Broadcast(bool value)
	{
	}

	[PunRPC]
	private void ToggleAttachments_RPC(bool value)
	{
	}

	public void PlacePaperBag_Broadcast(int orderId, PaperBagProductInstance[] data, Vector3 position, float yAngle, bool withTag)
	{
	}

	public void UpdateIndicators_All()
	{
	}

	[PunRPC]
	private void UpdateIndicators_RPC()
	{
	}

	[PunRPC]
	public void PlacePaperBag_RPC(int orderId, PaperBagProductInstance[] data, Vector3 position, float yAngle, bool withTag)
	{
	}

	public void Take_Broadcast(OrderPaperBag paperBag)
	{
	}

	public void Drop_Broadcast(OrderPaperBag paperBag)
	{
	}

	public void SyncPaperbagVisibility_Broadcast(int viewId, bool value)
	{
	}

	[PunRPC]
	public void SyncPaperVisibility_RPC(int viewId, bool value)
	{
	}

	[PunRPC]
	public void Take_RPC(int id, string userId)
	{
	}

	[PunRPC]
	public void Drop_RPC(int id, PaperBagProductInstance[] instances, bool isLabeled, int orderId)
	{
	}

	[IteratorStateMachine(typeof(_003CUpdateIndicatorsDelayed_003Ed__12))]
	private IEnumerator UpdateIndicatorsDelayed()
	{
		return null;
	}

	public void PlaceProductToDisplay_Broadcast(int productId, int displayViewId, int displaySlotIndex, Vector3 spawnPosition)
	{
	}

	public void TakeProductFromDisplay_Broadcast(int displayViewId, int displaySlotIndex)
	{
	}

	[PunRPC]
	public void PlaceProductToDisplay_RPC(int productId, int displayViewId, int displaySlotIndex, Vector3 spawnPosition)
	{
	}

	[PunRPC]
	public void TakeProductFromDisplay_RPC(int displayViewId, int displaySlotIndex)
	{
	}

	public void MoneyTransition_Master(float income)
	{
	}

	[PunRPC]
	private void MoneyTransition_RPC(float income)
	{
	}

	public void RequestLabelIconEvent_All(int id, bool value)
	{
	}

	[PunRPC]
	private void RequestLabelIconEvent_RPC(int id, bool value)
	{
	}
}
