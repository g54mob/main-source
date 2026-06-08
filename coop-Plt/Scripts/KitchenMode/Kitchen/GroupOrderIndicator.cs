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
	public class GroupOrderIndicator : GameSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass0_0
		{
			public EntityCommandBuffer ecb;

			public EntityArchetype default_archetype;

			public GroupOrderIndicator _003C_003E4__this;

			internal void _003COnUpdate_003Eb__0(Entity e, in DynamicBuffer<CWaitingForItem> order, in DynamicBuffer<CGroupMember> members, in CAssignedTable table_set)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}

			internal void _003COnUpdate_003Eb__1(Entity e, in CInterfaceOf interface_of, in DynamicBuffer<CDisplayedItem> displayed_items)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}

			internal void _003COnUpdate_003Eb__2(Entity e, in CHasItemCollectionIndicator indicator)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}

			internal void _003COnUpdate_003Eb__3(Entity e, in DynamicBuffer<CWaitingForItem> order, in DynamicBuffer<CGroupMember> group, in CHasItemCollectionIndicator indicator)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		[NoAlias]
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
					public LambdaParameterValueProvider_DynamicBuffer<CWaitingForItem>.Runtime runtime_order;

					[NoAlias]
					public LambdaParameterValueProvider_DynamicBuffer<CGroupMember>.Runtime runtime_members;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<CAssignedTable>.Runtime runtime_table_set;
				}

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_DynamicBuffer<CWaitingForItem> forParameter_order;

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_DynamicBuffer<CGroupMember> forParameter_members;

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CAssignedTable> forParameter_table_set;

				public void ScheduleTimeInitialize(GroupOrderIndicator componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_order.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_members.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_table_set.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_order = forParameter_order.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_members = forParameter_members.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_table_set = forParameter_table_set.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public unsafe delegate void RunWithoutJobSystem_00000801_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

			internal static class RunWithoutJobSystem_00000801_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_00000801_0024PostfixBurstDelegate).TypeHandle);
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

				static RunWithoutJobSystem_00000801_0024BurstDirectCall()
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

			public EntityArchetype default_archetype;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CCustomerTablePlacement> _ComponentDataFromEntity_CCustomerTablePlacement_0;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CPosition> _ComponentDataFromEntity_CPosition_1;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void OriginalLambdaBody(Entity e, in DynamicBuffer<CWaitingForItem> order, in DynamicBuffer<CGroupMember> members, in CAssignedTable table_set)
			{
				Entity entity = ecb.CreateEntity(default_archetype);
				ecb.AddBuffer<CDisplayedItem>(entity);
				for (int i = 0; i < order.Length; i++)
				{
					CCustomerTablePlacement cCustomerTablePlacement = _ComponentDataFromEntity_CCustomerTablePlacement_0[members[order[i].MemberIndex]];
					ecb.AppendToBuffer(entity, new CDisplayedItem
					{
						IsComplete = order[i].Satisfied,
						Item = order[i].Item,
						ItemID = order[i].ItemID,
						SeatPosition = cCustomerTablePlacement.SeatPosition,
						TablePosition = cCustomerTablePlacement.TablePosition,
						IsSide = order[i].IsSide,
						ShowExtra = (order[i].ExtraRequested && !order[i].ExtraSatisfied),
						ExtraID = order[i].Extra,
						IsSatisfiedBySharer = order[i].SatisfiedBySharer
					});
				}
				ecb.AddComponent(entity, new CInterfaceOf
				{
					Entity = e
				});
				ecb.AddComponent(entity, new CRequiresView
				{
					Type = ViewType.ItemCollectionView
				});
				ecb.AddComponent(entity, _ComponentDataFromEntity_CPosition_1[table_set]);
				ecb.AddComponent(e, new CHasItemCollectionIndicator
				{
					Indicator = entity
				});
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				ecb = displayClass.ecb;
				default_archetype = displayClass.default_archetype;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				displayClass.ecb = ecb;
				displayClass.default_archetype = default_archetype;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), runtimes.runtime_order.For(i), runtimes.runtime_members.For(i), in runtimes.runtime_table_set.For(i));
				}
			}

			public void ScheduleTimeInitialize(GroupOrderIndicator componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CCustomerTablePlacement_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CCustomerTablePlacement>(true);
				_ComponentDataFromEntity_CPosition_1 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CPosition>(true);
			}

			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			[BurstCompile]
			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				RunWithoutJobSystem_00000801_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			[BurstCompile]
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
					public LambdaParameterValueProvider_IComponentData<CInterfaceOf>.Runtime runtime_interface_of;

					[NoAlias]
					public LambdaParameterValueProvider_DynamicBuffer<CDisplayedItem>.Runtime runtime_displayed_items;
				}

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<CInterfaceOf> forParameter_interface_of;

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_DynamicBuffer<CDisplayedItem> forParameter_displayed_items;

				public void ScheduleTimeInitialize(GroupOrderIndicator componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_interface_of.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_displayed_items.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_interface_of = forParameter_interface_of.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_displayed_items = forParameter_displayed_items.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public unsafe delegate void RunWithoutJobSystem_0000080A_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

			internal static class RunWithoutJobSystem_0000080A_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_0000080A_0024PostfixBurstDelegate).TypeHandle);
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

				static RunWithoutJobSystem_0000080A_0024BurstDirectCall()
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
			private ComponentDataFromEntity<CHasItemCollectionIndicator> _ComponentDataFromEntity_CHasItemCollectionIndicator_0;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void OriginalLambdaBody(Entity e, in CInterfaceOf interface_of, in DynamicBuffer<CDisplayedItem> displayed_items)
			{
				if (!_ComponentDataFromEntity_CHasItemCollectionIndicator_0.HasComponent(interface_of))
				{
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), in runtimes.runtime_interface_of.For(i), runtimes.runtime_displayed_items.For(i));
				}
			}

			public void ScheduleTimeInitialize(GroupOrderIndicator componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CHasItemCollectionIndicator_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CHasItemCollectionIndicator>(true);
			}

			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			[BurstCompile]
			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				RunWithoutJobSystem_0000080A_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
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
		[NoAlias]
		[BurstCompile]
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
					public LambdaParameterValueProvider_IComponentData<CHasItemCollectionIndicator>.Runtime runtime_indicator;
				}

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CHasItemCollectionIndicator> forParameter_indicator;

				public void ScheduleTimeInitialize(GroupOrderIndicator componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_indicator.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_indicator = forParameter_indicator.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public unsafe delegate void RunWithoutJobSystem_00000813_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

			internal static class RunWithoutJobSystem_00000813_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_00000813_0024PostfixBurstDelegate).TypeHandle);
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

				static RunWithoutJobSystem_00000813_0024BurstDirectCall()
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

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CGroupAwaitingOrder> _ComponentDataFromEntity_CGroupAwaitingOrder_0;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CGroupAwaitingExtra> _ComponentDataFromEntity_CGroupAwaitingExtra_1;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CGroupEating> _ComponentDataFromEntity_CGroupEating_2;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void OriginalLambdaBody(Entity e, in CHasItemCollectionIndicator indicator)
			{
				if (!_ComponentDataFromEntity_CGroupAwaitingOrder_0.HasComponent(e) && !_ComponentDataFromEntity_CGroupAwaitingExtra_1.HasComponent(e) && !_ComponentDataFromEntity_CGroupEating_2.HasComponent(e))
				{
					ecb.DestroyEntity(indicator);
					ecb.RemoveComponent<CHasItemCollectionIndicator>(e);
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), in runtimes.runtime_indicator.For(i));
				}
			}

			public void ScheduleTimeInitialize(GroupOrderIndicator componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CGroupAwaitingOrder_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CGroupAwaitingOrder>(true);
				_ComponentDataFromEntity_CGroupAwaitingExtra_1 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CGroupAwaitingExtra>(true);
				_ComponentDataFromEntity_CGroupEating_2 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CGroupEating>(true);
			}

			[BurstCompile]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				RunWithoutJobSystem_00000813_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob2>(jobData), ref *archetypeChunkIterator);
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		[BurstCompile]
		[NoAlias]
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
					public LambdaParameterValueProvider_DynamicBuffer<CWaitingForItem>.Runtime runtime_order;

					[NoAlias]
					public LambdaParameterValueProvider_DynamicBuffer<CGroupMember>.Runtime runtime_group;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<CHasItemCollectionIndicator>.Runtime runtime_indicator;
				}

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_DynamicBuffer<CWaitingForItem> forParameter_order;

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_DynamicBuffer<CGroupMember> forParameter_group;

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CHasItemCollectionIndicator> forParameter_indicator;

				public void ScheduleTimeInitialize(GroupOrderIndicator componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_order.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_group.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_indicator.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_order = forParameter_order.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_group = forParameter_group.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_indicator = forParameter_indicator.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public unsafe delegate void RunWithoutJobSystem_0000081C_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

			internal static class RunWithoutJobSystem_0000081C_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_0000081C_0024PostfixBurstDelegate).TypeHandle);
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

				static RunWithoutJobSystem_0000081C_0024BurstDirectCall()
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
			private ComponentDataFromEntity<CCustomerTablePlacement> _ComponentDataFromEntity_CCustomerTablePlacement_0;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void OriginalLambdaBody(Entity e, in DynamicBuffer<CWaitingForItem> order, in DynamicBuffer<CGroupMember> group, in CHasItemCollectionIndicator indicator)
			{
				ecb.SetBuffer<CDisplayedItem>(indicator);
				for (int i = 0; i < order.Length; i++)
				{
					CCustomerTablePlacement cCustomerTablePlacement = _ComponentDataFromEntity_CCustomerTablePlacement_0[group[order[i].MemberIndex]];
					ecb.AppendToBuffer(indicator, new CDisplayedItem
					{
						IsComplete = order[i].Satisfied,
						Item = order[i].Item,
						ItemID = order[i].ItemID,
						SeatPosition = cCustomerTablePlacement.SeatPosition,
						TablePosition = cCustomerTablePlacement.TablePosition,
						IsSide = order[i].IsSide,
						ShowExtra = (order[i].ExtraRequested && !order[i].ExtraSatisfied),
						ExtraID = order[i].Extra,
						IsSatisfiedBySharer = order[i].SatisfiedBySharer
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

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void IterateEntities(ref ArchetypeChunk chunk, [NoAlias] ref LambdaParameterValueProviders.Runtimes runtimes)
			{
				int count = chunk.Count;
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(runtimes.runtime_e.For(i), runtimes.runtime_order.For(i), runtimes.runtime_group.For(i), in runtimes.runtime_indicator.For(i));
				}
			}

			public void ScheduleTimeInitialize(GroupOrderIndicator componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CCustomerTablePlacement_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CCustomerTablePlacement>(true);
			}

			[BurstCompile]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				RunWithoutJobSystem_0000081C_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
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
				ecb = GetCommandBuffer(ECB.End)
			};
			_ = base.Time;
			displayClass.default_archetype = DefaultArchetype;
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
			entityQueryDesc.All = new ComponentType[3]
			{
				ComponentType.ReadOnly<CWaitingForItem>(),
				ComponentType.ReadOnly<CGroupMember>(),
				ComponentType.ReadOnly<CAssignedTable>()
			};
			entityQueryDesc.None = new ComponentType[1] { ComponentType.ReadWrite<CHasItemCollectionIndicator>() };
			entityQueryDesc.Any = new ComponentType[2]
			{
				ComponentType.ReadWrite<CGroupAwaitingOrder>(),
				ComponentType.ReadWrite<CGroupAwaitingExtra>()
			};
			return componentSystem.GetEntityQuery(array);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob1_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
			{
				ComponentType.ReadOnly<CInterfaceOf>(),
				ComponentType.ReadOnly<CDisplayedItem>()
			};
			return componentSystem.GetEntityQuery(array);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob2_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
			{
				ComponentType.ReadOnly<CCustomerGroup>(),
				ComponentType.ReadOnly<CHasItemCollectionIndicator>()
			};
			return componentSystem.GetEntityQuery(array);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob3_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
			entityQueryDesc.All = new ComponentType[3]
			{
				ComponentType.ReadOnly<CWaitingForItem>(),
				ComponentType.ReadOnly<CGroupMember>(),
				ComponentType.ReadOnly<CHasItemCollectionIndicator>()
			};
			entityQueryDesc.Any = new ComponentType[3]
			{
				ComponentType.ReadWrite<CGroupAwaitingOrder>(),
				ComponentType.ReadWrite<CGroupAwaitingExtra>(),
				ComponentType.ReadWrite<CGroupEating>()
			};
			return componentSystem.GetEntityQuery(array);
		}

		public static void Initialize_0024_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0_RunWithoutJobSystem_00000801_0024BurstDirectCall()
		{
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem_00000801_0024BurstDirectCall.Initialize();
		}

		public static void Initialize_0024_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1_RunWithoutJobSystem_0000080A_0024BurstDirectCall()
		{
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.RunWithoutJobSystem_0000080A_0024BurstDirectCall.Initialize();
		}

		public static void Initialize_0024_003C_003Ec__DisplayClass_OnUpdate_LambdaJob2_RunWithoutJobSystem_00000813_0024BurstDirectCall()
		{
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob2.RunWithoutJobSystem_00000813_0024BurstDirectCall.Initialize();
		}

		public static void Initialize_0024_003C_003Ec__DisplayClass_OnUpdate_LambdaJob3_RunWithoutJobSystem_0000081C_0024BurstDirectCall()
		{
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob3.RunWithoutJobSystem_0000081C_0024BurstDirectCall.Initialize();
		}
	}
}
