using UnityEngine;

namespace RootMotion
{
	public abstract class LazySingleton<T> : MonoBehaviour where T : LazySingleton<T>
	{
		private static T sInstance;

		public static bool hasInstance => false;

		public static T instance => null;

		protected virtual void Awake()
		{
		}
	}
}
