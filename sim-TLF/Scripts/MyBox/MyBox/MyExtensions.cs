using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MyBox
{
	public static class MyExtensions
	{
		public struct ComponentOfInterface<T>
		{
			public readonly Component Component;

			public readonly T Interface;

			public ComponentOfInterface(Component component, T @interface)
			{
				Component = component;
				Interface = @interface;
			}
		}

		public static void Swap<T>(this T[] array, int a, int b)
		{
			T val = array[b];
			T val2 = array[a];
			array[a] = val;
			array[b] = val2;
		}

		public static bool IsWorldPointInViewport(this Camera camera, Vector3 point)
		{
			Vector3 vector = camera.WorldToViewportPoint(point);
			float x = vector.x;
			if (x > 0f && x < 1f)
			{
				float y = vector.y;
				if (y > 0f)
				{
					return y < 1f;
				}
			}
			return false;
		}

		public static Vector3 WorldPointOffsetByDepth(this Camera camera, Vector3 source, float distanceFromCamera, Camera.MonoOrStereoscopicEye eye = Camera.MonoOrStereoscopicEye.Mono)
		{
			Vector3 vector = camera.WorldToScreenPoint(source, eye);
			return camera.ScreenToWorldPoint(vector.SetZ(distanceFromCamera), eye);
		}

		public static void ResetPosition(this Transform transform)
		{
			transform.position = Vector3.zero;
		}

		public static Transform SetLossyScale(this Transform source, Vector3 targetLossyScale)
		{
			source.localScale = source.lossyScale.Pow(-1f).ScaleBy(targetLossyScale).ScaleBy(source.localScale);
			return source;
		}

		public static T SetLayerRecursively<T>(this T source, string layerName) where T : Component
		{
			source.gameObject.SetLayerRecursively(LayerMask.NameToLayer(layerName));
			return source;
		}

		public static T SetLayerRecursively<T>(this T source, int layer) where T : Component
		{
			source.gameObject.SetLayerRecursively(layer);
			return source;
		}

		public static GameObject SetLayerRecursively(this GameObject source, string layerName)
		{
			source.SetLayerRecursively(LayerMask.NameToLayer(layerName));
			return source;
		}

		public static GameObject SetLayerRecursively(this GameObject source, int layer)
		{
			Transform[] componentsInChildren = source.GetComponentsInChildren<Transform>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].gameObject.layer = layer;
			}
			return source;
		}

		public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
		{
			T component = gameObject.GetComponent<T>();
			if (component != null)
			{
				return component;
			}
			return gameObject.AddComponent<T>();
		}

		public static T GetOrAddComponent<T>(this Component component) where T : Component
		{
			return component.gameObject.GetOrAddComponent<T>();
		}

		public static bool HasComponent<T>(this GameObject gameObject)
		{
			return gameObject.GetComponent<T>() != null;
		}

		public static bool HasComponent<T>(this Component component)
		{
			return component.GetComponent<T>() != null;
		}

		public static List<Transform> GetChildsWhere(this Transform transform, Predicate<Transform> match)
		{
			List<Transform> list = new List<Transform>();
			RecursiveCheck(transform);
			return list;
			void RecursiveCheck(Transform parent)
			{
				foreach (Transform item in parent)
				{
					RecursiveCheck(item);
					if (match(item))
					{
						list.Add(item);
					}
				}
			}
		}

		public static List<Transform> GetObjectsOfLayerInChilds(this GameObject gameObject, int layer)
		{
			return gameObject.transform.GetChildsWhere((Transform t) => t.gameObject.layer == layer);
		}

		public static List<Transform> GetObjectsOfLayerInChilds(this GameObject gameObject, string layer)
		{
			return gameObject.GetObjectsOfLayerInChilds(LayerMask.NameToLayer(layer));
		}

		public static List<Transform> GetObjectsOfLayerInChilds(this Component component, string layer)
		{
			return component.GetObjectsOfLayerInChilds(LayerMask.NameToLayer(layer));
		}

		public static List<Transform> GetObjectsOfLayerInChilds(this Component component, int layer)
		{
			return component.gameObject.GetObjectsOfLayerInChilds(layer);
		}

		public static void SetBodyState(this Rigidbody body, bool state)
		{
			body.isKinematic = !state;
			body.detectCollisions = state;
		}

		public static T[] FindObjectsOfInterface<T>() where T : class
		{
			return (from behaviour in UnityEngine.Object.FindObjectsOfType<Transform>()
				select behaviour.GetComponent(typeof(T))).OfType<T>().ToArray();
		}

		public static ComponentOfInterface<T>[] FindObjectsOfInterfaceAsComponents<T>() where T : class
		{
			return (from c in UnityEngine.Object.FindObjectsOfType<Component>()
				where c is T
				select new ComponentOfInterface<T>(c, c as T)).ToArray();
		}

		public static T[] OnePerInstance<T>(this T[] components) where T : Component
		{
			if (components == null || components.Length == 0)
			{
				return null;
			}
			return (from h in components
				group h by h.transform.GetInstanceID() into g
				select g.First()).ToArray();
		}

		public static RaycastHit2D[] OneHitPerInstance(this RaycastHit2D[] hits)
		{
			if (hits == null || hits.Length == 0)
			{
				return null;
			}
			return (from h in hits
				group h by h.transform.GetInstanceID() into g
				select g.First()).ToArray();
		}

		public static Collider2D[] OneHitPerInstance(this Collider2D[] hits)
		{
			if (hits == null || hits.Length == 0)
			{
				return null;
			}
			return (from h in hits
				group h by h.transform.GetInstanceID() into g
				select g.First()).ToArray();
		}

		public static List<Collider2D> OneHitPerInstanceList(this Collider2D[] hits)
		{
			if (hits == null || hits.Length == 0)
			{
				return null;
			}
			return (from h in hits
				group h by h.transform.GetInstanceID() into g
				select g.First()).ToList();
		}
	}
}
