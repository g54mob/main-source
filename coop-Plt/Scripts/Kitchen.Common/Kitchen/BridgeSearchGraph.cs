using System;
using System.Collections.Generic;

namespace Kitchen
{
	public class BridgeSearchGraph
	{
		private int V;

		private List<int>[] adj;

		private int time;

		private static readonly int NIL = -1;

		public BridgeSearchGraph(int v)
		{
			V = v;
			adj = new List<int>[v];
			for (int i = 0; i < v; i++)
			{
				adj[i] = new List<int>();
			}
		}

		public void addEdge(int v, int w)
		{
			adj[v].Add(w);
			adj[w].Add(v);
		}

		private void APUtil(int u, bool[] visited, int[] disc, int[] low, int[] parent, bool[] ap)
		{
			int num = 0;
			visited[u] = true;
			disc[u] = (low[u] = ++time);
			foreach (int item in adj[u])
			{
				if (!visited[item])
				{
					num++;
					parent[item] = u;
					APUtil(item, visited, disc, low, parent, ap);
					low[u] = Math.Min(low[u], low[item]);
					if (parent[u] == NIL && num > 1)
					{
						ap[u] = true;
					}
					if (parent[u] != NIL && low[item] >= disc[u])
					{
						ap[u] = true;
					}
				}
				else if (item != parent[u])
				{
					low[u] = Math.Min(low[u], disc[item]);
				}
			}
		}

		public bool[] FindBridges()
		{
			bool[] array = new bool[V];
			int[] disc = new int[V];
			int[] low = new int[V];
			int[] array2 = new int[V];
			bool[] array3 = new bool[V];
			for (int i = 0; i < V; i++)
			{
				array2[i] = NIL;
				array[i] = false;
				array3[i] = false;
			}
			for (int j = 0; j < V; j++)
			{
				if (!array[j])
				{
					APUtil(j, array, disc, low, array2, array3);
				}
			}
			return array3;
		}
	}
}
