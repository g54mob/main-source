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
	public class AssignCustomerLocations : GameSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass0_0
		{
			public AssignCustomerLocations _003C_003E4__this;

			public EntityCommandBuffer ecb;

			internal void _003COnUpdate_003Eb__0(Entity e, in DynamicBuffer<CGroupMember> group, in CAssignedTable table)
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

					public LambdaParameterValueProvider_DynamicBuffer<CGroupMember>.Runtime runtime_group;

					public LambdaParameterValueProvider_IComponentData<CAssignedTable>.Runtime runtime_table;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[ReadOnly]
				private LambdaParameterValueProvider_DynamicBuffer<CGroupMember> forParameter_group;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CAssignedTable> forParameter_table;

				public void ScheduleTimeInitialize(AssignCustomerLocations componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_group.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_table.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_group = forParameter_group.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_table = forParameter_table.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public EntityCommandBuffer ecb;

			[NoAlias]
			private BufferFromEntity<CTablePlace> _BufferFromEntity_CTablePlace_0;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CCustomerTablePlacement> _ComponentDataFromEntity_CCustomerTablePlacement_1;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, in DynamicBuffer<CGroupMember> group, in CAssignedTable table)
			{
				DynamicBuffer<CTablePlace> dynamicBuffer = _BufferFromEntity_CTablePlace_0[table];
				for (int i = 0; i < group.Length; i++)
				{
					CTablePlace cTablePlace = dynamicBuffer[i];
					CGroupMember cGroupMember = group[i];
					if (!_ComponentDataFromEntity_CCustomerTablePlacement_1.HasComponent(cGroupMember))
					{
						ecb.AddComponent<CCustomerTablePlacement>(cGroupMember);
					}
					ecb.SetComponent(cGroupMember, new CCustomerTablePlacement
					{
						SeatPosition = cTablePlace.SeatPosition,
						TablePosition = cTablePlace.TablePosition
					});
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				ecb = displayClass.ecb;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				displayClass.ecb = ecb;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), runtimes.runtime_group.For(i), in runtimes.runtime_table.For(i));
				}
			}

			public void ScheduleTimeInitialize(AssignCustomerLocations componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_BufferFromEntity_CTablePlace_0 = ((ComponentSystemBase)componentSystem).GetBufferFromEntity<CTablePlace>(false);
				_ComponentDataFromEntity_CCustomerTablePlacement_1 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CCustomerTablePlacement>(true);
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
			_003C_003Ec__DisplayClass0_0 displayClass = new _003C_003Ec__DisplayClass0_0
			{
				_003C_003E4__this = this,
				ecb = GetCommandBuffer(ECB.End)
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
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[3]
			{
				ComponentType.ReadOnly<CAtTable>(),
				ComponentType.ReadOnly<CGroupMember>(),
				ComponentType.ReadOnly<CAssignedTable>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
