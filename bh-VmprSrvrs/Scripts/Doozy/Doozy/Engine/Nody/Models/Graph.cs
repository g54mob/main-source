using System;
using System.Collections.Generic;
using Doozy.Engine.Nody.Nodes;
using UnityEngine;

namespace Doozy.Engine.Nody.Models
{
	[Serializable]
	public class Graph : ScriptableObject
	{
		public const int FILE_VERSION = 1;

		public const string NODE_NOT_FOUND = "Node Not Found";

		public bool DebugMode;

		[NonSerialized]
		public Graph ParentGraph;

		[NonSerialized]
		public SubGraphNode ParentSubGraphNode;

		[NonSerialized]
		private List<Node> m_activatedNodesHistory;

		[NonSerialized]
		private List<Node> m_globalNodes;

		[NonSerialized]
		private Node m_enterNode;

		[NonSerialized]
		private Node m_exitNode;

		[NonSerialized]
		private Node m_startNode;

		[NonSerialized]
		private bool m_isDirty;

		[NonSerialized]
		private double m_infiniteLoopTimerStart;

		[NonSerialized]
		private float m_infiniteLoopTimeBreak;

		[NonSerialized]
		private bool m_enabled;

		[SerializeField]
		private List<Node> m_nodes;

		[SerializeField]
		private bool m_isSubGraph;

		[SerializeField]
		private int m_version;

		[SerializeField]
		private string m_description;

		[SerializeField]
		private string m_id;

		[SerializeField]
		private string m_lastModified;

		public DateTime LastModified => default(DateTime);

		public Graph ActiveSubGraph { get; set; }

		public List<Node> GlobalNodes => null;

		public List<Node> Nodes
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Node ActiveNode { get; set; }

		public Node PreviousActiveNode { get; set; }

		public bool HasGlobalNodes => false;

		public bool IsDirty
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsSubGraph
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public string Description => null;

		public string Id
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int Version => 0;

		public bool Enabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual void ActivateGlobalNodes()
		{
		}

		public virtual void DeactivateGlobalNodes()
		{
		}

		public virtual void FixedUpdate()
		{
		}

		public virtual void LateUpdate()
		{
		}

		public virtual void Update()
		{
		}

		public void ActivateStartOrEnterNode()
		{
		}

		public bool ContainsNode(Node node)
		{
			return false;
		}

		public bool ContainsNodeById(string nodeId)
		{
			return false;
		}

		public bool ContainsNodeByName(string nodeName)
		{
			return false;
		}

		public bool ContainsSocket(string socketId)
		{
			return false;
		}

		public Node GetEnterNode()
		{
			return null;
		}

		public Node GetExitNode()
		{
			return null;
		}

		public Node GetNodeById(string nodeId)
		{
			return null;
		}

		public Node GetNodeByName(string nodeName)
		{
			return null;
		}

		public string GetNodeIdFromNodeName(string nodeName)
		{
			return null;
		}

		public string GetNodeNameFromNodeId(string nodeId)
		{
			return null;
		}

		public Node GetStartNode()
		{
			return null;
		}

		public Node GetStartOrEnterNode()
		{
			return null;
		}

		public Socket GetSocket(string socketId)
		{
			return null;
		}

		public void SetActiveNode(Node nextActiveNode, Connection connection = null)
		{
		}

		public void SetActiveNodeByConnection(Connection connection)
		{
		}

		public void SetActiveNodeById(string nodeId, Connection connection = null)
		{
		}

		public void SetActiveNodeByName(string nodeName, Connection connection = null)
		{
		}

		public void SetLastModified(string time)
		{
		}

		public void SetVersion(int version)
		{
		}

		private bool InfiniteLoopDetected(Node nextActiveNode)
		{
			return false;
		}

		public void Reset()
		{
		}
	}
}
