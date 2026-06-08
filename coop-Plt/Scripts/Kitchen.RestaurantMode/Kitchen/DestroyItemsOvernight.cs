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
	[UpdateInGroup(typeof(DestructionGroup))]
	public class DestroyItemsOvernight : NightSystem
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass0_0
		{
			public DestroyItemsOvernight _003C_003E4__this;

			public EntityCommandBuffer ecb;

			internal void _003COnUpdate_003Eb__0(Entity e, ref CItemHolder holder)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}

			internal void _003COnUpdate_003Eb__1(Entity e, ref DynamicBuffer<CItemStored> stored)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}

			internal void _003COnUpdate_003Eb__2(Entity e, ref CHeldBy held_by, ref DynamicBuffer<CItemStored> stored_items)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}

			internal void _003COnUpdate_003Eb__3(Entity e, ref CHeldBy held_by)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}
		}

		[NoAlias]
		[Unity.Entities.DOTSCompilerGenerated]
		[BurstCompile]
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
					public LambdaParameterValueProvider_IComponentData<CItemHolder>.Runtime runtime_holder;
				}

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<CItemHolder> forParameter_holder;

				public void ScheduleTimeInitialize(DestroyItemsOvernight componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_holder.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_holder = forParameter_holder.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public unsafe delegate void RunWithoutJobSystem_000000C6_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

			internal static class RunWithoutJobSystem_000000C6_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_000000C6_0024PostfixBurstDelegate).TypeHandle);
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

				static RunWithoutJobSystem_000000C6_0024BurstDirectCall()
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

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CAppliance> _ComponentDataFromEntity_CAppliance_0;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CCreateAppliance> _ComponentDataFromEntity_CCreateAppliance_1;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CPreservedOvernight> _ComponentDataFromEntity_CPreservedOvernight_2;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void OriginalLambdaBody(Entity e, ref CItemHolder holder)
			{
				if (holder.HeldItem != default(Entity) && !_ComponentDataFromEntity_CAppliance_0.HasComponent(holder.HeldItem) && !_ComponentDataFromEntity_CCreateAppliance_1.HasComponent(holder.HeldItem) && !_ComponentDataFromEntity_CPreservedOvernight_2.HasComponent(holder.HeldItem))
				{
					ecb.DestroyEntity(holder.HeldItem);
					holder.HeldItem = default(Entity);
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

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void IterateEntities(ref ArchetypeChunk chunk, [NoAlias] ref LambdaParameterValueProviders.Runtimes runtimes)
			{
				int count = chunk.Count;
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_holder.For(i));
				}
			}

			public void ScheduleTimeInitialize(DestroyItemsOvernight componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CAppliance_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CAppliance>(true);
				_ComponentDataFromEntity_CCreateAppliance_1 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CCreateAppliance>(true);
				_ComponentDataFromEntity_CPreservedOvernight_2 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CPreservedOvernight>(true);
			}

			[BurstCompile]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				RunWithoutJobSystem_000000C6_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		[BurstCompile]
		[NoAlias]
		[Unity.Entities.DOTSCompilerGenerated]
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
					public LambdaParameterValueProvider_DynamicBuffer<CItemStored>.Runtime runtime_stored;
				}

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[NoAlias]
				private LambdaParameterValueProvider_DynamicBuffer<CItemStored> forParameter_stored;

				public void ScheduleTimeInitialize(DestroyItemsOvernight componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_stored.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_stored = forParameter_stored.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public unsafe delegate void RunWithoutJobSystem_000000CF_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

			internal static class RunWithoutJobSystem_000000CF_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_000000CF_0024PostfixBurstDelegate).TypeHandle);
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

				static RunWithoutJobSystem_000000CF_0024BurstDirectCall()
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

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CAppliance> _ComponentDataFromEntity_CAppliance_0;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CCreateAppliance> _ComponentDataFromEntity_CCreateAppliance_1;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CPreservedOvernight> _ComponentDataFromEntity_CPreservedOvernight_2;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void OriginalLambdaBody(Entity e, ref DynamicBuffer<CItemStored> stored)
			{
				for (int i = 0; i < stored.Length; i++)
				{
					Entity storedItem = stored[i].StoredItem;
					if (storedItem != default(Entity) && !_ComponentDataFromEntity_CAppliance_0.HasComponent(storedItem) && !_ComponentDataFromEntity_CCreateAppliance_1.HasComponent(storedItem) && !_ComponentDataFromEntity_CPreservedOvernight_2.HasComponent(storedItem))
					{
						ecb.DestroyEntity(storedItem);
						stored[i] = default(CItemStored);
					}
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

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void IterateEntities(ref ArchetypeChunk chunk, [NoAlias] ref LambdaParameterValueProviders.Runtimes runtimes)
			{
				int count = chunk.Count;
				for (int i = 0; i < count; i++)
				{
					Entity e = runtimes.runtime_e.For(i);
					DynamicBuffer<CItemStored> stored = runtimes.runtime_stored.For(i);
					OriginalLambdaBody(e, ref stored);
				}
			}

			public void ScheduleTimeInitialize(DestroyItemsOvernight componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CAppliance_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CAppliance>(true);
				_ComponentDataFromEntity_CCreateAppliance_1 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CCreateAppliance>(true);
				_ComponentDataFromEntity_CPreservedOvernight_2 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CPreservedOvernight>(true);
			}

			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			[BurstCompile]
			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				RunWithoutJobSystem_000000CF_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
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
					public LambdaParameterValueProvider_IComponentData<CHeldBy>.Runtime runtime_held_by;

					[NoAlias]
					public LambdaParameterValueProvider_DynamicBuffer<CItemStored>.Runtime runtime_stored_items;
				}

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<CHeldBy> forParameter_held_by;

				[NoAlias]
				private LambdaParameterValueProvider_DynamicBuffer<CItemStored> forParameter_stored_items;

				public void ScheduleTimeInitialize(DestroyItemsOvernight componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_held_by.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_stored_items.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_held_by = forParameter_held_by.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_stored_items = forParameter_stored_items.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public unsafe delegate void RunWithoutJobSystem_000000D8_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

			internal static class RunWithoutJobSystem_000000D8_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_000000D8_0024PostfixBurstDelegate).TypeHandle);
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

				static RunWithoutJobSystem_000000D8_0024BurstDirectCall()
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

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CPlayer> _ComponentDataFromEntity_CPlayer_0;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void OriginalLambdaBody(Entity e, ref CHeldBy held_by, ref DynamicBuffer<CItemStored> stored_items)
			{
				if (_ComponentDataFromEntity_CPlayer_0.HasComponent(held_by.Holder))
				{
					for (int i = 0; i < stored_items.Length; i++)
					{
						ecb.DestroyEntity(stored_items[i].StoredItem);
					}
					stored_items.ResizeUninitialized(0);
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

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void IterateEntities(ref ArchetypeChunk chunk, [NoAlias] ref LambdaParameterValueProviders.Runtimes runtimes)
			{
				int count = chunk.Count;
				for (int i = 0; i < count; i++)
				{
					Entity e = runtimes.runtime_e.For(i);
					ref CHeldBy held_by = ref runtimes.runtime_held_by.For(i);
					DynamicBuffer<CItemStored> stored_items = runtimes.runtime_stored_items.For(i);
					OriginalLambdaBody(e, ref held_by, ref stored_items);
				}
			}

			public void ScheduleTimeInitialize(DestroyItemsOvernight componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CPlayer_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CPlayer>(true);
			}

			[BurstCompile]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				RunWithoutJobSystem_000000D8_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob2>(jobData), ref *archetypeChunkIterator);
			}
		}

		[NoAlias]
		[Unity.Entities.DOTSCompilerGenerated]
		[BurstCompile]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob3 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				[NoAlias]
				public struct Runtimes
				{
					[NoAlias]
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<CHeldBy>.Runtime runtime_held_by;
				}

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<CHeldBy> forParameter_held_by;

				public void ScheduleTimeInitialize(DestroyItemsOvernight componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_held_by.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_held_by = forParameter_held_by.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public unsafe delegate void RunWithoutJobSystem_000000E1_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

			internal static class RunWithoutJobSystem_000000E1_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_000000E1_0024PostfixBurstDelegate).TypeHandle);
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

				static RunWithoutJobSystem_000000E1_0024BurstDirectCall()
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

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CPlayer> _ComponentDataFromEntity_CPlayer_0;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void OriginalLambdaBody(Entity e, ref CHeldBy held_by)
			{
				if (_ComponentDataFromEntity_CPlayer_0.HasComponent(held_by.Holder))
				{
					held_by.Holder = default(Entity);
					ecb.DestroyEntity(e);
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

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void IterateEntities(ref ArchetypeChunk chunk, [NoAlias] ref LambdaParameterValueProviders.Runtimes runtimes)
			{
				int count = chunk.Count;
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_held_by.For(i));
				}
			}

			public void ScheduleTimeInitialize(DestroyItemsOvernight componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CPlayer_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CPlayer>(true);
			}

			[BurstCompile]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				RunWithoutJobSystem_000000E1_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob3>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		private EntityQuery _003C_003EOnUpdate_LambdaJob1_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob1_profilerMarker;

		private EntityQuery _003C_003EOnUpdate_LambdaJob2_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob2_profilerMarker;

		private EntityQuery _003C_003EOnUpdate_LambdaJob3_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob3_profilerMarker;

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass0_0 displayClass = new _003C_003Ec__DisplayClass0_0
			{
				_003C_003E4__this = this,
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
			_ = base.Entities;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1 jobData2 = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1);
			jobData2.ScheduleTimeInitialize(this, ref displayClass);
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
			jobData2.WriteToDisplayClass(ref displayClass);
			_ = base.Entities;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob2 jobData3 = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob2);
			jobData3.ScheduleTimeInitialize(this, ref displayClass);
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
			jobData3.WriteToDisplayClass(ref displayClass);
			_ = base.Entities;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob3 jobData4 = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob3);
			jobData4.ScheduleTimeInitialize(this, ref displayClass);
			CompleteDependency();
			EntityQuery query4 = _003C_003EOnUpdate_LambdaJob3_entityQuery;
			InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate functionPointer4 = (JobsUtility.JobCompilerEnabled ? _003C_003Ec__DisplayClass_OnUpdate_LambdaJob3.s_RunWithoutJobSystemDelegateFieldBurst : _003C_003Ec__DisplayClass_OnUpdate_LambdaJob3.s_RunWithoutJobSystemDelegateFieldNoBurst);
			_003C_003EOnUpdate_LambdaJob3_profilerMarker.Begin();
			try
			{
				InternalCompilerInterface.RunJobChunk(ref jobData4, query4, functionPointer4);
			}
			finally
			{
				_003C_003EOnUpdate_LambdaJob3_profilerMarker.End();
			}
			jobData4.WriteToDisplayClass(ref displayClass);
			displayClass.ecb.Playback(base.EntityManager);
			displayClass.ecb.Dispose();
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
			_003C_003EOnUpdate_LambdaJob3_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob3_From(this);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob3.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob3.RunWithoutJobSystem;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob3.s_RunWithoutJobSystemDelegateFieldBurst = InternalCompilerInterface.BurstCompile(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob3.s_RunWithoutJobSystemDelegateFieldNoBurst);
			_003C_003EOnUpdate_LambdaJob3_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob3");
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
			entityQueryDesc.All = new ComponentType[1] { ComponentType.ReadWrite<CItemHolder>() };
			entityQueryDesc.None = new ComponentType[1] { ComponentType.ReadWrite<CPreservesContentsOvernight>() };
			return componentSystem.GetEntityQuery(array);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob1_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
			entityQueryDesc.All = new ComponentType[1] { ComponentType.ReadWrite<CItemStored>() };
			entityQueryDesc.None = new ComponentType[2]
			{
				ComponentType.ReadWrite<CPreservesContentsOvernight>(),
				ComponentType.ReadWrite<CPreservedOvernight>()
			};
			return componentSystem.GetEntityQuery(array);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob2_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[4]
			{
				ComponentType.ReadOnly<CPreservedOvernight>(),
				ComponentType.ReadOnly<CItemStorage>(),
				ComponentType.ReadWrite<CHeldBy>(),
				ComponentType.ReadWrite<CItemStored>()
			};
			return componentSystem.GetEntityQuery(array);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob3_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
			{
				ComponentType.ReadOnly<CPreservedOvernight>(),
				ComponentType.ReadWrite<CHeldBy>()
			};
			return componentSystem.GetEntityQuery(array);
		}

		public static void Initialize_0024_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0_RunWithoutJobSystem_000000C6_0024BurstDirectCall()
		{
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem_000000C6_0024BurstDirectCall.Initialize();
		}

		public static void Initialize_0024_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1_RunWithoutJobSystem_000000CF_0024BurstDirectCall()
		{
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.RunWithoutJobSystem_000000CF_0024BurstDirectCall.Initialize();
		}

		public static void Initialize_0024_003C_003Ec__DisplayClass_OnUpdate_LambdaJob2_RunWithoutJobSystem_000000D8_0024BurstDirectCall()
		{
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob2.RunWithoutJobSystem_000000D8_0024BurstDirectCall.Initialize();
		}

		public static void Initialize_0024_003C_003Ec__DisplayClass_OnUpdate_LambdaJob3_RunWithoutJobSystem_000000E1_0024BurstDirectCall()
		{
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob3.RunWithoutJobSystem_000000E1_0024BurstDirectCall.Initialize();
		}
	}
}
