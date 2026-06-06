using System;
using System.Collections.Generic;
using PajamaLlama.Extensions;
using PajamaLlama.Math;
using UnityEngine;

[Serializable]
public class Polygon : Polygon2DBase
{
	[Tooltip("The vertices that makeup this polygon.")]
	[SerializeField]
	private List<Transform> Vertices = new List<Transform>();

	[Header("Debug")]
	[Tooltip("Enable additional debug information.")]
	public bool Debug = true;

	public bool DebugPolygon;

	private static uint _count;

	private Transform _parent;

	private bool _initialized;

	private int _vertexCount;

	private int _normalCount;

	private Vector2[] _polygon;

	private Polygon2DLine[] _sides;

	private Polygon2DProjection[] _projections;

	private bool _isRegular;

	private bool _hit;

	private Vector2 _origin;

	private Vector2 _direction;

	private float _width;

	private Vector2[] _rectangle;

	private Polygon2DProjection[] _rectangleProjections;

	public Vector2 Position2D { get; protected set; }

	public override Rect Bounds { get; protected set; }

	public float Radius { get; private set; }

	public uint Id { get; private set; }

	public Vector2[] Polygon2D => _polygon;

	public Polygon2DLine[] Sides => _sides;

	public override int VertexCount => _vertexCount;

	protected override int SideCount => _sides.Length;

	protected override int ProjectionCount => _normalCount;

	public override Vector2 GetVertex(int index)
	{
		return _polygon[index];
	}

	protected override Polygon2DLine GetSide(int index)
	{
		return _sides[index];
	}

	protected override Polygon2DProjection GetProjection(int index)
	{
		return _projections[index];
	}

	public Polygon()
	{
	}

	public Polygon(Vector2 center, float halfSize)
	{
		_vertexCount = 4;
		_normalCount = 2;
		_polygon = new Vector2[4]
		{
			center + new Vector2(0f - halfSize, halfSize),
			center + new Vector2(halfSize, halfSize),
			center + new Vector2(halfSize, 0f - halfSize),
			center + new Vector2(0f - halfSize, 0f - halfSize)
		};
		_sides = new Polygon2DLine[4];
		_projections = new Polygon2DProjection[_normalCount];
		_rectangle = new Vector2[4];
		UpdateSidesNormalsAndProjections();
	}

	public Polygon(List<Vector2> vertices)
	{
		SetVertices(vertices);
		UpdateBoundsAndRadius();
		UpdateSidesNormalsAndProjections();
	}

	public Polygon(Polygon other, Vector3 position, Quaternion rotation)
	{
		using ListPool<Vector2>.List vertices = ListPool<Vector2>.Get();
		other.PopulateTransformedVertices(vertices, position, rotation);
		SetVertices(vertices);
		UpdateBoundsAndRadius();
		UpdateSidesNormalsAndProjections();
	}

	public void Initialize(Transform parent, Polygon prefabPolygon = null)
	{
		Id = _count++;
		Position2D = new Vector2(float.NaN, float.NaN);
		_parent = parent;
		IPolygonProvider componentInChildren;
		if (prefabPolygon != null)
		{
			SetVertices(prefabPolygon.Vertices);
		}
		else if (parent.TryGetComponentInChildren<IPolygonProvider>(out componentInChildren))
		{
			SetVertices(componentInChildren.Polygon.Vertices);
		}
		else
		{
			SetVertices(Vertices);
		}
		_rectangleProjections = new Polygon2DProjection[2];
		_initialized = true;
		Update();
	}

	public void Initialize(Transform parent, List<Transform> vertices)
	{
		_parent = parent;
		SetVertices(vertices);
		_initialized = true;
	}

