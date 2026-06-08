#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using KitchenData;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	public class AcceptIntoBin : TransferAcceptSystem
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass0_0
		{
			public AcceptIntoBin _003C_003E4__this;

			public bool sink_bins_blocked;

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

				public void ScheduleTimeInitialize(AcceptIntoBin componentSystem)
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

			public AcceptIntoBin _003C_003E4__this;

			public bool sink_bins_blocked;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			public unsafe static StructuralChangeEntityProvider.PerformLambdaDelegate _performLambdaDelegate = PerformLambda;

			internal void OriginalLambdaBody(Entity e, ref CItemTransferProposal proposal)
			{
				if (proposal.Status == ItemTransferStatus.Pruned || (proposal.Flags & TransferFlags.RequireMerge) != TransferFlags.Null || !_003C_003E4__this.Data.TryGet<Item>(proposal.ItemData.ID, out var output))
				{
					return;
				}
				CApplianceBin comp;
				bool flag = _003C_003E4__this.Require<CApplianceBin>(proposal.Destination, out comp);
				bool flag2 = _003C_003E4__this.Has<CApplianceExternalBin>(proposal.Destination);
				bool flag3 = !sink_bins_blocked && output.IsSinkDisposable && _003C_003E4__this.Has<CApplianceSinkBin>(proposal.Destination);
				if ((!flag && !flag2 && !flag3) || (output.DisposesTo != null && (proposal.Flags & TransferFlags.NoReturns) != TransferFlags.Null) || (flag && comp.Capacity <= comp.CurrentAmount))
				{
					return;
				}
				if (flag2)
				{
					if (output.IsIndisposable && !output.ItemStorageFlags.HasFlag(ItemStorage.OutsideRubbish))
					{
						return;
					}
				}
				else if (output.IsIndisposable)
				{
					return;
				}
				_003C_003E4__this.Accept(e, TransferFlags.SpecialInteraction);
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
				sink_bins_blocked = displayClass.sink_bins_blocked;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.sink_bins_blocked = sink_bins_blocked;
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

			public void ScheduleTimeInitialize(AcceptIntoBin componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
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
				sink_bins_blocked = GetOrCreate<SGlobalStatusList>().Has(RestaurantStatus.BlockSinkBins)
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
			if (Require<CItemTransferProposal>(proposal_entity, out CItemTransferProposal comp) && base.Data.TryGet<Item>(comp.ItemData.ID, out var output))
			{
				if (output.DisposesTo != null)
				{
					return_item = ctx.CreateItem(output.DisposesTo.ID);
				}
				ctx.Destroy(comp.Item);
				New(new CAcceptedIntoBinEvent
				{
					ID = comp.ItemData.ID
				});
				if (Require<CApplianceBin>(comp.Destination, out CApplianceBin comp2))
				{
					comp2.CurrentAmount++;
					ctx.Set(comp.Destination, comp2);
				}
			}
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
