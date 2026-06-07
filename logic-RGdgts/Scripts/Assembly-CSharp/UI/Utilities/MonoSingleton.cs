using UnityEngine;

namespace UI.Utilities
{
	public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T _instance;

		public static T instance => null;

		protected virtual void Awake()
		{
		}

		public void InitSingleton()
		{
		}
	}
}
