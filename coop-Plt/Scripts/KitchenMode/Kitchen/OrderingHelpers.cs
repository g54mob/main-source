using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public static class OrderingHelpers
	{
		public static int FindRandomUnsatisfiedOrder(DynamicBuffer<CWaitingForItem> orders)
		{
			int num = Random.Range(0, orders.Length);
			int result = -1;
			for (int i = 0; i < orders.Length; i++)
			{
				int num2 = (i + num) % orders.Length;
				if (!orders[num2].Satisfied)
				{
					result = num2;
					break;
				}
			}
			return result;
		}

		public static void SatisfyOrder(EntityContext ctx, CWaitingForItem satisfied_order, ref DynamicBuffer<CWaitingForItem> all_orders, int satisfy_equivalent_max, out int reward_count)
		{
			reward_count = 0;
			int num = 0;
			for (int i = 0; i < all_orders.Length; i++)
			{
				CWaitingForItem cWaitingForItem = all_orders[i];
				bool flag = cWaitingForItem.Item == satisfied_order.Item;
				if (cWaitingForItem.Satisfied)
				{
					continue;
				}
				if (!flag)
				{
					if (satisfied_order.MemberIndex == cWaitingForItem.MemberIndex || num >= satisfy_equivalent_max || !IsEquivalentRequest(ctx, cWaitingForItem, satisfied_order))
					{
						continue;
					}
					num++;
					cWaitingForItem.SatisfiedBySharer = true;
				}
				reward_count++;
				cWaitingForItem.Satisfied = true;
				all_orders[i] = cWaitingForItem;
			}
		}

		public static bool IsEquivalentRequest(EntityContext ctx, CWaitingForItem request1, CWaitingForItem request2)
		{
			if (!ctx.Require<CItem>(request1.Item, out var comp) || !ctx.Require<CItem>(request2.Item, out var comp2))
			{
				return false;
			}
			if (comp.ID != comp2.ID)
			{
				return false;
			}
			if (!comp.Items.IsEquivalent(comp2.Items))
			{
				return false;
			}
			return true;
		}

		public static bool IsEquivalentRequest(EntityContext ctx, CWaitingForItem request1, CItem item2)
		{
			if (!ctx.Require<CItem>(request1.Item, out var comp))
			{
				return false;
			}
			if (comp.ID != item2.ID)
			{
				return false;
			}
			if (!comp.Items.IsEquivalent(item2.Items))
			{
				return false;
			}
			return true;
		}

		public static bool IsEquivalentRequest(EntityContext ctx, CItem item1, CItem item2)
		{
			if (item1.ID != item2.ID)
			{
				return false;
			}
			if (!item1.Items.IsEquivalent(item2.Items))
			{
				return false;
			}
			return true;
		}

		public static bool AttemptTakeSideFrom(EntityContext ctx, CItem request, CItem candidate, out Entity leftover)
		{
			leftover = default(Entity);
			for (int i = 0; i < candidate.Items.Count; i++)
			{
				int num = candidate.Items[i];
				if (GameData.Main.Get<Item>(num).IsMergeableSide && num == request.ID)
				{
					candidate.Items.RemoveAt(i);
					if (candidate.Items.Count == 1)
					{
						leftover = ctx.CreateItem(candidate.Items[0]);
						return true;
					}
					Entity result2;
					bool result = ctx.AttemptComponentMerge(out result2, candidate.Items);
					leftover = result2;
					return result;
				}
			}
			return false;
		}

		public static bool IsRequestSatisfied(CItem requested, CItem candidate, out int also_provided_side, CSplittableItem candidate_split = default(CSplittableItem))
		{
			also_provided_side = 0;
			Item item = GameData.Main.Get<Item>(requested.ID);
			CItem cItem = candidate;
			if (item.CanBeOrderedPiecemeal && requested.Items.Count == 1 && cItem.Items.Count <= 1 && requested.Items[0] == cItem.ID)
			{
				return true;
			}
			if (item.SatisfiedBy.Count == 0)
			{
				if (requested.ID != cItem.ID)
				{
					return false;
				}
				if (candidate.Items.Count <= 1 && requested.Items.Count <= 1)
				{
					return true;
				}
				int num = 0;
				foreach (int item2 in cItem.Items)
				{
					bool flag = false;
					for (int i = 0; i < requested.Items.Count; i++)
					{
						if (requested.Items[i] == item2)
						{
							requested.Items[i] = 0;
							flag = true;
							num++;
							break;
						}
					}
					if (!flag)
					{
						if (!GameData.Main.Get<Item>(item2).IsMergeableSide)
						{
							return false;
						}
						also_provided_side = item2;
					}
				}
				return num == requested.Items.Count;
			}
			if (!cItem.Satisfies(item))
			{
				return false;
			}
			return true;
		}

		public static bool IsRequestSatisfied(EntityContext ctx, Entity request, Entity candidate, out int also_provided_side)
		{
			return IsRequestSatisfied(ctx.GetOrDefault<CItem>(request), ctx.GetOrDefault<CItem>(candidate), out also_provided_side, ctx.GetOrDefault<CSplittableItem>(candidate));
		}

		public static bool IsRequestSatisfied(EntityContext ctx, CItem request, Entity candidate, out int also_provided_side)
		{
			return IsRequestSatisfied(request, ctx.GetOrDefault<CItem>(candidate), out also_provided_side, ctx.GetOrDefault<CSplittableItem>(candidate));
		}
	}
}
