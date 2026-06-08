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
	[UpdateInGroup(typeof(ItemTransferEarlyPrune))]
	public class PruneByAutomations : GenericSystemBase
	{
		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					public LambdaParameterValueProvider_IComponentData<CItemTransferProposal>.Runtime runtime_proposal;

					public LambdaParameterValueProvider_IComponentData<CInteractionTransferProposal>.Runtime runtime_interaction;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CItemTransferProposal> forParameter_proposal;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CInteractionTransferProposal> forParameter_interaction;

				public void ScheduleTimeInitialize(PruneByAutomations componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_proposal.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_interaction.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_proposal = forParameter_proposal.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_interaction = forParameter_interaction.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public PruneByAutomations hostInstance;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			public void OriginalLambdaBody(Entity e, ref CItemTransferProposal proposal, [In] ref CInteractionTransferProposal interaction)
			{
				hostInstance._003COnUpdate_003Eb__0_0(e, ref proposal, in interaction);
			}

			public unsafe void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
			{
				LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteOnEntitiesInMethod(ref chunk, chunkIndex, firstEntityIndex);
				_runtimes = &runtimes;
				IterateEntities(ref chunk, ref *_runtimes);
			}

			public void IterateEntities(ref ArchetypeChunk chunk, ref LambdaParameterValueProviders.Runtimes runtimes)
			{
				int count = chunk.Count;
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_proposal.For(i), ref runtimes.runtime_interaction.For(i));
				}
			}

			public void ScheduleTimeInitialize(PruneByAutomations componentSystem)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				hostInstance = componentSystem;
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void OnUpdate()
		{
			_ = base.Entities;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 jobData = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0);
			jobData.ScheduleTimeInitialize(this);
			CompleteDependency();
			EntityQuery query = _003C_003EOnUpdate_LambdaJob0_entityQuery;
			InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst;
			_003C_003EOnUpdate_LambdaJob0_profilerMarker.Begin();
			try
			{
				InternalCompilerInterface.RunJobChunk(ref jobData, query, s_RunWithoutJobSystemDelegateFieldNoBurst);
			}
			finally
			{
				_003C_003EOnUpdate_LambdaJob0_profilerMarker.End();
			}
		}

		[CompilerGenerated]
		private void _003COnUpdate_003Eb__0_0(Entity e, ref CItemTransferProposal proposal, in CInteractionTransferProposal interaction)
		{
			if (proposal.Status == ItemTransferStatus.Pruned)
			{
				return;
			}
			if (interaction.Interactor == proposal.Source && Require<CAutomatedInteractor>(proposal.Source, out CAutomatedInteractor comp))
			{
				if (comp.RequiredFlags.Has(TransferFlags.NoDrops) && !proposal.Flags.Has(TransferFlags.Split))
				{
					proposal.Status = ItemTransferStatus.Pruned;
				}
				proposal.Flags |= comp.RequiredFlags;
				if ((proposal.Flags & TransferFlags.Split) == 0 && (comp.RequiredFlags & TransferFlags.RequireSplit) != TransferFlags.Null)
				{
					proposal.Status = ItemTransferStatus.Pruned;
				}
			}
			if (interaction.Interactor == proposal.Destination && Require<CAutomatedInteractor>(proposal.Destination, out CAutomatedInteractor comp2))
			{
				if (comp2.DoNotReceive)
				{
					proposal.Status = ItemTransferStatus.Pruned;
				}
				if (!proposal.Flags.Has(TransferFlags.Drop) && comp2.RequiredFlags.Has(TransferFlags.RequireDrop))
				{
					proposal.Status = ItemTransferStatus.Pruned;
				}
				if (!proposal.Flags.Has(TransferFlags.Split) && !proposal.Flags.Has(TransferFlags.Provider) && comp2.RequiredFlags.Has(TransferFlags.RequireSplit))
				{
					proposal.Status = ItemTransferStatus.Pruned;
				}
			}
			if (proposal.Status == ItemTransferStatus.Pruned)
			{
				proposal.PrunedBy = this;
			}
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EOnUpdate_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(this);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem;
			_003C_003EOnUpdate_LambdaJob0_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob0");
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
			{
				ComponentType.ReadWrite<CItemTransferProposal>(),
				ComponentType.ReadOnly<CInteractionTransferProposal>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
