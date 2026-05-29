using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using __Project__.Scripts.Multiplayer;

public class CustomerHelper : MonoBehaviour, IInteractable
{
	private const float m_RotationSmoothness = 5f;

	private const float m_RotatingTime = 0.3f;

	private const float m_SamplePositionDistance = 5f;

	[SerializeField]
	private NavMeshAgent m_Agent;

	[SerializeField]
	private CustomerHelperAnimationController m_Animation;

	[SerializeField]
	private Animator m_Animator;

	[SerializeField]
	private BoostIndicator m_BoostIndicator;

	[SerializeField]
	private float m_BoostAmount;

	[SerializeField]
	private float m_BoostCost;

	private int m_CustomerHelperID;

	private int m_CurrentBoostLevel;

	private List<float> m_CustomerHelperScanIntervals;

	private List<float> m_CustomerHelperAnimationSpeeds;

	private List<float> m_CustomerHelperWalkingSpeeds;

	private NetworkCustomerHelper m_NetworkCustomerHelper;

	public bool isBusy;

	public float ScanningInterval;

	public ICustomerHelperControllable checkoutToStay;

	public ICustomerHelperControllable checkoutToHelp;

	public bool isHelping;

	public bool isReserved;

	public NetworkCustomerHelper NetworkCustomerHelper => null;

	public int CustomerHelperID
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public float CurrentScanSpeed => 0f;

	public float CurrentScanInterval => 0f;

	public BoostIndicator BoostIndicator => null;

	public InteractactableType Type => default(InteractactableType);

	public bool ContinousInteraction => false;

	public InteractionType InteractionType => default(InteractionType);

	public bool NeedRepair { get; set; }

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint => null;

	public string RepairInteractionHint => null;

	public bool HasAssignedControllable => false;

	public bool HasControllingControllable => false;

	public Vector3 HelpPosition => default(Vector3);

	public Vector3 StandPosition => default(Vector3);

	public Quaternion StandRotation => default(Quaternion);

	public float BtStopDistance => 0f;

	public bool RemoteInteract(string userId)
	{
		return false;
	}

	private void Start()
	{
	}

	public void ManualUpdate()
	{
	}

	public bool InstantInteract()
	{
		return false;
	}

	public void SetBoostHelperNetwork(float m_BoostAmount)
	{
	}

	public bool CustomInteract()
	{
		return false;
	}

	public bool HoldingInteract()
	{
		return false;
	}

	public bool RepairInteract(bool isHold, PlayerInstance playerInstance)
	{
		return false;
	}

	private void SetCustomerHelperBoost(int boostLevel)
	{
	}

	public void ScanAnimation()
	{
	}

	public void TakePaymentAnimation()
	{
	}

	private void OnDisable()
	{
	}

	public void ResetHelperNewDay()
	{
	}

	public void ResetHelperFire()
	{
	}

	public void ResetHelperOnlySelf()
	{
	}

	public void Reserve()
	{
	}

	public void SyncControllable()
	{
	}

	public void UnreserveOrder()
	{
	}

	private void FixData()
	{
	}

	public void HelpControllable(ICustomerHelperControllable controllable)
	{
	}

	public void AssignControllable(ICustomerHelperControllable controllable)
	{
	}

	public void BoostHelper_Order()
	{
	}

	public void Help_Order(ICustomerHelperControllable controllable)
	{
	}

	public void Assign_Order(ICustomerHelperControllable controllable)
	{
	}

	public void Reserve_Order()
	{
	}
}
