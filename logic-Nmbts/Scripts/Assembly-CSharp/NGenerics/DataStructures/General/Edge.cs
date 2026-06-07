using System;
using NGenerics.Util;

namespace NGenerics.DataStructures.General
{
	[Serializable]
	public class Edge<T>
	{
		private readonly Vertex<T> from;

		private readonly Vertex<T> to;

		private readonly bool edgeIsDirected;

		public Vertex<T> FromVertex
		{
			get
			{
				return from;
			}
		}

		public Vertex<T> ToVertex
		{
			get
			{
				return to;
			}
		}

		public bool IsDirected
		{
			get
			{
				return edgeIsDirected;
			}
		}

		public double Weight { get; set; }

		public object Tag { get; set; }

		public Edge(Vertex<T> fromVertex, Vertex<T> toVertex, bool isDirected)
			: this(fromVertex, toVertex, 0.0, isDirected)
		{
		}

		public Edge(Vertex<T> fromVertex, Vertex<T> toVertex, double weight, bool isDirected)
		{
			Guard.ArgumentNotNull(toVertex, "toVertex");
			Guard.ArgumentNotNull(fromVertex, "fromVertex");
			from = fromVertex;
			to = toVertex;
			Weight = weight;
			edgeIsDirected = isDirected;
		}

		public Vertex<T> GetPartnerVertex(Vertex<T> vertex)
		{
			if (from == vertex)
			{
				return to;
			}
			if (to == vertex)
			{
				return from;
			}
			throw new ArgumentException("The vertex specified does not form part of this edge.", "vertex");
		}
	}
}
