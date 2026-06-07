using UnityEngine;

namespace Jundroo.Common.Debugging
{
	public static class DebugUtility
	{
		public static void AddReferenceObject(GameObject gameObject, string referenceName, GameObject referencedObject)
		{
			if (!gameObject.TryGetComponent<GameObjectReferencesScript>(out var component))
			{
				component = gameObject.AddComponent<GameObjectReferencesScript>();
			}
			component.References.Add(new GameObjectReferencesScript.GameObjectReference(referenceName, referencedObject));
		}

		public static GameObject CreateGameObject(string name, Transform parent, Vector3 localPosition)
		{
			GameObject gameObject = new GameObject(name);
			gameObject.transform.parent = parent;
			gameObject.transform.localPosition = localPosition;
			return gameObject;
		}

		public static GameObject CreateGameObjectWithReference(string name, Transform parent, Vector3 localPosition, GameObject referencedObject)
		{
			GameObject gameObject = new GameObject(name);
			gameObject.transform.parent = parent;
			gameObject.transform.localPosition = localPosition;
			if (referencedObject != null)
			{
				gameObject.AddComponent<GameObjectReferencesScript>().References.Add(new GameObjectReferencesScript.GameObjectReference(referencedObject.name, referencedObject));
			}
			return gameObject;
		}

		public static GameObject CreatePrimitive(string name, PrimitiveType type, Color color, Vector3 localPosition, Transform parent, bool colliderEnabled)
		{
			GameObject gameObject = GameObject.CreatePrimitive(type);
			gameObject.name = name;
			gameObject.transform.parent = parent;
			gameObject.transform.localPosition = localPosition;
			gameObject.GetComponent<MeshRenderer>().material.color = color;
			gameObject.GetComponent<Collider>().enabled = colliderEnabled;
			return gameObject;
		}

		public static void FocusInEditor(GameObject obj)
		{
		}

		public static void PauseEditor(bool pause)
		{
		}
	}
}
