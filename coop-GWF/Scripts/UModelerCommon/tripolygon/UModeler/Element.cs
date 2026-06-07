using System;
using System.Collections.Generic;
using UnityEngine;

namespace tripolygon.UModeler
{
	[Serializable]
	public class Element
	{
		public EElementType type;

		public List<Vertex> vertices;

		[SerializeField]
		private PolygonAndID polygonAndID_ = new PolygonAndID();

		public Vertex vertex => vertices[0];

		public Edge edge => new Edge(vertices[0].pos, vertices[1].pos);

		public ulong polygonID => polygonAndID_.id;

		public SimplePolygon polygon
		{
			get
			{
				return polygonAndID_.polygon;
			}
			set
			{
				if (value != null && value.IsValid())
				{
					polygonAndID_.polygon = value;
					vertices = new List<Vertex>();
					for (int i = 0; i < value.GetVertexCount(); i++)
					{
						vertices.Add(value.GetVertex(i).Clone());
					}
					type = EElementType.Polygon;
				}
				else
				{
					polygonAndID_.polygon = null;
				}
			}
		}

		public Vector3 normal
		{
			get
			{
				if (polygon != null)
				{
					return polygon.plane.normal;
				}
				EditableMeshCache editableMeshCache = UMContext.activeModeler.editableMesh.editableMeshCache;
				Vector3 zero = Vector3.zero;
				int num = 0;
				while (vertices != null && num < vertices.Count)
				{
					VertexInfo vertexInfo = editableMeshCache.FindVertexByPos(vertices[num].pos);
					if (vertexInfo != null)
					{
						for (int i = 0; i < vertexInfo.tokens.Count; i++)
						{
							zero += vertexInfo.tokens[i].polygon.plane.normal;
						}
					}
					num++;
				}
				if (!(zero != Vector3.zero))
				{
					return Vector3.zero;
				}
				return zero.normalized;
			}
		}

		public AABB aabb
		{
			get
			{
				if (polygon != null && polygon.IsValid())
				{
					return polygon.aabb;
				}
				AABB aABB = new AABB();
				aABB.Reset();
				int num = 0;
				while (vertices != null && num < vertices.Count)
				{
					aABB.Add(vertices[num].pos);
					num++;
				}
				return aABB;
			}
		}

		public Element Clone()
		{
			Element element = new Element();
			element.type = type;
			element.polygonAndID_ = polygonAndID_.Clone();
			if (vertices != null)
			{
				element.vertices = new List<Vertex>();
				for (int i = 0; i < vertices.Count; i++)
				{
					element.vertices.Add(vertices[i].Clone());
				}
			}
			else
			{
				element.vertices = null;
			}
			return element;
		}

		public void Invalidate()
		{
			polygonAndID_.Invalidate();
		}
	}
}
