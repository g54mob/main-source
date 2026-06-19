using System.Collections.Generic;
using PlayerEquipment;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;
using Unity.Profiling;
using UnityEngine;

public class PhysicsManager : ManagerBase
{
	private Dictionary<float3x2, BlobAssetReference<Unity.Physics.Collider>> sphereColliderCache;

	private Dictionary<float3x3, BlobAssetReference<Unity.Physics.Collider>> boxColliderCache;

	private readonly UnityEngine.RaycastHit[] _cachedRaycastHitArray = new UnityEngine.RaycastHit[64];

	private static readonly ProfilerMarker InitMarker = new ProfilerMarker("PhysicsManager.Init");

	[ClearOnReload]
	private static ComponentType[] _physicsWorldSingletonTypes;

	public override bool Init()
	{
		using (InitMarker.Auto())
		{
			sphereColliderCache = new Dictionary<float3x2, BlobAssetReference<Unity.Physics.Collider>>();
			boxColliderCache = new Dictionary<float3x3, BlobAssetReference<Unity.Physics.Collider>>();
			return true;
		}
	}

	public void InitWorld(World world)
	{
		using EntityQuery entityQuery = world.EntityManager.CreateEntityQuery(typeof(PhysicsStep));
		world.EntityManager.DestroyEntity(entityQuery);
		Entity entity = world.EntityManager.CreateEntity(typeof(PhysicsStep));
		PhysicsStep componentData = PhysicsStep.Default;
		componentData.Gravity = float3.zero;
		componentData.MultiThreaded = 0;
		int simulationTickRate = PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate;
		world.GetExistingSystemManaged<FixedStepSimulationSystemGroup>().Timestep = 1f / (float)simulationTickRate;
		world.GetExistingSystemManaged<PredictedFixedStepSimulationSystemGroup>().Timestep = 1f / (float)simulationTickRate;
		componentData.SolverIterationCount = 4;
		world.EntityManager.SetComponentData(entity, componentData);
	}

	private void Update()
	{
		if (Time.timeScale == 0f)
		{
			Physics.SyncTransforms();
		}
	}

	public int RaycastNonAlloc(Vector3 origin, Vector3 direction, float distance, bool includeTriggers, int objectLayerMask, out UnityEngine.RaycastHit[] hits)
	{
		bool queriesHitTriggers = Physics.queriesHitTriggers;
		Physics.queriesHitTriggers = includeTriggers;
		UnityEngine.Ray ray = new UnityEngine.Ray(origin, direction);
		hits = _cachedRaycastHitArray;
		int result = Physics.RaycastNonAlloc(ray, hits, distance, objectLayerMask);
		Physics.queriesHitTriggers = queriesHitTriggers;
		return result;
	}

	public static int OverlapBoxNonAlloc(Vector3 origin, Vector3 halfExtents, bool includeTriggers = true, List<int> objectLayerIds = null)
	{
		bool queriesHitTriggers = Physics.queriesHitTriggers;
		Physics.queriesHitTriggers = includeTriggers;
		UnityEngine.Collider[] preallocatedColliderArray = Manager.memory.preallocatedColliderArray;
		int result;
		if (objectLayerIds != null)
		{
			int num = 0;
			foreach (int objectLayerId in objectLayerIds)
			{
				num |= 1 << objectLayerId;
			}
			result = Physics.OverlapBoxNonAlloc(origin, halfExtents, preallocatedColliderArray, Quaternion.identity, num);
		}
		else
		{
			result = Physics.OverlapBoxNonAlloc(origin, halfExtents, preallocatedColliderArray);
		}
		Physics.queriesHitTriggers = queriesHitTriggers;
		return result;
	}

