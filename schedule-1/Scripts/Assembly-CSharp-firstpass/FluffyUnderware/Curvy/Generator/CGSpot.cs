using System;
using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator
{
	[Serializable]
	public struct CGSpot : IEquatable<CGSpot>
	{
		[SerializeField]
		[Label("Index", null)]
		private int m_Index;

		[SerializeField]
		[VectorEx("Position", null, Options = AttributeOptionsFlags.Compact, Precision = 4)]
		private Vector3 m_Position;

		[SerializeField]
		[VectorEx("Rotation", null, Options = AttributeOptionsFlags.Compact, Precision = 4)]
		private Quaternion m_Rotation;

		[VectorEx("Scale", null, Options = AttributeOptionsFlags.Compact, Precision = 4)]
		[SerializeField]
		private Vector3 m_Scale;

		public int Index => 0;

		public Vector3 Position
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Quaternion Rotation
		{
			get
			{
				return default(Quaternion);
			}
			set
			{
			}
		}

		public Vector3 Scale
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Matrix4x4 Matrix => default(Matrix4x4);

		public CGSpot(int index)
		{
			m_Index = 0;
			m_Position = default(Vector3);
			m_Rotation = default(Quaternion);
			m_Scale = default(Vector3);
		}

		public CGSpot(int index, Vector3 position, Quaternion rotation, Vector3 scale)
		{
			m_Index = 0;
			m_Position = default(Vector3);
			m_Rotation = default(Quaternion);
			m_Scale = default(Vector3);
		}

		public void ToTransform(Transform transform)
		{
		}

		public bool Equals(CGSpot other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(CGSpot left, CGSpot right)
		{
			return false;
		}

		public static bool operator !=(CGSpot left, CGSpot right)
		{
			return false;
		}
	}
}
