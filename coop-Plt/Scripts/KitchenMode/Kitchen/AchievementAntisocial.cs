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
	public class AchievementAntisocial : AchievementRequiresEndDay<AchievementAntisocial.SState>
	{
		public struct SState : IComponentData
		{
			public bool HasInvalidated;

			public bool HasBegun;
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct CAntisocialReceivedItem : IComponentData
		{
		}

		public struct CAntisocialTracker : IComponentData
		{
			public Entity StartHolder;

			public bool HasLeft;
		}

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass10_0
		{
			public bool is_invalidated;

			internal void _003CCheck_003Eb__0(Entity e, in CAntisocialReceivedItem rec, in CAntisocialTracker track)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_Check_LambdaJob0 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					public LambdaParameterValueProvider_IComponentData_Tag<CAntisocialReceivedItem>.Runtime runtime_rec;

					public LambdaParameterValueProvider_IComponentData<CAntisocialTracker>.Runtime runtime_track;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData_Tag<CAntisocialReceivedItem> forParameter_rec;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CAntisocialTracker> forParameter_track;

				public void ScheduleTimeInitialize(AchievementAntisocial componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_rec.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_track.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_rec = forParameter_rec.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_track = forParameter_track.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public bool is_invalidated;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, in CAntisocialReceivedItem rec, in CAntisocialTracker track)
			{
				if (!is_invalidated && !track.HasLeft)
				{
					is_invalidated = true;
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass10_0 displayClass)
			{
				is_invalidated = displayClass.is_invalidated;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass10_0 displayClass)
			{
				displayClass.is_invalidated = is_invalidated;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), runtimes.runtime_rec.For(i), in runtimes.runtime_track.For(i));
				}
			}

			public void ScheduleTimeInitialize(AchievementAntisocial componentSystem, ref _003C_003Ec__DisplayClass10_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_Check_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery UntrackedItems;

		private EntityQuery EventQuery;

		private EntityQuery _003C_003ECheck_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003ECheck_LambdaJob0_profilerMarker;

		protected override string Identifier => "ANTISOCIAL";

		protected override bool IsSatisfied(SState data)
		{
			if (!data.HasInvalidated)
			{
				return data.HasBegun;
			}
			return false;
		}

		protected override void Reset(ref SState data)
		{
			data = default(SState);
		}

		protected override void Initialise()
		{
			base.Initialise();
		}

		protected override void Check(ref SState data)
		{
			_003C_003Ec__DisplayClass10_0 displayClass = default(_003C_003Ec__DisplayClass10_0);
			if (Has<SIsDayTime>())
			{
				data.HasBegun = true;
			}
			if (Has<SGameOver>())
			{
				data.HasInvalidated = true;
				return;
			}
			displayClass.is_invalidated = false;
			_ = base.Entities;
			_003C_003Ec__DisplayClass_Check_LambdaJob0 jobData = default(_003C_003Ec__DisplayClass_Check_LambdaJob0);
			jobData.ScheduleTimeInitialize(this, ref displayClass);
			CompleteDependency();
			EntityQuery query = _003C_003ECheck_LambdaJob0_entityQuery;
			InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_Check_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst;
			_003C_003ECheck_LambdaJob0_profilerMarker.Begin();
			try
			{
				InternalCompilerInterface.RunJobChunk(ref jobData, query, s_RunWithoutJobSystemDelegateFieldNoBurst);
			}
			finally
			{
				_003C_003ECheck_LambdaJob0_profilerMarker.End();
			}
			jobData.WriteToDisplayClass(ref displayClass);
			base.EntityManager.DestroyEntity(EventQuery);
			if (displayClass.is_invalidated)
			{
				data.HasInvalidated = true;
			}
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003ECheck_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForCheck_LambdaJob0_From(this);
			EventQuery = _003C_003ECheck_LambdaJob0_entityQuery;
			_003C_003Ec__DisplayClass_Check_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_Check_LambdaJob0.RunWithoutJobSystem;
			_003C_003ECheck_LambdaJob0_profilerMarker = new ProfilerMarker("Check_LambdaJob0");
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForCheck_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
			{
				ComponentType.ReadOnly<CAntisocialReceivedItem>(),
				ComponentType.ReadOnly<CAntisocialTracker>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
