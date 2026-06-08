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
	public class UpdateTableDirtyStatus : GameSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass2_0
		{
			public UpdateTableDirtyStatus _003C_003E4__this;

			public EntityCommandBuffer ecb;

			internal void _003COnUpdate_003Eb__0(Entity e, in DynamicBuffer<CTableSetParts> parts, in CTableSetModifier mods)
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
					public LambdaParameterValueProvider_DynamicBuffer<CTableSetParts>.Runtime runtime_parts;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<CTableSetModifier>.Runtime runtime_mods;
				}

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_DynamicBuffer<CTableSetParts> forParameter_parts;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<CTableSetModifier> forParameter_mods;

				public void ScheduleTimeInitialize(UpdateTableDirtyStatus componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_parts.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_mods.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_parts = forParameter_parts.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_mods = forParameter_mods.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public unsafe delegate void RunWithoutJobSystem_00000A71_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

			internal static class RunWithoutJobSystem_00000A71_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_00000A71_0024PostfixBurstDelegate).TypeHandle);
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

				static RunWithoutJobSystem_00000A71_0024BurstDirectCall()
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
			private ComponentDataFromEntity<CTableReadyForCustomers> _ComponentDataFromEntity_CTableReadyForCustomers_0;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CTableSpawnDirt> _ComponentDataFromEntity_CTableSpawnDirt_1;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CPreventUse> _ComponentDataFromEntity_CPreventUse_2;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CItemHolder> _ComponentDataFromEntity_CItemHolder_3;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CItemStorage> _ComponentDataFromEntity_CItemStorage_4;

			[NoAlias]
			private BufferFromEntity<CItemStored> _BufferFromEntity_CItemStored_5;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void OriginalLambdaBody(Entity e, in DynamicBuffer<CTableSetParts> parts, in CTableSetModifier mods)
			{
				bool flag = _ComponentDataFromEntity_CTableReadyForCustomers_0.HasComponent(e);
				bool flag2 = _ComponentDataFromEntity_CTableSpawnDirt_1.HasComponent(e);
				if (!flag2)
				{
					for (int i = 0; i < parts.Length; i++)
					{
						if (_ComponentDataFromEntity_CPreventUse_2.HasComponent(parts[i]))
						{
							flag2 = true;
						}
						if (_ComponentDataFromEntity_CItemHolder_3[parts[i]].HeldItem != default(Entity))
						{
							flag2 = true;
						}
						if (flag2)
						{
							break;
						}
						if (_ComponentDataFromEntity_CItemStorage_4.HasComponent(parts[i]))
						{
							DynamicBuffer<CItemStored> dynamicBuffer = _BufferFromEntity_CItemStored_5[parts[i]];
							for (int j = 0; j < dynamicBuffer.Length; j++)
							{
								if (dynamicBuffer[j].StoredItem != default(Entity))
								{
									flag2 = true;
								}
							}
						}
						if (flag2)
						{
							break;
						}
					}
				}
				flag2 &= !mods.OrderingModifiers.SeatWithoutClear;
				if (flag)
				{
					if (flag2)
					{
						ecb.RemoveComponent<CTableReadyForCustomers>(e);
					}
				}
				else if (!flag2)
				{
					ecb.AddComponent<CTableReadyForCustomers>(e);
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				ecb = displayClass.ecb;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), runtimes.runtime_parts.For(i), in runtimes.runtime_mods.For(i));
				}
			}

			public void ScheduleTimeInitialize(UpdateTableDirtyStatus componentSystem, ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CTableReadyForCustomers_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CTableReadyForCustomers>(true);
				_ComponentDataFromEntity_CTableSpawnDirt_1 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CTableSpawnDirt>(true);
				_ComponentDataFromEntity_CPreventUse_2 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CPreventUse>(true);
				_ComponentDataFromEntity_CItemHolder_3 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CItemHolder>(true);
				_ComponentDataFromEntity_CItemStorage_4 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CItemStorage>(true);
				_BufferFromEntity_CItemStored_5 = ((ComponentSystemBase)componentSystem).GetBufferFromEntity<CItemStored>(false);
			}

			[BurstCompile]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				RunWithoutJobSystem_00000A71_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery OccupiedReadyTables;

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void Initialise()
		{
			base.Initialise();
			OccupiedReadyTables = GetEntityQuery(typeof(CTableReadyForCustomers), typeof(COccupiedByGroup));
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass2_0 displayClass = new _003C_003Ec__DisplayClass2_0
			{
				_003C_003E4__this = this,
				ecb = GetCommandBuffer(ECB.End)
			};
			base.EntityManager.RemoveComponent<CTableReadyForCustomers>(OccupiedReadyTables);
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
			EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
			entityQueryDesc.All = new ComponentType[2]
			{
				ComponentType.ReadOnly<CTableSetParts>(),
				ComponentType.ReadOnly<CTableSetModifier>()
			};
			entityQueryDesc.None = new ComponentType[1] { ComponentType.ReadWrite<COccupiedByGroup>() };
			return componentSystem.GetEntityQuery(array);
		}

		public static void Initialize_0024_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0_RunWithoutJobSystem_00000A71_0024BurstDirectCall()
		{
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem_00000A71_0024BurstDirectCall.Initialize();
		}
	}
}