	public void Update(bool checkPosition = false)
	{
		if (!_initialized)
		{
			return;
		}
		Vector2 vector = _parent.position.Vector2TopDown();
		if (checkPosition && vector == Position2D)
		{
			return;
		}
		Position2D = vector;
		if (Vertices.Count == 0)
		{
			return;
		}
		Vector2 vector2 = Vertices[0].position.Vector2TopDown();
		Vector2 vector3 = vector2;
		Vector2 vector4 = vector2;
		_polygon[0] = vector2;
		for (int i = 1; i < _vertexCount; i++)
		{
			vector2 = Vertices[i].position.Vector2TopDown();
			_polygon[i] = vector2;
			if (vector2.x < vector3.x)
			{
				vector3.x = vector2.x;
			}
			else if (vector4.x < vector2.x)
			{
				vector4.x = vector2.x;
			}
			if (vector2.y < vector3.y)
			{
				vector3.y = vector2.y;
			}
			else if (vector4.y < vector2.y)
			{
				vector4.y = vector2.y;
			}
		}
		UpdateSidesNormalsAndProjections();
		Bounds = new Rect(vector3, vector4 - vector3);
		Radius = (Bounds.size / 2f).magnitude;
	}

	public void FastUpdate()
	{
		if (_polygon == null || _polygon.Length != _vertexCount)
		{
			_polygon = new Vector2[_vertexCount];
		}
		for (int i = 0; i < _vertexCount; i++)
		{
			_polygon[i] = Vertices[i].position.Vector2TopDown();
		}
		UpdateSidesNormalsAndProjections();
	}

	public void Update(Vector2[] vertices)
	{
		using ListPool<Vector2>.List list = ListPool<Vector2>.Get();
		list.AddRange(vertices);
		Update(list);
	}

	public void Update(List<Vector2> vertices)
	{
		SetVertices(vertices);
		UpdateBoundsAndRadius();
		UpdateSidesNormalsAndProjections();
	}

	private void TryCopyVertexTransforms(IPolygonProvider polygonProvider)
	{
		if (polygonProvider != null)
		{
			Vertices = new List<Transform>(polygonProvider.Polygon.Vertices);
		}
	}

