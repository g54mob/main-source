using UnityEngine;

public class BaryCentricDistance
{
	public struct Result
	{
		public float distanceSquared;

		public int triangle;

		public Vector3 normal;

		public Vector3 centre;

		public Vector3 closestPoint;

		public float distance
		{
			get
			{
				return Mathf.Sqrt(distanceSquared);
			}
		}
	}

	private int[] _triangles;

	private Vector3[] _vertices;

	private Mesh _mesh;

	private MeshFilter _meshfilter;

	private Transform _transform;

	public BaryCentricDistance(MeshFilter meshfilter)
	{
		_meshfilter = meshfilter;
		_mesh = _meshfilter.sharedMesh;
		_triangles = _mesh.triangles;
		_vertices = _mesh.vertices;
		_transform = meshfilter.transform;
	}

	public Result GetClosestTriangleAndPoint(Vector3 point)
	{
		point = _transform.InverseTransformPoint(point);
		float num = float.PositiveInfinity;
		Result result = default(Result);
		int num2 = _triangles.Length / 3;
		for (int i = 0; i < num2; i++)
		{
			Result triangleInfoForPoint = GetTriangleInfoForPoint(point, i);
			if (num > triangleInfoForPoint.distanceSquared)
			{
				num = triangleInfoForPoint.distanceSquared;
				result = triangleInfoForPoint;
			}
		}
		result.centre = _transform.TransformPoint(result.centre);
		result.closestPoint = _transform.TransformPoint(result.closestPoint);
		result.normal = _transform.TransformDirection(result.normal);
		result.distanceSquared = (result.closestPoint - point).sqrMagnitude;
		return result;
	}

	private Result GetTriangleInfoForPoint(Vector3 point, int triangle)
	{
		Result result = new Result
		{
			triangle = triangle,
			distanceSquared = float.PositiveInfinity
		};
		if (triangle >= _triangles.Length / 3)
		{
			return result;
		}
		Vector3 vector = _vertices[_triangles[0 + triangle * 3]];
		Vector3 vector2 = _vertices[_triangles[1 + triangle * 3]];
		Vector3 vector3 = _vertices[_triangles[2 + triangle * 3]];
		result.normal = Vector3.Cross((vector2 - vector).normalized, (vector3 - vector).normalized);
		Vector3 vector4 = point + Vector3.Dot(vector - point, result.normal) * result.normal;
		float x = (vector4.x * vector2.y - vector4.x * vector3.y - vector2.x * vector4.y + vector2.x * vector3.y + vector3.x * vector4.y - vector3.x * vector2.y) / (vector.x * vector2.y - vector.x * vector3.y - vector2.x * vector.y + vector2.x * vector3.y + vector3.x * vector.y - vector3.x * vector2.y);
		float y = (vector.x * vector4.y - vector.x * vector3.y - vector4.x * vector.y + vector4.x * vector3.y + vector3.x * vector.y - vector3.x * vector4.y) / (vector.x * vector2.y - vector.x * vector3.y - vector2.x * vector.y + vector2.x * vector3.y + vector3.x * vector.y - vector3.x * vector2.y);
		float z = (vector.x * vector2.y - vector.x * vector4.y - vector2.x * vector.y + vector2.x * vector4.y + vector4.x * vector.y - vector4.x * vector2.y) / (vector.x * vector2.y - vector.x * vector3.y - vector2.x * vector.y + vector2.x * vector3.y + vector3.x * vector.y - vector3.x * vector2.y);
		result.centre = vector * 0.3333f + vector2 * 0.3333f + vector3 * 0.3333f;
		Vector3 normalized = new Vector3(x, y, z).normalized;
		result.distanceSquared = ((result.closestPoint = vector * normalized.x + vector2 * normalized.y + vector3 * normalized.z) - point).sqrMagnitude;
		if (float.IsNaN(result.distanceSquared))
		{
			result.distanceSquared = float.PositiveInfinity;
		}
		return result;
	}
}
