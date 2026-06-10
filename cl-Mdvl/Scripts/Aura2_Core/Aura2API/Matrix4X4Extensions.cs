using UnityEngine;

namespace Aura2API
{
	public static class Matrix4X4Extensions
	{
		public static MatrixFloats ToAuraMatrixFloats(this Matrix4x4 matrix)
		{
			return MatrixFloats.ToMatrixFloats(matrix);
		}

		public static void ToFloatArray(this Matrix4x4 matrix, ref float[] floatsArrayToFill)
		{
			floatsArrayToFill[0] = matrix[0, 0];
			floatsArrayToFill[1] = matrix[1, 0];
			floatsArrayToFill[2] = matrix[2, 0];
			floatsArrayToFill[3] = matrix[3, 0];
			floatsArrayToFill[4] = matrix[0, 1];
			floatsArrayToFill[5] = matrix[1, 1];
			floatsArrayToFill[6] = matrix[2, 1];
			floatsArrayToFill[7] = matrix[3, 1];
			floatsArrayToFill[8] = matrix[0, 2];
			floatsArrayToFill[9] = matrix[1, 2];
			floatsArrayToFill[10] = matrix[2, 2];
			floatsArrayToFill[11] = matrix[3, 2];
			floatsArrayToFill[12] = matrix[0, 3];
			floatsArrayToFill[13] = matrix[1, 3];
			floatsArrayToFill[14] = matrix[2, 3];
			floatsArrayToFill[15] = matrix[3, 3];
		}
	}
}
