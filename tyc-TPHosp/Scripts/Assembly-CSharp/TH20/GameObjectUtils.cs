using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public static class GameObjectUtils
	{
		public const float DefaultImageFillAmountIfDifferentTolerance = 0.001953125f;

		public static void SetActive(GameObject gameObject, bool isActive)
		{
			if (gameObject.activeSelf != isActive)
			{
				gameObject.SetActive(isActive);
			}
		}

		public static void SetSiblingIndex(Transform transform, int siblingIndex)
		{
			if (transform.GetSiblingIndex() != siblingIndex)
			{
				transform.SetSiblingIndex(siblingIndex);
			}
		}

		public static void SetParent(Transform transform, Transform parent, bool worldPositionStays = false)
		{
			if (transform.parent != parent)
			{
				transform.SetParent(parent, worldPositionStays);
			}
		}

		public static string ObjectFullPath(Transform transform)
		{
			if (!transform)
			{
				return "";
			}
			return ObjectFullPath(transform.parent) + "/" + transform.name;
		}

		public static string ObjectFullScenePath(Transform transform)
		{
			return transform.gameObject.scene.name + ObjectFullPath(transform);
		}

		public static void SetImageFillAmountIfDifferent(Image image, float fillAmount, float tolerance = 0.001953125f)
		{
			if (!MathUtils.Approximately(image.fillAmount, fillAmount, tolerance))
			{
				image.fillAmount = fillAmount;
			}
		}

		public static void SetInteractable(Selectable selectable, bool interactable)
		{
			if (selectable.interactable != interactable)
			{
				selectable.interactable = interactable;
			}
		}

		public static void SetImageSprite(Image image, Sprite sprite)
		{
			if (image.sprite != sprite)
			{
				image.sprite = sprite;
			}
		}

		public static void EnableEmmission(ParticleSystem system, bool value)
		{
			if (system.emission.enabled != value)
			{
				ParticleSystem.EmissionModule emission = system.emission;
				emission.enabled = value;
			}
		}

		public static void DestroyChildren(GameObject gameObject)
		{
			for (int num = gameObject.transform.childCount - 1; num >= 0; num--)
			{
				Object.Destroy(gameObject.transform.GetChild(num).gameObject);
			}
		}

		public static void DestroyChildrenImmediate(GameObject gameObject)
		{
			if (gameObject == null || gameObject.transform == null)
			{
				return;
			}
			for (int num = gameObject.transform.childCount - 1; num >= 0; num--)
			{
				if (!(gameObject.transform.GetChild(num).gameObject == null))
				{
					Object.DestroyImmediate(gameObject.transform.GetChild(num).gameObject);
				}
			}
		}

		public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
		{
			return gameObject.GetComponent<T>() ?? gameObject.AddComponent<T>();
		}

		public static Transform FindChildRecursively(this Transform transform, string name, bool ignoreInputTransform = false)
		{
			if (!ignoreInputTransform && transform.name == name)
			{
				return transform;
			}
			foreach (Transform item in transform)
			{
				if (item.name == name)
				{
					return item;
				}
				Transform transform3 = item.FindChildRecursively(name);
				if (transform3 != null)
				{
					return transform3;
				}
			}
			return null;
		}

		public static void SetLayerRecursively(this GameObject obj, int newLayer)
		{
			if (!(obj != null))
			{
				return;
			}
			if (obj.layer != newLayer)
			{
				obj.layer = newLayer;
			}
			foreach (Transform item in obj.transform)
			{
				item.gameObject.SetLayerRecursively(newLayer);
			}
		}

		public static void SafeDestroy(ref GameObject obj)
		{
			if (obj != null)
			{
				Object.Destroy(obj);
			}
			obj = null;
		}

		public static T[] GetComponentsInChildrenOnly<T>(this GameObject obj) where T : Component
		{
			List<T> list = new List<T>();
			foreach (Transform item2 in obj.transform)
			{
				T[] componentsInChildren = item2.GetComponentsInChildren<T>();
				if (componentsInChildren != null)
				{
					T[] array = componentsInChildren;
					foreach (T item in array)
					{
						list.Add(item);
					}
				}
			}
			return list.ToArray();
		}

		public static bool IsParent(this Transform parent, Transform child)
		{
			Transform transform = child;
			while (parent != null && transform != null)
			{
				if (parent == transform)
				{
					return true;
				}
				transform = transform.parent;
			}
			return false;
		}
	}
}
