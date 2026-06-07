using UnityEngine;

namespace tripolygon.UModeler
{
	public class GLUtil
	{
		private static Material material_;

		public static Material material
		{
			get
			{
				if (material_ == null)
				{
					material_ = new Material(Shader.Find("Hidden/Internal-Colored"));
					material_.hideFlags = HideFlags.HideAndDontSave;
					material_.SetInt("_SrcBlend", 5);
					material_.SetInt("_DstBlend", 10);
					material_.SetInt("_Cull", 0);
					material_.SetInt("_ZWrite", 1);
					material_.SetInt("_ZTest", 2);
				}
				return material_;
			}
		}

		public static Color color
		{
			set
			{
				GL.Color(value);
			}
		}

		public static void Begin(int mode, bool ztest = true)
		{
			if (ztest)
			{
				material.SetInt("_ZWrite", 1);
				material.SetInt("_ZTest", 2);
			}
			else
			{
				material.SetInt("_ZWrite", 0);
				material.SetInt("_ZTest", 8);
			}
			material.SetPass(0);
			GL.Begin(mode);
		}

		public static void End()
		{
			GL.End();
		}

		public static void DrawLine(Vector3 v0, Vector3 v1)
		{
			GL.Vertex(v0);
			GL.Vertex(v1);
		}

		public static void DrawTriangle(Vector3 v0, Vector3 v1, Vector3 v2)
		{
			GL.Vertex(v0);
			GL.Vertex(v1);
			GL.Vertex(v2);
		}

		public static void DrawPolygonEdges(SimplePolygon polygon, SelectionType type, float offset = 0f)
		{
			Vector3 scaledNormal = Util.GetScaledNormal(polygon.plane.normal);
			for (int i = 0; i < polygon.GetEdgeCount(); i++)
			{
				if (polygon.GetEdge(i).selection == type)
				{
					Edge pureEdge = polygon.GetPureEdge(i);
					if (polygon.plane != null)
					{
						DrawLine(pureEdge.p0 + scaledNormal * offset, pureEdge.p1 + scaledNormal * offset);
					}
					else
					{
						DrawLine(pureEdge.p0, pureEdge.p1);
					}
				}
			}
		}
	}
}
