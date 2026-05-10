using UnityEngine;

namespace RootMotion
{
	public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
	{
		private static T sInstance;

		public static T instance => null;

		public static void Clear()
		{
		}

		protected virtual void Awake()
		{
		}
	}
}
