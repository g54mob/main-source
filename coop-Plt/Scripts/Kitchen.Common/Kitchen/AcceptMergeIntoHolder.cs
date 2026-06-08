#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	public class AcceptMergeIntoHolder : TransferAcceptSystem
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass0_0
		{
			public AcceptMergeIntoHolder _003C_003E4__this;

			public EntityContext ctx;

			internal void _003COnUpdate_003Eb__0(Entity e, ref CItemTransferProposal proposal)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}
		}

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

				public void ScheduleTimeInitialize(AcceptMergeIntoHolder componentSystem)
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

			public AcceptMergeIntoHolder _003C_003E4__this;

			public EntityContext ctx;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			public unsafe static StructuralChangeEntityProvider.PerformLambdaDelegate _performLambdaDelegate = PerformLambda;

			internal void OriginalLambdaBody(Entity e, ref CItemTransferProposal proposal)
			{
				if (proposal.Status == ItemTransferStatus.Pruned || !_003C_003E4__this.Require<CItemHolder>(proposal.Destination, out CItemHolder comp))
				{
					return;
				}
				Entity heldItem = comp.HeldItem;
				Entity result = default(Entity);
				if (!(heldItem == result) && (!_003C_003E4__this.Require<CItemHolderFilter>(proposal.Destination, out CItemHolderFilter comp2) || !comp2.NoDirectInsertion) && _003C_003E4__this.Require<CItem>(comp.HeldItem, out CItem comp3) && (!_003C_003E4__this.Require<CItemHolderPreventTransfer>(proposal.Destination, out CItemHolderPreventTransfer comp4) || !comp4.PreventInsertingInto) && (proposal.RefuseMergeWith == 0 || proposal.RefuseMergeWith != comp3.ID) && !_003C_003E4__this.Has<CItemHolderPreventMergeIntoHeld>(proposal.Destination))
				{
					_003C_003E4__this.Require<CPreventItemMerge>(comp.HeldItem, out CPreventItemMerge comp5);
					if (ctx.AttemptItemMerge(out result, proposal.ItemData.ID, comp3, proposal.ItemComponents, comp3.Items, proposal.MergeCondition, comp5.Condition, only_test: true))
					{
						_003C_003E4__this.Accept(e, TransferFlags.RequireMerge);
					}
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
				ctx = displayClass.ctx;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.ctx = ctx;
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

			public void ScheduleTimeInitialize(AcceptMergeIntoHolder componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				ReadFromDisplayClass(ref displayClass);
			}
		}

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass0_0 displayClass = new _003C_003Ec__DisplayClass0_0
			{
				_003C_003E4__this = this,
				ctx = new EntityContext(base.EntityManager)
			};
			_ = base.Entities;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 _003C_003Ec__DisplayClass_OnUpdate_LambdaJob1 = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.ScheduleTimeInitialize(this, ref displayClass);
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
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.WriteToDisplayClass(ref displayClass);
		}

		public override void AcceptTransfer(Entity proposal_entity, Entity acceptance, EntityContext ctx, out Entity return_item)
		{
			return_item = default(Entity);
			if (!Require<CItemTransferProposal>(proposal_entity, out CItemTransferProposal comp) || !Require<CItemHolder>(comp.Destination, out CItemHolder comp2) || !Require<CItem>(comp2.HeldItem, out CItem comp3))
			{
				return;
			}
			Require<CPreventItemMerge>(comp2.HeldItem, out CPreventItemMerge comp4);
			if (!ctx.AttemptItemMerge(out var result, comp.ItemData.ID, comp3, comp.ItemComponents, comp3.Items, comp.MergeCondition, comp4.Condition))
			{
				return;
			}
			if (ctx.Require<CItem>(result, out var comp5))
			{
				Entity entity = default(Entity);
				if (comp5.ID == comp3.ID)
				{
					entity = comp2.HeldItem;
				}
				else if (comp5.ID == comp.ItemType)
				{
					entity = comp.Item;
				}
				CSplittableItem comp7;
				if (ctx.Require<CSplittableItem>(entity, out var comp6))
				{
					ctx.Set(result, comp6);
				}
				else if ((comp4.Condition == MergeCondition.OnlyAsFirstSplitElement || comp.MergeCondition == MergeCondition.OnlyAsFirstSplitElement) && ctx.Require<CSplittableItem>(result, out comp7))
				{
					comp7.RemainingCount = 1;
					ctx.Set(result, comp7);
				}
			}
			ctx.Destroy(comp2.HeldItem);
			ctx.Destroy(comp.Item);
			ctx.Set(result, new CHeldBy
			{
				Holder = comp.Destination
			});
			ctx.Set(comp.Destination, new CItemHolder
			{
				HeldItem = result
			});
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
