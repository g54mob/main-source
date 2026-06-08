using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(ItemTransferPostResolve), OrderLast = true)]
	public class PostTransferTidy : GenericSystemBase
	{
		private EntityQuery Proposals;

		private EntityQuery Accepts;

		private ResolveTransfers ResolveTransfers;

		protected override void Initialise()
		{
			base.Initialise();
			Proposals = GetEntityQuery(typeof(CItemTransferProposal));
			Accepts = GetEntityQuery(typeof(CItemTransferAccept));
		}

		public override void PostInitialisation()
		{
			base.PostInitialisation();
			ResolveTransfers = base.World.GetExistingSystem<ResolveTransfers>();
		}

		protected override void OnUpdate()
		{
			using NativeArray<CItemTransferProposal> nativeArray = Proposals.ToComponentDataArray<CItemTransferProposal>(Allocator.Temp);
			EntityContext ctx = new EntityContext(base.EntityManager);
			foreach (CItemTransferProposal item in nativeArray)
			{
				if (ResolveTransfers.ResolveSend(item.ResolutionSystem, out var system))
				{
					system.Tidy(ctx, item);
				}
			}
			base.EntityManager.DestroyEntity(Proposals);
			base.EntityManager.DestroyEntity(Accepts);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
