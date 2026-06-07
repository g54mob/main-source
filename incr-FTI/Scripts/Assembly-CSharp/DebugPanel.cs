using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DebugPanel : MonoBehaviour
{
	public InputFieldHelper adminCommandInput;

	public bool onlySimulateActiveTown;

	private long testTimestamp;

	private static GameManager gm => GameManager.Instance;

	private void Awake()
	{
		adminCommandInput.inputFieldDelegate = OnInputSubmit;
	}

	public void SetVisible(bool flag)
	{
		base.gameObject.SetActive(flag);
		if (flag)
		{
			EventSystem.current.SetSelectedGameObject(adminCommandInput.gameObject);
		}
	}

	private void ResetResearch(ResearchType t)
	{
		if (gm.activeTown.research.TryGetValue(t, out var value))
		{
			value.Reset();
		}
	}

	private void ResetQuest(QuestType t)
	{
		if (gm.globalQuests.TryGetValue(t, out var value))
		{
			value.Reset();
		}
	}

	public bool AllowAdminCommands()
	{
		return false;
	}

	public void OnInputSubmit(InputFieldHelper sender)
	{
		string inputFieldText = sender.GetInputFieldText();
		if (AllowAdminCommands())
		{
			UnityEngine.Debug.Log("Test admin command: " + inputFieldText);
			TestAdminCommands(inputFieldText);
		}
		TestRegularCommands(inputFieldText);
		EventSystem.current.SetSelectedGameObject(null);
		base.gameObject.SetActive(value: false);
	}

	private void TestAdminCommands(string text)
	{
		string text2 = text.ToUpper();
		if (text2 == "ADMIN ON")
		{
			GameManager.everythingUnlocked = true;
			gm.RefreshAllMetadata();
		}
		if (text2 == "XP")
		{
			MenuManager.Instance.tooltipPanel.LoadEntityProduction(EntityId.FromItem(ItemType.TownExperiencePoint));
			MenuManager.Instance.tooltipPanel.Pin();
		}
		if (text2 == "ADMIN OFF")
		{
			GameManager.everythingUnlocked = false;
			gm.RefreshAllMetadata();
		}
		if (text2 == "FREE ON")
		{
			GameManager.freeMode = true;
			gm.RefreshAllMetadata();
		}
		if (text2 == "FREE OFF")
		{
			GameManager.freeMode = false;
			gm.RefreshAllMetadata();
		}
		if (text2 == "LEVELUP")
		{
			gm.activeTown.cachedTownXPState.currentCount = gm.activeTown.levelUpCost;
		}
		if (text2 == "WIPE STATS" && Platform.Instance is PlatformSteam platformSteam)
		{
			platformSteam.WipeStatsAndAchievements();
			MenuManager.Instance.ShowMessage("Stats and Achievements reset");
		}
		string[] array = text.Split(' ');
		if (array.Length == 2)
		{
			string text3 = array[0].ToUpper();
			string text4 = array[1];
			if (text3.Equals("SETTOWNLEVEL", StringComparison.InvariantCultureIgnoreCase))
			{
				SetTownLevel(text4);
			}
			if (text3.Equals("SETOMNILEVEL", StringComparison.InvariantCultureIgnoreCase))
			{
				SetOmniLevel(text4);
			}
			if (text3.Equals("XP", StringComparison.InvariantCultureIgnoreCase))
			{
				AddCumulativeXP(text4);
			}
		}
		if (array.Length < 3)
		{
			return;
		}
		string text5 = array[0].ToUpper();
		int num = text.IndexOf(' ');
		int num2 = text.LastIndexOf(' ');
		int num3 = num2 - num;
		if (AllowAdminCommands())
		{
			if (text5 == "A")
			{
				string text6 = text.Substring(num + 1, num3 - 1);
				UnityEngine.Debug.Log("Got middle: '" + text6 + "'");
				string text7 = text.Substring(num2 + 1);
				UnityEngine.Debug.Log("Got last: '" + text7 + "'");
				ItemType type = ParsedItem(text6);
				AddItem(type, text7);
			}
			else if (text5 == "R")
			{
				string text8 = text.Substring(num + 1, num3 - 1);
				UnityEngine.Debug.Log("Got middle: '" + text8 + "'");
				string text9 = text.Substring(num2 + 1);
				UnityEngine.Debug.Log("Got last: '" + text9 + "'");
				ItemType type2 = ParsedItem(text8);
				RemoveItem(type2, text9);
			}
		}
	}

	private void TestRegularCommands(string text)
	{
		string[] array = text.Split(' ');
		if (array.Length == 2)
		{
			string text2 = array[0].ToUpper();
			string text3 = array[1];
			if (text2.Equals("LOAD", StringComparison.InvariantCultureIgnoreCase))
			{
				string text4 = text3;
				string fileNameWithExtension = text4 + ".idlesav";
				FileManager.ClearAndLoadCurrent(Platform.Instance.CreateNamedFileMetadata(fileNameWithExtension, FileType.SaveFile), FileManager.OnLoadResult);
				gm.overrideFileName = text4;
			}
		}
	}

	[Conditional("UNITY_EDITOR")]
	private void TestEditorCommands(string text)
	{
		string text2 = text.ToUpper();
		if (text2 == "T1")
		{
			testTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
		}
		if (text2 == "T2")
		{
			DateTimeOffset.UtcNow.ToUnixTimeSeconds();
		}
		if (text2 == "BIOME")
		{
			EntityId id = EntityId.FromBiome(BiomeType.Jungle);
			gm.recentlyUnlockedEntities.Add(new EntityLevel(id, 0));
			MenuManager.Instance.rewardPanel.ShowRecentlyUnlocked();
		}
		if (text2 == "EFF")
		{
			gm.activeTown.upgrades[UpgradeType.UpgradeEfficiency].numCompleted = 0;
			gm.activeTown.SetAllTownMetadataStale();
		}
		if (text2 == "RESET FARMING")
		{
			gm.minigameFarming.Reset();
		}
		if (text2 == "IMAGE")
		{
			Image[] array = UnityEngine.Object.FindObjectsByType<Image>(FindObjectsInactive.Include, FindObjectsSortMode.None);
			foreach (Image image in array)
			{
				try
				{
					_ = image.sprite.name;
				}
				catch (MissingReferenceException)
				{
				}
				catch (MissingComponentException)
				{
				}
				catch (UnassignedReferenceException)
				{
				}
				catch (NullReferenceException)
				{
				}
			}
		}
		if (text2 == "REWARD")
		{
			gm.lastRewardClaimTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - 72000 + 5;
		}
		if (text2 == "POPUPS")
		{
			for (int j = 0; j < 100; j++)
			{
				Notification n = new Notification(TextDisplay.FormattedKeyValue("ResearchComplete", "Test"), IconManager.Instance.happiness5, IconManager.SpriteForItem(ItemType.TownExperiencePoint), "+500");
				MenuManager.Instance.PlayOrQueueTownLogNotification(n);
			}
		}
	}

	private void SetTownLevel(string s)
	{
		if (int.TryParse(s, out var result))
		{
			gm.activeTown.SetTownLevel(result);
		}
	}

	private void SetOmniLevel(string s)
	{
		if (!int.TryParse(s, out var result) || result < 0)
		{
			return;
		}
		foreach (Town town in gm.towns)
		{
			if (town == null)
			{
				continue;
			}
			foreach (Upgrade value in town.upgrades.Values)
			{
				if (value.def.isInfinite)
				{
					value.numCompleted = result;
				}
			}
		}
		gm.RefreshAllMetadata();
	}

	private void AddCumulativeXP(string s)
	{
		if (double.TryParse(s, out var result))
		{
			gm.activeTown.cachedTownXPState.AddManualCurrency(result);
		}
	}

	private void SetPrestigePoints(string s)
	{
		if (int.TryParse(s, out var result))
		{
			gm.activeTown.pendingPrestigeCoins = 0;
			gm.activeTown.townPerkPointState.currentCount = result;
			double sacrificedXP = GameManager.CostForEarningNextPrestigePoint(Math.Round(gm.activeTown.townPerkPointState.currentCount - 1.0));
			gm.activeTown.sacrificedXP = sacrificedXP;
			if (gm.activeTown.numTownResets == 0)
			{
				gm.activeTown.numTownResets = 1;
			}
			MenuManager instance = MenuManager.Instance;
			instance.townStatsPanel.isItemAvailabilityStale = true;
			instance.townPerksPanel.areCountsStale = true;
			instance.townPerksPanel.isHeaderDataStale = true;
		}
	}

	private bool IsMagicBuilding(BuildingType t)
	{
		switch (t)
		{
		case BuildingType.ManaTransmitter:
		case BuildingType.MagicForge:
		case BuildingType.Refinery:
		case BuildingType.ManaReactor:
		case BuildingType.Enchanter:
		case BuildingType.FireShrine:
		case BuildingType.WaterShrine:
		case BuildingType.EarthShrine:
		case BuildingType.AirShrine:
		case BuildingType.MagicLab:
			return true;
		default:
			return false;
		}
	}

	private ItemType ParsedItem(string itemString)
	{
		if (Enum.IsDefined(typeof(ItemType), itemString))
		{
			return (ItemType)Enum.Parse(typeof(ItemType), itemString);
		}
		string text = itemString.ToUpper();
		foreach (ItemType key in Crafting.cachedItemDefs.Keys)
		{
			if (TextDisplay.LabelForItem(key).ToUpper() == text)
			{
				return key;
			}
		}
		MenuManager.Instance.ShowMessage("Unable to parse item '" + itemString + "'");
		return ItemType.None;
	}

	private void AddItem(ItemType type, string amountString)
	{
		if (!int.TryParse(amountString, out var result))
		{
			UnityEngine.Debug.Log("Could not parse int from:" + amountString);
			return;
		}
		switch (type)
		{
		case ItemType.UtilityQuestCoin:
			gm.ModifyQuestCoins(result);
			return;
		case ItemType.TimeToken:
			gm.timeTokenState.TryAdd(result);
			return;
		case ItemType.UtilityPrestigePoint:
			gm.activeTown.bonusPrestigePoints += result;
			gm.activeTown.CalcUnassignedPerkPoints();
			return;
		case ItemType.UtilityLand:
			gm.activeTown.bonusLand += result;
			gm.activeTown.SetMetadataFlag(4);
			return;
		}
		if (GameManager.Instance.activeTown.inventory.TryGetValue(type, out var value))
		{
			value.Add(result);
			UnityEngine.Debug.Log("Add item " + type.ToString() + " : " + result);
			value.CalcAvailability();
		}
		else
		{
			UnityEngine.Debug.Log("Could not find in inventory: " + type);
		}
	}

	private void RemoveItem(ItemType type, string amountString)
	{
		if (!int.TryParse(amountString, out var result))
		{
			return;
		}
		switch (type)
		{
		case ItemType.UtilityQuestCoin:
			gm.ModifyQuestCoins(-result);
			return;
		case ItemType.TimeToken:
			gm.timeTokenState.Subtract(-result);
			return;
		case ItemType.UtilityPrestigePoint:
			gm.activeTown.bonusPrestigePoints -= result;
			gm.activeTown.CalcUnassignedPerkPoints();
			return;
		case ItemType.UtilityLand:
			gm.activeTown.bonusLand -= result;
			gm.activeTown.SetMetadataFlag(4);
			return;
		}
		if (GameManager.Instance.activeTown.inventory.TryGetValue(type, out var value))
		{
			value.Subtract(result);
		}
		else
		{
			UnityEngine.Debug.Log("Could not find in inventory: " + type);
		}
	}
}
