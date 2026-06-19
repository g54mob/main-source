using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EnvironmentEvents.Components;
using Pug.UnityExtensions;
using PugTilemap;
using QFSW.QC;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Scripting;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup))]
public struct EnvironmentEventSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	public struct ComponentLookups
	{
		public ComponentLookup<LocalTransform> localTransforms;

		public ComponentLookup<MortarProjectileCD> mortarProjectiles;

		public ComponentLookup<HealthCD> healths;

		public ComponentLookup<MortarProjectileDamageEffectCD> mortarProjectileDamageEffectLookup;

		[ReadOnly]
		public ComponentLookup<TileCD> tileLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> summarizedConditionsBufferLookup;

		[ReadOnly]
		public ComponentLookup<EntityPartCD> entityPartLookup;

		[ReadOnly]
		public ComponentLookup<BossCD> bossLookup;

		public static ComponentLookups Create(ref SystemState state)
		{
			return new ComponentLookups
			{
				localTransforms = state.GetComponentLookup<LocalTransform>(),
				mortarProjectiles = state.GetComponentLookup<MortarProjectileCD>(),
				healths = state.GetComponentLookup<HealthCD>(),
				mortarProjectileDamageEffectLookup = state.GetComponentLookup<MortarProjectileDamageEffectCD>(),
				tileLookup = state.GetComponentLookup<TileCD>(isReadOnly: true),
				summarizedConditionsBufferLookup = state.GetBufferLookup<SummarizedConditionsBuffer>(isReadOnly: true),
				entityPartLookup = state.GetComponentLookup<EntityPartCD>(isReadOnly: true),
				bossLookup = state.GetComponentLookup<BossCD>(isReadOnly: true)
			};
		}

		public void Update(ref SystemState state)
		{
			localTransforms.Update(ref state);
			mortarProjectiles.Update(ref state);
			healths.Update(ref state);
			mortarProjectileDamageEffectLookup.Update(ref state);
			tileLookup.Update(ref state);
			summarizedConditionsBufferLookup.Update(ref state);
			entityPartLookup.Update(ref state);
			bossLookup.Update(ref state);
		}
	}

	public struct SharedData
	{
		public TileAccessor tileAccessor;

		[ReadOnly]
		public BiomeLookup biomeLookup;

		[ReadOnly]
		public CollisionWorld collisionWorld;

		public ConditionsTableCD conditionsTableCD;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public EntityCommandBuffer ecb;

		public NetworkTick currentTick;

		public Entity tileDamageBufferEntity;

		public Entity effectEventBufferEntity;

		public uint tickRate;

		public float deltaTime;
	}

	public struct EnvironmentEvent
	{
		public EnvironmentEventType eventType;

		public Entity playerEntity;

		public int2 eventPosition;

		public int updateCounter;

		public int int1;

		public TickTimer updateTimer;

		public TickTimer afkTimer;

		public float3 playerStartPos;

		[MarshalAs(UnmanagedType.U1)]
		public bool checkingIfPlayerIsAfk;
	}

	public struct EnvironmentEventRequirement
	{
		public float minSqDistanceFromCore;

		public int maxAmountOfNearbyObjects;

		public int minTotalTilesFulfillingRequirements;

		public UnsafeList<EnvironmentEventTileRequirement> tileRequirements;

		public UnsafeList<Biome> biomes;

		public bool ignoreGlobalEventCooldown;

		public float2 minMaxEventSpecificCooldown;

		public bool allowSpawningNearBosses;
	}

	public struct EnvironmentEventTileRequirement
	{
		public int minAmountOfTiles;

		public TileType tileType;

		public UnsafeList<Tileset> tilesets;
	}

	public struct EnvironmentEventStateCD : IComponentData, IQueryTypeParameter
	{
		public EnvironmentEvent activeEvent;

		public TickTimer globalCheckForNewEventCooldown;

		public TickTimer globalCooldownTimer;

		public Unity.Mathematics.Random rnd;
	}

	public struct EnvironmentEventStateContainers
	{
		public NativeList<int2> eventPositions;

		public NativeParallelHashSet<int2> spawnPositions;

		public NativeHashMap<int, EnvironmentEventFunctions> events;

		public NativeParallelHashMap<int, EnvironmentEventRequirement> eventRequirements;

		public NativeParallelHashMap<int, float> eventCooldowns;
	}

	[BurstCompile]
	private struct EnvironmentEventJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				public ComponentTypeHandle<EnvironmentEventStateCD> __EnvironmentEventSystem_EnvironmentEventStateCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__EnvironmentEventSystem_EnvironmentEventStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<EnvironmentEventStateCD>();
				}

				public void Update(ref SystemState state)
				{
					__EnvironmentEventSystem_EnvironmentEventStateCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				DefaultQuery = entityQueryBuilder.WithAllRW<EnvironmentEventStateCD>().Build(ref state);
				entityQueryBuilder.Reset();
				entityQueryBuilder.Dispose();
			}

			public void Init(ref SystemState state, bool assignDefaultQuery)
			{
				if (assignDefaultQuery)
				{
					__AssignQueries(ref state);
				}
				__TypeHandle.__AssignHandles(ref state);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Run(ref EnvironmentEventJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref EnvironmentEventJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref EnvironmentEventJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref EnvironmentEventJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref EnvironmentEventJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref EnvironmentEventJob job, EntityManager entityManager)
			{
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct InternalCompiler
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			public static void CheckForErrors(int scheduleType)
			{
			}
		}

		public ComponentLookups componentLookups;

		public SharedData sharedData;

		public EnvironmentEventStateContainers stateContainers;

		[ReadOnly]
		public NativeList<Entity> playerList;

		[ReadOnly]
		public NativeList<EnvironmentEventTriggerCD> environmentEventTriggerList;

		public NativeArray<EnvironmentEventType> allEventTypes;

		public NativeList<DistanceHit> cachedDistanceHits;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public void Execute(ref EnvironmentEventStateCD environmentEventStateCD)
		{
			ref EnvironmentEvent activeEvent = ref environmentEventStateCD.activeEvent;
			ref NativeList<int2> eventPositions = ref stateContainers.eventPositions;
			ref NativeParallelHashSet<int2> spawnPositions = ref stateContainers.spawnPositions;
			ref NativeHashMap<int, EnvironmentEventFunctions> events = ref stateContainers.events;
			ref NativeParallelHashMap<int, EnvironmentEventRequirement> eventRequirements = ref stateContainers.eventRequirements;
			ref TickTimer globalCheckForNewEventCooldown = ref environmentEventStateCD.globalCheckForNewEventCooldown;
			ref TickTimer globalCooldownTimer = ref environmentEventStateCD.globalCooldownTimer;
			ref NativeParallelHashMap<int, float> eventCooldowns = ref stateContainers.eventCooldowns;
			ref Unity.Mathematics.Random rnd = ref environmentEventStateCD.rnd;
			if (DebugTriggerData.debugTriggerData.Data.resetEventCooldowns)
			{
				globalCooldownTimer.Stop(sharedData.currentTick);
				globalCheckForNewEventCooldown.Stop(sharedData.currentTick);
				eventCooldowns.Clear();
				DebugTriggerData.debugTriggerData.Data.resetEventCooldowns = false;
			}
			if (DebugTriggerData.debugTriggerData.Data.attemptToTriggerEventNow != EnvironmentEventType.None)
			{
				activeEvent.eventType = EnvironmentEventType.None;
				if (eventCooldowns.ContainsKey((int)DebugTriggerData.debugTriggerData.Data.attemptToTriggerEventNow))
				{
					eventCooldowns.Remove((int)DebugTriggerData.debugTriggerData.Data.attemptToTriggerEventNow);
				}
				globalCheckForNewEventCooldown.Stop(sharedData.currentTick);
				globalCooldownTimer.Stop(sharedData.currentTick);
			}
			bool flag = activeEvent.eventType != EnvironmentEventType.None && (!activeEvent.updateTimer.isRunning || activeEvent.updateTimer.IsTimerElapsed(sharedData.currentTick));
			if (flag && (!componentLookups.localTransforms.TryGetComponent(activeEvent.playerEntity, out var componentData) || math.distancesq(componentData.Position.RoundToInt2(), activeEvent.eventPosition) > 2500f))
			{
				activeEvent.eventType = EnvironmentEventType.None;
				flag = false;
			}
			foreach (KeyValue<int, float> item in eventCooldowns)
			{
				if (item.Key == (int)DebugTriggerData.debugTriggerData.Data.attemptToTriggerEventNow)
				{
					item.Value = 0f;
				}
				else if (item.Value > 0f)
				{
					item.Value -= sharedData.deltaTime;
				}
			}
			bool flag2 = environmentEventTriggerList.Length > 0;
			bool hasStarted = globalCheckForNewEventCooldown.HasStarted;
			bool flag3 = hasStarted && (!globalCheckForNewEventCooldown.isRunning || globalCheckForNewEventCooldown.IsTimerElapsed(sharedData.currentTick));
			if (flag3 || !hasStarted)
			{
				globalCheckForNewEventCooldown.Start(sharedData.currentTick, rnd.NextFloat(900f, 1800f), sharedData.tickRate);
			}
			else if (!flag2 && !flag)
			{
				return;
			}
			if (!playerList.IsEmpty)
			{
				if (activeEvent.eventType == EnvironmentEventType.None)
				{
					EvaluateEventToStart(ref activeEvent, spawnPositions, eventPositions, ref globalCooldownTimer, flag3, events, eventRequirements, eventCooldowns, ref rnd);
				}
				if (activeEvent.eventType != EnvironmentEventType.None)
				{
					ExecuteEvent(ref activeEvent, spawnPositions, eventPositions, events, ref rnd);
				}
				DebugTriggerData.debugTriggerData.Data.attemptToTriggerEventNow = EnvironmentEventType.None;
				DebugTriggerData.debugTriggerData.Data.bypassTriggerRequirements = false;
			}
		}

		private void CountTilesNearbyPlayer(NativeParallelHashMap<TileCD, int> cachedTileMap, int2 playerTilePos)
		{
			cachedTileMap.Clear();
			for (int num = playerTilePos.y + 5; num >= playerTilePos.y - 5; num--)
			{
				for (int num2 = playerTilePos.x + 5; num2 >= playerTilePos.x - 5; num2--)
				{
					int2 worldPosition = new int2(num2, num);
					TileCD top = sharedData.tileAccessor.GetTop(worldPosition);
					if (!cachedTileMap.ContainsKey(top))
					{
						cachedTileMap.Add(top, 1);
					}
					else
					{
						cachedTileMap[top]++;
					}
				}
			}
		}

		private void EvaluateEventToStart(ref EnvironmentEvent activeEvent, NativeParallelHashSet<int2> spawnPositions, NativeList<int2> eventPositions, ref TickTimer globalCooldownTimer, bool globalCooldownIsElapsed, NativeHashMap<int, EnvironmentEventFunctions> events, NativeParallelHashMap<int, EnvironmentEventRequirement> eventRequirements, NativeParallelHashMap<int, float> eventCooldowns, ref Unity.Mathematics.Random rnd)
		{
			NativeArray<int> playerIndicies = new NativeArray<int>(playerList.Length, Allocator.Temp);
			for (int i = 0; i < playerList.Length; i++)
			{
				playerIndicies[i] = i;
			}
			Shuffle(playerIndicies, ref rnd);
			Shuffle(allEventTypes, ref rnd);
			NativeParallelHashMap<TileCD, int> nativeParallelHashMap = new NativeParallelHashMap<TileCD, int>(32, Allocator.Temp);
			for (int j = 0; j < playerIndicies.Length; j++)
			{
				int index = playerIndicies[j];
				Entity playerEntity = playerList[index];
				int2 playerTilePos = componentLookups.localTransforms[playerEntity].Position.RoundToInt2();
				Biome biome = sharedData.biomeLookup.GetBiome(playerTilePos);
				CountTilesNearbyPlayer(nativeParallelHashMap, playerTilePos);
				for (int k = 0; k < allEventTypes.Length; k++)
				{
					EnvironmentEventType environmentEventType = allEventTypes[k];
					if ((DebugTriggerData.debugTriggerData.Data.attemptToTriggerEventNow == EnvironmentEventType.None || DebugTriggerData.debugTriggerData.Data.attemptToTriggerEventNow == environmentEventType) && (DebugTriggerData.debugTriggerData.Data.bypassTriggerRequirements || RequirementsAreFulfilled(environmentEventType, nativeParallelHashMap, playerEntity, playerTilePos, biome, globalCooldownIsElapsed, ref rnd, componentLookups, environmentEventTriggerList, events, eventRequirements, eventCooldowns)))
					{
						activeEvent.eventType = environmentEventType;
						activeEvent.eventPosition = playerTilePos;
						activeEvent.playerEntity = playerEntity;
						activeEvent.checkingIfPlayerIsAfk = DebugTriggerData.debugTriggerData.Data.attemptToTriggerEventNow == EnvironmentEventType.None;
						activeEvent.afkTimer.Stop(sharedData.currentTick);
						activeEvent.playerStartPos = componentLookups.localTransforms[playerEntity].Position;
						spawnPositions.Clear();
						eventPositions.Clear();
						events[(int)environmentEventType].initEvent.Invoke(in playerEntity, in playerTilePos, ref activeEvent, in eventPositions, ref rnd, (NativeArray<EnvironmentEventTriggerCD>)environmentEventTriggerList, in sharedData, in componentLookups);
						EnvironmentEventRequirement item;
						float2 eventSpecificMinMaxCooldown = (eventRequirements.TryGetValue((int)environmentEventType, out item) ? item.minMaxEventSpecificCooldown : new float2(1800f, 3600f));
						StartEventCooldown(environmentEventType, eventCooldowns, eventSpecificMinMaxCooldown, ref rnd);
						eventRequirements.TryGetValue((int)environmentEventType, out var item2);
						if (!item2.ignoreGlobalEventCooldown)
						{
							globalCooldownTimer.Start(sharedData.currentTick, rnd.NextFloat(900f, 1800f), sharedData.tickRate);
						}
						return;
					}
				}
			}
		}

		private void Shuffle(NativeArray<EnvironmentEventType> list, ref Unity.Mathematics.Random rand)
		{
			int num = list.Length;
			while (num > 1)
			{
				num--;
				int num2 = rand.NextInt(0, num + 1);
				int index = num2;
				int index2 = num;
				EnvironmentEventType environmentEventType = list[num];
				EnvironmentEventType environmentEventType2 = list[num2];
				EnvironmentEventType environmentEventType3 = (list[index] = environmentEventType);
				environmentEventType3 = (list[index2] = environmentEventType2);
			}
		}

		private void Shuffle(NativeArray<int> playerIndicies, ref Unity.Mathematics.Random rand)
		{
			int num = playerIndicies.Length;
			while (num > 1)
			{
				num--;
				int num2 = rand.NextInt(0, num + 1);
				int index = num2;
				int index2 = num;
				int num3 = playerIndicies[num];
				int num4 = playerIndicies[num2];
				int num5 = (playerIndicies[index] = num3);
				num5 = (playerIndicies[index2] = num4);
			}
		}

		private bool RequirementsAreFulfilled(EnvironmentEventType eventType, NativeParallelHashMap<TileCD, int> tileCount, Entity playerEntity, int2 playerTilePos, Biome playerBiome, bool globalCooldownIsElapsed, ref Unity.Mathematics.Random rnd, ComponentLookups c, NativeList<EnvironmentEventTriggerCD> environmentEventTriggerArray, NativeHashMap<int, EnvironmentEventFunctions> events, NativeParallelHashMap<int, EnvironmentEventRequirement> eventRequirements, NativeParallelHashMap<int, float> eventCooldowns)
		{
			if (!eventRequirements.TryGetValue((int)eventType, out var item))
			{
				return false;
			}
			if (!globalCooldownIsElapsed && !item.ignoreGlobalEventCooldown)
			{
				return false;
			}
			if (EventIsOnCooldown(eventType, eventCooldowns))
			{
				return false;
			}
			if (math.lengthsq(playerTilePos) < item.minSqDistanceFromCore)
			{
				return false;
			}
			if (!item.allowSpawningNearBosses)
			{
				CollisionFilter filter = new CollisionFilter
				{
					BelongsTo = uint.MaxValue,
					CollidesWith = 24u
				};
				cachedDistanceHits.Clear();
				if (sharedData.collisionWorld.OverlapSphere(new float3(playerTilePos.x, 0f, playerTilePos.y), 30f, ref cachedDistanceHits, filter))
				{
					for (int i = 0; i < cachedDistanceHits.Length; i++)
					{
						Entity entity = cachedDistanceHits[i].Entity;
						if (componentLookups.entityPartLookup.TryGetComponent(entity, out var componentData))
						{
							entity = componentData.mainEntity;
						}
						if (componentLookups.bossLookup.HasComponent(entity))
						{
							return false;
						}
					}
				}
			}
			bool flag = false;
			foreach (Biome biome in item.biomes)
			{
				flag = flag || biome == playerBiome;
			}
			if (!flag)
			{
				return false;
			}
			int num = 0;
			for (int j = 0; j < item.tileRequirements.Length; j++)
			{
				EnvironmentEventTileRequirement environmentEventTileRequirement = item.tileRequirements[j];
				int num2 = 0;
				for (int k = 0; k < environmentEventTileRequirement.tilesets.Length; k++)
				{
					Tileset tileset = environmentEventTileRequirement.tilesets[k];
					TileCD key = new TileCD
					{
						tileType = environmentEventTileRequirement.tileType,
						tileset = (int)tileset
					};
					if (tileCount.ContainsKey(key))
					{
						num2 += tileCount[key];
					}
				}
				if (num2 < environmentEventTileRequirement.minAmountOfTiles)
				{
					return false;
				}
				num += num2;
			}
			if (num < item.minTotalTilesFulfillingRequirements)
			{
				return false;
			}
			if (item.maxAmountOfNearbyObjects > 0)
			{
				CollisionFilter filter2 = new CollisionFilter
				{
					BelongsTo = uint.MaxValue,
					CollidesWith = 131905u
				};
				cachedDistanceHits.Clear();
				int num3 = 0;
				if (sharedData.collisionWorld.OverlapSphere(new float3(playerTilePos.x, 0f, playerTilePos.y), 5f, ref cachedDistanceHits, filter2))
				{
					for (int l = 0; l < cachedDistanceHits.Length; l++)
					{
						if (!componentLookups.tileLookup.HasComponent(cachedDistanceHits[l].Entity))
						{
							num3++;
						}
					}
					if (num3 >= item.maxAmountOfNearbyObjects)
					{
						return false;
					}
				}
			}
			return events[(int)eventType].shouldActivateEvent.Invoke(in playerEntity, in playerTilePos, ref rnd, in environmentEventTriggerArray, in c);
		}

		private bool EventIsOnCooldown(EnvironmentEventType eventType, NativeParallelHashMap<int, float> eventCooldowns)
		{
			if (eventCooldowns.ContainsKey((int)eventType))
			{
				return eventCooldowns[(int)eventType] > 0f;
			}
			return false;
		}

		private void StartEventCooldown(EnvironmentEventType eventType, NativeParallelHashMap<int, float> eventCooldowns, float2 eventSpecificMinMaxCooldown, ref Unity.Mathematics.Random rnd)
		{
			float num = rnd.NextFloat(eventSpecificMinMaxCooldown.x, eventSpecificMinMaxCooldown.y);
			if (!eventCooldowns.ContainsKey((int)eventType))
			{
				eventCooldowns.Add((int)eventType, num);
			}
			else
			{
				eventCooldowns[(int)eventType] = num;
			}
		}

		private void ExecuteEvent(ref EnvironmentEvent activeEvent, NativeParallelHashSet<int2> spawnPositions, NativeList<int2> eventPositions, NativeHashMap<int, EnvironmentEventFunctions> events, ref Unity.Mathematics.Random rnd)
		{
			if (activeEvent.checkingIfPlayerIsAfk)
			{
				if (!activeEvent.afkTimer.isRunning)
				{
					activeEvent.afkTimer.Start(sharedData.currentTick, 10f, sharedData.tickRate);
				}
				LocalTransform componentData;
				float3 float5 = (componentLookups.localTransforms.TryGetComponent(activeEvent.playerEntity, out componentData) ? componentData.Position : activeEvent.playerStartPos);
				if (math.any(activeEvent.playerStartPos != float5))
				{
					activeEvent.checkingIfPlayerIsAfk = false;
				}
				else if (activeEvent.afkTimer.IsTimerElapsed(sharedData.currentTick))
				{
					activeEvent.updateCounter = 0;
				}
			}
			else
			{
				events[(int)activeEvent.eventType].executeEvent.Invoke(ref activeEvent, in spawnPositions, in eventPositions, ref rnd, in sharedData, in componentLookups);
			}
			if (activeEvent.updateCounter <= 0)
			{
				activeEvent.eventType = EnvironmentEventType.None;
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__EnvironmentEventSystem_EnvironmentEventStateCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnvironmentEventStateCD>(nativeArrayPtr, i));
					num++;
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int nextRangeBegin = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out nextRangeBegin, out nextRangeEnd))
				{
					while (nextRangeBegin < nextRangeEnd)
					{
						Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnvironmentEventStateCD>(nativeArrayPtr, nextRangeBegin));
						nextRangeBegin++;
						num++;
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int j = 0; j < num3; j++)
			{
				if ((num2 & 1) != 0L)
				{
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnvironmentEventStateCD>(nativeArrayPtr, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnvironmentEventStateCD>(nativeArrayPtr, k));
					num++;
				}
				num2 >>= 1;
			}
		}

		private JobHandle __ThrowCodeGenException()
		{
			throw new Exception("This method should have been replaced by source gen.");
		}

		public void Run()
		{
			__ThrowCodeGenException();
		}

		public void RunByRef()
		{
			__ThrowCodeGenException();
		}

		public void Run(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void RunByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle Schedule(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public void Schedule()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef()
		{
			__ThrowCodeGenException();
		}

		public void Schedule(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public void ScheduleParallel()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallel(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct TypeHandle
	{
		public EnvironmentEventJob.InternalCompilerQueryAndHandleData __EnvironmentEventSystem_EnvironmentEventJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__EnvironmentEventSystem_EnvironmentEventJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_00000024_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00000024_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00000024_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__OnUpdate_0024BurstManaged(self, state);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnDestroy_00000025_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnDestroy_00000025_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_00000025_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__OnDestroy_0024BurstManaged(self, state);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnStartRunning_00000026_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_00000026_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_00000026_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__OnStartRunning_0024BurstManaged(self, state);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnStopRunning_00000027_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_00000027_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_00000027_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__OnStopRunning_0024BurstManaged(self, state);
		}
	}

	private const int HALF_DISTANCE_TO_CHECK_TILES = 5;

	private const float AFK_CHECK_TIME = 10f;

	private const float MIN_GLOBAL_COOLDOWN = 900f;

	private const float MAX_GLOBAL_COOLDOWN = 1800f;

	private const float MIN_EVENT_COOLDOWN = 1800f;

	private const float MAX_EVENT_COOLDOWN = 3600f;

	private const float BOSS_CHECK_DISTANCE = 30f;

	private BiomeLookup _biomeLookup;

	private TileAccessor _tileAccessor;

	private ComponentLookups _componentLookups;

	private NativeArray<EnvironmentEventType> _allEventTypes;

	private EnvironmentEventStateContainers _eventStateContainers;

	private EntityQuery _playerQuery;

	private EntityQuery _eventQuery;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_12325330_0;

	private EntityQuery __query_12325330_1;

	private EntityQuery __query_12325330_2;

	private EntityQuery __query_12325330_3;

	private EntityQuery __query_12325330_4;

	private EntityQuery __query_12325330_5;

	private EntityQuery __query_12325330_6;

	private EntityQuery __query_12325330_7;

	private EntityQuery __query_12325330_8;

	private EntityQuery __query_12325330_9;

	private EntityQuery __query_12325330_10;

	[Preserve]
	[Command("ResetEnvironmentEventCooldowns", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void ResetEnvironmentEventCooldowns()
	{
		Manager.main.player.playerCommandSystem.ResetEnvironmentEventCooldowns();
	}

	[Preserve]
	[Command("SetEnvironmentEventsEnabled", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void SetEnvironmentEventsEnabled(bool value)
	{
		Manager.main.player.playerCommandSystem.SetEnvironmentEventsEnabled(value);
	}

	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<TileDamageBuffer>();
		state.RequireForUpdate<PhysicsWorldSingleton>();
		state.RequireForUpdate<EffectEventBuffer>();
		state.RequireForUpdate<ConditionsTableCD>();
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate(__query_12325330_0);
		_componentLookups = ComponentLookups.Create(ref state);
		EnvironmentEventStateCD componentData = new EnvironmentEventStateCD
		{
			rnd = PugRandom.GetRng()
		};
		_eventStateContainers = default(EnvironmentEventStateContainers);
		_eventStateContainers.eventPositions = new NativeList<int2>(Allocator.Persistent);
		_eventStateContainers.spawnPositions = new NativeParallelHashSet<int2>(0, Allocator.Persistent);
		Array values = Enum.GetValues(typeof(EnvironmentEventType));
		_eventStateContainers.eventCooldowns = new NativeParallelHashMap<int, float>(values.Length, Allocator.Persistent);
		_allEventTypes = new NativeArray<EnvironmentEventType>(values.Length, Allocator.Persistent);
		foreach (EnvironmentEventType item2 in values)
		{
			_allEventTypes[(int)item2] = item2;
		}
		EnvironmentEventsTable environmentEventsTable = Resources.Load<EnvironmentEventsTable>("EnvironmentEventsTable");
		_eventStateContainers.eventRequirements = new NativeParallelHashMap<int, EnvironmentEventRequirement>(environmentEventsTable.eventRequirements.Count, Allocator.Persistent);
		foreach (EnvironmentEventParams eventRequirement in environmentEventsTable.eventRequirements)
		{
			EnvironmentEventRequirement item = new EnvironmentEventRequirement
			{
				minSqDistanceFromCore = eventRequirement.minDistanceFromCore * eventRequirement.minDistanceFromCore,
				maxAmountOfNearbyObjects = eventRequirement.maxAmountOfNearbyObjects,
				minTotalTilesFulfillingRequirements = eventRequirement.minTotalTilesFulfillingRequirements,
				biomes = new UnsafeList<Biome>(eventRequirement.biomes.Count, Allocator.Persistent),
				tileRequirements = new UnsafeList<EnvironmentEventTileRequirement>(eventRequirement.tileRequirements.Count, Allocator.Persistent),
				ignoreGlobalEventCooldown = eventRequirement.ignoreGlobalEventCooldown,
				minMaxEventSpecificCooldown = (eventRequirement.overrideEventSpecificCooldown ? eventRequirement.minMaxEventSpecificCooldownSeconds : new Vector2(1800f, 3600f)),
				allowSpawningNearBosses = eventRequirement.allowSpawningNearBosses
			};
			UnsafeList<Biome> biomes = item.biomes;
			foreach (Biome biome in eventRequirement.biomes)
			{
				biomes.Add(biome);
			}
			item.biomes = biomes;
			UnsafeList<EnvironmentEventTileRequirement> tileRequirements = item.tileRequirements;
			foreach (EnvironmentEventTilesRequirement tileRequirement in eventRequirement.tileRequirements)
			{
				EnvironmentEventTileRequirement value = new EnvironmentEventTileRequirement
				{
					minAmountOfTiles = tileRequirement.minimumAmountOfTiles,
					tileType = tileRequirement.tileType,
					tilesets = new UnsafeList<Tileset>(tileRequirement.tilesets.Count, Allocator.Persistent)
				};
				UnsafeList<Tileset> tilesets = value.tilesets;
				foreach (Tileset tileset in tileRequirement.tilesets)
				{
					tilesets.Add(tileset);
				}
				value.tilesets = tilesets;
				tileRequirements.Add(in value);
			}
			item.tileRequirements = tileRequirements;
			_eventStateContainers.eventRequirements.Add((int)eventRequirement.eventType, item);
		}
		_eventStateContainers.events = new NativeHashMap<int, EnvironmentEventFunctions>(5, Allocator.Persistent);
		_eventStateContainers.events.Add(1, new EnvironmentEventFunctions
		{
			shouldActivateEvent = BurstCompiler.CompileFunctionPointer<EnvironmentEventBase.ShouldActivateEvent>(EnvironmentEventSpawnLarvas.ShouldActivateEvent),
			initEvent = BurstCompiler.CompileFunctionPointer<EnvironmentEventBase.InitEvent>(EnvironmentEventSpawnLarvas.InitEvent),
			executeEvent = BurstCompiler.CompileFunctionPointer<EnvironmentEventBase.ExecuteEvent>(EnvironmentEventSpawnLarvas.ExecuteEvent)
		});
		_eventStateContainers.events.Add(2, new EnvironmentEventFunctions
		{
			shouldActivateEvent = BurstCompiler.CompileFunctionPointer<EnvironmentEventBase.ShouldActivateEvent>(EnvironmentEventSpawnBombScarabs.ShouldActivateEvent),
			initEvent = BurstCompiler.CompileFunctionPointer<EnvironmentEventBase.InitEvent>(EnvironmentEventSpawnBombScarabs.InitEvent),
			executeEvent = BurstCompiler.CompileFunctionPointer<EnvironmentEventBase.ExecuteEvent>(EnvironmentEventSpawnBombScarabs.ExecuteEvent)
		});
		_eventStateContainers.events.Add(3, new EnvironmentEventFunctions
		{
			shouldActivateEvent = BurstCompiler.CompileFunctionPointer<EnvironmentEventBase.ShouldActivateEvent>(EnvironmentEventSpawnOmorothTentacles.ShouldActivateEvent),
			initEvent = BurstCompiler.CompileFunctionPointer<EnvironmentEventBase.InitEvent>(EnvironmentEventSpawnOmorothTentacles.InitEvent),
			executeEvent = BurstCompiler.CompileFunctionPointer<EnvironmentEventBase.ExecuteEvent>(EnvironmentEventSpawnOmorothTentacles.ExecuteEvent)
		});
		_eventStateContainers.events.Add(4, new EnvironmentEventFunctions
		{
			shouldActivateEvent = BurstCompiler.CompileFunctionPointer<EnvironmentEventBase.ShouldActivateEvent>(EnvironmentEventBaseCaveIn.ShouldActivateEvent),
			initEvent = BurstCompiler.CompileFunctionPointer<EnvironmentEventBase.InitEvent>(EnvironmentEventBaseCaveIn.InitEvent),
			executeEvent = BurstCompiler.CompileFunctionPointer<EnvironmentEventBase.ExecuteEvent>(EnvironmentEventBaseCaveIn.ExecuteEvent)
		});
		Entity entity = state.EntityManager.CreateEntity();
		state.EntityManager.AddComponentData(entity, componentData);
		_playerQuery = state.EntityManager.CreateEntityQuery(ComponentType.ReadOnly<PlayerGhost>(), ComponentType.ReadOnly<LocalTransform>(), ComponentType.Exclude<DisablePhysicsCD>());
		_eventQuery = state.EntityManager.CreateEntityQuery(ComponentType.ReadOnly<EnvironmentEventTriggerCD>());
	}

	[BurstCompile]
	public void OnDestroy(ref SystemState state)
	{
		if (_allEventTypes.IsCreated)
		{
			_allEventTypes.Dispose();
		}
		if (_eventStateContainers.eventPositions.IsCreated)
		{
			_eventStateContainers.eventPositions.Dispose();
		}
		if (_eventStateContainers.spawnPositions.IsCreated)
		{
			_eventStateContainers.spawnPositions.Dispose();
		}
		if (_eventStateContainers.eventCooldowns.IsCreated)
		{
			_eventStateContainers.eventCooldowns.Dispose();
		}
		if (_eventStateContainers.eventRequirements.IsCreated)
		{
			using NativeArray<int> nativeArray = _eventStateContainers.eventRequirements.GetKeyArray(Allocator.Temp);
			foreach (int item in nativeArray)
			{
				_eventStateContainers.eventRequirements[item].biomes.Dispose();
				for (int i = 0; i < _eventStateContainers.eventRequirements[item].tileRequirements.Length; i++)
				{
					_eventStateContainers.eventRequirements[item].tileRequirements[i].tilesets.Dispose();
				}
				_eventStateContainers.eventRequirements[item].tileRequirements.Dispose();
			}
			_eventStateContainers.eventRequirements.Dispose();
		}
		if (_eventStateContainers.events.IsCreated)
		{
			_eventStateContainers.events.Dispose();
		}
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		_tileAccessor = new TileAccessor(ref state);
		_biomeLookup = (__query_12325330_1.TryGetSingleton<BiomeSamplesCD>(out var value) ? new BiomeLookup(value) : new BiomeLookup(__query_12325330_2.GetSingleton<BiomeRangesCD>().Value, Allocator.Persistent));
	}

	[BurstCompile]
	public void OnStopRunning(ref SystemState state)
	{
		_biomeLookup.Dispose();
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		if (!DebugTriggerData.debugTriggerData.Data.eventsDisabled)
		{
			_componentLookups.Update(ref state);
			_tileAccessor.Update(ref state);
			JobHandle outJobHandle;
			NativeList<Entity> playerList = _playerQuery.ToEntityListAsync(state.WorldUpdateAllocator, state.Dependency, out outJobHandle);
			EntityCommandBuffer ecb = __query_12325330_3.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
			ecb.DestroyEntity(_eventQuery, EntityQueryCaptureMode.AtRecord);
			JobHandle outJobHandle2;
			NativeList<EnvironmentEventTriggerCD> environmentEventTriggerList = _eventQuery.ToComponentDataListAsync<EnvironmentEventTriggerCD>(state.WorldUpdateAllocator, state.Dependency, out outJobHandle2);
			JobHandle dependency = JobHandle.CombineDependencies(outJobHandle, outJobHandle2, state.Dependency);
			__query_12325330_4.TryGetSingleton<NetworkTime>(out var value);
			__query_12325330_5.TryGetSingleton<ClientServerTickRate>(out var value2);
			state.Dependency = __ScheduleViaJobChunkExtension_0(new EnvironmentEventJob
			{
				componentLookups = _componentLookups,
				sharedData = new SharedData
				{
					tileAccessor = _tileAccessor,
					biomeLookup = _biomeLookup,
					collisionWorld = __query_12325330_6.GetSingleton<PhysicsWorldSingleton>().CollisionWorld,
					conditionsTableCD = __query_12325330_7.GetSingleton<ConditionsTableCD>(),
					databaseBankCD = __query_12325330_8.GetSingleton<PugDatabase.DatabaseBankCD>(),
					ecb = ecb,
					currentTick = value.ServerTick,
					tileDamageBufferEntity = __query_12325330_9.GetSingletonEntity(),
					effectEventBufferEntity = __query_12325330_10.GetSingletonEntity(),
					tickRate = (uint)value2.SimulationTickRate,
					deltaTime = state.WorldUnmanaged.Time.DeltaTime
				},
				stateContainers = _eventStateContainers,
				playerList = playerList,
				environmentEventTriggerList = environmentEventTriggerList,
				allEventTypes = _allEventTypes,
				cachedDistanceHits = new NativeList<DistanceHit>(32, state.WorldUpdateAllocator)
			}, __TypeHandle.__EnvironmentEventSystem_EnvironmentEventJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, dependency, ref state, hasUserDefinedQuery: false);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(EnvironmentEventJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__EnvironmentEventSystem_EnvironmentEventJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__EnvironmentEventSystem_EnvironmentEventJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__EnvironmentEventSystem_EnvironmentEventJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__EnvironmentEventSystem_EnvironmentEventJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAny<BiomeRangesCD, BiomeSamplesCD>();
		__query_12325330_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeSamplesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_12325330_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeRangesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_12325330_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_12325330_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_12325330_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_12325330_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_12325330_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ConditionsTableCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_12325330_7 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_12325330_8 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileDamageBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_12325330_9 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_12325330_10 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	public void OnCreateForCompiler(ref SystemState state)
	{
		__AssignQueries(ref state);
		__TypeHandle.__AssignHandles(ref state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
	{
		((EnvironmentEventSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00000024_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
	{
		__codegen__OnDestroy_00000025_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_00000026_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_00000027_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((EnvironmentEventSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((EnvironmentEventSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((EnvironmentEventSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((EnvironmentEventSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((EnvironmentEventSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}
