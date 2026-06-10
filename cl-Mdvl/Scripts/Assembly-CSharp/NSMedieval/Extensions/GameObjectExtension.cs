using System.Collections.Generic;
using UnityEngine;

namespace NSMedieval.Extensions
{
	public static class GameObjectExtension
	{
		public static List<Transform> GetChildren(this GameObject gameObject)
		{
			List<Transform> list = new List<Transform>();
			int childCount = gameObject.transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				list.Add(gameObject.transform.GetChild(i));
			}
			return list;
		}

		public static List<GameObject> GetChildrenObjects(this GameObject gameObject)
		{
			List<GameObject> list = new List<GameObject>();
			int childCount = gameObject.transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				list.Add(gameObject.transform.GetChild(i).gameObject);
			}
			return list;
		}

		public static List<Vector3> GetChildrenPositions(this GameObject gameObject)
		{
			List<Vector3> list = new List<Vector3>();
			int childCount = gameObject.transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				list.Add(gameObject.transform.GetChild(i).transform.position);
			}
			return list;
		}

		public static string GetClearName(this GameObject gameObject)
		{
			string text = gameObject.name;
			if (gameObject.name.Contains("(Clone)"))
			{
				text = text.Remove(text.Length - 7);
			}
			return text;
		}

		public static void SetClearName(this GameObject gameObject)
		{
			string text = gameObject.name;
			if (gameObject.name.Contains("(Clone)"))
			{
				text = text.Remove(text.Length - 7);
			}
			gameObject.name = text;
		}

		public static bool ContainsTags(this GameObject gameObject, string[] tags)
		{
			foreach (string tag in tags)
			{
				if (gameObject.CompareTag(tag))
				{
					return true;
				}
			}
			return false;
		}
	}
}
