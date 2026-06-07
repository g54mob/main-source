using UnityEngine;

namespace SuperTiled2Unity
{
	public static class GameObjectExtensions
	{
		public static T GetComponentInAncestor<T>(this MonoBehaviour mono) where T : MonoBehaviour
		{
			return null;
		}

		public static T GetComponentInAncestor<T>(this GameObject go) where T : MonoBehaviour
		{
			return null;
		}

		public static bool TryGetCustomPropertySafe(this GameObject go, string name, out CustomProperty property)
		{
			property = null;
			return false;
		}
	}
}
