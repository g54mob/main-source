using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TheKiwiCoder
{
	public class BehaviourTreeBuilder
	{
		public BehaviourTree tree;

		public BehaviourTreeBuilder(string treeName)
		{
			tree = ScriptableObject.CreateInstance<BehaviourTree>();
			tree.name = treeName;
		}

		public T CreateNode<T>(params object[] args) where T : Node
		{
			T val = Activator.CreateInstance(typeof(T), args) as T;
			val.guid = Guid.NewGuid().ToString();
			tree.nodes.Add(val);
			return val;
		}

		public void Selector(params Node[] nodes)
		{
			CreateNode<Selector>(Array.Empty<object>()).children.AddRange(nodes);
			tree.nodes.AddRange(nodes);
		}

		private void LayoutNodes()
		{
			CalculatePositions(tree.rootNode, tree.rootNode.position, 80f);
		}

		private float CalculatePositions(Node node, Vector2 position, float verticalSpacing)
		{
			node.position = position;
			float num = position.x;
			foreach (Node child in BehaviourTree.GetChildren(node))
			{
				num += CalculateTreeWidth(child) / 2f;
				CalculatePositions(child, new Vector2(num, position.y + verticalSpacing), verticalSpacing);
				num += CalculateTreeWidth(child) / 2f;
			}
			return num;
		}

		private float CalculateTreeWidth(Node node)
		{
			List<Node> children = BehaviourTree.GetChildren(node);
			if (children.Count == 0)
			{
				return 100f;
			}
			return children.Sum((Node c) => CalculateTreeWidth(c));
		}
	}
}
