using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using PG;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class NetworkVehicle : MonoBehaviourPunCallbacks, IPunInstantiateMagicCallback
{
	[CompilerGenerated]
	private sealed class _003CDelayTrigger_003Ed__59 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Collider coll;

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
		public _003CDelayTrigger_003Ed__59(int _003C_003E1__state)
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

	public bool IsVehicleInUsage;

	private PhotonView m_PhotonView;

	private CarController m_CarController;

	private PlayerInstance m_VehicleUserPlayer;

	private SortedBoxPlacementArea m_SortedBoxPlacementArea;

	private StackedBoxPlacementArea m_StackedBoxPlacementArea;

	[SerializeField]
	private TrunkInteractable m_TrunkInteractable;

	private VehicleDataLoader m_VehicleDataLoader;

	private NetworkVehicleSpecterMode m_NetworkVehicleSpecterMode;

	public Transform[] m_Seats;

	private VehicleIKTargets m_VehicleIKTargets;

	[SerializeField]
	private PlayerAnimation.DriverState m_AnimationIndex;

	private NetworkVehicleSpecterMode NetworkVehicleSpecterMode => null;

	public Transform DriverSeat => null;

	public PlayerAnimation.DriverState AnimationIndex => default(PlayerAnimation.DriverState);

	public PhotonView PhotonView => null;

	public CarController CarController => null;

	public SortedBoxPlacementArea SortedBoxPlacementArea => null;

	public StackedBoxPlacementArea StackedBoxPlacementArea => null;

	public VehicleDataLoader VehicleDataLoader => null;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void OnPhotonInstantiate(PhotonMessageInfo info)
	{
	}

	private void SyncVehicleState_Broadcast(string newPlayerId)
	{
	}

	[PunRPC]
	private void SyncVehicleState_RPC(string[] passengers, Vector3 pos, Vector3 rot)
	{
	}

	public void TransferOwnership()
	{
	}

	public void EnterVehicle_Request()
	{
	}

	[PunRPC]
	public void EnterVehicle_Response(string _playerUserId)
	{
	}

	[PunRPC]
	public void EnterVehicle_Accept()
	{
	}

	[PunRPC]
	public void EnterCar_Rejected()
	{
	}

	public void EnterVehicle_Broadcast(string _playerUserId)
	{
	}

	[PunRPC]
	public void EnterVehicle_RPC(string _playerUserId)
	{
	}

	private Transform GetSeat(int index)
	{
		return null;
	}

	private Transform GetFreePassengerSeat()
	{
		return null;
	}

	public void SeatPlayerSpecter(PlayerInstance player, int seatIndex)
	{
	}

	public void SeatPlayerSpecter(PlayerInstance player)
	{
	}

	public void UnseatPlayerSpecter(PlayerInstance player)
	{
	}

	public void SeatPlayer(PlayerInstance player)
	{
	}

	public void UnseatPlayer(PlayerInstance player)
	{
	}

	public void ExitVehicle_Broadcast(string _playerUserId, bool _isPlayerLeft = false)
	{
	}

	[PunRPC]
	public void ExitVehicle_RPC(string _playerUserId, bool _isPlayerLeft = false)
	{
	}

	public void SyncGasLevel_Broadcast(float _amount)
	{
	}

	[PunRPC]
	public void SyncGasLevel_RPC(float _amount)
	{
	}

	public void TrunkInteract_Broadcast(bool isOpen)
	{
	}

	[PunRPC]
	public void TrunkInteract_RPC(bool isOpen)
	{
	}

	public void SortedBoxPlace_Request(SortableBox sortableBox)
	{
	}

	[PunRPC]
	public void SortedBoxPlace_Response(int boxViewId)
	{
	}

	public void SyncPaperBagData_Broadcast(int viewId, int orderId, PaperBagProductInstance[] data, bool withTag)
	{
	}

	[PunRPC]
	private void SyncPaperBagData_RPC(int viewId, int orderId, PaperBagProductInstance[] data, bool withTag)
	{
	}

	public void SortedBoxPlace_Broadcast(List<SortableBox> sortableBoxes)
	{
	}

	[PunRPC]
	public void SortedBoxPlace_RPC(int[] boxViewIds)
	{
	}

	[IteratorStateMachine(typeof(_003CDelayTrigger_003Ed__59))]
	private IEnumerator DelayTrigger(Collider coll)
	{
		return null;
	}

	public void RemoveBox_Request(SortableBox sortableBox)
	{
	}

	[PunRPC]
	public void RemoveBox_Response(int boxViewId)
	{
	}

	public void RemoveBox_Broadcast(SortableBox sortableBox)
	{
	}

	[PunRPC]
	public void RemoveBox_RPC(int boxViewId)
	{
	}

	public override void OnPlayerLeftRoom(Player otherPlayer)
	{
	}
}
