using UnityEngine;

namespace RLD
{
	public static class ObjectSpawnUtil
	{
		public struct Config
		{
			public float ObjectSize;
		}

		private static Config _defaultConfig = new Config
		{
			ObjectSize = 0.3f
		};

		public static Config DefaultConfig => _defaultConfig;

		public static GameObject SpawnInFrontOfCamera(GameObject sourceObject, Camera camera, Config config)
		{
			float num = config.ObjectSize * 0.5f;
			ObjectBounds.QueryConfig queryConfig = new ObjectBounds.QueryConfig
			{
				ObjectTypes = GameObjectTypeHelper.AllCombined,
				NoVolumeSize = Vector3Ex.FromValue(1f)
			};
			Transform transform = camera.transform;
			AABB aabb = ObjectBounds.CalcHierarchyWorldAABB(sourceObject, queryConfig);
			if (!aabb.IsValid)
			{
				return null;
			}
			Sphere sphere = new Sphere(aabb);
			Vector3 vector = sourceObject.transform.position - sphere.Center;
			float num2 = Mathf.Max(camera.nearClipPlane + sphere.Radius, sphere.Radius / num);
			Vector3 vector2 = transform.position + transform.forward * num2;
			GameObject gameObject = Object.Instantiate(sourceObject, vector2 + vector, sourceObject.transform.rotation);
			gameObject.SetActive(value: true);
			OBB obb = ObjectBounds.CalcHierarchyWorldOBB(gameObject, queryConfig);
			Ray ray = new Ray(camera.transform.position, (obb.Center - camera.transform.position).normalized);
			SceneRaycastFilter sceneRaycastFilter = new SceneRaycastFilter();
			sceneRaycastFilter.AllowedObjectTypes.Add(GameObjectType.Mesh);
			sceneRaycastFilter.AllowedObjectTypes.Add(GameObjectType.Terrain);
			sceneRaycastFilter.AllowedObjectTypes.Add(GameObjectType.Sprite);
			SceneRaycastHit sceneRaycastHit = MonoSingleton<RTScene>.Get.Raycast(ray, SceneRaycastPrecision.BestFit, sceneRaycastFilter);
			if (sceneRaycastHit.WasAnObjectHit)
			{
				Vector3 center = obb.Center;
				obb.Center = sceneRaycastHit.ObjectHit.HitPoint;
				Vector3 vector3 = obb.Center - center;
				vector3 += ObjectSurfaceSnap.CalculateSitOnSurfaceOffset(obb, sceneRaycastHit.ObjectHit.HitPlane, 0f);
				gameObject.transform.position += vector3;
			}
			return gameObject;
		}
	}
}
