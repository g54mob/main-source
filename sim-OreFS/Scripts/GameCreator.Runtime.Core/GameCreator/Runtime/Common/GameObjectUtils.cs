using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public static class GameObjectUtils
	{
		public static Bounds GetBoundingBox(this GameObject gameObject)
		{
			Bounds result = new Bounds(gameObject.transform.position, Vector3.zero);
			Renderer[] componentsInChildren = gameObject.GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in componentsInChildren)
			{
				result.Encapsulate(renderer.bounds);
			}
			return result;
		}
	}
}