	public void PopulateTransformedVertices(List<Vector2> vertices, Vector3 position, Quaternion rotation)
	{
		List<Transform> list = ReturnVertices();
		Matrix4x4 matrix4x = Matrix4x4.TRS(position, rotation, Vector3.one);
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			vertices.Add(matrix4x.MultiplyPoint3x4(list[i].position).Vector2TopDown());
		}
	}

	public bool ReturnShouldInitialize()
	{
		if (_polygon != null && _sides != null)
		{
			return _projections == null;
		}
		return true;
	}

	public float ReturnBoundingRadius()
	{
		float num = 0f;
		foreach (Transform vertex in Vertices)
		{
			float sqrMagnitude = vertex.localPosition.sqrMagnitude;
			if (num < sqrMagnitude)
			{
				num = sqrMagnitude;
			}
		}
		return Mathf.Sqrt(num);
	}

	public List<Transform> ReturnVertices()
	{
		return Vertices;
	}

	public Vector2[] ReturnPolygon()
	{
		return _polygon;
	}

	public bool ReturnIsLineIntersecting(Vector3 origin, Vector3 direction, float width = 0f)
	{
		return ReturnIsLineIntersecting(origin.Vector2TopDown(), direction.Vector2TopDown(), width);
	}

	public bool ReturnIsLineIntersecting(Vector2 origin, Vector2 direction, float width = 0f)
	{
		_width = width;
		if (width == 0f)
		{
			_origin = origin;
			_direction = direction;
			_hit = ReturnIsIntersecting(_origin, _direction);
		}
		else
		{
			_hit = ReturnIsOverlapping(origin, direction, width);
		}
		return _hit;
	}

	public bool ReturnIsLineIntersecting(Vector2 origin, Vector2 end)
	{
		Vector2 closestIntersection;
		return ReturnIsLineIntersecting(origin, end, out closestIntersection);
	}

	public bool ReturnIsLineIntersecting(Vector2 origin, Vector2 end, out Vector2 closestIntersection)
	{
		_hit = false;
		closestIntersection = Vector2.zero;
		float num = float.MaxValue;
		for (int i = 0; i < _sides.Length; i++)
		{
			if (PajamaLlama.Math.Math.LineLineIntersection(out var intersection, origin, end, _sides[i].Point, _sides[i].Point + _sides[i].Vector))
			{
				float num2 = Vector2.Distance(origin, intersection);
				if (num2 < num)
				{
					closestIntersection = intersection;
					num = num2;
					_hit = true;
				}
			}
		}
		return _hit;
	}

	public bool ReturnPointIsOverlapping(Vector3 point)
	{
		_hit = ReturnPointIsOverlapping(point.Vector2TopDown());
		return _hit;
	}

	public bool ReturnArePolygonsOverlapping(Polygon polygon, bool includeTolerance = false)
	{
		_hit = ReturnPolygonIsOverlapping(polygon._polygon, includeTolerance) && polygon.ReturnPolygonIsOverlapping(_polygon, includeTolerance);
		return _hit;
	}

	public bool ReturnArePolygonsOverlapping(Vector2[] vertices, bool includeTolerance = false)
	{
		_hit = ReturnPolygonIsOverlapping(vertices, includeTolerance);
		return _hit;
	}

	public bool ReturnIsPolygonOverlapping(Vector2[] vertices, bool includeTolerance = false)
	{
		return ReturnPolygonIsOverlapping(vertices, includeTolerance);
	}

	public bool ReturnIsAxisAllignedRectangleOverlapping(Vector2 min, Vector2 max)
	{
		for (int i = 0; i < _normalCount; i++)
		{
			if (!_projections[i].ReturnOverlap(min, max))
			{
				return false;
			}
		}
		return true;
	}

	public float ReturnPointDistanceToBorder(Vector2 point, out Vector2 projection)
	{
		projection = Vector2.zero;
		if (_sides == null)
		{
			return 0f;
		}
		int num = _sides.Length;
		float num2 = float.MaxValue;
		for (int i = 0; i < num; i++)
		{
			Vector2 vector = _sides[i].ReturnProjection(point);
			float num3 = point.DistanceToSquared(vector);
			if (num3 < num2)
			{
				projection = vector;
				num2 = num3;
			}
		}
		return Mathf.Sqrt(num2);
	}

	private void UpdatePolygonSides(Vector2[] polygon, List<Polygon2DLine> lines, bool clear = true)
	{
		int num = polygon.Length;
		if (clear)
		{
			lines.Clear();
			lines.Capacity = num;
		}
		for (int i = 0; i < num; i++)
		{
			Vector2 pointA = ((i != 0) ? polygon[i - 1] : polygon[num - 1]);
			Vector2 pointB = polygon[i];
			lines.Add(new Polygon2DLine(pointA, pointB));
		}
	}

	private Vector2[] ReturnPolygonNormals(Vector2[] polygon)
	{
		int num = polygon.Length;
		Vector2[] array = new Vector2[num];
		for (int i = 0; i < num; i++)
		{
			Vector2 vector = ((i != 0) ? polygon[i - 1] : polygon[num - 1]);
			Vector2 vector2 = polygon[i];
			array[i] = new Vector2(0f - (vector2.y - vector.y), vector2.x - vector.x);
		}
		return array;
	}

	private bool ContainsNormal(List<Vector2> computedNormals, Vector2 normal)
	{
		int count = computedNormals.Count;
		for (int i = 0; i < count; i++)
		{
			Vector2 vector = computedNormals[i];
			if (normal == vector || normal == -vector)
			{
				return true;
			}
		}
		return false;
	}

	public float ReturnClosestDistance(Vector3 point)
	{
		float num = float.MaxValue;
		foreach (Transform vertex in Vertices)
		{
			float num2 = Vector3.Distance(vertex.position, point);
			if (num2 < num)
			{
				num = num2;
			}
		}
		return num;
	}

	public static Polygon ReturnFromLine(Vector2 from, Vector2 to, float width)
	{
		Vector2 vector = to - from;
		Vector2 vector2 = new Vector2(0f - vector.y, vector.x).normalized * width;
		Vector2 vector3 = from + vector2;
		Vector2 vector4 = from - vector2;
		Polygon polygon = new Polygon();
		polygon._polygon = new Vector2[4]
		{
			vector3,
			vector3 + vector,
			vector4 + vector,
			vector4
		};
		polygon._vertexCount = 4;
		polygon._normalCount = 2;
		polygon._sides = new Polygon2DLine[4];
		polygon._projections = new Polygon2DProjection[2];
		polygon._rectangle = new Vector2[4];
		polygon.UpdateSidesNormalsAndProjections();
		return polygon;
	}

	public static bool ReturnIsConvex(List<Vector2> vertices)
	{
		int count = vertices.Count;
		if (count < 3)
		{
			return false;
		}
		Vector2 vector = vertices[count - 2];
		Vector2 vector2 = vertices[count - 1];
		float num = 0f;
		for (int i = 0; i < count; i++)
		{
			Vector2 vector3 = vertices[i];
			Vector2 vector4 = vector - vector2;
			Vector2 to = vector3 - vector2;
			float num2 = Vector2.SignedAngle(vector4, to);
			if (num == 0f)
			{
				num = num2;
			}
			else
			{
				if (num < 0f && 0f <= num2)
				{
					return false;
				}
				if (0f < num && num2 <= 0f)
				{
					return false;
				}
			}
			vector = vector2;
			vector2 = vector3;
		}
		return true;
	}

	public void SetVertices(List<Transform> vertices)
	{
		Vertices = vertices;
		using PooledList<Vector2> pooledList = PooledList<Vector2>.Get(vertices.Count);
		foreach (Transform vertex in vertices)
		{
			pooledList.Add(vertex.position.Vector2TopDown());
		}
		SetVertices(pooledList);
	}

	public void SetVertices(List<Vector2> vertices)
	{
		int count = vertices.Count;
		if (count != 0)
		{
			if (_vertexCount != count)
			{
				_vertexCount = count;
				_polygon = new Vector2[_vertexCount];
				_sides = new Polygon2DLine[_vertexCount];
			}
			vertices.CopyTo(_polygon, 0);
			_isRegular = ReturnIsRegularPolygon(_polygon);
			_normalCount = ((_isRegular && _vertexCount % 2 == 0) ? (_vertexCount / 2) : _vertexCount);
			if (_projections == null || _projections.Length != _normalCount)
			{
				_projections = new Polygon2DProjection[_normalCount];
			}
		}
	}

	public void AddVertex(Transform vertex)
	{
		Vertices.Add(vertex);
	}

	public void AddVertices(List<Transform> additionalVertices)
	{
		Vertices.AddRange(additionalVertices);
		SetVertices(Vertices);
	}

	public override void PopulateVertices(List<Vector2> vertices)
	{
		if (_polygon.IsNullOrEmpty())
		{
			if (!Vertices.IsNullOrEmpty())
			{
				for (int i = 0; i < Vertices.Count; i++)
				{
					vertices.Add(Vertices[i].position.Vector2TopDown());
				}
			}
		}
		else
		{
			base.PopulateVertices(vertices);
		}
	}

	private void UpdateBoundsAndRadius()
	{
		if (_polygon.IsNullOrEmpty())
		{
			return;
		}
		Rect bounds = new Rect(_polygon[0], Vector2.zero);
		Vector2[] polygon = _polygon;
		for (int i = 0; i < polygon.Length; i++)
		{
			Vector2 vector = polygon[i];
			if (vector.x < bounds.xMin)
			{
				bounds.xMin = vector.x;
			}
			else if (vector.x > bounds.xMax)
			{
				bounds.xMax = vector.x;
			}
			if (vector.y < bounds.yMin)
			{
				bounds.yMin = vector.y;
			}
			else if (vector.y > bounds.yMax)
			{
				bounds.yMax = vector.y;
			}
		}
		Bounds = bounds;
		Radius = (bounds.size / 2f).magnitude;
	}

	private void UpdateSidesNormalsAndProjections()
	{
		Vector2 vector = _polygon[_vertexCount - 1];
		for (int i = 0; i < _vertexCount; i++)
		{
			Vector2 pointA = vector;
			vector = _polygon[i];
			_sides[i] = new Polygon2DLine(pointA, vector);
			if (i < _normalCount)
			{
				Vector2 vector2 = new Vector2(0f - (vector.y - pointA.y), vector.x - pointA.x);
				_projections[i] = ProjectPolygonOnAxis(vector2.normalized, _polygon);
			}
		}
	}

	private void UpdateRectangleNormalsAndProjections()
	{
		Vector2 vector = _rectangle[3];
		Vector2 vector2 = _rectangle[0];
		Vector2 vector3 = new Vector2(0f - (vector2.y - vector.y), vector2.x - vector.x);
		_rectangleProjections[0] = ProjectPolygonOnAxis(vector3.normalized, _rectangle);
		vector3 = new Vector2(vector3.y, 0f - vector3.x);
		_rectangleProjections[1] = ProjectPolygonOnAxis(vector3.normalized, _rectangle);
	}

	private new bool ReturnIsIntersecting(Vector2 origin, Vector2 direction)
	{
		Polygon2DLine[] sides = _sides;
		for (int i = 0; i < sides.Length; i++)
		{
			Polygon2DLine polygon2DLine = sides[i];
			float num = ReturnIntersectionScalar(origin, direction, polygon2DLine.Point, polygon2DLine.Vector);
			if (!(num < 0f) && !(1f < num))
			{
				Vector2 point = origin + num * direction;
				if (ReturnPointIsOverlapping(point, 0.01f))
				{
					return true;
				}
			}
		}
		return false;
	}

	private new float ReturnIntersectionScalar(Vector2 pointA, Vector2 vectorA, Vector2 pointB, Vector2 vectorB)
	{
		return (pointB.Cross(vectorB) - pointA.Cross(vectorB)) / vectorA.Cross(vectorB);
	}

	private bool ReturnIsOverlapping(Vector2 origin, Vector2 direction, float width)
	{
		Vector2 vector = new Vector2(0f - direction.y, direction.x).normalized * width;
		Vector2 vector2 = origin + vector;
		Vector2 vector3 = origin - vector;
		if (_rectangle == null)
		{
			_rectangle = new Vector2[4];
		}
		_rectangle[0] = vector2;
		_rectangle[1] = vector2 + direction;
		_rectangle[2] = vector3 + direction;
		_rectangle[3] = vector3;
		if (ReturnPolygonIsOverlapping(_rectangle))
		{
			UpdateRectangleNormalsAndProjections();
			return ReturnPolygonsAreOverlapping(_rectangleProjections, _polygon);
		}
		return false;
	}

	public new bool ReturnPointIsOverlapping(Vector2 point, float marginOffError = 0f)
	{
		for (int i = 0; i < _normalCount; i++)
		{
			Polygon2DProjection polygon2DProjection = _projections[i];
			float scalar = Vector2.Dot(polygon2DProjection.axis, point);
			if (!polygon2DProjection.ReturnOverlap(scalar, marginOffError))
			{
				return false;
			}
		}
		return true;
	}

	private bool ReturnPolygonIsOverlapping(Vector2[] other, bool includeTolerance = false)
	{
		for (int i = 0; i < _normalCount; i++)
		{
			if (!_projections[i].ReturnOverlap(other, includeTolerance))
			{
				return false;
			}
		}
		return true;
	}

	private bool ReturnPolygonsAreOverlapping(Polygon2DProjection[] projections, Vector2[] other)
	{
		int num = projections.Length;
		for (int i = 0; i < num; i++)
		{
			if (!projections[i].ReturnOverlap(other))
			{
				return false;
			}
		}
		return true;
	}

	private Polygon2DProjection ProjectPolygonOnAxis(Vector2 axis, Vector2[] polygon)
	{
		Vector2 vector = polygon[0];
		float num = axis.x * vector.x + axis.y * vector.y;
		float num2 = num;
		float num3 = num;
		int num4 = polygon.Length;
		for (int i = 1; i < num4; i++)
		{
			vector = polygon[i];
			num = axis.x * vector.x + axis.y * vector.y;
			if (num < num2)
			{
				num2 = num;
			}
			else if (num3 < num)
			{
				num3 = num;
			}
		}
		return new Polygon2DProjection(axis, num2, num3);
	}

	private bool ReturnIsRegularPolygon(Vector2[] polygon)
	{
		int num = polygon.Length;
		Vector2 vector = polygon[num - 1];
		Vector2 vector2 = polygon[0];
		Vector2 vector3 = vector - polygon[num - 2];
		Vector2 vector4 = vector2 - vector;
		float b = vector3.Angle(vector4);
		for (int i = 1; i < num; i++)
		{
			vector = vector2;
			vector2 = polygon[i];
			vector3 = vector4;
			vector4 = vector2 - vector;
			if (!Mathf.Approximately(vector3.Angle(vector4), b))
			{
				return false;
			}
		}
		return true;
	}

	public void ResetIfRequired(Transform parent, bool required = false)
	{
		if (!Application.isPlaying)
		{
			bool flag = _vertexCount != Vertices.Count || _polygon == null || _sides == null || _projections == null;
			if (required || flag)
			{
				_vertexCount = -1;
				Initialize(parent);
			}
		}
	}

	public void DrawDebugPolygon(Color color, Vector3 offset)
	{
		int num = 0;
		while (_polygon != null && num < _polygon.Length)
		{
			int num2 = (int)Mathf.Repeat(num + 1, _polygon.Length);
			UnityEngine.Debug.DrawLine(_polygon[num].Vector3TopDown(), _polygon[num2].Vector3TopDown(), color, 1f, depthTest: false);
			num++;
		}
	}

	public void DrawDebugRectangle(Color color, Vector3 offset)
	{
		int num = 0;
		while (_rectangle != null && num < _rectangle.Length)
		{
			int num2 = (int)Mathf.Repeat(num + 1, _rectangle.Length);
			UnityEngine.Debug.DrawLine(_rectangle[num].Vector3TopDown(), _rectangle[num2].Vector3TopDown(), color, 1f, depthTest: false);
			num++;
		}
	}

	public void DrawGizmos()
	{
		Color color = Gizmos.color;
		if (Debug)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawCube(new Vector3(Bounds.center.x, 0f, Bounds.center.y), new Vector3(Bounds.size.x, 1f, Bounds.size.y));
			Gizmos.color = Color.white;
			if (_width == 0f)
			{
				Gizmos.DrawRay(_origin.Vector3TopDown(), _direction.Vector3TopDown());
			}
			else if (_rectangle != null)
			{
				for (int i = 0; i < _rectangle.Length; i++)
				{
					Vector3 vector = ((i != 0) ? _rectangle[i - 1].Vector3TopDown() : _rectangle[_rectangle.Length - 1].Vector3TopDown());
					Gizmos.DrawLine(vector, _rectangle[i].Vector3TopDown());
				}
				Gizmos.color = Color.magenta;
				DrawNormals(_projections);
				if (_rectangleProjections != null)
				{
					Gizmos.color = Color.cyan;
					DrawNormals(_rectangleProjections);
				}
			}
		}
		if (DebugPolygon)
		{
			DrawPolygon();
			if (_hit)
			{
				DrawPolygon(Color.red);
			}
			else
			{
				DrawPolygon(Color.yellow);
			}
		}
		Gizmos.color = color;
	}

	public void DrawPolygon(Color color)
	{
		Color color2 = Gizmos.color;
		Gizmos.color = color;
		int num = 0;
		while (_polygon != null && num < _polygon.Length)
		{
			int num2 = (int)Mathf.Repeat(num + 1, _polygon.Length);
			Gizmos.DrawLine(_polygon[num].Vector3TopDown(), _polygon[num2].Vector3TopDown());
			num++;
		}
		Gizmos.color = color2;
	}

	public void DrawVertices(Color color)
	{
		if (DebugPolygon)
		{
			Color color2 = Gizmos.color;
			Gizmos.color = color;
			int num = 0;
			while (Vertices != null && num < Vertices.Count)
			{
				int index = (int)Mathf.Repeat(num + 1, Vertices.Count);
				Gizmos.DrawLine(Vertices[num].position, Vertices[index].position);
				num++;
			}
			Gizmos.color = color2;
		}
	}

	private void DrawPolygon()
	{
		Gizmos.color = Color.white;
		if (Vertices.Count == 2)
		{
			Gizmos.DrawLine(Vertices[0].transform.position, Vertices[1].transform.position);
		}
		else if (2 < Vertices.Count)
		{
			for (int i = 0; i < Vertices.Count; i++)
			{
				Vector3 vector = ((i != 0) ? Vertices[i - 1].position : Vertices[Vertices.Count - 1].position);
				Gizmos.DrawLine(vector, Vertices[i].position);
			}
		}
	}

	private void DrawNormals(Polygon2DProjection[] projections)
	{
		for (int i = 0; i < projections.Length; i++)
		{
			Vector3 vector = projections[i].axis.Vector3TopDown();
			Gizmos.DrawLine(Vector3.zero - 100f * vector, Vector3.zero + 100f * vector);
		}
	}
}
