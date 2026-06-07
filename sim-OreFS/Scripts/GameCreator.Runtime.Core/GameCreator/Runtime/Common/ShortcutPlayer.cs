using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public static class ShortcutPlayer
	{
		public static GameObject Instance { get; private set; }

		public static Transform Transform
		{
			get
			{
				if (!(Instance != null))
				{
					return null;
				}
				return Instance.transform;
			}
		}

		public static TComponent Get<TComponent>() where TComponent : Component
		{
			if (!(Instance != null))
			{
				return null;
			}
			return Instance.Get<TComponent>();
		}

		public static void Change(GameObject player)
		{
			Instance = player;
		}
	}
}
