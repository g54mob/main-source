using UnityEngine;

namespace tripolygon.UModeler
{
	public class Token
	{
		public SimplePolygon polygon;

		public int vtxIndex;

		public Vector3 position
		{
			get
			{
				return polygon.GetVertex(vtxIndex).pos;
			}
			set
			{
				polygon.SetPos(vtxIndex, value);
			}
		}

		public Vector2 uv
		{
			get
			{
				return polygon.GetVertex(vtxIndex).uv;
			}
			set
			{
				polygon.SetUV(vtxIndex, value);
			}
		}

		public Color color
		{
			get
			{
				return polygon.GetVertex(vtxIndex).color;
			}
			set
			{
				polygon.SetColor(vtxIndex, value);
			}
		}

		public Vertex vertex
		{
			get
			{
				if (vtxIndex < 0 || vtxIndex >= polygon.GetVertexCount())
				{
					return null;
				}
				return polygon.GetVertex(vtxIndex);
			}
		}

		public void Update(SimplePolygon _polygon, int _vtxIdx)
		{
			polygon = _polygon;
			vtxIndex = _vtxIdx;
		}

		public Token()
		{
		}

		public Token(SimplePolygon _polygon, int _vtxIdx)
		{
			Update(_polygon, _vtxIdx);
		}
	}
}
