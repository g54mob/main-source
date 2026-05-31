using System;
using System.Collections.Generic;
using MyBox;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using __Project__.Scripts.Computer;

namespace __Project__.Scripts.Multiplayer.NetworkComputer
{
	public class NetworkComputer : NoktaSingletonPunCallbacks<NetworkComputer>
	{
		[SerializeField]
		private List<GameObject> m_BlockedTabs;

		private __Project__.Scripts.Computer.Computer m_Computer;

		public Action<RestockerItem, RestockerManagementData> OnRestockerDataChanged;

		private Vector3 m_PlayerLeftPosition;

		private TabManager m_TabManager;

		private ComputerOperatingSystem m_ComputerOperatingSystem;

		private bool m_IsHirinTabOpened;

		private List<RestockerItem> m_RestockerItems;

		public __Project__.Scripts.Computer.Computer Computer => null;

		public TabManager TabManager => null;

		public ComputerOperatingSystem ComputerOperatingSystem => null;

		public override void OnEnable()
		{
		}

		public override void OnDisable()
		{
		}

		private void OnComputerInteract()
		{
		}

		[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
		private void OpenHiringTab()
		{
		}

		private void OnRestockerDataChangedFunc(RestockerItem item, RestockerManagementData data)
		{
		}

		private void OnSyncRequest(string userID)
		{
		}

		[PunRPC]
		public void SyncComputerData_RPC(bool isOccupied)
		{
		}

		private void Start()
		{
		}

		public void InteractComputer_Broadcast(bool willOpen)
		{
		}

		[PunRPC]
		public void InteractComputer_RPC(string userId, bool willOpen)
		{
		}

		public void StartComputerPlacingMode_Request()
		{
		}

		[PunRPC]
		public void StartPlacingModeComputer_Response(string userId)
		{
		}

		[PunRPC]
		public void StartPlacingModeComputer_Order()
		{
		}

		[PunRPC]
		public void StartPlacingModeComputer_Rejected()
		{
		}

		public void StartPlacingMode_Broadcast()
		{
		}

		[PunRPC]
		public void StartComputerPlacingMode_RPC(string userId)
		{
		}

		public void SetRestockerItemsData_Request(RestockerItem restockerItem)
		{
		}

		[PunRPC]
		public void SetRestockerItemsData_Response(string restockerDataJson)
		{
		}

		public void RefreshRestockerItemsData_Request()
		{
		}

		[PunRPC]
		public void RefreshRestockerItemsData_Response()
		{
		}

		public void SetRestockerItemsData_Broadcast(RestockerItem restockerItem)
		{
		}

		[PunRPC]
		public void SetRestockerItemsData_RPC(string restockerDataJson, bool isHired, int restockerId, int requiredStoreLevel, float DailyWage, float HiringCost, bool canHire, bool purchasedStorage, int purchasedRack, int currentStoreLevel)
		{
		}

		public override void OnPlayerLeftRoom(Player otherPlayer)
		{
		}
	}
}
