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
	[UpdateInGroup(typeof(DetermineEffectsGroup))]
	public class DetermineRoom : GameEffectSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass2_0
		{
			public NativeArray<Entity> effectors;

			public DetermineRoom _003C_003E4__this;

			internal void _003COnUpdate_003Eb__0(Entity e, ref DynamicBuffer<CAffectedBy> affected_by, in CPosition position)
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

					public LambdaParameterValueProvider_DynamicBuffer<CAffectedBy>.Runtime runtime_affected_by;

					public LambdaParameterValueProvider_IComponentData<CPosition>.Runtime runtime_position;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_DynamicBuffer<CAffectedBy> forParameter_affected_by;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_position;

				public void ScheduleTimeInitialize(DetermineRoom componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_affected_by.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_position.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_affected_by = forParameter_affected_by.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_position = forParameter_position.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public NativeArray<Entity> effectors;

			public DetermineRoom _003C_003E4__this;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CPosition> _ComponentDataFromEntity_CPosition_0;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref DynamicBuffer<CAffectedBy> affected_by, in CPosition position)
			{
				for (int i = 0; i < effectors.Length; i++)
				{
					Entity entity = effectors[i];
					int room = _003C_003E4__this.TileManager.GetRoom(position);
					int room2 = _003C_003E4__this.TileManager.GetRoom(_ComponentDataFromEntity_CPosition_0[entity]);
					if (room == room2)
					{
						affected_by.Add(entity);
					}
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				effectors = displayClass.effectors;
				_003C_003E4__this = displayClass._003C_003E4__this;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				displayClass.effectors = effectors;
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
					Entity e = runtimes.runtime_e.For(i);
					DynamicBuffer<CAffectedBy> affected_by = runtimes.runtime_affected_by.For(i);
					OriginalLambdaBody(e, ref affected_by, in runtimes.runtime_position.For(i));
				}
			}

			public void ScheduleTimeInitialize(DetermineRoom componentSystem, ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CPosition_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CPosition>(true);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery EffectAppliers;

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void Initialise()
		{
			base.Initialise();
			EffectAppliers = GetEntityQuery(typeof(CAppliesEffect), typeof(CEffectRangeRoom), typeof(CPosition));
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass2_0 displayClass = new _003C_003Ec__DisplayClass2_0
			{
				_003C_003E4__this = this,
				effectors = EffectAppliers.ToEntityArray(Allocator.TempJob)
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
			displayClass.effectors.Dispose();
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
				ComponentType.ReadWrite<CAffectedBy>(),
				ComponentType.ReadOnly<CPosition>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
