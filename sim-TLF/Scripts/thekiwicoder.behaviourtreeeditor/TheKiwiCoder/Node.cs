using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheKiwiCoder
{
	[Serializable]
	public abstract class Node
	{
		public enum State
		{
			Running = 0,
			Failure = 1,
			Success = 2
		}

		[HideInInspector]
		public bool started;

		[HideInInspector]
		public string guid = Guid.NewGuid().ToString();

		[HideInInspector]
		public Vector2 position;

		[HideInInspector]
		public Context context;

		[HideInInspector]
		public Blackboard blackboard;

		[TextArea]
		public string description;

		[Tooltip("When enabled, the nodes OnDrawGizmos will be invoked")]
		public bool drawGizmos;

		public virtual void OnInit()
		{
		}

		public State Update()
		{
			if (!started)
			{
				OnStart();
				started = true;
			}
			State state = OnUpdate();
			context.tickResults[guid] = state;
			if (state != State.Running)
			{
				OnStop();
				started = false;
			}
			return state;
		}

		public void Abort()
		{
			BehaviourTree.Traverse(this, delegate(Node node)
			{
				node.started = false;
				node.OnStop();
			});
		}

		public virtual void OnDrawGizmos()
		{
		}

		protected abstract void OnStart();

		protected abstract void OnStop();

		protected abstract State OnUpdate();

		protected virtual void Log(string message)
		{
			Debug.Log($"[{GetType()}]{message}");
		}

		public Node Clone()
		{
			Node obj = MemberwiseClone() as Node;
			if (obj is DecoratorNode { child: not null } decoratorNode)
			{
				decoratorNode.child = null;
			}
			if (obj is RootNode { child: not null } rootNode)
			{
				rootNode.child = null;
			}
			if (obj is CompositeNode compositeNode)
			{
				compositeNode.children = new List<Node>();
			}
			return obj;
		}
	}
}
