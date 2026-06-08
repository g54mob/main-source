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
	public class UpdateApplianceView : BurstIncrementalViewSystemBase<ApplianceView.ViewData>
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass0_0
		{
			public EntityContext ctx;

			public BurstContext bctx;

			internal void _003CPopulateNewViewUpdates_003Eb__0(Entity entity, int entityInQueryIndex, in CLinkedView linked_view, in CAppliance appliance)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}

			internal void _003CPopulateNewViewUpdates_003Eb__1(Entity entity, int entityInQueryIndex, in CLinkedView linked_view, in CAppliance appliance)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}

			internal void _003CPopulateNewViewUpdates_003Eb__2(Entity entity, int entityInQueryIndex, in CLinkedView linked_view, in CAppliance appliance)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		[BurstCompile]
		[NoAlias]
		private struct _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				[NoAlias]
				public struct Runtimes
				{
					[NoAlias]
					public LambdaParameterValueProvider_Entity.Runtime runtime_entity;

					[NoAlias]
					public LambdaParameterValueProvider_EntityInQueryIndex.Runtime runtime_entityInQueryIndex;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<CAppliance>.Runtime runtime_appliance;
				}

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_Entity forParameter_entity;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<CAppliance> forParameter_appliance;

				public void ScheduleTimeInitialize(UpdateApplianceView componentSystem)
				{
					forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_appliance.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
						runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_appliance = forParameter_appliance.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public unsafe delegate void RunWithoutJobSystem_000000D9_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

			internal static class RunWithoutJobSystem_000000D9_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_000000D9_0024PostfixBurstDelegate).TypeHandle);
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

				static RunWithoutJobSystem_000000D9_0024BurstDirectCall()
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

			public EntityContext ctx;

			public BurstContext bctx;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void OriginalLambdaBody(Entity entity, int entityInQueryIndex, in CLinkedView linked_view, in CAppliance appliance)
			{
				bool flag = false;
				if (ctx.Require<CBeingLookedAt>(entity, out var comp))
				{
					Entity interactor = comp.Interactor;
					if (ctx.Has<CPlayer>(interactor) && ctx.Require<CAttemptingInteraction>(interactor, out var comp2))
					{
						flag = comp2.Result != InteractionResult.None;
					}
				}
				if (ctx.RequireBuffer(entity, out DynamicBuffer<CBeingActedOnBy> comp3) && !comp3.IsEmpty)
				{
					foreach (CBeingActedOnBy item in comp3)
					{
						if (ctx.Has<CPlayer>(item.Interactor) && ctx.Require<CAttemptingInteraction>(item.Interactor, out var comp4))
						{
							flag |= comp4.Result != InteractionResult.None;
							break;
						}
					}
				}
				int drawUsing = 0;
				if (ctx.Require<CDrawApplianceUsing>(entity, out var comp5))
				{
					drawUsing = comp5.DrawApplianceID;
				}
				CDestroyApplianceAtDay comp6;
				ApplianceView.ViewData view_data = new ApplianceView.ViewData
				{
					ApplianceID = appliance.ID,
					Broken = ctx.Has<CPreventUse>(entity),
					InteractTarget = flag,
					DrawUsing = drawUsing,
					MarkedForDeletion = (ctx.Require<CDestroyApplianceAtDay>(entity, out comp6) && !comp6.HideBin),
					IsOnFire = ctx.Has<CIsOnFire>(entity)
				};
				bctx.ProposeUpdate(linked_view.Identifier, view_data);
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				ctx = displayClass.ctx;
				bctx = displayClass.bctx;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				displayClass.ctx = ctx;
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
					OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), in runtimes.runtime_linked_view.For(i), in runtimes.runtime_appliance.For(i));
				}
			}

			public void ScheduleTimeInitialize(UpdateApplianceView componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			[BurstCompile]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				RunWithoutJobSystem_000000D9_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
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
					public LambdaParameterValueProvider_EntityInQueryIndex.Runtime runtime_entityInQueryIndex;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<CAppliance>.Runtime runtime_appliance;
				}

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_Entity forParameter_entity;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<CAppliance> forParameter_appliance;

				public void ScheduleTimeInitialize(UpdateApplianceView componentSystem)
				{
					forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_appliance.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
						runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_appliance = forParameter_appliance.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public unsafe delegate void RunWithoutJobSystem_000000E2_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

			internal static class RunWithoutJobSystem_000000E2_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_000000E2_0024PostfixBurstDelegate).TypeHandle);
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

				static RunWithoutJobSystem_000000E2_0024BurstDirectCall()
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

			public EntityContext ctx;

			public BurstContext bctx;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void OriginalLambdaBody(Entity entity, int entityInQueryIndex, in CLinkedView linked_view, in CAppliance appliance)
			{
				int drawUsing = 0;
				if (ctx.Require<CDrawApplianceUsing>(entity, out var comp))
				{
					drawUsing = comp.DrawApplianceID;
				}
				CDestroyApplianceAtDay comp2;
				ApplianceView.ViewData view_data = new ApplianceView.ViewData
				{
					ApplianceID = appliance.ID,
					Broken = ctx.Has<CPreventUse>(entity),
					InteractTarget = false,
					DrawUsing = drawUsing,
					MarkedForDeletion = (ctx.Require<CDestroyApplianceAtDay>(entity, out comp2) && !comp2.HideBin),
					IsOnFire = ctx.Has<CIsOnFire>(entity)
				};
				bctx.ProposeUpdate(linked_view.Identifier, view_data);
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				ctx = displayClass.ctx;
				bctx = displayClass.bctx;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				displayClass.ctx = ctx;
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
					OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), in runtimes.runtime_linked_view.For(i), in runtimes.runtime_appliance.For(i));
				}
			}

			public void ScheduleTimeInitialize(UpdateApplianceView componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			[BurstCompile]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				RunWithoutJobSystem_000000E2_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1>(jobData), ref *archetypeChunkIterator);
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		[BurstCompile]
		[NoAlias]
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
					public LambdaParameterValueProvider_EntityInQueryIndex.Runtime runtime_entityInQueryIndex;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<CAppliance>.Runtime runtime_appliance;
				}

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_Entity forParameter_entity;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<CAppliance> forParameter_appliance;

				public void ScheduleTimeInitialize(UpdateApplianceView componentSystem)
				{
					forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_appliance.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
						runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_appliance = forParameter_appliance.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public unsafe delegate void RunWithoutJobSystem_000000EB_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

			internal static class RunWithoutJobSystem_000000EB_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_000000EB_0024PostfixBurstDelegate).TypeHandle);
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

				static RunWithoutJobSystem_000000EB_0024BurstDirectCall()
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

			public BurstContext bctx;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void OriginalLambdaBody(Entity entity, int entityInQueryIndex, in CLinkedView linked_view, in CAppliance appliance)
			{
				ApplianceView.ViewData view_data = new ApplianceView.ViewData
				{
					ApplianceID = appliance.ID,
					Broken = false,
					InteractTarget = false,
					DrawUsing = 0,
					MarkedForDeletion = false,
					IsOnFire = false
				};
				bctx.ProposeUpdate(linked_view.Identifier, view_data);
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				bctx = displayClass.bctx;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
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
					OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), in runtimes.runtime_linked_view.For(i), in runtimes.runtime_appliance.For(i));
				}
			}

			public void ScheduleTimeInitialize(UpdateApplianceView componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			[BurstCompile]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				RunWithoutJobSystem_000000EB_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
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

		protected override void PopulateNewViewUpdates(BurstContext bctx)
		{
			_003C_003Ec__DisplayClass0_0 displayClass = new _003C_003Ec__DisplayClass0_0
			{
				bctx = bctx,
				ctx = new EntityContext(base.EntityManager)
			};
			_ = base.Entities;
			_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0 jobData = default(_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0);
			jobData.ScheduleTimeInitialize(this, ref displayClass);
			CompleteDependency();
			EntityQuery query = _003C_003EPopulateNewViewUpdates_LambdaJob0_entityQuery;
			InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate functionPointer = (JobsUtility.JobCompilerEnabled ? _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldBurst : _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst);
			_003C_003EPopulateNewViewUpdates_LambdaJob0_profilerMarker.Begin();
			try
			{
				InternalCompilerInterface.RunJobChunk(ref jobData, query, functionPointer);
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
			InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate functionPointer2 = (JobsUtility.JobCompilerEnabled ? _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1.s_RunWithoutJobSystemDelegateFieldBurst : _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1.s_RunWithoutJobSystemDelegateFieldNoBurst);
			_003C_003EPopulateNewViewUpdates_LambdaJob1_profilerMarker.Begin();
			try
			{
				InternalCompilerInterface.RunJobChunk(ref jobData2, query2, functionPointer2);
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
			InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate functionPointer3 = (JobsUtility.JobCompilerEnabled ? _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob2.s_RunWithoutJobSystemDelegateFieldBurst : _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob2.s_RunWithoutJobSystemDelegateFieldNoBurst);
			_003C_003EPopulateNewViewUpdates_LambdaJob2_profilerMarker.Begin();
			try
			{
				InternalCompilerInterface.RunJobChunk(ref jobData3, query3, functionPointer3);
			}
			finally
			{
				_003C_003EPopulateNewViewUpdates_LambdaJob2_profilerMarker.End();
			}
			jobData3.WriteToDisplayClass(ref displayClass);
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EPopulateNewViewUpdates_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForPopulateNewViewUpdates_LambdaJob0_From(this);
			_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.RunWithoutJobSystem;
			_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldBurst = InternalCompilerInterface.BurstCompile(_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst);
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
			EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
			entityQueryDesc.All = new ComponentType[2]
			{
				ComponentType.ReadOnly<CLinkedView>(),
				ComponentType.ReadOnly<CAppliance>()
			};
			entityQueryDesc.None = new ComponentType[1] { ComponentType.ReadWrite<CHeldAppliance>() };
			entityQueryDesc.Any = new ComponentType[2]
			{
				ComponentType.ReadWrite<CBeingLookedAt>(),
				ComponentType.ReadWrite<CBeingActedOn>()
			};
			return componentSystem.GetEntityQuery(array);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForPopulateNewViewUpdates_LambdaJob1_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
			entityQueryDesc.All = new ComponentType[2]
			{
				ComponentType.ReadOnly<CLinkedView>(),
				ComponentType.ReadOnly<CAppliance>()
			};
			entityQueryDesc.None = new ComponentType[3]
			{
				ComponentType.ReadWrite<CBeingLookedAt>(),
				ComponentType.ReadWrite<CBeingActedOn>(),
				ComponentType.ReadWrite<CHeldAppliance>()
			};
			entityQueryDesc.Any = new ComponentType[4]
			{
				ComponentType.ReadWrite<CDrawApplianceUsing>(),
				ComponentType.ReadWrite<CDestroyApplianceAtDay>(),
				ComponentType.ReadWrite<CPreventUse>(),
				ComponentType.ReadWrite<CIsOnFire>()
			};
			return componentSystem.GetEntityQuery(array);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForPopulateNewViewUpdates_LambdaJob2_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
			entityQueryDesc.All = new ComponentType[2]
			{
				ComponentType.ReadOnly<CLinkedView>(),
				ComponentType.ReadOnly<CAppliance>()
			};
			entityQueryDesc.None = new ComponentType[7]
			{
				ComponentType.ReadWrite<CDrawApplianceUsing>(),
				ComponentType.ReadWrite<CDestroyApplianceAtDay>(),
				ComponentType.ReadWrite<CPreventUse>(),
				ComponentType.ReadWrite<CIsOnFire>(),
				ComponentType.ReadWrite<CBeingLookedAt>(),
				ComponentType.ReadWrite<CBeingActedOn>(),
				ComponentType.ReadWrite<CHeldAppliance>()
			};
			return componentSystem.GetEntityQuery(array);
		}

		public static void Initialize_0024_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0_RunWithoutJobSystem_000000D9_0024BurstDirectCall()
		{
			_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.RunWithoutJobSystem_000000D9_0024BurstDirectCall.Initialize();
		}

		public static void Initialize_0024_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1_RunWithoutJobSystem_000000E2_0024BurstDirectCall()
		{
			_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1.RunWithoutJobSystem_000000E2_0024BurstDirectCall.Initialize();
		}

		public static void Initialize_0024_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob2_RunWithoutJobSystem_000000EB_0024BurstDirectCall()
		{
			_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob2.RunWithoutJobSystem_000000EB_0024BurstDirectCall.Initialize();
		}
	}
}
