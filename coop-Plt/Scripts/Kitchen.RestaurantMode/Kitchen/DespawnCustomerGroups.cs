#define ENABLE_PROFILER
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	[UpdateInGroup(typeof(DestructionGroup))]
	public class DespawnCustomerGroups : RestaurantSystem
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass0_0
		{
			public DespawnCustomerGroups _003C_003E4__this;

			public Bounds bounds;

			public EntityCommandBuffer ecb;

			internal void _003COnUpdate_003Eb__0(Entity e, in DynamicBuffer<CGroupMember> group, in CGroupLeaving leaving)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		[BurstCompile]
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
					public LambdaParameterValueProvider_DynamicBuffer<CGroupMember>.Runtime runtime_group;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData_Tag<CGroupLeaving>.Runtime runtime_leaving;
				}

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_DynamicBuffer<CGroupMember> forParameter_group;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_IComponentData_Tag<CGroupLeaving> forParameter_leaving;

				public void ScheduleTimeInitialize(DespawnCustomerGroups componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_group.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_leaving.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_group = forParameter_group.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_leaving = forParameter_leaving.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public unsafe delegate void RunWithoutJobSystem_00000032_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

			internal static class RunWithoutJobSystem_00000032_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_00000032_0024PostfixBurstDelegate).TypeHandle);
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

				static RunWithoutJobSystem_00000032_0024BurstDirectCall()
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

			public Bounds bounds;

			public EntityCommandBuffer ecb;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CPosition> _ComponentDataFromEntity_CPosition_0;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void OriginalLambdaBody(Entity e, in DynamicBuffer<CGroupMember> group, in CGroupLeaving leaving)
			{
				for (int i = 0; i < group.Length; i++)
				{
					CGroupMember cGroupMember = group[i];
					CPosition cPosition = _ComponentDataFromEntity_CPosition_0[cGroupMember];
					if (bounds.Contains(cPosition))
					{
						return;
					}
				}
				ecb.DestroyEntity(e);
				for (int j = 0; j < group.Length; j++)
				{
					CGroupMember cGroupMember2 = group[j];
					ecb.DestroyEntity(cGroupMember2);
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				bounds = displayClass.bounds;
				ecb = displayClass.ecb;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				displayClass.bounds = bounds;
				displayClass.ecb = ecb;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), runtimes.runtime_group.For(i), runtimes.runtime_leaving.For(i));
				}
			}

			public void ScheduleTimeInitialize(DespawnCustomerGroups componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CPosition_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CPosition>(true);
			}

			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			[BurstCompile]
			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				RunWithoutJobSystem_00000032_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			[BurstCompile]
			public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
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
				ecb = GetCommandBuffer(ECB.DestructionGroup),
				bounds = new Bounds(Vector3.zero, new Vector3(20f, 10f, 20f))
			};
			_ = base.Entities;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 jobData = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0);
			jobData.ScheduleTimeInitialize(this, ref displayClass);
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
			jobData.WriteToDisplayClass(ref displayClass);
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
				ComponentType.ReadOnly<CGroupMember>(),
				ComponentType.ReadOnly<CGroupLeaving>()
			};
			return componentSystem.GetEntityQuery(array);
		}

		public static void Initialize_0024_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0_RunWithoutJobSystem_00000032_0024BurstDirectCall()
		{
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem_00000032_0024BurstDirectCall.Initialize();
		}
	}
}
