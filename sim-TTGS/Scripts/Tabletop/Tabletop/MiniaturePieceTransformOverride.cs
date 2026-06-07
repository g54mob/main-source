using System;
using UnityEngine;

namespace Tabletop
{
	[Serializable]
	public struct MiniaturePieceTransformOverride
	{
		[SerializeField]
		private bool m_override;

		[SerializeField]
		private Vector3 m_localPositionOffset;

		[SerializeField]
		private Vector3 m_localRotationOffset;

		public bool HasOverride(out Vector3 localPos, out Vector3 localRot)
		{
			if (m_override)
			{
				localPos = m_localPositionOffset;
				localRot = m_localRotationOffset;
				return true;
			}
			localPos = Vector3.zero;
			localRot = Vector3.zero;
			return false;
		}
	}
}
