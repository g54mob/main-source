using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
	public static UpgradePanel ins;

	[SerializeField]
	private RectTransform panelObject;

	public Building currentBuildingSelected;

	[Header("Speed stat")]
	[SerializeField]
	private TMP_Text speedStatText;

	[SerializeField]
	private TMP_Text speedUpgradeText;

	[SerializeField]
	private Slider speedCurrentSlider;

	[SerializeField]
	private Slider speedUpgradeSlider;

	[SerializeField]
	private Slider speedFrozenSlider;

	[SerializeField]
	private Button speedUpgradeButton;

	private bool maxSpeed;

	private int speedSparePartsCost;

	private int speedBiofuelCost;

	[Header("Capacity stat")]
	[SerializeField]
	private TMP_Text capacityStatText;

	[SerializeField]
	private TMP_Text capacityUpgradeText;

	[SerializeField]
	private Slider capacityCurrentSlider;

	[SerializeField]
	private Slider capacityUpgradeSlider;

	[SerializeField]
	private Slider capacityFrozenSlider;

	[SerializeField]
	private Button capacityUpgradeButton;

	private bool maxCapacity;

	private int capacitySparePartsCost;

	private int capacityBiofuelCost;

	[Header("Recharge cost stat")]
	[SerializeField]
	private TMP_Text rechargeCostText;

	[Header("Enable / Disable")]
	[SerializeField]
	private Toggle enableDisableToggle;

	[Header("Building name")]
	[SerializeField]
	private TMP_Text buildingNameText;

	private void Awake()
	{
		ins = this;
	}

	private void Start()
	{
		HideUpgradePanel();
		if (!GameManager.ins.qualityUpdate)
		{
			enableDisableToggle.gameObject.SetActive(value: false);
		}
	}

	public void EnableBot(bool value)
	{
		if (currentBuildingSelected != null)
		{
			currentBuildingSelected.SetBuildingToEnabled(value);
		}
	}

	public void SpawnUpgradePanel(int currentSpeedLvl, int currentCapacityLvl, Building buildingScript)
	{
		if (currentBuildingSelected != buildingScript && currentBuildingSelected != null)
		{
			currentBuildingSelected.ShowSelectedIcon(activeState: false);
		}
		currentBuildingSelected = buildingScript;
		currentBuildingSelected.ShowSelectedIcon(activeState: true);
		CheckIfBuildingIsBeingUpgradedAlready(currentSpeedLvl, currentCapacityLvl);
		CheckIfBuildingIsEnabled();
		panelObject.DOComplete();
		panelObject.transform.localScale = new Vector3(1f, 0f, 1f);
		panelObject.DOScaleY(1f, 0.25f).SetEase(Ease.OutBack);
		SetSpeedStats(currentSpeedLvl, buildingScript);
		SetCapacityStats(currentCapacityLvl, buildingScript);
		if (maxCapacity && maxSpeed)
		{
			buildingScript.CheckIfBuildingIsMaxed();
		}
		int biofuelConsumption = buildingScript.getBiofuelConsumption();
		rechargeCostText.text = LocalizationSystem.GetLocalizedValue("_ROBOT_RECHARGE_COST") + " <sprite index=1>" + biofuelConsumption;
		buildingNameText.text = LocalizationSystem.GetLocalizedValue(buildingScript.building.buildName);
		panelObject.gameObject.SetActive(value: true);
	}

	private void CheckIfBuildingIsEnabled()
	{
		if (!(currentBuildingSelected == null))
		{
			enableDisableToggle.SetIsOnWithoutNotify(currentBuildingSelected.buildingEnabled);
		}
	}

	private void CheckIfBuildingIsBeingUpgradedAlready(int currentSpeedLvl, int currentCapacityLvl)
	{
		if (currentBuildingSelected.state == Building.State.IsUpgrading || currentBuildingSelected.state == Building.State.NeedsUpgrading)
		{
			SetButtonsToInteractable(interactable: false);
		}
		else
		{
			SetButtonsToInteractable(interactable: true);
		}
		if (currentBuildingSelected.upgradingSpeed)
		{
			speedUpgradeText.text = LocalizationSystem.GetLocalizedValue("_UPGRADING_BUTTON");
		}
		else
		{
			int incrementalSpeedAmountBasedOn = getIncrementalSpeedAmountBasedOn(currentBuildingSelected.building.buildType);
			speedSparePartsCost = Mathf.CeilToInt((float)currentBuildingSelected.building.speedUpgradeBasePriceSP + Mathf.Pow(incrementalSpeedAmountBasedOn + 1, currentBuildingSelected.building.speedUpgradeCoefficientSP));
			speedBiofuelCost = Mathf.CeilToInt((float)currentBuildingSelected.building.speedUpgradeBasePriceBF + Mathf.Pow(incrementalSpeedAmountBasedOn + 1, currentBuildingSelected.building.speedUpgradeCoefficientBF));
			speedUpgradeText.text = LocalizationSystem.GetLocalizedValue("_UPRADE_BUTTON") + $"<br><sprite index=1>{speedBiofuelCost} <sprite index=0>{speedSparePartsCost}";
		}
		if (currentBuildingSelected.upgradingCapacity)
		{
			capacityUpgradeText.text = LocalizationSystem.GetLocalizedValue("_UPGRADING_BUTTON");
			return;
		}
		int incrementalCapacityAmountBasedOn = getIncrementalCapacityAmountBasedOn(currentBuildingSelected.building.buildType);
		capacitySparePartsCost = Mathf.CeilToInt((float)currentBuildingSelected.building.capacityUpgradeBasePriceSP + Mathf.Pow(incrementalCapacityAmountBasedOn + 1, currentBuildingSelected.building.capacityUpgradeCoefficientSP));
		capacityBiofuelCost = Mathf.CeilToInt((float)currentBuildingSelected.building.capacityUpgradeBasePriceBF + Mathf.Pow(incrementalCapacityAmountBasedOn + 1, currentBuildingSelected.building.capacityUpgradeCoefficientBF));
		capacityUpgradeText.text = LocalizationSystem.GetLocalizedValue("_UPRADE_BUTTON") + $"<br><sprite index=1>{capacityBiofuelCost} <sprite index=0>{capacitySparePartsCost}";
	}

	private int getIncrementalSpeedAmountBasedOn(BuildingType type)
	{
		return type switch
		{
			BuildingType.WaterBot => GameManager.ins.incrWaterBotSpeed, 
			BuildingType.HarvestBot => GameManager.ins.incrHarvestBotSpeed, 
			BuildingType.CarryBot => GameManager.ins.incrCarryBotSpeed, 
			BuildingType.FeederBot => GameManager.ins.incrFeederBotSpeed, 
			BuildingType.WasteBot => GameManager.ins.incrWasteBotSpeed, 
			BuildingType.FertilizerBot => GameManager.ins.incrFertBotSpeed, 
			BuildingType.BerryBot => GameManager.ins.incrBerryBotSpeed, 
			_ => 0, 
		};
	}

	private int getIncrementalCapacityAmountBasedOn(BuildingType type)
	{
		return type switch
		{
			BuildingType.WaterBot => GameManager.ins.incrWaterBotCapacity, 
			BuildingType.HarvestBot => GameManager.ins.incrHarvestBotCapacity, 
			BuildingType.CarryBot => GameManager.ins.incrCarryBotCapacity, 
			BuildingType.FeederBot => GameManager.ins.incrFeederBotCapacity, 
			BuildingType.WasteBot => GameManager.ins.incrWasteBotCapacity, 
			BuildingType.FertilizerBot => GameManager.ins.incrFertBotCapacity, 
			BuildingType.BerryBot => GameManager.ins.incrBerryBotCapacity, 
			_ => 0, 
		};
	}

	private void SetSpeedStats(int currentSpeedLvl, Building b)
	{
		int num = 2;
		int num2 = currentBuildingSelected.building.speedUpgrade.Length;
		speedUpgradeSlider.maxValue = num + num2;
		speedCurrentSlider.maxValue = num + num2;
		if (SaveData.ins.farmType == SaveData.FarmType.WinterSnow)
		{
			int speedFrost = b.building.speedFrost;
			num2 -= speedFrost;
			speedFrozenSlider.maxValue = speedUpgradeSlider.maxValue;
			speedFrozenSlider.value = speedFrost;
		}
		else
		{
			speedFrozenSlider.value = 0f;
		}
		int level = currentBuildingSelected.building.speedUpgrade[currentSpeedLvl].level;
		speedStatText.text = LocalizationSystem.GetLocalizedValue("_SPEED_UPGRADE") + " " + level;
		int num3 = currentSpeedLvl + 1;
		if (num3 >= num2)
		{
			num3 = num2 - 1;
		}
		int num4 = currentBuildingSelected.building.speedUpgrade[num3].level - level;
		if (num4 == 0)
		{
			maxSpeed = true;
			speedUpgradeButton.interactable = false;
			TMP_Text tMP_Text = speedStatText;
			tMP_Text.text = tMP_Text.text + " " + LocalizationSystem.GetLocalizedValue("_MAXED_UPGRADE");
			speedUpgradeText.text = " " + LocalizationSystem.GetLocalizedValue("_MAXED_UPGRADE");
			speedCurrentSlider.value = speedCurrentSlider.maxValue;
			speedUpgradeSlider.value = speedUpgradeSlider.maxValue;
		}
		else
		{
			maxSpeed = false;
			TMP_Text tMP_Text2 = speedStatText;
			tMP_Text2.text = tMP_Text2.text + " (+" + num4 + ")";
			speedCurrentSlider.value = num + currentSpeedLvl + 1;
			speedUpgradeSlider.value = num + currentSpeedLvl + 1 + 1;
		}
	}

	private void SetCapacityStats(int currentCapacityLvl, Building b)
	{
		int num = 2;
		int num2 = currentBuildingSelected.building.capacityUpgrade.Length;
		capacityUpgradeSlider.maxValue = num + num2;
		capacityCurrentSlider.maxValue = num + num2;
		if (SaveData.ins.farmType == SaveData.FarmType.WinterSnow)
		{
			int capacityFrost = b.building.capacityFrost;
			num2 -= capacityFrost;
			capacityFrozenSlider.maxValue = capacityUpgradeSlider.maxValue;
			capacityFrozenSlider.value = capacityFrost;
		}
		else
		{
			capacityFrozenSlider.value = 0f;
		}
		int num3 = currentBuildingSelected.building.capacityUpgrade[currentCapacityLvl].level;
		if (currentBuildingSelected.building.buildType == BuildingType.WaterBot)
		{
			num3 *= GameManager.ins.waterBotCharges;
		}
		TMP_Text tMP_Text = capacityStatText;
		string localizedValue = LocalizationSystem.GetLocalizedValue("_CAPACITY_UPGRADE");
		int num4 = num3;
		tMP_Text.text = localizedValue + " " + num4;
		int num5 = currentCapacityLvl + 1;
		if (num5 >= num2)
		{
			num5 = num2 - 1;
		}
		int num6 = currentBuildingSelected.building.capacityUpgrade[num5].level;
		if (currentBuildingSelected.building.buildType == BuildingType.WaterBot)
		{
			num6 *= GameManager.ins.waterBotCharges;
		}
		int num7 = num6 - num3;
		if (num7 == 0)
		{
			maxCapacity = true;
			capacityUpgradeButton.interactable = false;
			TMP_Text tMP_Text2 = capacityStatText;
			tMP_Text2.text = tMP_Text2.text + " " + LocalizationSystem.GetLocalizedValue("_MAXED_UPGRADE");
			capacityUpgradeText.text = " " + LocalizationSystem.GetLocalizedValue("_MAXED_UPGRADE");
			capacityCurrentSlider.value = capacityCurrentSlider.maxValue;
			capacityUpgradeSlider.value = capacityUpgradeSlider.maxValue;
		}
		else
		{
			maxCapacity = false;
			TMP_Text tMP_Text3 = capacityStatText;
			tMP_Text3.text = tMP_Text3.text + " (+" + num7 + ")";
			capacityCurrentSlider.value = num + currentCapacityLvl + 1;
			capacityUpgradeSlider.value = num + currentCapacityLvl + 1 + 1;
		}
	}

	public void BuildingHasFinishedUpgrading(Building building)
	{
		if (currentBuildingSelected == building)
		{
			SpawnUpgradePanel(building.speedLevel, building.capacityLevel, building);
		}
	}

	public void UpgradeSpeed()
	{
		if (maxSpeed)
		{
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			return;
		}
		if (currentBuildingSelected.state == Building.State.NeedsUpgrading || currentBuildingSelected.state == Building.State.IsUpgrading)
		{
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			return;
		}
		if (Inventory.ins.spareParts < speedSparePartsCost || Inventory.ins.biofuel < speedBiofuelCost)
		{
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			return;
		}
		Inventory.ins.AddSpareParts(-speedSparePartsCost);
		Inventory.ins.AddBiofuel(-speedBiofuelCost);
		speedUpgradeText.text = LocalizationSystem.GetLocalizedValue("_UPGRADING_BUTTON");
		currentBuildingSelected.MarkForUpgrading(speedLvl: true, capacityLvl: false);
		if (currentBuildingSelected.building.buildType == BuildingType.WaterBot)
		{
			GameManager.ins.incrWaterBotSpeed++;
		}
		if (currentBuildingSelected.building.buildType == BuildingType.HarvestBot)
		{
			GameManager.ins.incrHarvestBotSpeed++;
		}
		if (currentBuildingSelected.building.buildType == BuildingType.CarryBot)
		{
			GameManager.ins.incrCarryBotSpeed++;
		}
		if (currentBuildingSelected.building.buildType == BuildingType.FeederBot)
		{
			GameManager.ins.incrFeederBotSpeed++;
		}
		if (currentBuildingSelected.building.buildType == BuildingType.WasteBot)
		{
			GameManager.ins.incrWasteBotSpeed++;
		}
		if (currentBuildingSelected.building.buildType == BuildingType.FertilizerBot)
		{
			GameManager.ins.incrFertBotSpeed++;
		}
		if (currentBuildingSelected.building.buildType == BuildingType.BerryBot)
		{
			GameManager.ins.incrBerryBotSpeed++;
		}
		SetButtonsToInteractable(interactable: false);
	}

	public void UpgradeCapacity()
	{
		if (maxCapacity)
		{
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			return;
		}
		if (currentBuildingSelected.state == Building.State.NeedsUpgrading || currentBuildingSelected.state == Building.State.IsUpgrading)
		{
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			return;
		}
		if (Inventory.ins.spareParts < capacitySparePartsCost || Inventory.ins.biofuel < capacityBiofuelCost)
		{
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			return;
		}
		Inventory.ins.AddSpareParts(-capacitySparePartsCost);
		Inventory.ins.AddBiofuel(-capacityBiofuelCost);
		capacityUpgradeText.text = LocalizationSystem.GetLocalizedValue("_UPGRADING_BUTTON");
		currentBuildingSelected.MarkForUpgrading(speedLvl: false, capacityLvl: true);
		if (currentBuildingSelected.building.buildType == BuildingType.WaterBot)
		{
			GameManager.ins.incrWaterBotCapacity++;
		}
		if (currentBuildingSelected.building.buildType == BuildingType.HarvestBot)
		{
			GameManager.ins.incrHarvestBotCapacity++;
		}
		if (currentBuildingSelected.building.buildType == BuildingType.CarryBot)
		{
			GameManager.ins.incrCarryBotCapacity++;
		}
		if (currentBuildingSelected.building.buildType == BuildingType.FeederBot)
		{
			GameManager.ins.incrFeederBotCapacity++;
		}
		if (currentBuildingSelected.building.buildType == BuildingType.WasteBot)
		{
			GameManager.ins.incrWasteBotCapacity++;
		}
		if (currentBuildingSelected.building.buildType == BuildingType.FertilizerBot)
		{
			GameManager.ins.incrFertBotCapacity++;
		}
		if (currentBuildingSelected.building.buildType == BuildingType.BerryBot)
		{
			GameManager.ins.incrBerryBotCapacity++;
		}
		SetButtonsToInteractable(interactable: false);
	}

	private void SetButtonsToInteractable(bool interactable)
	{
		speedUpgradeButton.interactable = interactable;
		capacityUpgradeButton.interactable = interactable;
		Debug.Log("Set upgrade button interactable to " + interactable);
	}

	public void HideUpgradePanel()
	{
		if (currentBuildingSelected != null)
		{
			currentBuildingSelected.ShowSelectedIcon(activeState: false);
		}
		currentBuildingSelected = null;
		panelObject.gameObject.SetActive(value: false);
	}
}
