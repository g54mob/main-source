using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;
using UnityEngine.AI;

public class IceCreamStand : MonoBehaviour, IInteractable, IPoolable
{
	private PlayerInstance m_ControllerPlayer;

	[SerializeField]
	private FurnitureSO m_FurnitureSO;

	private bool m_Active;

	private IndexedStaticInstancer[] m_ConeInstancers;

	[SerializeField]
	private CustomerQueue m_Queue;

	[SerializeField]
	private GameObject m_ActiveDisplay;

	private NavMeshObstacle m_Obstacle;

	private IceCreamHelper m_Employee;

	[SerializeField]
	private IceCreamConeInteractable[] m_ConeInteractables;

	[SerializeField]
	private Transform m_ControlTransform;

	[SerializeField]
	private Transform m_EmployeeControlTransform;

	private bool m_IsInPlacement;

	private FurniturePlacingMode m_PlacingMode;

	[SerializeField]
	private GameObject m_WarningIndicator;

	[SerializeField]
	private IceCreamFlavourInteractable[] m_FlavourBoxes;

	private DisplaySlot[] m_DisplaySlots;

	private NetworkIceCreamStand m_NetworkStand;

	public FurnitureSO FurnitureSO => null;

	public InteractactableType Type => default(InteractactableType);

	public bool ContinousInteraction => false;

	public InteractionType InteractionType => default(InteractionType);

	public bool NeedRepair { get; set; }

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint { get; }

	public string SecondInteractionHint => null;

	public string RepairInteractionHint { get; }

	public bool IsActive
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public CustomerQueue Queue => null;

	public IceCreamHelper Employee => null;

	public bool HasEmployee => false;

	public bool IsInPlacement => false;

	public IReadOnlyCollection<IceCreamFlavourInteractable> FlavourBoxes => null;

	public bool IsControlled => false;

	public int ConeContainerCount => 0;

	public NetworkIceCreamStand NetworkStand => null;

	public void SetActiveInternal(bool value)
	{
	}

	private void UpdateActive()
	{
	}

	public void ForceResetQueue()
	{
	}

	public void ForceCompleteQueue()
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

	private void Awake()
	{
	}

	public bool InstantInteract()
	{
		return false;
	}

	public bool RemoteInteract(string userId)
	{
		return false;
	}

	public bool RepairInteract(bool isHold, PlayerInstance playerInstance)
	{
		return false;
	}

	public void StartController()
	{
	}

	public void EndController()
	{
	}

	private void ActivateControlCamera()
	{
	}

	public void SetControllerIdle()
	{
	}

	public void StartPlacementNetwork(string userId)
	{
	}

	private void StartPlacement()
	{
	}

	public void EndPlacement()
	{
	}

	public void RegisterDisplaySlots()
	{
	}

	public void UpdateEmployeeTransform()
	{
	}

	public void ApplyStandData(IceCreamManager.StandBoxData data)
	{
	}

	public void ToggleWarning(bool value)
	{
	}

	public void ToggleWarning_Network(bool value)
	{
	}

	public void ApplyStandData(IceCreamManager.StandData data)
	{
	}

	private void ToggleConeInstancers(bool value)
	{
	}

	public IceCreamFlavourInteractable GetFlavourBox(int i)
	{
		return null;
	}

	public bool TryGetFlavourBoxOfFlavour(IceCreamFlavour flavour, out IceCreamFlavourInteractable result, bool withAvailableCount = true)
	{
		result = null;
		return false;
	}

	public IceCreamConeInteractable GetConeContainer(int i)
	{
		return null;
	}

	public int GetConeCount(int i)
	{
		return 0;
	}

	public void SetConeCount(int index, int value)
	{
	}

	public void SetConeCountWithoutNotify(int index, int value)
	{
	}

	public void SetController_Network(PlayerInstance player)
	{
	}

	public void ApplyState(NetworkIceCreamStand.SyncState syncState)
	{
	}

	public IceCreamManager.StandBoxData GenerateStandBoxData()
	{
		return null;
	}

	public IceCreamManager.StandData GenerateStandData()
	{
		return null;
	}

	public void UpdateRequestTexture()
	{
	}

	public void UpdateRequestTextureForRequest(IceCreamRequest request)
	{
	}

	public void ReleaseRequestTexture()
	{
	}

	public void AssignHelper(IceCreamHelper iceCreamHelper)
	{
	}

	public void UnassignHelper()
	{
	}

	public void UnassignHelper(IceCreamHelper iceCreamHelper)
	{
	}

	public void AddHelper_Network(IceCreamHelper helper)
	{
	}

	public void RequestEmployee()
	{
	}

	public void OnSpawn()
	{
	}

	public void OnDespawn()
	{
	}

	public void Clear()
	{
	}

	public bool CheckIfHasEnoughFlavours(IEnumerable<KeyValuePair<IceCreamFlavour, int>> flavours, out IceCreamFlavour missing)
	{
		missing = null;
		return false;
	}

	public void SetActiveInternal_Network(bool value)
	{
	}

	public void DiscardController()
	{
	}

	public void UpdateInventory()
	{
	}
}
