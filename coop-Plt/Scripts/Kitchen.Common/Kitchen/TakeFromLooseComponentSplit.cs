using System;
using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public class TakeFromLooseComponentSplit : TransferInteractionProposalSystem
	{
		protected override bool IsPossible(ref InteractionData data)
		{
			CreateProposal(this, Context, data.Target, data.Interactor, TransferFlags.Interaction, data.Interactor);
			CreateProposal(this, Context, data.Interactor, data.Target, TransferFlags.Interaction | TransferFlags.Drop, data.Interactor);
			return false;
		}

		public static void CreateProposal(SystemReference system, EntityContext ctx, Entity from, Entity to, TransferFlags flags, Entity interactor = default(Entity), Action<Entity> per_proposal = null)
		{
			if (!ctx.Require<CItemHolder>(from, out var comp) || !ctx.Require<CItem>(comp, out var comp2) || comp2.Items.Count <= 1 || !GameData.Main.TryGet<ItemGroup>(comp2, out var output) || !output.AllowLooseComponentSplitting)
			{
				return;
			}
			foreach (int item in comp2.Items)
			{
				Entity entity = ctx.CreateItem(item);
				Entity entity2 = TransferProposalSystem.CreateProposal(ctx, system, entity, from, to, flags | TransferFlags.Holder | TransferFlags.LooseSplit);
				if (interactor != default(Entity))
				{
					ctx.Set(entity2, new CInteractionTransferProposal
					{
						RequireHeld = false,
						RequirePress = true,
						Interactor = interactor,
						AllowAct = false,
						AllowGrab = true
					});
				}
				per_proposal?.Invoke(entity);
			}
		}

		public override void SendTransfer(Entity transfer, Entity acceptance, EntityContext ctx)
		{
			if (Require<CItemTransferProposal>(transfer, out CItemTransferProposal comp) && Require<CItemHolder>(comp.Source, out CItemHolder comp2) && Require<CItem>((Entity)comp2, out CItem comp3))
			{
				ItemList itemList = (comp3.Items = comp3.Items.Without(comp.ItemType, 1));
				if (itemList.Count == 1)
				{
					comp3.ID = itemList[0];
				}
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
