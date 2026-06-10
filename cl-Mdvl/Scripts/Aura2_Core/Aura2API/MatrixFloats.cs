using UnityEngine;

namespace Aura2API
{
	public struct MatrixFloats
	{
		public Vector4 a;

		public Vector4 b;

		public Vector4 c;

		public Vector4 d;

		private static int _byteSize;

		private static MatrixFloats _tmpMatrixFloats;

		public static int Size
		{
			get
			{
				if (_byteSize == 0)
				{
					_byteSize = 64;
				}
				return _byteSize;
			}
		}

		public static MatrixFloats ToMatrixFloats(Matrix4x4 matrix)
		{
			_tmpMatrixFloats.a = matrix.GetColumn(0);
			_tmpMatrixFloats.b = matrix.GetColumn(1);
			_tmpMatrixFloats.c = matrix.GetColumn(2);
			_tmpMatrixFloats.d = matrix.GetColumn(3);
			return _tmpMatrixFloats;
		}
	}
}
