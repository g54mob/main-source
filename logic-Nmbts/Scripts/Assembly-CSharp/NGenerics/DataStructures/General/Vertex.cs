using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NGenerics.DataStructures.General
{
	[Serializable]
	public class Vertex<T>
	{
		private readonly List<Edge<T>> incidentEdges;

		private readonly List<Edge<T>> emanatingEdges;

		public double Weight { get; set; }

		public T Data { get; set; }

		public int Degree
		{
			get
			{
				return emanatingEdges.Count;
			}
		}

		public IList<Edge<T>> IncidentEdges
		{
			get
			{
				return new ReadOnlyCollection<Edge<T>>(incidentEdges);
			}
		}

		public IList<Edge<T>> EmanatingEdges
		{
			get
			{
				return new ReadOnlyCollection<Edge<T>>(emanatingEdges);
			}
		}

		public int IncomingEdgeCount
		{
			get
			{
				return incidentEdges.Count - emanatingEdges.Count;
			}
		}

		public Vertex(T data)
		{
			Data = data;
			incidentEdges = new List<Edge<T>>();
			emanatingEdges = new List<Edge<T>>();
			Weight = 0.0;
		}

		public Vertex(T data, double weight)
		{
			Data = data;
			incidentEdges = new List<Edge<T>>();
			emanatingEdges = new List<Edge<T>>();
			Weight = weight;
		}

		public bool HasEmanatingEdgeTo(Vertex<T> toVertex)
		{
			for (int i = 0; i < emanatingEdges.Count; i++)
			{
				Edge<T> edge = emanatingEdges[i];
				if (edge.IsDirected)
				{
					if (edge.ToVertex == toVertex)
					{
						return true;
					}
				}
				else if (edge.ToVertex == toVertex || edge.FromVertex == toVertex)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasIncidentEdgeWith(Vertex<T> fromVertex)
		{
			for (int i = 0; i < incidentEdges.Count; i++)
			{
				Edge<T> edge = incidentEdges[i];
				if (edge.FromVertex == fromVertex || edge.ToVertex == fromVertex)
				{
					return true;
				}
			}
			return false;
		}

		public Edge<T> GetEmanatingEdgeTo(Vertex<T> toVertex)
		{
			for (int i = 0; i < emanatingEdges.Count; i++)
			{
				Edge<T> edge = emanatingEdges[i];
				if (edge.IsDirected)
				{
					if (edge.ToVertex == toVertex)
					{
						return edge;
					}
				}
				else if (edge.FromVertex == toVertex || edge.ToVertex == toVertex)
				{
					return edge;
				}
			}
			return null;
		}

		public Edge<T> GetIncidentEdgeWith(Vertex<T> toVertex)
		{
			for (int i = 0; i < incidentEdges.Count; i++)
			{
				Edge<T> edge = incidentEdges[i];
				if (edge.ToVertex == toVertex || edge.FromVertex == toVertex)
				{
					return edge;
				}
			}
			return null;
		}

		internal void RemoveEdge(Edge<T> edge)
		{
			RemoveEdgeFromVertex(edge);
		}

		internal void AddEdge(Edge<T> edge)
		{
			if (edge.IsDirected)
			{
				if (edge.FromVertex == this)
				{
					emanatingEdges.Add(edge);
				}
			}
			else
			{
				emanatingEdges.Add(edge);
			}
			incidentEdges.Add(edge);
		}

		private void RemoveEdgeFromVertex(Edge<T> edge)
		{
			incidentEdges.Remove(edge);
			if (edge.IsDirected)
			{
				if (edge.FromVertex == this)
				{
					emanatingEdges.Remove(edge);
				}
			}
			else
			{
				emanatingEdges.Remove(edge);
			}
		}
	}
}
