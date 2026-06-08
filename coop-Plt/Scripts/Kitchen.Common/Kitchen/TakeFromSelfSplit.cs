using System;
using Unity.Entities;

namespace Kitchen
{
	public class TakeFromSelfSplit : TransferInteractionProposalSystem
	{
		protected override InteractionType RequiredType => InteractionType.Act;

		protected override bool RequireHold => true;

		protected override bool IsPossible(ref InteractionData data)
		{
			CreateProposal(this, Context, data.Target, data.Interactor, TransferFlags.Interaction, data.Interactor);
			CreateProposal(this, Context, data.Interactor, data.Target, TransferFlags.Interaction | TransferFlags.Drop, data.Interactor);
			return false;
		}

		public static void CreateProposal(SystemReference system, EntityContext ctx, Entity from, Entity to, TransferFlags flags = TransferFlags.Null, Entity interactor = default(Entity), Action<Entity> per_proposal = null)
		{
			CItemHolder comp;
			CItem comp2;
			bool flag = ctx.Require<CItemHolder>(from, out comp) && ctx.Require<CItem>(comp, out comp2);
			if (ctx.Require<CSplittableItem>(comp, out var comp3) && comp3.SplitAsSelf && flag)
			{
				Entity entity = TransferProposalSystem.CreateProposal(ctx, system, comp, from, to, flags | TransferFlags.Holder | TransferFlags.Split);
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
			if (Require<CItemTransferProposal>(transfer, out CItemTransferProposal comp) && Require<CItemHolder>(comp.Source, out CItemHolder comp2))
			{
				ctx.Remove<CSplittableItem>(comp.Item);
				ctx.Set(comp2, default(CHeldBy));
				ctx.Set(comp.Source, default(CItemHolder));
			}
		}

		public override void ReceiveResult(Entity result, Entity transfer, Entity acceptance, EntityContext ctx)
		{
			if (Require<CItemTransferProposal>(transfer, out CItemTransferProposal comp) && Require<CItemHolder>(comp.Source, out CItemHolder _))
			{
				ctx.Set(result, new CHeldBy
				{
					Holder = comp.Source
				});
				ctx.Set(comp.Source, new CItemHolder
				{
					HeldItem = result
				});
			}
		}

		public override void Tidy(EntityContext ctx, CItemTransferProposal proposal)
		{
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
