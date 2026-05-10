using UnityEngine;

namespace MyBox
{
	public abstract class Singleton<T> : MonoBehaviour
	{
		private static T _instance;

		public static T Instance => default(T);

		protected void InitializeSingleton(bool persistent = true)
		{
		}
	}
}
