public class PricingInteraction : Interaction
{
	private PriceTag m_PriceTag;

	private PlayerInstance m_PlayerInstance;

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

	public void ClosePricingMenu()
	{
	}
}
