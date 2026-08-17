using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Doozy.Engine.Nody.Nodes;
using UnityEngine;

namespace Doozy.Engine.Nody.Models;

[Serializable]
public class Graph : ScriptableObject
{
	public const int FILE_VERSION = 1;

	public const string NODE_NOT_FOUND = "Node Not Found";

	private Graph _003CActiveSubGraph_003Ek__BackingField;

	private Node _003CActiveNode_003Ek__BackingField;

	private Node _003CPreviousActiveNode_003Ek__BackingField;

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

	private List<Node> m_nodes;

	private bool m_isSubGraph;

	private int m_version;

	private string m_description;

	private string m_id;

	private string m_lastModified;

	public DateTime LastModified
	{
		get
		{
			long fileTime = long.Parse(m_lastModified);
			return DateTime.FromFileTimeUtc(fileTime);
		}
	}

	public Graph ActiveSubGraph
	{
		get
		{
			return _003CActiveSubGraph_003Ek__BackingField;
		}
		set
		{
			_003CActiveSubGraph_003Ek__BackingField = value;
		}
	}

	public List<Node> GlobalNodes
	{
		get
		{
			List<Node> result = m_globalNodes;
			if (m_globalNodes == null)
			{
				result = (m_globalNodes = new List<Node>());
			}
			return result;
		}
	}

	public List<Node> Nodes
	{
		get
		{
			List<Node> result = m_nodes;
			if (m_nodes == null)
			{
				result = (m_nodes = new List<Node>());
			}
			return result;
		}
		set
		{
			m_nodes = value;
		}
	}

	public Node ActiveNode
	{
		get
		{
			return _003CActiveNode_003Ek__BackingField;
		}
		set
		{
			_003CActiveNode_003Ek__BackingField = value;
		}
	}

	public Node PreviousActiveNode
	{
		get
		{
			return _003CPreviousActiveNode_003Ek__BackingField;
		}
		set
		{
			_003CPreviousActiveNode_003Ek__BackingField = value;
		}
	}

