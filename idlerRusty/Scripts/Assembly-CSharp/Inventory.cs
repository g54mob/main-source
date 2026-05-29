using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	public static Inventory ins;

	public int spareParts;

	public List<ResourceInventory> sparePartsInventory;

	public TMP_Text sparePartsHUDText;

	public int biofuel;

	public List<ResourceInventory> biofuelInventory;

	public TMP_Text biofuelHUDText;

	public int fertilizer;

	public TMP_Text fertilizerText;

	public int fossils;

	public TMP_Text fossilsText;

	private Vector2 fossilsTextStartPos;

	private Color fossilsTextStartCol;

	public RectTransform seedsButtonRect;

	public List<PlantSeedButton> cropAndSeedInventory;

	public List<CropSignButton> cropSignsInventory;

	public List<BuildButton> buildingButtons;

	public List<HouseButton> houseButtons;

	[Space]
	public AnimalText cowCostText;

	public List<AnimalButton> cowButtons;

	public AnimalText pigCostText;

	public List<AnimalButton> pigButtons;

	[Space]
	public GameObject[] newCropIcon;

	public GameObject[] newBerryIcon;

	private void Awake()
	{
		ins = this;
	}

	private void Start()
	{
		GameManager.ins.SetCropUnlocked(CropType.Wheat, state: true);
		GameManager.ins.SetCropUnlocked(CropType.Radish, state: true);
		GameManager.ins.SetCropUnlocked(CropType.Cabbage, state: true);
		GameManager.ins.SetCropUnlocked(CropType.Blueberries, state: true);
		if (SaveData.ins.checkIfCrossover(out var crossover) && crossover == CrossoverFarmType.VampireSurvivors)
		{
			GameManager.ins.SetCropUnlocked(CropType.Garlic, state: true);
			cropAndSeedInventory[getCropIndexInInventoryList(CropType.Garlic)].transform.SetSiblingIndex(20);
		}
		if (SaveData.ins.checkIfCrossover(out var _))
		{
			_ = 2;
		}
		InitializeCropStorage();
		InitializeBuildingButtons();
		CheckForUnlockedCrops();
		fossilsTextStartPos = fossilsText.transform.localPosition;
		fossilsTextStartCol = fossilsText.color;
		fossilsText.text = fossils.ToString();
		fertilizerText.text = fertilizer.ToString();
		sparePartsHUDText.text = spareParts.ToString();
		biofuelHUDText.text = biofuel.ToString();
		for (int i = 0; i < sparePartsInventory.Count; i++)
		{
			sparePartsInventory[i].SetAmountTo(spareParts);
		}
		for (int j = 0; j < biofuelInventory.Count; j++)
		{
			biofuelInventory[j].SetAmountTo(biofuel);
		}
	}

	private void InitializeCropStorage()
	{
		for (int i = 0; i < cropAndSeedInventory.Count; i++)
		{
			cropAndSeedInventory[i].Initialize();
		}
		CheckForUnlockedCrops();
	}

	private void InitializeBuildingButtons()
	{
		for (int i = 0; i < buildingButtons.Count; i++)
		{
			buildingButtons[i].Initialize();
		}
	}

	public void SetHouseToBuilt(HouseType type)
	{
		for (int i = 0; i < houseButtons.Count; i++)
		{
			if (houseButtons[i].house.houseType == type)
			{
				houseButtons[i].SetToBuilt();
				break;
			}
		}
	}

	public int getCropIndexInInventoryList(CropType cropType)
	{
		for (int i = 0; i < cropAndSeedInventory.Count; i++)
		{
			if (cropAndSeedInventory[i].cropType == cropType)
			{
				return i;
			}
		}
		return -1;
	}

	public int getCropIndexInCropInventoryPanel(CropType cropType)
	{
		List<PlantSeedButton> list = new List<PlantSeedButton>();
		for (int i = 0; i < cropAndSeedInventory.Count; i++)
		{
			if (!(cropAndSeedInventory[i].bushDecoration != null))
			{
				list.Add(cropAndSeedInventory[i]);
			}
		}
		for (int j = 0; j < list.Count; j++)
		{
			if (list[j].cropType == cropType)
			{
				return j;
			}
		}
		return -1;
	}

	public int getBerryIndexInBerryInventoryPanel(CropType cropType)
	{
		List<PlantSeedButton> list = new List<PlantSeedButton>();
		for (int i = 0; i < cropAndSeedInventory.Count; i++)
		{
			if (!(cropAndSeedInventory[i].bushDecoration == null))
			{
				list.Add(cropAndSeedInventory[i]);
			}
		}
		for (int j = 0; j < list.Count; j++)
		{
			if (list[j].cropType == cropType)
			{
				return j;
			}
		}
		return -1;
	}

	public void AddToCropInventory(CropType crop, int n)
	{
		for (int i = 0; i < cropAndSeedInventory.Count; i++)
		{
			if (cropAndSeedInventory[i].cropType == crop)
			{
				cropAndSeedInventory[i].cropAmount += n;
				cropAndSeedInventory[i].UpdateCropAmountText();
				if (n > 0)
				{
					cropAndSeedInventory[i].AddCropHarvestedToTotalAmount();
				}
			}
			if (n > 0)
			{
				cropAndSeedInventory[i].UpdateRequirementsStatus();
			}
			cropAndSeedInventory[i].CalculateLockedState();
		}
	}

	public int GetCropInventoryQuantity(CropType crop)
	{
		int result = 0;
		for (int i = 0; i < cropAndSeedInventory.Count; i++)
		{
			if (cropAndSeedInventory[i].cropType == crop)
			{
				return cropAndSeedInventory[i].cropAmount;
			}
		}
		return result;
	}

	public void AddToSeedInventory(CropType crop, int n)
	{
		for (int i = 0; i < cropAndSeedInventory.Count; i++)
		{
			if (cropAndSeedInventory[i].cropType == crop)
			{
				cropAndSeedInventory[i].seedAmount += n;
				cropAndSeedInventory[i].UpdateSeedAmountText();
				break;
			}
		}
		CheckForUnlockedCrops();
	}

	public int GetSeedInventoryQuantity(CropType crop)
	{
		int result = 0;
		for (int i = 0; i < cropAndSeedInventory.Count; i++)
		{
			if (cropAndSeedInventory[i].cropType == crop)
			{
				return cropAndSeedInventory[i].seedAmount;
			}
		}
		return result;
	}

	public CropType GetRandomCropFromTheLastX(int X)
	{
		List<CropType> listOfCropsFromTheLastX = GetListOfCropsFromTheLastX(X);
		return listOfCropsFromTheLastX[Random.Range(0, listOfCropsFromTheLastX.Count)];
	}

	public List<CropType> GetListOfCropsFromTheLastX(int X)
	{
		List<CropType> list = new List<CropType>();
		int count = cropAndSeedInventory.Count;
		while (count-- > 0)
		{
			if (!(cropAndSeedInventory[count].bushDecoration != null))
			{
				if (cropAndSeedInventory[count].isUnlocked)
				{
					list.Add(cropAndSeedInventory[count].cropType);
				}
				if (list.Count >= X)
				{
					break;
				}
			}
		}
		return list;
	}

	public List<CropSO> GetListOfCropsWithNoChip()
	{
		List<CropSO> list = new List<CropSO>();
		for (int i = 0; i < cropAndSeedInventory.Count; i++)
		{
			if (!(cropAndSeedInventory[i].bushDecoration != null))
			{
				CropSO cropSO = cropAndSeedInventory[i].getCropSO();
				if (cropAndSeedInventory[i].isUnlocked && GameManager.ins.cropManager.cropGmoStats[cropSO.cropIndexInList].tier == CropManager.GmoTier.None)
				{
					list.Add(cropSO);
				}
			}
		}
		return list;
	}

	public void SpendResourcesForBuilding(BuildingSO building)
	{
		AddSpareParts(-building.spareParts);
		AddBiofuel(-building.biofuel);
	}

	public void AddToBuildingInventory(BuildingSO building, int n)
	{
		if (building.name == "Crop Patch 4x4")
		{
			n *= 16;
		}
		if (building.name == "Crop Patch 3x3")
		{
			n *= 9;
		}
		if (building.name == "Crop Patch 2x2")
		{
			n *= 4;
		}
		if (building.name == "Crop Patch 1x1")
		{
			n *= 2;
		}
		for (int i = 0; i < buildingButtons.Count; i++)
		{
			if (building.buildType == buildingButtons[i].buildingSO.buildType)
			{
				buildingButtons[i].amountBuilt += n;
				buildingButtons[i].UpdateResourceCosts();
			}
		}
	}

	public int getNumberOfBuiltBuildingsInInventory(BuildingType buildingType)
	{
		for (int i = 0; i < buildingButtons.Count; i++)
		{
			if (buildingType == buildingButtons[i].buildingSO.buildType)
			{
				return buildingButtons[i].amountBuilt;
			}
		}
		return 0;
	}

	public void ShowNewCropIcon(bool active)
	{
		for (int i = 0; i < newCropIcon.Length; i++)
		{
			newCropIcon[i].SetActive(active);
		}
	}

	public void ShowNewBerryIcon(bool active)
	{
		for (int i = 0; i < newBerryIcon.Length; i++)
		{
			newBerryIcon[i].SetActive(active);
		}
	}

	public void CheckNewCropBerryIcon()
	{
		for (int i = 0; i < cropAndSeedInventory.Count; i++)
		{
			if (!cropAndSeedInventory[i].isUnlocked && cropAndSeedInventory[i].canUnlock)
			{
				if (cropAndSeedInventory[i].bushDecoration == null)
				{
					ShowNewCropIcon(active: true);
				}
				else
				{
					ShowNewBerryIcon(active: true);
				}
			}
		}
	}

	public void UpdateCropChipIcons()
	{
		for (int i = 0; i < cropAndSeedInventory.Count; i++)
		{
			cropAndSeedInventory[i].UpdateChipIcon();
		}
	}

	public bool checkIfCropAlreadyHasChip(CropSO cropSO)
	{
		for (int i = 0; i < cropAndSeedInventory.Count; i++)
		{
			if (GameManager.ins.cropManager.cropGmoStats[cropSO.cropIndexInList].tier != CropManager.GmoTier.None)
			{
				return true;
			}
		}
		return false;
	}

	public void NotEnoughFossils()
	{
		fossilsText.transform.DOKill();
		fossilsText.transform.localPosition = fossilsTextStartPos;
		fossilsText.transform.DOShakePosition(0.5f, 3f, 20);
		fossilsText.DOKill();
		fossilsText.color = Color.red;
		fossilsText.DOColor(fossilsTextStartCol, 0.5f);
	}

	public void NotEnoughSpareparts()
	{
		for (int i = 0; i < sparePartsInventory.Count; i++)
		{
			sparePartsInventory[i].ShakeText();
			sparePartsInventory[i].RedText();
		}
	}

	public void NotEnoughBiofuel()
	{
		for (int i = 0; i < biofuelInventory.Count; i++)
		{
			biofuelInventory[i].ShakeText();
			biofuelInventory[i].RedText();
		}
	}

	public void AddSpareParts(int amount)
	{
		spareParts += amount;
		sparePartsHUDText.text = spareParts.ToString();
		for (int i = 0; i < sparePartsInventory.Count; i++)
		{
			sparePartsInventory[i].SetAmountTo(spareParts);
		}
		if (amount > 0)
		{
			AchievementManager.ins.EarnSpareParts(amount);
		}
		if (amount > 0)
		{
			AchievementManager.ins.AddSparePartsStat(amount);
		}
		if (amount > 0)
		{
			SaveData.ins.AddTotalSpareParts(amount);
		}
	}

	public void AddBiofuel(int amount)
	{
		biofuel += amount;
		biofuelHUDText.text = biofuel.ToString();
		for (int i = 0; i < biofuelInventory.Count; i++)
		{
			biofuelInventory[i].SetAmountTo(biofuel);
		}
		if (amount > 0)
		{
			AchievementManager.ins.ProduceBiofuel(amount);
		}
		if (amount > 0)
		{
			AchievementManager.ins.AddBiofuelStat(amount);
		}
		if (amount > 0)
		{
			SaveData.ins.AddTotalBiofuel(amount);
		}
	}

	public void AddFertilizer(int amount)
	{
		fertilizer += amount;
		if (fertilizer > 999)
		{
			fertilizer = 999;
		}
		fertilizerText.text = fertilizer.ToString();
		if (amount > 0)
		{
			SaveData.ins.AddTotalWasteCollected(amount);
		}
	}

	public void AddFossils(int amount)
	{
		fossils += amount;
		fossilsText.text = fossils.ToString();
		if (amount > 0)
		{
			SaveData.ins.AddTotalFossils(amount);
		}
	}

	public void RecalculateCowPrices()
	{
		for (int i = 0; i < cowButtons.Count; i++)
		{
			cowButtons[i].UpdateCostTexts();
		}
	}

	public void RecalculatePigPrices()
	{
		for (int i = 0; i < pigButtons.Count; i++)
		{
			pigButtons[i].UpdateCostTexts();
		}
	}

	public int getHighestFossilCost()
	{
		int num = 10;
		for (int i = 0; i < buildingButtons.Count; i++)
		{
			if (buildingButtons[i].getFossilCost() > num)
			{
				num = buildingButtons[i].getFossilCost();
			}
		}
		if (pigButtons[0].getFossilCost() > num)
		{
			num = pigButtons[0].getFossilCost();
		}
		if (cowButtons[0].getFossilCost() > num)
		{
			num = cowButtons[0].getFossilCost();
		}
		return num;
	}

	public void CheckForUnlockedCrops()
	{
		for (int i = 0; i < cropAndSeedInventory.Count; i++)
		{
			cropAndSeedInventory[i].CalculateLockedState();
		}
	}

	public void CheckForUnlockedSigns()
	{
		for (int i = 0; i < cropSignsInventory.Count; i++)
		{
			if (cropSignsInventory[i].isUnlocked)
			{
				continue;
			}
			for (int j = 0; j < cropAndSeedInventory.Count; j++)
			{
				if (cropAndSeedInventory[j].cropType == cropSignsInventory[i].cropSO.cropType)
				{
					if (cropAndSeedInventory[j].isUnlocked)
					{
						cropSignsInventory[i].UnlockCropSign();
					}
					break;
				}
			}
		}
	}

	public void CheckAllCropsUnlocked()
	{
		int num = 0;
		for (int i = 0; i < cropAndSeedInventory.Count; i++)
		{
			if (cropAndSeedInventory[i].isUnlocked)
			{
				if (cropAndSeedInventory[i].cropType == CropType.Wheat)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Radish)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Cabbage)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Leek)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Carrot)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Celery)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Corn)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Lettuce)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Onion)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Cauliflower)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Potato)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Turnip)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Tomato)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Peas)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Beans)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Eggplant)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Spinach)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Pumpkin)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Broccoli)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.RedCabbage)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.RedChili)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Parsnip)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.RedOnion)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.KidneyBeans)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.GreenTomato)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Oats)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Garlic)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Beetroot)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.RedBellPepper)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.YellowBellPepper)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.GreenBellPepper)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Watermelon)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Cucumber)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Artichoke)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.SweetPotato)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.BlackBeans)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.BlueGrapes)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.RedGrapes)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.GreenGrapes)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Rhubarb)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Zucchini)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Kale)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.BlueCorn)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.GreenChiliPepper)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.PurplePotato)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.RedCorn)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Rutabega)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.WhiteBeetroot)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.WhitePumpkin)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Yam)
				{
					num++;
				}
			}
		}
		AchievementManager.ins.CheckUnlockedCrops(num);
	}

	public void CheckAllBerriesUnlocked()
	{
		int num = 0;
		for (int i = 0; i < cropAndSeedInventory.Count; i++)
		{
			if (cropAndSeedInventory[i].isUnlocked)
			{
				if (cropAndSeedInventory[i].cropType == CropType.Blackberries)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.BlackCurrant)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Blueberries)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Boysenberries)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Cloudberries)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Raspberries)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.RedCurrant)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.RedGooseberries)
				{
					num++;
				}
				if (cropAndSeedInventory[i].cropType == CropType.Strawberry)
				{
					num++;
				}
			}
		}
		AchievementManager.ins.CheckUnlockedBerries(num);
	}
}
