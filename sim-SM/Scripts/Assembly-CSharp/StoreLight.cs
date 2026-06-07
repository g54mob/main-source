using UnityEngine;
using __Project__.Scripts.Multiplayer;

public class StoreLight : MonoBehaviour, IInteractable
{
	[SerializeField]
	private FurniturePlacingMode m_PlacingMode;

	public LayerMask layerMask;

	private NetworkStoreLight m_NetworkStoreLight;

	[SerializeField]
	private Vector3 defaultPosition;

	[SerializeField]
	private Quaternion defaultRotation;

	public InteractactableType Type { get; private set; }

	public bool ContinousInteraction { get; }

	public InteractionType InteractionType => default(InteractionType);

	public NetworkStoreLight NetworkStoreLight => null;

	private bool IsOccupied
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool NeedRepair { get; set; }

	public string InstantInteractionHint { get; }

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint { get; }

	public string RepairInteractionHint { get; }

	private void OnEnable()
	{
	}

	private void Awake()
	{
	}

	private void LoadSaveProgress()
	{
	}

	private void Start()
	{
	}

	private void OnDisable()
	{
	}

	private void OnSectionPurchased(int obj)
	{
	}

	private void SnapStoreLightWall()
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

	public void StartPlacingMode()
	{
	}

	public void StartPlacingMode(string userId)
	{
	}

	public bool CustomInteract()
	{
		return false;
	}

	public bool RepairInteract(bool isHold, PlayerInstance playerInstance)
	{
		return false;
	}

	public bool RemoteInteract(string userId)
	{
		return false;
	}

	public void ResetDefaultPos()
	{
	}
}
