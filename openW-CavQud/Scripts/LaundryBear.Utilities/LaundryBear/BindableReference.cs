using System;
using UnityEngine;

namespace LaundryBear
{
	[Serializable]
	public class BindableReference<T> where T : Component
	{
		[SerializeField]
		private bool m_isRelative;

		[SerializeField]
		private string m_gameObjectPath;

		private T m_runtimeReference;

		public T Value => m_runtimeReference;

		public bool TryGetBindableReference(Transform transform)
		{
			if (m_isRelative)
			{
				Transform transform2 = transform.Find(m_gameObjectPath);
				if (transform2 != null)
				{
					return transform2.TryGetComponent<T>(out m_runtimeReference);
				}
				return false;
			}
			GameObject gameObject = GameObject.Find(m_gameObjectPath);
			if (gameObject != null)
			{
				return gameObject.TryGetComponent<T>(out m_runtimeReference);
			}
			return false;
		}
	}
}
