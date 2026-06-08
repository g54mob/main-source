#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using KitchenData;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	public class AcceptIntoToolStorage : TransferAcceptSystem
	{
		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public StructuralChangeEntityProvider _entityProvider;

					public LambdaParameterValueProvider_Entity.StructuralChangeRuntime runtime_e;

					public LambdaParameterValueProvider_IComponentData<CItemTransferProposal>.StructuralChangeRuntime runtime_proposal;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CItemTransferProposal> forParameter_proposal;

				public void ScheduleTimeInitialize(AcceptIntoToolStorage componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_proposal.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteWithStructuralChanges(ComponentSystemBase p0, EntityQuery p1)
				{
					Runtimes result = default(Runtimes);
					result._entityProvider.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_e = forParameter_e.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_proposal = forParameter_proposal.PrepareToExecuteWithStructuralChanges(p0, p1);
					return result;
				}
			}

			public AcceptIntoToolStorage hostInstance;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			public unsafe static StructuralChangeEntityProvider.PerformLambdaDelegate _performLambdaDelegate = PerformLambda;

			public void OriginalLambdaBody(Entity e, ref CItemTransferProposal proposal)
			{
				hostInstance._003COnUpdate_003Eb__0_0(e, ref proposal);
			}

			public unsafe static void PerformLambda(void* jobStructPtr, void* runtimesPtr, Entity entity)
			{
				ref LambdaParameterValueProviders.Runtimes reference = ref UnsafeUtility.AsRef<LambdaParameterValueProviders.Runtimes>(runtimesPtr);
				Entity e = reference.runtime_e.For(entity);
				CItemTransferProposal originalComponent;
				CItemTransferProposal proposal = reference.runtime_proposal.For(entity, out originalComponent);
				UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobStructPtr).OriginalLambdaBody(e, ref proposal);
				reference.runtime_proposal.WriteBack(entity, ref proposal, ref originalComponent);
			}

			public unsafe void Execute(ComponentSystemBase componentSystem, EntityQuery query)
			{
				LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteWithStructuralChanges(componentSystem, query);
				_runtimes = &runtimes;
				runtimes._entityProvider.IterateEntities(System.Runtime.CompilerServices.Unsafe.AsPointer(ref this), _runtimes, _performLambdaDelegate);
			}

			public void ScheduleTimeInitialize(AcceptIntoToolStorage componentSystem)
			{
				hostInstance = componentSystem;
			}
		}

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void OnUpdate()
		{
			_ = base.Entities;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 _003C_003Ec__DisplayClass_OnUpdate_LambdaJob1 = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.ScheduleTimeInitialize(this);
			CompleteDependency();
			EntityQuery query = _003C_003EOnUpdate_LambdaJob0_entityQuery;
			_003C_003EOnUpdate_LambdaJob0_profilerMarker.Begin();
			try
			{
				_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.Execute(this, query);
			}
			finally
			{
				_003C_003EOnUpdate_LambdaJob0_profilerMarker.End();
			}
		}

		public override void AcceptTransfer(Entity proposal_entity, Entity acceptance, EntityContext ctx, out Entity return_item)
		{
			return_item = default(Entity);
			if (Require<CItemTransferProposal>(proposal_entity, out CItemTransferProposal comp))
			{
				Entity entity = DetermineStorageTool(comp.Destination);
				if (RequireBuffer(entity, out DynamicBuffer<CItemStored> comp2))
				{
					comp2.Add(comp.Item);
					ctx.Set(entity, new CToolInteractionMemory
					{
						LastEntity = comp.Source,
						LastWasDrop = false
					});
					ctx.Set(comp.Item, new CStoredBy
					{
						Storage = entity
					});
				}
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

		[CompilerGenerated]
		private void _003COnUpdate_003Eb__0_0(Entity e, ref CItemTransferProposal proposal)
		{
			if (proposal.Status == ItemTransferStatus.Pruned || (proposal.Flags & TransferFlags.RequireMerge) != TransferFlags.Null)
			{
				return;
			}
			Entity e2 = DetermineStorageTool(proposal.Destination);
			if (Has<CPreventToolStorageAccess>(e2) || !Require<CItemStorage>(e2, out CItemStorage comp) || !RequireBuffer(e2, out DynamicBuffer<CItemStored> comp2) || Has<CToolStorage>(proposal.Item) || (Has<CToolStorageNoTools>(e2) && Has<CEquippableTool>(proposal.Item)) || comp.Capacity <= comp2.Length)
			{
				return;
			}
			bool flag = false;
			if (Require<CToolInteractionMemory>(e2, out CToolInteractionMemory comp3))
			{
				flag = comp3.LastEntity == proposal.Source && comp3.LastWasDrop;
			}
			if (!GameData.Main.TryGet<Item>(proposal.ItemData, out var output) || output.ItemCategory != ItemCategory.Generic)
			{
				return;
			}
			if (Require<CToolStorageOnlySameItem>(e2, out CToolStorageOnlySameItem _))
			{
				int num = 0;
				ItemList other = default(ItemList);
				foreach (CItemStored item in comp2)
				{
					if (Require<CItem>((Entity)item, out CItem comp5))
					{
						num = comp5.ID;
						other = comp5.Items;
						break;
					}
				}
				if (num != 0 && (proposal.ItemType != num || !proposal.ItemComponents.IsEquivalent(other)))
				{
					return;
				}
			}
			Accept(e, (TransferFlags)(8 | (flag ? 8192 : 0)));
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EOnUpdate_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(this);
			_003C_003EOnUpdate_LambdaJob0_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob0");
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[1] { ComponentType.ReadWrite<CItemTransferProposal>() };
			return componentSystem.GetEntityQuery(array);
		}
	}
}
