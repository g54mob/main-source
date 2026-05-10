using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ParadoxNotion;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;

namespace NodeCanvas.Framework
{
	[Serializable]
	[SpoofAOT]
	[fsSerializeAsReference]
	[fsDeserializeOverwrite]
	public abstract class Node : IGraphElement, ISerializationCollectable
	{
		[AttributeUsage(AttributeTargets.Field)]
		protected class AutoSortWithChildrenConnections : Attribute
		{
		}

		[CompilerGenerated]
		private sealed class _003CYieldBreak_003Ed__92 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Action resume;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CYieldBreak_003Ed__92(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		private string _UID;

		[SerializeField]
		private string _name;

		[SerializeField]
		private string _tag;

		[SerializeField]
		[fsIgnoreInBuild]
		private Vector2 _position;

		[SerializeField]
		[fsIgnoreInBuild]
		private string _comment;

		[SerializeField]
		[fsIgnoreInBuild]
		private bool _isBreakpoint;

		private Graph _graph;

		private int _ID;

		private List<Connection> _inConnections;

		private List<Connection> _outConnections;

		[NonSerialized]
		private Status _status;

		[NonSerialized]
		private string _nameCache;

		[NonSerialized]
		private string _descriptionCache;

		[NonSerialized]
		private int _priorityCache;

		public Graph graph
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public int ID
		{
			get
			{
				return 0;
			}
			internal set
			{
			}
		}

		public string UID => null;

		public List<Connection> inConnections
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		public List<Connection> outConnections
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		public Vector2 position
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		private string customName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string tag
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string comments
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool isBreakpoint
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual string name
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual string description => null;

		public virtual int priority => 0;

		public abstract int maxInConnections { get; }

		public abstract int maxOutConnections { get; }

		public abstract Type outConnectionType { get; }

		public abstract bool allowAsPrime { get; }

		public abstract bool canSelfConnect { get; }

		public abstract Alignment2x2 commentsAlignment { get; }

		public abstract Alignment2x2 iconAlignment { get; }

		public Status status
		{
			get
			{
				return default(Status);
			}
			protected set
			{
			}
		}

		public Component graphAgent => null;

		public IBlackboard graphBlackboard => null;

		public float elapsedTime => 0f;

		private float timeStarted { get; set; }

		private bool isChecked { get; set; }

		private bool breakPointReached { get; set; }

		public Node()
		{
		}

		public static Node Create(Graph targetGraph, Type nodeType, Vector2 pos)
		{
			return null;
		}

		public Node Duplicate(Graph targetGraph)
		{
			return null;
		}

		public void Validate(Graph assignedGraph)
		{
		}

		public Status Execute(Component agent, IBlackboard blackboard)
		{
			return default(Status);
		}

		public void Reset(bool recursively = true)
		{
		}

		[IteratorStateMachine(typeof(_003CYieldBreak_003Ed__92))]
		private IEnumerator YieldBreak(Action resume)
		{
			return null;
		}

		public Status Error(object msg)
		{
			return default(Status);
		}

		public Status Fail(string msg)
		{
			return default(Status);
		}

		public void Warn(string msg)
		{
		}

		public void SetStatus(Status status)
		{
		}

		protected void SendEvent(string eventName)
		{
		}

		protected void SendEvent<T>(string eventName, T value)
		{
		}

		public static bool IsNewConnectionAllowed(Node sourceNode, Node targetNode, Connection refConnection = null)
		{
			return false;
		}

		protected virtual bool CanConnectToTarget(Node targetNode)
		{
			return false;
		}

		protected virtual bool CanConnectFromSource(Node sourceNode)
		{
			return false;
		}

		public static bool AreNodesConnected(Node a, Node b)
		{
			return false;
		}

		public Coroutine StartCoroutine(IEnumerator routine)
		{
			return null;
		}

		public void StopCoroutine(Coroutine routine)
		{
		}

		public IEnumerable<Node> GetParentNodes()
		{
			return null;
		}

		public IEnumerable<Node> GetChildNodes()
		{
			return null;
		}

		public bool IsChildOf(Node parentNode)
		{
			return false;
		}

		public bool IsParentOf(Node childNode)
		{
			return false;
		}

		protected virtual string GetWarningOrError()
		{
			return null;
		}

		private string GetHardError()
		{
			return null;
		}

		protected virtual Status OnExecute(Component agent, IBlackboard blackboard)
		{
			return default(Status);
		}

		protected virtual void OnReset()
		{
		}

		public virtual void OnCreate(Graph assignedGraph)
		{
		}

		public virtual void OnValidate(Graph assignedGraph)
		{
		}

		public virtual void OnDestroy()
		{
		}

		public virtual void OnParentConnected(int connectionIndex)
		{
		}

		public virtual void OnParentDisconnected(int connectionIndex)
		{
		}

		public virtual void OnChildConnected(int connectionIndex)
		{
		}

		public virtual void OnChildDisconnected(int connectionIndex)
		{
		}

		public virtual void OnChildrenConnectionsSorted(int[] oldIndeces)
		{
		}

		public virtual void OnGraphStarted()
		{
		}

		public virtual void OnPostGraphStarted()
		{
		}

		public virtual void OnGraphStoped()
		{
		}

		public virtual void OnPostGraphStoped()
		{
		}

		public virtual void OnGraphPaused()
		{
		}

		public virtual void OnGraphUnpaused()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
