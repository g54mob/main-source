using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class ObjectCloning
	{
		[Flags]
		public enum TransformFlags
		{
			None = 0,
			Position = 1,
			Rotation = 2,
			Scale = 4,
			All = 7
		}

		public struct Config
		{
			public Transform Parent;

			public TransformFlags TransformFlags;

			public int Layer;
		}

		private static Config _defaultConfig;

		public static Config DefaultConfig => _defaultConfig;

		static ObjectCloning()
		{
			_defaultConfig = default(Config);
			_defaultConfig.TransformFlags = TransformFlags.All;
			_defaultConfig.Layer = 0;
		}

		public static List<GameObject> CloneHierarchies(List<GameObject> roots, Config cloneConfig)
		{
			if (roots.Count == 0)
			{
				return new List<GameObject>();
			}
			List<GameObject> list = new List<GameObject>(roots.Count);
			foreach (GameObject root in roots)
			{
				GameObject gameObject = CloneHierarchy(root, cloneConfig);
				if (gameObject != null)
				{
					list.Add(gameObject);
				}
			}
			return list;
		}

		public static GameObject CloneHierarchy(GameObject root, Config cloneConfig)
		{
			if (root == null)
			{
				return null;
			}
			Transform transform = root.transform;
			Vector3 position = Vector3.zero;
			Quaternion rotation = Quaternion.identity;
			Vector3 localScale = Vector3.one;
			if ((cloneConfig.TransformFlags & TransformFlags.Position) != TransformFlags.None)
			{
				position = transform.position;
			}
			if ((cloneConfig.TransformFlags & TransformFlags.Rotation) != TransformFlags.None)
			{
				rotation = transform.rotation;
			}
			if ((cloneConfig.TransformFlags & TransformFlags.Scale) != TransformFlags.None)
			{
				localScale = transform.lossyScale;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(root, position, rotation);
			gameObject.name = root.name;
			gameObject.layer = cloneConfig.Layer;
			Transform transform2 = gameObject.transform;
			transform2.localScale = localScale;
			transform2.parent = cloneConfig.Parent;
			return gameObject;
		}
	}
}
