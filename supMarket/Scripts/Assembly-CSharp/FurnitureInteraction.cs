using __Project__.Scripts.Multiplayer.NetworkInteractions;

public class FurnitureInteraction : Interaction
{
	private Furniture m_Furniture;

	private PlayerInstance m_PlayerInstance;

	private bool m_InAnimationTransition;

	public NetworkFurnitureInteraction NetworkFurnitureInteraction;

	public PlayerInstance PlayerInstance => null;

	public override IInteractable Interactable
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public Furniture CurrentFurniture => null;

	public override bool Enable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnUse(bool down)
	{
	}

	private void OnRotate(bool clockvise)
	{
	}

	private void OnClose()
	{
	}

	private void BoxUpFurniture()
	{
	}

	public void BoxUpFurnitureNetwork()
	{
	}

	private void TryPlaceFurniture()
	{
	}

	public void PlaceFurniture()
	{
	}

	public void SetFurniture(Furniture furniture)
	{
	}

	private void DefaultHint(bool show)
	{
	}

	private void SpeakerHint(bool show)
	{
	}

	public void CancelInteractionForOnlyMultiplayer()
	{
	}
}
