using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public readonly struct RotationOpposite : IRotation
	{
		[NonSerialized]
		private readonly Transform m_Transform;

		public RotationOpposite(Transform transform)
		{
			m_Transform = transform;
		}

		public bool HasRotation(GameObject source)
		{
			if (source != null)
			{
				return m_Transform != null;
			}
			return false;
		}

		public Quaternion GetRotation(GameObject source)
		{
			return m_Transform.rotation * Quaternion.Euler(0f, 180f, 0f);
		}
	}
}
