using GameCreator.Runtime.Cameras;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public static class ShortcutMainShot
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

		public static void Change(ShotCamera shotCamera)
		{
			Instance = ((shotCamera != null) ? shotCamera.gameObject : null);
		}
	}
}
