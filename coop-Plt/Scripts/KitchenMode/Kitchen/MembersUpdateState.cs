#define ENABLE_PROFILER
using System;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.Profiling;

namespace Kitchen
{
	public class MembersUpdateState : GameSystemBase
	{
		[BurstCompile]
		[Unity.Entities.DOTSCompilerGenerated]
		[NoAlias]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				[NoAlias]
				public struct Runtimes
				{
					[NoAlias]
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData_Tag<CCustomerGroup>.Runtime runtime_group;

					[NoAlias]
					public LambdaParameterValueProvider_DynamicBuffer<CGroupMember>.Runtime runtime_members;
				}

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData_Tag<CCustomerGroup> forParameter_group;

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_DynamicBuffer<CGroupMember> forParameter_members;

				public void ScheduleTimeInitialize(MembersUpdateState componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_group.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_members.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_group = forParameter_group.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_members = forParameter_members.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public unsafe delegate void RunWithoutJobSystem_00000A13_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

			internal static class RunWithoutJobSystem_00000A13_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_00000A13_0024PostfixBurstDelegate).TypeHandle);
					}
					P_0 = Pointer;
				}

				private static IntPtr GetFunctionPointer()
				{
					IntPtr result = (IntPtr)0;
					GetFunctionPointerDiscard(ref result);
					return result;
				}

				public static void Constructor()
				{
					DeferredCompilation = BurstCompiler.CompileILPPMethod2((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/);
				}

				public static void Initialize()
				{
				}

				static RunWithoutJobSystem_00000A13_0024BurstDirectCall()
				{
					Constructor();
				}

				public unsafe static void Invoke(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					if (BurstCompiler.IsEnabled)
					{
						IntPtr functionPointer = GetFunctionPointer();
						if (functionPointer != (IntPtr)0)
						{
							((UIntPtr/*delegate* unmanaged[Cdecl]<ArchetypeChunkIterator*, void*, void>*/)(void*)(long)functionPointer)(archetypeChunkIterator, jobData);
							return;
						}
					}
					RunWithoutJobSystem_0024BurstManaged(archetypeChunkIterator, jobData);
				}
			}

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CGroupPhaseQueue> _ComponentDataFromEntity_CGroupPhaseQueue_0;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CGroupAtWaitingTable> _ComponentDataFromEntity_CGroupAtWaitingTable_1;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CGroupPhaseFood> _ComponentDataFromEntity_CGroupPhaseFood_2;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CGroupPhaseOrder> _ComponentDataFromEntity_CGroupPhaseOrder_3;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CGroupStartLeaving> _ComponentDataFromEntity_CGroupStartLeaving_4;

			[NoAlias]
			private ComponentDataFromEntity<CCustomerState> _ComponentDataFromEntity_CCustomerState_5;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void OriginalLambdaBody(Entity e, in CCustomerGroup group, in DynamicBuffer<CGroupMember> members)
			{
				CCustomerState.State state = CCustomerState.State.Normal;
				if (_ComponentDataFromEntity_CGroupPhaseQueue_0.HasComponent(e))
				{
					state = CCustomerState.State.Queue;
				}
				if (_ComponentDataFromEntity_CGroupAtWaitingTable_1.HasComponent(e))
				{
					state = CCustomerState.State.AtTable;
				}
				if (_ComponentDataFromEntity_CGroupPhaseFood_2.HasComponent(e))
				{
					state = CCustomerState.State.AtTable;
				}
				if (_ComponentDataFromEntity_CGroupPhaseOrder_3.HasComponent(e))
				{
					state = CCustomerState.State.AtTable;
				}
				if (_ComponentDataFromEntity_CGroupStartLeaving_4.HasComponent(e))
				{
					state = CCustomerState.State.Normal;
				}
				for (int i = 0; i < members.Length; i++)
				{
					_ComponentDataFromEntity_CCustomerState_5[members[i]] = state;
				}
			}

			public unsafe void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
			{
				LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteOnEntitiesInMethod(ref chunk, chunkIndex, firstEntityIndex);
				_runtimes = &runtimes;
				IterateEntities(ref chunk, ref *_runtimes);
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void IterateEntities(ref ArchetypeChunk chunk, [NoAlias] ref LambdaParameterValueProviders.Runtimes runtimes)
			{
				int count = chunk.Count;
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(runtimes.runtime_e.For(i), runtimes.runtime_group.For(i), runtimes.runtime_members.For(i));
				}
			}

			public void ScheduleTimeInitialize(MembersUpdateState componentSystem)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				_ComponentDataFromEntity_CGroupPhaseQueue_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CGroupPhaseQueue>(true);
				_ComponentDataFromEntity_CGroupAtWaitingTable_1 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CGroupAtWaitingTable>(true);
				_ComponentDataFromEntity_CGroupPhaseFood_2 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CGroupPhaseFood>(true);
				_ComponentDataFromEntity_CGroupPhaseOrder_3 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CGroupPhaseOrder>(true);
				_ComponentDataFromEntity_CGroupStartLeaving_4 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CGroupStartLeaving>(true);
				_ComponentDataFromEntity_CCustomerState_5 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CCustomerState>(false);
			}

			[BurstCompile]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				RunWithoutJobSystem_00000A13_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
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
			InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate functionPointer = (JobsUtility.JobCompilerEnabled ? _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldBurst : _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst);
			_003C_003EOnUpdate_LambdaJob0_profilerMarker.Begin();
			try
			{
				InternalCompilerInterface.RunJobChunk(ref jobData, query, functionPointer);
			}
			finally
			{
				_003C_003EOnUpdate_LambdaJob0_profilerMarker.End();
			}
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EOnUpdate_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(this);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldBurst = InternalCompilerInterface.BurstCompile(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst);
			_003C_003EOnUpdate_LambdaJob0_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob0");
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
			{
				ComponentType.ReadOnly<CCustomerGroup>(),
				ComponentType.ReadOnly<CGroupMember>()
			};
			return componentSystem.GetEntityQuery(array);
		}

		public static void Initialize_0024_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0_RunWithoutJobSystem_00000A13_0024BurstDirectCall()
		{
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem_00000A13_0024BurstDirectCall.Initialize();
		}
	}
}
