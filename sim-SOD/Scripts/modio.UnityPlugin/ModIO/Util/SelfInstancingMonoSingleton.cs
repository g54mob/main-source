using UnityEngine;

namespace ModIO.Util
{
	public class SelfInstancingMonoSingleton<T> : MonoBehaviour, ISimpleMonoSingleton where T : MonoBehaviour
	{
		protected static T _instance;

		public static T Instance
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		protected virtual void Awake()
		{
		}

		public void SetupSingleton()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		protected virtual void OnApplicationQuit()
		{
		}

		public static bool SingletonIsInstantiated()
		{
			return false;
		}
	}
}
