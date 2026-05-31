using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsPanel : MonoBehaviour
{
	[SerializeField]
	private TMP_Text totalSPText;

	[SerializeField]
	private TMP_Text totalBFText;

	[SerializeField]
	private TMP_Text totalWateredText;

	[SerializeField]
	private TMP_Text totalHarvestedText;

	[SerializeField]
	private TMP_Text totalBeesText;

	[SerializeField]
	private TMP_Text totalAnimalsText;

	[SerializeField]
	private TMP_Text totalFossilsText;

	[SerializeField]
	private TMP_Text totalWasteText;

	[SerializeField]
	private TMP_Text totalBotsText;

	[SerializeField]
	private TMP_Text totalCropTilesText;

	[SerializeField]
	private TMP_Text timePlayedText;

	[SerializeField]
	private TMP_Text biofuelProductionText;

	[SerializeField]
	private TMP_Text biofuelConsumptionText;

	[SerializeField]
	private StatsCropPanel[] cropStats;

	[SerializeField]
	private List<float> biofuelProductionTimeList;

	[SerializeField]
	private List<int> biofuelProductionValueList;

	[SerializeField]
	private List<float> biofuelConsumptionTimeList;

	[SerializeField]
	private List<int> biofuelConsumptionValueList;

	private void OnEnable()
	{
		UpdateTotalSpareParts(SaveData.ins.total_spare_parts);
		UpdateTotalBiofuel(SaveData.ins.total_biofuel);
		UpdateTotalCropsWatered(SaveData.ins.total_crops_watered);
		UpdateTotalCropsHarvested(SaveData.ins.total_crops_harvested);
		UpdateTotalFossils(SaveData.ins.total_fossils);
		UpdateTotalWaste(SaveData.ins.total_animal_waste);
		UpdateTotalBees();
		UpdateTotalBots();
		UpdateTotalCropTiles();
		UpdateTotalAnimals();
		if ((bool)Inventory.ins)
		{
			UpdateCropStats();
		}
	}

	public void AddBiofuelProduction(int amount, float timeStamp)
	{
		biofuelProductionTimeList.Add(timeStamp);
		biofuelProductionValueList.Add(amount);
		biofuelProductionText.text = CalculateAverageBiofuelProduction().ToString();
	}

	private int CalculateAverageBiofuelProduction()
	{
		int count = 0;
		for (int i = 0; i < biofuelProductionTimeList.Count; i++)
		{
			float num = GameManager.ins.timeElapsed - 300f;
			if (biofuelProductionTimeList[i] < num)
			{
				count = i;
			}
		}
		biofuelProductionTimeList.RemoveRange(0, count);
		biofuelProductionValueList.RemoveRange(0, count);
		int num2 = 0;
		for (int j = 0; j < biofuelProductionValueList.Count; j++)
		{
			num2 += biofuelProductionValueList[j];
		}
		return num2;
	}

	public void AddBiofuelConsumption(int amount, float timeStamp)
	{
		biofuelConsumptionTimeList.Add(timeStamp);
		biofuelConsumptionValueList.Add(amount);
		biofuelConsumptionText.text = CalculateAverageBiofuelConsumption().ToString();
	}

	private int CalculateAverageBiofuelConsumption()
	{
		int count = 0;
		for (int i = 0; i < biofuelConsumptionTimeList.Count; i++)
		{
			float num = GameManager.ins.timeElapsed - 300f;
			if (biofuelConsumptionTimeList[i] < num)
			{
				count = i;
			}
		}
		biofuelConsumptionTimeList.RemoveRange(0, count);
		biofuelConsumptionValueList.RemoveRange(0, count);
		int num2 = 0;
		for (int j = 0; j < biofuelConsumptionValueList.Count; j++)
		{
			num2 += biofuelConsumptionValueList[j];
		}
		return num2;
	}

	public void UpdateTotalSpareParts(long value)
	{
		totalSPText.text = value.ToString();
	}

	public void UpdateTotalBiofuel(long value)
	{
		totalBFText.text = value.ToString();
	}

	public void UpdateTotalCropsWatered(long value)
	{
		totalWateredText.text = value.ToString();
	}

	public void UpdateTotalCropsHarvested(long value)
	{
		totalHarvestedText.text = value.ToString();
	}

	public void UpdateTotalFossils(int value)
	{
		totalFossilsText.text = value.ToString();
	}

	public void UpdateTotalWaste(int value)
	{
		totalWasteText.text = value.ToString();
	}

	public void UpdateTotalBees()
	{
		totalBeesText.text = GameManager.ins.beesButterflies.Count.ToString();
	}

	public void UpdateTotalAnimals()
	{
		totalAnimalsText.text = GameManager.ins.animals.Count.ToString();
	}

	public void UpdateTotalBots()
	{
		totalBotsText.text = GameManager.ins.bots.Count.ToString();
	}

	public void UpdateTotalCropTiles()
	{
		totalCropTilesText.text = GameManager.ins.cropSlots.Count.ToString();
	}

	public void UpdateCropStats()
	{
		int num = 0;
		int count = Inventory.ins.cropAndSeedInventory.Count;
		while (count-- > 0)
		{
			CropSO cropSO = Inventory.ins.cropAndSeedInventory[count].getCropSO();
			int num2 = 0;
			for (int i = 0; i < GameManager.ins.cropSlots.Count; i++)
			{
				if (GameManager.ins.cropSlots[i].cropType == cropSO.cropType)
				{
					num2++;
				}
			}
			for (int j = 0; j < GameManager.ins.berryBushes.Count; j++)
			{
				if (GameManager.ins.berryBushes[j].cropSO.cropType == cropSO.cropType)
				{
					num2++;
				}
			}
			if (num2 > 0)
			{
				cropStats[num].SetCropStatTo(cropSO, num2);
				num++;
				if (num >= cropStats.Length)
				{
					break;
				}
			}
		}
		for (int k = num; k < cropStats.Length; k++)
		{
			cropStats[k].DisableCropStat();
		}
	}
}
