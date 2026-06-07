using UnityEngine;

namespace Gh
{
	public class SingletonScriptableObjectAsset<T> : ScriptableObject where T : ScriptableObject
	{
		private static T _instance;

		public static T Instance => null;
	}
}
