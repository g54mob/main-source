using System.Collections.Generic;
using System.Linq;
using KitchenData;
using Platforms;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateInGroup(typeof(ItemTransferResolve))]
	public class ResolveTransfers : GenericSystemBase
	{
		private struct Acceptance
		{
			public Entity Entity;

			public CItemTransferAccept Data;

			public int Priority;

			public bool IgnoreDuplication;
		}

		private EntityQuery Acceptances;

		private HashSet<Entity> BlockedEntities = new HashSet<Entity>();

		private Dictionary<SystemReference, IAcceptTransfers> AcceptTransfers = new Dictionary<SystemReference, IAcceptTransfers>();

		private Dictionary<SystemReference, ISendTransfers> SendTransfers = new Dictionary<SystemReference, ISendTransfers>();

		private List<Acceptance> AcceptanceList = new List<Acceptance>();

		protected override void Initialise()
		{
			base.Initialise();
			Acceptances = GetEntityQuery(typeof(CItemTransferAccept));
		}

		public bool ResolveSend(SystemReference reference, out ISendTransfers system)
		{
			return SendTransfers.TryGetValue(reference, out system);
		}

		public override void PostInitialisation()
		{
			base.PostInitialisation();
			AcceptTransfers.Clear();
			SendTransfers.Clear();
			foreach (ComponentSystemBase system2 in base.World.Systems)
			{
				if (system2 is GenericSystemBase system)
				{
					Register(system);
				}
			}
		}

		private void Register<T>(T system) where T : GenericSystemBase
		{
			if (!(system is IAcceptTransfers value))
			{
				if (system is ISendTransfers value2)
				{
					SendTransfers[system] = value2;
				}
			}
			else
			{
				AcceptTransfers[system] = value;
			}
		}

		protected override void OnUpdate()
		{
			AcceptanceList.Clear();
			EntityContext ctx = new EntityContext(base.EntityManager);
			BlockedEntities.Clear();
			using NativeArray<Entity> nativeArray = Acceptances.ToEntityArray(Allocator.Temp);
			using NativeArray<CItemTransferAccept> nativeArray2 = Acceptances.ToComponentDataArray<CItemTransferAccept>(Allocator.Temp);
			for (int i = 0; i < nativeArray2.Length; i++)
			{
				CItemTransferAccept cItemTransferAccept = nativeArray2[i];
				if (Require<CItemTransferProposal>(cItemTransferAccept.Proposal, out CItemTransferProposal comp) && comp.Status == ItemTransferStatus.Accepted && cItemTransferAccept.Status == ItemAcceptStatus.Accepted)
				{
					FlagSorter flagSorter = new FlagSorter(comp.Flags, cItemTransferAccept.Flags);
					if (flagSorter.Sort(TransferFlags.Interaction))
					{
						flagSorter.SortEither(TransferFlags.OrderSatisfaction | TransferFlags.LooseSplit);
						flagSorter.SortEither(TransferFlags.PartialSatisfaction | TransferFlags.LooseSplit);
						flagSorter.SortEitherReversed(TransferFlags.LooseSplit);
						flagSorter.SortAcceptReversed(TransferFlags.OrderSatisfaction);
						flagSorter.SortAccept(TransferFlags.PartialSatisfaction);
						flagSorter.SortReversed(TransferFlags.Buffet);
						flagSorter.SortReversed(TransferFlags.TraySwapType);
						flagSorter.SortReversed(TransferFlags.ToolGrab);
						flagSorter.SortReversed(TransferFlags.ToolSlot);
						flagSorter.SortAcceptReversed(TransferFlags.ToolSlot);
						flagSorter.SortAccept(TransferFlags.Refresh);
						flagSorter.Sort(TransferFlags.Storage);
						flagSorter.SortAccept(TransferFlags.Storage);
						flagSorter.Sort(TransferFlags.Holder);
						flagSorter.SortAcceptReversed(TransferFlags.Provider);
						flagSorter.Sort(TransferFlags.Drop);
						flagSorter.SortAccept(TransferFlags.RequireMerge);
						flagSorter.Sort(TransferFlags.RequireMerge);
						flagSorter.SortAccept(TransferFlags.SpecialInteraction);
					}
					else
					{
						flagSorter.SortAcceptReversed(TransferFlags.OrderSatisfaction);
						flagSorter.SortAccept(TransferFlags.PartialSatisfaction);
						flagSorter.SortReversed(TransferFlags.Storage);
					}
					AcceptanceList.Add(new Acceptance
					{
						Entity = nativeArray[i],
						Data = nativeArray2[i],
						Priority = flagSorter,
						IgnoreDuplication = ((comp.Flags & TransferFlags.LooseSplit) != 0)
					});
				}
			}
			AcceptanceList.Sort(delegate(Acceptance x, Acceptance y)
			{
				if (x.Priority < y.Priority)
				{
					return 1;
				}
				return (y.Priority < x.Priority) ? (-1) : 0;
			});
			if (PlatformSettings.IsDebugBuild && new HashSet<int>(from e in AcceptanceList
				where !e.IgnoreDuplication
				select e.Priority).Count < AcceptanceList.Count((Acceptance e) => !e.IgnoreDuplication))
			{
				Debug.LogWarning("Found multiple acceptances with equal priority:");
				foreach (Acceptance acceptance in AcceptanceList)
				{
					AcceptTransfers.TryGetValue(acceptance.Data.ResolutionSystem, out var value);
					Debug.LogWarning($"{acceptance.Priority}: {value.GetType()}");
				}
			}
			foreach (Acceptance acceptance2 in AcceptanceList)
			{
				CItemTransferAccept data = acceptance2.Data;
				Entity entity = acceptance2.Entity;
				if (!Require<CItemTransferProposal>(data.Proposal, out CItemTransferProposal comp2))
				{
					continue;
				}
				if (comp2.Status == ItemTransferStatus.Resolved)
				{
					data.Status = ItemAcceptStatus.Conflicted;
					ctx.Set(acceptance2.Entity, data);
				}
				else
				{
					if (comp2.Status != ItemTransferStatus.Accepted)
					{
						continue;
					}
					if (IsBlocked(comp2.Source, comp2.Destination))
					{
						comp2.Status = ItemTransferStatus.Conflicted;
						ctx.Set(data.Proposal, comp2);
						continue;
					}
					if (Require<CTransferRequiresUnblockedEntity>(entity, out CTransferRequiresUnblockedEntity comp3) && IsBlocked(comp3.Entity))
					{
						comp2.Status = ItemTransferStatus.Conflicted;
						ctx.Set(data.Proposal, comp2);
						continue;
					}
					if (!SendTransfers.TryGetValue(comp2.ResolutionSystem, out var value2) | !AcceptTransfers.TryGetValue(data.ResolutionSystem, out var value3))
					{
						Debug.LogWarning($"Failed to find both resolvers for {comp2.ResolutionSystem} (=> {value2})/{data.ResolutionSystem} (=> {value3})");
						continue;
					}
					value2.SendTransfer(data.Proposal, entity, ctx);
					if (!Has<CItem>(comp2.Item))
					{
						Debug.LogWarning($"Entity transfer failed from {comp2.Source} to {comp2.Destination}");
						comp2.Status = ItemTransferStatus.Failed;
						ctx.Set(data.Proposal, comp2);
						continue;
					}
					comp2.Status = ItemTransferStatus.Resolved;
					ctx.Set(data.Proposal, comp2);
					value3.AcceptTransfer(data.Proposal, entity, ctx, out var return_item);
					if (Require<CInteractionTransferProposal>(data.Proposal, out CInteractionTransferProposal comp4) && Has<CPlayer>(comp4.Interactor))
					{
						if (comp4.Interactor == comp2.Destination || (Require<CToolUser>(comp4.Interactor, out CToolUser comp5) && comp5.CurrentTool == comp2.Destination))
						{
							CSoundEvent.Create(base.EntityManager, SoundEvent.PlayerItemPickUp);
						}
						else
						{
							CSoundEvent.Create(base.EntityManager, SoundEvent.PlayerItemDrop);
						}
					}
					if (return_item != default(Entity))
					{
						value2.ReceiveResult(return_item, data.Proposal, entity, ctx);
					}
				}
			}
		}

		protected bool IsBlocked(Entity e1)
		{
			return !BlockedEntities.Add(e1);
		}

		protected bool IsBlocked(Entity e1, Entity e2)
		{
			if (BlockedEntities.Contains(e1) || BlockedEntities.Contains(e2))
			{
				return true;
			}
			BlockedEntities.Add(e1);
			BlockedEntities.Add(e2);
			return false;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
