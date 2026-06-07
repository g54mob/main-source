using UnityEngine;

public class Rectangle : Polygon2DBase
{
	private Rect _bounds;

	private Vector2[] _vertices = new Vector2[4];

	private Polygon2DLine[] _sides = new Polygon2DLine[4];

	private Polygon2DProjection[] _projections = new Polygon2DProjection[2];

	public override Rect Bounds
	{
		get
		{
			return _bounds;
		}
		protected set
		{
			_bounds = value;
		}
	}

	public override int VertexCount => 4;

	protected override int SideCount => 4;

	protected override int ProjectionCount => 2;

	public void Set(Rect rect)
	{
		SetVertices(rect.min, new Vector2(rect.xMin, rect.yMax), rect.max, new Vector2(rect.xMax, rect.yMin));
		_bounds = rect;
	}

	public void Set(Vector2 origin, Vector2 direction, float width)
	{
		Vector2 vector = new Vector2(0f - direction.y, direction.x).normalized * width / 2f;
		Vector2 vector2 = origin + vector;
		Vector2 vector3 = origin - vector;
		SetVertices(vector2, vector2 + direction, vector3 + direction, vector3);
		UpdateBounds();
	}

	private void SetVertices(Vector2 vertex0, Vector2 vertex1, Vector2 vertex2, Vector2 vertex3)
	{
		_vertices[0] = vertex0;
		_vertices[1] = vertex1;
		_vertices[2] = vertex2;
		_vertices[3] = vertex3;
		_sides[0] = new Polygon2DLine(vertex3, vertex0);
		_sides[1] = new Polygon2DLine(vertex0, vertex1);
		_sides[2] = new Polygon2DLine(vertex1, vertex2);
		_sides[3] = new Polygon2DLine(vertex2, vertex3);
		UpdateProjections(vertex3, vertex0);
	}

	private void SetVertex(Vector2 vertex, int index)
	{
		_vertices[index] = vertex;
		if (vertex.x < _bounds.xMin)
		{
			_bounds.xMin = vertex.x;
		}
		else if (vertex.x > _bounds.xMax)
		{
			_bounds.xMax = vertex.x;
		}
		if (vertex.y < _bounds.yMin)
		{
			_bounds.yMin = vertex.y;
		}
		else if (vertex.y > _bounds.yMax)
		{
			_bounds.yMax = vertex.y;
		}
	}

	private void UpdateBounds()
	{
		Vector2 vector = _vertices[0];
		_bounds.Set(vector.x, vector.y, 0f, 0f);
		for (int i = 0; i < VertexCount; i++)
		{
			vector = _vertices[i];
			if (vector.x < _bounds.xMin)
			{
				_bounds.xMin = vector.x;
			}
			else if (vector.x > _bounds.xMax)
			{
				_bounds.xMax = vector.x;
			}
			if (vector.y < _bounds.yMin)
			{
				_bounds.yMin = vector.y;
			}
			else if (vector.y > _bounds.yMax)
			{
				_bounds.yMax = vector.y;
			}
		}
	}

	private void UpdateProjections(Vector2 from, Vector2 to)
	{
		Vector2 vector = new Vector2(0f - (to.y - from.y), to.x - from.x);
		_projections[0] = GetProjectionOnAxis(vector.normalized, _vertices);
		vector = new Vector2(vector.y, 0f - vector.x);
		_projections[1] = GetProjectionOnAxis(vector.normalized, _vertices);
	}

	public override Vector2 GetVertex(int index)
	{
		return _vertices[index];
	}

	protected override Polygon2DProjection GetProjection(int index)
	{
		return _projections[index];
	}

	protected override Polygon2DLine GetSide(int index)
	{
		return _sides[index];
	}

	private Polygon2DProjection GetProjectionOnAxis(Vector2 axis, Vector2[] polygon)
	{
		Vector2 vector = polygon[0];
		float num = axis.x * vector.x + axis.y * vector.y;
		float num2 = num;
		float num3 = num;
		int vertexCount = VertexCount;
		for (int i = 1; i < vertexCount; i++)
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
}
