#define PUG_ACHIEVEMENTS
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.NetCode;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class AchievementSystem : PugSimulationSystemBase
{
	public struct AchievementRpc : IRpcCommand, IComponentData, IQueryTypeParameter
	{
		public AchievementID AchievementID;

		public Entity playerEntity;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_671493708_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public AchievementRpc Get(int index)
			{
				return InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<AchievementRpc>(item1_IntPtr, index);
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<AchievementRpc> item1_ComponentTypeHandle_RO;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<AchievementRpc>(isReadOnly: true);
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO)
				};
			}
		}

		public struct Enumerator : IEnumerator<AchievementRpc>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public AchievementRpc Current => _resolvedChunk.Get(_currentEntityIndex);

			object IEnumerator.Current
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			public Enumerator(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
			{
				if (!entityQuery.IsEmptyIgnoreFilter)
				{
					CompleteDependencies(ref state);
					typeHandle.Update(ref state);
				}
				_entityQueryEnumerator = new InternalEntityQueryEnumerator(entityQuery);
				_currentEntityIndex = -1;
				_endEntityIndex = -1;
				_typeHandle = typeHandle;
				_resolvedChunk = default(ResolvedChunk);
			}

			public void Dispose()
			{
				_entityQueryEnumerator.Dispose();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool MoveNext()
			{
				_currentEntityIndex++;
				if (_currentEntityIndex >= _endEntityIndex)
				{
					if (_entityQueryEnumerator.MoveNextEntityRange(out var movedToNewChunk, out var chunk, out var entityStartIndex, out var entityEndIndex))
					{
						if (movedToNewChunk)
						{
							_resolvedChunk = _typeHandle.Resolve(chunk);
						}
						_currentEntityIndex = entityStartIndex;
						_endEntityIndex = entityEndIndex;
						return true;
					}
					return false;
				}
				return true;
			}

			public Enumerator GetEnumerator()
			{
				return this;
			}

			public void Reset()
			{
				throw new NotImplementedException();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Enumerator Query(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
		{
			return new Enumerator(entityQuery, typeHandle, ref state);
		}

		public static void CompleteDependencies(ref SystemState state)
		{
			state.EntityManager.CompleteDependencyBeforeRO<AchievementRpc>();
		}
	}

	private struct TypeHandle
	{
		public IFE_671493708_0.TypeHandle __IFE_671493708_0_TypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_671493708_0_TypeHandle = new IFE_671493708_0.TypeHandle(ref state);
		}
	}

	private NativeQueue<AchievementRpc> rpcQueue;

	private EntityArchetype rpcArchetype;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_671493708_0;

	private EntityQuery __query_671493708_1;

	private EntityQuery __query_671493708_2;

	private EntityQuery __query_671493708_3;

	public static EntityArchetype GetRpcArchetype(EntityManager entityManager)
	{
		return entityManager.CreateArchetype(typeof(AchievementRpc), typeof(SendRpcCommandRequest));
	}

	[Preserve]
	protected override void OnCreate()
	{
		UpdatesInRunGroup();
		rpcQueue = new NativeQueue<AchievementRpc>(Allocator.Persistent);
		rpcArchetype = base.EntityManager.CreateArchetype(typeof(AchievementRpc), typeof(SendRpcCommandRequest));
		RequireForUpdate<AchievementTrackerCD>();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnDestroy()
	{
		rpcQueue.Dispose();
		base.OnDestroy();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);
		AchievementRpc item;
		while (rpcQueue.TryDequeue(out item))
		{
			Entity e = entityCommandBuffer.CreateEntity(rpcArchetype);
			entityCommandBuffer.SetComponent(e, item);
		}
		foreach (AchievementRpc item2 in IFE_671493708_0.Query(__query_671493708_0, __TypeHandle.__IFE_671493708_0_TypeHandle, ref base.CheckedStateRef))
		{
			Manager.achievements.TriggerAchievement(item2.AchievementID, item2.playerEntity);
		}
		base.EntityManager.DestroyEntity(__query_671493708_1);
		AchievementTrackerCD singleton = __query_671493708_2.GetSingleton<AchievementTrackerCD>();
		if (!singleton.hasTriggeredCherryBlossomAchievement && singleton.cherryBlossomAchievement)
		{
			Manager.achievements.TriggerAchievement(AchievementID.CherryBlossomTrees);
			singleton.hasTriggeredCherryBlossomAchievement = true;
			__query_671493708_3.SetSingleton(singleton);
		}
		entityCommandBuffer.Playback(base.EntityManager);
		entityCommandBuffer.Dispose();
		base.OnUpdate();
	}

	public static void TriggerAchievementForEveryone(EntityCommandBuffer ecb, EntityArchetype rpcArchetype, AchievementID achievementID)
	{
		TriggerAchievement(isServer: true, ecb, rpcArchetype, achievementID, Entity.Null);
	}

	public static void TriggerAchievement(bool isServer, EntityCommandBuffer ecb, EntityArchetype rpcArchetype, AchievementID achievementID, Entity playerEntity)
	{
		if (isServer)
		{
			AchievementRpc component = CreateRpc(achievementID, playerEntity);
			Entity e = ecb.CreateEntity(rpcArchetype);
			ecb.SetComponent(e, component);
		}
	}

	public static void TriggerAchievement(EntityCommandBuffer.ParallelWriter ecb, int sortKey, EntityArchetype rpcArchetype, AchievementID achievementID)
	{
		AchievementRpc component = CreateRpc(achievementID, Entity.Null);
		Entity e = ecb.CreateEntity(sortKey, rpcArchetype);
		ecb.SetComponent(sortKey, e, component);
	}

	private static AchievementRpc CreateRpc(AchievementID achievementID, Entity playerEntity)
	{
		return new AchievementRpc
		{
			AchievementID = achievementID,
			playerEntity = playerEntity
		};
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ReceiveRpcCommandRequest>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<AchievementRpc>();
		__query_671493708_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<AchievementRpc, ReceiveRpcCommandRequest>();
		__query_671493708_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<AchievementTrackerCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_671493708_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<AchievementTrackerCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_671493708_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	protected override void OnCreateForCompiler()
	{
		base.OnCreateForCompiler();
		__AssignQueries(ref base.CheckedStateRef);
		__TypeHandle.__AssignHandles(ref base.CheckedStateRef);
	}

	[Preserve]
	public AchievementSystem()
	{
	}
}
