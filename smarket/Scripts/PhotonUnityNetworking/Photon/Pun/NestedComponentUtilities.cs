using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Photon.Pun
{
	public static class NestedComponentUtilities
	{
		private static Queue<Transform> nodesQueue;

		public static Dictionary<Type, ICollection> searchLists;

		private static Stack<Transform> nodeStack;

		public static T EnsureRootComponentExists<T, NestedT>(this Transform transform)
		{
			return default(T);
		}

		public static T GetParentComponent<T>(this Transform t)
		{
			return default(T);
		}

		public static void GetNestedComponentsInParents<T>(this Transform t, List<T> list)
		{
		}

		public static T GetNestedComponentInChildren<T, NestedT>(this Transform t, bool includeInactive) where T : class where NestedT : class
		{
			return null;
		}

		public static T GetNestedComponentInParent<T, NestedT>(this Transform t) where T : class where NestedT : class
		{
			return null;
		}

		public static T GetNestedComponentInParents<T, NestedT>(this Transform t) where T : class where NestedT : class
		{
			return null;
		}

		public static void GetNestedComponentsInParents<T, NestedT>(this Transform t, List<T> list) where T : class where NestedT : class
		{
		}

		public static List<T> GetNestedComponentsInChildren<T, NestedT>(this Transform t, List<T> list, bool includeInactive = true) where T : class where NestedT : class
		{
			return null;
		}

		public static List<T> GetNestedComponentsInChildren<T>(this Transform t, List<T> list, bool includeInactive = true, params Type[] stopOn) where T : class
		{
			return null;
		}

		public static void GetNestedComponentsInChildren<T, SearchT, NestedT>(this Transform t, bool includeInactive, List<T> list) where T : class where SearchT : class
		{
		}
	}
}
