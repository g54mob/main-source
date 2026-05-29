using UnityEngine;

namespace Libs
{
	public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T _instance;

		public static T Instance => null;

		public static T InstanceNullable => null;

		protected void InitInstance()
		{
		}

		public static bool IsMultiple(T ins)
		{
			return false;
		}

		protected virtual void OnDestroy()
		{
		}
	}
}
