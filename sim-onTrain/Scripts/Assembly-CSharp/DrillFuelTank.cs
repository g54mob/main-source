using UnityEngine;
using UnityEngine.Localization;

public class DrillFuelTank : MonoBehaviour, IInteractable
{
	private DrillController drillController;

	[SerializeField]
	private Transform interactionParent;

	[Header("Custom Interaction Distance")]
	[SerializeField]
	private float customInteractionDistance = 2f;

	[Header("Localization")]
	[SerializeField]
	private LocalizedString addFuelLocalized;

	public bool IsActive { get; set; }

	public Transform InteractionParent
	{
		get
		{
			return interactionParent;
		}
		set
		{
			interactionParent = value;
		}
	}

	public float CustomInteractionDistance => customInteractionDistance;

	private void Start()
	{
		drillController = GetComponentInParent<DrillController>();
		if (drillController == null)
		{
			drillController = GetComponent<DrillController>();
		}
	}

	public void Interact(PlayerInventory player, Vector3 hitPoint)
	{
		if (drillController == null)
		{
			Debug.LogWarning("[DrillFuelTank] DrillController bulunamadi!");
			return;
		}
		EastUpPlayerItemManager component = player.GetComponent<EastUpPlayerItemManager>();
		CollectableItemData collectableItemData = null;
		if (component != null && component.lastSelectedSlot != null && component.lastSelectedSlot.InventoryItem != null)
		{
			collectableItemData = component.lastSelectedSlot.InventoryItem.collectableItemData;
		}
		int num;
		Color color;
		if (collectableItemData != null)
		{
			num = (drillController.IsFuelItem(collectableItemData) ? 1 : 0);
			if (num != 0)
			{
				color = InteractionPanel.Instance.positiveColor;
				goto IL_008e;
			}
		}
		else
		{
			num = 0;
		}
		color = InteractionPanel.Instance.negativeColor;
		goto IL_008e;
		IL_008e:
		Color value = color;
		string localizedString = GetLocalizedString(addFuelLocalized, "Add Fuel");
		string message = ((num != 0) ? (localizedString + " (" + collectableItemData.GetLocalizedDisplayName() + ")") : localizedString);
		InteractionPanel.Instance.ShowInteractionOverlay(InteractionParent, player.transform, Singleton<UserPrefencesManager>.Instance.keyData.InteractKey, message, hasHoldAction: false, 1f, null, value);
		if (num != 0 && Input.GetKeyDown(Singleton<UserPrefencesManager>.Instance.keyData.InteractKey))
		{
			Debug.Log("[DrillFuelTank] Adding " + collectableItemData.itemName + " to fuel tank");
			if (drillController.TryAddFuel(player, collectableItemData))
			{
				InteractionPanel.Instance.HidePanels();
			}
		}
	}

	public void StopInteract()
	{
		HideFuelUI();
	}

	private void HideFuelUI()
	{
		InteractionPanel.Instance.HidePanels();
	}

	private string GetLocalizedString(LocalizedString localizedString, string fallback)
	{
		if (localizedString != null && !localizedString.IsEmpty)
		{
			string localizedString2 = localizedString.GetLocalizedString();
			if (!string.IsNullOrEmpty(localizedString2))
			{
				return localizedString2;
			}
		}
		return fallback;
	}
}
