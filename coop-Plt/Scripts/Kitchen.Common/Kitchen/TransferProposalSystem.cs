using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(ItemTransferPropose))]
	public abstract class TransferProposalSystem : GenericSystemBase, ISendTransfers
	{
		public static Entity CreateProposal(EntityContext ctx, GenericSystemBase system, Entity item, CItem item_component, MergeCondition item_merge_condition, Entity source, Entity destination, TransferFlags flags = TransferFlags.Null, int refuse_merge_with = 0)
		{
			Entity entity = ctx.CreateEntity();
			ctx.Set(entity, new CItemTransferProposal
			{
				ResolutionSystem = system,
				Flags = flags,
				Item = item,
				Status = ItemTransferStatus.Proposed,
				Source = source,
				Destination = destination,
				ItemData = item_component,
				ItemType = item_component.ID,
				ItemComponents = item_component.Items,
				MergeCondition = item_merge_condition,
				RefuseMergeWith = refuse_merge_with
			});
			return entity;
		}

		public static Entity CreateProposal(EntityContext ctx, SystemReference system, Entity item, Entity source, Entity destination, TransferFlags flags = TransferFlags.Null, int refuse_merge_with = 0)
		{
			if (!ctx.Require<CItem>(item, out var comp))
			{
				return default(Entity);
			}
			MergeCondition mergeCondition = MergeCondition.All;
			if (ctx.Require<CPreventItemMerge>(item, out var comp2))
			{
				mergeCondition = comp2.Condition;
			}
			Entity entity = ctx.CreateEntity();
			ctx.Set(entity, new CItemTransferProposal
			{
				ResolutionSystem = system,
				Flags = flags,
				Item = item,
				Status = ItemTransferStatus.Proposed,
				Source = source,
				Destination = destination,
				ItemData = comp,
				ItemType = comp.ID,
				ItemComponents = comp.Items,
				MergeCondition = mergeCondition,
				RefuseMergeWith = refuse_merge_with
			});
			return entity;
		}

		protected Entity CreateProposal(EntityContext ctx, Entity item, Entity source, Entity destination, TransferFlags flags = TransferFlags.Null, int refuse_merge_with = 0)
		{
			return CreateProposal(ctx, this, item, source, destination, flags, refuse_merge_with);
		}

		public abstract void SendTransfer(Entity transfer, Entity acceptance, EntityContext ctx);

		public abstract void ReceiveResult(Entity result, Entity transfer, Entity acceptance, EntityContext ctx);

		public abstract void Tidy(EntityContext ctx, CItemTransferProposal proposal);

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
