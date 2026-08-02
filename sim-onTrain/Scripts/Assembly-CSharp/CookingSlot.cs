using UnityEngine;
using UnityEngine.Localization;

public class CookingSlot : MonoBehaviour, IInteractable
{
	[SerializeField]
	private Transform interactionParent;

	private bool isActive = true;

	private GrillController grillController;

	private int slotIndex = -1;

	[Header("Localization")]
	[SerializeField]
	private LocalizedString collectLocalized;

	[SerializeField]
	private bool useSphereCast;

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

	public bool IsActive
	{
		get
		{
			return isActive;
		}
		set
		{
			isActive = value;
		}
	}

	private GrillController GrillController
	{
		get
		{
			if (grillController == null)
			{
				grillController = GetComponentInParent<GrillController>();
			}
			return grillController;
		}
	}

	public bool UseSphereCast => useSphereCast;

	private void Start()
	{
		if (GrillController != null)
		{
			slotIndex = GrillController.GetCookingSlotIndex(this);
		}
	}

	public void Interact(PlayerInventory playerInventory, Vector3 hitPoint)
	{
		if (GrillController == null || slotIndex == -1 || slotIndex >= GrillController.cookingSlots.Count)
		{
			return;
		}
		CookingSlotData cookingSlotData = GrillController.cookingSlots[slotIndex];
		if (!cookingSlotData.isPlaced)
		{
			GrillController.Interact(playerInventory, hitPoint);
		}
		else if (cookingSlotData.isPlaced && cookingSlotData.isCooked)
		{
			InteractionPanel.Instance.ShowInteractionOverlay(base.transform, playerInventory.transform, Singleton<UserPrefencesManager>.Instance.keyData.InteractKey, GetLocalizedString(collectLocalized, "Collect"));
			if (Input.GetKeyDown(Singleton<UserPrefencesManager>.Instance.keyData.InteractKey))
			{
				GrillController.CollectCookedItemFromSlot(playerInventory, slotIndex);
				InteractionPanel.Instance.HideAllInteractions();
			}
		}
	}

	public void StopInteract()
	{
		if (GrillController != null && slotIndex >= 0 && slotIndex < GrillController.cookingSlots.Count)
		{
			if (GrillController.cookingSlots[slotIndex].isPlaced)
			{
				InteractionPanel.Instance.HideAllInteractions();
			}
		}
		else
		{
			InteractionPanel.Instance.HideAllInteractions();
		}
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
