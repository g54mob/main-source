using UnityEngine;

namespace Dreamteck
{
	public class Singleton<T> : MonoBehaviour where T : Component
	{
		[SerializeField]
		private bool _dontDestryOnLoad;

		[SerializeField]
		private bool _overrideInstance;

		protected static T _instance;

		public static T instance => null;

		protected virtual void Awake()
		{
		}

		protected virtual void Init()
		{
		}

		protected virtual void OnDestroy()
		{
		}
	}
}
