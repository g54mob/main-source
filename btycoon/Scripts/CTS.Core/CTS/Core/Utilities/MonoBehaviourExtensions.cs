using UnityEngine;

namespace CTS.Core.Utilities
{
	public static class MonoBehaviourExtensions
	{
		public static TComponent GetOrAddComponent<TComponent>(this MonoBehaviour p_behaviour) where TComponent : Component
		{
			if (p_behaviour.TryGetComponent<TComponent>(out var component))
			{
				return component;
			}
			return p_behaviour.gameObject.AddComponent<TComponent>();
		}

		public static bool Singleton<T>(this T mono, ref T instance) where T : MonoBehaviour
		{
			if (instance == null)
			{
				instance = mono;
				return true;
			}
			Object.Destroy(mono.gameObject);
			return false;
		}

		public static bool PersistentSingleton<T>(this T mono, ref T instance) where T : MonoBehaviour
		{
			if (instance == null)
			{
				instance = mono;
				Object.DontDestroyOnLoad(mono.gameObject);
				return true;
			}
			Object.Destroy(mono.gameObject);
			return false;
		}
	}
}
