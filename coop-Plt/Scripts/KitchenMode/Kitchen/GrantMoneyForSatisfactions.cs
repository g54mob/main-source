using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class GrantMoneyForSatisfactions : PostResolveSatisfactionSystem
	{
		private EntityQuery UnlockBoosts;

		protected override void Initialise()
		{
			base.Initialise();
			UnlockBoosts = GetEntityQuery(typeof(CUnlockRewardBoost));
		}

		protected override void HandleSatisfiedOrder(CItemTransferAccept acceptance, CItemTransferProposal proposal, ref COrderAcceptance details)
		{
			EntityContext ctx = base.EntityManager.Context();
			GrantReward(ctx, details.Group, details.DeliveredItem, details.CreditDish, details.OrderedItem);
		}

		public void GrantReward(EntityContext ctx, Entity group, int item, int credit_dish, CItem ordered_item)
		{
			Require<CPatience>(group, out CPatience comp);
			Require<CCustomerSettings>(group, out CCustomerSettings comp2);
			Require<CGroupReward>(group, out CGroupReward comp3);
			int flatFee = comp2.Ordering.FlatFee;
			CommitCompletedGroups.AddEvent(ctx, group, 0, flatFee);
			comp3.Amount += flatFee;
			if (comp2.Ordering.IsOnlyFlatFee)
			{
				ctx.Set(group, comp3);
			}
			else
			{
				if ((!base.Data.TryGet<Item>(ordered_item.ID, out var output) || !output.CanBeOrderedPiecemeal) && !base.Data.TryGet<Item>(item, out output))
				{
					return;
				}
				int num = 0;
				int num2 = output.Reward;
				if (output is ItemGroup itemGroup && itemGroup.Rewards != null)
				{
					foreach (int item2 in ordered_item.Items)
					{
						foreach (ItemGroup.ItemReward reward in itemGroup.Rewards)
						{
							if (reward.Item.ID == item2)
							{
								num2 += reward.RewardAmount;
								break;
							}
						}
					}
				}
				using NativeArray<CUnlockRewardBoost> nativeArray = UnlockBoosts.ToComponentDataArray<CUnlockRewardBoost>(Allocator.Temp);
				foreach (CUnlockRewardBoost item3 in nativeArray)
				{
					if (item3.ItemID == ordered_item.ID)
					{
						num2 += item3.Amount;
					}
				}
				if (GetOrCreate<SGlobalStatusList>().Has(RestaurantStatus.PayBasedOnPatience))
				{
					num2 = Mathf.CeilToInt((float)num2 * (comp.RemainingTime / comp.StartTime));
				}
				num += num2;
				CommitCompletedGroups.AddEvent(ctx, group, credit_dish, num);
				num += comp2.Ordering.BonusPerDelivery;
				CommitCompletedGroups.AddEvent(ctx, group, 0, comp2.Ordering.BonusPerDelivery);
				comp3.Amount += num;
				ctx.Set(group, comp3);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
