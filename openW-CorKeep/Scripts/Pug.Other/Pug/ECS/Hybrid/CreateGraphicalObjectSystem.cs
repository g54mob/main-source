using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.Scripting;

namespace Pug.ECS.Hybrid
{
	[BurstCompile]
	[UpdateInGroup(typeof(EndPresentationSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	public class CreateGraphicalObjectSystem : SystemBase
	{
		[BurstCompile]
		private struct SpawnJob : IJobChunk
		{
			public EntityTypeHandle EntityHandle;

			[ReadOnly]
			public ComponentTypeHandle<GraphicalObjectPrefabCD> PrefabHandle;

			[ReadOnly]
			public ComponentTypeHandle<GraphicalObjectPrefabEntityCD> PrimaryEntityHandle;

			[ReadOnly]
			public ComponentLookup<LocalTransform> TransformLookup;

			[ReadOnly]
			public ComponentLookup<EntityDestroyedCD> EntityDestroyedLookup;

			[ReadOnly]
			public ComponentLookup<ProjectileCD> ProjectileLookup;

			public NativeHashSet<Entity> frameDestroyedEntitiesSet;

			public NativeList<SpawnQueue> SpawnQueue;

			public float4 CameraBounds;

			public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				NativeArray<GraphicalObjectPrefabEntityCD> nativeArray = chunk.GetNativeArray(PrimaryEntityHandle);
				NativeArray<Entity> nativeArray2 = chunk.GetNativeArray(EntityHandle);
				NativeArray<GraphicalObjectPrefabCD> nativeArray3 = chunk.GetNativeArray(PrefabHandle);
				for (int i = 0; i < chunk.Count; i++)
				{
					if ((EntityDestroyedLookup.IsComponentEnabled(nativeArray[i].Value) || frameDestroyedEntitiesSet.Contains(nativeArray[i].Value)) && !ProjectileLookup.HasComponent(nativeArray[i].Value))
					{
						continue;
					}
					bool flag = false;
					foreach (SpawnQueue item in SpawnQueue)
					{
						if (item.Entity == nativeArray2[i])
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						float num = SqDistanceToCameraBounds(nativeArray[i].Value, TransformLookup, nativeArray3[i], CameraBounds);
						if (!(num > 4f))
						{
							byte order = (byte)math.min((int)math.ceil(num), 255);
							ref NativeList<SpawnQueue> spawnQueue = ref SpawnQueue;
							SpawnQueue value = new SpawnQueue
							{
								Entity = nativeArray2[i],
								Prefab = nativeArray3[i],
								SpawnedObject = new GraphicalObjectSpawnedCD
								{
									PrimaryEntity = nativeArray[i].Value
								},
								Order = order
							};
							spawnQueue.Add(in value);
						}
					}
				}
			}

			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		[BurstCompile]
		private struct DespawnJob : IJobChunk
		{
			public EntityTypeHandle EntityHandle;

			[ReadOnly]
			public ComponentTypeHandle<GraphicalObjectSpawnedCD> SpawnedHandle;

			[ReadOnly]
			public ComponentTypeHandle<GraphicalObjectPrefabCD> PrefabHandle;

			[ReadOnly]
			public ComponentLookup<LocalTransform> TransformLookup;

			public NativeList<DespawnQueue> DespawnQueue;

			public float4 CameraBounds;

			public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				NativeArray<Entity> nativeArray = chunk.GetNativeArray(EntityHandle);
				NativeArray<GraphicalObjectPrefabCD> nativeArray2 = chunk.GetNativeArray(PrefabHandle);
				NativeArray<GraphicalObjectSpawnedCD> nativeArray3 = chunk.GetNativeArray(SpawnedHandle);
				bool isCreated = nativeArray2.IsCreated;
				for (int i = 0; i < chunk.Count; i++)
				{
					if (nativeArray3[i].Index == -1)
					{
						continue;
					}
					byte order;
					if (isCreated)
					{
						float num = SqDistanceToCameraBounds(nativeArray3[i].PrimaryEntity, TransformLookup, nativeArray2[i], CameraBounds);
						if (num <= 16f)
						{
							continue;
						}
						order = (byte)math.max((int)math.floor(271f - num), 1);
					}
					else
					{
						order = 0;
					}
					DespawnQueue.Add(new DespawnQueue
					{
						Entity = nativeArray[i],
						SpawnedObject = nativeArray3[i],
						Order = order
					});
				}
			}

			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		private struct SpawnQueue
		{
			[StructLayout(LayoutKind.Sequential, Size = 1)]
			public struct OrderComparer : IComparer<SpawnQueue>
			{
				public int Compare(SpawnQueue x, SpawnQueue y)
				{
					return x.Order.CompareTo(y.Order);
				}
			}

			public Entity Entity;

			public GraphicalObjectPrefabCD Prefab;

			public GraphicalObjectSpawnedCD SpawnedObject;

			public byte Order;
		}

		private struct DespawnQueue
		{
			[StructLayout(LayoutKind.Sequential, Size = 1)]
			public struct SpawnedObjectIndexComparer : IComparer<DespawnQueue>
			{
				public int Compare(DespawnQueue x, DespawnQueue y)
				{
					return y.SpawnedObject.Index.CompareTo(x.SpawnedObject.Index);
				}
			}

			[StructLayout(LayoutKind.Sequential, Size = 1)]
			public struct OrderComparer : IComparer<DespawnQueue>
			{
				public int Compare(DespawnQueue x, DespawnQueue y)
				{
					return x.Order.CompareTo(y.Order);
				}
			}

			public Entity Entity;

			public GraphicalObjectSpawnedCD SpawnedObject;

			public byte Order;
		}

		private struct TypeHandle
		{
			[ReadOnly]
			public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<GraphicalObjectSpawnedCD> __Pug_ECS_Hybrid_GraphicalObjectSpawnedCD_RO_ComponentTypeHandle;

			[ReadOnly]
			public ComponentLookup<GraphicalObjectSpawnedCD> __Pug_ECS_Hybrid_GraphicalObjectSpawnedCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentTypeHandle<GraphicalObjectPrefabCD> __Pug_ECS_Hybrid_GraphicalObjectPrefabCD_RO_ComponentTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<GraphicalObjectPrefabEntityCD> __Pug_ECS_Hybrid_GraphicalObjectPrefabEntityCD_RO_ComponentTypeHandle;

			[ReadOnly]
			public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<GhostInstance> __Unity_NetCode_GhostInstance_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<ProjectileCD> __ProjectileCD_RO_ComponentLookup;

			public ComponentLookup<GraphicalObjectSpawnedCD> __Pug_ECS_Hybrid_GraphicalObjectSpawnedCD_RW_ComponentLookup;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
				__Pug_ECS_Hybrid_GraphicalObjectSpawnedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<GraphicalObjectSpawnedCD>(isReadOnly: true);
				__Pug_ECS_Hybrid_GraphicalObjectSpawnedCD_RO_ComponentLookup = state.GetComponentLookup<GraphicalObjectSpawnedCD>(isReadOnly: true);
				__Pug_ECS_Hybrid_GraphicalObjectPrefabCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<GraphicalObjectPrefabCD>(isReadOnly: true);
				__Pug_ECS_Hybrid_GraphicalObjectPrefabEntityCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<GraphicalObjectPrefabEntityCD>(isReadOnly: true);
				__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
				__Unity_NetCode_GhostInstance_RO_ComponentLookup = state.GetComponentLookup<GhostInstance>(isReadOnly: true);
				__EntityDestroyedCD_RO_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
				__ProjectileCD_RO_ComponentLookup = state.GetComponentLookup<ProjectileCD>(isReadOnly: true);
				__Pug_ECS_Hybrid_GraphicalObjectSpawnedCD_RW_ComponentLookup = state.GetComponentLookup<GraphicalObjectSpawnedCD>();
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void QueueSpawnAndDespawn_00007AB2_0024PostfixBurstDelegate(ref SpawnJob spawnJob, in EntityQuery spawnQuery, ref NativeList<SpawnQueue> spawnQueue, ref DespawnJob despawnJob, in EntityQuery despawnedQuery, ref NativeList<DespawnQueue> despawnQueue, in NativeList<Entity> entities, in NativeList<Entity> graphicalEntities, in NativeParallelHashMap<SpawnedGhost, Entity>.ReadOnly spawnedGhostMap, in ComponentLookup<GraphicalObjectSpawnedCD> spawnedLookup, in ComponentLookup<GhostInstance> ghostInstanceLookup);

		internal static class QueueSpawnAndDespawn_00007AB2_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<QueueSpawnAndDespawn_00007AB2_0024PostfixBurstDelegate>(QueueSpawnAndDespawn).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(ref SpawnJob spawnJob, in EntityQuery spawnQuery, ref NativeList<SpawnQueue> spawnQueue, ref DespawnJob despawnJob, in EntityQuery despawnedQuery, ref NativeList<DespawnQueue> despawnQueue, in NativeList<Entity> entities, in NativeList<Entity> graphicalEntities, in NativeParallelHashMap<SpawnedGhost, Entity>.ReadOnly spawnedGhostMap, in ComponentLookup<GraphicalObjectSpawnedCD> spawnedLookup, in ComponentLookup<GhostInstance> ghostInstanceLookup)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref SpawnJob, ref EntityQuery, ref NativeList<SpawnQueue>, ref DespawnJob, ref EntityQuery, ref NativeList<DespawnQueue>, ref NativeList<Entity>, ref NativeList<Entity>, ref NativeParallelHashMap<SpawnedGhost, Entity>.ReadOnly, ref ComponentLookup<GraphicalObjectSpawnedCD>, ref ComponentLookup<GhostInstance>, void>)functionPointer)(ref spawnJob, ref spawnQuery, ref spawnQueue, ref despawnJob, ref despawnedQuery, ref despawnQueue, ref entities, ref graphicalEntities, ref spawnedGhostMap, ref spawnedLookup, ref ghostInstanceLookup);
						return;
					}
				}
				QueueSpawnAndDespawn_0024BurstManaged(ref spawnJob, in spawnQuery, ref spawnQueue, ref despawnJob, in despawnedQuery, ref despawnQueue, in entities, in graphicalEntities, in spawnedGhostMap, in spawnedLookup, in ghostInstanceLookup);
			}
		}

		private const float SPAWN_SQ_THRESHOLD = 4f;

		private const float DESPAWN_SQ_THRESHOLD = 16f;

		private const int DESIRED_REQUESTS_PER_FRAME = 8;

		public Dictionary<GameObject, Entity> EntityLookup = new Dictionary<GameObject, Entity>();

		public Dictionary<Entity, GameObject> GameObjectLookup = new Dictionary<Entity, GameObject>();

		private UpdateGraphicalObjectTransformSystem _updateGraphicalObjectTransformSystem;

		private EntityQuery _spawnQuery;

		private EntityQuery _fullySpawnedQuery;

		private EntityQuery _despawnedQuery;

		private NativeList<SpawnQueue> _spawnQueue;

		private NativeList<DespawnQueue> _despawnQueue;

		private List<IGraphicalSpawn> _cachedSpawnComponentsList = new List<IGraphicalSpawn>();

		private List<IGraphicalDespawn> _cachedDepawnComponentsList = new List<IGraphicalDespawn>();

		public Dictionary<Entity, EntityMonoBehaviour> entityMonoBehaviourLookup = new Dictionary<Entity, EntityMonoBehaviour>(1024);

		public NativeHashSet<Entity> frameDestroyedEntitiesSet;

		internal List<IGraphicalObject[]> m_GraphicalObjects;

		internal List<GameObject> m_GameObjects;

		internal TransformAccessArray m_Transforms;

		internal NativeList<Entity> m_GraphicalEntities;

		internal NativeList<Entity> m_Entities;

		private float2 m_PrevCameraPos;

		private bool _isDestroyingSystem;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_809447924_0;

		private EntityQuery __query_809447924_1;

		[Preserve]
		protected override void OnCreate()
		{
			_updateGraphicalObjectTransformSystem = base.World.GetExistingSystemManaged<UpdateGraphicalObjectTransformSystem>();
			_spawnQuery = GetEntityQuery(ComponentType.ReadOnly<GraphicalObjectPrefabCD>(), ComponentType.ReadOnly<GraphicalObjectPrefabEntityCD>(), ComponentType.Exclude<GraphicalObjectSpawnedCD>());
			_despawnedQuery = GetEntityQuery(ComponentType.ReadOnly<GraphicalObjectSpawnedCD>());
			_spawnQueue = new NativeList<SpawnQueue>(Allocator.Persistent);
			_despawnQueue = new NativeList<DespawnQueue>(Allocator.Persistent);
			m_GraphicalObjects = new List<IGraphicalObject[]>();
			m_GameObjects = new List<GameObject>();
			m_Transforms = new TransformAccessArray(16, 16);
			m_Entities = new NativeList<Entity>(16, Allocator.Persistent);
			m_GraphicalEntities = new NativeList<Entity>(16, Allocator.Persistent);
			frameDestroyedEntitiesSet = new NativeHashSet<Entity>(64, Allocator.Persistent);
			base.OnCreate();
		}

		[Preserve]
		protected override void OnDestroy()
		{
			_isDestroyingSystem = true;
			base.EntityManager.RemoveComponent<GraphicalObjectPrefabCD>(GetEntityQuery(typeof(GraphicalObjectPrefabCD)));
			OnUpdate();
			_spawnQueue.Dispose();
			_despawnQueue.Dispose();
			m_Transforms.Dispose();
			m_Entities.Dispose();
			m_GraphicalEntities.Dispose();
			frameDestroyedEntitiesSet.Dispose();
			base.OnDestroy();
		}

		[Preserve]
		protected override void OnUpdate()
		{
			EntityTypeHandle entityTypeHandle = InternalCompilerInterface.GetEntityTypeHandle(ref __TypeHandle.__Unity_Entities_Entity_TypeHandle, ref base.CheckedStateRef);
			ComponentTypeHandle<GraphicalObjectSpawnedCD> componentTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__Pug_ECS_Hybrid_GraphicalObjectSpawnedCD_RO_ComponentTypeHandle, ref base.CheckedStateRef);
			ComponentLookup<GraphicalObjectSpawnedCD> spawnedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_ECS_Hybrid_GraphicalObjectSpawnedCD_RO_ComponentLookup, ref base.CheckedStateRef);
			ComponentTypeHandle<GraphicalObjectPrefabCD> componentTypeHandle2 = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__Pug_ECS_Hybrid_GraphicalObjectPrefabCD_RO_ComponentTypeHandle, ref base.CheckedStateRef);
			ComponentTypeHandle<GraphicalObjectPrefabEntityCD> componentTypeHandle3 = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__Pug_ECS_Hybrid_GraphicalObjectPrefabEntityCD_RO_ComponentTypeHandle, ref base.CheckedStateRef);
			ComponentLookup<LocalTransform> componentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref base.CheckedStateRef);
			ComponentLookup<GhostInstance> ghostInstanceLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_NetCode_GhostInstance_RO_ComponentLookup, ref base.CheckedStateRef);
			ComponentLookup<EntityDestroyedCD> componentLookup2 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref base.CheckedStateRef);
			ComponentLookup<ProjectileCD> componentLookup3 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ProjectileCD_RO_ComponentLookup, ref base.CheckedStateRef);
			EntityCommandBuffer entityCommandBuffer;
			NativeParallelHashMap<SpawnedGhost, Entity>.ReadOnly spawnedGhostMap;
			if (_isDestroyingSystem)
			{
				entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);
				spawnedGhostMap = new NativeParallelHashMap<SpawnedGhost, Entity>(0, base.World.UpdateAllocator.ToAllocator).AsReadOnly();
			}
			else
			{
				entityCommandBuffer = __query_809447924_0.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(base.World.Unmanaged);
				spawnedGhostMap = __query_809447924_1.GetSingleton<SpawnedGhostEntityMap>().Value;
			}
			_updateGraphicalObjectTransformSystem.GetOutputDependency().Complete();
			base.Dependency.Complete();
			CameraManager camera = Manager.camera;
			float2 float5 = camera.GetCameraCurrentPosition().ToFloat2();
			Camera gameCamera = camera.gameCamera;
			float orthographicSize = gameCamera.orthographicSize;
			float2 float6 = new float2(orthographicSize * gameCamera.aspect, orthographicSize);
			float4 cameraBounds = new float4(float5 - float6, float5 + float6);
			float2 float7 = math.normalizesafe(float5 - m_PrevCameraPos);
			m_PrevCameraPos = float5;
			cameraBounds += new float4(-1f, -1f, 1f, 1f) + float7.xyxy;
			SpawnJob spawnJob = new SpawnJob
			{
				EntityHandle = entityTypeHandle,
				PrimaryEntityHandle = componentTypeHandle3,
				PrefabHandle = componentTypeHandle2,
				TransformLookup = componentLookup,
				EntityDestroyedLookup = componentLookup2,
				ProjectileLookup = componentLookup3,
				frameDestroyedEntitiesSet = frameDestroyedEntitiesSet,
				SpawnQueue = _spawnQueue,
				CameraBounds = cameraBounds
			};
			DespawnJob despawnJob = new DespawnJob
			{
				EntityHandle = entityTypeHandle,
				PrefabHandle = componentTypeHandle2,
				TransformLookup = componentLookup,
				SpawnedHandle = componentTypeHandle,
				DespawnQueue = _despawnQueue,
				CameraBounds = cameraBounds
			};
			QueueSpawnAndDespawn(ref spawnJob, in _spawnQuery, ref _spawnQueue, ref despawnJob, in _despawnedQuery, ref _despawnQueue, in m_Entities, in m_GraphicalEntities, in spawnedGhostMap, in spawnedLookup, in ghostInstanceLookup);
			foreach (DespawnQueue item in _despawnQueue)
			{
				GameObject gameObject = m_GameObjects[item.SpawnedObject.Index];
				int index = item.SpawnedObject.Index;
				m_Transforms.RemoveAtSwapBack(index);
				m_Entities.RemoveAtSwapBack(index);
				m_GraphicalEntities.RemoveAtSwapBack(index);
				m_GameObjects.RemoveAtSwapBack(index);
				m_GraphicalObjects.RemoveAtSwapBack(index);
				if (index != m_Entities.Length)
				{
					GraphicalObjectSpawnedCD componentAfterCompletingDependency = InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__Pug_ECS_Hybrid_GraphicalObjectSpawnedCD_RO_ComponentLookup, ref base.CheckedStateRef, m_Entities[index]);
					componentAfterCompletingDependency.Index = index;
					InternalCompilerInterface.SetComponentAfterCompletingDependency(ref __TypeHandle.__Pug_ECS_Hybrid_GraphicalObjectSpawnedCD_RW_ComponentLookup, ref base.CheckedStateRef, componentAfterCompletingDependency, m_Entities[index]);
				}
				if (base.EntityManager.HasComponent<InteractableObjectReferenceCD>(item.SpawnedObject.PrimaryEntity))
				{
					entityCommandBuffer.SetComponent(item.SpawnedObject.PrimaryEntity, default(InteractableObjectReferenceCD));
				}
				if (base.EntityManager.HasComponent<EntityMonoBehaviourCD>(item.SpawnedObject.PrimaryEntity))
				{
					entityCommandBuffer.SetComponent(item.SpawnedObject.PrimaryEntity, default(EntityMonoBehaviourCD));
				}
				entityCommandBuffer.RemoveComponent(item.Entity, typeof(GraphicalObjectSpawnedCD));
				entityMonoBehaviourLookup.Remove(item.SpawnedObject.PrimaryEntity);
				if ((object)gameObject == null)
				{
					continue;
				}
				Entity value;
				bool flag = EntityLookup.TryGetValue(gameObject, out value) && value == item.SpawnedObject.PrimaryEntity;
				if (flag)
				{
					EntityLookup.Remove(gameObject);
				}
				else
				{
					Debug.LogWarning($"Cannot remove {gameObject}, since it's mapped to another entity {value}.");
				}
				if (flag)
				{
					gameObject.GetComponents(_cachedDepawnComponentsList);
					foreach (IGraphicalDespawn cachedDepawnComponents in _cachedDepawnComponentsList)
					{
						cachedDepawnComponents.Despawn(item.SpawnedObject.PrimaryEntity, base.EntityManager);
					}
					_cachedDepawnComponentsList.Clear();
				}
				if ((item.SpawnedObject.Instantiated && flag) || Manager.mod.Client.HasObjectDepawnedOnClientSubscribers)
				{
					try
					{
						Manager.mod.Client.ObjectDespawnedOnClient(item.SpawnedObject.PrimaryEntity, base.EntityManager, flag ? gameObject : null);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
				if (flag && item.SpawnedObject.Instantiated && gameObject != null)
				{
					UnityEngine.Object.Destroy(gameObject);
				}
				GameObjectLookup.Remove(item.SpawnedObject.PrimaryEntity);
				if (item.Order == 0 && base.EntityManager.HasComponent<GraphicalObjectPrefabEntityCD>(item.Entity))
				{
					entityCommandBuffer.RemoveComponent<GraphicalObjectPrefabEntityCD>(item.Entity);
				}
			}
			foreach (SpawnQueue item2 in _spawnQueue)
			{
				SpawnQueue current2 = item2;
				IGraphicalObject[] array = null;
				GameObject gameObject2 = null;
				bool instantiated = false;
				int index2 = -1;
				Component value2 = current2.Prefab.PrefabComponent.Value;
				GameObject value3 = current2.Prefab.Prefab.Value;
				bool flag2 = value2 != null;
				if (flag2)
				{
					gameObject2 = Manager.memory.GetFreeComponent(value2.GetType(), deferOnOccupied: true, deferReparent: true)?.gameObject;
				}
				else if (value3 != null)
				{
					gameObject2 = UnityEngine.Object.Instantiate(value3);
					instantiated = true;
				}
				if (gameObject2 != null)
				{
					array = gameObject2.GetComponents<IGraphicalObject>();
					index2 = m_Entities.Length;
					m_Entities.Add(in current2.Entity);
					m_GraphicalEntities.Add(in current2.SpawnedObject.PrimaryEntity);
					m_Transforms.Add(gameObject2.transform);
					m_GameObjects.Add(gameObject2);
					m_GraphicalObjects.Add(array);
					if (flag2)
					{
						EntityMonoBehaviour component = gameObject2.GetComponent<EntityMonoBehaviour>();
						entityMonoBehaviourLookup.Add(current2.SpawnedObject.PrimaryEntity, component);
						if (component.interactable != null)
						{
							entityCommandBuffer.SetComponent(current2.SpawnedObject.PrimaryEntity, new InteractableObjectReferenceCD
							{
								Value = component.interactable
							});
						}
						entityCommandBuffer.SetComponent(current2.SpawnedObject.PrimaryEntity, new EntityMonoBehaviourCD
						{
							entityMonoBehaviour = component
						});
					}
					if (!GameObjectLookup.TryAdd(current2.SpawnedObject.PrimaryEntity, gameObject2))
					{
						string name = base.EntityManager.GetName(current2.SpawnedObject.PrimaryEntity);
						GameObject gameObject3 = GameObjectLookup[current2.SpawnedObject.PrimaryEntity];
						Debug.LogError($"Cannot tie entity {current2.SpawnedObject.PrimaryEntity} ({name}) to {gameObject2}. It is already tied to {gameObject3}.");
					}
					if (!EntityLookup.TryAdd(gameObject2, current2.SpawnedObject.PrimaryEntity))
					{
						Entity entity = EntityLookup[gameObject2];
						string name2 = base.EntityManager.GetName(current2.SpawnedObject.PrimaryEntity);
						string name3 = base.EntityManager.GetName(entity);
						Debug.LogWarning($"{gameObject2} is already mapped to entity {entity} ({name3}). Overwriting to {current2.SpawnedObject.PrimaryEntity} ({name2}).");
						EntityLookup[gameObject2] = current2.SpawnedObject.PrimaryEntity;
					}
				}
				entityCommandBuffer.AddComponent(current2.Entity, new GraphicalObjectSpawnedCD
				{
					Index = index2,
					Instantiated = instantiated,
					PrimaryEntity = current2.SpawnedObject.PrimaryEntity
				});
				if (gameObject2 == null)
				{
					continue;
				}
				gameObject2.GetComponents(_cachedSpawnComponentsList);
				foreach (IGraphicalSpawn cachedSpawnComponents in _cachedSpawnComponentsList)
				{
					cachedSpawnComponents.Spawn(current2.SpawnedObject.PrimaryEntity, base.EntityManager);
				}
				_cachedSpawnComponentsList.Clear();
				if (Manager.mod.Client.HasObjectSpawnedOnClientSubscribers)
				{
					try
					{
						Manager.mod.Client.ObjectSpawnedOnClient(current2.SpawnedObject.PrimaryEntity, base.EntityManager, gameObject2);
					}
					catch (Exception exception2)
					{
						Debug.LogException(exception2);
					}
				}
			}
			frameDestroyedEntitiesSet.Clear();
			if (_isDestroyingSystem)
			{
				entityCommandBuffer.Playback(base.EntityManager);
				entityCommandBuffer.Dispose();
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(Pug_002EECS_002EHybrid_002EQueueSpawnAndDespawn_00007AB2_0024PostfixBurstDelegate))]
		private static void QueueSpawnAndDespawn(ref SpawnJob spawnJob, in EntityQuery spawnQuery, ref NativeList<SpawnQueue> spawnQueue, ref DespawnJob despawnJob, in EntityQuery despawnedQuery, ref NativeList<DespawnQueue> despawnQueue, in NativeList<Entity> entities, in NativeList<Entity> graphicalEntities, in NativeParallelHashMap<SpawnedGhost, Entity>.ReadOnly spawnedGhostMap, in ComponentLookup<GraphicalObjectSpawnedCD> spawnedLookup, in ComponentLookup<GhostInstance> ghostInstanceLookup)
		{
			QueueSpawnAndDespawn_00007AB2_0024BurstDirectCall.Invoke(ref spawnJob, in spawnQuery, ref spawnQueue, ref despawnJob, in despawnedQuery, ref despawnQueue, in entities, in graphicalEntities, in spawnedGhostMap, in spawnedLookup, in ghostInstanceLookup);
		}

		private static float SqDistanceToCameraBounds(Entity primaryEntity, ComponentLookup<LocalTransform> transformLookup, GraphicalObjectPrefabCD prefab, float4 cameraBounds)
		{
			float2 obj = transformLookup.GetRefRO(primaryEntity).ValueRO.Position.ToFloat2();
			float4 float5 = cameraBounds - prefab.RenderBounds.zwxy;
			float2 y = math.clamp(obj, float5.xy, float5.zw);
			return math.distancesq(obj, y);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginInitializationEntityCommandBufferSystem.Singleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_809447924_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<SpawnedGhostEntityMap>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_809447924_1 = entityQueryBuilder2.Build(ref state);
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
		public CreateGraphicalObjectSystem()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void QueueSpawnAndDespawn_0024BurstManaged(ref SpawnJob spawnJob, in EntityQuery spawnQuery, ref NativeList<SpawnQueue> spawnQueue, ref DespawnJob despawnJob, in EntityQuery despawnedQuery, ref NativeList<DespawnQueue> despawnQueue, in NativeList<Entity> entities, in NativeList<Entity> graphicalEntities, in NativeParallelHashMap<SpawnedGhost, Entity>.ReadOnly spawnedGhostMap, in ComponentLookup<GraphicalObjectSpawnedCD> spawnedLookup, in ComponentLookup<GhostInstance> ghostInstanceLookup)
		{
			spawnQueue.Clear();
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobs(ref spawnJob, spawnQuery);
			despawnQueue.Clear();
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobs(ref despawnJob, despawnedQuery);
			int length = despawnQueue.Length;
			for (int i = 0; i < graphicalEntities.Length; i++)
			{
				if (ghostInstanceLookup.TryGetComponent(graphicalEntities[i], out var componentData) && (componentData.ghostId == 0 || spawnedGhostMap.ContainsKey(componentData)))
				{
					continue;
				}
				GraphicalObjectSpawnedCD valueRO = spawnedLookup.GetRefRO(entities[i]).ValueRO;
				if (valueRO.Index != -1)
				{
					int j;
					for (j = 0; j < length && despawnQueue[j].SpawnedObject.Index != valueRO.Index; j++)
					{
					}
					if (j == length)
					{
						DespawnQueue value = new DespawnQueue
						{
							Entity = entities[i],
							SpawnedObject = valueRO,
							Order = 0
						};
						despawnQueue.Add(in value);
					}
				}
			}
			despawnQueue.Sort(default(DespawnQueue.OrderComparer));
			int k;
			for (k = 0; k < despawnQueue.Length && despawnQueue[k].Order == 0; k++)
			{
			}
			spawnQueue.Sort(default(SpawnQueue.OrderComparer));
			int l;
			for (l = 0; l < spawnQueue.Length && spawnQueue[l].Order == 0; l++)
			{
			}
			int num = despawnQueue.Length - k;
			int num2 = spawnQueue.Length - l;
			int num3 = num + num2;
			if (num3 > 0)
			{
				int num4 = 8 - k - l;
				if (num4 > 0)
				{
					num = (int)math.round((float)num4 * (float)num / (float)num3);
					num2 = num4 - num;
					k += num;
					l += num2;
				}
				if (despawnQueue.Length > k)
				{
					despawnQueue.Length = k;
				}
				if (spawnQueue.Length > l)
				{
					spawnQueue.Length = l;
				}
			}
			despawnQueue.Sort(default(DespawnQueue.SpawnedObjectIndexComparer));
		}
	}
}
