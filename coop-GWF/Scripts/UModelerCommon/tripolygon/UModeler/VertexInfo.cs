using System.Collections.Generic;
using UnityEngine;

namespace tripolygon.UModeler
{
	public class VertexInfo : SelectExtended
	{
		public List<Token> tokens = new List<Token>();

		public Vector3 pos
		{
			get
			{
				if (tokens.Count > 0)
				{
					return tokens[0].polygon.GetVertex(tokens[0].vtxIndex).pos;
				}
				return Vector3.zero;
			}
			set
			{
				for (int i = 0; i < tokens.Count; i++)
				{
					tokens[i].position = value;
				}
			}
		}

		public Vector2 uv
		{
			get
			{
				if (tokens.Count > 0)
				{
					return tokens[0].polygon.GetVertex(tokens[0].vtxIndex).uv;
				}
				return Vector2.zero;
			}
			set
			{
				for (int i = 0; i < tokens.Count; i++)
				{
					tokens[i].uv = value;
				}
			}
		}

		public Color color
		{
			get
			{
				return tokens[0].color;
			}
			set
			{
				for (int i = 0; i < tokens.Count; i++)
				{
					tokens[i].color = value;
				}
			}
		}

		public Vertex vtx
		{
			get
			{
				if (tokens.Count > 0)
				{
					return tokens[0].polygon.GetVertex(tokens[0].vtxIndex);
				}
				return null;
			}
		}

		public bool IsValid()
		{
			if (tokens.Count > 0 && tokens[0].polygon != null && tokens[0].vtxIndex >= 0)
			{
				return tokens[0].vtxIndex < tokens[0].polygon.GetVertexCount();
			}
			return false;
		}

		public void AddToken(Token token)
		{
			if (FindToken(token.vtxIndex, token.polygon) == null)
			{
				tokens.Add(token);
			}
		}

		public Token FindToken(int vtxIdx, SimplePolygon polygon)
		{
			for (int i = 0; i < tokens.Count; i++)
			{
				if (tokens[i].polygon == polygon && tokens[i].vtxIndex == vtxIdx)
				{
					return tokens[i];
				}
			}
			return null;
		}

		public Token FindToken(Vertex vertex)
		{
			foreach (Token token in tokens)
			{
				if (token.vertex == vertex)
				{
					return token;
				}
			}
			return null;
		}

		public bool RemoveToken(Vertex vertex)
		{
			foreach (Token token in tokens)
			{
				if (token.vertex == null)
				{
					return false;
				}
				if (token.vertex == vertex)
				{
					tokens.Remove(token);
					return true;
				}
			}
			return false;
		}
	}
}
