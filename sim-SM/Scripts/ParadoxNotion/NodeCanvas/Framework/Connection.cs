using System;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;

namespace NodeCanvas.Framework
{
	[Serializable]
	[SpoofAOT]
	[fsDeserializeOverwrite]
	public abstract class Connection : IGraphElement, ISerializationCollectable
	{
		[SerializeField]
		[fsSerializeAsReference]
		private Node _sourceNode;

		[SerializeField]
		[fsSerializeAsReference]
		private Node _targetNode;

		[SerializeField]
		private string _UID;

		[SerializeField]
		private bool _isDisabled;

		[NonSerialized]
		private Status _status;

		public string UID => null;

		public Node sourceNode
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		public Node targetNode
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		string IGraphElement.name => null;

		public bool isActive
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Status status
		{
			get
			{
				return default(Status);
			}
			set
			{
			}
		}

		public Graph graph => null;

		public Connection()
		{
		}

		public static Connection Create(Node source, Node target, int sourceIndex = -1, int targetIndex = -1)
		{
			return null;
		}

		public Connection Duplicate(Node newSource, Node newTarget)
		{
			return null;
		}

		public int SetSourceNode(Node newSource, int index = -1)
		{
			return 0;
		}

		public int SetTargetNode(Node newTarget, int index = -1)
		{
			return 0;
		}

		public Status Execute(Component agent, IBlackboard blackboard)
		{
			return default(Status);
		}

		public void Reset(bool recursively = true)
		{
		}

		public virtual void OnCreate(int sourceIndex, int targetIndex)
		{
		}

		public virtual void OnValidate(int sourceIndex, int targetIndex)
		{
		}

		public virtual void OnDestroy()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
