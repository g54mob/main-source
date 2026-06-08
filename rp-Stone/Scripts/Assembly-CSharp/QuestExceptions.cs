using System.Collections.Generic;

public class QuestExceptions
{
	public static void HandleQuestStarting(Data.Quest quest)
	{
	}

	public static void AfterQuestDataLoaded(Data.Quest quest)
	{
	}

	public static bool CanMakeAvailable(string questId)
	{
		return true;
	}

	public static void AfterProgressLoaded()
	{
		QuestController singleton = QuestController.singleton;
		if (singleton.HasCompleted("upgrade_workstation_3") && !singleton.HasCompleted("utility_belt"))
		{
			singleton.MakeAvailable("utility_belt");
		}
		if (singleton.IsAvailable("cross_bridge") && singleton.IsAvailable("broken_bridge"))
		{
			singleton.MakeUnavailable("broken_bridge");
		}
		singleton.LimitStarDifficultiesForAllQuests();
	}

	public static void AfterQuestCompleted(Data.Quest quest)
	{
		TryMakeAvailableUpgradeStarStone();
		if (quest.id == "build_workstation")
		{
			long resourceOfType = InventoryResources.singleton.GetResourceOfType(Data.Resource.Stone);
			long resourceOfType2 = InventoryResources.singleton.GetResourceOfType(Data.Resource.Wood);
			if (resourceOfType < 8)
			{
				InventoryResources.singleton.AddResourceOfType(Data.Resource.Stone, 8 - resourceOfType);
			}
			if (resourceOfType2 < 8)
			{
				InventoryResources.singleton.AddResourceOfType(Data.Resource.Wood, 8 - resourceOfType2);
			}
			GameStates.Singleton.UpdateNavBarForProgressFlags();
		}
		else if (quest.id == "prospect_cliff" || quest.id == "craft_sword" || quest.id == "craft_shovel")
		{
			GameStates.Singleton.UpdateNavBarForProgressFlags();
		}
		else if (quest.id == "clean_sword")
		{
			Inventory.Singleton.ReplaceItem("dirty_sword", "sword").hasInteracted = true;
		}
		else if (quest.id == "craft_anvil")
		{
			Inventory.Singleton.RemoveItemById("metal_piece_1");
			Inventory.Singleton.RemoveItemById("metal_piece_2");
			Inventory.Singleton.RemoveItemById("metal_piece_3");
			GameStates.Singleton.itemScreen.NeedsRefresh();
		}
		else if (quest.id == "rocky_plateau" && QuestController.singleton.GetStarDifficultyForQuest(quest.id) == 3)
		{
			QuestController.singleton.MarkAsUnplayed("rocky_plateau");
		}
		else if (quest.id == "craft_goal_book")
		{
			Item item = ItemFactory.singleton.MakeItem("goal_book");
			Inventory.Singleton.AddItem(item);
			GoalBookScreen.singleton.ScheduleShowCover();
		}
	}

	public static void AfterItemAdded(Item item)
	{
		if ((item.id == "metal_piece_3" || item.id == "metal_piece_2" || item.id == "metal_piece_1") && Inventory.Singleton.HasItemById("metal_piece_1") && Inventory.Singleton.HasItemById("metal_piece_2") && Inventory.Singleton.HasItemById("metal_piece_3") && !QuestController.singleton.HasCompleted("craft_anvil_hammer"))
		{
			QuestController.singleton.MakeAvailable("craft_anvil_hammer");
		}
	}

	public static void UpdateTic(Data.Quest quest)
	{
		if (quest.id == "dig_cave" && quest.timeProgress != null)
		{
			int num = quest.timeProgress.elapsedMilliseconds / 1000;
			int num2 = quest.timeProgress.prevElapsedMilliseconds / 1000;
			if (num > num2)
			{
				InventoryResources.singleton.AddResourceOfType(Data.Resource.Stone, 2L);
			}
			quest.timeProgress.prevElapsedMilliseconds = quest.timeProgress.elapsedMilliseconds;
		}
	}

	private static void TryMakeAvailableUpgradeStarStone()
	{
		QuestController singleton = QuestController.singleton;
		if (StarStoneWeapon.singleton != null && StarStoneWeapon.singleton.level < 3 && OuroborosWeapon.singleton != null && OuroborosWeapon.singleton.level >= 2 && singleton.HasAspiringStarDifficulties() && !singleton.IsAvailableWorkstation("fetch_water_cyan") && !singleton.IsAvailableWorkstation("fetch_water_yellow") && !singleton.IsAvailableWorkstation("fetch_water_green") && !singleton.IsAvailableWorkstation("fetch_water_blue") && !singleton.IsAvailableWorkstation("fetch_water_red") && !singleton.IsAvailableWorkstation("fetch_water_rainbow") && !singleton.IsAvailableWorkstation("prepare_paint_cyan") && !singleton.IsAvailableWorkstation("prepare_paint_yellow") && !singleton.IsAvailableWorkstation("prepare_paint_green") && !singleton.IsAvailableWorkstation("prepare_paint_blue") && !singleton.IsAvailableWorkstation("prepare_paint_red") && !singleton.IsAvailableWorkstation("prepare_paint_rainbow") && !singleton.IsAvailableWorkstation("upgrade_star_stone"))
		{
			if (StarStoneWeapon.singleton.level == 1)
			{
				MakeAvailableUpgradeStarStoneIfQuests(2, 5, "upgrade_star_stone");
			}
			else if (StarStoneWeapon.singleton.level == 2)
			{
				MakeAvailableUpgradeStarStoneIfQuests(1, 10, "fetch_water_yellow");
			}
			else if (StarStoneWeapon.singleton.level == 3)
			{
				MakeAvailableUpgradeStarStoneIfQuests(1, 15, "fetch_water_green");
			}
			else if (StarStoneWeapon.singleton.level == 4)
			{
				MakeAvailableUpgradeStarStoneIfQuests(1, 20, "fetch_water_blue");
			}
			else if (StarStoneWeapon.singleton.level == 5)
			{
				MakeAvailableUpgradeStarStoneIfQuests(1, 25, "fetch_water_red");
			}
			else if (StarStoneWeapon.singleton.level == 6)
			{
				MakeAvailableUpgradeStarStoneIfQuests(1, 30, "fetch_water_rainbow");
			}
		}
	}

	private static void MakeAvailableUpgradeStarStoneIfQuests(int questCount, int minStarDifficulty, string workstationQuestId)
	{
		List<Data.Quest> availableQuests = QuestController.singleton.AvailableQuests;
		for (int i = 0; i < availableQuests.Count; i++)
		{
			Data.Quest quest = availableQuests[i];
			if (QuestController.singleton.GetStarDifficultyForQuest(quest.id) >= minStarDifficulty)
			{
				questCount--;
				if (questCount <= 0)
				{
					QuestController.singleton.MakeAvailable(workstationQuestId);
					return;
				}
			}
		}
		Utils.LogWarning("Tried to make Star Stone available to upgrade, but needs " + questCount + " more maxed quest");
	}
}
