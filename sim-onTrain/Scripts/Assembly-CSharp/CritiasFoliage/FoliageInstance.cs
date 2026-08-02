using System;
using UnityEngine;

namespace CritiasFoliage
{
	public struct FoliageInstance
	{
		public Vector3 m_Position;

		public Quaternion m_Rotation;

		public Vector3 m_Scale;

		public Matrix4x4 m_Matrix;

		public Bounds m_Bounds;

		public Guid m_UniqueId;

		public Matrix4x4 GetWorldTransform()
		{
			return Matrix4x4.TRS(m_Position, m_Rotation, m_Scale);
		}

		public void BuildWorldMatrix()
		{
			m_Matrix = GetWorldTransform();
		}
	}
}
