using TMPro;
using UnityEngine;

public class Label : MonoBehaviour, IInteractable
{
	public enum EProductType
	{
		Default = 0,
		Weighted = 1
	}

	[SerializeField]
	private MeshRenderer m_Renderer;

	[SerializeField]
	private TMP_Text m_ProductCount;

	[SerializeField]
	private TMP_Text m_ProductWeight;

	[SerializeField]
	private GameObject m_WeightedProductTextContainer;

	[SerializeField]
	private GameObject m_ProductTextContainer;

	private DisplaySlot m_DisplaySlot;

	private RackSlot m_RackSlot;

	private VendingSlot m_VendingSlot;

	private EProductType m_ProductType;

	public bool Enabled => false;

	private TMP_Text CountText => null;

	public int ProductCount
	{
		set
		{
		}
	}

	public float ProductWeight { get; set; }

	public DisplaySlot DisplaySlot => null;

	public RackSlot RackSlot => null;

	public VendingSlot VendingSlot => null;

	public InteractactableType Type => default(InteractactableType);

	public bool ContinousInteraction => false;

	public InteractionType InteractionType => default(InteractionType);

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint => null;

	public string RepairInteractionHint => null;

	public bool NeedRepair { get; set; }

	public EProductType ProductType
	{
		get
		{
			return default(EProductType);
		}
		set
		{
		}
	}

	public void DisplaySetup(DisplaySlot displaySlot)
	{
	}

	public void RackSetup(RackSlot rackSlot)
	{
	}

	public void VendingSetup(VendingSlot vendingSlot)
	{
	}

	public void DisableTag()
	{
	}

	public void SetProductIcon(int productID)
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

	public bool RepairInteract(bool isHold, PlayerInstance playerInstance)
	{
		return false;
	}

	public bool RemoteInteract(string userId)
	{
		return false;
	}

	public void ClearLabel()
	{
	}

	public void ClearLabelNetwork()
	{
	}

	public bool CustomInteract()
	{
		return false;
	}
}
