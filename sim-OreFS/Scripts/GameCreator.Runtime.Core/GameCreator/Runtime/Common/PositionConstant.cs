using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public readonly struct PositionConstant : IPosition
	{
		[NonSerialized]
		private readonly Vector3 m_Position;

		public PositionConstant(Vector3 position)
		{
			m_Position = position;
		}

		public bool HasPosition(GameObject user)
		{
			return true;
		}

		public Vector3 GetPosition(GameObject source)
		{
			return m_Position;
		}
	}
}
