using UnityEngine;

public class OvenStartButton : MonoBehaviour, IInteractable
{
	[SerializeField]
	private Oven m_Oven;

	private AudioSource m_ButtonPressAudioSource;

	public InteractactableType Type => default(InteractactableType);

	public bool ContinousInteraction => false;

	public InteractionType InteractionType => default(InteractionType);

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint => null;

	public string RepairInteractionHint => null;

	public bool NeedRepair { get; set; }

	public bool RemoteInteract(string userId)
	{
		return false;
	}

	private void Start()
	{
	}

	public void OvenStart()
	{
	}

	public void AnimateButton()
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

	public bool CustomInteract()
	{
		return false;
	}

	public bool RepairInteract(bool isHold, PlayerInstance playerInstance)
	{
		return false;
	}
}
