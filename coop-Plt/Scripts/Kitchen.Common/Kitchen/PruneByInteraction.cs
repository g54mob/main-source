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
	[UpdateInGroup(typeof(ItemTransferLatePrune), OrderLast = true)]
	public class PruneByInteraction : GenericSystemBase
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

					public LambdaParameterValueProvider_IComponentData<CInteractionTransferProposal>.Runtime runtime_interaction_transfer_proposal;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CItemTransferProposal> forParameter_proposal;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CInteractionTransferProposal> forParameter_interaction_transfer_proposal;

				public void ScheduleTimeInitialize(PruneByInteraction componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_proposal.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_interaction_transfer_proposal.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_proposal = forParameter_proposal.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_interaction_transfer_proposal = forParameter_interaction_transfer_proposal.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public PruneByInteraction hostInstance;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			public void OriginalLambdaBody(Entity e, ref CItemTransferProposal proposal, [In] ref CInteractionTransferProposal interaction_transfer_proposal)
			{
				hostInstance._003COnUpdate_003Eb__0_0(e, ref proposal, in interaction_transfer_proposal);
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_proposal.For(i), ref runtimes.runtime_interaction_transfer_proposal.For(i));
				}
			}

			public void ScheduleTimeInitialize(PruneByInteraction componentSystem)
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
		private void _003COnUpdate_003Eb__0_0(Entity e, ref CItemTransferProposal proposal, in CInteractionTransferProposal interaction_transfer_proposal)
		{
			if (proposal.Status != ItemTransferStatus.Pruned && Require<CAttemptingInteraction>(interaction_transfer_proposal.Interactor, out CAttemptingInteraction comp) && comp.Result != InteractionResult.Performed)
			{
				bool num = (interaction_transfer_proposal.RequireHeld && comp.IsHeld) || (interaction_transfer_proposal.RequirePress && !comp.IsHeld);
				bool flag = (interaction_transfer_proposal.AllowGrab && comp.Type == InteractionType.Grab) || (interaction_transfer_proposal.AllowAct && comp.Type == InteractionType.Act);
				if (Has<CEquippableTool>(proposal.Item) && !flag && comp.Type == InteractionType.Act)
				{
					flag = true;
					proposal.Flags |= TransferFlags.ToolGrab;
				}
				if (proposal.Status == ItemTransferStatus.Accepted)
				{
					comp.Result = InteractionResult.Possible;
				}
				if (!num || !flag)
				{
					proposal.Status = ItemTransferStatus.Pruned;
				}
				base.EntityManager.SetComponentData(interaction_transfer_proposal.Interactor, comp);
				if (proposal.Status == ItemTransferStatus.Pruned)
				{
					proposal.PrunedBy = this;
				}
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
