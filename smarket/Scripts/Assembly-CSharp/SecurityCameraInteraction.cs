public class SecurityCameraInteraction : Interaction
{
	private PlayerInstance m_PlayerInstance;

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

	private PlayerInstance PlayerInstance => null;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public void ActivateCamera()
	{
	}

	public void DeactivateCamera()
	{
	}
}
