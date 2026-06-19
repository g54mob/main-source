using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheKiwiCoder
{
	[CreateAssetMenu]
	public class BehaviourTree : ScriptableObject
	{
		[SerializeReference]
		public RootNode rootNode;

		[SerializeReference]
		public List<Node> nodes = new List<Node>();

		public Blackboard blackboard = new Blackboard();

		public Context treeContext;

		public Vector3 viewPosition = new Vector3(600f, 300f);

		public Vector3 viewScale = Vector3.one;

		public BehaviourTree()
		{
			rootNode = new RootNode();
			nodes.Add(rootNode);
		}

		private void OnEnable()
		{
			nodes.RemoveAll((Node node) => node == null);
			Traverse(rootNode, delegate(Node node)
			{
				if (node is CompositeNode compositeNode)
				{
					compositeNode.children.RemoveAll((Node child) => child == null);
				}
			});
		}

		public Node.State Tick(float tickDelta)
		{
			treeContext.tickDelta = tickDelta;
			return rootNode.Update();
		}

		public static List<Node> GetChildren(Node parent)
		{
			List<Node> list = new List<Node>();
			if (parent is DecoratorNode { child: not null } decoratorNode)
			{
				list.Add(decoratorNode.child);
			}
			if (parent is RootNode { child: not null } rootNode)
			{
				list.Add(rootNode.child);
			}
			if (parent is CompositeNode compositeNode)
			{
				return compositeNode.children;
			}
			return list;
		}

		public static void Traverse(Node node, Action<Node> visiter)
		{
			if (node != null)
			{
				visiter(node);
				GetChildren(node).ForEach(delegate(Node n)
				{
					Traverse(n, visiter);
				});
			}
		}

		public BehaviourTree Clone()
		{
			return UnityEngine.Object.Instantiate(this);
		}

		public void Bind(Context context)
		{
			treeContext = context;
			Traverse(rootNode, delegate(Node node)
			{
				node.context = context;
				node.blackboard = blackboard;
				node.OnInit();
			});
		}
	}
}
