using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public readonly struct PositionMarker : IPosition
	{
		[NonSerialized]
		private readonly Marker m_Marker;

		public PositionMarker(Marker marker)
		{
			m_Marker = marker;
		}

		public bool HasPosition(GameObject user)
		{
			if (user != null)
			{
				return m_Marker != null;
			}
			return false;
		}

		public Vector3 GetPosition(GameObject source)
		{
			return m_Marker.GetPosition(source);
		}
	}
}
