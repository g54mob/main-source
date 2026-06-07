using System;
using Os.Utils;
using Unity.Mathematics;
using UnityEngine;

namespace Placemaker
{
	[Serializable]
	public struct Orientation
	{
		public int4x4 int4x4;

		public ByteQube cornerTransform0;

		public ByteQube cornerTransform1;

		public ByteQube sideTransform;

		public bool inverted;

		public Matrix4x4 matrix => default(Matrix4x4);

		public byte GetSideTransform0(int index)
		{
			return 0;
		}

		public byte GetSideTransform1(int index)
		{
			return 0;
		}

		public SbyteFloat3 MultiplyPoint(SbyteFloat3 point)
		{
			return default(SbyteFloat3);
		}

		public SbyteFloat3 MultiplyVector(SbyteFloat3 vector)
		{
			return default(SbyteFloat3);
		}

		public int3x2 MultiplyBounds(int3x2 bounds)
		{
			return default(int3x2);
		}
	}
}
