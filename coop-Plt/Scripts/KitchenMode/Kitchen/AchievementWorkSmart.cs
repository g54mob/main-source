#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	public class AchievementWorkSmart : AchievementRequiresEndDay<AchievementWorkSmart.SState>
	{
		public struct SState : IComponentData
		{
			public bool IsSatisfied;

			public bool NeedsAssignment;
		}

		public struct CTracker : IComponentData
		{
			public Vector3 Start;
		}

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass9_0
		{
			public bool needs_assign;

			public bool is_invalid;

			internal void _003CCheck_003Eb__0(Entity e, ref CTracker tracker, in CPosition pos)
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

					public LambdaParameterValueProvider_IComponentData<CTracker>.Runtime runtime_tracker;

					public LambdaParameterValueProvider_IComponentData<CPosition>.Runtime runtime_pos;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CTracker> forParameter_tracker;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_pos;

				public void ScheduleTimeInitialize(AchievementWorkSmart componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_tracker.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_pos.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_tracker = forParameter_tracker.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_pos = forParameter_pos.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public bool needs_assign;

			public bool is_invalid;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref CTracker tracker, in CPosition pos)
			{
				if (needs_assign)
				{
					tracker.Start = pos.Position;
				}
				else if (!is_invalid && (tracker.Start - pos.Position).Chebyshev() > 1f)
				{
					is_invalid = true;
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass9_0 displayClass)
			{
				needs_assign = displayClass.needs_assign;
				is_invalid = displayClass.is_invalid;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass9_0 displayClass)
			{
				displayClass.needs_assign = needs_assign;
				displayClass.is_invalid = is_invalid;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_tracker.For(i), in runtimes.runtime_pos.For(i));
				}
			}

			public void ScheduleTimeInitialize(AchievementWorkSmart componentSystem, ref _003C_003Ec__DisplayClass9_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_Check_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		public const float MaxDist = 1f;

		private EntityQuery Players;

		private EntityQuery _003C_003ECheck_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003ECheck_LambdaJob0_profilerMarker;

		protected override string Identifier => "WORK_SMART";

		protected override void Initialise()
		{
			base.Initialise();
			Players = GetEntityQuery(new QueryHelper().All(typeof(CPlayer), typeof(CPosition)).None(typeof(CTracker)));
		}

		protected override bool IsSatisfied(SState data)
		{
			return data.IsSatisfied;
		}

		protected override void Reset(ref SState data)
		{
			data.NeedsAssignment = true;
			data.IsSatisfied = false;
		}

		protected override void Check(ref SState data)
		{
			_003C_003Ec__DisplayClass9_0 displayClass = default(_003C_003Ec__DisplayClass9_0);
			base.EntityManager.AddComponent<CTracker>(Players);
			displayClass.needs_assign = data.NeedsAssignment;
			displayClass.is_invalid = false;
			if (displayClass.needs_assign)
			{
				data.IsSatisfied = true;
			}
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
			data.NeedsAssignment = false;
			if (displayClass.is_invalid)
			{
				data.IsSatisfied = false;
			}
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003ECheck_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForCheck_LambdaJob0_From(this);
			_003C_003Ec__DisplayClass_Check_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_Check_LambdaJob0.RunWithoutJobSystem;
			_003C_003ECheck_LambdaJob0_profilerMarker = new ProfilerMarker("Check_LambdaJob0");
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForCheck_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
			{
				ComponentType.ReadWrite<CTracker>(),
				ComponentType.ReadOnly<CPosition>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
