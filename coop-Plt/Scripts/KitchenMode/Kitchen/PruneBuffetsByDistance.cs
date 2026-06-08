using Unity.Entities;

namespace Kitchen
{
	[UpdateBefore(typeof(HandleBuffetUsers))]
	[UpdateInGroup(typeof(ItemTransferLatePrune))]
	public class PruneBuffetsByDistance : GenericSystemBase
	{
		public EntityQuery BuffetUsers;

		public EntityQuery Acceptances;

		protected override void Initialise()
		{
			BuffetUsers = GetEntityQuery(typeof(CPosition), typeof(CBelongsToGroup));
			Acceptances = GetEntityQuery(typeof(CItemTransferAccept));
		}

		protected override void OnUpdate()
		{
			using EntityContext entityContext = new EntityContext(base.EntityManager);
			using EntityLookup<CPosition, CBelongsToGroup, NullType> entityLookup = EntityLookup.Create<CPosition, CBelongsToGroup>(BuffetUsers);
			using EntityLookup<CItemTransferAccept, NullType, NullType> entityLookup2 = EntityLookup.Create<CItemTransferAccept>(Acceptances);
			foreach (EntityData<CPosition, CBelongsToGroup, NullType> item in entityLookup.Iterate())
			{
				float num = 99999f;
				Entity entity = default(Entity);
				CItemTransferAccept data = default(CItemTransferAccept);
				foreach (EntityData<CItemTransferAccept, NullType, NullType> item2 in entityLookup2.Iterate())
				{
					if (item2.Value1.Status == ItemAcceptStatus.Pruned)
					{
						continue;
					}
					COrderAcceptance comp;
					CPartialOrderAcceptance comp2;
					int num2 = (Require<COrderAcceptance>(item2.Entity, out comp) ? comp.MemberIndex : (Require<CPartialOrderAcceptance>(item2.Entity, out comp2) ? comp2.MemberIndex : (-1)));
					if (!(comp.Group != item.Value2.Group) && num2 == item.Value2.IndexInGroup && Require<CItemTransferProposal>(item2.Value1.Proposal, out CItemTransferProposal comp3) && (comp3.Flags & TransferFlags.Buffet) != TransferFlags.Null && Require<CPosition>(comp3.Source, out CPosition comp4))
					{
						CItemTransferAccept value = item2.Value1;
						value.Status = ItemAcceptStatus.Pruned;
						value.PrunedBy = this;
						entityContext.Set(item2.Entity, value);
						float sqrMagnitude = (comp4.ForwardPosition - item.Value1.Position).sqrMagnitude;
						if (entity == default(Entity) || sqrMagnitude < num)
						{
							entity = item2.Entity;
							num = sqrMagnitude;
							data = item2.Value1;
						}
					}
				}
				if (entity != default(Entity))
				{
					entityContext.Set(entity, data);
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
