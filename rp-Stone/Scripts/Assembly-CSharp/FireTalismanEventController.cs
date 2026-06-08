using System.Collections.Generic;

public class FireTalismanEventController : BaseEventController
{
	private const string SIGNATURE = "BlowItUp";

	private static FireTalismanEventController instance;

	public static FireTalismanEventController singleton
	{
		get
		{
			if (instance == null)
			{
				instance = new FireTalismanEventController();
			}
			return instance;
		}
	}

	public override string GetEventId()
	{
		return "blowing_steam";
	}

	public override int[] GetProgressThresholds()
	{
		return new int[10] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
	}

	protected override void IncreaseRarityBonus()
	{
	}

	private void UpdatePartToMatchGoalBook()
	{
		if (!(GoalController.singleton != null))
		{
			return;
		}
		FireTalismanGoals component = GoalController.singleton.GetComponent<FireTalismanGoals>();
		int num = ((!component.IsComplete()) ? component.goal.GetValue() : component.goalCount);
		if (num < 0)
		{
			num = 0;
		}
		if (base.part != num)
		{
			base.part = num;
			if (num == 1)
			{
				GiveStartingReward(giveGoldenTreasureReplacement: true);
			}
		}
		int num2 = 1;
		switch (num)
		{
		case 1:
			num2 = 3;
			break;
		case 2:
			num2 = 6;
			break;
		case 3:
			num2 = 8;
			break;
		case 4:
			num2 = 10;
			break;
		case 5:
			num2 = 11;
			break;
		case 6:
			num2 = 12;
			break;
		}
		if (base.rarityBonus != num2)
		{
			base.rarityBonus = num2;
		}
	}

	private void GiveStartingReward(bool giveGoldenTreasureReplacement)
	{
		ItemData.Element element = ItemData.Element.Fire;
		Item item = Inventory.Singleton.GetFirstItemWithId("fire_talisman");
		if (item == null || item.signature != "BlowItUp")
		{
			if (item == null)
			{
				item = Inventory.Singleton.MakeReward("fire_talisman", 32);
			}
			else
			{
				Inventory.Singleton.RemoveItem(item);
			}
			item.cosmeticId = "golden";
			item.cosmetic = CosmeticController.singleton.GetCosmeticPrefab("golden");
			item.signature = "BlowItUp";
			Inventory.Singleton.AddItem(item);
		}
		Cosmetic cosmetic = CosmeticController.singleton.FindInventoryCosmetic("golden", "fire_talisman", element);
		if (cosmetic != null)
		{
			if (giveGoldenTreasureReplacement && !EventController.singleton.HasReceivedReward(GetEventId()))
			{
				TreasureItem item2 = TreasureFactory.singleton.MakeTreasureItem("mushroom_shop", "treasure_gold", null);
				Inventory.Singleton.AddItem(item2);
				SequentialPopupManager.singleton.ScheduleItemFound(item2);
			}
		}
		else
		{
			CosmeticController.Collection collection = CosmeticController.singleton.GetCollection("golden");
			CosmeticController.ItemEntry chosenItemEntry = new CosmeticController.ItemEntry("fire_talisman", element);
			cosmetic = CosmeticController.singleton.MakeCosmeticAndAddToInventory(chosenItemEntry, collection);
			cosmetic.targetItem.appliedGroupId = item.GetGroupId();
			SequentialPopupManager.singleton.ScheduleItemFound(cosmetic);
		}
	}

	protected override string GetRewardItemId()
	{
		return "treasure_3";
	}

	protected override string GetRewardTitleTID()
	{
		return "tid_info_blow_title";
	}

	protected override Item GetRewardItem()
	{
		if (rewardItem == null || rewardItem.GetRarityBonus() != base.rarityBonus)
		{
			TreasureItem treasureItem = ItemFactory.singleton.MakeItem(GetRewardItemId()) as TreasureItem;
			treasureItem.isShiny = true;
			Data.ItemInTreasure itemInTreasure = new Data.ItemInTreasure();
			itemInTreasure.id = "sword";
			itemInTreasure.rarityType = ItemData.Rarity.GetTypeForBonus(base.rarityBonus);
			itemInTreasure.rarityBonus = base.rarityBonus;
			itemInTreasure.showTreasureColor = true;
			treasureItem.itemsInTreasure = new Data.ItemInTreasure[1] { itemInTreasure };
			rewardItem = treasureItem;
		}
		return rewardItem;
	}

	public override void ProcessReward()
	{
		TreasureItem treasureItem = ItemFactory.singleton.MakeItem("treasure_3") as TreasureItem;
		List<Data.ItemInTreasure> obj = new List<Data.ItemInTreasure>
		{
			new Data.ItemInTreasure
			{
				id = "runestone",
				element = ItemData.Element.Fire,
				rarityType = ItemData.Rarity.Type.Common,
				rarityBonus = 0,
				countMin = 500,
				countMax = 500
			},
			new Data.ItemInTreasure
			{
				id = "runestone",
				element = ItemData.Element.Fire,
				rarityType = ItemData.Rarity.GetTypeForBonus(base.rarityBonus),
				rarityBonus = base.rarityBonus,
				showTreasureColor = true
			}
		};
		Data.ItemInTreasure item = TreasureFactory.singleton.MakeOneItemForTreasure("moonbloom_bud", 1, 1, null);
		obj.Add(item);
		Data.ItemInTreasure[] itemsInTreasure = obj.ToArray();
		treasureItem.itemsInTreasure = itemsInTreasure;
		Inventory.Singleton.AddItem(treasureItem);
		ShowRewardDialog(treasureItem);
	}

	protected override void HandlePartEnded(int partEnded)
	{
		GameStates.Singleton.OnStateChanged -= HandleGameStateChanged;
	}

	protected override void HandlePartStarted(int partStarted)
	{
		GameStates.Singleton.OnStateChanged += HandleGameStateChanged;
	}

	private void HandleGameStateChanged(GameStates.State newState, GameStates.State prevState)
	{
		switch (prevState)
		{
		case GameStates.State.Playing:
			if (newState >= GameStates.State.Playing)
			{
				break;
			}
			goto case GameStates.State.SequentialPopupRewards;
		case GameStates.State.SequentialPopupRewards:
			UpdatePartToMatchGoalBook();
			break;
		}
	}
}
