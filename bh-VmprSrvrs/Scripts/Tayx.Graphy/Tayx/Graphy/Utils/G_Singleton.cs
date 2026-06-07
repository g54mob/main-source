using UnityEngine;

namespace Tayx.Graphy.Utils
{
	public class G_Singleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T _instance;

		private static object _lock;

		public static T Instance => null;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
