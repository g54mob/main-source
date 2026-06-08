using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class TakeForCustomerOrders : TransferProposalSystem
	{
		private EntityQuery Buffets;

		private EntityQuery TableSets;

		private List<CTableSetGrabPoints> _GrabPoints = new List<CTableSetGrabPoints>();

		protected override void Initialise()
		{
			base.Initialise();
			Buffets = GetEntityQuery(typeof(CProvidesBuffet), typeof(CPathable), typeof(CEmptyAhead));
			TableSets = GetEntityQuery(typeof(CTableSet));
		}

		protected override void OnUpdate()
		{
			EntityContext ctx = new EntityContext(base.EntityManager);
			using NativeArray<Entity> nativeArray = Buffets.ToEntityArray(Allocator.Temp);
			using NativeArray<Entity> nativeArray2 = TableSets.ToEntityArray(Allocator.Temp);
			foreach (Entity item in nativeArray2)
			{
				if (!Require<COccupiedByGroup>(item, out COccupiedByGroup comp))
				{
					continue;
				}
				if (Require<CTableSetGrabPoints>(item, out DynamicBuffer<CTableSetGrabPoints> comp2))
				{
					comp2.Cache(_GrabPoints);
					foreach (CTableSetGrabPoints grabPoint in _GrabPoints)
					{
						CreateProposals(ctx, grabPoint.Entity, item, TransferFlags.OnlyOrderSatisfaction);
					}
				}
				if (!RequireBuffer((Entity)comp, out DynamicBuffer<CGroupMember> comp3))
				{
					continue;
				}
				int length = comp3.Length;
				foreach (Entity item2 in nativeArray)
				{
					int i;
					for (i = 0; i < length; i++)
					{
						CreateProposals(ctx, item2, item, TransferFlags.OnlyOrderSatisfaction | TransferFlags.Buffet, delegate(Entity prop)
						{
							ctx.Set(prop, new CProposalForMember
							{
								MemberIndex = i
							});
						});
					}
				}
			}
		}

		protected void CreateProposals(EntityContext ctx, Entity from, Entity to, TransferFlags flags, Action<Entity> per_entity = null)
		{
			TakeFromHolder.CreateProposal(typeof(TakeFromHolder), ctx, from, to, flags, default(Entity), per_entity);
			TakeFromLooseComponentSplit.CreateProposal(typeof(TakeFromLooseComponentSplit), ctx, from, to, flags, default(Entity), per_entity);
			TakeFromSelfSplit.CreateProposal(typeof(TakeFromSelfSplit), ctx, from, to, flags, default(Entity), per_entity);
			TakeFromExplicitSplit.CreateProposal(typeof(TakeFromExplicitSplit), ctx, from, to, flags, default(Entity), per_entity);
			TakeFromComponentSplit.CreateProposal(typeof(TakeFromComponentSplit), ctx, from, to, flags, default(Entity), per_entity);
			TakeFromCopySplit.CreateProposal(typeof(TakeFromCopySplit), ctx, from, to, flags, default(Entity), per_entity);
		}

		public override void SendTransfer(Entity transfer, Entity acceptance, EntityContext ctx)
		{
		}

		public override void ReceiveResult(Entity result, Entity transfer, Entity acceptance, EntityContext ctx)
		{
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
