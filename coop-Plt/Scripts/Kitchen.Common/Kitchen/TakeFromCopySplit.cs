using System;
using Unity.Entities;

namespace Kitchen
{
	public class TakeFromCopySplit : TransferInteractionProposalSystem
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
			if (ctx.Require<CItemHolder>(from, out var comp) && ctx.Require<CItem>(comp, out var comp2) && ctx.Require<CSplittableItem>(comp, out var comp3) && comp3.RemainingCount > 0 && comp3.CopySplit && comp3.SubItem != 0 && !comp3.PreventExplicitSplit && ctx.Require<CItemUndergoingProcess>(comp, out var comp4) && comp4.IsBeingSplit && (!(comp4.Progress < 1f) || ctx.Has<CInstantlyCompleteSplit>(to)))
			{
				Entity item = ctx.CreateItemGroup(comp3.SubItem, comp2.Items);
				Entity entity = TransferProposalSystem.CreateProposal(ctx, system, item, from, to, flags | TransferFlags.Holder | TransferFlags.Split, comp3.RefuseSplitWith);
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
