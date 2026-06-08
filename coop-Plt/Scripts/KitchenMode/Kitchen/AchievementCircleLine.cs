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
	public class AchievementCircleLine : AchievementManager
	{
		private struct CCircleLineTrack : IComponentData
		{
			public Entity StartHolder;

			public bool HasLeft;
		}

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass5_0
		{
			public AchievementCircleLine _003C_003E4__this;

			public bool is_achieved;

			internal void _003COnUpdate_003Eb__0(Entity e, ref CCircleLineTrack app, in CHeldBy holder)
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

					public LambdaParameterValueProvider_IComponentData<CCircleLineTrack>.Runtime runtime_app;

					public LambdaParameterValueProvider_IComponentData<CHeldBy>.Runtime runtime_holder;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CCircleLineTrack> forParameter_app;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CHeldBy> forParameter_holder;

				public void ScheduleTimeInitialize(AchievementCircleLine componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_app.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_holder.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_app = forParameter_app.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_holder = forParameter_holder.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public AchievementCircleLine _003C_003E4__this;

			public bool is_achieved;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref CCircleLineTrack app, in CHeldBy holder)
			{
				if (!_003C_003E4__this.Has<CAppliance>(holder))
				{
					app.StartHolder = default(Entity);
					app.HasLeft = false;
				}
				else if (app.StartHolder == default(Entity))
				{
					app.StartHolder = holder;
					app.HasLeft = false;
				}
				else if (app.StartHolder == holder)
				{
					if (app.HasLeft)
					{
						is_achieved = true;
					}
				}
				else
				{
					app.HasLeft = true;
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass5_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
				is_achieved = displayClass.is_achieved;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass5_0 displayClass)
			{
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.is_achieved = is_achieved;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_app.For(i), in runtimes.runtime_holder.For(i));
				}
			}

			public void ScheduleTimeInitialize(AchievementCircleLine componentSystem, ref _003C_003Ec__DisplayClass5_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery UntrackedItems;

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override string Identifier => "CIRCLE_LINE";

		protected override void Initialise()
		{
			base.Initialise();
			UntrackedItems = GetEntityQuery(new QueryHelper().All(typeof(CItem)).None(typeof(CCircleLineTrack)));
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass5_0 displayClass = new _003C_003Ec__DisplayClass5_0
			{
				_003C_003E4__this = this
			};
			base.EntityManager.AddComponent<CCircleLineTrack>(UntrackedItems);
			displayClass.is_achieved = false;
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
			if (displayClass.is_achieved)
			{
				Unlock();
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
				ComponentType.ReadWrite<CCircleLineTrack>(),
				ComponentType.ReadOnly<CHeldBy>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
