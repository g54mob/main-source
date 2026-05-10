using UnityEngine;

namespace PG
{
	public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
	{
		[SerializeField]
		private bool dontDestroyOnLoad;

		private static T _Instance;

		public static T Instance => null;

		private void Awake()
		{
		}

		protected virtual void AwakeSingleton()
		{
		}
	}
}
