#define ENABLE_PROFILER
using System;
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
	public class GroupReceiveBonus : GameSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass1_0
		{
			public bool has_found_item;

			public GroupReceiveBonus _003C_003E4__this;

			public EntityCommandBuffer ecb;

			internal void _003COnUpdate_003Eb__0(Entity e, ref CPatience patience, in CCustomerSettings settings, in DynamicBuffer<CGroupMember> group, in CAssignedTable table_set)
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

					public LambdaParameterValueProvider_IComponentData<CPatience>.Runtime runtime_patience;

					public LambdaParameterValueProvider_IComponentData<CCustomerSettings>.Runtime runtime_settings;

					public LambdaParameterValueProvider_DynamicBuffer<CGroupMember>.Runtime runtime_group;

					public LambdaParameterValueProvider_IComponentData<CAssignedTable>.Runtime runtime_table_set;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CPatience> forParameter_patience;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CCustomerSettings> forParameter_settings;

				[ReadOnly]
				private LambdaParameterValueProvider_DynamicBuffer<CGroupMember> forParameter_group;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CAssignedTable> forParameter_table_set;

				public void ScheduleTimeInitialize(GroupReceiveBonus componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_patience.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_settings.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_group.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_table_set.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_patience = forParameter_patience.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_settings = forParameter_settings.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_group = forParameter_group.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_table_set = forParameter_table_set.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public bool has_found_item;

			public EntityCommandBuffer ecb;

			public GroupReceiveBonus _003C_003E4__this;

			[NoAlias]
			private BufferFromEntity<CTableSetGrabPoints> _BufferFromEntity_CTableSetGrabPoints_0;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CItemHolder> _ComponentDataFromEntity_CItemHolder_1;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CTriggerOrderReset> _ComponentDataFromEntity_CTriggerOrderReset_2;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CGroupAwaitingOrder> _ComponentDataFromEntity_CGroupAwaitingOrder_3;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CTriggerPatienceReset> _ComponentDataFromEntity_CTriggerPatienceReset_4;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CTriggerLeaveHappy> _ComponentDataFromEntity_CTriggerLeaveHappy_5;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref CPatience patience, in CCustomerSettings settings, in DynamicBuffer<CGroupMember> group, in CAssignedTable table_set)
			{
				if (has_found_item)
				{
					return;
				}
				DynamicBuffer<CTableSetGrabPoints> dynamicBuffer = _BufferFromEntity_CTableSetGrabPoints_0[table_set];
				for (int i = 0; i < dynamicBuffer.Length; i++)
				{
					if (has_found_item)
					{
						break;
					}
					CTableSetGrabPoints cTableSetGrabPoints = dynamicBuffer[i];
					CItemHolder cItemHolder = _ComponentDataFromEntity_CItemHolder_1[cTableSetGrabPoints];
					if (cItemHolder.HeldItem == default(Entity))
					{
						continue;
					}
					bool flag = false;
					if (_ComponentDataFromEntity_CTriggerOrderReset_2.HasComponent(cItemHolder.HeldItem) && _ComponentDataFromEntity_CGroupAwaitingOrder_3.HasComponent(e))
					{
						flag = true;
						ecb.AddComponent<CGroupForceChangedMind>(e);
					}
					if (_ComponentDataFromEntity_CTriggerPatienceReset_4.HasComponent(cItemHolder.HeldItem) && !_003C_003E4__this.Has<CGroupEating>(e))
					{
						patience.RemainingTime = patience.StartTime;
						flag = true;
					}
					if (_ComponentDataFromEntity_CTriggerLeaveHappy_5.HasComponent(cItemHolder.HeldItem) && !_003C_003E4__this.Has<CGroupStartLeaving>(e))
					{
						ecb.AddComponent<CGroupStartLeaving>(e);
						ecb.AddComponent<CGroupStateChanged>(e);
						flag = true;
					}
					if (_003C_003E4__this.Has<CTriggerLeftoverCurrentMeal>(cItemHolder.HeldItem) && _003C_003E4__this.Has<CGroupEating>(e))
					{
						bool flag2 = true;
						foreach (CGroupMember item in group)
						{
							if (!_003C_003E4__this.Has<CCustomerHasLeftoversBag>(item))
							{
								flag2 = false;
								break;
							}
						}
						if (!flag2)
						{
							ecb.SetComponent(e, new CGroupEating
							{
								RemainingTime = 0f
							});
							foreach (CGroupMember item2 in group)
							{
								ecb.AddComponent<CCustomerHasLeftoversBag>(item2);
							}
							flag = true;
						}
					}
					if (flag)
					{
						settings.AddPatience(ref patience, settings.Patience.ItemDeliverBonus);
						ecb.SetComponent(cTableSetGrabPoints, default(CItemHolder));
						ecb.DestroyEntity(cItemHolder.HeldItem);
						has_found_item = true;
						break;
					}
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				has_found_item = displayClass.has_found_item;
				ecb = displayClass.ecb;
				_003C_003E4__this = displayClass._003C_003E4__this;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				displayClass.has_found_item = has_found_item;
				displayClass.ecb = ecb;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_patience.For(i), in runtimes.runtime_settings.For(i), runtimes.runtime_group.For(i), in runtimes.runtime_table_set.For(i));
				}
			}

			public void ScheduleTimeInitialize(GroupReceiveBonus componentSystem, ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_BufferFromEntity_CTableSetGrabPoints_0 = ((ComponentSystemBase)componentSystem).GetBufferFromEntity<CTableSetGrabPoints>(false);
				_ComponentDataFromEntity_CItemHolder_1 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CItemHolder>(true);
				_ComponentDataFromEntity_CTriggerOrderReset_2 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CTriggerOrderReset>(true);
				_ComponentDataFromEntity_CGroupAwaitingOrder_3 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CGroupAwaitingOrder>(true);
				_ComponentDataFromEntity_CTriggerPatienceReset_4 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CTriggerPatienceReset>(true);
				_ComponentDataFromEntity_CTriggerLeaveHappy_5 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CTriggerLeaveHappy>(true);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void Initialise()
		{
			base.Initialise();
			RequireForUpdate(GetEntityQuery(typeof(CAtTable), typeof(CAssignedTable)));
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass1_0 displayClass = new _003C_003Ec__DisplayClass1_0
			{
				_003C_003E4__this = this,
				ecb = new EntityCommandBuffer(Allocator.TempJob)
			};
			try
			{
				displayClass.has_found_item = false;
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
				displayClass.ecb.Playback(base.EntityManager);
			}
			finally
			{
				((IDisposable)displayClass.ecb/*cast due to .constrained prefix*/).Dispose();
			}
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
			EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
			entityQueryDesc.All = new ComponentType[4]
			{
				ComponentType.ReadWrite<CPatience>(),
				ComponentType.ReadOnly<CCustomerSettings>(),
				ComponentType.ReadOnly<CGroupMember>(),
				ComponentType.ReadOnly<CAssignedTable>()
			};
			entityQueryDesc.Any = new ComponentType[1] { ComponentType.ReadWrite<CAtTable>() };
			return componentSystem.GetEntityQuery(array);
		}
	}
}
