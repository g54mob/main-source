using System.Collections;
using Steamworks;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
	public static AchievementManager ins;

	private bool unlock_farm_1;

	private bool unlock_farm_2;

	private bool unlock_farm_3;

	private bool unlock_farm_4;

	private bool giant_pumpkin;

	private bool giant_tomato;

	private bool giant_cucumber;

	private bool spin_cog;

	private bool spin_cog_1000;

	private bool echo_house;

	private bool haiku_house;

	private bool sonnet_house;

	private bool splunk_house;

	private bool slate_house;

	private bool forbic_house;

	private bool pinion_house;

	private bool new_crop;

	private bool unlock_10_crops;

	private bool unlock_25_crops;

	private bool all_crops;

	private bool all_berries;

	private bool all_buildings;

	private bool e_15000_spareparts;

	private bool e_50000_spareparts;

	private bool e_250000_spareparts;

	private bool e_1000000_spareparts;

	private bool e_10000000_spareparts;

	private bool unlock_10_cow;

	private bool unlock_10_pig;

	private bool collect_1000_waste;

	private bool place_1_decoration;

	private bool place_25_decoration;

	private bool place_100_decoration;

	private bool p_1000_biofuel;

	private bool p_5000_biofuel;

	private bool p_25000_biofuel;

	private bool p_100000_biofuel;

	private bool p_1000000_biofuel;

	private bool max_waterbot;

	private bool max_harvestbot;

	private bool max_carrybot;

	private bool max_feederbot;

	private bool max_wastebot;

	private bool max_fertilizerbot;

	private bool max_berrybot;

	private bool play_1h;

	private bool play_24h;

	private bool play_48h;

	private bool cover_entire_farm;

	private bool build_every_bot;

	private bool water_million;

	private bool harvest_quarter_million;

	private bool ten_bulb_hives;

	private bool sixsixsix;

	private bool move_building;

	private bool build_10_bioconverters;

	private bool unlock_farm_5;

	private bool get_a_pet;

	private bool get_more_pets;

	private bool unlock_10_chickens;

	private bool giant_white_pumpkin;

	private bool giant_zucchini;

	private bool giant_red_cabbage;

	private bool reaper_house;

	private bool common_gmo;

	private bool rare_gmo;

	private bool legendary_gmo;

	private bool unlock_1_gmo;

	private bool reroll_gmos;

	private bool unlock_10_gmos;

	private bool unlock_25_gmos;

	private bool unlock_all_gmos;

	private int totalNumberOfCrops = 50;

	private int nCows;

	private int nPigs;

	private int nPets;

	private int nChickens;

	private int amountOfDecorations;

	private bool waterbot;

	private bool harvestbot;

	private bool carrybot;

	private bool feederbot;

	private bool wastebot;

	private bool fertbot;

	private bool berrybot;

	private bool storage;

	private bool fertfacility;

	private bool waterwell;

	private bool bulbhive;

	private bool butterflyhouse;

	private bool croppatch1;

	private bool croppatch2;

	private bool croppatch3;

	private bool bench;

	private bool feeder;

	private void Awake()
	{
		ins = this;
		StartCoroutine(GetStats());
	}

	private void SetAchievement(string key)
	{
		if (SteamManager.Initialized)
		{
			SteamUserStats.GetAchievement(key, out var pbAchieved);
			if (!pbAchieved)
			{
				SteamUserStats.SetAchievement(key);
				SteamUserStats.StoreStats();
			}
		}
	}

	private bool GetAchievement(string key)
	{
		if (!SteamManager.Initialized)
		{
			return false;
		}
		SteamUserStats.GetAchievement(key, out var pbAchieved);
		return pbAchieved;
	}

	private IEnumerator GetStats()
	{
		yield return new WaitForSeconds(10f);
		if (SteamManager.Initialized)
		{
			SteamUserStats.RequestGlobalStats(60);
			yield return new WaitForSeconds(10f);
			SteamUserStats.GetGlobalStat("SPARE_PARTS_STAT", out long pData);
			Debug.Log("Global spare parts: " + pData);
			SteamUserStats.GetGlobalStat("BIOFUEL_STAT", out long pData2);
			Debug.Log("Global biofuel: " + pData2);
			SteamUserStats.GetGlobalStat("TOTAL_MINUTES_STAT", out long pData3);
			Debug.Log("Global total minutes played: " + pData3);
			SteamUserStats.GetGlobalStat("GIANT_PUMPKIN_STAT", out long pData4);
			Debug.Log("Global giant pumpkins: " + pData4);
			SteamUserStats.GetGlobalStat("GIANT_TOMATO_STAT", out long pData5);
			Debug.Log("Global giant tomatoes: " + pData5);
			SteamUserStats.GetGlobalStat("GIANT_CUCUMBER_STAT", out long pData6);
			Debug.Log("Global giant cucumbers: " + pData6);
			SteamUserStats.GetGlobalStat("GIANT_GOLDEN_PUMPKIN_STAT", out long pData7);
			Debug.Log("Global giant golden pumpkins: " + pData7);
			SteamUserStats.GetGlobalStat("COWS_STAT", out long pData8);
			Debug.Log("Global cows: " + pData8);
			SteamUserStats.GetGlobalStat("PIGS_STAT", out long pData9);
			Debug.Log("Global pigs: " + pData9);
			SteamUserStats.GetGlobalStat("POOP_COLLECTED_STAT", out long pData10);
			Debug.Log("Global poop collected: " + pData10);
			SteamUserStats.GetGlobalStat("CROPS_HARVESTED_STAT", out long pData11);
			Debug.Log("Global crops harvested: " + pData11);
			SteamUserStats.GetGlobalStat("CROPS_WATERED_STAT", out long pData12);
			Debug.Log("Global crops watered: " + pData12);
			SteamUserStats.GetGlobalStat("_SPENT_ON_DECOR_STAT", out long pData13);
			Debug.Log("Global spent on decor: " + pData13);
		}
	}

	public void SaveStats()
	{
		if (SteamManager.Initialized)
		{
			SteamUserStats.StoreStats();
		}
	}

	public void AddSparePartsStat(int amount)
	{
		if (SteamManager.Initialized)
		{
			SteamUserStats.GetStat("SPARE_PARTS_STAT", out int pData);
			pData += amount;
			if (pData > 15000 && !e_15000_spareparts)
			{
				SetAchievement("E_15000_SPAREPARTS");
				e_15000_spareparts = true;
			}
			if (pData > 50000 && !e_50000_spareparts)
			{
				SetAchievement("E_50000_SPAREPARTS");
				e_50000_spareparts = true;
			}
			if (pData > 250000 && !e_250000_spareparts)
			{
				SetAchievement("E_250000_SPAREPARTS");
				e_250000_spareparts = true;
			}
			if (pData > 1000000 && !e_1000000_spareparts)
			{
				SetAchievement("E_1000000_SPAREPARTS");
				e_1000000_spareparts = true;
			}
			if (pData > 10000000 && !e_10000000_spareparts)
			{
				SetAchievement("E_10000000_SPAREPARTS");
				e_10000000_spareparts = true;
			}
			SteamUserStats.SetStat("SPARE_PARTS_STAT", pData);
		}
	}

	public void AddBiofuelStat(int amount)
	{
		if (SteamManager.Initialized)
		{
			SteamUserStats.GetStat("BIOFUEL_STAT", out int pData);
			pData += amount;
			if (pData > 1000 && !p_1000_biofuel)
			{
				SetAchievement("P_1000_BIOFUEL");
				p_1000_biofuel = true;
			}
			if (pData > 5000 && !p_5000_biofuel)
			{
				SetAchievement("P_5000_BIOFUEL");
				p_5000_biofuel = true;
			}
			if (pData > 25000 && !p_25000_biofuel)
			{
				SetAchievement("P_25000_BIOFUEL");
				p_25000_biofuel = true;
			}
			if (pData > 100000 && !p_100000_biofuel)
			{
				SetAchievement("P_100000_BIOFUEL");
				p_100000_biofuel = true;
			}
			if (pData > 1000000 && !p_1000000_biofuel)
			{
				SetAchievement("P_1000000_BIOFUEL");
				p_1000000_biofuel = true;
			}
			SteamUserStats.SetStat("BIOFUEL_STAT", pData);
		}
	}

	public void AddPoopStat(int amount)
	{
		if (SteamManager.Initialized)
		{
			SteamUserStats.GetStat("POOP_COLLECTED_STAT", out int pData);
			pData += amount;
			SteamUserStats.SetStat("POOP_COLLECTED_STAT", pData);
		}
	}

	public void AddWateredStat(int amount)
	{
		if (SteamManager.Initialized)
		{
			SteamUserStats.GetStat("CROPS_WATERED_STAT", out int pData);
			pData += amount;
			if (pData >= 1000000)
			{
				SetAchievement("WATER_MILLION");
			}
			SteamUserStats.SetStat("CROPS_WATERED_STAT", pData);
		}
	}

	public void AddHarvestStat(int amount)
	{
		if (SteamManager.Initialized)
		{
			SteamUserStats.GetStat("CROPS_HARVESTED_STAT", out int pData);
			pData += amount;
			if (pData >= 250000)
			{
				SetAchievement("HARVEST_QUARTER_MILLION");
			}
			SteamUserStats.SetStat("CROPS_HARVESTED_STAT", pData);
		}
	}

	public void AddAnimalStat(AnimalSO animal, int amount)
	{
		if (SteamManager.Initialized)
		{
			string pchName = "";
			if (animal.animalName == "Cow")
			{
				pchName = "COWS_STAT";
			}
			if (animal.animalName == "Pig")
			{
				pchName = "PIGS_STAT";
			}
			SteamUserStats.GetStat(pchName, out int pData);
			pData += amount;
			SteamUserStats.SetStat(pchName, pData);
		}
	}

	public void SpentOnDecorStat(int SPamount, int BFamount)
	{
		if (SteamManager.Initialized)
		{
			SteamUserStats.GetStat("_SPENT_ON_DECOR_STAT", out int pData);
			pData += SPamount;
			pData += BFamount * 10;
			SteamUserStats.SetStat("_SPENT_ON_DECOR_STAT", pData);
		}
	}

	public void AddGiantCropStat(CropType type, int amount)
	{
		if (SteamManager.Initialized)
		{
			string pchName = "";
			if (type == CropType.Pumpkin)
			{
				pchName = "GIANT_PUMPKIN_STAT";
			}
			if (type == CropType.Tomato)
			{
				pchName = "GIANT_TOMATO_STAT";
			}
			if (type == CropType.Cucumber)
			{
				pchName = "GIANT_CUCUMBER_STAT";
			}
			if (type == CropType.GoldenGiantPumpkin)
			{
				pchName = "GIANT_GOLDEN_PUMPKIN_STAT";
			}
			SteamUserStats.GetStat(pchName, out int pData);
			pData += amount;
			SteamUserStats.SetStat(pchName, pData);
		}
	}

	public void AddUpdateTotalTimeStat(float value)
	{
		if (SteamManager.Initialized)
		{
			value = (int)(value / 60f);
			SteamUserStats.SetStat("TOTAL_MINUTES_STAT", value);
		}
	}

	public void CheckTimer(float timeElapsed)
	{
		if (SteamManager.Initialized)
		{
			if (timeElapsed > 3600f && !play_1h)
			{
				SetAchievement("PLAY_1H");
				play_1h = true;
			}
			if (timeElapsed > 86400f && !play_24h)
			{
				SetAchievement("PLAY_24H");
				play_24h = true;
			}
			if (timeElapsed > 172800f && !play_48h)
			{
				SetAchievement("PLAY_48H");
				play_48h = true;
			}
		}
	}

	public void SpinCog()
	{
		SaveData.ins.global_cogs_spins++;
		if (SteamManager.Initialized)
		{
			if (SaveData.ins.global_cogs_spins > 0 && !spin_cog)
			{
				SetAchievement("SPIN_COG");
				spin_cog = true;
			}
			if (SaveData.ins.global_cogs_spins >= 1000 && !spin_cog_1000)
			{
				SetAchievement("SPIN_COG_1000");
				spin_cog_1000 = true;
			}
		}
	}

	public void UnlockFarm(int farmType)
	{
		if (SteamManager.Initialized)
		{
			if (farmType >= 1 && !unlock_farm_1)
			{
				SetAchievement("UNLOCK_FARM_1");
				unlock_farm_1 = true;
			}
			if (farmType >= 2 && !unlock_farm_2)
			{
				SetAchievement("UNLOCK_FARM_2");
				unlock_farm_2 = true;
			}
			if (farmType >= 3 && !unlock_farm_3)
			{
				SetAchievement("UNLOCK_FARM_3");
				unlock_farm_3 = true;
			}
			if (farmType >= 4 && !unlock_farm_4)
			{
				SetAchievement("UNLOCK_FARM_4");
				unlock_farm_4 = true;
			}
			if (farmType >= 5 && !unlock_farm_5)
			{
				SetAchievement("UNLOCK_FARM_5");
				unlock_farm_5 = true;
			}
		}
	}

	public int CheckFarmUnlocks()
	{
		if (!SteamManager.Initialized)
		{
			return 0;
		}
		int num = 0;
		if (GetAchievement("UNLOCK_FARM_1"))
		{
			num++;
		}
		if (GetAchievement("UNLOCK_FARM_2"))
		{
			num++;
		}
		if (GetAchievement("UNLOCK_FARM_3"))
		{
			num++;
		}
		if (GetAchievement("UNLOCK_FARM_4"))
		{
			num++;
		}
		return num;
	}

	public void GrowGiantCrop(CropType crop)
	{
		if (SteamManager.Initialized)
		{
			if (crop == CropType.Pumpkin && !giant_pumpkin)
			{
				SetAchievement("GIANT_PUMPKIN");
				giant_pumpkin = true;
			}
			if (crop == CropType.Tomato && !giant_tomato)
			{
				SetAchievement("GIANT_TOMATO");
				giant_tomato = true;
			}
			if (crop == CropType.Cucumber && !giant_cucumber)
			{
				SetAchievement("GIANT_CUCUMBER");
				giant_cucumber = true;
			}
			if (crop == CropType.WhitePumpkin && !giant_white_pumpkin)
			{
				SetAchievement("GIANT_WHITE_PUMPKIN");
				giant_white_pumpkin = true;
			}
			if (crop == CropType.Zucchini && !giant_zucchini)
			{
				SetAchievement("GIANT_ZUCCHINI");
				giant_zucchini = true;
			}
			if (crop == CropType.RedCabbage && !giant_red_cabbage)
			{
				SetAchievement("GIANT_RED_CABBAGE");
				giant_red_cabbage = true;
			}
		}
	}

	public void BuildHouse(House house)
	{
		if (SteamManager.Initialized)
		{
			if (house.houseType == HouseType.HaikuHouse && !haiku_house)
			{
				SetAchievement("HAIKU_HOUSE");
				haiku_house = true;
			}
			if (house.houseType == HouseType.SonnetShop && !sonnet_house)
			{
				SetAchievement("SONNET_HOUSE");
				sonnet_house = true;
			}
			if (house.houseType == HouseType.PinionHouse && !pinion_house)
			{
				SetAchievement("PINION_HOUSE");
				pinion_house = true;
			}
			if (house.houseType == HouseType.ForbicHouse && !forbic_house)
			{
				SetAchievement("FORBIC_HOUSE");
				forbic_house = true;
			}
			if (house.houseType == HouseType.EchoHouse && !echo_house)
			{
				SetAchievement("ECHO_HOUSE");
				echo_house = true;
			}
			if (house.houseType == HouseType.SlateBarn && !slate_house)
			{
				SetAchievement("SLATE_HOUSE");
				slate_house = true;
			}
			if (house.houseType == HouseType.SplunkHouse && !splunk_house)
			{
				SetAchievement("SPLUNK_HOUSE");
				splunk_house = true;
			}
			if (house.houseType == HouseType.ReaperShop && !reaper_house)
			{
				SetAchievement("REAPER_HOUSE");
				reaper_house = true;
			}
		}
	}

	public void CheckUnlockedCrops(int amount)
	{
		if (SteamManager.Initialized)
		{
			if (amount >= 4 && !new_crop)
			{
				SetAchievement("NEW_CROP");
				new_crop = true;
			}
			if (amount >= 10 && !unlock_10_crops)
			{
				SetAchievement("UNLOCK_10_CROPS");
				unlock_10_crops = true;
			}
			if (amount >= 25 && !unlock_25_crops)
			{
				SetAchievement("UNLOCK_25_CROPS");
				unlock_25_crops = true;
			}
			if (amount >= totalNumberOfCrops && !all_crops)
			{
				SetAchievement("ALL_CROPS");
				all_crops = true;
			}
		}
	}

	private int getNumberOfCropsWithGMOs()
	{
		int num = 0;
		for (int i = 0; i < GameManager.ins.cropManager.cropGmoStats.Length; i++)
		{
			if (GameManager.ins.cropManager.cropGmoStats[i].tier != CropManager.GmoTier.None)
			{
				num++;
			}
		}
		return num;
	}

	public void CheckGMOsOnCrops()
	{
		if (SteamManager.Initialized)
		{
			int numberOfCropsWithGMOs = getNumberOfCropsWithGMOs();
			if (numberOfCropsWithGMOs >= 1 && !unlock_1_gmo)
			{
				SetAchievement("UNLOCK_1_GMO");
				unlock_1_gmo = true;
			}
			if (numberOfCropsWithGMOs >= 10 && !unlock_10_gmos)
			{
				SetAchievement("UNLOCK_10_GMOS");
				unlock_10_gmos = true;
			}
			if (numberOfCropsWithGMOs >= 25 && !unlock_25_gmos)
			{
				SetAchievement("UNLOCK_25_GMOS");
				unlock_25_gmos = true;
			}
			if (numberOfCropsWithGMOs >= totalNumberOfCrops && !unlock_all_gmos)
			{
				SetAchievement("UNLOCK_ALL_GMOS");
				unlock_all_gmos = true;
			}
		}
	}

	public void CheckUnlockedBerries(int amount)
	{
		if (SteamManager.Initialized && amount >= 9 && !all_berries)
		{
			SetAchievement("ALL_BERRIES");
			all_berries = true;
		}
	}

	public void EarnSpareParts(int amount)
	{
		SaveData.ins.global_spareparts_earned += amount;
		if (SteamManager.Initialized)
		{
			if (SaveData.ins.global_spareparts_earned > 15000 && !e_15000_spareparts)
			{
				SetAchievement("E_15000_SPAREPARTS");
				e_15000_spareparts = true;
			}
			if (SaveData.ins.global_spareparts_earned > 50000 && !e_50000_spareparts)
			{
				SetAchievement("E_50000_SPAREPARTS");
				e_50000_spareparts = true;
			}
			if (SaveData.ins.global_spareparts_earned > 250000 && !e_250000_spareparts)
			{
				SetAchievement("E_250000_SPAREPARTS");
				e_250000_spareparts = true;
			}
			if (SaveData.ins.global_spareparts_earned > 1000000 && !e_1000000_spareparts)
			{
				SetAchievement("E_1000000_SPAREPARTS");
				e_1000000_spareparts = true;
			}
			if (SaveData.ins.global_spareparts_earned > 10000000 && !e_10000000_spareparts)
			{
				SetAchievement("E_10000000_SPAREPARTS");
				e_10000000_spareparts = true;
			}
			if (SaveData.ins.total_spare_parts > 15000 && !e_15000_spareparts)
			{
				SetAchievement("E_15000_SPAREPARTS");
				e_15000_spareparts = true;
			}
			if (SaveData.ins.total_spare_parts > 50000 && !e_50000_spareparts)
			{
				SetAchievement("E_50000_SPAREPARTS");
				e_50000_spareparts = true;
			}
			if (SaveData.ins.total_spare_parts > 250000 && !e_250000_spareparts)
			{
				SetAchievement("E_250000_SPAREPARTS");
				e_250000_spareparts = true;
			}
			if (SaveData.ins.total_spare_parts > 1000000 && !e_1000000_spareparts)
			{
				SetAchievement("E_1000000_SPAREPARTS");
				e_1000000_spareparts = true;
			}
			if (SaveData.ins.total_spare_parts > 10000000 && !e_10000000_spareparts)
			{
				SetAchievement("E_10000000_SPAREPARTS");
				e_10000000_spareparts = true;
			}
		}
	}

	public void ProduceBiofuel(int amount)
	{
		SaveData.ins.global_biofuel_produced += amount;
		if (SteamManager.Initialized)
		{
			if (SaveData.ins.global_biofuel_produced > 1000 && !p_1000_biofuel)
			{
				SetAchievement("P_1000_BIOFUEL");
				p_1000_biofuel = true;
			}
			if (SaveData.ins.global_biofuel_produced > 5000 && !p_5000_biofuel)
			{
				SetAchievement("P_5000_BIOFUEL");
				p_5000_biofuel = true;
			}
			if (SaveData.ins.global_biofuel_produced > 25000 && !p_25000_biofuel)
			{
				SetAchievement("P_25000_BIOFUEL");
				p_25000_biofuel = true;
			}
			if (SaveData.ins.global_biofuel_produced > 100000 && !p_100000_biofuel)
			{
				SetAchievement("P_100000_BIOFUEL");
				p_100000_biofuel = true;
			}
			if (SaveData.ins.global_biofuel_produced > 1000000 && !p_1000000_biofuel)
			{
				SetAchievement("P_1000000_BIOFUEL");
				p_1000000_biofuel = true;
			}
			if (SaveData.ins.total_biofuel > 1000 && !p_1000_biofuel)
			{
				SetAchievement("P_1000_BIOFUEL");
				p_1000_biofuel = true;
			}
			if (SaveData.ins.total_biofuel > 5000 && !p_5000_biofuel)
			{
				SetAchievement("P_5000_BIOFUEL");
				p_5000_biofuel = true;
			}
			if (SaveData.ins.total_biofuel > 25000 && !p_25000_biofuel)
			{
				SetAchievement("P_25000_BIOFUEL");
				p_25000_biofuel = true;
			}
			if (SaveData.ins.total_biofuel > 100000 && !p_100000_biofuel)
			{
				SetAchievement("P_100000_BIOFUEL");
				p_100000_biofuel = true;
			}
			if (SaveData.ins.total_biofuel > 1000000 && !p_1000000_biofuel)
			{
				SetAchievement("P_1000000_BIOFUEL");
				p_1000000_biofuel = true;
			}
		}
	}

	public void MaxedBot(BuildingType build)
	{
		if (SteamManager.Initialized)
		{
			if (build == BuildingType.BerryBot && !max_berrybot)
			{
				SetAchievement("MAX_BERRYBOT");
				max_berrybot = true;
			}
			if (build == BuildingType.WaterBot && !max_waterbot)
			{
				SetAchievement("MAX_WATERBOT");
				max_waterbot = true;
			}
			if (build == BuildingType.HarvestBot && !max_harvestbot)
			{
				SetAchievement("MAX_HARVESTBOT");
				max_harvestbot = true;
			}
			if (build == BuildingType.CarryBot && !max_carrybot)
			{
				SetAchievement("MAX_CARRYBOT");
				max_carrybot = true;
			}
			if (build == BuildingType.FeederBot && !max_feederbot)
			{
				SetAchievement("MAX_FEEDERBOT");
				max_feederbot = true;
			}
			if (build == BuildingType.WasteBot && !max_wastebot)
			{
				SetAchievement("MAX_WASTEBOT");
				max_wastebot = true;
			}
			if (build == BuildingType.FertilizerBot && !max_fertilizerbot)
			{
				SetAchievement("MAX_FERTILIZERBOT");
				max_fertilizerbot = true;
			}
		}
	}

	public void PlaceAnimal(AnimalSO animal)
	{
		if (animal.animalName == "Cow")
		{
			nCows++;
		}
		if (animal.animalName == "Pig")
		{
			nPigs++;
		}
		if (SteamManager.Initialized)
		{
			if (animal.animalName == "Cow" && !unlock_10_cow && nCows >= 10)
			{
				SetAchievement("UNLOCK_10_COW");
				unlock_10_cow = true;
			}
			if (animal.animalName == "Pig" && !unlock_10_pig && nPigs >= 10)
			{
				SetAchievement("UNLOCK_10_PIG");
				unlock_10_pig = true;
			}
		}
	}

	public void PlaceAnimal(BuildingType animal)
	{
		if (animal == BuildingType.PetHouse)
		{
			nPets++;
		}
		if (animal == BuildingType.ChickenNest)
		{
			nChickens++;
		}
		if (SteamManager.Initialized)
		{
			if (animal == BuildingType.PetHouse && !get_a_pet && nPets >= 1)
			{
				SetAchievement("GET_A_PET");
				get_a_pet = true;
			}
			if (animal == BuildingType.PetHouse && !get_more_pets && nPets >= 4)
			{
				SetAchievement("GET_MORE_PETS");
				get_more_pets = true;
			}
			if (animal == BuildingType.ChickenNest && !unlock_10_chickens && nChickens >= 10)
			{
				SetAchievement("UNLOCK_10_CHICKENS");
				unlock_10_chickens = true;
			}
		}
	}

	public void RemoveAnimal(BuildingType animal)
	{
		if (animal == BuildingType.PetHouse)
		{
			nPets--;
		}
		if (animal == BuildingType.ChickenNest)
		{
			nChickens--;
		}
		if (nPets < 0)
		{
			nPets = 0;
		}
		if (nChickens < 0)
		{
			nChickens = 0;
		}
	}

	public void CollectWaste(int amount)
	{
		if (SteamManager.Initialized && SaveData.ins.total_animal_waste > 1000 && !collect_1000_waste)
		{
			SetAchievement("COLLECT_1000_WASTE");
			collect_1000_waste = true;
		}
	}

	public void Water1MillionCrops()
	{
		if (SteamManager.Initialized)
		{
			if (SaveData.ins.global_watered_crops > 1000000)
			{
				SetAchievement("WATER_MILLION");
			}
			if (SaveData.ins.total_crops_watered > 1000000)
			{
				SetAchievement("WATER_MILLION");
			}
		}
	}

	public void Harvest1MillionCrops()
	{
		if (SteamManager.Initialized)
		{
			if (SaveData.ins.global_harvested_crops > 250000)
			{
				SetAchievement("HARVEST_QUARTER_MILLION");
			}
			if (SaveData.ins.total_crops_harvested > 250000)
			{
				SetAchievement("HARVEST_QUARTER_MILLION");
			}
		}
	}

	public void PlaceDecoration()
	{
		amountOfDecorations++;
		if (SteamManager.Initialized)
		{
			if (amountOfDecorations >= 1 && !place_1_decoration)
			{
				SetAchievement("PLACE_1_DECORATION");
				place_1_decoration = true;
			}
			if (amountOfDecorations >= 25 && !place_25_decoration)
			{
				SetAchievement("PLACE_25_DECORATION");
				place_25_decoration = true;
			}
			if (amountOfDecorations >= 100 && !place_100_decoration)
			{
				SetAchievement("PLACE_100_DECORATION");
				place_100_decoration = true;
			}
		}
	}

	public void CheckIfEntireFarmCovered()
	{
		if (!SteamManager.Initialized)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		if (cover_entire_farm)
		{
			return;
		}
		for (int i = 0; i < GridSystem.ins.gridSize.x; i++)
		{
			for (int j = 0; j < GridSystem.ins.gridSize.y; j++)
			{
				num++;
				if (GridSystem.ins.tile[i, j].occupied)
				{
					num2++;
				}
			}
		}
		if (num2 >= num - 1)
		{
			SetAchievement("COVER_ENTIRE_FARM");
			cover_entire_farm = true;
		}
	}

	public void BuildEveryBot(string botname)
	{
		if (!build_every_bot)
		{
			if (botname == "water")
			{
				waterbot = true;
			}
			if (botname == "harvest")
			{
				harvestbot = true;
			}
			if (botname == "carry")
			{
				carrybot = true;
			}
			if (botname == "feeder")
			{
				feederbot = true;
			}
			if (botname == "waste")
			{
				wastebot = true;
			}
			if (botname == "fert")
			{
				fertbot = true;
			}
			if (botname == "berry")
			{
				berrybot = true;
			}
			if (waterbot && harvestbot && carrybot && feederbot && wastebot && fertbot && berrybot && SteamManager.Initialized)
			{
				SetAchievement("BUILD_EVERY_BOT");
				build_every_bot = true;
			}
		}
	}

	public void BuildAllBuildings(string buildname)
	{
		if (!all_buildings && waterbot && harvestbot && carrybot && feederbot && wastebot && fertbot && berrybot)
		{
			if (buildname == "Bench 2x1")
			{
				bench = true;
			}
			if (buildname == "ButterflyHouse 1x2")
			{
				butterflyhouse = true;
			}
			if (buildname == "Crop Patch 1x1")
			{
				croppatch1 = true;
			}
			if (buildname == "Crop Patch 2x2")
			{
				croppatch2 = true;
			}
			if (buildname == "Crop Patch 3x3")
			{
				croppatch3 = true;
			}
			if (buildname == "Feeder 3x3")
			{
				feeder = true;
			}
			if (buildname == "Beehive 1x2")
			{
				bulbhive = true;
			}
			if (buildname == "Storage 2x2")
			{
				storage = true;
			}
			if (buildname == "Waste Storage 2x2")
			{
				fertfacility = true;
			}
			if (buildname == "Well 2x2")
			{
				waterwell = true;
			}
			if (bench && butterflyhouse && croppatch1 && croppatch2 && croppatch3 && feeder && bulbhive && storage && fertfacility && waterwell && SteamManager.Initialized)
			{
				SetAchievement("ALL_BUILDINGS");
				all_buildings = true;
			}
		}
	}

	public void PlaceBulbHives()
	{
		if (SteamManager.Initialized && GameManager.ins.beehives.Count >= 10 && !ten_bulb_hives)
		{
			SetAchievement("TEN_BULB_HIVES");
			ten_bulb_hives = true;
		}
	}

	public void PlaceCropSlots()
	{
		if (SteamManager.Initialized && GameManager.ins.cropSlots.Count >= 666 && !sixsixsix)
		{
			SetAchievement("SIXSIXSIX");
			sixsixsix = true;
		}
	}

	public void BuildBiofuelConverters()
	{
		if (SteamManager.Initialized && GameManager.ins.bioConverters.Count >= 10 && !build_10_bioconverters)
		{
			SetAchievement("BUILD_10_BIOCONVERTERS");
			build_10_bioconverters = true;
		}
	}

	public void MoveABuilding()
	{
		if (SteamManager.Initialized && !move_building)
		{
			SetAchievement("MOVE_BUILDING");
			move_building = true;
		}
	}

	public void BuyGMO(CropManager.GmoTier rarity)
	{
		if (SteamManager.Initialized)
		{
			if (rarity == CropManager.GmoTier.Common && !common_gmo)
			{
				SetAchievement("COMMON_GMO");
				common_gmo = true;
			}
			if (rarity == CropManager.GmoTier.Rare && !rare_gmo)
			{
				SetAchievement("RARE_GMO");
				rare_gmo = true;
			}
			if (rarity == CropManager.GmoTier.Legendary && !legendary_gmo)
			{
				SetAchievement("LEGENDARY_GMO");
				legendary_gmo = true;
			}
		}
	}

	public void RerollAllGMOs()
	{
		if (SteamManager.Initialized && !reroll_gmos)
		{
			SetAchievement("REROLL_GMOS");
			reroll_gmos = true;
		}
	}
}
