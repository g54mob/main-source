using System;
using System.Collections.Generic;
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
				Component = null;
				Interface = default(T);
			}
		}

		public static void Swap<T>(this T[] array, int a, int b)
		{
		}

		public static bool IsWorldPointInViewport(this Camera camera, Vector3 point)
		{
			return false;
		}

		public static Vector3 WorldPointOffsetByDepth(this Camera camera, Vector3 source, float distanceFromCamera, Camera.MonoOrStereoscopicEye eye = Camera.MonoOrStereoscopicEye.Mono)
		{
			return default(Vector3);
		}

		public static void ResetPosition(this Transform transform)
		{
		}

		public static Transform SetLossyScale(this Transform source, Vector3 targetLossyScale)
		{
			return null;
		}

		public static T SetLayerRecursively<T>(this T source, string layerName)
		{
			return default(T);
		}

		public static T SetLayerRecursively<T>(this T source, int layer)
		{
			return default(T);
		}

		public static GameObject SetLayerRecursively(this GameObject source, string layerName)
		{
			return null;
		}

		public static GameObject SetLayerRecursively(this GameObject source, int layer)
		{
			return null;
		}

		public static T GetOrAddComponent<T>(this GameObject gameObject)
		{
			return default(T);
		}

		public static T GetOrAddComponent<T>(this Component component)
		{
			return default(T);
		}

		public static bool HasComponent<T>(this GameObject gameObject)
		{
			return false;
		}

		public static bool HasComponent<T>(this Component component)
		{
			return false;
		}

		public static List<Transform> GetChildsWhere(this Transform transform, Predicate<Transform> match)
		{
			return null;
		}

		public static List<Transform> GetObjectsOfLayerInChilds(this GameObject gameObject, int layer)
		{
			return null;
		}

		public static List<Transform> GetObjectsOfLayerInChilds(this GameObject gameObject, string layer)
		{
			return null;
		}

		public static List<Transform> GetObjectsOfLayerInChilds(this Component component, string layer)
		{
			return null;
		}

		public static List<Transform> GetObjectsOfLayerInChilds(this Component component, int layer)
		{
			return null;
		}

		public static void SetBodyState(this Rigidbody body, bool state)
		{
		}

		public static T[] FindObjectsOfInterface<T>() where T : class
		{
			return null;
		}

		public static ComponentOfInterface<T>[] FindObjectsOfInterfaceAsComponents<T>() where T : class
		{
			return null;
		}

		public static T[] OnePerInstance<T>(this T[] components)
		{
			return null;
		}

		public static RaycastHit2D[] OneHitPerInstance(this RaycastHit2D[] hits)
		{
			return null;
		}

		public static Collider2D[] OneHitPerInstance(this Collider2D[] hits)
		{
			return null;
		}

		public static List<Collider2D> OneHitPerInstanceList(this Collider2D[] hits)
		{
			return null;
		}
	}
}
