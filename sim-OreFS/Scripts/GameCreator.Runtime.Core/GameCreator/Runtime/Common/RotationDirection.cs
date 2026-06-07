using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public readonly struct RotationDirection : IRotation
	{
		[NonSerialized]
		private readonly Vector3 m_Position;

		public RotationDirection(Vector3 position)
		{
			m_Position = position;
		}

		public bool HasRotation(GameObject source)
		{
			return source != null;
		}

		public Quaternion GetRotation(GameObject source)
		{
			return Quaternion.LookRotation(m_Position - source.transform.position, source.transform.up);
		}
	}
}
