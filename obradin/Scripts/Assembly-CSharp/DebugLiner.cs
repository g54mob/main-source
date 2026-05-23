using System;
using System.Collections.Generic;
using UnityEngine;

public class DebugLiner
{
	public delegate void DebugDrawFunc(DebugLiner liner);

	public struct Seg
	{
		public Color color;

		public Vector3 a;

		public Vector3 b;

		public float dashLen;

		public Seg(Color color_, Vector3 a_, Vector3 b_, float dashLen_)
		{
			color = color_;
			a = a_;
			b = b_;
			dashLen = dashLen_;
		}
	}

	public struct Text
	{
		public Color color;

		public string text;

		public Vector3 center;

		public float charHeight;

		public bool alignLeft;
	}

	private bool gizmos;

	private Color color_;

	private Matrix4x4 matrix_;

	private List<Seg> segs = new List<Seg>();

	private List<Text> texts = new List<Text>();

	private static GUIStyle customLabelStyle;

	public Color color
	{
		get
		{
			return (!gizmos) ? color_ : Gizmos.color;
		}
		set
		{
			if (gizmos)
			{
				Gizmos.color = value;
			}
			else
			{
				color_ = value;
			}
		}
	}

	public Matrix4x4 matrix
	{
		get
		{
			return (!gizmos) ? matrix_ : Gizmos.matrix;
		}
		set
		{
			if (gizmos)
			{
				Gizmos.matrix = value;
			}
			else
			{
				matrix_ = value;
			}
		}
	}

	public DebugLiner(bool gizmos_)
	{
		gizmos = gizmos_;
		matrix_ = Matrix4x4.identity;
	}

	public void DrawLine(Vector3 a, Vector3 b, float dashLen = 0f)
	{
		segs.Add(new Seg(color_, matrix_.MultiplyPoint(a), matrix_.MultiplyPoint(b), dashLen));
	}

	public void DrawCircle(Matrix4x4 mat, int numPoints)
	{
		Vector3 vector = new Vector3(0f, 0f, 0f);
		Vector3 vector2 = new Vector3(0f, 0f, 0f);
		for (int i = 0; i <= numPoints; i++)
		{
			float num = (float)i / (float)numPoints;
			float f = num * 2f * (float)Math.PI;
			vector2 = vector;
			vector = mat.MultiplyPoint(new Vector3(Mathf.Cos(f), Mathf.Sin(f), 0f));
			if (i != 0)
			{
				DrawLine(vector, vector2);
			}
		}
	}

	public void DrawRay(Vector3 origin, Vector3 dir)
	{
		DrawLine(origin, origin + dir);
	}

	public void DrawSphere(Vector3 center, float radius)
	{
		Matrix4x4 matrix4x = Matrix4x4.TRS(center, Quaternion.identity, radius * Vector3.one);
		DrawCircle(matrix4x, 16);
		DrawCircle(Util.MakeComponentMatrix(matrix4x.GetZ(), matrix4x.GetY(), -matrix4x.GetX(), matrix4x.GetT()), 16);
		DrawCircle(Util.MakeComponentMatrix(matrix4x.GetZ(), matrix4x.GetX(), matrix4x.GetY(), matrix4x.GetT()), 16);
	}

	public void DrawText(string text, Vector3 center, float charHeight, bool alignLeft = false)
	{
		texts.Add(new Text
		{
			color = color_,
			text = text,
			center = center,
			charHeight = charHeight,
			alignLeft = alignLeft
		});
	}

	public void Flush()
	{
		if (gizmos || (segs.Count == 0 && texts.Count == 0))
		{
			return;
		}
		DebugDrawer.World(delegate(DebugDrawer dd)
		{
			foreach (Seg seg in segs)
			{
				float magnitude = (seg.a - seg.b).magnitude;
				if (seg.dashLen > 0f && magnitude > seg.dashLen)
				{
					int num = Mathf.RoundToInt(magnitude / seg.dashLen);
					for (int i = 0; i < num; i++)
					{
						float t = (float)i / (float)num;
						float t2 = ((float)i + ((i >= num - 1) ? 1f : 0.75f)) / (float)num;
						Vector3 p = Vector3.Lerp(seg.a, seg.b, t);
						Vector3 p2 = Vector3.Lerp(seg.a, seg.b, t2);
						dd.DrawLine(seg.color, p, p2);
					}
				}
				else
				{
					dd.DrawLine(seg.color, seg.a, seg.b);
				}
			}
			segs.Clear();
			Vector3 cameraFacingNorm = dd.cameraFacingNorm;
			foreach (Text text in texts)
			{
				dd.DrawText(text.color, text.text, text.center, cameraFacingNorm, text.charHeight, text.alignLeft);
			}
			texts.Clear();
		});
	}

	public static void CallAndFlush(DebugDrawFunc debugDrawFunc, bool gizmos)
	{
		DebugLiner debugLiner = new DebugLiner(gizmos);
		debugDrawFunc(debugLiner);
		debugLiner.Flush();
	}
}
