using UnityEngine;

namespace GameKit.Utilities.Types
{
	public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
	{
		private static T _instance;

		public static T Instance => null;
	}
}
