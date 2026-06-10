using System.Text;
using UnityEngine;

namespace NSMedieval.Utils
{
	public static class GameObjectUtils
	{
		public static void DeleteComponentIfExists<TComponent>(this GameObject gameObject) where TComponent : MonoBehaviour
		{
			TComponent component = gameObject.GetComponent<TComponent>();
			if (component != null)
			{
				Object.DestroyImmediate(component);
			}
		}

		public static void DeleteAllComponentsIfExist<TComponent>(this GameObject gameObject) where TComponent : Component
		{
			TComponent[] componentsInChildren = gameObject.GetComponentsInChildren<TComponent>();
			if (componentsInChildren != null)
			{
				TComponent[] array = componentsInChildren;
				for (int i = 0; i < array.Length; i++)
				{
					Object.DestroyImmediate(array[i]);
				}
			}
		}

		public static void DeleteChildIfExists(this GameObject gameObject, string objectName, bool recursive = true)
		{
			for (int num = gameObject.transform.childCount - 1; num >= 0; num--)
			{
				Transform child = gameObject.transform.GetChild(num);
				child.gameObject.DeleteChildIfExists(objectName, recursive);
				if (child.name == objectName)
				{
					Object.DestroyImmediate(child.gameObject);
				}
			}
		}

		public static void SetActiveNullCheck(GameObject gameObject, bool active)
		{
			if (gameObject != null)
			{
				gameObject.SetActive(active);
			}
		}

		public static T GetOrAddComponent<T>(this GameObject gameObject) where T : MonoBehaviour
		{
			T component = gameObject.GetComponent<T>();
			if (component != null)
			{
				return component;
			}
			return gameObject.AddComponent<T>();
		}

		public static string GetNameWithPath(Transform transform)
		{
			StringBuilder stringBuilder = new StringBuilder();
			GetNameWithPath(transform, stringBuilder);
			return stringBuilder.ToString();
		}

		private static void GetNameWithPath(Transform transform, StringBuilder stringBuilder)
		{
			while (true)
			{
				stringBuilder.Insert(0, '/');
				if (transform == null)
				{
					stringBuilder.Insert(0, "null");
					break;
				}
				stringBuilder.Insert(0, transform.name);
				stringBuilder.Insert(0, transform.name);
				if (transform?.parent?.gameObject != null)
				{
					transform = transform.parent;
					continue;
				}
				break;
			}
		}
	}
}
