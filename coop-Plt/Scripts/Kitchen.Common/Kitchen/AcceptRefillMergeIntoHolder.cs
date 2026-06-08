#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using KitchenData;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	public class AcceptRefillMergeIntoHolder : TransferAcceptSystem
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

				public void ScheduleTimeInitialize(AcceptRefillMergeIntoHolder componentSystem)
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

			public AcceptRefillMergeIntoHolder hostInstance;

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

			public void ScheduleTimeInitialize(AcceptRefillMergeIntoHolder componentSystem)
			{
				hostInstance = componentSystem;
			}
		}

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void OnUpdate()
		{
			new EntityContext(base.EntityManager);
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
			if (!Require<CItemTransferProposal>(proposal_entity, out CItemTransferProposal comp) || !Require<CItemHolder>(comp.Destination, out CItemHolder comp2))
			{
				return;
			}
			CSplittableItem comp3;
			bool flag = Require<CSplittableItem>(comp.Item, out comp3);
			if (!Require<CSplittableItem>((Entity)comp2, out CSplittableItem comp4))
			{
				return;
			}
			if (!flag)
			{
				if (comp4.RemainingCount < comp4.TotalCount)
				{
					comp4.RemainingCount++;
					comp4.RemainingCount = Mathf.Clamp(comp4.RemainingCount, 0, comp4.TotalCount);
					ctx.Set(comp2, comp4);
					ctx.Destroy(comp.Item);
				}
			}
			else if (comp4.RemainingCount < comp4.TotalCount && comp3.RemainingCount > 0)
			{
				int value = comp4.TotalCount - comp4.RemainingCount;
				value = Mathf.Clamp(value, 0, comp3.RemainingCount);
				comp4.RemainingCount += value;
				comp4.RemainingCount = Mathf.Clamp(comp4.RemainingCount, 0, comp4.TotalCount);
				comp3.RemainingCount -= value;
				ctx.Set(comp.Item, comp3);
				ctx.Set(comp2, comp4);
				return_item = comp.Item;
			}
		}

		[CompilerGenerated]
		private void _003COnUpdate_003Eb__0_0(Entity e, ref CItemTransferProposal proposal)
		{
			if (proposal.Status == ItemTransferStatus.Pruned || !Require<CItemHolder>(proposal.Destination, out CItemHolder comp) || comp.HeldItem == default(Entity) || (Require<CItemHolderFilter>(proposal.Destination, out CItemHolderFilter comp2) && comp2.NoDirectInsertion) || !Require<CItem>(comp.HeldItem, out CItem comp3) || (Require<CItemHolderPreventTransfer>(proposal.Destination, out CItemHolderPreventTransfer comp4) && comp4.PreventInsertingInto) || (proposal.RefuseMergeWith != 0 && proposal.RefuseMergeWith == comp3.ID) || Has<CItemHolderPreventMergeIntoHeld>(proposal.Destination) || !GameData.Main.TryGet<Item>(comp3.ID, out var output) || !GameData.Main.TryGet<Item>(proposal.ItemData.ID, out var output2) || ((output.HasImplicitlyModifiedComponents || output2.HasImplicitlyModifiedComponents) && output.ID != output2.ID))
			{
				return;
			}
			CSplittableItem comp5;
			bool flag = Require<CSplittableItem>(proposal.Item, out comp5);
			if (!Require<CSplittableItem>(comp.HeldItem, out CSplittableItem comp6))
			{
				return;
			}
			if (!flag)
			{
				if (comp6.RemainingCount >= comp6.TotalCount)
				{
					return;
				}
				ItemList itemList = proposal.ItemComponents.Without(comp6.SplitByComponentsHolder);
				ItemList itemList2 = comp3.Items.Without(comp6.SplitByComponentsHolder);
				if (!itemList.IsEquivalent(comp3.Items) && !itemList2.IsEquivalent(proposal.ItemComponents))
				{
					return;
				}
			}
			else
			{
				if (comp6.RemainingCount >= comp6.TotalCount || comp5.RemainingCount <= 0)
				{
					return;
				}
				ItemList itemList3 = proposal.ItemComponents.Without(comp6.SplitByComponentsHolder);
				ItemList other = comp3.Items.Without(comp6.SplitByComponentsHolder);
				if (!itemList3.IsEquivalent(other))
				{
					return;
				}
			}
			Accept(e, TransferFlags.RequireMerge);
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
