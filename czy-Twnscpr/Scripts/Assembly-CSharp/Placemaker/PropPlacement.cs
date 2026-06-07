using System;
using Os.Utils;
using UnityEngine;

namespace Placemaker
{
	[Serializable]
	public struct PropPlacement
	{
		public SbyteFloat3 pos;

		public ByteFloat3 scale;

		public ByteFloat3 rotationByte;

		private const float byteToAngle = 1.40625f;

		private const float angleToByte = 32f / 45f;

		public Prop prop;

		public sbyte corner;

		public byte prioAdd;

		public Vector3 rotation
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Matrix4x4 GetMatrix()
		{
			return default(Matrix4x4);
		}
	}
}
