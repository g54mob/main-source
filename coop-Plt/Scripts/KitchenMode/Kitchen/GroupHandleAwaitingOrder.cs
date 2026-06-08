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
	public class GroupHandleAwaitingOrder : GameSystemBase
	{
		private struct CChangeOrderCooldown : IComponentData
		{
			public float Timeout;
		}

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass3_0
		{
			public GroupHandleAwaitingOrder _003C_003E4__this;

			public float dt;

			public float time;

			public EntityCommandBuffer ecb;

			public EntityContext ctx;

			public TwitchNameList twitch_name_list;

			public bool is_money;

			public float profit;

			internal void _003COnUpdate_003Eb__0(Entity e, ref CGroupMealPhase phase, ref CPatience patience, ref CGroupReward reward, in DynamicBuffer<CWaitingForItem> order, in CCustomerSettings settings, in CPosition pos)
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

					public LambdaParameterValueProvider_IComponentData<CGroupReward>.Runtime runtime_reward;

					public LambdaParameterValueProvider_DynamicBuffer<CWaitingForItem>.Runtime runtime_order;

					public LambdaParameterValueProvider_IComponentData<CCustomerSettings>.Runtime runtime_settings;

					public LambdaParameterValueProvider_IComponentData<CPosition>.Runtime runtime_pos;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CGroupMealPhase> forParameter_phase;

				private LambdaParameterValueProvider_IComponentData<CPatience> forParameter_patience;

				private LambdaParameterValueProvider_IComponentData<CGroupReward> forParameter_reward;

				[ReadOnly]
				private LambdaParameterValueProvider_DynamicBuffer<CWaitingForItem> forParameter_order;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CCustomerSettings> forParameter_settings;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_pos;

				public void ScheduleTimeInitialize(GroupHandleAwaitingOrder componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_phase.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_patience.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_reward.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_order.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_settings.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_pos.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_phase = forParameter_phase.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_patience = forParameter_patience.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_reward = forParameter_reward.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_order = forParameter_order.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_settings = forParameter_settings.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_pos = forParameter_pos.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public GroupHandleAwaitingOrder _003C_003E4__this;

			public float dt;

			public float time;

			public EntityCommandBuffer ecb;

			public EntityContext ctx;

			public TwitchNameList twitch_name_list;

			public bool is_money;

			public float profit;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CGroupForceChangedMind> _ComponentDataFromEntity_CGroupForceChangedMind_0;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CGroupTriggerChangedMind> _ComponentDataFromEntity_CGroupTriggerChangedMind_1;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CGroupHasChangedMind> _ComponentDataFromEntity_CGroupHasChangedMind_2;

			[NoAlias]
			private BufferFromEntity<CGroupMember> _BufferFromEntity_CGroupMember_3;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref CGroupMealPhase phase, ref CPatience patience, ref CGroupReward reward, in DynamicBuffer<CWaitingForItem> order, in CCustomerSettings settings, in CPosition pos)
			{
				bool flag = true;
				bool flag2 = true;
				for (int i = 0; i < order.Length; i++)
				{
					CWaitingForItem cWaitingForItem = order[i];
					flag2 &= cWaitingForItem.Satisfied || (cWaitingForItem.IsSide && settings.Ordering.SidesOptional);
					flag &= !cWaitingForItem.Satisfied;
					flag &= !_003C_003E4__this.Has<COriginalOrderBeforePiecemeal>(cWaitingForItem.Item);
				}
				CHalloweenOrder comp;
				bool flag3 = _003C_003E4__this.Require<CHalloweenOrder>(e, out comp);
				bool flag4 = _ComponentDataFromEntity_CGroupForceChangedMind_0.HasComponent(e);
				bool flag5 = _ComponentDataFromEntity_CGroupTriggerChangedMind_1.HasComponent(e);
				bool flag6 = flag3 && comp.State == TrickTreatStates.TrickChangeOrders;
				if ((flag && flag6) || flag4 || (!_ComponentDataFromEntity_CGroupHasChangedMind_2.HasComponent(e) && ((flag && patience.RemainingTime > 0.9f) || flag5)))
				{
					bool num = flag5 || flag4 || Random.value < settings.Ordering.ChangeMindModifier * dt;
					CChangeOrderCooldown comp2;
					bool flag7 = (!_003C_003E4__this.Require<CChangeOrderCooldown>(e, out comp2) || !(time < comp2.Timeout)) && flag6 && Random.value < 0.1f * dt;
					if (num || flag7)
					{
						ecb.RemoveComponent<CWaitingForItem>(e);
						ecb.RemoveComponent<CWaitingForItem.Marker>(e);
						ecb.RemoveComponent<CGroupAwaitingOrder>(e);
						if (flag4)
						{
							ecb.RemoveComponent<CGroupForceChangedMind>(e);
						}
						if (flag5)
						{
							ecb.RemoveComponent<CGroupTriggerChangedMind>(e);
						}
						ecb.AddComponent<CGroupReadyToOrder>(e);
						ecb.AddComponent<CGroupPromptedForOrder>(e);
						ecb.AddComponent<CGroupStateChanged>(e);
						ecb.AddComponent<CGroupHasChangedMind>(e);
						if (flag7)
						{
							if (_003C_003E4__this.Has<CChangeOrderCooldown>(e))
							{
								ecb.SetComponent(e, new CChangeOrderCooldown
								{
									Timeout = time + 10f
								});
							}
							else
							{
								ecb.AddComponent(e, new CChangeOrderCooldown
								{
									Timeout = time + 10f
								});
							}
							CEventIndicator.Request(ctx, pos, EventType.HalloweenTrick);
						}
						return;
					}
				}
				if (!flag2)
				{
					return;
				}
				patience = settings.NewPhase(PatienceReason.Eating);
				_003C_003E4__this.Require<CEatingTimeFactor>(e, out CEatingTimeFactor comp3);
				ecb.RemoveComponent<CEatingTimeFactor>(e);
				ecb.RemoveComponent<CGroupAwaitingOrder>(e);
				ecb.AddComponent(e, new CGroupEating
				{
					RemainingTime = settings.Patience.Eating * comp3.Factor
				});
				ecb.AddComponent<CGroupStateChanged>(e);
				DynamicBuffer<CGroupMember> dynamicBuffer = _BufferFromEntity_CGroupMember_3[e];
				int num2 = ((float)(int)reward * settings.Ordering.PriceModifier).ProbabilisticRound();
				reward += num2;
				CommitCompletedGroups.AddEvent(ctx, e, 0, num2);
				if (flag3)
				{
					switch (comp.State)
					{
					case TrickTreatStates.TreatDoubleMoney:
						CommitCompletedGroups.AddEvent(ctx, e, 0, reward);
						reward = (int)reward * 2;
						CEventIndicator.Request(ctx, pos, EventType.HalloweenTreat);
						CommitCompletedGroups.CommitGroup(ctx, e);
						break;
					case TrickTreatStates.TrickNoPayment:
						reward = 0;
						CEventIndicator.Request(ctx, pos, EventType.HalloweenTrick);
						CommitCompletedGroups.CommitGroup(ctx, e, is_failure: true);
						break;
					default:
						CommitCompletedGroups.CommitGroup(ctx, e);
						break;
					}
				}
				else
				{
					CommitCompletedGroups.CommitGroup(ctx, e);
				}
				int num3 = 0;
				foreach (CGroupMember item in dynamicBuffer)
				{
					num3 += twitch_name_list.GetBits(item.Customer);
				}
				Entity e2 = ecb.CreateEntity();
				ecb.AddComponent(e2, new CMoneyPopup
				{
					Change = reward,
					TwitchBits = num3
				});
				ecb.AddComponent(e2, new CPosition(pos));
				ecb.AddComponent(e2, new CLifetime(1f));
				ecb.AddComponent(e2, new CRequiresView
				{
					Type = (is_money ? ViewType.MoneyPopup : ViewType.LovePopup)
				});
				profit += (int)reward;
				reward.Amount = 0;
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
				dt = displayClass.dt;
				time = displayClass.time;
				ecb = displayClass.ecb;
				ctx = displayClass.ctx;
				twitch_name_list = displayClass.twitch_name_list;
				is_money = displayClass.is_money;
				profit = displayClass.profit;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
			{
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.dt = dt;
				displayClass.time = time;
				displayClass.ecb = ecb;
				displayClass.ctx = ctx;
				displayClass.twitch_name_list = twitch_name_list;
				displayClass.is_money = is_money;
				displayClass.profit = profit;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_phase.For(i), ref runtimes.runtime_patience.For(i), ref runtimes.runtime_reward.For(i), runtimes.runtime_order.For(i), in runtimes.runtime_settings.For(i), in runtimes.runtime_pos.For(i));
				}
			}

			public void ScheduleTimeInitialize(GroupHandleAwaitingOrder componentSystem, ref _003C_003Ec__DisplayClass3_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CGroupForceChangedMind_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CGroupForceChangedMind>(true);
				_ComponentDataFromEntity_CGroupTriggerChangedMind_1 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CGroupTriggerChangedMind>(true);
				_ComponentDataFromEntity_CGroupHasChangedMind_2 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CGroupHasChangedMind>(true);
				_BufferFromEntity_CGroupMember_3 = ((ComponentSystemBase)componentSystem).GetBufferFromEntity<CGroupMember>(false);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery Players;

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SMoney_8;

		private EntityQuery _SingletonEntityQuery_SMoney_9;

		protected override void Initialise()
		{
			base.Initialise();
			Players = GetEntityQuery(typeof(CPlayer));
			RequireForUpdate(GetEntityQuery(typeof(CGroupAwaitingOrder)));
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass3_0 displayClass = default(_003C_003Ec__DisplayClass3_0);
			displayClass._003C_003E4__this = this;
			displayClass.dt = base.Time.DeltaTime;
			displayClass.ecb = GetCommandBuffer(ECB.StateChanges);
			displayClass.ctx = new EntityContext(base.EntityManager, displayClass.ecb);
			displayClass.time = base.Time.TotalTime;
			displayClass.profit = 0f;
			displayClass.is_money = HasSingleton<SMoney>();
			displayClass.twitch_name_list = base.World.GetExistingSystem<TwitchNameList>();
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
			if ((displayClass.profit > 0f) & displayClass.is_money)
			{
				_SingletonEntityQuery_SMoney_9.SetSingleton((SMoney)(_SingletonEntityQuery_SMoney_8.GetSingleton<SMoney>().Amount + displayClass.profit.ProbabilisticRound()));
			}
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EOnUpdate_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(this);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem;
			_003C_003EOnUpdate_LambdaJob0_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob0");
			_SingletonEntityQuery_SMoney_8 = GetEntityQuery(ComponentType.ReadOnly<SMoney>());
			_SingletonEntityQuery_SMoney_9 = GetEntityQuery(ComponentType.ReadWrite<SMoney>());
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[7]
			{
				ComponentType.ReadOnly<CGroupAwaitingOrder>(),
				ComponentType.ReadWrite<CGroupMealPhase>(),
				ComponentType.ReadWrite<CPatience>(),
				ComponentType.ReadWrite<CGroupReward>(),
				ComponentType.ReadOnly<CWaitingForItem>(),
				ComponentType.ReadOnly<CCustomerSettings>(),
				ComponentType.ReadOnly<CPosition>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
