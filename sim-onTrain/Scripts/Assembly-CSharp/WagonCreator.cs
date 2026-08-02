using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class WagonCreator : MonoBehaviour, IInteractable
{
	public WagonController connectedWagon;

	public CollectableItemData wagonData;

	public GameObject wagonInfoCanvas;

	private List<CraftNeededPartUI> neededParts = new List<CraftNeededPartUI>();

	private bool isActive = true;

	private bool isInteracting;

	private TSPlayerController player;

	[SerializeField]
	private TextMeshProUGUI interactText;

	private bool isCanvasActive;

	private bool isPanelSet;

	[SerializeField]
	private Transform interactionParent;

	private bool isLastWagon;

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

	private void Start()
	{
		wagonInfoCanvas.SetActive(value: false);
		neededParts = GetComponentsInChildren<CraftNeededPartUI>(includeInactive: true).ToList();
		CheckIfLastWagon();
	}

	private void CheckIfLastWagon()
	{
		TrainController componentInParent = GetComponentInParent<TrainController>();
		if (!(componentInParent != null) || !(connectedWagon != null))
		{
			return;
		}
		int num = componentInParent.wagonControllers.Count - 1;
		if (num >= 0)
		{
			WagonController wagonController = componentInParent.wagonControllers[num];
			isLastWagon = wagonController == connectedWagon;
			isActive = isLastWagon;
			if (!isLastWagon)
			{
				StopInteract();
			}
		}
	}

	public void SetAsLastWagon(bool isLast)
	{
		isLastWagon = isLast;
		isActive = isLast;
		if (!isLast)
		{
			StopInteract();
		}
	}

	public void Interact(PlayerInventory playerInventory, Vector3 hitPoint)
	{
		if (!isLastWagon || !isActive)
		{
			return;
		}
		isInteracting = true;
		if (!isCanvasActive)
		{
			wagonInfoCanvas.SetActive(value: true);
		}
		isCanvasActive = true;
		if (Input.GetKeyDown(Singleton<UserPrefencesManager>.Instance.keyData.InteractKey) && TrainBuildManager.Instance != null)
		{
			TrainBuildManager.Instance.CmdRequestAddWagon(wagonData?.itemName ?? "Wagon");
		}
		if (isPanelSet)
		{
			return;
		}
		interactText.SetText("Press " + Singleton<UserPrefencesManager>.Instance.keyData.InteractKey.ToString() + " To Add A New Wagon");
		isPanelSet = true;
		int num = 0;
		foreach (CraftNeededPartUI neededPart in neededParts)
		{
			if (num < wagonData.costData.Count)
			{
				CostData currentData = wagonData.costData[num];
				int inventoryCount = playerInventory.inventoryData.Find((PlayerInventoryData x) => currentData.item == x.item)?.itemCollectedCount ?? 0;
				neededPart.SetPanel(wagonData.costData[num], inventoryCount);
				neededPart.gameObject.SetActive(value: true);
			}
			else
			{
				neededPart.gameObject.SetActive(value: false);
			}
			num++;
		}
	}

	public void StopInteract()
	{
		isPanelSet = false;
		isCanvasActive = false;
		isInteracting = false;
		wagonInfoCanvas.SetActive(value: false);
	}
}
