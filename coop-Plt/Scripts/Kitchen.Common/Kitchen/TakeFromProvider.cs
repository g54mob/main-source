using Unity.Entities;

namespace Kitchen
{
	public class TakeFromProvider : TransferInteractionProposalSystem
	{
		protected override bool AllowActOrGrab => true;

		protected override bool RequireHold => true;

		protected override bool RequirePress => true;

		protected override bool IsPossible(ref InteractionData data)
		{
			if (Has<CPreventUse>(data.Target))
			{
				return false;
			}
			if (Has<CPreventItemTransfer>(data.Target))
			{
				return false;
			}
			if (!Require<CItemProvider>(data.Target, out CItemProvider comp))
			{
				return false;
			}
			TransferFlags transferFlags = TransferFlags.Interaction | TransferFlags.NoReturns | TransferFlags.Provider;
			if (comp.ProvidedItem == 0)
			{
				return false;
			}
			if (comp.Maximum != 0 && comp.Available == 0)
			{
				return false;
			}
			CInteractionTransferProposal data2 = InteractionTransferProposal(data.Interactor);
			if (comp.DirectInsertionOnly)
			{
				data2.AllowAct = true;
				data2.AllowGrab = true;
				transferFlags |= TransferFlags.RequireMerge;
			}
			else
			{
				data2.AllowAct = false;
				data2.AllowGrab = true;
			}
			Context.Set(TransferProposalSystem.CreateProposal(Context, this, Context.CreateItemGroup(comp.ProvidedItem, comp.ProvidedComponents), data.Attempt.Target, data.Interactor, transferFlags), data2);
			return false;
		}

		public override void SendTransfer(Entity transfer, Entity acceptance, EntityContext ctx)
		{
			if (Require<CItemTransferProposal>(transfer, out CItemTransferProposal comp) && Require<CItemProvider>(comp.Source, out CItemProvider comp2) && comp2.Maximum > 0)
			{
				comp2.Available--;
				SetComponent(comp.Source, comp2);
			}
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
