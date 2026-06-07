using UnityEngine;

namespace ModApi.Common.Extensions
{
	public static class GameObjectExtensions
	{
		public static T AddMissingComponent<T>(this GameObject obj) where T : Component
		{
			T val = obj.GetComponent<T>();
			if (val == null)
			{
				val = obj.AddComponent<T>();
			}
			return val;
		}

		public static GameObject LocalPosition(this GameObject obj, Vector3 position)
		{
			obj.transform.localPosition = position;
			return obj;
		}

		public static GameObject LocalRotation(this GameObject obj, Quaternion rotation)
		{
			obj.transform.localRotation = rotation;
			return obj;
		}

		public static GameObject Name(this GameObject obj, string name, params object[] args)
		{
			obj.name = ((args == null || args.Length == 0) ? name : string.Format(name, args));
			return obj;
		}

		public static GameObject Position(this GameObject obj, Vector3 position)
		{
			obj.transform.position = position;
			return obj;
		}

		public static GameObject Rotation(this GameObject obj, Quaternion rotation)
		{
			obj.transform.rotation = rotation;
			return obj;
		}

		public static GameObject Rotation(this GameObject obj, Vector3 scale)
		{
			obj.transform.localScale = scale;
			return obj;
		}

		public static void SetLayer(this GameObject gameObject, int layer)
		{
			gameObject.layer = layer;
			foreach (Transform item in gameObject.transform)
			{
				item.gameObject.SetLayer(layer);
			}
		}
	}
}
