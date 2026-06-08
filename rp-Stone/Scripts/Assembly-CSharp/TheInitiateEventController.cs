using System;
using System.Collections.Generic;
using UnityEngine;

public class TheInitiateEventController : BaseEventController
{
	private static TheInitiateEventController instance;

	public static TheInitiateEventController singleton
	{
		get
		{
			if (instance == null)
			{
				instance = new TheInitiateEventController();
			}
			return instance;
		}
	}

	public override string GetEventId()
	{
		return "the_initiate";
	}

	public override int[] GetProgressThresholds()
	{
		throw new NotImplementedException();
	}

	protected override string GetRewardItemId()
	{
		return "treasure_delta_no_rainbow";
	}

	protected override string GetRewardTitleTID()
	{
		return "tid_info_initiate_title";
	}

	public void MarkRewardCompleted()
	{
		base.rarityBonus = 1;
		int value = UnityEngine.Random.Range(0, 999999);
		EventController.singleton.SetProgress("seed", value);
	}

	public override void ProcessReward()
	{
		TreasureItem treasureItem = ItemFactory.singleton.MakeItem("treasure_2") as TreasureItem;
		treasureItem.isShiny = true;
		treasureItem.signature = "IN22";
		int seed = EventController.singleton.GetProgress("seed", UnityEngine.Random.Range(0, 999999));
		TreasureFactory.singleton.SetSeed(seed);
		Data.ItemInTreasure[] collection = TreasureFactory.singleton.MakeShinyItemsInTreasure(1);
		List<Data.ItemInTreasure> list = new List<Data.ItemInTreasure>(collection);
		for (int i = 0; i < list.Count; i++)
		{
			Data.ItemInTreasure itemInTreasure = list[i];
			if (itemInTreasure.id != "shiny" && itemInTreasure.id != "enchantment")
			{
				itemInTreasure.level = 1024;
			}
		}
		Data.ItemInTreasure item = TreasureFactory.singleton.MakeOneItemForTreasure("cult_mask", 6, 1, null);
		list.Add(item);
		collection = list.ToArray();
		treasureItem.itemsInTreasure = collection;
		Inventory.Singleton.AddItem(treasureItem);
		ShowRewardDialog(treasureItem);
	}
}
