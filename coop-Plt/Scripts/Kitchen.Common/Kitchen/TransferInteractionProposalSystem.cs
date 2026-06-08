using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(ItemTransferPropose))]
	public abstract class TransferInteractionProposalSystem : InteractionSystem, ISendTransfers
	{
		protected override bool UseImmediateContext => true;

		protected override InteractionType RequiredType => InteractionType.Grab;

		protected override InteractionMode RequiredMode => InteractionMode.Items;

		protected override bool AllowTransferOnly => true;

		protected override EntityContext CreateContext()
		{
			return new EntityContext(base.EntityManager);
		}

		protected override void CompleteContext(EntityContext ctx)
		{
		}

		protected CInteractionTransferProposal InteractionTransferProposal(Entity interactor)
		{
			return new CInteractionTransferProposal
			{
				RequireHeld = RequireHold,
				RequirePress = RequirePress,
				Interactor = interactor,
				AllowAct = (RequiredType == InteractionType.Act || AllowActOrGrab),
				AllowGrab = (RequiredType == InteractionType.Grab || AllowActOrGrab)
			};
		}

		protected Entity CreateProposal(Entity interactor, Entity item, Entity source, Entity destination, TransferFlags flags = TransferFlags.Null, int refuse_merge_with = 0)
		{
			Entity entity = TransferProposalSystem.CreateProposal(Context, this, item, source, destination, flags, refuse_merge_with);
			Context.Set(entity, InteractionTransferProposal(interactor));
			return entity;
		}

		public abstract void SendTransfer(Entity transfer, Entity acceptance, EntityContext ctx);

		public abstract void ReceiveResult(Entity result, Entity transfer, Entity acceptance, EntityContext ctx);

		public abstract void Tidy(EntityContext ctx, CItemTransferProposal proposal);

		protected override void Perform(ref InteractionData data)
		{
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
