using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Doozy.Engine.Nody.Models;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.Nody.Nodes;

public class ExitNode : Node
{
	public override void OnCreate()
	{
		base.m_canBeDeleted = false;
		base.m_nodeType = NodeType.Exit;
		UILanguagePack instance = UILanguagePack.Instance;
		base.m_name = instance.ExitNodeName;
		NodySettings instance2 = NodySettings.Instance;
		base.m_width = instance2.ExitNodeWidth;
	}

	public override float GetDefaultNodeWidth()
	{
		NodySettings instance = NodySettings.Instance;
		return instance.ExitNodeWidth;
	}

	public override void AddDefaultSockets()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type valueType = default(Type);
		bool canBeReordered = default(bool);
		Socket socket = AddInputSocket(ConnectionMode.Multiple, valueType, canBeDeleted: false, canBeReordered);
	}

	public override void CheckForErrors()
	{
	}

	public override void OnEnter(Node previousActiveNode, Connection connection)
	{
		base.OnEnter(previousActiveNode, connection);
		Graph activeGraph = base.m_activeGraph;
		if ((object)base.m_activeGraph == null || ((UnityEngine.Object)activeGraph).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Graph activeGraph2 = base.m_activeGraph;
		Graph parentGraph = activeGraph2.ParentGraph;
		if ((object)activeGraph2.ParentGraph == null || ((UnityEngine.Object)parentGraph).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Graph activeGraph3 = base.m_activeGraph;
		SubGraphNode parentSubGraphNode = activeGraph3.ParentSubGraphNode;
		if ((object)activeGraph3.ParentSubGraphNode != null && ((UnityEngine.Object)parentSubGraphNode).m_CachedPtr != (IntPtr)0)
		{
			base.m_activeGraph.DeactivateGlobalNodes();
			Graph activeGraph4 = base.m_activeGraph;
			Node parentSubGraphNode2 = activeGraph4.ParentSubGraphNode;
			Socket firstOutputSocket = activeGraph4.ParentSubGraphNode.FirstOutputSocket;
			List<Connection> connections = firstOutputSocket.m_connections;
			if (connections._size > 0)
			{
				Graph activeGraph5 = parentSubGraphNode2.m_activeGraph;
				activeGraph5._003CActiveSubGraph_003Ek__BackingField.Enabled = false;
				Graph activeGraph6 = parentSubGraphNode2.m_activeGraph;
				activeGraph6._003CActiveSubGraph_003Ek__BackingField = null;
				parentSubGraphNode2.m_activeGraph.ActivateGlobalNodes();
				Socket firstOutputSocket2 = activeGraph4.ParentSubGraphNode.FirstOutputSocket;
				Connection firstConnection = firstOutputSocket2.FirstConnection;
				Node nodeById = parentSubGraphNode2.m_activeGraph.GetNodeById(firstConnection.m_inputNodeId);
				parentSubGraphNode2.m_activeGraph.SetActiveNode(nodeById, firstConnection);
			}
		}
	}
}
