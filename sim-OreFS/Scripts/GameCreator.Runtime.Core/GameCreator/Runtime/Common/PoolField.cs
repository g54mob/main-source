using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class PoolField
	{
		[SerializeField]
		private GameObject m_Prefab;

		[SerializeField]
		private EnablerInt m_UsePooling = new EnablerInt(isEnabled: false, 5);

		[SerializeField]
		private EnablerFloat m_Duration = new EnablerFloat(isEnabled: false, 10f);

		public GameObject Create(Vector3 position, Quaternion rotation, Transform parent)
		{
			if (m_Prefab == null)
			{
				return null;
			}
			GameObject gameObject;
			if (m_UsePooling.IsEnabled)
			{
				gameObject = Singleton<PoolManager>.Instance.Pick(m_Prefab, position, rotation, m_UsePooling.Value, m_Duration.IsEnabled ? m_Duration.Value : (-1f));
				if (parent != null)
				{
					gameObject.transform.SetParent(parent);
				}
			}
			else
			{
				gameObject = UnityEngine.Object.Instantiate(m_Prefab, position, rotation, parent);
			}
			return gameObject;
		}
	}
}
