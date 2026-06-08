using System;
using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public class TakeFromComponentSplit : TransferInteractionProposalSystem
	{
		protected override bool AllowActOrGrab => true;

		protected override bool IsPossible(ref InteractionData data)
		{
			CInteractionTransferProposal cInteractionTransferProposal = new CInteractionTransferProposal
			{
				RequireHeld = true,
				RequirePress = false,
				Interactor = data.Interactor,
				AllowAct = true,
				AllowGrab = false
			};
			CreateProposal(this, Context, data.Target, data.Interactor, TransferFlags.Interaction, data.Interactor);
			CreateProposal(this, Context, data.Interactor, data.Target, TransferFlags.Interaction, data.Interactor);
			return false;
		}

		public static void CreateProposal(SystemReference system, EntityContext ctx, Entity from, Entity to, TransferFlags flags = TransferFlags.Null, Entity interactor = default(Entity), Action<Entity> per_proposal = null)
		{
			if (!ctx.Require<CItemHolder>(from, out var comp) || !ctx.Require<CSplittableItem>(comp, out var comp2) || !ctx.Require<CItem>(comp, out var comp3) || comp2.RemainingCount <= 0 || !comp2.SplitByComponents)
			{
				return;
			}
			ItemList components = default(ItemList);
			foreach (int item4 in comp3.Items)
			{
				if (item4 != comp2.SplitByComponentsHolder)
				{
					components.Add(item4);
				}
			}
			CItemUndergoingProcess comp5;
			if (comp2.SplitByComponentsWrapper != 0)
			{
				if (!(interactor != default(Entity)) || (ctx.Require<CItemUndergoingProcess>(comp, out var comp4) && comp4.IsBeingSplit && (!(comp4.Progress < 1f) || ctx.Has<CInstantlyCompleteSplit>(to))))
				{
					Entity item = ctx.CreateItemGroup(comp2.SplitByComponentsWrapper, components);
					Entity entity = TransferProposalSystem.CreateProposal(ctx, system, item, from, to, flags | TransferFlags.Holder | TransferFlags.Split, comp2.RefuseSplitWith);
					if (interactor != default(Entity))
					{
						ctx.Set(entity, new CInteractionTransferProposal
						{
							RequireHeld = true,
							RequirePress = false,
							Interactor = interactor,
							AllowAct = true,
							AllowGrab = false
						});
					}
					per_proposal?.Invoke(entity);
				}
			}
			else if (comp2.AllowMergeSplit)
			{
				Entity item2 = ctx.CreateItemSet(components);
				Entity entity2 = TransferProposalSystem.CreateProposal(ctx, system, item2, from, to, flags | TransferFlags.Holder | TransferFlags.RequireMerge | TransferFlags.Split, comp2.RefuseSplitWith);
				if (interactor != default(Entity))
				{
					ctx.Set(entity2, new CInteractionTransferProposal
					{
						RequireHeld = false,
						RequirePress = true,
						Interactor = interactor,
						AllowAct = true,
						AllowGrab = true
					});
				}
				per_proposal?.Invoke(entity2);
			}
			else if (ctx.Require<CItemUndergoingProcess>(comp, out comp5) && comp5.Process == -1 && !(comp5.Progress < 1f))
			{
				Entity item3 = ctx.CreateItemSet(components);
				Entity entity3 = TransferProposalSystem.CreateProposal(ctx, system, item3, from, to, flags | TransferFlags.Holder | TransferFlags.RequireMerge | TransferFlags.Split, comp2.RefuseSplitWith);
				if (interactor != default(Entity))
				{
					ctx.Set(entity3, new CInteractionTransferProposal
					{
						RequireHeld = true,
						RequirePress = false,
						Interactor = interactor,
						AllowAct = true,
						AllowGrab = false
					});
				}
				per_proposal?.Invoke(entity3);
			}
		}

		public static void SendComponentSplitTransfer(Entity transfer, Entity acceptance, EntityContext ctx)
		{
			if (ctx.Require<CItemTransferProposal>(transfer, out var comp) && ctx.Require<CItemHolder>(comp.Source, out var comp2) && ctx.Require<CSplittableItem>(comp2, out var comp3))
			{
				comp3.RemainingCount--;
				ctx.Set(comp2, comp3);
				ctx.Remove<CItemUndergoingProcess>(comp2);
				if (comp3.RemainingCount <= 0)
				{
					ctx.Destroy(comp2);
					Entity entity = ctx.CreateItem(comp3.SplitByComponentsHolder);
					ctx.Set(entity, new CHeldBy
					{
						Holder = comp.Source
					});
					ctx.Set(comp.Source, new CItemHolder
					{
						HeldItem = entity
					});
				}
			}
		}

		public override void SendTransfer(Entity transfer, Entity acceptance, EntityContext ctx)
		{
			SendComponentSplitTransfer(transfer, acceptance, ctx);
		}

		public override void ReceiveResult(Entity result, Entity transfer, Entity acceptance, EntityContext ctx)
		{
		}

		public override void Tidy(EntityContext ctx, CItemTransferProposal proposal)
		{
			if (proposal.Status != ItemTransferStatus.Resolved)
			{
				ctx.Destroy(proposal.Item);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
