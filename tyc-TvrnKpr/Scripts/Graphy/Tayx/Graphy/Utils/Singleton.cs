using UnityEngine;

namespace Tayx.Graphy.Utils
{
	public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T _instance;

		private static object _lock;

		private static bool _applicationIsQuitting;

		public static T Instance => null;

		private void Awake()
		{
		}

		public void OnDestroy()
		{
		}
	}
}
