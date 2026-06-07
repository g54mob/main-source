using System;
using PajamaLlama.Extensions;
using UnityEngine;

[Serializable]
public struct Vector2Polygon
{
	public Vector2[] Vertices;

	public void DrawGizmo(Color color)
	{
		GizmoExtensions.DrawPolygon(Vertices, color);
	}
}
