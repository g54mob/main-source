using System;
using System.Collections.Generic;
using NGenerics.Comparers;
using NGenerics.DataStructures.General;
using NGenerics.Util;

namespace NGenerics.Algorithms
{
	public static class GraphAlgorithms
	{
		public static Graph<T> DijkstrasAlgorithm<T>(Graph<T> weightedGraph, Vertex<T> fromVertex)
		{
			Guard.ArgumentNotNull(weightedGraph, "weightedGraph");
			Guard.ArgumentNotNull(fromVertex, "fromVertex");
			if (!weightedGraph.ContainsVertex(fromVertex))
			{
				throw new ArgumentException("The vertex specified could not be found in the graph.", "fromVertex");
			}
			Heap<Association<double, Vertex<T>>> heap = new Heap<Association<double, Vertex<T>>>(HeapType.Minimum, new AssociationKeyComparer<double, Vertex<T>>());
			Dictionary<Vertex<T>, VertexInfo<T>> dictionary = new Dictionary<Vertex<T>, VertexInfo<T>>();
			foreach (Vertex<T> vertex in weightedGraph.Vertices)
			{
				dictionary.Add(vertex, new VertexInfo<T>(double.MaxValue, null, false));
			}
			dictionary[fromVertex].Distance = 0.0;
			heap.Add(new Association<double, Vertex<T>>(0.0, fromVertex));
			while (heap.Count > 0)
			{
				Association<double, Vertex<T>> association = heap.RemoveRoot();
				VertexInfo<T> vertexInfo = dictionary[association.Value];
				if (vertexInfo.IsFinalised)
				{
					continue;
				}
				IList<Edge<T>> emanatingEdges = association.Value.EmanatingEdges;
				dictionary[association.Value].IsFinalised = true;
				for (int i = 0; i < emanatingEdges.Count; i++)
				{
					Edge<T> edge = emanatingEdges[i];
					Vertex<T> partnerVertex = edge.GetPartnerVertex(association.Value);
					double num = vertexInfo.Distance + edge.Weight;
					VertexInfo<T> vertexInfo2 = dictionary[partnerVertex];
					if (num < vertexInfo2.Distance)
					{
						vertexInfo2.EdgeFollowed = edge;
						vertexInfo2.Distance = num;
						heap.Add(new Association<double, Vertex<T>>(num, partnerVertex));
					}
				}
			}
			return BuildGraphDijkstra(weightedGraph, fromVertex, dictionary);
		}

		public static Graph<T> PrimsAlgorithm<T>(Graph<T> weightedGraph, Vertex<T> fromVertex)
		{
			Guard.ArgumentNotNull(weightedGraph, "weightedGraph");
			Guard.ArgumentNotNull(fromVertex, "fromVertex");
			if (!weightedGraph.ContainsVertex(fromVertex))
			{
				throw new ArgumentException("The vertex specified could not be found in the graph.", "fromVertex");
			}
			Heap<Association<double, Vertex<T>>> heap = new Heap<Association<double, Vertex<T>>>(HeapType.Minimum, new AssociationKeyComparer<double, Vertex<T>>());
			Dictionary<Vertex<T>, VertexInfo<T>> dictionary = new Dictionary<Vertex<T>, VertexInfo<T>>();
			foreach (Vertex<T> vertex in weightedGraph.Vertices)
			{
				dictionary.Add(vertex, new VertexInfo<T>(double.MaxValue, null, false));
			}
			dictionary[fromVertex].Distance = 0.0;
			heap.Add(new Association<double, Vertex<T>>(0.0, fromVertex));
			while (heap.Count > 0)
			{
				Association<double, Vertex<T>> association = heap.RemoveRoot();
				IList<Edge<T>> incidentEdges = association.Value.IncidentEdges;
				dictionary[association.Value].IsFinalised = true;
				for (int i = 0; i < incidentEdges.Count; i++)
				{
					Edge<T> edge = incidentEdges[i];
					Vertex<T> partnerVertex = edge.GetPartnerVertex(association.Value);
					VertexInfo<T> vertexInfo = dictionary[partnerVertex];
					if (!vertexInfo.IsFinalised && edge.Weight < vertexInfo.Distance)
					{
						vertexInfo.EdgeFollowed = edge;
						vertexInfo.Distance = edge.Weight;
						heap.Add(new Association<double, Vertex<T>>(edge.Weight, partnerVertex));
					}
				}
			}
			return BuildGraphPrim(weightedGraph, dictionary);
		}

