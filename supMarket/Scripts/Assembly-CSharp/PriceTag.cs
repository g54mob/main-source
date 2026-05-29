using TMPro;
using UnityEngine;

public class PriceTag : MonoBehaviour, IInteractable
{
	[SerializeField]
	protected TMP_Text m_PriceText;

	[SerializeField]
	private Color m_DiscountColor;

	[SerializeField]
	private Texture m_LabelDefault;

	[SerializeField]
	private Texture m_LabelDiscounted;

	private DisplaySlot m_DisplaySlot;

	public bool Enabled => false;

	public InteractactableType Type => default(InteractactableType);

	public bool ContinousInteraction => false;

	public DisplaySlot DisplaySlot => null;

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

	public void EnableTag(DisplaySlot displaySlot)
	{
	}

	public void DisableTag()
	{
	}

	public virtual void SetPrice(float price)
	{
	}

	public bool InstantInteract()
	{
		return false;
	}

	public virtual void OccupyDisplay()
	{
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
