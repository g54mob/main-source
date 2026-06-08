using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(ItemTransferAccept))]
	public abstract class TransferAcceptSystem : GenericSystemBase, IAcceptTransfers
	{
		public static Entity Accept(EntityManager em, GenericSystemBase system, Entity proposal, TransferFlags flags)
		{
			return Accept(new EntityContext(em), system, proposal, flags);
		}

		public static Entity Accept(EntityContext ctx, GenericSystemBase system, Entity proposal, TransferFlags flags)
		{
			Entity entity = ctx.CreateEntity();
			ctx.Set(entity, new CItemTransferAccept
			{
				ResolutionSystem = system,
				Proposal = proposal,
				Flags = flags,
				Status = ItemAcceptStatus.Accepted
			});
			return entity;
		}

		public Entity Accept(Entity proposal, TransferFlags flags = TransferFlags.Null)
		{
			return Accept(base.EntityManager, this, proposal, flags);
		}

		public Entity Accept(EntityContext ctx, Entity proposal, TransferFlags flags = TransferFlags.Null)
		{
			return Accept(ctx, this, proposal, flags);
		}

		public abstract void AcceptTransfer(Entity proposal, Entity acceptance, EntityContext ctx, out Entity return_item);

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
