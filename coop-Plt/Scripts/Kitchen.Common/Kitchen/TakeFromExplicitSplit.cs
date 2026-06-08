using System;
using Unity.Entities;

namespace Kitchen
{
	public class TakeFromExplicitSplit : TransferInteractionProposalSystem
	{
		protected override bool AllowActOrGrab => true;

		protected override bool IsPossible(ref InteractionData data)
		{
			CreateProposal(this, Context, data.Target, data.Interactor, TransferFlags.Interaction, data.Interactor);
			CreateProposal(this, Context, data.Interactor, data.Target, TransferFlags.Interaction, data.Interactor);
			return false;
		}

		public static void CreateProposal(SystemReference system, EntityContext ctx, Entity from, Entity to, TransferFlags flags = TransferFlags.Null, Entity interactor = default(Entity), Action<Entity> per_proposal = null)
		{
			if (!ctx.Require<CItemHolder>(from, out var comp) || !ctx.Require<CSplittableItem>(comp, out var comp2) || comp2.RemainingCount <= 0 || comp2.SplitByComponents || comp2.CopySplit || comp2.SubItem == 0)
			{
				return;
			}
			CItemUndergoingProcess comp3;
			if (comp2.AllowMergeSplit)
			{
				Entity item = ctx.CreateItem(comp2.SubItem);
				Entity entity = TransferProposalSystem.CreateProposal(ctx, system, item, from, to, flags | TransferFlags.Holder | TransferFlags.RequireMerge | TransferFlags.Split, comp2.RefuseSplitWith);
				if (interactor != default(Entity))
				{
					ctx.Set(entity, new CInteractionTransferProposal
					{
						RequireHeld = false,
						RequirePress = true,
						Interactor = interactor,
						AllowAct = false,
						AllowGrab = true
					});
				}
				per_proposal?.Invoke(entity);
				entity = TransferProposalSystem.CreateProposal(ctx, system, item, from, to, flags | TransferFlags.Holder | TransferFlags.RequireMerge | TransferFlags.Split, comp2.RefuseSplitWith);
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
			else if (!comp2.PreventExplicitSplit && (!(interactor != default(Entity)) || (ctx.Require<CItemUndergoingProcess>(comp, out comp3) && comp3.IsBeingSplit && (!(comp3.Progress < 1f) || ctx.Has<CInstantlyCompleteSplit>(to)))))
			{
				Entity item2 = ctx.CreateItem(comp2.SubItem);
				Entity entity2 = TransferProposalSystem.CreateProposal(ctx, system, item2, from, to, flags | TransferFlags.Holder | TransferFlags.Split, comp2.RefuseSplitWith);
				if (interactor != default(Entity))
				{
					ctx.Set(entity2, new CInteractionTransferProposal
					{
						RequireHeld = true,
						RequirePress = false,
						Interactor = interactor,
						AllowAct = true,
						AllowGrab = false
					});
				}
				per_proposal?.Invoke(entity2);
			}
		}

		public override void SendTransfer(Entity transfer, Entity acceptance, EntityContext ctx)
		{
			if (Require<CItemTransferProposal>(transfer, out CItemTransferProposal comp) && Require<CItemHolder>(comp.Source, out CItemHolder comp2) && Require<CSplittableItem>((Entity)comp2, out CSplittableItem comp3))
			{
				comp3.RemainingCount--;
				ctx.Set(comp2, comp3);
				ctx.Remove<CItemUndergoingProcess>(comp2);
			}
		}

		public override void ReceiveResult(Entity result, Entity transfer, Entity acceptance, EntityContext ctx)
		{
		}

		public override void Tidy(EntityContext ctx, CItemTransferProposal proposal)
		{
			if (proposal.Status != ItemTransferStatus.Resolved && Has<CItem>(proposal.Item))
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
