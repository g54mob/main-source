using UnityEngine;

namespace ClockStone
{
	public class UnitySingleton<T> where T : MonoBehaviour
	{
		private static T _instance;

		internal static GameObject _autoCreatePrefab;

		private static int _GlobalInstanceCount;

		private static bool _awakeSingletonCalled;

		public static T GetSingleton(bool throwErrorIfNotFound, bool autoCreate, bool searchInObjectHierarchy = true)
		{
			return null;
		}

		private UnitySingleton()
		{
		}

		internal static void _Awake(T instance)
		{
		}

		internal static void _Destroy()
		{
		}

		private static void _AwakeSingleton(T instance)
		{
		}
	}
}
