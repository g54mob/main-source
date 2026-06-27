using UnityEngine;

namespace Helpers.Extensions
{
	public static class GameObjectExtensions
	{
		public static Vector3 CalculateBoundSize(this GameObject gameObject, bool includeLineRenderer = false)
		{
			Vector3 zero = Vector3.zero;
			Renderer[] componentsInChildren = gameObject.GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in componentsInChildren)
			{
				if (includeLineRenderer || !(renderer is LineRenderer))
				{
					zero.x = Mathf.Max(renderer.bounds.size.x, zero.x);
					zero.y = Mathf.Max(renderer.bounds.size.y, zero.y);
					zero.z = Mathf.Max(renderer.bounds.size.z, zero.z);
				}
			}
			return zero;
		}

		public static string GetFullPath(this GameObject gameObject)
		{
			string text = gameObject.scene.name + "/" + gameObject.name;
			while (gameObject.transform.parent != null)
			{
				gameObject = gameObject.transform.parent.gameObject;
				text = "/" + gameObject.name + text;
			}
			return text;
		}
	}
}
