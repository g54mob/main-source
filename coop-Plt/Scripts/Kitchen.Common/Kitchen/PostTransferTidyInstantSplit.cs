using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(ItemTransferPostResolve))]
	public class PostTransferTidyInstantSplit : GenericSystemBase
	{
		private EntityQuery Accepts;

		protected override void Initialise()
		{
			base.Initialise();
			Accepts = GetEntityQuery(typeof(CItemTransferAccept));
		}

		protected override void OnUpdate()
		{
			using NativeArray<CItemTransferAccept> nativeArray = Accepts.ToComponentDataArray<CItemTransferAccept>(Allocator.Temp);
			foreach (CItemTransferAccept item in nativeArray)
			{
				if (item.Status == ItemAcceptStatus.Accepted && Require<CItemTransferProposal>(item.Proposal, out CItemTransferProposal comp) && Require<CInstantlyCompleteSplit>(comp.Destination, out CInstantlyCompleteSplit comp2))
				{
					Set<CInstantProcessToolOnCooldown>(comp2.Tool);
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
