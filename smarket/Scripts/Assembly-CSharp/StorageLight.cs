using UnityEngine;
using __Project__.Scripts.Multiplayer;

public class StorageLight : MonoBehaviour, IInteractable
{
	[SerializeField]
	private FurniturePlacingMode m_PlacingMode;

	public LayerMask layerMask;

	private NetworkStorageLight m_NetworkStorageLight;

	[SerializeField]
	private Vector3 defaultPosition;

	[SerializeField]
	private Quaternion defaultRotation;

	public InteractactableType Type { get; private set; }

	public bool ContinousInteraction { get; }

	public InteractionType InteractionType => default(InteractionType);

	public NetworkStorageLight NetworkStorageLight => null;

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

	private void OnSectionPurchased()
	{
	}

	private void SnapStorageLightWall()
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

	private void StartPlacingMode()
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
