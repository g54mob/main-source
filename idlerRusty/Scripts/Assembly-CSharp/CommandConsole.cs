using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CommandConsole : MonoBehaviour
{
	public List<TMP_Text> history;

	public TMP_InputField inputField;

	public void LaunchCommand(string value)
	{
		UpdateHistory(value);
		value = value.ToLower();
		if (value == "spareparts")
		{
			Inventory.ins.AddSpareParts(100000);
		}
		if (value == "biofuel")
		{
			Inventory.ins.AddBiofuel(10000);
		}
		if (value == "fossils")
		{
			Inventory.ins.AddFossils(1000);
		}
		if (value == "fertilizer")
		{
			Inventory.ins.AddFertilizer(2000);
		}
		if (value == "crops")
		{
			GameManager.ins.SetCropUnlocked(CropType.Wheat, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Radish, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Cabbage, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Leek, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Carrot, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Celery, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Corn, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Lettuce, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Onion, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Cauliflower, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Potato, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Turnip, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Tomato, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Peas, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Beans, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Eggplant, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Spinach, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Pumpkin, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Broccoli, state: true);
			GameManager.ins.SetCropUnlocked(CropType.RedCabbage, state: true);
			GameManager.ins.SetCropUnlocked(CropType.RedChili, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Parsnip, state: true);
			GameManager.ins.SetCropUnlocked(CropType.RedOnion, state: true);
			GameManager.ins.SetCropUnlocked(CropType.KidneyBeans, state: true);
			GameManager.ins.SetCropUnlocked(CropType.GreenTomato, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Oats, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Garlic, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Beetroot, state: true);
			GameManager.ins.SetCropUnlocked(CropType.RedBellPepper, state: true);
			GameManager.ins.SetCropUnlocked(CropType.YellowBellPepper, state: true);
			GameManager.ins.SetCropUnlocked(CropType.GreenBellPepper, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Watermelon, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Cucumber, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Artichoke, state: true);
			GameManager.ins.SetCropUnlocked(CropType.SweetPotato, state: true);
			GameManager.ins.SetCropUnlocked(CropType.BlackBeans, state: true);
			GameManager.ins.SetCropUnlocked(CropType.BlueGrapes, state: true);
			GameManager.ins.SetCropUnlocked(CropType.RedGrapes, state: true);
			GameManager.ins.SetCropUnlocked(CropType.GreenGrapes, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Rhubarb, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Zucchini, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Kale, state: true);
			Inventory.ins.CheckForUnlockedCrops();
		}
		if (value == "berries")
		{
			GameManager.ins.SetCropUnlocked(CropType.Blackberries, state: true);
			GameManager.ins.SetCropUnlocked(CropType.BlackCurrant, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Blueberries, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Boysenberries, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Cloudberries, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Raspberries, state: true);
			GameManager.ins.SetCropUnlocked(CropType.RedCurrant, state: true);
			GameManager.ins.SetCropUnlocked(CropType.RedGooseberries, state: true);
			GameManager.ins.SetCropUnlocked(CropType.Strawberry, state: true);
			Inventory.ins.CheckForUnlockedCrops();
		}
		if (value == "goldenpumpkin")
		{
			GameManager.ins.spawnGoldenPumpkin = true;
		}
		if (value == "clearsavefile")
		{
			SaveData.ins.ClearSave();
		}
		if (value == "clearplayerprefs")
		{
			SaveData.ins.ClearPlayerPrefs();
		}
		if (value == "unlockmaps")
		{
			SaveData.ins.mapsUnlocked = 100;
		}
		if (value == "sit")
		{
			GameManager.ins.rusty.NeedsRest();
			GameManager.ins.haiku.NeedsRest();
		}
		inputField.text = "";
	}

	private void UpdateHistory(string newValue)
	{
		history[2].text = history[1].text;
		history[1].text = history[0].text;
		history[0].text = newValue;
	}
}
