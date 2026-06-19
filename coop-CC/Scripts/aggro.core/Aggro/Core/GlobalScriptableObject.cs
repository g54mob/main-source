using UnityEngine;

namespace Aggro.Core
{
	public abstract class GlobalScriptableObject<T> : ScriptableObject, IGlobalScriptableObject where T : GlobalScriptableObject<T>
	{
		private static T _instance;

		public static T instance => _instance;

		public void SetSingleton()
		{
			_instance = (T)this;
		}

		public static bool Exists()
		{
			return (object)_instance != null;
		}
	}
}