	public bool HasGlobalNodes
	{
		get
		{
			//IL_009e: Expected I4, but got O
			List<Node> globalNodes = GlobalNodes;
			if (globalNodes != null)
			{
				int num = globalNodes._size ^ globalNodes._size;
				int num2 = globalNodes._size & num;
				bool flag = num2 < 0;
				bool flag2 = globalNodes._size < 0;
				bool flag3 = globalNodes._size == 0;
				bool flag4 = flag2 == flag;
				bool flag5 = !flag3;
				return flag5 & flag4;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public bool IsDirty
	{
		get
		{
			return m_isDirty;
		}
		set
		{
			m_isDirty = value;
		}
	}

	public bool IsSubGraph
	{
		get
		{
			return m_isSubGraph;
		}
		set
		{
			m_isSubGraph = value;
		}
	}

	public string Description => m_description;

	public string Id
	{
		get
		{
			return m_id;
		}
		set
		{
			m_id = value;
		}
	}

	public int Version => m_version;

	public bool Enabled
	{
		get
		{
			return m_enabled;
		}
		set
		{
			Graph graph = this;
			bool enabled = value;
			while (true)
			{
				graph.m_enabled = enabled;
				Graph graph2 = graph._003CActiveSubGraph_003Ek__BackingField;
				if ((object)graph._003CActiveSubGraph_003Ek__BackingField != null && ((UnityEngine.Object)graph2).m_CachedPtr != (IntPtr)0)
				{
					enabled = graph.m_enabled;
					graph = graph._003CActiveSubGraph_003Ek__BackingField;
					continue;
				}
				break;
			}
		}
	}

	public unsafe virtual void ActivateGlobalNodes()
	{
		//IL_00a3: Expected O, but got I4
		//IL_00ab: Expected O, but got Ref
		List<Node> globalNodes = GlobalNodes;
		int version = globalNodes._version + 1;
		globalNodes._version = version;
		int size = globalNodes._size;
		globalNodes._size = 0;
		if (globalNodes._size > 0)
		{
			Array.Clear(globalNodes._items, 0, globalNodes._size);
		}
		List<Node> nodes = Nodes;
		List<Node>.Enumerator enumerator = default(List<Node>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<Node>.Enumerator enumerator2 = (List<Node>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	public virtual void DeactivateGlobalNodes()
	{
		List<Node> globalNodes = GlobalNodes;
		if (globalNodes != null)
		{
			if (globalNodes._size <= 0)
			{
				return;
			}
			List<Node> globalNodes2 = GlobalNodes;
			if (globalNodes2 != null)
			{
				List<Node>.Enumerator enumerator = default(List<Node>.Enumerator);
				if (enumerator.MoveNext())
				{
					Graph graph = null;
					Graph graph2 = null;
					throw new NullReferenceException();
				}
				Graph graph3 = _003CActiveSubGraph_003Ek__BackingField;
				if ((object)_003CActiveSubGraph_003Ek__BackingField == null || ((UnityEngine.Object)graph3).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				Graph graph4 = _003CActiveSubGraph_003Ek__BackingField;
				if ((object)_003CActiveSubGraph_003Ek__BackingField != null)
				{
					_003CActiveSubGraph_003Ek__BackingField.DeactivateGlobalNodes();
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public virtual void FixedUpdate()
	{
		//IL_00c4: Expected O, but got I4
		Node node = _003CActiveNode_003Ek__BackingField;
		if ((object)_003CActiveNode_003Ek__BackingField != null && ((UnityEngine.Object)node).m_CachedPtr != (IntPtr)0)
		{
			Node node2 = _003CActiveNode_003Ek__BackingField;
			if (node2.m_useFixedUpdate)
			{
				node2.OnFixedUpdate();
			}
		}
		Graph graph = _003CActiveSubGraph_003Ek__BackingField;
		if ((object)_003CActiveSubGraph_003Ek__BackingField != null && ((UnityEngine.Object)graph).m_CachedPtr != (IntPtr)0)
		{
			_003CActiveSubGraph_003Ek__BackingField.FixedUpdate();
		}
		List<Node> globalNodes = GlobalNodes;
		List<Node>.Enumerator enumerator = default(List<Node>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			throw new NullReferenceException();
		}
	}

	public virtual void LateUpdate()
	{
		//IL_00c4: Expected O, but got I4
		Node node = _003CActiveNode_003Ek__BackingField;
		if ((object)_003CActiveNode_003Ek__BackingField != null && ((UnityEngine.Object)node).m_CachedPtr != (IntPtr)0)
		{
			Node node2 = _003CActiveNode_003Ek__BackingField;
			if (node2.m_useLateUpdate)
			{
				node2.OnLateUpdate();
			}
		}
		Graph graph = _003CActiveSubGraph_003Ek__BackingField;
		if ((object)_003CActiveSubGraph_003Ek__BackingField != null && ((UnityEngine.Object)graph).m_CachedPtr != (IntPtr)0)
		{
			_003CActiveSubGraph_003Ek__BackingField.LateUpdate();
		}
		List<Node> globalNodes = GlobalNodes;
		List<Node>.Enumerator enumerator = default(List<Node>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			throw new NullReferenceException();
		}
	}

	public virtual void Update()
	{
		//IL_00c4: Expected O, but got I4
		Node node = _003CActiveNode_003Ek__BackingField;
		if ((object)_003CActiveNode_003Ek__BackingField != null && ((UnityEngine.Object)node).m_CachedPtr != (IntPtr)0)
		{
			Node node2 = _003CActiveNode_003Ek__BackingField;
			if (node2.m_useUpdate)
			{
				node2.OnUpdate();
			}
		}
		Graph graph = _003CActiveSubGraph_003Ek__BackingField;
		if ((object)_003CActiveSubGraph_003Ek__BackingField != null && ((UnityEngine.Object)graph).m_CachedPtr != (IntPtr)0)
		{
			_003CActiveSubGraph_003Ek__BackingField.Update();
		}
		List<Node> globalNodes = GlobalNodes;
		List<Node>.Enumerator enumerator = default(List<Node>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			throw new NullReferenceException();
		}
	}

	public void ActivateStartOrEnterNode()
	{
		_003CPreviousActiveNode_003Ek__BackingField = null;
		Node node = ((!m_isSubGraph) ? GetStartNode() : GetEnterNode());
		_003CActiveNode_003Ek__BackingField = node;
		Node node2 = _003CActiveNode_003Ek__BackingField;
		node2.m_activeGraph = this;
		_003CActiveNode_003Ek__BackingField.OnEnter(null, null);
	}

	public bool ContainsNode(Node node)
	{
		//IL_0058: Expected I4, but got O
		//IL_004e: Expected I4, but got O
		bool flag = (byte)(int)Nodes != 0;
		if (!flag)
		{
			return flag;
		}
		List<Node> nodes = Nodes;
		if (nodes != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D500");
			bool result = default(bool);
			return result;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool ContainsNodeById(string nodeId)
	{
		Node nodeById = GetNodeById(nodeId);
		if ((object)nodeById != null)
		{
			bool flag = ((UnityEngine.Object)nodeById).m_CachedPtr == (IntPtr)0;
			return !flag;
		}
		return false;
	}

	public bool ContainsNodeByName(string nodeName)
	{
		Node nodeByName = GetNodeByName(nodeName);
		if ((object)nodeByName != null)
		{
			bool flag = ((UnityEngine.Object)nodeByName).m_CachedPtr == (IntPtr)0;
			return !flag;
		}
		return false;
	}

	public bool ContainsSocket(string socketId)
	{
		Socket socket = GetSocket(socketId);
		bool flag = socket == null;
		return !flag;
	}

	public unsafe Node GetEnterNode()
	{
		//IL_0017: Expected O, but got Ref
		List<Node> nodes = Nodes;
		List<Node>.Enumerator enumerator = default(List<Node>.Enumerator);
		if (enumerator.MoveNext())
		{
			Node node = null;
			List<Node>.Enumerator enumerator2 = (List<Node>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return null;
	}

	public unsafe Node GetExitNode()
	{
		//IL_0017: Expected O, but got Ref
		List<Node> nodes = Nodes;
		List<Node>.Enumerator enumerator = default(List<Node>.Enumerator);
		if (enumerator.MoveNext())
		{
			Node node = null;
			List<Node>.Enumerator enumerator2 = (List<Node>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return null;
	}

	public unsafe Node GetNodeById(string nodeId)
	{
		//IL_0017: Expected O, but got Ref
		List<Node> nodes = Nodes;
		List<Node>.Enumerator enumerator = default(List<Node>.Enumerator);
		if (enumerator.MoveNext())
		{
			Node node = null;
			List<Node>.Enumerator enumerator2 = (List<Node>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return null;
	}

	public unsafe Node GetNodeByName(string nodeName)
	{
		//IL_0017: Expected O, but got Ref
		List<Node> nodes = Nodes;
		List<Node>.Enumerator enumerator = default(List<Node>.Enumerator);
		if (enumerator.MoveNext())
		{
			Node node = null;
			List<Node>.Enumerator enumerator2 = (List<Node>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return null;
	}

	public string GetNodeIdFromNodeName(string nodeName)
	{
		Node nodeByName = GetNodeByName(nodeName);
		if ((object)nodeByName != null && ((UnityEngine.Object)nodeByName).m_CachedPtr != (IntPtr)0)
		{
			return nodeByName.m_name;
		}
		return "Node Not Found";
	}

	public string GetNodeNameFromNodeId(string nodeId)
	{
		Node nodeById = GetNodeById(nodeId);
		if ((object)nodeById != null && ((UnityEngine.Object)nodeById).m_CachedPtr != (IntPtr)0)
		{
			return nodeById.m_name;
		}
		return "Node Not Found";
	}

	public unsafe Node GetStartNode()
	{
		//IL_0017: Expected O, but got Ref
		List<Node> nodes = Nodes;
		List<Node>.Enumerator enumerator = default(List<Node>.Enumerator);
		if (enumerator.MoveNext())
		{
			Node node = null;
			List<Node>.Enumerator enumerator2 = (List<Node>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return null;
	}

	public Node GetStartOrEnterNode()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 13 Invalid \"Jump target not found in method: 0x182C3B3C0\"");
		return GetStartNode();
	}

	public Socket GetSocket(string socketId)
	{
		List<Node> nodes = Nodes;
		List<Node>.Enumerator enumerator = default(List<Node>.Enumerator);
		if (enumerator.MoveNext())
		{
			Node node = null;
			throw new NullReferenceException();
		}
		return null;
	}

	public void SetActiveNode(Node nextActiveNode, Connection connection = null)
	{
		//IL_004d: Expected I, but got O
		Node node = _003CActiveNode_003Ek__BackingField;
		if ((object)_003CActiveNode_003Ek__BackingField != null && ((UnityEngine.Object)node).m_CachedPtr != (IntPtr)0)
		{
			Node node2 = _003CActiveNode_003Ek__BackingField;
			nint num = (nint)node2;
			node2.OnExit(nextActiveNode, connection);
			Node node3 = _003CActiveNode_003Ek__BackingField;
			node3.m_activeGraph = null;
		}
		_003CPreviousActiveNode_003Ek__BackingField = _003CActiveNode_003Ek__BackingField;
		if (!InfiniteLoopDetected(nextActiveNode))
		{
			_003CActiveNode_003Ek__BackingField = nextActiveNode;
			Node node4 = _003CActiveNode_003Ek__BackingField;
			if ((object)_003CActiveNode_003Ek__BackingField != null && ((UnityEngine.Object)node4).m_CachedPtr != (IntPtr)0)
			{
				Node node5 = _003CActiveNode_003Ek__BackingField;
				if (node5.m_nodeType == NodeType.Exit)
				{
					DeactivateGlobalNodes();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A8E780");
				_003CActiveNode_003Ek__BackingField.OnEnter(_003CPreviousActiveNode_003Ek__BackingField, connection);
			}
			return;
		}
		string[] array = new string[13];
		throw new NullReferenceException();
	}

	public void SetActiveNodeByConnection(Connection connection)
	{
		Node nodeById = GetNodeById(connection.m_inputNodeId);
		SetActiveNode(nodeById, connection);
	}

	public void SetActiveNodeById(string nodeId, Connection connection = null)
	{
		Node nodeById = GetNodeById(nodeId);
		SetActiveNode(nodeById, connection);
	}

	public void SetActiveNodeByName(string nodeName, Connection connection = null)
	{
		Node nodeByName = GetNodeByName(nodeName);
		SetActiveNode(nodeByName, connection);
	}

	public void SetLastModified(string time)
	{
		m_lastModified = time;
	}

	public void SetVersion(int version)
	{
		m_version = version;
	}

	private bool InfiniteLoopDetected(Node nextActiveNode)
	{
		//IL_003f: Expected O, but got I
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0167: Expected O, but got F4
		//IL_019e: Expected O, but got I4
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Expected O, but got Unknown
		//IL_01c2: Expected O, but got F4
		if ((object)nextActiveNode != null && ((UnityEngine.Object)nextActiveNode).m_CachedPtr != (IntPtr)0)
		{
			object obj = (nint)0 ^ (nint)0;
			object obj2 = 0 & obj;
			bool flag = (nint)obj2 < 0;
			bool flag2 = (nint)0 < (nint)0;
			bool flag3 = (nint)0 == 0;
			object obj3 = Time.realtimeSinceStartup;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm2,xmm0\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm2,qword ptr [rbx+78h]\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm2\"");
			bool flag4 = flag2 == flag;
			object obj4 = !flag3;
			object obj5 = flag4 & obj4;
			if (obj5 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D500");
				object obj6 = default(object);
				if (obj6 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D4A0");
					return false;
				}
				return true;
			}
			object obj7 = Time.realtimeSinceStartup;
			List<Node> activatedNodesHistory = m_activatedNodesHistory;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
			m_infiniteLoopTimerStart = 0.0;
			int version = activatedNodesHistory._version + 1;
			activatedNodesHistory._version = version;
			activatedNodesHistory._size = 0;
			if (activatedNodesHistory._size > 0)
			{
				Array.Clear(activatedNodesHistory._items, 0, activatedNodesHistory._size);
			}
		}
		return false;
	}

	public void Reset()
	{
		//IL_0084: Expected O, but got F4
		object obj = Time.realtimeSinceStartup;
		List<Node> activatedNodesHistory = m_activatedNodesHistory;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
		m_infiniteLoopTimerStart = 0.0;
		int version = activatedNodesHistory._version + 1;
		activatedNodesHistory._version = version;
		activatedNodesHistory._size = 0;
		if (activatedNodesHistory._size > 0)
		{
			Array.Clear(activatedNodesHistory._items, 0, activatedNodesHistory._size);
		}
	}

	public Graph()
	{
		List<Node> activatedNodesHistory = new List<Node>();
		m_activatedNodesHistory = activatedNodesHistory;
		m_infiniteLoopTimeBreak = 0.1f;
		base._002Ector();
	}
}
