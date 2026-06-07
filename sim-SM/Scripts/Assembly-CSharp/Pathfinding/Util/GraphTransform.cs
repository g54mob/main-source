using UnityEngine;

namespace Pathfinding.Util
{
	public class GraphTransform : IMovementPlane, ITransform
	{
		public readonly bool identity;

		public readonly bool onlyTranslational;

		private readonly bool isXY;

		private readonly bool isXZ;

		private readonly Matrix4x4 matrix;

		private readonly Matrix4x4 inverseMatrix;

		private readonly Vector3 up;

		private readonly Vector3 translation;

		private readonly Int3 i3translation;

		private readonly Quaternion rotation;

		private readonly Quaternion inverseRotation;

		public static readonly GraphTransform identityTransform;

		public GraphTransform(Matrix4x4 matrix)
		{
		}

		public Vector3 WorldUpAtGraphPosition(Vector3 point)
		{
			return default(Vector3);
		}

		private static bool MatrixIsTranslational(Matrix4x4 matrix)
		{
			return false;
		}

		public Vector3 Transform(Vector3 point)
		{
			return default(Vector3);
		}

		public Vector3 TransformVector(Vector3 point)
		{
			return default(Vector3);
		}

		public void Transform(Int3[] arr)
		{
		}

		public void Transform(Vector3[] arr)
		{
		}

		public Vector3 InverseTransform(Vector3 point)
		{
			return default(Vector3);
		}

		public Int3 InverseTransform(Int3 point)
		{
			return default(Int3);
		}

		public void InverseTransform(Int3[] arr)
		{
		}

		public static GraphTransform operator *(GraphTransform lhs, Matrix4x4 rhs)
		{
			return null;
		}

		public static GraphTransform operator *(Matrix4x4 lhs, GraphTransform rhs)
		{
			return null;
		}

		public Bounds Transform(Bounds bounds)
		{
			return default(Bounds);
		}

		public Bounds InverseTransform(Bounds bounds)
		{
			return default(Bounds);
		}

		Vector2 IMovementPlane.ToPlane(Vector3 point)
		{
			return default(Vector2);
		}

		Vector2 IMovementPlane.ToPlane(Vector3 point, out float elevation)
		{
			elevation = default(float);
			return default(Vector2);
		}

		Vector3 IMovementPlane.ToWorld(Vector2 point, float elevation)
		{
			return default(Vector3);
		}
	}
}
