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
	public class UpdateViewPositions : BurstIncrementalViewSystemBase<UpdateViewPositionData>
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass2_0
		{
			public EntityViewManager view_manager;

			public float time;

			public BurstContext bctx;

			internal void _003CPopulateNewViewUpdates_003Eb__0(Entity entity, ref CPosition position, in CRequiresView require, in CLinkedView linked_view)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}

			internal void _003CPopulateNewViewUpdates_003Eb__1(Entity entity, ref CPosition position, in CRequiresView require, in CLinkedView linked_view)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}

			internal void _003CPopulateNewViewUpdates_003Eb__2(Entity entity, ref CPosition position, in CRequiresView require, in CLinkedView linked_view)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public LambdaParameterValueProvider_Entity.Runtime runtime_entity;

					public LambdaParameterValueProvider_IComponentData<CPosition>.Runtime runtime_position;

					public LambdaParameterValueProvider_IComponentData<CRequiresView>.Runtime runtime_require;

					public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_entity;

				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_position;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CRequiresView> forParameter_require;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

				public void ScheduleTimeInitialize(UpdateViewPositions componentSystem)
				{
					forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_position.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_require.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_position = forParameter_position.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_require = forParameter_require.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public EntityViewManager view_manager;

			public float time;

			public BurstContext bctx;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity entity, ref CPosition position, in CRequiresView require, in CLinkedView linked_view)
			{
				if (require.PhysicsDriven && !position.ForceSnap)
				{
					position = CheckForPhysicsUpdate(linked_view, position, view_manager);
					position = ProposeUpdate(has_refresh: false, linked_view, require, position, time, ref bctx);
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				view_manager = displayClass.view_manager;
				time = displayClass.time;
				bctx = displayClass.bctx;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				displayClass.view_manager = view_manager;
				displayClass.time = time;
				displayClass.bctx = bctx;
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
					OriginalLambdaBody(runtimes.runtime_entity.For(i), ref runtimes.runtime_position.For(i), in runtimes.runtime_require.For(i), in runtimes.runtime_linked_view.For(i));
				}
			}

			public void ScheduleTimeInitialize(UpdateViewPositions componentSystem, ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		[BurstCompile]
		[NoAlias]
		private struct _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				[NoAlias]
				public struct Runtimes
				{
					[NoAlias]
					public LambdaParameterValueProvider_Entity.Runtime runtime_entity;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<CPosition>.Runtime runtime_position;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<CRequiresView>.Runtime runtime_require;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;
				}

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_entity;

				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_position;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<CRequiresView> forParameter_require;

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

				public void ScheduleTimeInitialize(UpdateViewPositions componentSystem)
				{
					forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_position.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_require.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_position = forParameter_position.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_require = forParameter_require.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public unsafe delegate void RunWithoutJobSystem_00000F01_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

			internal static class RunWithoutJobSystem_00000F01_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_00000F01_0024PostfixBurstDelegate).TypeHandle);
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

				static RunWithoutJobSystem_00000F01_0024BurstDirectCall()
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

			public float time;

			public BurstContext bctx;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void OriginalLambdaBody(Entity entity, ref CPosition position, in CRequiresView require, in CLinkedView linked_view)
			{
				if (!require.PhysicsDriven || position.ForceSnap)
				{
					position = ProposeUpdate(has_refresh: false, linked_view, require, position, time, ref bctx);
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				time = displayClass.time;
				bctx = displayClass.bctx;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				displayClass.time = time;
				displayClass.bctx = bctx;
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
					OriginalLambdaBody(runtimes.runtime_entity.For(i), ref runtimes.runtime_position.For(i), in runtimes.runtime_require.For(i), in runtimes.runtime_linked_view.For(i));
				}
			}

			public void ScheduleTimeInitialize(UpdateViewPositions componentSystem, ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			[BurstCompile]
			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				RunWithoutJobSystem_00000F01_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			[BurstCompile]
			public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1>(jobData), ref *archetypeChunkIterator);
			}
		}

		[NoAlias]
		[BurstCompile]
		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob2 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				[NoAlias]
				public struct Runtimes
				{
					[NoAlias]
					public LambdaParameterValueProvider_Entity.Runtime runtime_entity;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<CPosition>.Runtime runtime_position;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<CRequiresView>.Runtime runtime_require;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;
				}

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_Entity forParameter_entity;

				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_position;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<CRequiresView> forParameter_require;

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

				public void ScheduleTimeInitialize(UpdateViewPositions componentSystem)
				{
					forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_position.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_require.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_position = forParameter_position.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_require = forParameter_require.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public unsafe delegate void RunWithoutJobSystem_00000F0A_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

			internal static class RunWithoutJobSystem_00000F0A_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_00000F0A_0024PostfixBurstDelegate).TypeHandle);
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

				static RunWithoutJobSystem_00000F0A_0024BurstDirectCall()
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

			public float time;

			public BurstContext bctx;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void OriginalLambdaBody(Entity entity, ref CPosition position, in CRequiresView require, in CLinkedView linked_view)
			{
				if (!require.PhysicsDriven || position.ForceSnap)
				{
					position = ProposeUpdate(has_refresh: true, linked_view, require, position, time, ref bctx);
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				time = displayClass.time;
				bctx = displayClass.bctx;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				displayClass.time = time;
				displayClass.bctx = bctx;
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
					OriginalLambdaBody(runtimes.runtime_entity.For(i), ref runtimes.runtime_position.For(i), in runtimes.runtime_require.For(i), in runtimes.runtime_linked_view.For(i));
				}
			}

			public void ScheduleTimeInitialize(UpdateViewPositions componentSystem, ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			[BurstCompile]
			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				RunWithoutJobSystem_00000F0A_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			[BurstCompile]
			public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob2>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery _003C_003EPopulateNewViewUpdates_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EPopulateNewViewUpdates_LambdaJob0_profilerMarker;

		private EntityQuery _003C_003EPopulateNewViewUpdates_LambdaJob1_entityQuery;

		private ProfilerMarker _003C_003EPopulateNewViewUpdates_LambdaJob1_profilerMarker;

		private EntityQuery _003C_003EPopulateNewViewUpdates_LambdaJob2_entityQuery;

		private ProfilerMarker _003C_003EPopulateNewViewUpdates_LambdaJob2_profilerMarker;

		protected override MessageType MessageType => MessageType.ViewPositionUpdate;

		protected override void PopulateNewViewUpdates(BurstContext bctx)
		{
			_003C_003Ec__DisplayClass2_0 displayClass = new _003C_003Ec__DisplayClass2_0
			{
				bctx = bctx,
				time = base.Time.TotalTime,
				view_manager = base.EntityViewManager
			};
			_ = base.Entities;
			_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0 jobData = default(_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0);
			jobData.ScheduleTimeInitialize(this, ref displayClass);
			CompleteDependency();
			EntityQuery query = _003C_003EPopulateNewViewUpdates_LambdaJob0_entityQuery;
			InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst;
			_003C_003EPopulateNewViewUpdates_LambdaJob0_profilerMarker.Begin();
			try
			{
				InternalCompilerInterface.RunJobChunk(ref jobData, query, s_RunWithoutJobSystemDelegateFieldNoBurst);
			}
			finally
			{
				_003C_003EPopulateNewViewUpdates_LambdaJob0_profilerMarker.End();
			}
			jobData.WriteToDisplayClass(ref displayClass);
			_ = base.Entities;
			_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1 jobData2 = default(_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1);
			jobData2.ScheduleTimeInitialize(this, ref displayClass);
			CompleteDependency();
			EntityQuery query2 = _003C_003EPopulateNewViewUpdates_LambdaJob1_entityQuery;
			InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate functionPointer = (JobsUtility.JobCompilerEnabled ? _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1.s_RunWithoutJobSystemDelegateFieldBurst : _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1.s_RunWithoutJobSystemDelegateFieldNoBurst);
			_003C_003EPopulateNewViewUpdates_LambdaJob1_profilerMarker.Begin();
			try
			{
				InternalCompilerInterface.RunJobChunk(ref jobData2, query2, functionPointer);
			}
			finally
			{
				_003C_003EPopulateNewViewUpdates_LambdaJob1_profilerMarker.End();
			}
			jobData2.WriteToDisplayClass(ref displayClass);
			_ = base.Entities;
			_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob2 jobData3 = default(_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob2);
			jobData3.ScheduleTimeInitialize(this, ref displayClass);
			CompleteDependency();
			EntityQuery query3 = _003C_003EPopulateNewViewUpdates_LambdaJob2_entityQuery;
			InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate functionPointer2 = (JobsUtility.JobCompilerEnabled ? _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob2.s_RunWithoutJobSystemDelegateFieldBurst : _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob2.s_RunWithoutJobSystemDelegateFieldNoBurst);
			_003C_003EPopulateNewViewUpdates_LambdaJob2_profilerMarker.Begin();
			try
			{
				InternalCompilerInterface.RunJobChunk(ref jobData3, query3, functionPointer2);
			}
			finally
			{
				_003C_003EPopulateNewViewUpdates_LambdaJob2_profilerMarker.End();
			}
			jobData3.WriteToDisplayClass(ref displayClass);
		}

		private static CPosition CheckForPhysicsUpdate(CLinkedView linked_view, CPosition position_base, EntityViewManager view_manager)
		{
			if (view_manager.EntityViews.TryGetValue(linked_view, out var value) && value != null)
			{
				return value.GetPosition();
			}
			return position_base;
		}

		private static CPosition ProposeUpdate(bool has_refresh, CLinkedView linked_view, CRequiresView require, CPosition position, float time, ref BurstContext bctx)
		{
			CPosition cPosition = position;
			UpdateViewPositionData view_data = new UpdateViewPositionData
			{
				Rotation = position.Rotation,
				Position = cPosition,
				Force = (position.ForceSnap || has_refresh),
				Mode = require.ViewMode,
				GameTime = time
			};
			bctx.ProposeUpdate(linked_view, view_data);
			position.ForceSnap = false;
			return position;
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EPopulateNewViewUpdates_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForPopulateNewViewUpdates_LambdaJob0_From(this);
			_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.RunWithoutJobSystem;
			_003C_003EPopulateNewViewUpdates_LambdaJob0_profilerMarker = new ProfilerMarker("PopulateNewViewUpdates_LambdaJob0");
			_003C_003EPopulateNewViewUpdates_LambdaJob1_entityQuery = _003C_003EGetEntityQuery_ForPopulateNewViewUpdates_LambdaJob1_From(this);
			_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1.RunWithoutJobSystem;
			_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1.s_RunWithoutJobSystemDelegateFieldBurst = InternalCompilerInterface.BurstCompile(_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1.s_RunWithoutJobSystemDelegateFieldNoBurst);
			_003C_003EPopulateNewViewUpdates_LambdaJob1_profilerMarker = new ProfilerMarker("PopulateNewViewUpdates_LambdaJob1");
			_003C_003EPopulateNewViewUpdates_LambdaJob2_entityQuery = _003C_003EGetEntityQuery_ForPopulateNewViewUpdates_LambdaJob2_From(this);
			_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob2.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob2.RunWithoutJobSystem;
			_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob2.s_RunWithoutJobSystemDelegateFieldBurst = InternalCompilerInterface.BurstCompile(_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob2.s_RunWithoutJobSystemDelegateFieldNoBurst);
			_003C_003EPopulateNewViewUpdates_LambdaJob2_profilerMarker = new ProfilerMarker("PopulateNewViewUpdates_LambdaJob2");
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForPopulateNewViewUpdates_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[3]
			{
				ComponentType.ReadOnly<CLinkedView>(),
				ComponentType.ReadWrite<CPosition>(),
				ComponentType.ReadOnly<CRequiresView>()
			};
			return componentSystem.GetEntityQuery(array);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForPopulateNewViewUpdates_LambdaJob1_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
			entityQueryDesc.All = new ComponentType[3]
			{
				ComponentType.ReadOnly<CLinkedView>(),
				ComponentType.ReadWrite<CPosition>(),
				ComponentType.ReadOnly<CRequiresView>()
			};
			entityQueryDesc.None = new ComponentType[1] { ComponentType.ReadWrite<CRefreshView>() };
			return componentSystem.GetEntityQuery(array);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForPopulateNewViewUpdates_LambdaJob2_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[4]
			{
				ComponentType.ReadOnly<CLinkedView>(),
				ComponentType.ReadOnly<CRefreshView>(),
				ComponentType.ReadWrite<CPosition>(),
				ComponentType.ReadOnly<CRequiresView>()
			};
			return componentSystem.GetEntityQuery(array);
		}

		public static void Initialize_0024_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1_RunWithoutJobSystem_00000F01_0024BurstDirectCall()
		{
			_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1.RunWithoutJobSystem_00000F01_0024BurstDirectCall.Initialize();
		}

		public static void Initialize_0024_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob2_RunWithoutJobSystem_00000F0A_0024BurstDirectCall()
		{
			_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob2.RunWithoutJobSystem_00000F0A_0024BurstDirectCall.Initialize();
		}
	}
}
