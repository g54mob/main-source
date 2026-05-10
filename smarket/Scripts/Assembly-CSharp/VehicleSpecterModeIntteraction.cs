public class VehicleSpecterModeIntteraction : Interaction
{
	public NetworkVehicleSpecterMode CurrentVehicle;

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

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Awake()
	{
	}

	public void EnterSpecterMode(NetworkVehicleSpecterMode vehicleSpecterMode)
	{
	}

	public void OnExitVehicle()
	{
	}
}
