using System;
using UnityEngine;

namespace VRM
{
	[Serializable]
	public struct OffsetOnTransform
	{
		public Transform Transform;

		public Matrix4x4 OffsetRotation;

		private Matrix4x4 m_initialLocalMatrix;

		public Matrix4x4 WorldMatrix
		{
			get
			{
				if (Transform == null)
				{
					return Matrix4x4.identity;
				}
				return Transform.localToWorldMatrix * OffsetRotation;
			}
		}

		public Vector3 WorldForward => WorldMatrix.GetColumn(2);

		public Matrix4x4 InitialWorldMatrix => Transform.parent.localToWorldMatrix * m_initialLocalMatrix;

		public void Setup()
		{
			if (!(Transform == null))
			{
				m_initialLocalMatrix = Transform.parent.worldToLocalMatrix * Transform.localToWorldMatrix;
			}
		}

		public static OffsetOnTransform Create(Transform transform)
		{
			OffsetOnTransform result = new OffsetOnTransform
			{
				Transform = transform
			};
			if (transform != null)
			{
				result.OffsetRotation = transform.worldToLocalMatrix.RotationToWorldAxis();
			}
			return result;
		}
	}
}
