using UnityEngine;

namespace Kitchen
{
	public static class GameObjectExtensions
	{
		public static void SetLayer(this GameObject go, int layer)
		{
			Transform[] componentsInChildren = go.GetComponentsInChildren<Transform>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].gameObject.layer = layer;
			}
		}

		public static string GetGameObjectPath(this GameObject obj)
		{
			string text = obj.name;
			while (obj.transform.parent != null)
			{
				obj = obj.transform.parent.gameObject;
				text = "/" + obj.name + text;
			}
			return text;
		}
	}
}
