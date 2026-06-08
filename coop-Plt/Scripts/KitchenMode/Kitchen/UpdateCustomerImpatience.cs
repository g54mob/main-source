#define ENABLE_PROFILER
using System;
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
	public class UpdateCustomerImpatience : GameSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass3_0
		{
			public UpdateCustomerImpatience _003C_003E4__this;

			public EntityCommandBuffer ecb;

			public bool has_queue;

			public bool lose_patience_in_room;

			public NativeArray<CPosition> player_positions;

			public float dt;

			public float player_factor;

			public EntityArchetype default_archetype;

			internal void _003COnUpdate_003Eb__0(Entity e, ref CPatience patience, in DynamicBuffer<CGroupMember> group, in CCustomerSettings settings, in CPosition pos)
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

					public LambdaParameterValueProvider_DynamicBuffer<CGroupMember>.Runtime runtime_group;

					public LambdaParameterValueProvider_IComponentData<CCustomerSettings>.Runtime runtime_settings;

					public LambdaParameterValueProvider_IComponentData<CPosition>.Runtime runtime_pos;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CPatience> forParameter_patience;

				[ReadOnly]
				private LambdaParameterValueProvider_DynamicBuffer<CGroupMember> forParameter_group;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CCustomerSettings> forParameter_settings;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_pos;

				public void ScheduleTimeInitialize(UpdateCustomerImpatience componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_patience.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_group.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_settings.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_pos.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_patience = forParameter_patience.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_group = forParameter_group.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_settings = forParameter_settings.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_pos = forParameter_pos.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public EntityCommandBuffer ecb;

			public bool has_queue;

			public UpdateCustomerImpatience _003C_003E4__this;

			public bool lose_patience_in_room;

			public NativeArray<CPosition> player_positions;

			public float dt;

			public float player_factor;

			public EntityArchetype default_archetype;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<GroupUsePatienceReset.CGivePatienceReset> _ComponentDataFromEntity_CGivePatienceReset_0;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CAssignedTable> _ComponentDataFromEntity_CAssignedTable_1;

			[NoAlias]
			private BufferFromEntity<CTableSetParts> _BufferFromEntity_CTableSetParts_2;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref CPatience patience, in DynamicBuffer<CGroupMember> group, in CCustomerSettings settings, in CPosition pos)
			{
				if (!patience.Active)
				{
					return;
				}
				if (_ComponentDataFromEntity_CGivePatienceReset_0.HasComponent(e))
				{
					patience.RemainingTime = patience.StartTime;
					ecb.RemoveComponent<GroupUsePatienceReset.CGivePatienceReset>(e);
					return;
				}
				float num = 1f;
				if (has_queue && settings.Patience.InfinitePatienceIfQueue)
				{
					num = 0f;
				}
				if (!_003C_003E4__this.Has<CAtTable>(e) && !_003C_003E4__this.Has<CAssignedStand>(e))
				{
					num = 0f;
				}
				int num2 = (lose_patience_in_room ? _003C_003E4__this.TileManager.GetRoom(pos) : 0);
				bool flag = false;
				bool flag2 = false;
				if (settings.Patience.BonusPatienceWhenNearby | lose_patience_in_room)
				{
					for (int i = 0; i < player_positions.Length; i++)
					{
						CPosition cPosition = player_positions[i];
						if (settings.Patience.BonusPatienceWhenNearby && (cPosition.Position - pos).Chebyshev() < 2f)
						{
							flag2 = true;
						}
						if (!lose_patience_in_room || num2 != _003C_003E4__this.TileManager.GetRoom(cPosition))
						{
							continue;
						}
						foreach (CGroupMember item in group)
						{
							if (!_003C_003E4__this.Require<CPosition>((Entity)item, out CPosition comp))
							{
								continue;
							}
							Vector3 vector = cPosition.Position - comp.Position;
							if (vector.sqrMagnitude < 25f)
							{
								Vector3 rhs = comp.Forward(1f);
								if (Vector3.Dot(vector.normalized, rhs) > 1f - Mathf.Cos((float)Math.PI / 4f))
								{
									flag = true;
								}
							}
						}
					}
				}
				if (flag && patience.Reason != PatienceReason.GetFoodDelivered)
				{
					num *= 4f;
				}
				if (flag2)
				{
					num *= 0.5f;
				}
				settings.AddPatience(ref patience, (0f - dt) * num * player_factor);
				patience.LastUpdateRate = num;
				patience.Factors &= ~(DisplayedPatienceFactor.PlayerInView | DisplayedPatienceFactor.PlayerNearby);
				patience.Factors |= (DisplayedPatienceFactor)(flag ? 1 : 0);
				patience.Factors |= (DisplayedPatienceFactor)(flag2 ? 2 : 0);
				if (!(patience.RemainingTime <= 0f))
				{
					return;
				}
				ecb.AddComponent<CGroupStartLeaving>(e);
				if (settings.Patience.DestroyTableIfLeave)
				{
					if (!_ComponentDataFromEntity_CAssignedTable_1.HasComponent(e))
					{
						return;
					}
					CAssignedTable cAssignedTable = _ComponentDataFromEntity_CAssignedTable_1[e];
					{
						foreach (CTableSetParts item2 in _BufferFromEntity_CTableSetParts_2[cAssignedTable])
						{
							ecb.AddComponent<CIsBroken>(item2);
						}
						return;
					}
				}
				ecb.AddComponent<CLoseLifeEvent>(ecb.CreateEntity(default_archetype));
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
			{
				ecb = displayClass.ecb;
				has_queue = displayClass.has_queue;
				_003C_003E4__this = displayClass._003C_003E4__this;
				lose_patience_in_room = displayClass.lose_patience_in_room;
				player_positions = displayClass.player_positions;
				dt = displayClass.dt;
				player_factor = displayClass.player_factor;
				default_archetype = displayClass.default_archetype;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
			{
				displayClass.ecb = ecb;
				displayClass.has_queue = has_queue;
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.lose_patience_in_room = lose_patience_in_room;
				displayClass.player_positions = player_positions;
				displayClass.dt = dt;
				displayClass.player_factor = player_factor;
				displayClass.default_archetype = default_archetype;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_patience.For(i), runtimes.runtime_group.For(i), in runtimes.runtime_settings.For(i), in runtimes.runtime_pos.For(i));
				}
			}

			public void ScheduleTimeInitialize(UpdateCustomerImpatience componentSystem, ref _003C_003Ec__DisplayClass3_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CGivePatienceReset_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<GroupUsePatienceReset.CGivePatienceReset>(true);
				_ComponentDataFromEntity_CAssignedTable_1 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CAssignedTable>(true);
				_BufferFromEntity_CTableSetParts_2 = ((ComponentSystemBase)componentSystem).GetBufferFromEntity<CTableSetParts>(false);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery Players;

		private EntityQuery SPopUps;

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SQueueMarker_12;

		protected override void Initialise()
		{
			base.Initialise();
			Players = GetEntityQuery(typeof(CPlayer), typeof(CPosition));
			SPopUps = GetEntityQuery(typeof(RestartDayPopup.SPopup));
			RequireForUpdate(GetEntityQuery(typeof(CCustomerGroup)));
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass3_0 displayClass = new _003C_003Ec__DisplayClass3_0
			{
				_003C_003E4__this = this
			};
			if (!Has<SCheatNoPatienceDecrease>() && SPopUps.IsEmpty)
			{
				displayClass.ecb = GetCommandBuffer(ECB.End);
				displayClass.dt = base.Time.DeltaTime;
				int player_count = Players.CalculateEntityCount();
				displayClass.player_factor = DifficultyHelpers.PatiencePlayerCountModifier(player_count);
				displayClass.player_positions = Players.ToComponentDataArray<CPosition>(Allocator.TempJob);
				displayClass.lose_patience_in_room = HasStatus(RestaurantStatus.CustomersLosePatienceInRoom);
				displayClass.has_queue = false;
				if (HasSingleton<SQueueMarker>())
				{
					displayClass.has_queue = GetBuffer<CQueue>(_SingletonEntityQuery_SQueueMarker_12.GetSingletonEntity()).Length > 0;
				}
				displayClass.default_archetype = DefaultArchetype;
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
				displayClass.player_positions.Dispose();
			}
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EOnUpdate_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(this);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem;
			_003C_003EOnUpdate_LambdaJob0_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob0");
			_SingletonEntityQuery_SQueueMarker_12 = GetEntityQuery(ComponentType.ReadOnly<SQueueMarker>());
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
			entityQueryDesc.All = new ComponentType[5]
			{
				ComponentType.ReadOnly<CCustomerGroup>(),
				ComponentType.ReadWrite<CPatience>(),
				ComponentType.ReadOnly<CGroupMember>(),
				ComponentType.ReadOnly<CCustomerSettings>(),
				ComponentType.ReadOnly<CPosition>()
			};
			entityQueryDesc.None = new ComponentType[2]
			{
				ComponentType.ReadWrite<CGroupLeaving>(),
				ComponentType.ReadWrite<CGroupStartLeaving>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
