#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	public class UpdatePlayerView : ResponsiveViewSystemBase<PlayerView.ViewData, PlayerView.ResponseData>
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass0_0
		{
			public UpdatePlayerView _003C_003E4__this;

			public SGameTime game_time;

			internal void _003COnUpdate_003Eb__0(Entity entity, int entityInQueryIndex, ref CPosition pos, in CInputData input_data, in CItemHolder holding, in CLinkedView linked_view, in CPlayer player)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public LambdaParameterValueProvider_Entity.Runtime runtime_entity;

					public LambdaParameterValueProvider_EntityInQueryIndex.Runtime runtime_entityInQueryIndex;

					public LambdaParameterValueProvider_IComponentData<CPosition>.Runtime runtime_pos;

					public LambdaParameterValueProvider_IComponentData<CInputData>.Runtime runtime_input_data;

					public LambdaParameterValueProvider_IComponentData<CItemHolder>.Runtime runtime_holding;

					public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;

					public LambdaParameterValueProvider_IComponentData<CPlayer>.Runtime runtime_player;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_entity;

				[ReadOnly]
				private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_pos;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CInputData> forParameter_input_data;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CItemHolder> forParameter_holding;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPlayer> forParameter_player;

				public void ScheduleTimeInitialize(UpdatePlayerView componentSystem)
				{
					forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_pos.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_input_data.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_holding.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_player.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
						runtime_pos = forParameter_pos.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_input_data = forParameter_input_data.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_holding = forParameter_holding.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_player = forParameter_player.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public UpdatePlayerView _003C_003E4__this;

			public SGameTime game_time;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CAttemptingInteraction> _ComponentDataFromEntity_CAttemptingInteraction_0;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity entity, int entityInQueryIndex, ref CPosition pos, in CInputData input_data, in CItemHolder holding, in CLinkedView linked_view, in CPlayer player)
			{
				bool isInteracting = false;
				int process = 0;
				if (_ComponentDataFromEntity_CAttemptingInteraction_0.HasComponent(entity))
				{
					CAttemptingInteraction cAttemptingInteraction = _ComponentDataFromEntity_CAttemptingInteraction_0[entity];
					isInteracting = cAttemptingInteraction.Result == InteractionResult.Performed && cAttemptingInteraction.Type == InteractionType.Act;
					process = cAttemptingInteraction.Process;
				}
				_003C_003E4__this.SendUpdate(linked_view, new PlayerView.ViewData
				{
					Inputs = (input_data.IsCaptured ? CInputData.Captured : input_data),
					Speed = player.Speed,
					IsPaused = game_time.IsPaused,
					IsHolding = (holding.HeldItem != default(Entity)),
					IsInteracting = isInteracting,
					Process = process,
					InputSource = player.InputSource,
					PlayerID = player.ID
				});
				PlayerView.ResponseData result = default(PlayerView.ResponseData);
				if (_003C_003E4__this.ApplyUpdates(linked_view.Identifier, delegate(PlayerView.ResponseData data)
				{
					result = data;
				}, only_final_update: true) && !pos.ForceSnap)
				{
					pos.Position = result.Position;
					pos.Rotation = result.Rotation;
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
				game_time = displayClass.game_time;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.game_time = game_time;
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
					OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), ref runtimes.runtime_pos.For(i), in runtimes.runtime_input_data.For(i), in runtimes.runtime_holding.For(i), in runtimes.runtime_linked_view.For(i), in runtimes.runtime_player.For(i));
				}
			}

			public void ScheduleTimeInitialize(UpdatePlayerView componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CAttemptingInteraction_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CAttemptingInteraction>(true);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SGameTime_8;

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass0_0 displayClass = new _003C_003Ec__DisplayClass0_0
			{
				_003C_003E4__this = this,
				game_time = _SingletonEntityQuery_SGameTime_8.GetSingleton<SGameTime>()
			};
			_ = base.Entities;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 jobData = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0);
			jobData.ScheduleTimeInitialize(this, ref displayClass);
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
			jobData.WriteToDisplayClass(ref displayClass);
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EOnUpdate_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(this);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem;
			_003C_003EOnUpdate_LambdaJob0_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob0");
			_SingletonEntityQuery_SGameTime_8 = GetEntityQuery(ComponentType.ReadOnly<SGameTime>());
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[5]
			{
				ComponentType.ReadOnly<CPlayer>(),
				ComponentType.ReadWrite<CPosition>(),
				ComponentType.ReadOnly<CInputData>(),
				ComponentType.ReadOnly<CItemHolder>(),
				ComponentType.ReadOnly<CLinkedView>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
