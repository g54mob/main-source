using System;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[Serializable]
	public abstract class NodeGraph : ScriptableObject
	{
		[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
		public class RequireNodeAttribute : Attribute
		{
			public Type type0;

			public Type type1;

			public Type type2;

			public RequireNodeAttribute(Type type)
			{
			}

			public RequireNodeAttribute(Type type, Type type2)
			{
			}

			public RequireNodeAttribute(Type type, Type type2, Type type3)
			{
			}

			public bool Requires(Type type)
			{
				return false;
			}
		}

		[SerializeField]
		public List<Node> nodes;

		public T AddNode<T>() where T : Node
		{
			return null;
		}

		public virtual Node AddNode(Type type)
		{
			return null;
		}

		public virtual Node CopyNode(Node original)
		{
			return null;
		}

		public virtual void RemoveNode(Node node)
		{
		}

		public virtual void Clear()
		{
		}

		public virtual NodeGraph Copy()
		{
			return null;
		}

		protected virtual void OnDestroy()
		{
		}
	}
}
