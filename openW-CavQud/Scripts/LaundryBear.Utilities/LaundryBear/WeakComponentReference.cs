using System;
using UnityEngine;

namespace LaundryBear
{
	[Serializable]
	public class WeakComponentReference
	{
		[SerializeField]
		private string m_path;

		[SerializeField]
		private string m_fullPath;

		[SerializeField]
		private bool m_relative;

		[SerializeField]
		private SerializableSystemType m_type;

		public bool GetReference<T>(out T result) where T : Component
		{
			GameObject gameObject = GameObject.Find(m_fullPath);
			if (gameObject != null)
			{
				return gameObject.TryGetComponent<T>(out result);
			}
			result = null;
			return false;
		}

		public bool GetReference<T>(Transform transform, out T result) where T : Component
		{
			Transform transform2 = transform.Find(m_path);
			if (transform2 != null)
			{
				return transform2.TryGetComponent<T>(out result);
			}
			result = null;
			return false;
		}
	}
}
