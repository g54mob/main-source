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
	public class FindHostStandQueuePoints : TableUpdateSystem
	{
		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					public LambdaParameterValueProvider_IComponentData<CHostStandQueueLocation>.Runtime runtime_loc;

					public LambdaParameterValueProvider_IComponentData<CPosition>.Runtime runtime_pos;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CHostStandQueueLocation> forParameter_loc;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_pos;

				public void ScheduleTimeInitialize(FindHostStandQueuePoints componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_loc.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_pos.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_loc = forParameter_loc.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_pos = forParameter_pos.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public FindHostStandQueuePoints hostInstance;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			public void OriginalLambdaBody(Entity e, ref CHostStandQueueLocation loc, [In] ref CPosition pos)
			{
				hostInstance._003COnUpdate_003Eb__2_0(e, ref loc, in pos);
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_loc.For(i), ref runtimes.runtime_pos.For(i));
				}
			}

			public void ScheduleTimeInitialize(FindHostStandQueuePoints componentSystem)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				hostInstance = componentSystem;
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery StandsWithoutLocation;

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void Initialise()
		{
			base.Initialise();
			StandsWithoutLocation = GetEntityQuery(new QueryHelper().All(typeof(CApplianceHostStand), typeof(CPathable)).None(typeof(CHostStandQueueLocation)));
		}

		protected override void OnUpdate()
		{
			base.EntityManager.AddComponent<CHostStandQueueLocation>(StandsWithoutLocation);
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

		protected bool ValidateLocation(int stand_room, Vector3 candidate)
		{
			if (base.TileManager.GetRoom(candidate) == stand_room)
			{
				return base.TileManager.GetOccupant(candidate) == default(Entity);
			}
			return false;
		}

		[CompilerGenerated]
		private void _003COnUpdate_003Eb__2_0(Entity e, ref CHostStandQueueLocation loc, in CPosition pos)
		{
			int room = base.TileManager.GetRoom(pos);
			Vector3 vector = pos + pos.Forward(1f);
			if (ValidateLocation(room, vector))
			{
				loc.Location = vector;
				return;
			}
			vector = pos + pos.Forward(1f) + pos.Right(1f);
			if (ValidateLocation(room, vector))
			{
				loc.Location = vector;
				return;
			}
			vector = pos + pos.Forward(1f) - pos.Right(1f);
			if (ValidateLocation(room, vector))
			{
				loc.Location = vector;
			}
			else
			{
				loc.Location = pos;
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
				ComponentType.ReadOnly<CApplianceHostStand>(),
				ComponentType.ReadWrite<CHostStandQueueLocation>(),
				ComponentType.ReadOnly<CPosition>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
