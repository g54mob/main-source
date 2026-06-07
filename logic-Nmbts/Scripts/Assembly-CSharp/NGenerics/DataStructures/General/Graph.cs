using System;
using System.Collections;
using System.Collections.Generic;
using NGenerics.Patterns.Visitor;
using NGenerics.Util;

namespace NGenerics.DataStructures.General
{
	[Serializable]
	public class Graph<T> : ICollection<T>, IEnumerable<T>, IEnumerable
	{
		internal const string couldNotBeFoundInTheGraph = "The vertex specified could not be found in the graph.";

		private const string graphIsEmpty = "The graph is empty.";

		private readonly Dictionary<Vertex<T>, object> graphVertices;

		private readonly Dictionary<Edge<T>, object> graphEdges;

		private readonly bool graphIsDirected;

		public bool IsEmpty
		{
			get
			{
				return graphVertices.Count == 0;
			}
		}

		int ICollection<T>.Count
		{
			get
			{
				return graphVertices.Count;
			}
		}

		public bool IsDirected
		{
			get
			{
				return graphIsDirected;
			}
		}

		public ICollection<Vertex<T>> Vertices
		{
			get
			{
				return graphVertices.Keys;
			}
		}

		public ICollection<Edge<T>> Edges
		{
			get
			{
				return graphEdges.Keys;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public Graph(bool isDirected)
		{
			graphIsDirected = isDirected;
			graphVertices = new Dictionary<Vertex<T>, object>();
			graphEdges = new Dictionary<Edge<T>, object>();
		}

		void ICollection<T>.Add(T item)
		{
			AddVertex(new Vertex<T>(item));
		}

		bool ICollection<T>.Contains(T item)
		{
			return ContainsVertex(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			Guard.ArgumentNotNull(array, "array");
			if (array.Length - arrayIndex < graphVertices.Count)
			{
				throw new ArgumentException("Not enough space in the target array.", "array");
			}
			int num = arrayIndex;
			foreach (Vertex<T> key in graphVertices.Keys)
			{
				array.SetValue(key.Data, num);
				num++;
			}
		}

		bool ICollection<T>.Remove(T item)
		{
			return RemoveVertex(item);
		}

		public IEnumerator<T> GetEnumerator()
		{
			List<Vertex<T>> vertexList = new List<Vertex<T>>(graphVertices.Count);
			vertexList.AddRange(graphVertices.Keys);
			for (int i = 0; i < vertexList.Count; i++)
			{
				yield return vertexList[i].Data;
			}
		}

		public void Clear()
		{
			graphVertices.Clear();
			graphEdges.Clear();
		}

		public void DepthFirstTraversal(OrderedVisitor<Vertex<T>> visitor, Vertex<T> startVertex)
		{
			Guard.ArgumentNotNull(visitor, "visitor");
			Guard.ArgumentNotNull(startVertex, "startVertex");
			List<Vertex<T>> visitedVertices = new List<Vertex<T>>(graphVertices.Count);
			DepthFirstTraversal(visitor, startVertex, ref visitedVertices);
		}

		public bool IsCyclic()
		{
			DummyVisitor<Vertex<T>> visitor = new DummyVisitor<Vertex<T>>();
			return TopologicalSortTraversalInternal(visitor) < graphVertices.Count;
		}

		public IList<Vertex<T>> TopologicalSort()
		{
			TrackingVisitor<Vertex<T>> trackingVisitor = new TrackingVisitor<Vertex<T>>();
			TopologicalSortTraversal(trackingVisitor);
			return trackingVisitor.TrackingList;
		}

		public void TopologicalSortTraversal(IVisitor<Vertex<T>> visitor)
		{
			if (TopologicalSortTraversalInternal(visitor) < graphVertices.Count)
			{
				throw new InvalidOperationException("A cycle was found in the graph.");
			}
		}

		public void BreadthFirstTraversal(IVisitor<Vertex<T>> visitor, Vertex<T> startVertex)
		{
			Guard.ArgumentNotNull(visitor, "visitor");
			Guard.ArgumentNotNull(startVertex, "startVertex");
			List<Vertex<T>> list = new List<Vertex<T>>(graphVertices.Count);
			Queue<Vertex<T>> queue = new Queue<Vertex<T>>();
			queue.Enqueue(startVertex);
			list.Add(startVertex);
			while (queue.Count != 0 && !visitor.HasCompleted)
			{
				Vertex<T> vertex = queue.Dequeue();
				visitor.Visit(vertex);
				IList<Edge<T>> emanatingEdges = vertex.EmanatingEdges;
				for (int i = 0; i < emanatingEdges.Count; i++)
				{
					Vertex<T> partnerVertex = emanatingEdges[i].GetPartnerVertex(vertex);
					if (!list.Contains(partnerVertex))
					{
						queue.Enqueue(partnerVertex);
						list.Add(partnerVertex);
					}
				}
			}
		}

		public bool RemoveVertex(Vertex<T> vertex)
		{
			if (!graphVertices.Remove(vertex))
			{
				return false;
			}
			IList<Edge<T>> incidentEdges = vertex.IncidentEdges;
			while (incidentEdges.Count > 0)
			{
				RemoveEdge(incidentEdges[0]);
			}
			return true;
		}

		public bool RemoveVertex(T item)
		{
			foreach (Vertex<T> key in graphVertices.Keys)
			{
				if (key.Data.Equals(item))
				{
					RemoveVertex(key);
					return true;
				}
			}
			return false;
		}

		public bool ContainsVertex(Vertex<T> vertex)
		{
			return graphVertices.ContainsKey(vertex);
		}

		public bool ContainsVertex(T item)
		{
			foreach (Vertex<T> key in graphVertices.Keys)
			{
				if (key.Data.Equals(item))
				{
					return true;
				}
			}
			return false;
		}

		public bool RemoveEdge(Edge<T> edge)
		{
			CheckEdgeNotNull(edge);
			if (!graphEdges.Remove(edge))
			{
				return false;
			}
			edge.FromVertex.RemoveEdge(edge);
			edge.ToVertex.RemoveEdge(edge);
			return true;
		}

		public bool RemoveEdge(Vertex<T> from, Vertex<T> to)
		{
			Guard.ArgumentNotNull(from, "from");
			Guard.ArgumentNotNull(to, "to");
			if (graphIsDirected)
			{
				foreach (Edge<T> key in graphEdges.Keys)
				{
					if (key.FromVertex == from && key.ToVertex == to)
					{
						RemoveEdge(key);
						return true;
					}
				}
			}
			else
			{
				foreach (Edge<T> key2 in graphEdges.Keys)
				{
					if ((key2.FromVertex == from && key2.ToVertex == to) || (key2.FromVertex == to && key2.ToVertex == from))
					{
						RemoveEdge(key2);
						return true;
					}
				}
			}
			return false;
		}

		public void AddEdge(Edge<T> edge)
		{
			CheckEdgeNotNull(edge);
			if (edge.IsDirected != graphIsDirected)
			{
				throw new ArgumentException("The type of edge must be the same as the type of graph (Undirected / Directed)", "edge");
			}
			if (!graphVertices.ContainsKey(edge.FromVertex) || !graphVertices.ContainsKey(edge.ToVertex))
			{
				throw new ArgumentException("The vertex specified could not be found in the graph.", "edge");
			}
			if (edge.FromVertex.HasEmanatingEdgeTo(edge.ToVertex))
			{
				throw new ArgumentException("The edge between the vertices specified already exists.", "edge");
			}
			graphEdges.Add(edge, null);
			AddEdgeToVertices(edge);
		}

		public void AddVertex(Vertex<T> vertex)
		{
			Guard.ArgumentNotNull(vertex, "vertex");
			if (graphVertices.ContainsKey(vertex))
			{
				throw new ArgumentException("The vertex already exists in the graph.", "vertex");
			}
			graphVertices.Add(vertex, null);
		}

		public Vertex<T> AddVertex(T item)
		{
			Vertex<T> vertex = new Vertex<T>(item);
			graphVertices.Add(vertex, null);
			return vertex;
		}

		public Edge<T> AddEdge(Vertex<T> from, Vertex<T> to)
		{
			Edge<T> edge = new Edge<T>(from, to, graphIsDirected);
			AddEdge(edge);
			return edge;
		}

		public Edge<T> AddEdge(Vertex<T> from, Vertex<T> to, double weight)
		{
			Edge<T> edge = new Edge<T>(from, to, weight, graphIsDirected);
			AddEdge(edge);
			return edge;
		}

		public bool IsWeaklyConnected()
		{
			if (graphVertices.Count == 0)
			{
				throw new InvalidOperationException("The graph is empty.");
			}
			CountingVisitor<Vertex<T>> countingVisitor = new CountingVisitor<Vertex<T>>();
			BreadthFirstTraversal(countingVisitor, GetAnyVertex());
			return countingVisitor.Count == graphVertices.Count;
		}

		public bool IsStronglyConnected()
		{
			if (graphIsDirected)
			{
				throw new InvalidOperationException("This operation is only valid on a directed graph. For undirected graphs, rather test for weak connectedness.");
			}
			if (graphVertices.Count == 0)
			{
				throw new InvalidOperationException("The graph is empty.");
			}
			CountingVisitor<Vertex<T>> countingVisitor = new CountingVisitor<Vertex<T>>();
			foreach (Vertex<T> key in graphVertices.Keys)
			{
				BreadthFirstTraversal(countingVisitor, key);
				if (countingVisitor.Count != graphVertices.Count)
				{
					return false;
				}
				countingVisitor.ResetCount();
			}
			return true;
		}

		public bool ContainsEdge(T fromValue, T toValue)
		{
			if (graphIsDirected)
			{
				foreach (Edge<T> key in graphEdges.Keys)
				{
					if (key.FromVertex.Data.Equals(fromValue) && key.ToVertex.Data.Equals(toValue))
					{
						return true;
					}
				}
			}
			else
			{
				foreach (Edge<T> key2 in graphEdges.Keys)
				{
					if ((key2.FromVertex.Data.Equals(fromValue) && key2.ToVertex.Data.Equals(toValue)) || (key2.FromVertex.Data.Equals(toValue) && key2.ToVertex.Data.Equals(fromValue)))
					{
						return true;
					}
				}
			}
			return false;
		}

		public bool ContainsEdge(Vertex<T> from, Vertex<T> to)
		{
			if (!graphIsDirected)
			{
				return from.HasIncidentEdgeWith(to);
			}
			return from.HasEmanatingEdgeTo(to);
		}

		public bool ContainsEdge(Edge<T> edge)
		{
			return graphEdges.ContainsKey(edge);
		}

		public Edge<T> GetEdge(Vertex<T> from, Vertex<T> to)
		{
			return from.GetEmanatingEdgeTo(to);
		}

		public Edge<T> GetEdge(T fromVertexValue, T toVertexValue)
		{
			foreach (Vertex<T> key in graphVertices.Keys)
			{
				if (!key.Data.Equals(fromVertexValue))
				{
					continue;
				}
				for (int i = 0; i < key.EmanatingEdges.Count; i++)
				{
					Edge<T> edge = key.EmanatingEdges[i];
					if (edge.GetPartnerVertex(key).Data.Equals(toVertexValue))
					{
						return edge;
					}
				}
			}
			return null;
		}

		public Vertex<T> GetVertex(T vertexValue)
		{
			foreach (Vertex<T> key in graphVertices.Keys)
			{
				if (key.Data.Equals(vertexValue))
				{
					return key;
				}
			}
			return null;
		}

		public IList<Vertex<T>> FindVertices(Predicate<T> predicate)
		{
			Guard.ArgumentNotNull(predicate, "predicate");
			List<Vertex<T>> list = new List<Vertex<T>>();
			foreach (Vertex<T> key in graphVertices.Keys)
			{
				if (predicate(key.Data))
				{
					list.Add(key);
				}
			}
			return list;
		}

		public IList<Vertex<T>[]> FindCycles()
		{
			return FindCycles(true);
		}

		public IList<Vertex<T>[]> FindCycles(bool excludeSingleItems)
		{
			Dictionary<Vertex<T>, int> dictionary = new Dictionary<Vertex<T>, int>();
			Dictionary<Vertex<T>, int> lowlinks = new Dictionary<Vertex<T>, int>();
			List<Vertex<T>[]> list = new List<Vertex<T>[]>();
			Stack<Vertex<T>> stack = new Stack<Vertex<T>>();
			foreach (Vertex<T> vertex in Vertices)
			{
				if (!dictionary.ContainsKey(vertex))
				{
					TarjansStronglyConnectedComponentsAlgorithm(excludeSingleItems, vertex, dictionary, lowlinks, list, stack, 0);
				}
			}
			return list;
		}

		private int TopologicalSortTraversalInternal(IVisitor<Vertex<T>> visitor)
		{
			Guard.ArgumentNotNull(visitor, "visitor");
			if (!IsDirected)
			{
				throw new ArgumentException("The current operation is only valid for a directed graph.");
			}
			int num = 0;
			if (!IsEmpty)
			{
				Dictionary<Vertex<T>, int> dictionary = new Dictionary<Vertex<T>, int>(graphVertices.Count);
				Queue<Vertex<T>> queue = new Queue<Vertex<T>>();
				foreach (Vertex<T> vertex2 in Vertices)
				{
					int incomingEdgeCount = vertex2.IncomingEdgeCount;
					dictionary.Add(vertex2, incomingEdgeCount);
					if (incomingEdgeCount == 0)
					{
						queue.Enqueue(vertex2);
					}
				}
				if (queue.Count > 0)
				{
					while (queue.Count > 0 && !visitor.HasCompleted)
					{
						Vertex<T> vertex = queue.Dequeue();
						dictionary.Remove(vertex);
						visitor.Visit(vertex);
						num++;
						foreach (Edge<T> emanatingEdge in vertex.EmanatingEdges)
						{
							Vertex<T> toVertex = emanatingEdge.ToVertex;
							dictionary[toVertex]--;
							if (dictionary[toVertex] == 0)
							{
								queue.Enqueue(toVertex);
							}
						}
					}
				}
			}
			return num;
		}

		private static void DepthFirstTraversal(OrderedVisitor<Vertex<T>> visitor, Vertex<T> startVertex, ref List<Vertex<T>> visitedVertices)
		{
			if (visitor.HasCompleted)
			{
				return;
			}
			visitedVertices.Add(startVertex);
			visitor.VisitPreOrder(startVertex);
			IList<Edge<T>> emanatingEdges = startVertex.EmanatingEdges;
			for (int i = 0; i < emanatingEdges.Count; i++)
			{
				Vertex<T> partnerVertex = emanatingEdges[i].GetPartnerVertex(startVertex);
				if (!visitedVertices.Contains(partnerVertex))
				{
					DepthFirstTraversal(visitor, partnerVertex, ref visitedVertices);
				}
			}
			visitor.VisitPostOrder(startVertex);
		}

		private static void AddEdgeToVertices(Edge<T> edge)
		{
			edge.FromVertex.AddEdge(edge);
			if (edge.FromVertex != edge.ToVertex)
			{
				edge.ToVertex.AddEdge(edge);
			}
		}

		private static void CheckEdgeNotNull(Edge<T> edge)
		{
			Guard.ArgumentNotNull(edge, "edge");
		}

		private Vertex<T> GetAnyVertex()
		{
			using (Dictionary<Vertex<T>, object>.KeyCollection.Enumerator enumerator = graphVertices.Keys.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					return enumerator.Current;
				}
			}
			return null;
		}

		private static void TarjansStronglyConnectedComponentsAlgorithm(bool excludeSinlgeItems, Vertex<T> vertex, IDictionary<Vertex<T>, int> indices, IDictionary<Vertex<T>, int> lowlinks, ICollection<Vertex<T>[]> connected, Stack<Vertex<T>> stack, int index)
		{
			indices[vertex] = index;
			lowlinks[vertex] = index;
			index++;
			stack.Push(vertex);
			foreach (Edge<T> emanatingEdge in vertex.EmanatingEdges)
			{
				Vertex<T> toVertex = emanatingEdge.ToVertex;
				if (!indices.ContainsKey(toVertex))
				{
					TarjansStronglyConnectedComponentsAlgorithm(excludeSinlgeItems, toVertex, indices, lowlinks, connected, stack, index);
					lowlinks[vertex] = Math.Min(lowlinks[vertex], lowlinks[toVertex]);
				}
				else if (stack.Contains(toVertex))
				{
					lowlinks[vertex] = Math.Min(lowlinks[vertex], lowlinks[toVertex]);
				}
			}
			if (lowlinks[vertex] == indices[vertex])
			{
				List<Vertex<T>> list = new List<Vertex<T>>();
				Vertex<T> vertex2;
				do
				{
					vertex2 = stack.Pop();
					list.Add(vertex2);
				}
				while (vertex2 != vertex);
				if (!excludeSinlgeItems || list.Count > 1)
				{
					connected.Add(list.ToArray());
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
