using UnityEngine;

namespace HQFPSTemplate
{
	public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T m_Instance;

		public static T Instance
		{
			get
			{
				if (m_Instance == null)
				{
					m_Instance = Object.FindObjectOfType<T>();
				}
				return m_Instance;
			}
		}

		protected virtual void Awake()
		{
			if (m_Instance != null && m_Instance != this as T)
			{
				Object.Destroy(base.gameObject);
			}
			else
			{
				m_Instance = this as T;
			}
		}
	}
}
