using UnityEngine;

namespace Pathfinding.Util
{
	public class GraphTransform : IMovementPlane, ITransform
	{
		private bool isXY;

		private bool isXZ;

		private bool isOnlyTranslational;

		private bool isIdentity;

		private Vector3 up;

		private Vector3 translation;

		private Int3 i3translation;

		private Quaternion inverseRotation;

		public static readonly GraphTransform identityTransform = new GraphTransform(Matrix4x4.identity);

		public static readonly GraphTransform xyPlane = new GraphTransform(Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(-90f, 0f, 0f), Vector3.one));

		public static readonly GraphTransform xzPlane = new GraphTransform(Matrix4x4.identity);

		public bool identity => isIdentity;

		public bool onlyTranslational => isOnlyTranslational;

		public Matrix4x4 matrix { get; private set; }

		public Matrix4x4 inverseMatrix { get; private set; }

		public Quaternion rotation { get; private set; }

		public GraphTransform(Matrix4x4 matrix)
		{
			Set(matrix);
		}

		protected void Set(Matrix4x4 matrix)
		{
			this.matrix = matrix;
			inverseMatrix = matrix.inverse;
			isIdentity = matrix.isIdentity;
			isOnlyTranslational = MatrixIsTranslational(matrix);
			up = matrix.MultiplyVector(Vector3.up).normalized;
			translation = matrix.MultiplyPoint3x4(Vector3.zero);
			i3translation = (Int3)translation;
			rotation = Quaternion.LookRotation(TransformVector(Vector3.forward), TransformVector(Vector3.up));
			inverseRotation = Quaternion.Inverse(rotation);
			isXY = rotation == Quaternion.Euler(-90f, 0f, 0f);
			isXZ = rotation == Quaternion.Euler(0f, 0f, 0f);
		}

		public Vector3 WorldUpAtGraphPosition(Vector3 point)
		{
			return up;
		}

		private static bool MatrixIsTranslational(Matrix4x4 matrix)
		{
			if (matrix.GetColumn(0) == new Vector4(1f, 0f, 0f, 0f) && matrix.GetColumn(1) == new Vector4(0f, 1f, 0f, 0f) && matrix.GetColumn(2) == new Vector4(0f, 0f, 1f, 0f))
			{
				return matrix.m33 == 1f;
			}
			return false;
		}

		public Vector3 Transform(Vector3 point)
		{
			if (onlyTranslational)
			{
				return point + translation;
			}
			return matrix.MultiplyPoint3x4(point);
		}

		public Vector3 TransformVector(Vector3 dir)
		{
			if (onlyTranslational)
			{
				return dir;
			}
			return matrix.MultiplyVector(dir);
		}

		public void Transform(Int3[] arr)
		{
			if (onlyTranslational)
			{
				for (int num = arr.Length - 1; num >= 0; num--)
				{
					arr[num] += i3translation;
				}
			}
			else
			{
				for (int num2 = arr.Length - 1; num2 >= 0; num2--)
				{
					arr[num2] = (Int3)matrix.MultiplyPoint3x4((Vector3)arr[num2]);
				}
			}
		}

		public void Transform(UnsafeSpan<Int3> arr)
		{
			if (onlyTranslational)
			{
				for (int num = arr.Length - 1; num >= 0; num--)
				{
					arr[num] += i3translation;
				}
			}
			else
			{
				for (int num2 = arr.Length - 1; num2 >= 0; num2--)
				{
					arr[num2] = (Int3)matrix.MultiplyPoint3x4((Vector3)arr[num2]);
				}
			}
		}

		public void Transform(Vector3[] arr)
		{
			if (onlyTranslational)
			{
				for (int num = arr.Length - 1; num >= 0; num--)
				{
					arr[num] += translation;
				}
			}
			else
			{
				for (int num2 = arr.Length - 1; num2 >= 0; num2--)
				{
					arr[num2] = matrix.MultiplyPoint3x4(arr[num2]);
				}
			}
		}

		public Vector3 InverseTransform(Vector3 point)
		{
			if (onlyTranslational)
			{
				return point - translation;
			}
			return inverseMatrix.MultiplyPoint3x4(point);
		}

		public Vector3 InverseTransformVector(Vector3 dir)
		{
			if (onlyTranslational)
			{
				return dir;
			}
			return inverseMatrix.MultiplyVector(dir);
		}

		public Int3 InverseTransform(Int3 point)
		{
			if (onlyTranslational)
			{
				return point - i3translation;
			}
			return (Int3)inverseMatrix.MultiplyPoint3x4((Vector3)point);
		}

		public void InverseTransform(Int3[] arr)
		{
			for (int num = arr.Length - 1; num >= 0; num--)
			{
				arr[num] = (Int3)inverseMatrix.MultiplyPoint3x4((Vector3)arr[num]);
			}
		}

		public void InverseTransform(UnsafeSpan<Int3> arr)
		{
			for (int num = arr.Length - 1; num >= 0; num--)
			{
				arr[num] = (Int3)inverseMatrix.MultiplyPoint3x4((Vector3)arr[num]);
			}
		}

