using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public readonly struct RotationConstant : IRotation
	{
		[NonSerialized]
		private readonly Quaternion m_Rotation;

		public RotationConstant(Quaternion rotation)
		{
			m_Rotation = rotation;
		}

		public bool HasRotation(GameObject source)
		{
			return true;
		}

		public Quaternion GetRotation(GameObject source)
		{
			return m_Rotation;
		}
	}
}
