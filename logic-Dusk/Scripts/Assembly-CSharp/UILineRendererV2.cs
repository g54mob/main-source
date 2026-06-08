using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI/Extensions/Primitives/UI Line Renderer V2")]
public class UILineRendererV2 : MaskableGraphic
{
	[SerializeField]
	private Texture m_Texture;

	[SerializeField]
	private Rect m_UVRect = new Rect(0f, 0f, 1f, 1f);

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

	public Vector2[] Points;

	public bool relativeSize;

	public override Texture mainTexture
	{
		get
		{
			return (!(m_Texture == null)) ? m_Texture : Graphic.s_WhiteTexture;
		}
	}

	public Texture texture
	{
		get
		{
			return m_Texture;
		}
		set
		{
			if (!(m_Texture == value))
			{
				m_Texture = value;
				SetVerticesDirty();
				SetMaterialDirty();
			}
		}
	}

	public Rect uvRect
	{
		get
		{
			return m_UVRect;
		}
		set
		{
			if (!(m_UVRect == value))
			{
				m_UVRect = value;
				SetVerticesDirty();
			}
		}
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		vh.Clear();
		float num = base.rectTransform.rect.width;
		float num2 = base.rectTransform.rect.height;
		float num3 = (0f - base.rectTransform.pivot.x) * base.rectTransform.rect.width;
		float num4 = (0f - base.rectTransform.pivot.y) * base.rectTransform.rect.height;
		Vector2 vector = Vector2.zero;
		Vector2 vector2 = Vector2.zero;
		if (Points != null && Points.Length >= 2)
		{
			Points = new Vector2[2]
			{
				new Vector2(0f, 0f),
				new Vector2(1f, 1f)
			};
			int num5 = 24;
			if (!relativeSize)
			{
				num = 1f;
				num2 = 1f;
			}
			List<Vector2> list = new List<Vector2>();
			list.Add(Points[0]);
			Vector2 item = Points[0] + (Points[1] - Points[0]).normalized * num5;
			list.Add(item);
			for (int i = 1; i < Points.Length - 1; i++)
			{
				list.Add(Points[i]);
			}
			item = Points[Points.Length - 1] - (Points[Points.Length - 1] - Points[Points.Length - 2]).normalized * num5;
			list.Add(item);
			list.Add(Points[Points.Length - 1]);
			Vector2[] array = list.ToArray();
			if (UseMargins)
			{
				num -= Margin.x;
				num2 -= Margin.y;
				num3 += Margin.x / 2f;
				num4 += Margin.y / 2f;
			}
			vh.Clear();
			for (int j = 1; j < array.Length; j++)
			{
				Vector2 vector3 = array[j - 1];
				Vector2 vector4 = array[j];
				vector3 = new Vector2(vector3.x * num + num3, vector3.y * num2 + num4);
				vector4 = new Vector2(vector4.x * num + num3, vector4.y * num2 + num4);
				if (flipFixedY)
				{
					vector3.y = (float)Screen.height - vector3.y;
					vector4.y = (float)Screen.height - vector4.y;
				}
				float z = Mathf.Atan2(vector4.y - vector3.y, vector4.x - vector3.x) * 180f / (float)Math.PI;
				Vector2 vector5 = vector3 + new Vector2(0f, (0f - LineThickness) / 2f);
				Vector2 vector6 = vector3 + new Vector2(0f, LineThickness / 2f);
				Vector2 vector7 = vector4 + new Vector2(0f, LineThickness / 2f);
				Vector2 vector8 = vector4 + new Vector2(0f, (0f - LineThickness) / 2f);
				vector5 = RotatePointAroundPivot(vector5, vector3, new Vector3(0f, 0f, z));
				vector6 = RotatePointAroundPivot(vector6, vector3, new Vector3(0f, 0f, z));
				vector7 = RotatePointAroundPivot(vector7, vector4, new Vector3(0f, 0f, z));
				vector8 = RotatePointAroundPivot(vector8, vector4, new Vector3(0f, 0f, z));
				Vector2 zero = Vector2.zero;
				Vector2 vector9 = new Vector2(0f, 1f);
				Vector2 vector10 = new Vector2(0.5f, 0f);
				Vector2 vector11 = new Vector2(0.5f, 1f);
				Vector2 vector12 = new Vector2(1f, 0f);
				Vector2 vector13 = new Vector2(1f, 1f);
				Vector2[] uvs = new Vector2[4] { vector10, vector11, vector11, vector10 };
				if (j > 1)
				{
					vh.AddUIVertexQuad(SetVbo(new Vector2[4] { vector, vector2, vector5, vector6 }, uvs));
				}
				if (j == 1)
				{
					uvs = new Vector2[4] { zero, vector9, vector11, vector10 };
				}
				else if (j == array.Length - 1)
				{
					uvs = new Vector2[4] { vector10, vector11, vector13, vector12 };
				}
				vh.AddUIVertexQuad(SetVbo(new Vector2[4] { vector5, vector6, vector7, vector8 }, uvs));
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
		for (int k = 1; k < ActualCoordPoints.Length; k++)
		{
			Vector2 vector14 = ActualCoordPoints[k - 1];
			Vector2 vector15 = ActualCoordPoints[k];
			Vector2 vector16 = vector14;
			Vector2 vector17 = vector15;
			if (flipFixedY)
			{
				vector16.y = (float)Screen.height - vector16.y;
				vector17.y = (float)Screen.height - vector17.y;
			}
			if (relativeToCenter)
			{
				vector16.x = (float)(Screen.width / 2) + vector16.x;
				vector16.y = (float)(Screen.height / 2) + vector16.y;
				vector17.x = (float)(Screen.width / 2) + vector17.x;
				vector17.y = (float)(Screen.height / 2) + vector17.y;
			}
			float num6 = (float)Screen.width - widthAt100PerScale;
			float num7 = (float)Screen.width - widthAt100PerScale;
			if (LockAtCenterX[k - 1])
			{
				vector16.x = Screen.width / 2;
			}
			else
			{
				vector16.x -= num6 * Scale[k - 1].x;
			}
			if (LockAtCenterX[k])
			{
				vector17.x = Screen.width / 2;
			}
			else
			{
				vector17.x -= num6 * Scale[k].x;
			}
			if (LockAtCenterY[k - 1])
			{
				vector16.y = Screen.height / 2;
			}
			else
			{
				vector16.y -= num7 * Scale[k - 1].y;
			}
			if (LockAtCenterY[k])
			{
				vector17.y = Screen.height / 2;
			}
			else
			{
				vector17.y -= num7 * Scale[k].y;
			}
			vector17.x /= Screen.width;
			vector17.y /= Screen.height;
			vector16.x /= Screen.width;
			vector16.y /= Screen.height;
			vector16 = new Vector2(vector16.x * num + num3, vector16.y * num2 + num4);
			vector17 = new Vector2(vector17.x * num + num3, vector17.y * num2 + num4);
			float z2 = Mathf.Atan2(vector17.y - vector16.y, vector17.x - vector16.x) * 180f / (float)Math.PI;
			Vector2 vector18 = vector16 + new Vector2(0f, (0f - LineThickness) / 2f);
			Vector2 vector19 = vector16 + new Vector2(0f, LineThickness / 2f);
			Vector2 vector20 = vector17 + new Vector2(0f, LineThickness / 2f);
			Vector2 vector21 = vector17 + new Vector2(0f, (0f - LineThickness) / 2f);
			vector18 = RotatePointAroundPivot(vector18, vector16, new Vector3(0f, 0f, z2));
			vector19 = RotatePointAroundPivot(vector19, vector16, new Vector3(0f, 0f, z2));
			vector20 = RotatePointAroundPivot(vector20, vector17, new Vector3(0f, 0f, z2));
			vector21 = RotatePointAroundPivot(vector21, vector17, new Vector3(0f, 0f, z2));
			Vector2 zero2 = Vector2.zero;
			Vector2 vector22 = new Vector2(0f, 1f);
			Vector2 vector23 = new Vector2(0.5f, 0f);
			Vector2 vector24 = new Vector2(0.5f, 1f);
			Vector2 vector25 = new Vector2(1f, 0f);
			Vector2 vector26 = new Vector2(1f, 1f);
			Vector2[] uvs2 = new Vector2[4] { vector23, vector24, vector24, vector23 };
			if (k > 1)
			{
				vh.AddUIVertexQuad(SetVbo(new Vector2[4] { vector, vector2, vector18, vector19 }, uvs2));
			}
			if (k == 1)
			{
				uvs2 = new Vector2[4] { zero2, vector22, vector24, vector23 };
			}
			else if (k == ActualCoordPoints.Length - 1)
			{
				uvs2 = new Vector2[4] { vector23, vector24, vector26, vector25 };
			}
			vh.AddUIVertexQuad(SetVbo(new Vector2[4] { vector18, vector19, vector20, vector21 }, uvs2));
			vector = vector20;
			vector2 = vector21;
		}
	}

	protected UIVertex[] SetVbo(Vector2[] vertices, Vector2[] uvs)
	{
		UIVertex[] array = new UIVertex[4];
		for (int i = 0; i < vertices.Length; i++)
		{
			UIVertex simpleVert = UIVertex.simpleVert;
			simpleVert.color = base.color;
			simpleVert.position = vertices[i];
			simpleVert.uv0 = uvs[i];
			array[i] = simpleVert;
		}
		return array;
	}

	public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
	{
		Vector3 vector = point - pivot;
		vector = Quaternion.Euler(angles) * vector;
		point = vector + pivot;
		return point;
	}
}
