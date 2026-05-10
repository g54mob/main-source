using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Cinemachine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using __Project__.Scripts.Interaction;

public class PlayerInstance : MonoBehaviourPunCallbacks, IPunOwnershipCallbacks
{
	[CompilerGenerated]
	private sealed class _003CDelayedOnDayFinishSubscribe_003Ed__73 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerInstance _003C_003E4__this;

		private int _003Ci_003E5__2;

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
		public _003CDelayedOnDayFinishSubscribe_003Ed__73(int _003C_003E1__state)
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
	private MeshRenderer arrowMeshRenderer;

	[SerializeField]
	private TMP_Text m_PlayerNameText;

	[SerializeField]
	private GameObject m_NetworkObjectsParent;

	private PlayerSkinController m_SkinController;

	public InputActions InputActions;

	public FirstPersonController FirstPersonController;

	public PlayerController PlayerController;

	public PlayerObjectHolder PlayerObjectHolder;

	public FurniturePlacer FurniturePlacer;

	public PlayerInteraction PlayerInteraction;

	public CheckoutInteraction CheckoutInteraction;

	public CategorySignInteraction CategorySignInteraction;

	public RepairInteraction RepairInteraction;

	public ComputerInteraction ComputerInteraction;

	public CameraSettings CameraSettings;

	public BoxInteraction BoxInteraction;

	public VehicleInteraction VehicleInteraction;

	public RackInteraction RackInteraction;

	public DisplayInteraction DisplayInteraction;

	public FurnitureInteraction FurnitureInteraction;

	public FurnitureBoxInteraction FurnitureBoxInteraction;

	public PricingInteraction PricingInteraction;

	public ScaleInteraction ScaleInteraction;

	public TrashbagInteraction TrashbagInteraction;

	public ScannerInteraction ScannerInteraction;

	public ShoplifterInteraction ShoplifterInteraction;

	public CrateInteraction CrateInteraction;

	public FloorBoxInteraction FloorBoxInteraction;

	public BucketInteraction BucketInteraction;

	public OnlineOrderInteraction OnlineOrderInteraction;

	public VehicleSpecterModeIntteraction VehicleSpecterModeIntteraction;

	public StoreLightInteraction StoreLightInteraction;

	public StorageLightInteraction StorageLightInteraction;

	public IceCreamInteraction IceCreamInteraction;

	public VendingMachineInteraction VendingMachineInteraction;

	private PhotonView m_PhotonView;

	private bool _isOwned;

	private CinemachineVirtualCamera m_FPSVCamObject;

	private NetworkManager m_NetworkManager;

	private PhotonTransformViewPlayer m_PhotonTransformViewPlayer;

	public string LastPlayerUserId;

	private int m_PlayerIndex;

	public GameObject NetworkObjectsContainer => null;

	public PlayerSkinController SkinController => null;

	public bool IsMasterClient => false;

	public bool IsLocalPlayerInstance => false;

	public string UserId => null;

	public PhotonView PhotonView
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public int PlayerIndex => 0;

	public int SkinIndex { get; set; }

	public PhotonTransformViewPlayer PhotonTransformViewPlayer => null;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public Color GetMyColor()
	{
		return default(Color);
	}

	private void OnDayFinished()
	{
	}

	public int GetRandomNumber()
	{
		return 0;
	}

	public GameObject GetPlayerObject()
	{
		return null;
	}

	public bool IsUnownedPlayer()
	{
		return false;
	}

	private void ConfigureInstanceVisuals(bool isLocal)
	{
	}

	public void ConfigureLocalPlayer()
	{
	}

	[IteratorStateMachine(typeof(_003CDelayedOnDayFinishSubscribe_003Ed__73))]
	private IEnumerator DelayedOnDayFinishSubscribe()
	{
		return null;
	}

	public void ConfigureRemotePlayer()
	{
	}

	private void SetLayerRecursively(GameObject obj, int newLayer)
	{
	}

	public void TogglePlayerNameText(bool _isVisible)
	{
	}

	public void DisablePlayer()
	{
	}

	public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
	{
	}

	public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
	{
	}

	public void OnOwnershipTransferFailed(PhotonView targetView, Player senderOfFailedRequest)
	{
	}

	public override void OnPlayerLeftRoom(Player otherPlayer)
	{
	}

	public void AssignIndex(int value)
	{
	}
}
