using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(PostResolveSatisfactionsGroup), OrderFirst = true)]
	public class SatisfySimilarOrders : PostResolveSatisfactionSystem
	{
		private void CheckIfItemSatisfiesOrder(DynamicBuffer<CWaitingForItem> orders, CItem satisfied_item, int original_member, int max_sharers, Entity group)
		{
			int num = 0;
			using EntityContext ctx = EntityContext.WithTemporaryBuffer(base.EntityManager);
			for (int i = 0; i < orders.Length; i++)
			{
				CWaitingForItem cWaitingForItem = orders[i];
				if (cWaitingForItem.Satisfied || original_member == cWaitingForItem.MemberIndex || num >= max_sharers)
				{
					continue;
				}
				if (Require<COriginalOrderBeforePiecemeal>(cWaitingForItem.Item, out COriginalOrderBeforePiecemeal comp))
				{
					if (!OrderingHelpers.IsEquivalentRequest(base.EntityManager.Context(), new CItem
					{
						ID = comp.ItemID,
						Items = comp.OriginalItems
					}, satisfied_item))
					{
						continue;
					}
				}
				else if (!OrderingHelpers.IsEquivalentRequest(base.EntityManager.Context(), cWaitingForItem, satisfied_item))
				{
					continue;
				}
				num++;
				cWaitingForItem.SatisfiedBySharer = true;
				cWaitingForItem.Satisfied = true;
				orders[i] = cWaitingForItem;
				base.World.GetExistingSystem<GrantMoneyForSatisfactions>().GrantReward(ctx, group, cWaitingForItem.ItemID, cWaitingForItem.SourceMenuItem, satisfied_item);
			}
			for (int j = 0; j < orders.Length; j++)
			{
				CWaitingForItem cWaitingForItem2 = orders[j];
				if (original_member != cWaitingForItem2.MemberIndex && num < max_sharers && Require<CItem>(cWaitingForItem2.Item, out CItem comp2) && comp2.Items.Count != 1 && comp2.Items[0] == satisfied_item.ID && GameData.Main.TryGet<ItemGroup>(cWaitingForItem2.ItemID, out var output) && output.CanBeOrderedPiecemeal)
				{
					if (!Has<COriginalOrderBeforePiecemeal>(cWaitingForItem2.Item))
					{
						ctx.Set(cWaitingForItem2.Item, new COriginalOrderBeforePiecemeal
						{
							ItemID = comp2.ID,
							OriginalItems = comp2.Items
						});
					}
					comp2.Items = comp2.Items.Without(satisfied_item.ID, 1);
					Set(cWaitingForItem2.Item, comp2);
					num++;
				}
			}
		}

		protected override void HandleSatisfiedOrder(CItemTransferAccept acceptance, CItemTransferProposal proposal, ref COrderAcceptance details)
		{
			if (details.MaxSharers <= 0 || !Require<CWaitingForItem>(details.Group, out DynamicBuffer<CWaitingForItem> comp))
			{
				return;
			}
			CWaitingForItem cWaitingForItem = comp[details.OrderIndex];
			if (details.OrderIndex >= 0 && details.OrderIndex < comp.Length)
			{
				CItem comp3;
				if (Require<COriginalOrderBeforePiecemeal>(cWaitingForItem.Item, out COriginalOrderBeforePiecemeal comp2))
				{
					CheckIfItemSatisfiesOrder(comp, new CItem
					{
						ID = comp2.ItemID,
						Items = comp2.OriginalItems
					}, cWaitingForItem.MemberIndex, details.MaxSharers, details.Group);
				}
				else if (Require<CItem>(cWaitingForItem.Item, out comp3))
				{
					CheckIfItemSatisfiesOrder(comp, comp3, cWaitingForItem.MemberIndex, details.MaxSharers, details.Group);
				}
			}
		}

		protected override void HandlePartialSatisfiedOrder(CItemTransferAccept acceptance, CItemTransferProposal proposal, ref CPartialOrderAcceptance details)
		{
			if (details.MaxSharers > 0 && Require<CWaitingForItem>(details.Group, out DynamicBuffer<CWaitingForItem> comp))
			{
				CWaitingForItem cWaitingForItem = comp[details.OrderIndex];
				if (details.OrderIndex >= 0 && details.OrderIndex < comp.Length)
				{
					CheckIfItemSatisfiesOrder(comp, details.ComponentServed, cWaitingForItem.MemberIndex, details.MaxSharers, details.Group);
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
