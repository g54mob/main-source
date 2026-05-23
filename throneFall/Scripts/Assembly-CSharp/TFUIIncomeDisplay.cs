using System.Collections.Generic;
using I2.Loc;
using TMPro;

public class TFUIIncomeDisplay : TFUIPerklike
{
	public TextMeshProUGUI displayNumber;

	private int iFromBuildings;

	private int iFromInterest;

	private int iFromBuildersGuild;

	private int iFromTreasureHunter;

	private int iFromEnemies;

	private int currentIncome;

	public int CurrentIncome => currentIncome;

	public string GetTitle()
	{
		return LocalizationManager.GetTranslation("Menu/Gold Income");
	}

	public string GetDescription()
	{
		string text = "";
		text += "\n";
		text = text + LocalizationManager.GetTranslation("Menu/Income From Buildings") + " <sprite name=arrow_right> <sprite name=coin><style=Body Numerals>" + iFromBuildings + "</style>";
		text += "\n";
		if (iFromBuildersGuild > 0)
		{
			text = text + LocalizationManager.GetTranslation("Building/Castle Center Choice Builder's Guild") + " <sprite name=arrow_right> <sprite name=coin><style=Body Numerals>" + iFromBuildersGuild + "</style>";
			text += "\n";
		}
		if (iFromTreasureHunter > 0)
		{
			text = text + LocalizationManager.GetTranslation("Equippable/Treasure Hunter") + " <sprite name=arrow_right> <sprite name=coin><style=Body Numerals>" + iFromTreasureHunter + "</style>";
			text += "\n";
		}
		if (iFromInterest > 0)
		{
			text = text + LocalizationManager.GetTranslation("Equippable/Interest") + " <sprite name=arrow_right> <sprite name=coin><style=Body Numerals>" + iFromInterest + "</style>";
			text += "\n";
		}
		text = text + LocalizationManager.GetTranslation("Menu/Income From Enemies") + " <sprite name=arrow_right> <sprite name=coin><style=Body Numerals>" + iFromEnemies + "</style>";
		return text + "\n";
	}

	public void UpdateData(int wavenumber)
	{
		List<TaggedObject> list = new List<TaggedObject>();
		List<BuildSlot> list2 = new List<BuildSlot>();
		BuildSlot buildSlot = null;
		TagManager.instance.FindAllTaggedObjectsWithTag(list, TagManager.ETag.Building);
		foreach (TaggedObject item in list)
		{
			buildSlot = item.GetComponentInParent<BuildSlot>();
			if ((bool)buildSlot && buildSlot.State == BuildSlot.BuildingState.Built)
			{
				list2.Add(buildSlot);
			}
		}
		TagManager.instance.FindAllTaggedObjectsWithTag(list, TagManager.ETag.Bridge);
		foreach (TaggedObject item2 in list)
		{
			buildSlot = item2.GetComponentInParent<BuildSlot>();
			if ((bool)buildSlot && buildSlot.State == BuildSlot.BuildingState.Built)
			{
				list2.Add(buildSlot);
			}
		}
		currentIncome = 0;
		iFromBuildings = 0;
		iFromInterest = 0;
		iFromBuildersGuild = 0;
		iFromTreasureHunter = 0;
		iFromEnemies = 0;
		foreach (BuildSlot item3 in list2)
		{
			iFromBuildings += item3.GoldIncome;
		}
		if ((bool)DayNightCycle.Instance && DayNightCycle.Instance.CurrentTimestate == DayNightCycle.Timestate.Day && (bool)UpgradeBuildersGuild.Instance)
		{
			iFromBuildersGuild += UpgradeBuildersGuild.Instance.GetIncomeChangeIfNextUpgradeIsPossible();
		}
		if (PerkManager.instance.TreasureHunterActive && (bool)EnemySpawner.instance)
		{
			int amount = 0;
			EnemySpawner.instance.GetTreasureHunterBonus(wavenumber, out amount);
			iFromTreasureHunter += amount;
		}
		WaveInfo waveInfoByNumber = EnemySpawner.GetWaveInfoByNumber(wavenumber);
		if (waveInfoByNumber != null)
		{
			iFromEnemies += waveInfoByNumber.goldReward;
		}
		if ((bool)InterestPerk.instance)
		{
			iFromInterest = InterestPerk.instance.InterestAmount();
		}
		currentIncome = iFromBuildings + iFromBuildersGuild + iFromTreasureHunter + iFromEnemies + iFromInterest;
		displayNumber.text = currentIncome.ToString();
	}
}
