public class VendingMachineInteraction : Interaction
{
	private VendingMachine m_Vending;

	private PlayerInstance m_ownedPlayerInstance;

	public NetworkVendingInteraction NetworkVendingInteraction;

	private bool m_InAnimationTransition;

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

	public VendingMachine CurrentVending => null;

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

	public PlayerInstance PlayerInstance => null;

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

	private void BoxUpVending()
	{
	}

	public void BoxUpVendingNetwork()
	{
	}

	private void TryPlaceFurniture()
	{
	}

	public void PlaceFurniture()
	{
	}

	public void CancelInteracitonForOnlyMultiplayer()
	{
	}

	private void DefaultHint(bool show)
	{
	}

	public void SetVending(VendingMachine vending)
	{
	}
}
