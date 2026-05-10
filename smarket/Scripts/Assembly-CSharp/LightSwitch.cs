using UnityEngine;

public class LightSwitch : MonoBehaviour, IInteractable
{
	[SerializeField]
	private Animator m_Anim;

	[SerializeField]
	private string m_Section;

	public InteractactableType Type => default(InteractactableType);

	public bool ContinousInteraction => false;

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint => null;

	public string RepairInteractionHint => null;

	public bool NeedRepair { get; set; }

	public InteractionType InteractionType => default(InteractionType);

	public bool RemoteInteract(string userId)
	{
		return false;
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

	public bool CustomInteract()
	{
		return false;
	}
}
