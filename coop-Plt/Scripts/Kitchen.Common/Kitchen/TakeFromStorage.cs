using Unity.Entities;

namespace Kitchen
{
	public class TakeFromStorage : TransferInteractionProposalSystem
	{
		protected override bool IsPossible(ref InteractionData data)
		{
			CreateProposal(data.Target, data.Interactor, is_drop: false, data.Interactor);
			CreateProposal(data.Interactor, data.Target, is_drop: true, data.Interactor);
			return false;
		}

		private void CreateProposal(Entity from, Entity to, bool is_drop, Entity interactor)
		{
			if (Require<CItemStorage>(from, out CItemStorage comp) && RequireBuffer(from, out DynamicBuffer<CItemStored> comp2) && comp.ActiveIndex >= 0 && comp.ActiveIndex < comp2.Length)
			{
				CItemStored cItemStored = comp2[comp.ActiveIndex];
				if (Require<CItem>((Entity)cItemStored, out CItem _))
				{
					CreateProposal(interactor, cItemStored, from, to, (TransferFlags)(9 | (is_drop ? 2 : 0)));
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
				comp3[comp2.ActiveIndex] = result;
				ctx.Set(result, new CStoredBy
				{
					Storage = comp.Source
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
