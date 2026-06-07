using UnityEngine;

public class OvenDoor : MonoBehaviour, IInteractable
{
	[SerializeField]
	private Oven m_Oven;

	[SerializeField]
	private Transform m_OvenDoor;

	[SerializeField]
	private AudioClip m_OvenDoorOpen;

	[SerializeField]
	private AudioClip m_OvenDoorClose;

	private bool m_IsOvenDoorOpen;

	private bool m_IsOpenDoorModel;

	private AudioSource m_DoorAudioSource;

	public InteractactableType Type => default(InteractactableType);

	public bool ContinousInteraction => false;

	public InteractionType InteractionType => default(InteractionType);

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint => null;

	public string RepairInteractionHint => null;

	public bool NeedRepair { get; set; }

	public bool IsOvenDoorOpen
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool RemoteInteract(string userId)
	{
		return false;
	}

	private void Start()
	{
	}

	public bool InstantInteract()
	{
		return false;
	}

	public void OpenDoorOnFinish()
	{
	}

	public void SwitchOvenDoor(bool isOpen)
	{
	}

	private void SwichtOvenDoor()
	{
	}

	public void SwichtOvenDoor_Network(bool isOpen)
	{
	}

	public void OpenCloseOvenDoor(bool isOpen)
	{
	}

	public bool HoldingInteract()
	{
		return false;
	}

	public bool CustomInteract()
	{
		return false;
	}

	public bool RepairInteract(bool isHold, PlayerInstance playerInstance)
	{
		return false;
	}
}