		public static GraphTransform operator *(GraphTransform lhs, Matrix4x4 rhs)
		{
			return new GraphTransform(lhs.matrix * rhs);
		}

		public static GraphTransform operator *(Matrix4x4 lhs, GraphTransform rhs)
		{
			return new GraphTransform(lhs * rhs.matrix);
		}

		public Bounds Transform(Bounds bounds)
		{
			if (onlyTranslational)
			{
				return new Bounds(bounds.center + translation, bounds.size);
			}
			Vector3[] array = ArrayPool<Vector3>.Claim(8);
			Vector3 extents = bounds.extents;
			array[0] = Transform(bounds.center + new Vector3(extents.x, extents.y, extents.z));
			array[1] = Transform(bounds.center + new Vector3(extents.x, extents.y, 0f - extents.z));
			array[2] = Transform(bounds.center + new Vector3(extents.x, 0f - extents.y, extents.z));
			array[3] = Transform(bounds.center + new Vector3(extents.x, 0f - extents.y, 0f - extents.z));
			array[4] = Transform(bounds.center + new Vector3(0f - extents.x, extents.y, extents.z));
			array[5] = Transform(bounds.center + new Vector3(0f - extents.x, extents.y, 0f - extents.z));
			array[6] = Transform(bounds.center + new Vector3(0f - extents.x, 0f - extents.y, extents.z));
			array[7] = Transform(bounds.center + new Vector3(0f - extents.x, 0f - extents.y, 0f - extents.z));
			Vector3 vector = array[0];
			Vector3 vector2 = array[0];
			for (int i = 1; i < 8; i++)
			{
				vector = Vector3.Min(vector, array[i]);
				vector2 = Vector3.Max(vector2, array[i]);
			}
			ArrayPool<Vector3>.Release(ref array);
			return new Bounds((vector + vector2) * 0.5f, vector2 - vector);
		}

		public Bounds InverseTransform(Bounds bounds)
		{
			if (onlyTranslational)
			{
				return new Bounds(bounds.center - translation, bounds.size);
			}
			Vector3[] array = ArrayPool<Vector3>.Claim(8);
			Vector3 extents = bounds.extents;
			array[0] = InverseTransform(bounds.center + new Vector3(extents.x, extents.y, extents.z));
			array[1] = InverseTransform(bounds.center + new Vector3(extents.x, extents.y, 0f - extents.z));
			array[2] = InverseTransform(bounds.center + new Vector3(extents.x, 0f - extents.y, extents.z));
			array[3] = InverseTransform(bounds.center + new Vector3(extents.x, 0f - extents.y, 0f - extents.z));
			array[4] = InverseTransform(bounds.center + new Vector3(0f - extents.x, extents.y, extents.z));
			array[5] = InverseTransform(bounds.center + new Vector3(0f - extents.x, extents.y, 0f - extents.z));
			array[6] = InverseTransform(bounds.center + new Vector3(0f - extents.x, 0f - extents.y, extents.z));
			array[7] = InverseTransform(bounds.center + new Vector3(0f - extents.x, 0f - extents.y, 0f - extents.z));
			Vector3 vector = array[0];
			Vector3 vector2 = array[0];
			for (int i = 1; i < 8; i++)
			{
				vector = Vector3.Min(vector, array[i]);
				vector2 = Vector3.Max(vector2, array[i]);
			}
			ArrayPool<Vector3>.Release(ref array);
			return new Bounds((vector + vector2) * 0.5f, vector2 - vector);
		}

		Vector2 IMovementPlane.ToPlane(Vector3 point)
		{
			if (isXY)
			{
				return new Vector2(point.x, point.y);
			}
			if (!isXZ)
			{
				point = inverseRotation * point;
			}
			return new Vector2(point.x, point.z);
		}

		Vector2 IMovementPlane.ToPlane(Vector3 point, out float elevation)
		{
			if (!isXZ)
			{
				point = inverseRotation * point;
			}
			elevation = point.y;
			return new Vector2(point.x, point.z);
		}

		Vector3 IMovementPlane.ToWorld(Vector2 point, float elevation)
		{
			return rotation * new Vector3(point.x, elevation, point.y);
		}

		public SimpleMovementPlane ToSimpleMovementPlane()
		{
			return new SimpleMovementPlane(rotation);
		}

		public void CopyTo(MutableGraphTransform graphTransform)
		{
			graphTransform.isXY = isXY;
			graphTransform.isXZ = isXZ;
			graphTransform.isOnlyTranslational = isOnlyTranslational;
			graphTransform.isIdentity = isIdentity;
			graphTransform.matrix = matrix;
			graphTransform.inverseMatrix = inverseMatrix;
			graphTransform.up = up;
			graphTransform.translation = translation;
			graphTransform.i3translation = i3translation;
			graphTransform.rotation = rotation;
			graphTransform.inverseRotation = inverseRotation;
		}
	}
}
