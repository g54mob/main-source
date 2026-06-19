using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pug.UnityExtensions
{
	public static class UnityUtility
	{
		public static void FindObjectsOfTypeInScene<T>(List<T> objects, bool clearListFirst = true)
		{
			if (clearListFirst)
			{
				objects.Clear();
			}
			GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
			for (int i = 0; i < rootGameObjects.Length; i++)
			{
				T[] componentsInChildren = rootGameObjects[i].GetComponentsInChildren<T>();
				foreach (T item in componentsInChildren)
				{
					objects.Add(item);
				}
			}
		}

		public static Texture3D SlicesToCubicTexture3D(List<Texture2D> slices)
		{
			int count = slices.Count;
			Color[] array = new Color[count * count * count];
			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j < count; j++)
				{
					for (int k = 0; k < count; k++)
					{
						array[i + j * count + k * count * count] = slices[k].GetPixel(i, j);
					}
				}
			}
			Texture3D texture3D = new Texture3D(count, count, count, slices[0].format, mipChain: false);
			texture3D.filterMode = slices[0].filterMode;
			texture3D.anisoLevel = slices[0].anisoLevel;
			texture3D.wrapMode = slices[0].wrapMode;
			texture3D.SetPixels(array);
			texture3D.Apply();
			return texture3D;
		}

		public static void ApplyToGameObjectAndAllChildren(GameObject gameObject, Action<GameObject> action)
		{
			action(gameObject);
			int childCount = gameObject.transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				_ = gameObject.transform.GetChild(i).gameObject;
			}
		}

		public static GameObject FindParentWithTag(GameObject child, string tag)
		{
			Transform transform = child.transform;
			while (transform.parent != null)
			{
				if (transform.parent.tag == tag)
				{
					return transform.parent.gameObject;
				}
				transform = transform.parent.transform;
			}
			return null;
		}

		public static bool IsParentTo(Transform parent, Transform to)
		{
			if (to.parent == null)
			{
				return false;
			}
			if (to.parent == parent)
			{
				return true;
			}
			return IsParentTo(parent, to.parent);
		}

		public static void RemoveAllChildrenOfParentFromList(List<Transform> listToRemoveObjectsFrom, Transform parent)
		{
			foreach (Transform item in parent)
			{
				listToRemoveObjectsFrom.Remove(item);
				RemoveAllChildrenOfParentFromList(listToRemoveObjectsFrom, item);
			}
		}

		public static void AddAllChildrenOfParentToList(List<Transform> listToAddObjectsTo, Transform parent)
		{
			foreach (Transform item in parent)
			{
				listToAddObjectsTo.Add(item);
				RemoveAllChildrenOfParentFromList(listToAddObjectsTo, item);
			}
		}
	}
}
