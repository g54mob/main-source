using PG;
using UnityEngine;

public class VehicleInteract : MonoBehaviour, IInteractable
{
	[SerializeField]
	private CarController m_CarController;

	public InteractactableType Type => default(InteractactableType);

	public bool ContinousInteraction => false;

	public InteractionType InteractionType => default(InteractionType);

	public bool NeedRepair { get; set; }

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint => null;

	public string RepairInteractionHint => null;

	public CarController CarController
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool RemoteInteract(string userId)
	{
		return false;
	}

	public bool InstantInteract()
	{
		return false;
	}

	private bool IsVehicleInUsage()
	{
		return false;
	}

	public bool CustomInteract()
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
}
