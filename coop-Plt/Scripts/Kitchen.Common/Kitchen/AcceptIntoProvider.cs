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
	public class AcceptIntoProvider : TransferAcceptSystem
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

				public void ScheduleTimeInitialize(AcceptIntoProvider componentSystem)
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

			public AcceptIntoProvider hostInstance;

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

			public void ScheduleTimeInitialize(AcceptIntoProvider componentSystem)
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
			if (!Require<CItemTransferProposal>(proposal_entity, out CItemTransferProposal comp) || !Require<CItemProvider>(comp.Destination, out CItemProvider comp2))
			{
				return;
			}
			if (comp2.Maximum > 0)
			{
				if (Has<CProviderFillsOnAccept>(comp.Destination))
				{
					comp2.Available = comp2.Maximum;
				}
				else
				{
					comp2.Available++;
				}
				comp2.ProvidedItem = comp.ItemData.ID;
				comp2.ProvidedComponents = comp.ItemData.Items;
				SetComponent(comp.Destination, comp2);
			}
			ctx.Destroy(comp.Item);
		}

		[CompilerGenerated]
		private void _003COnUpdate_003Eb__0_0(Entity e, ref CItemTransferProposal proposal)
		{
			if (proposal.Status == ItemTransferStatus.Pruned || (proposal.Flags & TransferFlags.RequireMerge) != TransferFlags.Null || !Require<CItemProvider>(proposal.Destination, out CItemProvider comp) || comp.PreventReturns || (comp.Maximum > 0 && comp.Available >= comp.Maximum))
			{
				return;
			}
			CDynamicItemProvider comp2;
			bool flag = Require<CDynamicItemProvider>(proposal.Destination, out comp2);
			if ((comp.ProvidedItem != proposal.ItemType || !comp.ProvidedComponents.IsEquivalent(proposal.ItemComponents)) && (!flag || comp.Available != 0))
			{
				return;
			}
			if (comp.Available == 0 && flag)
			{
				if (!base.Data.TryGet<Item>(proposal.ItemData.ID, out var output))
				{
					return;
				}
				ItemStorage itemStorageFlags = output.ItemStorageFlags;
				ItemStorage storageFlags = comp2.StorageFlags;
				if (!itemStorageFlags.HasFlag(storageFlags))
				{
					return;
				}
			}
			Accept(e, TransferFlags.Provider);
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
