using System.Collections.Generic;
using KitchenData;
using Platforms;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(ItemTransferResolve))]
	public class DebugTransfers : GenericSystemBase
	{
		public struct Proposal
		{
			public string Entity;

			public string ProposalSystemName;

			public string Source;

			public string Destination;

			public string Item;

			public CItemTransferProposal Data;
		}

		public struct Acceptance
		{
			public string Entity;

			public string ProposalSystemName;

			public string AcceptanceSystemName;

			public CItemTransferAccept Data;
		}

		private EntityQuery Proposals;

		private EntityQuery Acceptances;

		public static List<Proposal> ProposalList = new List<Proposal>();

		public static List<Acceptance> AcceptanceList = new List<Acceptance>();

		protected override void Initialise()
		{
			Proposals = GetEntityQuery(typeof(CItemTransferProposal));
			Acceptances = GetEntityQuery(typeof(CItemTransferAccept));
		}

		protected override void OnUpdate()
		{
			if (!PlatformSettings.IsEditor)
			{
				return;
			}
			ProposalList.Clear();
			AcceptanceList.Clear();
			using NativeArray<Entity> nativeArray = Proposals.ToEntityArray(Allocator.Temp);
			using NativeArray<Entity> nativeArray2 = Acceptances.ToEntityArray(Allocator.Temp);
			foreach (Entity item in nativeArray)
			{
				Require<CItemTransferProposal>(item, out CItemTransferProposal comp);
				ProposalList.Add(new Proposal
				{
					Entity = item.ToString(),
					ProposalSystemName = SystemReference.GetName(comp.ResolutionSystem),
					Source = GetDescription(comp.Source),
					Destination = GetDescription(comp.Destination),
					Data = comp
				});
			}
			foreach (Entity item2 in nativeArray2)
			{
				Require<CItemTransferAccept>(item2, out CItemTransferAccept comp2);
				Require<CItemTransferProposal>(comp2.Proposal, out CItemTransferProposal comp3);
				AcceptanceList.Add(new Acceptance
				{
					Entity = item2.ToString(),
					ProposalSystemName = SystemReference.GetName(comp3.ResolutionSystem),
					AcceptanceSystemName = SystemReference.GetName(comp2.ResolutionSystem),
					Data = comp2
				});
			}
		}

		public string GetDescription(Entity e)
		{
			if (Has<CPlayer>(e))
			{
				return "Player";
			}
			if (Require<CAppliance>(e, out CAppliance comp) && GameData.Main.TryGet<Appliance>(comp, out var output))
			{
				return output.Name;
			}
			if (Require<CItem>(e, out CItem comp2) && GameData.Main.TryGet<Item>(comp2, out var output2))
			{
				return output2.name;
			}
			return "?";
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
