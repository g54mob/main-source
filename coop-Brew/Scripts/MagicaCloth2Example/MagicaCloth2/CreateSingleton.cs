using UnityEngine;

namespace MagicaCloth2
{
	public abstract class CreateSingleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T instance;

		private static T initInstance;

		private static bool isDestroy;

		public static T Instance => null;

		protected static void InitMember()
		{
		}

		private static void InitInstance()
		{
		}

		public static bool IsInstance()
		{
			return false;
		}

		protected virtual void Awake()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		protected virtual void DuplicateDetection(T duplicate)
		{
		}

		protected abstract void InitSingleton();
	}
}
