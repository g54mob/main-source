using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public BuildingSO buildingSO;

	public int amountBuilt;

	private int sparePartsCost;

	private int biofuelCost;

	private int fossilCost;

	private bool isHoveringOver;

	private bool infoPanelIsOpen;

	[Header("References")]
	[SerializeField]
	private Image buildingIconImage;

	[SerializeField]
	private TMP_Text biofuelResourcesText;

	[SerializeField]
	private TMP_Text sparepartsResourcesText;

	public void Initialize()
	{
		sparePartsCost = buildingSO.spareParts;
		biofuelCost = buildingSO.biofuel;
		UpdateResourceVisuals();
		UpdateResourceCosts();
	}

	private void UpdateResourceVisuals()
	{
		buildingIconImage.sprite = buildingSO.buildImage;
	}

	public void UpdateResourceCosts()
	{
		if (amountBuilt <= 0)
		{
			amountBuilt = 0;
		}
		float num = amountBuilt;
		if (buildingSO.buildType == BuildingType.CropPatch)
		{
			num = (float)amountBuilt / 16f;
		}
		sparePartsCost = Mathf.CeilToInt((float)buildingSO.spareParts + Mathf.Pow((float)buildingSO.sparePartsStartIncrease + num + 1f, buildingSO.sparePartsCoef));
		biofuelCost = Mathf.CeilToInt((float)buildingSO.biofuel + Mathf.Pow((float)buildingSO.biofuelStartIncrease + num + 1f, buildingSO.biofuelCoef));
		if (sparePartsCost > 100)
		{
			sparePartsCost = Mathf.CeilToInt((float)sparePartsCost * 0.1f) * 10;
		}
		if (sparePartsCost > 1000)
		{
			sparePartsCost = Mathf.CeilToInt((float)sparePartsCost * 0.01f) * 100;
		}
		if (sparePartsCost > 10000)
		{
			sparePartsCost = Mathf.CeilToInt((float)sparePartsCost * 0.001f) * 1000;
		}
		if (biofuelCost > 50)
		{
			biofuelCost = Mathf.CeilToInt((float)biofuelCost * 0.1f) * 10;
		}
		if (biofuelCost > 1000)
		{
			biofuelCost = Mathf.CeilToInt((float)biofuelCost * 0.01f) * 100;
		}
		if (biofuelCost > 10000)
		{
			biofuelCost = Mathf.CeilToInt((float)biofuelCost * 0.001f) * 1000;
		}
		if (buildingSO.name == "Crop Patch 3x3")
		{
			sparePartsCost = Mathf.CeilToInt((float)sparePartsCost * 0.5625f);
		}
		if (buildingSO.name == "Crop Patch 2x2")
		{
			sparePartsCost = Mathf.CeilToInt((float)sparePartsCost * 0.25f);
		}
		if (buildingSO.name == "Crop Patch 1x1")
		{
			sparePartsCost = Mathf.CeilToInt((float)sparePartsCost * 0.125f);
		}
		if (buildingSO.name == "Crop Patch 4x4" || buildingSO.name == "Crop Patch 3x3" || buildingSO.name == "Crop Patch 2x2" || buildingSO.name == "Crop Patch 1x1")
		{
			biofuelCost = 0;
		}
		if (buildingSO.buildType == BuildingType.BiofuelConverter && amountBuilt <= 0)
		{
			biofuelCost = 0;
		}
		if ((bool)sparepartsResourcesText)
		{
			sparepartsResourcesText.text = "<sprite index=0>" + sparePartsCost;
		}
		if (biofuelCost > 0)
		{
			if ((bool)biofuelResourcesText)
			{
				biofuelResourcesText.text = "<sprite index=1>" + biofuelCost;
			}
		}
		else if ((bool)biofuelResourcesText)
		{
			biofuelResourcesText.text = "<sprite index=1>0";
		}
		if (buildingSO.hasFossilCost)
		{
			sparePartsCost = 0;
			fossilCost = Mathf.CeilToInt((float)buildingSO.fossilCost + Mathf.Pow((float)buildingSO.fossilStartIncrease + num + 1f, buildingSO.fossilCoef));
			if ((bool)sparepartsResourcesText)
			{
				sparepartsResourcesText.text = "<sprite index=11>" + fossilCost;
			}
		}
	}

	public void SelectBuilding()
	{
		TooltipSystem.HideIcontip();
		TooltipSystem.HideSigntip();
		if (!DoesPlayerHaveResources())
		{
			PlayNegativeFeedback();
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			return;
		}
		GameManager.ins.buildingSelected = buildingSO;
		GameManager.ins.buildingSPCost = sparePartsCost;
		GameManager.ins.buildingBFCost = biofuelCost;
		GameManager.ins.buildingFOCost = fossilCost;
		GameManager.ins.state = GameManager.State.CanBuild;
		SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
	}

	private void PlayNegativeFeedback()
	{
		if (Inventory.ins.spareParts < sparePartsCost)
		{
			Inventory.ins.NotEnoughSpareparts();
		}
		if (Inventory.ins.biofuel < biofuelCost)
		{
			Inventory.ins.NotEnoughBiofuel();
		}
		if (Inventory.ins.fossils < fossilCost)
		{
			Inventory.ins.NotEnoughFossils();
		}
	}

	private bool DoesPlayerHaveResources()
	{
		if (Inventory.ins.spareParts < sparePartsCost)
		{
			return false;
		}
		if (Inventory.ins.biofuel < biofuelCost)
		{
			return false;
		}
		if (Inventory.ins.fossils < fossilCost)
		{
			return false;
		}
		return true;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		isHoveringOver = true;
	}

	private void Update()
	{
		if (isHoveringOver && !infoPanelIsOpen)
		{
			infoPanelIsOpen = true;
			BuildInfoPanel.ins.SetInfo(buildingSO);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		isHoveringOver = false;
		infoPanelIsOpen = false;
		BuildInfoPanel.ins.SetBlank();
	}

	public int getFossilCost()
	{
		return fossilCost;
	}
}
