using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class EntityUtil
{
	public static Entity Instantiate(GameObject prefab)
	{
		return Instantiate(prefab, GameUtil.GetCurrentContainer(), Vector3.zero, Quaternion.identity);
	}

	public static Entity Instantiate(GameObject prefab, Vector3 position)
	{
		return Instantiate(prefab, GameUtil.GetCurrentContainer(), position, Quaternion.identity);
	}

	public static Entity Instantiate(GameObject prefab, Vector3 position, Quaternion rotation)
	{
		return Instantiate(prefab, GameUtil.GetCurrentContainer(), position, rotation);
	}

	public static Entity Instantiate(GameObject prefab, Transform parent)
	{
		return Instantiate(prefab, parent, Vector3.zero, Quaternion.identity);
	}

	public static Entity Instantiate(GameObject prefab, Transform parent, Vector3 position)
	{
		return Instantiate(prefab, parent, position, Quaternion.identity);
	}

	public static Entity Instantiate(GameObject prefab, Transform parent, Vector3 position, Quaternion rotation)
	{
		Entity entity;
		if (prefab.HasPrefabPool())
		{
			entity = prefab.GetEntityFromPrefabPool().entity;
		}
		else
		{
			GameObject gameObject = Object.Instantiate(prefab, position, rotation);
			if (!gameObject.TryGetEntity(out entity))
			{
				Debug.LogError("EntityUtil.Instantiate can only be used to instantiate Entities!");
				Object.Destroy(gameObject);
				return Entity.invalid;
			}
		}
		entity.transform.SetParent(parent);
		entity.transform.position = position;
		entity.transform.rotation = rotation;
		if (entity.TryGetObject<Rigidbody>(out var obj))
		{
			obj.position = position;
			obj.rotation = rotation;
		}
		entity.AddStruct(new EntityContextComp
		{
			roomType = GameUtil.GetCurrentRoomType()
		});
		return entity;
	}

	public static void Destroy(Entity entity)
	{
		if (entity.HasStruct<MarkedForDeathComp>())
		{
			return;
		}
		if (NetworkServer.active && entity.TryGetObject<Grabbable>(out var obj))
		{
			obj.ServerBreakStackAtMe();
			if (NetworkAggroManagerBase<WarehouseManager>.ManagerExists())
			{
				NetworkAggroManagerBase<WarehouseManager>.instance.ServerBoxDestroyed(entity);
			}
		}
		entity.AddStruct<MarkedForDeathComp>();
		AggroManagerBase<DeathManager>.instance.QueueDeath(entity);
	}

	public static void SetContextForScene(Scene scene, RoomType roomType)
	{
		GameObject[] rootGameObjects = scene.GetRootGameObjects();
		for (int i = 0; i < rootGameObjects.Length; i++)
		{
			EntityBehaviour[] componentsInChildren = rootGameObjects[i].GetComponentsInChildren<EntityBehaviour>();
			foreach (EntityBehaviour entityBehaviour in componentsInChildren)
			{
				if (entityBehaviour.entity.Exists() && !entityBehaviour.entity.HasStruct<EntityContextComp>())
				{
					EntityContextComp comp = new EntityContextComp
					{
						roomType = roomType
					};
					entityBehaviour.entity.AddStruct(comp);
				}
			}
		}
	}

	public static bool IsMarkedForDeath(Entity entity)
	{
		if (entity.Exists())
		{
			return entity.HasStruct<MarkedForDeathComp>();
		}
		return false;
	}
}
