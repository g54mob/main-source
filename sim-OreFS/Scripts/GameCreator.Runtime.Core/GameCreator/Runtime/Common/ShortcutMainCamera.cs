using GameCreator.Runtime.Cameras;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public static class ShortcutMainCamera
	{
		private static GameObject _Instance;

		public static GameObject Instance
		{
			get
			{
				if (_Instance == null)
				{
					LocateCamera();
				}
				return _Instance;
			}
			private set
			{
				_Instance = value;
			}
		}

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

		public static void Change(TCamera camera)
		{
			Instance = ((camera != null) ? camera.gameObject : null);
		}

		private static void LocateCamera()
		{
			if (_Instance != null)
			{
				return;
			}
			GameObject gameObject = GameObject.FindWithTag("MainCamera");
			if (gameObject != null)
			{
				_Instance = gameObject;
				return;
			}
			Camera camera = Object.FindAnyObjectByType<Camera>();
			if (camera != null)
			{
				_Instance = camera.gameObject;
			}
			else
			{
				Debug.LogWarning("No 'Main Camera' found");
			}
		}
	}
}
