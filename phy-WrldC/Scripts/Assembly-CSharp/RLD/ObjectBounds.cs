using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class ObjectBounds
	{
		public struct QueryConfig
		{
			public GameObjectType ObjectTypes;

			public Vector3 NoVolumeSize;
		}

		private static QueryConfig _defaultQConfig;

		public static QueryConfig DefaultQConfig => _defaultQConfig;

		static ObjectBounds()
		{
			_defaultQConfig = default(QueryConfig);
			_defaultQConfig.ObjectTypes = GameObjectTypeHelper.AllCombined;
			_defaultQConfig.NoVolumeSize = Vector3.zero;
		}

		public static Rect CalcScreenRect(GameObject gameObject, Camera camera, QueryConfig queryConfig)
		{
			AABB aABB = CalcWorldAABB(gameObject, queryConfig);
			if (!aABB.IsValid)
			{
				return new Rect(0f, 0f, 0f, 0f);
			}
			return aABB.GetScreenRectangle(camera);
		}

		public static OBB CalcSpriteWorldOBB(GameObject gameObject)
		{
			AABB modelSpaceAABB = CalcSpriteModelAABB(gameObject);
			if (!modelSpaceAABB.IsValid)
			{
				return OBB.GetInvalid();
			}
			return new OBB(modelSpaceAABB, gameObject.transform);
		}

		public static AABB CalcSpriteWorldAABB(GameObject gameObject)
		{
			AABB result = CalcSpriteModelAABB(gameObject);
			if (!result.IsValid)
			{
				return result;
			}
			result.Transform(gameObject.transform.localToWorldMatrix);
			return result;
		}

		public static AABB CalcSpriteModelAABB(GameObject spriteObject)
		{
			SpriteRenderer component = spriteObject.GetComponent<SpriteRenderer>();
			if (component == null)
			{
				return AABB.GetInvalid();
			}
			return component.GetModelSpaceAABB();
		}

		public static OBB GetMeshWorldOBB(GameObject gameObject)
		{
			AABB modelSpaceAABB = CalcMeshModelAABB(gameObject);
			if (!modelSpaceAABB.IsValid)
			{
				return OBB.GetInvalid();
			}
			return new OBB(modelSpaceAABB, gameObject.transform);
		}

		public static AABB GetMeshWorldAABB(GameObject gameObject)
		{
			AABB result = CalcMeshModelAABB(gameObject);
			if (!result.IsValid)
			{
				return result;
			}
			result.Transform(gameObject.transform.localToWorldMatrix);
			return result;
		}

		public static AABB CalcObjectCollectionWorldAABB(IEnumerable<GameObject> gameObjectCollection, QueryConfig queryConfig)
		{
			AABB result = AABB.GetInvalid();
			foreach (GameObject item in gameObjectCollection)
			{
				AABB aABB = CalcWorldAABB(item, queryConfig);
				if (aABB.IsValid)
				{
					if (result.IsValid)
					{
						result.Encapsulate(aABB);
					}
					else
					{
						result = aABB;
					}
				}
			}
			return result;
		}

		public static AABB CalcHierarchyCollectionWorldAABB(List<GameObject> roots, QueryConfig queryConfig)
		{
			AABB result = AABB.GetInvalid();
			foreach (GameObject root in roots)
			{
				AABB aABB = CalcHierarchyWorldAABB(root, queryConfig);
				if (aABB.IsValid)
				{
					if (result.IsValid)
					{
						result.Encapsulate(aABB);
					}
					else
					{
						result = aABB;
					}
				}
			}
			return result;
		}

		public static OBB CalcHierarchyWorldOBB(GameObject root, QueryConfig queryConfig)
		{
			AABB modelSpaceAABB = CalcHierarchyModelAABB(root, queryConfig);
			if (!modelSpaceAABB.IsValid)
			{
				return OBB.GetInvalid();
			}
			return new OBB(modelSpaceAABB, root.transform);
		}

		public static AABB CalcHierarchyWorldAABB(GameObject root, QueryConfig queryConfig)
		{
			AABB result = CalcHierarchyModelAABB(root, queryConfig);
			if (!result.IsValid)
			{
				return AABB.GetInvalid();
			}
			result.Transform(root.transform.localToWorldMatrix);
			return result;
		}

		public static OBB CalcWorldOBB(GameObject gameObject, QueryConfig queryConfig)
		{
			AABB modelSpaceAABB = CalcModelAABB(gameObject, queryConfig, gameObject.GetGameObjectType());
			if (!modelSpaceAABB.IsValid)
			{
				return OBB.GetInvalid();
			}
			return new OBB(modelSpaceAABB, gameObject.transform);
		}

		public static AABB CalcWorldAABB(GameObject gameObject, QueryConfig queryConfig)
		{
			AABB result = CalcModelAABB(gameObject, queryConfig, gameObject.GetGameObjectType());
			if (!result.IsValid)
			{
				return result;
			}
			result.Transform(gameObject.transform.localToWorldMatrix);
			return result;
		}

		public static AABB CalcMeshWorldAABB(GameObject gameObject)
		{
			AABB result = CalcMeshModelAABB(gameObject);
			if (!result.IsValid)
			{
				return result;
			}
			result.Transform(gameObject.transform.localToWorldMatrix);
			return result;
		}

		public static AABB CalcHierarchyModelAABB(GameObject root, QueryConfig queryConfig)
		{
			Matrix4x4 localToWorldMatrix = root.transform.localToWorldMatrix;
			AABB result = CalcModelAABB(root, queryConfig, root.GetGameObjectType());
			foreach (GameObject allChild in root.GetAllChildren())
			{
				if (allChild.layer != LayerNames.LEPermanent && allChild.layer != LayerNames.LEScalable && allChild.layer != LayerNames.LEUnscalable)
				{
					continue;
				}
				AABB aABB = CalcModelAABB(allChild, queryConfig, allChild.GetGameObjectType());
				if (aABB.IsValid)
				{
					Matrix4x4 relativeTransform = allChild.transform.localToWorldMatrix.GetRelativeTransform(localToWorldMatrix);
					aABB.Transform(relativeTransform);
					if (result.IsValid)
					{
						result.Encapsulate(aABB);
					}
					else
					{
						result = aABB;
					}
				}
			}
			return result;
		}

		public static AABB CalcMeshModelAABB(GameObject gameObject)
		{
			Mesh mesh = gameObject.GetMesh();
			if (mesh == null)
			{
				return AABB.GetInvalid();
			}
			return new AABB(mesh.bounds);
		}

		public static AABB CalcModelAABB(GameObject gameObject, QueryConfig queryConfig, GameObjectType objectType)
		{
			if ((objectType & queryConfig.ObjectTypes) == 0)
			{
				return AABB.GetInvalid();
			}
			switch (objectType)
			{
			case GameObjectType.Mesh:
			{
				Mesh mesh = gameObject.GetMesh();
				if (mesh == null)
				{
					return AABB.GetInvalid();
				}
				return new AABB(mesh.bounds);
			}
			case GameObjectType.Sprite:
				return CalcSpriteModelAABB(gameObject);
			case GameObjectType.Terrain:
			{
				TerrainData terrainData = gameObject.GetComponent<Terrain>().terrainData;
				if (terrainData == null)
				{
					return AABB.GetInvalid();
				}
				Vector3 size = terrainData.bounds.size;
				return new AABB(terrainData.bounds.center, size);
			}
			default:
				return new AABB(Vector3.zero, queryConfig.NoVolumeSize);
			}
		}
	}
}
