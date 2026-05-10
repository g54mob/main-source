using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Photon.Pun;
using UnityEngine;

public class NetworkOrderManager : NoktaSingletonPunCallbacks<NetworkOrderManager>
{
	private OrderManager m_OrderManager;

	[SerializeField]
	private OrderPaperBag m_OrderPaperBagPrefab;

	private static bool m_Registered;

	private Dictionary<int, HashSet<string>> m_WorkInfo;

	public event Action<int> WorkingStatusChanged
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action<int, bool> LabelIconStatusRequested
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public bool IsBeingWorkedOn(int id, string except, out string workedBy)
	{
		workedBy = null;
		return false;
	}

	[RuntimeInitializeOnLoadMethod]
	private static void ResetRegistrationStatus()
	{
	}

	private void Awake()
	{
	}

	private void OnSyncRequest(string userId)
	{
	}

	[PunRPC]
	public void UpdatePaperBagData_RPC(int viewId, int orderId, PaperBagProductInstance[] instanceData, bool active)
	{
	}

	[PunRPC]
	public void SyncData_RPC(OrderListData[] data)
	{
	}

	public void CreateOrder(OrderListData newOrder)
	{
	}

	public void RequestOrderRemove_Master(int id)
	{
	}

	[PunRPC]
	private void RequestOrderRemove_MasterRPC(int id)
	{
	}

	public void RemoveOrder_Broadcast(int id)
	{
	}

	private void CreateOrder_Broadcast(OrderListData newOrder)
	{
	}

	[PunRPC]
	public void RemoveFromMinimap_RPC(int customerViewId)
	{
	}

	[PunRPC]
	public void RemoveOrder_RPC(int id)
	{
	}

	[PunRPC]
	public void CreateOrder_RPC(OrderListData data)
	{
	}

	public void CancelOrder_Others(int orderId)
	{
	}

	[PunRPC]
	public void CancelOrder_RPC(int customerViewId)
	{
	}

	public void RegisterWorking(string userId, int orderId)
	{
	}

	public void UnregisterWorking(string userId, int orderId)
	{
	}

	[PunRPC]
	private void ToggleWorking_RPC(string userId, int orderId, bool add)
	{
	}

	public void RaiseLabelIconRequest(int id, bool value)
	{
	}
}
