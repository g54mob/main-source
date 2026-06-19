using System;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[Serializable]
	public abstract class NodeGraph : ScriptableObject
	{
		[SerializeField]
		public List<Node> nodes = new List<Node>();

		public T AddNode<T>() where T : Node
		{
			return AddNode(typeof(T)) as T;
		}

		public virtual Node AddNode(Type type)
		{
			Node.graphHotfix = this;
			Node node = ScriptableObject.CreateInstance(type) as Node;
			node.graph = this;
			nodes.Add(node);
			return node;
		}

		public virtual Node CopyNode(Node original)
		{
			Node.graphHotfix = this;
			Node node = UnityEngine.Object.Instantiate(original);
			node.graph = this;
			node.ClearConnections();
			nodes.Add(node);
			return node;
		}

		public void RemoveNode(Node node)
		{
			node.ClearConnections();
			nodes.Remove(node);
			if (Application.isPlaying)
			{
				UnityEngine.Object.Destroy(node);
			}
		}

		public void Clear()
		{
			if (Application.isPlaying)
			{
				for (int i = 0; i < nodes.Count; i++)
				{
					UnityEngine.Object.Destroy(nodes[i]);
				}
			}
			nodes.Clear();
		}

		public NodeGraph Copy()
		{
			NodeGraph nodeGraph = UnityEngine.Object.Instantiate(this);
			for (int i = 0; i < nodes.Count; i++)
			{
				if (!(nodes[i] == null))
				{
					Node.graphHotfix = nodeGraph;
					Node node = UnityEngine.Object.Instantiate(nodes[i]);
					node.graph = nodeGraph;
					nodeGraph.nodes[i] = node;
				}
			}
			for (int j = 0; j < nodeGraph.nodes.Count; j++)
			{
				if (nodeGraph.nodes[j] == null)
				{
					continue;
				}
				foreach (NodePort port in nodeGraph.nodes[j].Ports)
				{
					port.Redirect(nodes, nodeGraph.nodes);
				}
			}
			return nodeGraph;
		}

		private void OnDestroy()
		{
			Clear();
		}
	}
}
