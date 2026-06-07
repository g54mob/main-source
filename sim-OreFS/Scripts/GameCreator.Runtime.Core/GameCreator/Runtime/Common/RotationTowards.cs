using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public readonly struct RotationTowards : IRotation
	{
		[NonSerialized]
		private readonly Transform m_Transform;

		public RotationTowards(Transform transform)
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
			Vector3 vector = m_Transform.position - source.transform.position;
			if (source.Get<Character>() != null)
			{
				vector = Vector3.Scale(vector, Vector3Plane.NormalUp);
			}
			return Quaternion.LookRotation(vector);
		}
	}
}
