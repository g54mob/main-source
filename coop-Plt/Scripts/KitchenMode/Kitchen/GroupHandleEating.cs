#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using KitchenData;
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
	public class GroupHandleEating : GameSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass1_0
		{
			public float dt;

			public GroupHandleEating _003C_003E4__this;

			public EntityCommandBuffer ecb;

			internal void _003COnUpdate_003Eb__0(Entity e, ref CGroupMealPhase phase, ref CPatience patience, ref CGroupEating eating, ref DynamicBuffer<CWaitingForItem> waiting_for_items, in CCustomerSettings settings, in CPosition pos, in DynamicBuffer<CGroupMember> members)
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

					public LambdaParameterValueProvider_IComponentData<CGroupMealPhase>.Runtime runtime_phase;

					public LambdaParameterValueProvider_IComponentData<CPatience>.Runtime runtime_patience;

					public LambdaParameterValueProvider_IComponentData<CGroupEating>.Runtime runtime_eating;

					public LambdaParameterValueProvider_DynamicBuffer<CWaitingForItem>.Runtime runtime_waiting_for_items;

					public LambdaParameterValueProvider_IComponentData<CCustomerSettings>.Runtime runtime_settings;

					public LambdaParameterValueProvider_IComponentData<CPosition>.Runtime runtime_pos;

					public LambdaParameterValueProvider_DynamicBuffer<CGroupMember>.Runtime runtime_members;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CGroupMealPhase> forParameter_phase;

				private LambdaParameterValueProvider_IComponentData<CPatience> forParameter_patience;

				private LambdaParameterValueProvider_IComponentData<CGroupEating> forParameter_eating;

				private LambdaParameterValueProvider_DynamicBuffer<CWaitingForItem> forParameter_waiting_for_items;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CCustomerSettings> forParameter_settings;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_pos;

				[ReadOnly]
				private LambdaParameterValueProvider_DynamicBuffer<CGroupMember> forParameter_members;

				public void ScheduleTimeInitialize(GroupHandleEating componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_phase.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_patience.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_eating.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_waiting_for_items.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_settings.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_pos.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_members.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_phase = forParameter_phase.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_patience = forParameter_patience.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_eating = forParameter_eating.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_waiting_for_items = forParameter_waiting_for_items.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_settings = forParameter_settings.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_pos = forParameter_pos.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_members = forParameter_members.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public float dt;

			public GroupHandleEating _003C_003E4__this;

			public EntityCommandBuffer ecb;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CPosition> _ComponentDataFromEntity_CPosition_0;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CGroupHasRepeatedOrder> _ComponentDataFromEntity_CGroupHasRepeatedOrder_1;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CAssignedTable> _ComponentDataFromEntity_CAssignedTable_2;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref CGroupMealPhase phase, ref CPatience patience, ref CGroupEating eating, ref DynamicBuffer<CWaitingForItem> waiting_for_items, in CCustomerSettings settings, in CPosition pos, in DynamicBuffer<CGroupMember> members)
			{
				eating.RemainingTime -= dt;
				int num = 1;
				bool flag = false;
				bool flag2 = false;
				if (_003C_003E4__this.Require<CHalloweenOrder>(e, out CHalloweenOrder comp))
				{
					if (comp.State == TrickTreatStates.TrickDoubleOrder)
					{
						flag = true;
					}
					if (comp.State == TrickTreatStates.TrickExtraMess)
					{
						num *= 3;
					}
					if (comp.State == TrickTreatStates.TreatBuffFloors)
					{
						flag2 = true;
						num *= 3;
					}
				}
				if (Random.value < (float)(num * members.Length) * 0.4f * dt * settings.Ordering.MessFactor && !settings.Ordering.PreventMess)
				{
					CGroupMember cGroupMember = members[Random.Range(0, members.Length)];
					Entity e2 = ecb.CreateEntity();
					ecb.AddComponent(e2, _ComponentDataFromEntity_CPosition_0[cGroupMember]);
					if (flag2)
					{
						ecb.AddComponent(e2, new CMessRequest
						{
							ID = AssetReference.BuffedFloor,
							OverwriteOtherMesses = true
						});
					}
					else
					{
						ecb.AddComponent(e2, new CMessRequest
						{
							ID = AssetReference.CustomerMess
						});
						CSoundEvent.Create(ecb, SoundEvent.MessCreated);
					}
				}
				for (int i = 0; i < waiting_for_items.Length; i++)
				{
					CWaitingForItem value = waiting_for_items[i];
					if (value.Extra != 0 && !value.ExtraRequested && !value.ExtraSatisfied && Random.value < 0.2f * dt)
					{
						value.ExtraRequested = true;
						waiting_for_items[i] = value;
						patience = settings.NewPhase(PatienceReason.GetFoodDelivered);
						ecb.RemoveComponent<CGroupEating>(e);
						ecb.AddComponent<CGroupAwaitingExtra>(e);
						ecb.AddComponent<CGroupStateChanged>(e);
						return;
					}
				}
				if (eating.RemainingTime > 0f)
				{
					return;
				}
				if (_ComponentDataFromEntity_CGroupHasRepeatedOrder_1.HasComponent(e) || (!flag && !(Random.value < settings.Ordering.RepeatCourseModifier)))
				{
					phase.Phase = phase.Phase.Next();
				}
				else
				{
					ecb.AddComponent<CGroupHasRepeatedOrder>(e);
				}
				patience = settings.NewPhase(PatienceReason.Thinking);
				ecb.RemoveComponent<CWaitingForItem>(e);
				ecb.RemoveComponent<CWaitingForItem.Marker>(e);
				ecb.RemoveComponent<CGroupEating>(e);
				ecb.AddComponent<CGroupChoosingOrder>(e);
				ecb.AddComponent<CGroupStateChanged>(e);
				if (!_ComponentDataFromEntity_CAssignedTable_2.HasComponent(e))
				{
					return;
				}
				CAssignedTable cAssignedTable = _ComponentDataFromEntity_CAssignedTable_2[e];
				bool flag3 = false;
				foreach (CGroupMember member in members)
				{
					flag3 |= _003C_003E4__this.Has<CCustomerHasLeftoversBag>(member);
				}
				if (!_003C_003E4__this.Has<CTableSpawnDirt>(cAssignedTable))
				{
					ecb.AddComponent(cAssignedTable, new CTableSpawnDirt
					{
						ReuseConsumables = true,
						BlockExtendedDirt = flag3
					});
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				dt = displayClass.dt;
				_003C_003E4__this = displayClass._003C_003E4__this;
				ecb = displayClass.ecb;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				displayClass.dt = dt;
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
					Entity e = runtimes.runtime_e.For(i);
					ref CGroupMealPhase phase = ref runtimes.runtime_phase.For(i);
					ref CPatience patience = ref runtimes.runtime_patience.For(i);
					ref CGroupEating eating = ref runtimes.runtime_eating.For(i);
					DynamicBuffer<CWaitingForItem> waiting_for_items = runtimes.runtime_waiting_for_items.For(i);
					OriginalLambdaBody(e, ref phase, ref patience, ref eating, ref waiting_for_items, in runtimes.runtime_settings.For(i), in runtimes.runtime_pos.For(i), runtimes.runtime_members.For(i));
				}
			}

			public void ScheduleTimeInitialize(GroupHandleEating componentSystem, ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CPosition_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CPosition>(true);
				_ComponentDataFromEntity_CGroupHasRepeatedOrder_1 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CGroupHasRepeatedOrder>(true);
				_ComponentDataFromEntity_CAssignedTable_2 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CAssignedTable>(true);
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
			RequireForUpdate(GetEntityQuery(typeof(CGroupEating)));
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass1_0 displayClass = new _003C_003Ec__DisplayClass1_0
			{
				_003C_003E4__this = this,
				dt = base.Time.DeltaTime,
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
			(array[0] = new EntityQueryDesc()).All = new ComponentType[7]
			{
				ComponentType.ReadWrite<CGroupEating>(),
				ComponentType.ReadWrite<CGroupMealPhase>(),
				ComponentType.ReadWrite<CPatience>(),
				ComponentType.ReadWrite<CWaitingForItem>(),
				ComponentType.ReadOnly<CCustomerSettings>(),
				ComponentType.ReadOnly<CPosition>(),
				ComponentType.ReadOnly<CGroupMember>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
