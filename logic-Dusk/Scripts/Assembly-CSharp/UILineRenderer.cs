using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILineRenderer : MaskableGraphic
{
	public struct LinePoint
	{
		public Vector2 Point;

		public bool isScaled;
	}

	public float LineThickness = 2f;

	public bool UseMargins;

	public Vector2 Margin;

	public bool flipFixedY;

	public bool relativeToCenter;

	public float widthAt100PerScale = Screen.width;

	public float heightAt100PerScale = Screen.height;

	public Vector2[] ActualCoordPoints;

	public Vector2[] Scale;

	public bool[] LockAtCenterX;

	public bool[] LockAtCenterY;

	private Vector2[] Points;

	public float a;

	public float b;

	public float c;

	public float d;

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		List<UIVertex> list = new List<UIVertex>();
		float num = base.rectTransform.rect.width / 2f;
		float num2 = base.rectTransform.rect.height / 2f;
		a = Math.Min(1f, Math.Max(0f, a));
		b = Math.Min(1f, Math.Max(0f, b));
		c = Math.Min(1f, Math.Max(0f, c));
		d = Math.Min(1f, Math.Max(0f, d));
		Color32 color = base.color;
		vh.AddVert(new Vector3((0f - num) * a, 0f), color, new Vector2(0f, 0f));
		vh.AddVert(new Vector3(0f, num * b), color, new Vector2(0f, 1f));
		vh.AddVert(new Vector3(num * c, 0f), color, new Vector2(1f, 1f));
		vh.AddVert(new Vector3(0f, (0f - num) * d), color, new Vector2(1f, 0f));
		vh.AddTriangle(0, 1, 2);
		vh.AddTriangle(2, 3, 0);
	}

	protected void myOnFillVBO(List<UIVertex> vbo)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		Vector2 vector = Vector2.zero;
		Vector2 vector2 = Vector2.zero;
		if (Points != null && Points.Length >= 2)
		{
			num = base.rectTransform.rect.width;
			num2 = base.rectTransform.rect.height;
			num3 = (0f - base.rectTransform.pivot.x) * base.rectTransform.rect.width;
			num4 = (0f - base.rectTransform.pivot.y) * base.rectTransform.rect.height;
			if (UseMargins)
			{
				num -= Margin.x;
				num2 -= Margin.y;
				num3 += Margin.x / 2f;
				num4 += Margin.y / 2f;
			}
			vbo.Clear();
			for (int i = 1; i < Points.Length; i++)
			{
				Vector2 vector3 = Points[i - 1];
				Vector2 vector4 = Points[i];
				vector3 = new Vector2(vector3.x * num + num3, vector3.y * num2 + num4);
				vector4 = new Vector2(vector4.x * num + num3, vector4.y * num2 + num4);
				float z = Mathf.Atan2(vector4.y - vector3.y, vector4.x - vector3.x) * 180f / (float)Math.PI;
				Vector2 vector5 = vector3 + new Vector2(0f, (0f - LineThickness) / 2f);
				Vector2 vector6 = vector3 + new Vector2(0f, LineThickness / 2f);
				Vector2 vector7 = vector4 + new Vector2(0f, LineThickness / 2f);
				Vector2 vector8 = vector4 + new Vector2(0f, (0f - LineThickness) / 2f);
				vector5 = RotatePointAroundPivot(vector5, vector3, new Vector3(0f, 0f, z));
				vector6 = RotatePointAroundPivot(vector6, vector3, new Vector3(0f, 0f, z));
				vector7 = RotatePointAroundPivot(vector7, vector4, new Vector3(0f, 0f, z));
				vector8 = RotatePointAroundPivot(vector8, vector4, new Vector3(0f, 0f, z));
				if (i > 1)
				{
					SetVbo(vbo, new Vector2[4] { vector, vector2, vector5, vector6 });
				}
				SetVbo(vbo, new Vector2[4] { vector5, vector6, vector7, vector8 });
				vector = vector7;
				vector2 = vector8;
			}
		}
		if (ActualCoordPoints == null || ActualCoordPoints.Length < 2)
		{
			return;
		}
		if (Scale == null)
		{
			Scale = new Vector2[ActualCoordPoints.Length];
		}
		else if (Scale.Length != ActualCoordPoints.Length)
		{
			Array.Resize(ref Scale, ActualCoordPoints.Length);
		}
		if (LockAtCenterX == null)
		{
			LockAtCenterX = new bool[ActualCoordPoints.Length];
		}
		else if (LockAtCenterX.Length != ActualCoordPoints.Length)
		{
			Array.Resize(ref LockAtCenterX, ActualCoordPoints.Length);
		}
		if (LockAtCenterY == null)
		{
			LockAtCenterY = new bool[ActualCoordPoints.Length];
		}
		else if (LockAtCenterY.Length != ActualCoordPoints.Length)
		{
			Array.Resize(ref LockAtCenterY, ActualCoordPoints.Length);
		}
		num = base.rectTransform.rect.width;
		num2 = base.rectTransform.rect.height;
		num3 = (0f - base.rectTransform.pivot.x) * base.rectTransform.rect.width;
		num4 = (0f - base.rectTransform.pivot.y) * base.rectTransform.rect.height;
		if (UseMargins)
		{
			num -= Margin.x;
			num2 -= Margin.y;
			num3 += Margin.x / 2f;
			num4 += Margin.y / 2f;
		}
		vector = Vector2.zero;
		vector2 = Vector2.zero;
		for (int j = 1; j < ActualCoordPoints.Length; j++)
		{
			Vector2 vector9 = ActualCoordPoints[j - 1];
			Vector2 vector10 = ActualCoordPoints[j];
			Vector2 vector11 = vector9;
			Vector2 vector12 = vector10;
			if (flipFixedY)
			{
				vector11.y = (float)Screen.height - vector11.y;
				vector12.y = (float)Screen.height - vector12.y;
			}
			if (relativeToCenter)
			{
				vector11.x = (float)(Screen.width / 2) + vector11.x;
				vector11.y = (float)(Screen.height / 2) + vector11.y;
				vector12.x = (float)(Screen.width / 2) + vector12.x;
				vector12.y = (float)(Screen.height / 2) + vector12.y;
			}
			float num5 = (float)Screen.width - widthAt100PerScale;
			float num6 = (float)Screen.width - widthAt100PerScale;
			if (LockAtCenterX[j - 1])
			{
				vector11.x = Screen.width / 2;
			}
			else
			{
				vector11.x -= num5 * Scale[j - 1].x;
			}
			if (LockAtCenterX[j])
			{
				vector12.x = Screen.width / 2;
			}
			else
			{
				vector12.x -= num5 * Scale[j].x;
			}
			if (LockAtCenterY[j - 1])
			{
				vector11.y = Screen.height / 2;
			}
			else
			{
				vector11.y -= num6 * Scale[j - 1].y;
			}
			if (LockAtCenterY[j])
			{
				vector12.y = Screen.height / 2;
			}
			else
			{
				vector12.y -= num6 * Scale[j].y;
			}
			vector12.x /= Screen.width;
			vector12.y /= Screen.height;
			vector11.x /= Screen.width;
			vector11.y /= Screen.height;
			vector11 = new Vector2(vector11.x * num + num3, vector11.y * num2 + num4);
			vector12 = new Vector2(vector12.x * num + num3, vector12.y * num2 + num4);
			float z2 = Mathf.Atan2(vector12.y - vector11.y, vector12.x - vector11.x) * 180f / (float)Math.PI;
			Vector2 vector13 = vector11 + new Vector2(0f, (0f - LineThickness) / 2f);
			Vector2 vector14 = vector11 + new Vector2(0f, LineThickness / 2f);
			Vector2 vector15 = vector12 + new Vector2(0f, LineThickness / 2f);
			Vector2 vector16 = vector12 + new Vector2(0f, (0f - LineThickness) / 2f);
			vector13 = RotatePointAroundPivot(vector13, vector11, new Vector3(0f, 0f, z2));
			vector14 = RotatePointAroundPivot(vector14, vector11, new Vector3(0f, 0f, z2));
			vector15 = RotatePointAroundPivot(vector15, vector12, new Vector3(0f, 0f, z2));
			vector16 = RotatePointAroundPivot(vector16, vector12, new Vector3(0f, 0f, z2));
			if (j > 1)
			{
				SetVbo(vbo, new Vector2[4] { vector, vector2, vector13, vector14 });
			}
			SetVbo(vbo, new Vector2[4] { vector13, vector14, vector15, vector16 });
			vector = vector15;
			vector2 = vector16;
		}
	}

	protected void SetVbo(List<UIVertex> vbo, Vector2[] vertices)
	{
		for (int i = 0; i < vertices.Length; i++)
		{
			UIVertex simpleVert = UIVertex.simpleVert;
			simpleVert.color = base.color;
			simpleVert.position = vertices[i];
			vbo.Add(simpleVert);
		}
	}

	public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
	{
		Vector3 vector = point - pivot;
		vector = Quaternion.Euler(angles) * vector;
		point = vector + pivot;
		return point;
	}
}
