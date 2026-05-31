using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class PurchasableProduct : MonoBehaviour, IPurchasable, IInteractable, IHoldDuration
{
	public const int k_StorePointPerEachItemPurchased = 2;

	[SerializeField]
	private ProductSO m_ProductSO;

	[SerializeField]
	private Renderer[] m_IgnoredLicenseVisibilityRenderers;

	[SerializeField]
	private Material m_DisabledMaterial;

	private List<Material> m_DefaultProductMaterials;

	private List<Material> m_TempMaterials;

	[SerializeField]
	private Renderer[] m_ProductRenderers;

	private LocalMarketProductPriceDisplay m_PriceDisplay;

	private bool m_LicenseVisibilityStatus;

	public ProductSO ProductSO => null;

	public InteractactableType Type => default(InteractactableType);

	public bool ContinousInteraction => false;

	public InteractionType InteractionType => default(InteractionType);

	public LocalMarketProductDatabase Database { get; set; }

	public float Duration => 0f;

	public bool NeedRepair { get; set; }

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint => null;

	public string RepairInteractionHint => null;

	public float ActualPrice => 0f;

	public float DiscountedPrice => 0f;

	public bool RemoteInteract(string userId)
	{
		return false;
	}

	public bool CustomInteract()
	{
		return false;
	}

	private void Awake()
	{
	}

	private void LoadDefaultProductMaterials()
	{
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnLicensePurchased(int _)
	{
	}

	public void ToggleLicenseVisibility()
	{
	}

	public void Purchase(IPurchaser purchaser)
	{
	}

	public bool CanBePurchased(IPurchaser purchaser)
	{
		return false;
	}

	public float GetCost()
	{
		return 0f;
	}

	public bool HoldingInteract()
	{
		return false;
	}

	public bool InstantInteract()
	{
		return false;
	}

	public bool RepairInteract(bool isHold, PlayerInstance playerInstance)
	{
		return false;
	}
}
