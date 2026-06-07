using System;
using UnityEngine;

namespace VoxelBusters.CoreLibrary
{
	public static class ComponentUtility
	{
		public static T AddComponentIfNotFound<T>(this GameObject gameObject) where T : Component
		{
			return null;
		}

		public static TBase AddUniqueComponent<TBase>(this GameObject gameObject, Type type) where TBase : Component
		{
			return null;
		}

		public static T GetComponentInPredecessor<T>(this MonoBehaviour monoBehaviour) where T : Component
		{
			return null;
		}

		public static T[] GetComponentsInChildren<T>(this Component component, bool includeParent, bool includeInactive) where T : Component
		{
			return null;
		}
	}
}
