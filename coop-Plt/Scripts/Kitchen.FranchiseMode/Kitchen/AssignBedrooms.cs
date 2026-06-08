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
	public class AssignBedrooms : FranchiseSystem
	{
		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public LambdaParameterValueProvider_Entity.Runtime runtime_entity;

					public LambdaParameterValueProvider_EntityInQueryIndex.Runtime runtime_entityInQueryIndex;

					public LambdaParameterValueProvider_IComponentData<COwnedByPlayer>.Runtime runtime_owner;

					public LambdaParameterValueProvider_IComponentData<CBedroomPart>.Runtime runtime_part;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_entity;

				[ReadOnly]
				private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

				private LambdaParameterValueProvider_IComponentData<COwnedByPlayer> forParameter_owner;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CBedroomPart> forParameter_part;

				public void ScheduleTimeInitialize(AssignBedrooms componentSystem)
				{
					forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_owner.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_part.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
						runtime_owner = forParameter_owner.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_part = forParameter_part.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public AssignBedrooms hostInstance;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			public void OriginalLambdaBody(Entity entity, int entityInQueryIndex, ref COwnedByPlayer owner, [In] ref CBedroomPart part)
			{
				hostInstance._003COnUpdate_003Eb__3_0(entity, entityInQueryIndex, ref owner, in part);
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
					OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), ref runtimes.runtime_owner.For(i), ref runtimes.runtime_part.For(i));
				}
			}

			public void ScheduleTimeInitialize(AssignBedrooms componentSystem)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				hostInstance = componentSystem;
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery Players;

		private Dictionary<int, Entity> PlayerMap;

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void Initialise()
		{
			base.Initialise();
			Players = GetEntityQuery(typeof(CPlayer));
			PlayerMap = new Dictionary<int, Entity>();
		}

		protected override void OnUpdate()
		{
			NativeArray<Entity> nativeArray = Players.ToEntityArray(Allocator.Temp);
			NativeArray<CPlayer> nativeArray2 = Players.ToComponentDataArray<CPlayer>(Allocator.Temp);
			PlayerMap.Clear();
			for (int i = 0; i < nativeArray2.Length; i++)
			{
				CPlayer cPlayer = nativeArray2[i];
				PlayerMap.Add(cPlayer.Index, nativeArray[i]);
			}
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
			nativeArray.Dispose();
			nativeArray2.Dispose();
		}

		[CompilerGenerated]
		private void _003COnUpdate_003Eb__3_0(Entity entity, int entityInQueryIndex, ref COwnedByPlayer owner, in CBedroomPart part)
		{
			if (PlayerMap.ContainsKey(part.Room))
			{
				owner.Player = PlayerMap[part.Room];
			}
			else
			{
				owner.Player = default(Entity);
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
				ComponentType.ReadWrite<COwnedByPlayer>(),
				ComponentType.ReadOnly<CBedroomPart>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
