using System.Collections.Generic;
using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public static class ItemExtensions
	{
		private static HashSet<ItemMergeCacheKey> FailedMerges = new HashSet<ItemMergeCacheKey>();

		public static void UpdateHolder(this EntityContext ctx, Entity held_item, Entity new_holder = default(Entity))
		{
			if (ctx.Require<CHeldBy>(held_item, out var comp) && comp.Holder != default(Entity))
			{
				ctx.Set(comp.Holder, default(CItemHolder));
			}
			ctx.Set(held_item, (CHeldBy)new_holder);
			if (new_holder != default(Entity))
			{
				ctx.Set(new_holder, (CItemHolder)held_item);
			}
		}

		public static Entity CreateItem(this EntityContext ctx, int item_id)
		{
			return ctx.CreateItemFromBase(ctx.CreateEntity(), item_id);
		}

		public static Entity CreateItem(this EntityContext ctx, ItemList item_components)
		{
			return ctx.CreateItemGroup(item_components.Primary, item_components);
		}

		public static Entity CreateItem(this EntityContext ctx, Entity creation_request, int item_id)
		{
			ctx.Remove<CCreateItem>(creation_request);
			return ctx.CreateItemFromBase(creation_request, item_id);
		}

		public static Entity CreateItemSet(this EntityContext ctx, ItemList components)
		{
			Entity entity = ctx.CreateEntity();
			ctx.Set(entity, new CItem
			{
				ID = 0,
				IsPartial = true,
				IsTransient = true,
				IsGroup = true,
				Category = ItemCategory.Generic,
				Items = components
			});
			return entity;
		}

		public static Entity CreateItemGroup(this EntityContext ctx, int item_id, ItemList components, bool is_partial = false, bool is_transient = false)
		{
			if (!GameData.Main.TryGet<Item>(item_id, out var output, warn_if_fail: true))
			{
				return ctx.CreateEntity();
			}
			if (output is ItemGroup itemGroup && itemGroup.AutoCollapsing)
			{
				return ctx.CreateItem(item_id);
			}
			Entity entity = ctx.CreateEntity();
			ctx.Set(entity, new CItem
			{
				ID = item_id,
				IsPartial = is_partial,
				IsTransient = is_transient,
				IsGroup = true,
				Category = output.ItemCategory,
				Items = components
			});
			ctx.Set(entity, new CRequiresView
			{
				Type = ViewType.Item
			});
			ctx.InitialiseItem(entity, output);
			return entity;
		}

		private static Entity CreateItemFromBase(this EntityContext ctx, Entity creation_request, int item_id)
		{
			if (!GameData.Main.TryGet<Item>(item_id, out var output, warn_if_fail: true))
			{
				return ctx.CreateEntity();
			}
			ctx.Set(creation_request, new CItem
			{
				ID = item_id,
				IsPartial = false,
				IsTransient = false,
				IsGroup = false,
				Category = output.ItemCategory,
				Items = new ItemList(item_id)
			});
			ctx.Set(creation_request, new CRequiresView
			{
				Type = ViewType.Item
			});
			ctx.InitialiseItem(creation_request, output);
			return creation_request;
		}

		public static void ChangeItemType(this EntityContext ctx, Entity item, int new_type, bool collapse_components, int apply_process_to_components, bool mark_self_splittable)
		{
			CItem cItem = ctx.Get<CItem>(item);
			if (!GameData.Main.TryGet<Item>(new_type, out var output, warn_if_fail: true))
			{
				return;
			}
			ItemList items = cItem.Items;
			bool flag = false;
			if (output is ItemGroup itemGroup)
			{
				flag = true;
				if (itemGroup.ApplyProcessesToComponents && !collapse_components && apply_process_to_components != 0)
				{
					for (int i = 0; i < items.Count; i++)
					{
						int item2 = items[i];
						if (GameData.Main.ProcessesView.GetResultOfProcess(item2, apply_process_to_components, out var result, allow_wrapped_only: true))
						{
							items[i] = result;
						}
					}
				}
			}
			ctx.Set(item, new CItem
			{
				ID = new_type,
				IsPartial = false,
				IsTransient = false,
				IsGroup = (cItem.IsGroup && flag),
				Category = output.ItemCategory,
				Items = ((collapse_components || !flag) ? new ItemList(new_type) : items)
			});
			ctx.Remove<CItemUndergoingProcess>(item);
			ctx.ClearItemProperties(item);
			if (mark_self_splittable)
			{
				ctx.Set(item, new CSplittableItem
				{
					SplitAsSelf = true
				});
			}
			ctx.InitialiseItem(item, output);
		}

		private static void InitialiseItem(this EntityContext ctx, Entity item, Item item_data)
		{
			if (item_data.IsSplittable)
			{
				int subItem = ((item_data.SplitSubItem != null) ? item_data.SplitSubItem.ID : 0);
				int splitByComponentsHolder = ((item_data.SplitByComponentsHolder != null) ? item_data.SplitByComponentsHolder.ID : 0);
				ctx.Set(item, new CSplittableItem
				{
					RemainingCount = item_data.SplitCount,
					TotalCount = item_data.SplitCount,
					SubItem = subItem,
					SplitSpeed = item_data.SplitSpeed,
					AllowMergeSplit = item_data.AllowSplitMerging,
					PreventExplicitSplit = item_data.PreventExplicitSplit,
					CopySplit = item_data.SplitByCopying,
					SplitByComponents = item_data.SplitByComponents,
					SplitByComponentsWrapper = ((item_data.SplitByComponentsWrapper != null) ? item_data.SplitByComponentsWrapper.ID : 0),
					SplitByComponentsHolder = splitByComponentsHolder,
					RefuseSplitWith = ((item_data.RefuseSplitWith != null) ? item_data.RefuseSplitWith.ID : 0)
				});
			}
			ItemProperties.Add(ctx, item, item_data);
			ItemHelpers.AddItemComponents(ctx, item, item_data);
		}

		private static void ClearItemProperties(this EntityContext ctx, Entity item)
		{
			ctx.Remove<CSplittableItem>(item);
			ItemProperties.Clear(ctx, item);
		}

		public static bool AttemptItemMerge(this EntityContext ctx, out Entity result, int item1_id, int item2_id, ItemList item1_components, ItemList item2_components, MergeCondition c1, MergeCondition c2, bool only_test = false)
		{
			result = default(Entity);
			ItemMergeCacheKey item = new ItemMergeCacheKey(item1_id, item2_id, item1_components, item2_components, c1, c2);
			if (FailedMerges.Contains(item))
			{
				return false;
			}
			bool flag = c1.CanSide() || c2.CanSide();
			bool flag2 = c1.CanChangeWrapper();
			bool flag3 = c2.CanChangeWrapper();
			if (c1 == MergeCondition.OnlyWithPlate && item2_id != AssetReference.Plate)
			{
				FailedMerges.Add(item);
				return false;
			}
			if (c2 == MergeCondition.OnlyWithPlate && item1_id != AssetReference.Plate)
			{
				FailedMerges.Add(item);
				return false;
			}
			if (item1_id != 0 && item2_id != 0 && (flag || (c1.CanWrap() && c2.CanWrap())) && flag2 && flag3 && ctx.AttemptComponentMerge(out result, DoubleWrapperMergeResult(item1_id, item2_id), only_test))
			{
				return true;
			}
			if (item1_id != 0 && (flag || (c1.CanWrap() && c2.CanComp())) && flag2 && flag3 && ctx.AttemptComponentMerge(out result, SingleWrapperMergeResult(item1_id, item2_components), only_test))
			{
				return true;
			}
			if (item2_id != 0 && (flag || (c1.CanComp() && c2.CanWrap())) && flag2 && flag3 && ctx.AttemptComponentMerge(out result, SingleWrapperMergeResult(item2_id, item1_components), only_test))
			{
				return true;
			}
			int must_result_in = ((!flag2) ? item1_id : ((!flag3) ? item2_id : 0));
			if ((flag || (c1.CanComp() && c2.CanComp())) && (flag2 || flag3 || item1_id == item2_id) && ctx.AttemptComponentMerge(out result, MergeByComponentsResult(item1_components, item2_components), only_test, must_result_in))
			{
				return true;
			}
			FailedMerges.Add(item);
			return false;
		}

		public static bool AttemptItemMerge(this EntityContext ctx, out Entity result, Entity item1, int item2_id, ItemList item2_components, MergeCondition c2, bool only_test = false)
		{
			if (!ctx.Require<CItem>(item1, out var comp))
			{
				result = default(Entity);
				return false;
			}
			MergeCondition condition = ctx.GetOrDefault<CPreventItemMerge>(item1).Condition;
			return ctx.AttemptItemMerge(out result, comp.ID, item2_id, comp.Items, item2_components, condition, c2, only_test);
		}

		public static bool AttemptItemMerge(this EntityContext ctx, out Entity result, int item1_id, Entity item2, bool only_test = false)
		{
			if (!ctx.Require<CItem>(item2, out var comp))
			{
				result = default(Entity);
				return false;
			}
			ItemList item1_components = new ItemList(item1_id);
			ItemList items = comp.Items;
			MergeCondition condition = ctx.GetOrDefault<CPreventItemMerge>(item2).Condition;
			MergeCondition c = MergeCondition.All;
			if (GameData.Main.TryGet<Item>(item1_id, out var output, warn_if_fail: true) && output.IsMergeableSide)
			{
				c = MergeCondition.AsSide;
			}
			return ctx.AttemptItemMerge(out result, item1_id, ctx.Get<CItem>(item2), item1_components, items, c, condition, only_test);
		}

		public static bool AttemptItemMerge(this EntityContext ctx, out Entity result, Entity item1, int item2_type, ItemList item2, bool only_test = false)
		{
			if (!ctx.Require<CItem>(item1, out var comp) || !GameData.Main.TryGet<Item>(item2_type, out var _))
			{
				result = default(Entity);
				return false;
			}
			MergeCondition condition = ctx.GetOrDefault<CPreventItemMerge>(item1).Condition;
			return ctx.AttemptItemMerge(out result, ctx.Get<CItem>(item1), item2_type, comp.Items, item2, condition, MergeCondition.All, only_test);
		}

		public static bool AttemptItemMerge(this EntityContext ctx, out Entity result, Entity item1, Entity item2, bool only_test = false)
		{
			if (!ctx.Require<CItem>(item1, out var comp) || !ctx.Require<CItem>(item2, out var comp2))
			{
				result = default(Entity);
				return false;
			}
			MergeCondition condition = ctx.GetOrDefault<CPreventItemMerge>(item1).Condition;
			MergeCondition condition2 = ctx.GetOrDefault<CPreventItemMerge>(item2).Condition;
			return ctx.AttemptItemMerge(out result, ctx.Get<CItem>(item1), ctx.Get<CItem>(item2), comp.Items, comp2.Items, condition, condition2, only_test);
		}

		public static bool AttemptComponentMerge(this EntityContext ctx, out Entity result, ItemList components, bool only_test = false, int must_result_in = 0)
		{
			result = default(Entity);
			int group_id;
			Satisfaction satisfaction = GameData.Main.ItemSetView.IsValidGroup(components, out group_id);
			if (must_result_in != 0 && group_id != must_result_in)
			{
				return false;
			}
			if (satisfaction == Satisfaction.Impossible)
			{
				return false;
			}
			if (!only_test)
			{
				if (components.Count > 1)
				{
					result = ctx.CreateItemGroup(group_id, components, satisfaction == Satisfaction.Partial, is_transient: true);
				}
				else
				{
					result = ctx.CreateItem(group_id);
				}
			}
			return true;
		}

		private static ItemList DoubleWrapperMergeResult(int item1_id, int item2_id)
		{
			return new ItemList(item1_id, item2_id);
		}

		private static ItemList SingleWrapperMergeResult(int item1_id, ItemList item2_components)
		{
			return item1_id + item2_components;
		}

		private static ItemList MergeByComponentsResult(ItemList item1_components, ItemList item2_components)
		{
			return item1_components + item2_components;
		}
	}
}
