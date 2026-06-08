using Unity.Entities;

namespace Kitchen
{
	public class TakeFromToolStorage : TransferInteractionProposalSystem
	{
		protected override bool IsPossible(ref InteractionData data)
		{
			CreateProposal(data.Target, data.Interactor, is_drop: false, data.Interactor);
			CreateProposal(data.Interactor, data.Target, is_drop: true, data.Interactor);
			return false;
		}

		private void CreateProposal(Entity from, Entity to, bool is_drop, Entity interactor)
		{
			Entity entity = DetermineStorageTool(from);
			if (!Require<CItemStorage>(entity, out CItemStorage comp) || Has<CPreventToolStorageAccess>(entity))
			{
				return;
			}
			bool flag = false;
			if (!Has<CPlayer>(to) && Require<CToolInteractionMemory>(entity, out CToolInteractionMemory comp2))
			{
				flag = comp2.LastEntity == to && !comp2.LastWasDrop;
			}
			if (RequireBuffer(entity, out DynamicBuffer<CItemStored> comp3) && comp.ActiveIndex >= 0 && comp.ActiveIndex < comp3.Length)
			{
				CItemStored cItemStored = comp3[comp.ActiveIndex];
				if (Require<CItem>((Entity)cItemStored, out CItem _))
				{
					CreateProposal(interactor, cItemStored, entity, to, (TransferFlags)(9 | (flag ? 8192 : 0) | (is_drop ? 2 : 0)));
				}
			}
		}

		public override void SendTransfer(Entity transfer, Entity acceptance, EntityContext ctx)
		{
			if (Require<CItemTransferProposal>(transfer, out CItemTransferProposal comp) && Require<CItemStorage>(comp.Source, out CItemStorage comp2) && RequireBuffer(comp.Source, out DynamicBuffer<CItemStored> comp3))
			{
				comp3.RemoveAt(comp2.ActiveIndex);
				ctx.Remove<CStoredBy>(comp.Item);
			}
		}

		public override void ReceiveResult(Entity result, Entity transfer, Entity acceptance, EntityContext ctx)
		{
			if (Require<CItemTransferProposal>(transfer, out CItemTransferProposal comp) && Require<CItemStorage>(comp.Source, out CItemStorage comp2) && RequireBuffer(comp.Source, out DynamicBuffer<CItemStored> comp3))
			{
				if (comp3.Length <= comp2.ActiveIndex)
				{
					comp3.Add(result);
				}
				else
				{
					comp3.Insert(comp2.ActiveIndex, result);
				}
				ctx.Set(result, new CStoredBy
				{
					Storage = comp.Source
				});
			}
		}

		public override void Tidy(EntityContext ctx, CItemTransferProposal proposal)
		{
			if (proposal.Status == ItemTransferStatus.Resolved)
			{
				ctx.Set(proposal.Source, new CToolInteractionMemory
				{
					LastEntity = proposal.Destination,
					LastWasDrop = true
				});
			}
		}

		private Entity DetermineStorageTool(Entity entity)
		{
			if (Require<CToolUser>(entity, out CToolUser comp))
			{
				return comp.CurrentTool;
			}
			if (Require<CItemHolder>(entity, out CItemHolder comp2))
			{
				return comp2.HeldItem;
			}
			return default(Entity);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
