using Unity.Entities;

namespace Kitchen
{
	public class TakeFromToolUser : TransferInteractionProposalSystem
	{
		protected override InteractionType RequiredType => InteractionType.Act;

		protected override bool IsPossible(ref InteractionData data)
		{
			CreateProposal(data.Target, data.Interactor, is_drop: false, data.Interactor);
			CreateProposal(data.Interactor, data.Target, is_drop: true, data.Interactor);
			return false;
		}

		private void CreateProposal(Entity from, Entity to, bool is_drop, Entity interactor)
		{
			if (Require<CToolUser>(from, out CToolUser comp) && Require<CEquippableTool>(comp.CurrentTool, out CEquippableTool _))
			{
				CreateProposal(interactor, comp.CurrentTool, from, to, (TransferFlags)(0x821 | (is_drop ? 2 : 0)));
			}
		}

		public override void SendTransfer(Entity transfer, Entity acceptance, EntityContext ctx)
		{
			if (Require<CItemTransferProposal>(transfer, out CItemTransferProposal comp) && Require<CToolUser>(comp.Source, out CToolUser comp2))
			{
				ctx.Set(comp.Source, default(CToolUser));
				ctx.Set(comp2.CurrentTool, default(CToolInUse));
			}
		}

		public override void ReceiveResult(Entity result, Entity transfer, Entity acceptance, EntityContext ctx)
		{
			if (Require<CItemTransferProposal>(transfer, out CItemTransferProposal comp) && Require<CToolUser>(comp.Source, out CToolUser _))
			{
				ctx.Set(comp.Source, new CToolUser
				{
					CurrentTool = result
				});
				ctx.Set(result, new CToolInUse
				{
					User = comp.Source
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
