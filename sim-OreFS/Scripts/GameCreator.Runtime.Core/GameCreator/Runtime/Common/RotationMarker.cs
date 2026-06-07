using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public readonly struct RotationMarker : IRotation
	{
		[NonSerialized]
		private readonly Marker m_Marker;

		public RotationMarker(Marker marker)
		{
			m_Marker = marker;
		}

		public bool HasRotation(GameObject source)
		{
			return m_Marker != null;
		}

		public Quaternion GetRotation(GameObject source)
		{
			return m_Marker.GetRotation(source);
		}
	}
}
