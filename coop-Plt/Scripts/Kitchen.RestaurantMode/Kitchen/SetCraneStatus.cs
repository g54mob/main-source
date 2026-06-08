#define ENABLE_PROFILER
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	public class SetCraneStatus : GameSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass1_0
		{
			public bool remove_all_cranes;

			public SetCraneStatus _003C_003E4__this;

			internal void _003COnUpdate_003Eb__0(Entity e, ref CIsInteractor interactor, ref CRequiresView view)
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
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					public LambdaParameterValueProvider_IComponentData<CIsInteractor>.Runtime runtime_interactor;

					public LambdaParameterValueProvider_IComponentData<CRequiresView>.Runtime runtime_view;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CIsInteractor> forParameter_interactor;

				private LambdaParameterValueProvider_IComponentData<CRequiresView> forParameter_view;

				public void ScheduleTimeInitialize(SetCraneStatus componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_interactor.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_view.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_interactor = forParameter_interactor.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_view = forParameter_view.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public bool remove_all_cranes;

			public SetCraneStatus _003C_003E4__this;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref CIsInteractor interactor, ref CRequiresView view)
			{
				bool num = !remove_all_cranes && _003C_003E4__this.Has<CIsCraneMode>(e);
				ViewType type = view.Type;
				if (num != (type == ViewType.PlayerCrane))
				{
					_003C_003E4__this.PlayersToRefresh.Add(e);
				}
				if (num)
				{
					interactor.InteractionOffset = 0f;
					view.Type = ViewType.PlayerCrane;
				}
				else
				{
					interactor.InteractionOffset = 0.7f;
					view.Type = ViewType.Player;
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				remove_all_cranes = displayClass.remove_all_cranes;
				_003C_003E4__this = displayClass._003C_003E4__this;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				displayClass.remove_all_cranes = remove_all_cranes;
				displayClass._003C_003E4__this = _003C_003E4__this;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_interactor.For(i), ref runtimes.runtime_view.For(i));
				}
			}

			public void ScheduleTimeInitialize(SetCraneStatus componentSystem, ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private HashSet<Entity> PlayersToRefresh = new HashSet<Entity>();

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass1_0 displayClass = new _003C_003Ec__DisplayClass1_0
			{
				_003C_003E4__this = this,
				remove_all_cranes = (Has<SIsDayTime>() || !Has<SIsNightTime>() || !Has<SKitchenMarker>())
			};
			PlayersToRefresh.Clear();
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
			foreach (Entity item in PlayersToRefresh)
			{
				if (displayClass.remove_all_cranes)
				{
					Unset<CIsCraneMode>(item);
				}
				Set<CRemoveView>(item);
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
			(array[0] = new EntityQueryDesc()).All = new ComponentType[3]
			{
				ComponentType.ReadOnly<CPlayer>(),
				ComponentType.ReadWrite<CIsInteractor>(),
				ComponentType.ReadWrite<CRequiresView>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
