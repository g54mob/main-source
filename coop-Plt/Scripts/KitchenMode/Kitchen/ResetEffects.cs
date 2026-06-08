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

namespace Kitchen
{
	[UpdateInGroup(typeof(EffectsGroup), OrderFirst = true)]
	public class ResetEffects : GameEffectSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass0_0
		{
			public EntityCommandBuffer ecb;

			internal void _003COnUpdate_003Eb__0(Entity e, in CAppliance appliance)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}
		}

		[BurstCompile]
		[NoAlias]
		[Unity.Entities.DOTSCompilerGenerated]
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
					public LambdaParameterValueProvider_IComponentData<CAppliance>.Runtime runtime_appliance;
				}

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CAppliance> forParameter_appliance;

				public void ScheduleTimeInitialize(ResetEffects componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_appliance.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_appliance = forParameter_appliance.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public unsafe delegate void RunWithoutJobSystem_000003AB_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

			internal static class RunWithoutJobSystem_000003AB_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_000003AB_0024PostfixBurstDelegate).TypeHandle);
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

				static RunWithoutJobSystem_000003AB_0024BurstDirectCall()
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

			public EntityCommandBuffer ecb;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void OriginalLambdaBody(Entity e, in CAppliance appliance)
			{
				ecb.AddComponent<CAffectedBy.Marker>(e);
				ecb.AddBuffer<CAffectedBy>(e);
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

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void IterateEntities(ref ArchetypeChunk chunk, [NoAlias] ref LambdaParameterValueProviders.Runtimes runtimes)
			{
				int count = chunk.Count;
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(runtimes.runtime_e.For(i), in runtimes.runtime_appliance.For(i));
				}
			}

			public void ScheduleTimeInitialize(ResetEffects componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			[BurstCompile]
			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				RunWithoutJobSystem_000003AB_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			[BurstCompile]
			public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		[BurstCompile]
		[NoAlias]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob1 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				[NoAlias]
				public struct Runtimes
				{
					[NoAlias]
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<CAppliesEffect>.Runtime runtime_effect;
				}

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<CAppliesEffect> forParameter_effect;

				public void ScheduleTimeInitialize(ResetEffects componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_effect.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_effect = forParameter_effect.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public unsafe delegate void RunWithoutJobSystem_000003B2_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

			internal static class RunWithoutJobSystem_000003B2_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_000003B2_0024PostfixBurstDelegate).TypeHandle);
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

				static RunWithoutJobSystem_000003B2_0024BurstDirectCall()
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

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void OriginalLambdaBody(Entity e, ref CAppliesEffect effect)
			{
				effect.IsActive = false;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_effect.For(i));
				}
			}

			public void ScheduleTimeInitialize(ResetEffects componentSystem)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
			}

			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			[BurstCompile]
			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				RunWithoutJobSystem_000003B2_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			[BurstCompile]
			public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1>(jobData), ref *archetypeChunkIterator);
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		[BurstCompile]
		[NoAlias]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob2 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				[NoAlias]
				public struct Runtimes
				{
					[NoAlias]
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					[NoAlias]
					public LambdaParameterValueProvider_DynamicBuffer<CAffectedBy>.Runtime runtime_effected_by;
				}

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[NoAlias]
				private LambdaParameterValueProvider_DynamicBuffer<CAffectedBy> forParameter_effected_by;

				public void ScheduleTimeInitialize(ResetEffects componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_effected_by.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_effected_by = forParameter_effected_by.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public unsafe delegate void RunWithoutJobSystem_000003B9_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

			internal static class RunWithoutJobSystem_000003B9_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_000003B9_0024PostfixBurstDelegate).TypeHandle);
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

				static RunWithoutJobSystem_000003B9_0024BurstDirectCall()
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

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void OriginalLambdaBody(Entity e, ref DynamicBuffer<CAffectedBy> effected_by)
			{
				effected_by.Clear();
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
					Entity e = runtimes.runtime_e.For(i);
					DynamicBuffer<CAffectedBy> effected_by = runtimes.runtime_effected_by.For(i);
					OriginalLambdaBody(e, ref effected_by);
				}
			}

			public void ScheduleTimeInitialize(ResetEffects componentSystem)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
			}

			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			[BurstCompile]
			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				RunWithoutJobSystem_000003B9_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			[BurstCompile]
			public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob2>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		private EntityQuery _003C_003EOnUpdate_LambdaJob1_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob1_profilerMarker;

		private EntityQuery _003C_003EOnUpdate_LambdaJob2_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob2_profilerMarker;

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass0_0 displayClass = new _003C_003Ec__DisplayClass0_0
			{
				ecb = new EntityCommandBuffer(Allocator.TempJob)
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
			displayClass.ecb.Playback(base.EntityManager);
			displayClass.ecb.Dispose();
			_ = base.Entities;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1 jobData2 = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1);
			jobData2.ScheduleTimeInitialize(this);
			CompleteDependency();
			EntityQuery query2 = _003C_003EOnUpdate_LambdaJob1_entityQuery;
			InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate functionPointer2 = (JobsUtility.JobCompilerEnabled ? _003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.s_RunWithoutJobSystemDelegateFieldBurst : _003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.s_RunWithoutJobSystemDelegateFieldNoBurst);
			_003C_003EOnUpdate_LambdaJob1_profilerMarker.Begin();
			try
			{
				InternalCompilerInterface.RunJobChunk(ref jobData2, query2, functionPointer2);
			}
			finally
			{
				_003C_003EOnUpdate_LambdaJob1_profilerMarker.End();
			}
			_ = base.Entities;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob2 jobData3 = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob2);
			jobData3.ScheduleTimeInitialize(this);
			CompleteDependency();
			EntityQuery query3 = _003C_003EOnUpdate_LambdaJob2_entityQuery;
			InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate functionPointer3 = (JobsUtility.JobCompilerEnabled ? _003C_003Ec__DisplayClass_OnUpdate_LambdaJob2.s_RunWithoutJobSystemDelegateFieldBurst : _003C_003Ec__DisplayClass_OnUpdate_LambdaJob2.s_RunWithoutJobSystemDelegateFieldNoBurst);
			_003C_003EOnUpdate_LambdaJob2_profilerMarker.Begin();
			try
			{
				InternalCompilerInterface.RunJobChunk(ref jobData3, query3, functionPointer3);
			}
			finally
			{
				_003C_003EOnUpdate_LambdaJob2_profilerMarker.End();
			}
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EOnUpdate_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(this);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldBurst = InternalCompilerInterface.BurstCompile(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst);
			_003C_003EOnUpdate_LambdaJob0_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob0");
			_003C_003EOnUpdate_LambdaJob1_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob1_From(this);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.RunWithoutJobSystem;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.s_RunWithoutJobSystemDelegateFieldBurst = InternalCompilerInterface.BurstCompile(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.s_RunWithoutJobSystemDelegateFieldNoBurst);
			_003C_003EOnUpdate_LambdaJob1_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob1");
			_003C_003EOnUpdate_LambdaJob2_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob2_From(this);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob2.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob2.RunWithoutJobSystem;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob2.s_RunWithoutJobSystemDelegateFieldBurst = InternalCompilerInterface.BurstCompile(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob2.s_RunWithoutJobSystemDelegateFieldNoBurst);
			_003C_003EOnUpdate_LambdaJob2_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob2");
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
			entityQueryDesc.All = new ComponentType[1] { ComponentType.ReadOnly<CAppliance>() };
			entityQueryDesc.None = new ComponentType[1] { ComponentType.ReadWrite<CAffectedBy>() };
			return componentSystem.GetEntityQuery(array);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob1_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[1] { ComponentType.ReadWrite<CAppliesEffect>() };
			return componentSystem.GetEntityQuery(array);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob2_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[1] { ComponentType.ReadWrite<CAffectedBy>() };
			return componentSystem.GetEntityQuery(array);
		}

		public static void Initialize_0024_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0_RunWithoutJobSystem_000003AB_0024BurstDirectCall()
		{
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem_000003AB_0024BurstDirectCall.Initialize();
		}

		public static void Initialize_0024_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1_RunWithoutJobSystem_000003B2_0024BurstDirectCall()
		{
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.RunWithoutJobSystem_000003B2_0024BurstDirectCall.Initialize();
		}

		public static void Initialize_0024_003C_003Ec__DisplayClass_OnUpdate_LambdaJob2_RunWithoutJobSystem_000003B9_0024BurstDirectCall()
		{
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob2.RunWithoutJobSystem_000003B9_0024BurstDirectCall.Initialize();
		}
	}
}
