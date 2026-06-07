using UnityEngine;

namespace Helios.GUI
{
	public class SingletonMono<T> : MonoBehaviour where T : Component
	{
		private static T _instance;

		public static T Instance => null;

		protected virtual void OnDestroy()
		{
		}

		protected virtual void OnApplicationQuit()
		{
		}

		public static bool IsNull()
		{
			return false;
		}
	}
}
