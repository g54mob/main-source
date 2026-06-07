using UnityEngine;

public class SCC_Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T m_Instance;

	private static readonly object m_Lock = new object();

	public static T Instance
	{
		get
		{
			lock (m_Lock)
			{
				if (m_Instance != null)
				{
					return m_Instance;
				}
				m_Instance = (T)Object.FindObjectOfType(typeof(T));
				if (m_Instance != null)
				{
					return m_Instance;
				}
				GameObject obj = new GameObject();
				m_Instance = obj.AddComponent<T>();
				obj.name = typeof(T).ToString();
				return m_Instance;
			}
		}
	}
}
