using __Project__.Scripts.Multiplayer.NetworkInteractions;

public class DisplayInteraction : Interaction
{
	private Display m_Display;

	private PlayerInstance m_ownedPlayerInstance;

	public NetworkDisplayInteraction NetworkDisplayInteraction;

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

	public Display CurrentDisplay => null;

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

	private void BoxUpDisplay()
	{
	}

	public void BoxUpDisplayNetwork()
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

	public void SetDisplay(Display display)
	{
	}
}
