using UnityEngine;

namespace Sirenix.Utilities
{
	public abstract class GlobalConfig<T> : ScriptableObject, IGlobalConfigEvents where T : GlobalConfig<T>, new()
	{
		private static GlobalConfigAttribute configAttribute;

		private static T instance;

		public static GlobalConfigAttribute ConfigAttribute => null;

		public static bool HasInstanceLoaded => false;

		public static T Instance => null;

		public static void LoadInstanceIfAssetExists()
		{
		}

		public void OpenInEditor()
		{
		}

		protected virtual void OnConfigInstanceFirstAccessed()
		{
		}

		protected virtual void OnConfigAutoCreated()
		{
		}

		void IGlobalConfigEvents.OnConfigAutoCreated()
		{
		}

		void IGlobalConfigEvents.OnConfigInstanceFirstAccessed()
		{
		}
	}
}
