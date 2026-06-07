using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasRenderer))]
public class UILineRenderer : MaskableGraphic
{
	public struct Triangle
	{
		public readonly UIVertex[] Points;

		public Triangle(Vector2 p1, Vector2 p2, Vector3 p3, Color color)
		{
			Points = new UIVertex[3];
			for (int i = 0; i < Points.Length; i++)
			{
				Points[i] = UIVertex.simpleVert;
			}
			Points[0].position = p1;
			Points[1].position = p2;
			Points[2].position = p3;
			for (int j = 0; j < Points.Length; j++)
			{
				Points[j].color = color;
			}
		}
	}

	[SerializeField]
	private float _thickness = 10f;

	[SerializeField]
	private bool _useDashes;

	[SerializeField]
	private float _dashLength = 10f;

	[SerializeField]
	private float _gapLength = 5f;

	[SerializeField]
	private bool _roundedEnds;

	private List<UILine> _lineSegments = new List<UILine>();

	private List<Triangle> _triangles = new List<Triangle>();

	public void SetLineSegments(List<UILine> segments)
	{
		_lineSegments = new List<UILine>(segments);
		SetVerticesDirty();
	}

	public void AddLineSegment(List<UILine> segments)
	{
		_lineSegments.AddRange(new List<UILine>(segments));
		SetVerticesDirty();
	}

	public void ClearLineSegments()
	{
		_lineSegments.Clear();
		SetVerticesDirty();
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		vh.Clear();
		if (_lineSegments == null)
		{
			return;
		}
		float num = 0f;
		for (int i = 0; i < _lineSegments.Count; i++)
		{
			UILine uILine = _lineSegments[i];
			if (uILine != null && !(uILine.start == uILine.end))
			{
				float magnitude = (uILine.end - uILine.start).magnitude;
				if (!(magnitude < Mathf.Epsilon))
				{
					num += magnitude;
					DrawSegment(uILine.start, uILine.end, uILine.color, uILine.thickness, vh);
				}
			}
		}
		for (int j = 0; j < _triangles.Count; j++)
		{
			DrawTriangle(_triangles[j], vh);
		}
	}

	private void DrawSegment(Vector2 start, Vector2 end, Color lineColor, float thickness, VertexHelper vh)
	{
		Vector2 vector = end - start;
		float magnitude = vector.magnitude;
		if (magnitude < Mathf.Epsilon)
		{
			return;
		}
		Vector2 vector2 = vector / magnitude;
		Vector2 normal = new Vector2(0f - vector2.y, vector2.x) * (thickness * 0.5f);
		if (_useDashes)
		{
			float num = 0f;
			Vector2 vector3 = start;
			while (num < magnitude)
			{
				float num2 = Mathf.Min(_dashLength, magnitude - num);
				Vector2 vector4 = vector3 + vector2 * num2;
				CreateQuad(vector3, vector4, normal, lineColor, vh);
				num += num2 + _gapLength;
				vector3 = vector4 + vector2 * _gapLength;
			}
		}
		else
		{
			CreateQuad(start, end, normal, lineColor, vh);
		}
		if (_roundedEnds)
		{
			CreateCircle(start, vh, lineColor);
			CreateCircle(end, vh, lineColor);
		}
	}

	private void DrawTriangle(Triangle triangle, VertexHelper vh)
	{
		int currentVertCount = vh.currentVertCount;
		for (int i = 0; i < triangle.Points.Length; i++)
		{
			vh.AddVert(triangle.Points[i]);
		}
		vh.AddTriangle(currentVertCount, currentVertCount + 1, currentVertCount + 2);
	}

	public void AddTriangle(Vector2 p1, Vector2 p2, Vector3 p3, Color vertexColor)
	{
		_triangles.Add(new Triangle(p1, p2, p3, vertexColor));
		SetVerticesDirty();
	}

	public void ClearTriangles()
	{
		_triangles.Clear();
		SetVerticesDirty();
	}

	private void CreateQuad(Vector2 start, Vector2 end, Vector2 normal, Color vertexColor, VertexHelper vh)
	{
		UIVertex simpleVert = UIVertex.simpleVert;
		UIVertex simpleVert2 = UIVertex.simpleVert;
		UIVertex simpleVert3 = UIVertex.simpleVert;
		UIVertex simpleVert4 = UIVertex.simpleVert;
		simpleVert.position = start - normal;
		simpleVert2.position = start + normal;
		simpleVert3.position = end - normal;
		simpleVert4.position = end + normal;
		simpleVert.color = (simpleVert2.color = (simpleVert3.color = (simpleVert4.color = vertexColor)));
		int currentVertCount = vh.currentVertCount;
		vh.AddVert(simpleVert);
		vh.AddVert(simpleVert2);
		vh.AddVert(simpleVert3);
		vh.AddVert(simpleVert4);
		vh.AddTriangle(currentVertCount, currentVertCount + 1, currentVertCount + 2);
		vh.AddTriangle(currentVertCount + 2, currentVertCount + 1, currentVertCount + 3);
	}

	private void CreateCircle(Vector2 center, VertexHelper vh, Color vertexColor)
	{
		int num = 8;
		float num2 = MathF.PI * 2f / (float)num;
		int currentVertCount = vh.currentVertCount;
		vh.AddVert(CreateVertex(center, vertexColor));
		for (int i = 0; i <= num; i++)
		{
			float f = (float)i * num2;
			Vector2 vector = new Vector2(Mathf.Cos(f), Mathf.Sin(f)) * (_thickness * 0.5f);
			vh.AddVert(CreateVertex(center + vector, vertexColor));
		}
		for (int j = 1; j <= num; j++)
		{
			vh.AddTriangle(currentVertCount, currentVertCount + j, currentVertCount + j + 1);
		}
	}

	private UIVertex CreateVertex(Vector2 position, Color vertexColor)
	{
		UIVertex simpleVert = UIVertex.simpleVert;
		simpleVert.position = position;
		simpleVert.color = vertexColor;
		return simpleVert;
	}
}
