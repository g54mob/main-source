using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Photon.Pun;
using TMPro;
using UnityEngine;
using __Project__.Scripts.Vending_Machine;

public class VendingMachine : MonoBehaviour, IInteractable
{
	[CompilerGenerated]
	private sealed class _003CAttractNPCRoutine_003Ed__99 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public VendingMachine _003C_003E4__this;

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
		public _003CAttractNPCRoutine_003Ed__99(int _003C_003E1__state)
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
	private FurniturePlacingMode m_PlacingMode;

	[SerializeField]
	private int m_ID;

	[SerializeField]
	private Transform m_ProductFallTransform;

	[SerializeField]
	private float m_NPCAttractRadius;

	[SerializeField]
	private float m_AttractCooldown;

	[SerializeField]
	private Transform m_InteractionPoint;

	[SerializeField]
	private Transform m_GrabPointTransform;

	[SerializeField]
	private TextMeshProUGUI m_CollectedMoneyText;

	private VendingData m_VendingData;

	private VendingSlot[] m_VendingSlots;

	private bool m_IsOccupied;

	private bool m_IsServingNPC;

	private bool m_WillAttractNPC;

	private WaitForSeconds m_AttractWaitForSeconds;

	private Coroutine m_AttractNPCCoroutine;

	private PhotonView m_PhotonView;

	private VendingIdleCollector m_VendingIdleCollector;

	private NetworkVendingMachine m_NetworkVendingMachine;

	private Collider[] m_Colliders;

	private int m_VendingUniqueID;

	public PhotonView PhotonView => null;

	public VendingIdleCollector VendingIdleCollector => null;

	public NetworkVendingMachine OwnNetworkVendingMachine => null;

	public Transform InteractionPoint => null;

	public Transform GrabPointTransform => null;

	public VendingSlot RandomSlot => null;

	public VendingSlot RandomUsedSlot => null;

	public Vector3 ProductFallPosition => default(Vector3);

	public FurniturePlacingMode PlacingMode => null;

	public int ID => 0;

	private bool EnablePriceTagColliders
	{
		set
		{
		}
	}

	private bool EnableLabelColliders
	{
		set
		{
		}
	}

	public bool HasAnyProductInVendingMachine => false;

	public VendingData Data
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public InteractactableType Type => default(InteractactableType);

	public bool NeedRepair { get; set; }

	public bool ContinousInteraction => false;

	public InteractionType InteractionType => default(InteractionType);

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint => null;

	public string RepairInteractionHint => null;

	public List<VendingSlot> VendingSlots => null;

	public int VendingUniqueID
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	private void Initialize()
	{
	}

	private void Awake()
	{
	}

	public void SetCollisions(bool willOpen)
	{
	}

	public void OccupyVending(bool isOccupied)
	{
	}

	public void OccupyOrder(bool isOccupied)
	{
	}

	public int GetIndexOfVendingSlot(VendingSlot vendingSlot)
	{
		return 0;
	}

	public VendingSlot GetVendingSlotFromIndex(int index)
	{
		return null;
	}

	public void RemoveFromVendingManagerWhileCarrying()
	{
	}

	public void AddBackToVendingManagerAfterPlaced()
	{
	}

	public bool InstantInteract()
	{
		return false;
	}

	public bool HoldingInteract()
	{
		return false;
	}

	public bool CustomInteract()
	{
		return false;
	}

	public void CollectMoney()
	{
	}

	public void SetCollectedMoney()
	{
	}

	public void SetCollectedMoneyText(float money)
	{
	}

	public bool RepairInteract(bool isHold, PlayerInstance playerInstance)
	{
		return false;
	}

	public bool RemoteInteract(string userId)
	{
		return false;
	}

	public void StartPlacingMode()
	{
	}

	public void StartPlacingModeNetwork()
	{
	}

	public void StartPlacingMode(string userId)
	{
	}

	public void Place()
	{
	}

	public void Despawn()
	{
	}

	public void ResetVendingData()
	{
	}

	public void PopulateWithLabeledEmptySlots(int productID, List<VendingSlot> slots)
	{
	}

	public int GetLabeledEmptySlotsNonAlloc(int productID, VendingSlot[] slots)
	{
		return 0;
	}

	public IEnumerable<VendingSlot> LabeledEmptySlots(int productID)
	{
		return null;
	}

	public void SwitchNPCAttractionState(bool willAttract)
	{
	}

	[IteratorStateMachine(typeof(_003CAttractNPCRoutine_003Ed__99))]
	private IEnumerator AttractNPCRoutine()
	{
		return null;
	}

	private void CallNPCToShop()
	{
	}

	public void NPCFinishedShopping()
	{
	}
}
