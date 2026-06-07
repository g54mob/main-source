using UnityEngine;

namespace com.ootii.Base
{
	public class Singleton<T> : MonoBehaviour where T : Component
	{
		private static T m_Instance;

		public static T Instance => null;

		public virtual void Awake()
		{
		}
	}
}
