#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	[UpdateInGroup(typeof(UpdateCustomerStatesGroup))]
	public class GroupHandleStartLeaving : GameSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass0_0
		{
			public GroupHandleStartLeaving _003C_003E4__this;

			public EntityCommandBuffer ecb;

			internal void _003COnUpdate_003Eb__0(Entity e, in DynamicBuffer<CGroupMember> members, in CCustomerSettings settings)
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

					public LambdaParameterValueProvider_DynamicBuffer<CGroupMember>.Runtime runtime_members;

					public LambdaParameterValueProvider_IComponentData<CCustomerSettings>.Runtime runtime_settings;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[ReadOnly]
				private LambdaParameterValueProvider_DynamicBuffer<CGroupMember> forParameter_members;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CCustomerSettings> forParameter_settings;

				public void ScheduleTimeInitialize(GroupHandleStartLeaving componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_members.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_settings.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_members = forParameter_members.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_settings = forParameter_settings.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public GroupHandleStartLeaving _003C_003E4__this;

			public EntityCommandBuffer ecb;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CGroupAwaitingOrder> _ComponentDataFromEntity_CGroupAwaitingOrder_0;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CGroupReadyToOrder> _ComponentDataFromEntity_CGroupReadyToOrder_1;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CQueuePosition> _ComponentDataFromEntity_CQueuePosition_2;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CMoveToLocation> _ComponentDataFromEntity_CMoveToLocation_3;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, in DynamicBuffer<CGroupMember> members, in CCustomerSettings settings)
			{
				if (_003C_003E4__this.Require<CAssignedTable>(e, out CAssignedTable comp) && comp.Table != default(Entity))
				{
					if (!_003C_003E4__this.Has<CTableSpawnDirt>(comp))
					{
						ecb.AddComponent<CTableSpawnDirt>(comp);
					}
					bool flag = false;
					foreach (CGroupMember member in members)
					{
						flag |= _003C_003E4__this.Has<CCustomerHasLeftoversBag>(member);
					}
					ecb.SetComponent(comp, new CTableSpawnDirt
					{
						ReuseConsumables = (Random.value < settings.Ordering.ConsumableReuseChance),
						BlockExtendedDirt = flag
					});
					ecb.RemoveComponent<CAssignedTable>(e);
					ecb.RemoveComponent<COccupiedByGroup>(comp);
				}
				if (_003C_003E4__this.Require<CAssignedMenu>(e, out CAssignedMenu comp2) && comp2.Menu != default(Entity))
				{
					ecb.RemoveComponent<CAssignedMenu>(e);
					ecb.RemoveComponent<COccupiedByGroup>(comp2.Menu);
				}
				if (_003C_003E4__this.Require<CAssignedStand>(e, out CAssignedStand comp3) && comp3.Stand != default(Entity))
				{
					ecb.RemoveComponent<CAssignedStand>(e);
					ecb.RemoveComponent<COccupiedByGroup>(comp3.Stand);
				}
				if (_ComponentDataFromEntity_CGroupAwaitingOrder_0.HasComponent(e))
				{
					ecb.RemoveComponent<CGroupAwaitingOrder>(e);
				}
				if (_ComponentDataFromEntity_CGroupReadyToOrder_1.HasComponent(e))
				{
					ecb.RemoveComponent<CGroupReadyToOrder>(e);
				}
				if (_ComponentDataFromEntity_CQueuePosition_2.HasComponent(e))
				{
					ecb.RemoveComponent<CQueuePosition>(e);
				}
				for (int i = 0; i < members.Length; i++)
				{
					CGroupMember cGroupMember = members[i];
					if (_ComponentDataFromEntity_CMoveToLocation_3.HasComponent(cGroupMember))
					{
						ecb.RemoveComponent<CMoveToLocation>(cGroupMember);
						ecb.AddComponent<CCustomerLeaving>(cGroupMember);
					}
				}
				Entity e2 = ecb.CreateEntity();
				ecb.AddComponent<CGroupServedEvent>(e2);
				ecb.RemoveComponent<CGroupStartLeaving>(e);
				ecb.AddComponent<CGroupLeaving>(e);
				ecb.AddComponent<CGroupStateChanged>(e);
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
				ecb = displayClass.ecb;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				displayClass._003C_003E4__this = _003C_003E4__this;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), runtimes.runtime_members.For(i), in runtimes.runtime_settings.For(i));
				}
			}

			public void ScheduleTimeInitialize(GroupHandleStartLeaving componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CGroupAwaitingOrder_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CGroupAwaitingOrder>(true);
				_ComponentDataFromEntity_CGroupReadyToOrder_1 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CGroupReadyToOrder>(true);
				_ComponentDataFromEntity_CQueuePosition_2 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CQueuePosition>(true);
				_ComponentDataFromEntity_CMoveToLocation_3 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CMoveToLocation>(true);
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
				ecb = GetCommandBuffer(ECB.StateChanges)
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
				ComponentType.ReadOnly<CGroupStartLeaving>(),
				ComponentType.ReadOnly<CGroupMember>(),
				ComponentType.ReadOnly<CCustomerSettings>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
