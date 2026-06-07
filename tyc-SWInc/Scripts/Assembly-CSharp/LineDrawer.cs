using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LineDrawer : MaskableGraphic
{
	public class GraphicsLine
	{
		public Vector2[] Points;

		public Vector2[] UVs;

		public Color Col;

		public float Width;

		public bool Cyclic;

		public bool Mesh;

		public GraphicsLine(Vector2[] points, Color col, float width, bool cyclic)
		{
			Points = points;
			Col = col;
			Width = width;
			Cyclic = cyclic;
		}

		public GraphicsLine(Vector2[] points, Vector2[] uvs)
		{
			Points = points;
			UVs = uvs;
			Mesh = true;
		}
	}

	public bool OverrideTex;

	public Texture Tex;

	public List<GraphicsLine> Lines = new List<GraphicsLine>();

	public bool Normalize;

	public Rect? NormalizeRect;

	public override Texture mainTexture
	{
		get
		{
			if (!OverrideTex)
			{
				return base.mainTexture;
			}
			return Tex;
		}
	}

	public void AddLine(Color col, float width, bool cyclic, params Vector2[] points)
	{
		Lines.Add(new GraphicsLine(points, col, width, cyclic));
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		vh.Clear();
		Rect inner = ((!Normalize) ? default(Rect) : (NormalizeRect ?? Lines.SelectMany((GraphicsLine x) => x.Points).ToList().GetBounds()));
		for (int num = 0; num < Lines.Count; num++)
		{
			GraphicsLine graphicsLine = Lines[num];
			if (graphicsLine.Mesh)
			{
				int currentVertCount = vh.currentVertCount;
				for (int num2 = 0; num2 < graphicsLine.Points.Length; num2++)
				{
					Vector2 vector = graphicsLine.Points[num2];
					Vector2 uv = graphicsLine.UVs[num2];
					vh.AddVert(Normalize ? vector.NormalizePoint(inner, base.rectTransform.rect) : vector, Color.white, uv);
				}
				int num3 = graphicsLine.Points.Length / 3;
				for (int num4 = 0; num4 < num3; num4++)
				{
					vh.AddTriangle(currentVertCount + num4 * 3, currentVertCount + num4 * 3 + 1, currentVertCount + num4 * 3 + 2);
				}
				continue;
			}
			int num5 = (graphicsLine.Cyclic ? graphicsLine.Points.Length : (graphicsLine.Points.Length - 1));
			for (int num6 = 0; num6 < num5; num6++)
			{
				Vector2 vector2 = graphicsLine.Points[num6];
				Vector2 vector3 = (graphicsLine.Cyclic ? graphicsLine.Points[(num6 + 1) % graphicsLine.Points.Length] : graphicsLine.Points[num6 + 1]);
				Color col = graphicsLine.Col;
				if (Normalize)
				{
					Utilities.DrawLine(vector2.NormalizePoint(inner, base.rectTransform.rect), vector3.NormalizePoint(inner, base.rectTransform.rect), graphicsLine.Width, col, vh);
				}
				else
				{
					Utilities.DrawLine(vector2, vector3, graphicsLine.Width, col, vh);
				}
			}
		}
	}
}
