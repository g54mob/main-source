using MyBox;
using Photon.Pun;
using UnityEngine;
using __Project__.Scripts.Multiplayer;

public class Furniture : MonoBehaviour, IInteractable
{
	[Separator("Placing Settings", false)]
	[SerializeField]
	private FurniturePlacingMode m_PlacingMode;

	[SerializeField]
	private InteriorSpotLight m_InteriorSpotLight;

	[SerializeField]
	private Speaker m_speaker;

	[SerializeField]
	private int m_ID;

	private FurnitureData m_Data;

	private PhotonView m_PhotonView;

	private NetworkFurniture m_NetworkFurniture;

	public PhotonView PhotonView => null;

	public NetworkFurniture OwnNetworkFurniture => null;

	public InteractactableType Type => default(InteractactableType);

	public bool ContinousInteraction => false;

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint => null;

	public string RepairInteractionHint => null;

	public bool NeedRepair { get; set; }

	public FurniturePlacingMode PlacingMode
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public InteractionType InteractionType => default(InteractionType);

	public InteriorSpotLight InteriorSpotLight
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public Speaker Speaker
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public int ID
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public FurnitureData Data
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool IsInteractableToEnter => false;

	public bool RemoteInteract(string userId)
	{
		return false;
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnSave()
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

	public bool RepairInteract(bool isHold, PlayerInstance playerInstance)
	{
		return false;
	}

	public void Despawn()
	{
	}

	public bool CustomInteract()
	{
		return false;
	}

	public void StartPlacingMode(string userId)
	{
	}

	public void UpdateFurnitureData()
	{
	}
}
