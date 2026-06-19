using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	public class ResearchNetwork
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
		public class Node
		{
			public int NodeID;

			[NonSerialized]
			[HideInInspector]
			public int Depth;

			public List<int> Children = new List<int>();

			[NonSerialized]
			[HideInInspector]
			public int Parent = -1;

			public int BranchID;

			public bool IsRoot
			{
				get
				{
					if (Depth == 0)
					{
						return Parent == -1;
					}
					return false;
				}
			}
		}

		private readonly List<Node> _nodes = new List<Node>();

		private readonly Node _root;

		private int _networkMaxDepth;

		private int _nextNodeID;

		public Node this[int i] => GetNode(i);

		public ResearchNetwork(Node rootNode)
		{
			_root = rootNode;
			_nextNodeID++;
			_nodes.Add(rootNode);
		}

		public ResearchNetwork(List<Node> nodes)
		{
			_nodes.AddRange(nodes);
			_root = _nodes[0];
			_nextNodeID = _nodes.Count;
			FixupNetworkNode(_root);
			_networkMaxDepth = -1;
			foreach (Node node in _nodes)
			{
				_networkMaxDepth = Mathf.Max(node.NodeID, _networkMaxDepth);
			}
		}

		public Node GetRootNode()
		{
			return _root;
		}

		public Node GetNode(int index)
		{
			if (index < 0 || index >= _nodes.Count)
			{
				return null;
			}
			return _nodes[index];
		}

		public int GetNodeCount()
		{
			return _nodes.Count;
		}

		public int GetConnectorCount()
		{
			int num = 0;
			for (int i = 0; i < _nodes.Count; i++)
			{
				num += _nodes[i].Children.Count;
			}
			return num;
		}

		public int GetMaxDepth()
		{
			return _networkMaxDepth;
		}

		public List<Node> GetNodesList()
		{
			return _nodes;
		}

		public void AddChildToNode(int nodeID, Node childToAdd)
		{
			AddChildToNode(GetNode(nodeID), childToAdd);
		}

		public void AddChildToNode(Node node, Node childToAdd)
		{
			childToAdd.NodeID = _nextNodeID;
			_nextNodeID++;
			childToAdd.Parent = node.NodeID;
			node.Children.Add(childToAdd.NodeID);
			childToAdd.Depth = node.Depth + 1;
			if (childToAdd.Depth > _networkMaxDepth)
			{
				_networkMaxDepth = childToAdd.Depth;
			}
			_nodes.Add(childToAdd);
		}

		private void FixupNetworkNode(Node node, int depth = 0)
		{
			node.Depth = depth;
			foreach (int child in node.Children)
			{
				Node node2 = _nodes[child];
				node2.Parent = node.NodeID;
				FixupNetworkNode(node2, depth + 1);
			}
		}

		public void GetChildrenWithDepth(int depth, ref List<Node> nodeList)
		{
			if (nodeList == null)
			{
				nodeList = new List<Node>();
			}
			for (int i = 0; i < _nodes.Count; i++)
			{
				if (_nodes[i].Depth == depth)
				{
					nodeList.Add(_nodes[i]);
				}
			}
		}

		public void GetAllChildren(Node node, ref List<Node> childrenList)
		{
			if (childrenList == null)
			{
				childrenList = new List<Node>();
			}
			if (node != null)
			{
				for (int i = 0; i < node.Children.Count; i++)
				{
					childrenList.Add(GetNode(node.Children[i]));
					GetAllChildren(GetNode(node.Children[i]), ref childrenList);
				}
			}
		}

		public void GetAllChildren(Node node, ref List<int> childrenList)
		{
			if (childrenList == null)
			{
				childrenList = new List<int>();
			}
			if (node != null)
			{
				for (int i = 0; i < node.Children.Count; i++)
				{
					childrenList.Add(node.Children[i]);
					GetAllChildren(GetNode(node.Children[i]), ref childrenList);
				}
			}
		}

		public void GetAllParents(Node node, ref List<Node> parentList)
		{
			if (parentList == null)
			{
				parentList = new List<Node>();
			}
			if (node != null && node.Parent != -1)
			{
				Node node2 = GetNode(node.Parent);
				parentList.Add(node2);
				GetAllParents(node2, ref parentList);
			}
		}

		public Node GetFirstCommonAncestor(Node nodeA, Node nodeB)
		{
			if (nodeA == null || nodeB == null)
			{
				return null;
			}
			List<Node> parentList = null;
			GetAllParents(nodeA, ref parentList);
			List<Node> parentList2 = null;
			GetAllParents(nodeB, ref parentList2);
			List<Node> list = parentList.Intersect(parentList2).ToList();
			list.Sort((Node a, Node b) => a.Depth.CompareTo(b.Depth));
			return list.First();
		}

		public void GetLeafNodes(int nodeID, ref List<Node> leafNodes)
		{
			Node node = GetNode(nodeID);
			GetLeafNodes(node, ref leafNodes);
		}

		public void GetLeafNodes(Node node, ref List<Node> leafNodes)
		{
			if (leafNodes == null)
			{
				leafNodes = new List<Node>();
			}
			if (node.Children.Count <= 0)
			{
				leafNodes.Add(node);
			}
			for (int i = 0; i < node.Children.Count; i++)
			{
				Node node2 = GetNode(node.Children[i]);
				GetLeafNodes(node2, ref leafNodes);
			}
		}

		public void GetSplitNodes(int nodeID, ref List<Node> splitNodes)
		{
			Node node = GetNode(nodeID);
			GetSplitNodes(node, ref splitNodes);
		}

		public void GetSplitNodes(Node node, ref List<Node> splitNodes)
		{
			if (splitNodes == null)
			{
				splitNodes = new List<Node>();
			}
			if (node.Children.Count > 1)
			{
				splitNodes.Add(node);
			}
			for (int i = 0; i < node.Children.Count; i++)
			{
				Node node2 = GetNode(node.Children[i]);
				GetSplitNodes(node2, ref splitNodes);
			}
		}
	}
}
