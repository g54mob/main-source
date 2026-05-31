using System;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;

namespace NodeCanvas.Framework
{
	[Serializable]
	[fsForward("_targetNodeUID")]
	[fsAutoInstance(true)]
	public class NodeReference<T> : INodeReference
	{
		[SerializeField]
		private string _targetNodeUID;

		[NonSerialized]
		private WeakReference<T> _targetNodeRef;

		Type INodeReference.type => null;

		Node INodeReference.Get(Graph graph)
		{
			return null;
		}

		void INodeReference.Set(Node target)
		{
		}

		public NodeReference()
		{
		}

		public NodeReference(T target)
		{
		}

		public T Get(Graph graph)
		{
			return default(T);
		}

		public void Set(T target)
		{
		}
	}
}