	public static int OverlapSphereNonAlloc(Vector3 origin, float radius, bool includeTriggers = true, List<int> objectLayerIds = null)
	{
		bool queriesHitTriggers = Physics.queriesHitTriggers;
		Physics.queriesHitTriggers = includeTriggers;
		UnityEngine.Collider[] preallocatedColliderArray = Manager.memory.preallocatedColliderArray;
		int result;
		if (objectLayerIds != null)
		{
			int num = 0;
			foreach (int objectLayerId in objectLayerIds)
			{
				num |= 1 << objectLayerId;
			}
			result = Physics.OverlapSphereNonAlloc(origin, radius, preallocatedColliderArray, num);
		}
		else
		{
			result = Physics.OverlapSphereNonAlloc(origin, radius, preallocatedColliderArray);
		}
		Physics.queriesHitTriggers = queriesHitTriggers;
		return result;
	}

	public static bool IsSphereBlocked(float3 from, float3 to, float radius, uint layerMaskCollidesWith, in ColliderCacheCD colliderCacheCD, CollisionWorld collisionWorld)
	{
		return collisionWorld.CastCollider(GetColliderCastInput(from, to, GetSphereCollider(float3.zero, radius, layerMaskCollidesWith, colliderCacheCD)));
	}

	public static PhysicsCollider GetSphereCollider(float3 position, float radius, uint layerMaskCollidesWith, ColliderCacheCD colliderCache)
	{
		float3x2 key = new float3x2(position, new float3(radius, layerMaskCollidesWith, 0f));
		if (!colliderCache.sphereColliderCache.ContainsKey(key))
		{
			BlobAssetReference<Unity.Physics.Collider> item = Unity.Physics.SphereCollider.Create(new SphereGeometry
			{
				Center = position,
				Radius = radius
			}, GetCollisionFilter(uint.MaxValue, layerMaskCollidesWith));
			colliderCache.sphereColliderCache.Add(key, item);
		}
		return new PhysicsCollider
		{
			Value = colliderCache.sphereColliderCache[key]
		};
	}

	public static PhysicsCollider GetBoxCollider(float3 position, float3 size, uint layerMaskCollidesWith, ColliderCacheCD colliderCache)
	{
		float3x3 key = new float3x3(position, size, new float3(layerMaskCollidesWith, 0f, 0f));
		if (!colliderCache.boxColliderCache.ContainsKey(key))
		{
			BlobAssetReference<Unity.Physics.Collider> item = Unity.Physics.BoxCollider.Create(new BoxGeometry
			{
				Center = position,
				Orientation = quaternion.identity,
				Size = size,
				BevelRadius = 0f
			}, GetCollisionFilter(uint.MaxValue, layerMaskCollidesWith));
			colliderCache.boxColliderCache.Add(key, item);
		}
		return new PhysicsCollider
		{
			Value = colliderCache.boxColliderCache[key]
		};
	}

	public static CollisionWorld GetCollisionWorld()
	{
		if (_physicsWorldSingletonTypes == null)
		{
			_physicsWorldSingletonTypes = new ComponentType[1] { typeof(PhysicsWorldSingleton) };
		}
		return Manager.ecs.GetClientEntityQuery(_physicsWorldSingletonTypes).GetSingleton<PhysicsWorldSingleton>().PhysicsWorld.CollisionWorld;
	}

	public static CollisionFilter GetCollisionFilter(uint layerMaskBelongTo, uint layerMaskCollidesWith)
	{
		return new CollisionFilter
		{
			BelongsTo = layerMaskBelongTo,
			CollidesWith = layerMaskCollidesWith,
			GroupIndex = 0
		};
	}

	public static RaycastInput GetRaycastInput(float3 frompos, float3 topos, uint layerMaskBelongTo, uint layerMaskCollidesWith)
	{
		return new RaycastInput
		{
			Start = frompos,
			End = topos,
			Filter = new CollisionFilter
			{
				BelongsTo = layerMaskBelongTo,
				CollidesWith = layerMaskCollidesWith,
				GroupIndex = 0
			}
		};
	}

	public unsafe static ColliderCastInput GetColliderCastInput(float3 fromPos, float3 toPos, PhysicsCollider collider)
	{
		return new ColliderCastInput
		{
			Collider = collider.ColliderPtr,
			Start = fromPos,
			End = toPos
		};
	}
}
