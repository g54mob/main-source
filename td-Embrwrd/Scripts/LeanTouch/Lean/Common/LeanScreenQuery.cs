using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lean.Common
{
	[Serializable]
	public struct LeanScreenQuery
	{
		public enum MethodType
		{
			Raycast = 0
		}

		public enum SearchType
		{
			GetComponent = 0,
			GetComponentInParent = 1,
			GetComponentInChildren = 2
		}

		public MethodType Method;

		public LayerMask Layers;

		public SearchType Search;

		public string RequiredTag;

		public Camera Camera;

		public float Distance;

		private static RaycastHit[] raycastHits;

		private static RaycastHit2D[] raycastHit2Ds;

		private static List<RaycastResult> tempRaycastResults;

		private static PointerEventData tempPointerEventData;

		private static EventSystem tempEventSystem;

		private static List<KeyValuePair<GameObject, int>> tempLayers;

		public LeanScreenQuery(MethodType newMethod)
		{
			Method = default(MethodType);
			Layers = default(LayerMask);
			Search = default(SearchType);
			RequiredTag = null;
			Camera = null;
			Distance = 0f;
		}

		public LeanScreenQuery(MethodType newMethod, LayerMask layers)
		{
			Method = default(MethodType);
			Layers = default(LayerMask);
			Search = default(SearchType);
			RequiredTag = null;
			Camera = null;
			Distance = 0f;
		}

		public static void ChangeLayers(GameObject root, bool ancestors, bool children)
		{
		}

		public static void RevertLayers()
		{
		}

		public T Query<T>(GameObject gameObject, Vector2 screenPosition)
		{
			return default(T);
		}

		public bool TryQuery<T>(GameObject gameObject, Vector2 screenPosition, ref T result, ref Component root, ref Vector3 worldPosition)
		{
			return false;
		}

		private bool TryResult<T>(Component hit, ref T result, ref Component component)
		{
			return false;
		}

		private bool TryGetComponent<T>(Component hit, ref T result, ref Component component)
		{
			return false;
		}

		private bool TryGetComponentInParent<T>(Component hit, ref T result, ref Component component)
		{
			return false;
		}

		private bool TryGetComponentInChildren<T>(Component hit, ref T result, ref Component component)
		{
			return false;
		}

		private static int GetClosestRaycastHitsIndex(int count)
		{
			return 0;
		}

		private void DoRaycast3D(Camera camera, Vector2 screenPosition, ref Component bestResult, ref float bestDistance, ref Vector3 bestPosition)
		{
		}

		private void DoRaycast2D(Camera camera, Vector2 screenPosition, ref Component bestResult, ref float bestDistance, ref Vector3 bestPosition)
		{
		}

		private void DoRaycastUI(Vector2 screenPosition, ref Component bestResult, ref float bestDistance, ref Vector3 bestPosition)
		{
		}
	}
}
