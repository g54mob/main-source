using System;
using UnityEngine;

namespace tripolygon.UModeler
{
	[Serializable]
	public class Vertex
	{
		public Vector3 pos;

		public Vector2 uv;

		public Color color;

		public Vertex(Vertex vertex)
		{
			Set(vertex);
		}

		public Vertex(Vector3 _pos)
		{
			Set(_pos);
		}

		public Vertex(Vector3 _pos, Vector2 _uv)
		{
			Set(_pos, _uv);
		}

		public Vertex(Vector3 _pos, Vector2 _uv, Color _color)
		{
			Set(_pos, _uv, _color);
		}

		public void Set(Vector3 _pos)
		{
			pos = _pos;
			uv = new Vector2(0f, 0f);
			color = Color.white;
		}

		public void Set(Vector3 _pos, Vector2 _uv)
		{
			pos = _pos;
			uv = _uv;
			color = Color.white;
		}

		public void Set(Vector3 _pos, Vector2 _uv, Color _color)
		{
			pos = _pos;
			uv = _uv;
			color = _color;
		}

		public void Set(Vertex v)
		{
			pos = v.pos;
			uv = v.uv;
			color = v.color;
		}

		public Vertex Clone()
		{
			return new Vertex(pos, uv, color);
		}
	}
}
