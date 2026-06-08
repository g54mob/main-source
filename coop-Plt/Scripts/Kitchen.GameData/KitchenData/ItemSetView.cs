using System.Collections.Generic;
using System.Linq;
using Kitchen;
using UnityEngine;

namespace KitchenData
{
	public class ItemSetView : DataView
	{
		private List<ItemGroupData> ItemGroups;

		private List<bool> TempUsed = new List<bool>();

		public override void Initialise(GameData data)
		{
			base.Initialise(data);
			ItemGroups = new List<ItemGroupData>();
			foreach (ItemGroup item2 in data.Get<ItemGroup>().ToList())
			{
				List<ItemSetData> list = new List<ItemSetData>();
				foreach (ItemGroup.ItemSet derivedSet in item2.DerivedSets)
				{
					if (!derivedSet.OrderingOnly)
					{
						ItemSetData item = new ItemSetData
						{
							Items = derivedSet.Items.Select((Item i) => i.ID).ToList(),
							Min = derivedSet.Min,
							Max = derivedSet.Max,
							IsMandatory = derivedSet.IsMandatory,
							RequiresUnlock = derivedSet.RequiresUnlock
						};
						list.Add(item);
					}
				}
				ItemGroups.Add(new ItemGroupData
				{
					ID = item2.ID,
					Sets = list,
					CanHaveSide = item2.CanContainSide
				});
			}
		}

		public ItemGroupData GetGroupData(int id)
		{
			return ItemGroups.First((ItemGroupData e) => e.ID == id);
		}

		public Satisfaction IsSetSatisfied(ItemSetData item_set, ItemList items, ref List<bool> used)
		{
			int num = 0;
			foreach (int item in item_set.Items)
			{
				for (int i = 0; i < items.Count; i++)
				{
					if (!used[i] && item == items[i])
					{
						used[i] = true;
						num++;
						break;
					}
				}
				if (num > item_set.Max)
				{
					return Satisfaction.Impossible;
				}
			}
			if (num < item_set.Min)
			{
				if (!item_set.IsMandatory)
				{
					return Satisfaction.Partial;
				}
				return Satisfaction.Impossible;
			}
			return Satisfaction.Correct;
		}

		public Satisfaction IsGroupSatisfied(ItemGroupData group, ItemList items)
		{
			TempUsed.Fill(items.Count, val: false);
			Satisfaction satisfaction = Satisfaction.Correct;
			foreach (ItemSetData set in group.Sets)
			{
				Satisfaction num = IsSetSatisfied(set, items, ref TempUsed);
				if (num == Satisfaction.Impossible)
				{
					satisfaction = Satisfaction.Impossible;
				}
				if (num == Satisfaction.Partial && satisfaction == Satisfaction.Correct)
				{
					satisfaction = Satisfaction.Partial;
				}
			}
			for (int i = 0; i < TempUsed.Count; i++)
			{
				if (!TempUsed[i] && Data.TryGet<Item>(items[i], out var output, warn_if_fail: true) && output.IsMergeableSide && group.CanHaveSide)
				{
					TempUsed[i] = true;
					break;
				}
			}
			foreach (bool item in TempUsed)
			{
				if (!item)
				{
					return Satisfaction.Impossible;
				}
			}
			return satisfaction;
		}

		public Satisfaction IsValidGroup(ItemList items, out int group_id)
		{
			group_id = 0;
			foreach (ItemGroupData itemGroup in ItemGroups)
			{
				Satisfaction satisfaction = IsGroupSatisfied(itemGroup, items);
				if (satisfaction == Satisfaction.Partial)
				{
					group_id = itemGroup.ID;
				}
				if (satisfaction == Satisfaction.Correct)
				{
					group_id = itemGroup.ID;
					return satisfaction;
				}
			}
			if (group_id != 0)
			{
				return Satisfaction.Partial;
			}
			return Satisfaction.Impossible;
		}

		public ItemList GetRandomConfiguration(int group, HashSet<int> available_ingredients, bool allow_any = false)
		{
			if (!Data.TryGet<ItemGroup>(group, out var output))
			{
				return default(ItemList);
			}
			List<ItemGroup.ItemSet> derivedSets = output.DerivedSets;
			ItemList result = default(ItemList);
			foreach (ItemGroup.ItemSet item in derivedSets)
			{
				int num = Random.Range(item.Min, item.Max + 1);
				foreach (Item item2 in from s in item.Items
					where allow_any || available_ingredients.Contains(s.ID)
					orderby Random.value
					select s)
				{
					if (num <= 0)
					{
						break;
					}
					result.Add(item2.ID);
					num--;
				}
			}
			return result;
		}
	}
}
