using UnityEngine;

namespace Helpers.Singletons
{
	public class SingletonScriptableObject<T> : ScriptableObject where T : SingletonScriptableObject<T>
	{
		private static bool applicationQuit;

		private static T instance;

		public static string AssetPath => typeof(T).ToString().Replace('.', '/');

		public static T Instance
		{
			get
			{
				if (instance == null && !applicationQuit)
				{
					instance = Resources.Load<T>(AssetPath);
					if (instance == null)
					{
						Debug.LogError(typeof(T).Name + " cannot be instanced.");
					}
				}
				return instance;
			}
		}

		public static bool IsInstanced => instance;

		protected virtual void OnApplicationQuit()
		{
			applicationQuit = true;
		}
	}
}
