using ClipperLib;
using SimplySVG;
using UnityEngine;

public class MatrixUtils
{
	public static Matrix Transform(float a, float b, float c, float d, float e, float f)
	{
		Matrix matrix = Matrix.IdentityMatrix(3, 3);
		matrix[0, 0] = a;
		matrix[1, 0] = b;
		matrix[0, 1] = c;
		matrix[1, 1] = d;
		matrix[0, 2] = e;
		matrix[1, 2] = f;
		return matrix;
	}

	public static Matrix Translate(float x, float y = 0f)
	{
		Matrix matrix = Matrix.IdentityMatrix(3, 3);
		matrix[0, 2] = x;
		matrix[1, 2] = y;
		return matrix;
	}

	public static Matrix Rotate(float a)
	{
		Matrix matrix = Matrix.IdentityMatrix(3, 3);
		matrix[0, 0] = Mathf.Cos(a);
		matrix[1, 0] = Mathf.Sin(a);
		matrix[0, 1] = 0f - Mathf.Sin(a);
		matrix[1, 1] = Mathf.Cos(a);
		return matrix;
	}

	public static Matrix Scale(float x, float y)
	{
		Matrix matrix = Matrix.IdentityMatrix(3, 3);
		matrix[0, 0] = x;
		matrix[1, 1] = y;
		return matrix;
	}

	public static Matrix SkewX(float a)
	{
		Matrix matrix = Matrix.IdentityMatrix(3, 3);
		matrix[0, 1] = Mathf.Tan(a);
		return matrix;
	}

	public static Matrix SkewY(float a)
	{
		Matrix matrix = Matrix.IdentityMatrix(3, 3);
		matrix[1, 0] = Mathf.Tan(a);
		return matrix;
	}

	public static IntPoint MultiplyScaledClipperPoint(Matrix matrix, IntPoint point)
	{
		Matrix matrix2 = Matrix.IdentityMatrix(3, 3);
		matrix2[0, 2] = (double)point.X / GraphicalElement.clipperCoordinateScale;
		matrix2[1, 2] = (double)point.Y / GraphicalElement.clipperCoordinateScale;
		matrix2 = matrix * matrix2;
		point.X = (long)(matrix2[0, 2] * GraphicalElement.clipperCoordinateScale);
		point.Y = (long)(matrix2[1, 2] * GraphicalElement.clipperCoordinateScale);
		return point;
	}
}
