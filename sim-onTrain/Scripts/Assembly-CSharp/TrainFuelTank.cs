using UnityEngine;
using UnityEngine.Localization;

public class TrainFuelTank : MonoBehaviour, IInteractable
{
	private TrainController trainController;

	private bool didHideBottomInfo;

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
		trainController = GetComponentInParent<TrainController>();
		if (trainController == null)
		{
			trainController = Object.FindObjectOfType<TrainController>();
		}
	}

	public void Interact(PlayerInventory playerInventory, Vector3 hitPoint)
	{
		if (InteractionPanel.Instance != null && InteractionPanel.Instance.IsBottomInfoLocked)
		{
			InteractionPanel.Instance.UnlockAndHideBottomInfo();
			didHideBottomInfo = true;
		}
		if (trainController == null)
		{
			Debug.LogWarning("[TrainFuelTank] TrainController bulunamadı!");
			return;
		}
		bool flag = trainController.fuelItemQueue.Count < trainController.maxFuelAmount;
		CollectableItemData collectableItemData = null;
		if (flag)
		{
			for (int i = 0; i < trainController.fuelItems.Count; i++)
			{
				if (playerInventory.GetTotalItemCount(trainController.fuelItems[i].item) > 0)
				{
					collectableItemData = trainController.fuelItems[i].item;
					break;
				}
			}
		}
		bool num = collectableItemData != null && flag;
		string localizedString = GetLocalizedString(addFuelLocalized, "Add Fuel");
		Color value = (num ? InteractionPanel.Instance.positiveColor : InteractionPanel.Instance.negativeColor);
		InteractionPanel.Instance.ShowInteractionOverlay(InteractionParent, playerInventory.transform, Singleton<UserPrefencesManager>.Instance.keyData.AddFuelKey, localizedString, hasHoldAction: false, 1f, null, value);
		if (num && Input.GetKeyDown(Singleton<UserPrefencesManager>.Instance.keyData.AddFuelKey))
		{
			trainController.TryAddFuel(collectableItemData, 1);
			playerInventory.AddItemInventory(collectableItemData, -1);
			InteractionPanel.Instance.HidePanels();
			TaskEventManager.OnAddFuelToTrainTaskCompleted.Invoke();
		}
	}

	public void StopInteract()
	{
		HideFuelUI();
		if (didHideBottomInfo)
		{
			didHideBottomInfo = false;
			EastUpPlayerItemManager eastUpPlayerItemManager = Object.FindObjectOfType<EastUpPlayerItemManager>();
			if (eastUpPlayerItemManager != null)
			{
				eastUpPlayerItemManager.UpdateConsumableInteraction();
			}
		}
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
