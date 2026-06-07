using System.Collections.Generic;
using UnityEngine;

public class ListBasedPolygon : Polygon2DBase
{
	private int _vertexCount;

	private int _projectionCount;

	private List<Vector2> _vertices;

	private List<Polygon2DLine> _sides;

	private List<Polygon2DProjection> _projections;

	public Vector2 Position { get; private set; }

	public override Rect Bounds { get; protected set; }

	public float Radius { get; private set; }

	public List<Vector2> Vertices => _vertices;

	public List<Polygon2DLine> Sides => _sides;

	public List<Polygon2DProjection> Projections => _projections;

	public override int VertexCount => _vertexCount;

	protected override int SideCount => _vertexCount;

	protected override int ProjectionCount => _projectionCount;

	public override Vector2 GetVertex(int index)
	{
		return _vertices[index];
	}

	protected override Polygon2DLine GetSide(int index)
	{
		return _sides[index];
	}

	protected override Polygon2DProjection GetProjection(int index)
	{
		return _projections[index];
	}

	public ListBasedPolygon()
	{
		_vertices = new List<Vector2>();
		_sides = new List<Polygon2DLine>();
		_projections = new List<Polygon2DProjection>();
	}

	public ListBasedPolygon(List<Vector2> vertices)
		: this()
	{
		SetVertices(vertices);
	}

	public void SetVertices(List<Vector2> vertices)
	{
		_vertices.Clear();
		_sides.Clear();
		_projections.Clear();
		foreach (Vector2 vertex in vertices)
		{
			_vertices.Add(vertex);
		}
		_vertexCount = _vertices.Count;
		_projectionCount = ((IsRegular() && _vertexCount % 2 == 0) ? (_vertexCount / 2) : _vertexCount);
		UpdateBoundsAndRadius();
		UpdateSidesNormalsAndProjections();
	}

	private void UpdateBoundsAndRadius()
	{
		if (_vertices.IsNullOrEmpty())
		{
			return;
		}
		Rect bounds = new Rect(_vertices[0], Vector2.zero);
		foreach (Vector2 vertex in _vertices)
		{
			if (vertex.x < bounds.xMin)
			{
				bounds.xMin = vertex.x;
			}
			else if (vertex.x > bounds.xMax)
			{
				bounds.xMax = vertex.x;
			}
			if (vertex.y < bounds.yMin)
			{
				bounds.yMin = vertex.y;
			}
			else if (vertex.y > bounds.yMax)
			{
				bounds.yMax = vertex.y;
			}
		}
		Bounds = bounds;
		Radius = (bounds.size / 2f).magnitude;
	}

	private void UpdateSidesNormalsAndProjections()
	{
		Vector2 vector = _vertices[_vertexCount - 1];
		_sides.Clear();
		_projections.Clear();
		for (int i = 0; i < _vertexCount; i++)
		{
			Vector2 pointA = vector;
			vector = _vertices[i];
			_sides.Add(new Polygon2DLine(pointA, vector));
			if (i < _projectionCount)
			{
				Vector2 vector2 = new Vector2(0f - (vector.y - pointA.y), vector.x - pointA.x);
				_projections.Add(GetProjectionOnAxis(vector2.normalized));
			}
		}
	}
}
