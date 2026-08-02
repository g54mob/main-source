using UnityEngine;

namespace HQFPSTemplate
{
	public class AssetSingleton<T> : ScriptableObject where T : Object
	{
		private static T m_Instance;

		public static T Instance
		{
			get
			{
				if (m_Instance == null)
				{
					T[] array = Resources.LoadAll<T>("");
					if (array != null && array.Length != 0)
					{
						m_Instance = array[0];
					}
				}
				return m_Instance;
			}
		}
	}
}