		public static Graph<T> KruskalsAlgorithm<T>(Graph<T> weightedGraph)
		{
			Guard.ArgumentNotNull(weightedGraph, "weightedGraph");
			int num = weightedGraph.Vertices.Count - 1;
			Dictionary<Vertex<T>, Vertex<T>> dictionary = new Dictionary<Vertex<T>, Vertex<T>>();
			Dictionary<Vertex<T>, Vertex<T>> dictionary2 = new Dictionary<Vertex<T>, Vertex<T>>();
			Heap<Association<double, Edge<T>>> heap = new Heap<Association<double, Edge<T>>>(HeapType.Minimum, new AssociationKeyComparer<double, Edge<T>>());
			Graph<T> graph = new Graph<T>(false);
			foreach (Vertex<T> vertex4 in weightedGraph.Vertices)
			{
				Vertex<T> vertex = new Vertex<T>(vertex4.Data);
				dictionary2.Add(vertex4, vertex);
				graph.AddVertex(vertex);
				dictionary.Add(vertex4, null);
			}
			foreach (Edge<T> edge in weightedGraph.Edges)
			{
				heap.Add(new Association<double, Edge<T>>(edge.Weight, edge));
			}
			while (heap.Count > 0 && num > 0)
			{
				Edge<T> value = heap.RemoveRoot().Value;
				Vertex<T> vertex2 = value.FromVertex;
				Vertex<T> vertex3 = value.ToVertex;
				while (dictionary[vertex2] != null)
				{
					vertex2 = dictionary[vertex2];
				}
				while (dictionary[vertex3] != null)
				{
					vertex3 = dictionary[vertex3];
				}
				if (vertex2 != vertex3)
				{
					dictionary[vertex2] = value.ToVertex;
					num--;
					graph.AddEdge(dictionary2[value.FromVertex], dictionary2[value.ToVertex], value.Weight);
				}
			}
			return graph;
		}

		private static Graph<T> BuildGraphPrim<T>(Graph<T> weightedGraph, ICollection<KeyValuePair<Vertex<T>, VertexInfo<T>>> vertexStatus)
		{
			Graph<T> graph = new Graph<T>(weightedGraph.IsDirected);
			Dictionary<Vertex<T>, Vertex<T>> dictionary = new Dictionary<Vertex<T>, Vertex<T>>(vertexStatus.Count);
			foreach (KeyValuePair<Vertex<T>, VertexInfo<T>> item in vertexStatus)
			{
				Vertex<T> vertex = new Vertex<T>(item.Key.Data, item.Key.Weight);
				dictionary.Add(item.Key, vertex);
				graph.AddVertex(vertex);
			}
			foreach (KeyValuePair<Vertex<T>, VertexInfo<T>> item2 in vertexStatus)
			{
				VertexInfo<T> value = item2.Value;
				if (value.EdgeFollowed != null)
				{
					graph.AddEdge(dictionary[value.EdgeFollowed.GetPartnerVertex(item2.Key)], dictionary[item2.Key], value.Distance);
				}
			}
			return graph;
		}

		private static Graph<T> BuildGraphDijkstra<T>(Graph<T> weightedGraph, Vertex<T> fromVertex, ICollection<KeyValuePair<Vertex<T>, VertexInfo<T>>> vertexStatus)
		{
			Graph<T> graph = new Graph<T>(weightedGraph.IsDirected);
			Dictionary<Vertex<T>, Vertex<T>> dictionary = new Dictionary<Vertex<T>, Vertex<T>>(vertexStatus.Count);
			foreach (KeyValuePair<Vertex<T>, VertexInfo<T>> item in vertexStatus)
			{
				Vertex<T> vertex = new Vertex<T>(item.Key.Data, item.Value.Distance);
				dictionary.Add(item.Key, vertex);
				graph.AddVertex(vertex);
			}
			foreach (KeyValuePair<Vertex<T>, VertexInfo<T>> item2 in vertexStatus)
			{
				VertexInfo<T> value = item2.Value;
				if (value.EdgeFollowed != null && item2.Key != fromVertex)
				{
					graph.AddEdge(dictionary[value.EdgeFollowed.GetPartnerVertex(item2.Key)], dictionary[item2.Key], value.EdgeFollowed.Weight);
				}
			}
			return graph;
		}
	}
}
