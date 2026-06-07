using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class GameObjectEx
	{
		public static void SetStatic(this GameObject gameObject, bool isStatic, bool affectChildren)
		{
			if (!affectChildren)
			{
				gameObject.isStatic = isStatic;
				return;
			}
			foreach (GameObject item in gameObject.GetAllChildrenAndSelf())
			{
				item.isStatic = isStatic;
			}
		}

		public static bool IsRLDAppObject(this GameObject gameObject)
		{
			return gameObject.transform.root.gameObject.GetComponent<IRLDApplication>() != null;
		}

		public static GameObjectType GetGameObjectType(this GameObject gameObject)
		{
			if (gameObject.GetMesh() != null)
			{
				return GameObjectType.Mesh;
			}
			if (gameObject.GetComponent<Terrain>() != null)
			{
				return GameObjectType.Terrain;
			}
			if (gameObject.GetSprite() != null)
			{
				return GameObjectType.Sprite;
			}
			if (gameObject.GetComponent<Camera>() != null)
			{
				return GameObjectType.Camera;
			}
			if (gameObject.GetComponent<Light>() != null)
			{
				return GameObjectType.Light;
			}
			if (gameObject.GetComponent<ParticleSystem>() != null)
			{
				return GameObjectType.ParticleSystem;
			}
			return GameObjectType.Empty;
		}

		public static bool HierarchyHasMesh(this GameObject root)
		{
			foreach (GameObject item in root.GetAllChildrenAndSelf())
			{
				if (item.GetMesh() != null)
				{
					return true;
				}
			}
			return false;
		}

		public static bool HierarchyHasSprite(this GameObject root)
		{
			foreach (GameObject item in root.GetAllChildrenAndSelf())
			{
				if (item.GetSprite() != null)
				{
					return true;
				}
			}
			return false;
		}

		public static bool HierarchyHasObjectsOfType(this GameObject root, GameObjectType typeFlags)
		{
			foreach (GameObject item in root.GetAllChildrenAndSelf())
			{
				GameObjectType gameObjectType = item.GetGameObjectType();
				if ((typeFlags & gameObjectType) != 0)
				{
					return true;
				}
			}
			return false;
		}

		public static List<GameObject> GetMeshObjectsInHierarchy(this GameObject root)
		{
			List<GameObject> allChildrenAndSelf = root.GetAllChildrenAndSelf();
			List<GameObject> list = new List<GameObject>(allChildrenAndSelf.Count);
			foreach (GameObject item in allChildrenAndSelf)
			{
				if (item.GetMesh() != null)
				{
					list.Add(item);
				}
			}
			return list;
		}

		public static List<GameObject> GetSpriteObjectsInHierarchy(this GameObject root)
		{
			List<GameObject> allChildrenAndSelf = root.GetAllChildrenAndSelf();
			List<GameObject> list = new List<GameObject>(allChildrenAndSelf.Count);
			foreach (GameObject item in allChildrenAndSelf)
			{
				if (item.GetSprite() != null)
				{
					list.Add(item);
				}
			}
			return list;
		}

		public static void SetHierarchyWorldScaleByPivot(this GameObject root, Vector3 worldScale, Vector3 pivotPoint)
		{
			if (worldScale.x == 0f)
			{
				worldScale.x = 0.0001f;
			}
			if (worldScale.y == 0f)
			{
				worldScale.y = 0.0001f;
			}
			if (worldScale.z == 0f)
			{
				worldScale.z = 0.0001f;
			}
			Transform transform = root.transform;
			Vector3 b = transform.position - pivotPoint;
			Vector3 lossyScale = transform.lossyScale;
			transform.SetWorldScale(worldScale);
			b = Vector3.Scale(Vector3.Scale(b: lossyScale.GetInverse(), a: worldScale), b);
			transform.position = pivotPoint + b;
		}

		public static List<GameObject> GetAllChildren(this GameObject gameObject)
		{
			Transform[] componentsInChildren = gameObject.GetComponentsInChildren<Transform>();
			List<GameObject> list = new List<GameObject>(componentsInChildren.Length);
			Transform[] array = componentsInChildren;
			foreach (Transform transform in array)
			{
				if (transform.gameObject != gameObject)
				{
					list.Add(transform.gameObject);
				}
			}
			return list;
		}

		public static List<GameObject> GetAllChildrenAndSelf(this GameObject gameObject)
		{
			Transform[] componentsInChildren = gameObject.GetComponentsInChildren<Transform>();
			List<GameObject> list = new List<GameObject>(componentsInChildren.Length);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				list.Add(componentsInChildren[i].gameObject);
			}
			return list;
		}

		public static void GetAllChildrenAndSelf(this GameObject gameObject, List<GameObject> childrenAndSelf)
		{
			childrenAndSelf.Clear();
			Transform[] componentsInChildren = gameObject.GetComponentsInChildren<Transform>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				childrenAndSelf.Add(componentsInChildren[i].gameObject);
			}
		}

		public static Mesh GetMesh(this GameObject gameObject)
		{
			MeshFilter component = gameObject.GetComponent<MeshFilter>();
			if (component != null && component.sharedMesh != null)
			{
				return component.sharedMesh;
			}
			SkinnedMeshRenderer component2 = gameObject.GetComponent<SkinnedMeshRenderer>();
			if (component2 != null && component2.sharedMesh != null)
			{
				return component2.sharedMesh;
			}
			return null;
		}

		public static Renderer GetMeshRenderer(this GameObject gameObject)
		{
			MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
			if (component != null)
			{
				return component;
			}
			return gameObject.GetComponent<SkinnedMeshRenderer>();
		}

		public static Sprite GetSprite(this GameObject gameObject)
		{
			SpriteRenderer component = gameObject.GetComponent<SpriteRenderer>();
			if (component == null)
			{
				return null;
			}
			return component.sprite;
		}

		public static List<GameObject> GetRoots(IEnumerable<GameObject> gameObjects)
		{
			if (gameObjects == null)
			{
				return new List<GameObject>();
			}
			List<GameObject> list = new List<GameObject>();
			HashSet<GameObject> hashSet = new HashSet<GameObject>();
			foreach (GameObject gameObject2 in gameObjects)
			{
				GameObject gameObject = gameObject2.transform.root.gameObject;
				if (!hashSet.Contains(gameObject))
				{
					hashSet.Add(gameObject);
					list.Add(gameObject);
				}
			}
			hashSet.Clear();
			return list;
		}

		public static List<GameObject> FilterParentsOnly(IEnumerable<GameObject> gameObjects)
		{
			if (gameObjects == null)
			{
				return new List<GameObject>();
			}
			List<GameObject> list = new List<GameObject>(10);
			foreach (GameObject gameObject in gameObjects)
			{
				bool flag = false;
				Transform transform = gameObject.transform;
				foreach (GameObject gameObject2 in gameObjects)
				{
					if (gameObject2 != gameObject && transform.IsChildOf(gameObject2.transform))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					list.Add(gameObject);
				}
			}
			return list;
		}
	}
}
