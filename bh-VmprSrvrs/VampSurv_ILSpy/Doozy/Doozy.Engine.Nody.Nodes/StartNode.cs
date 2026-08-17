using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Doozy.Engine.Nody.Models;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.Nody.Nodes;

public class StartNode : Node
{
	public override void OnCreate()
	{
		base.m_canBeDeleted = false;
		base.m_nodeType = NodeType.Start;
		UILanguagePack instance = UILanguagePack.Instance;
		base.m_name = instance.StartNodeName;
		NodySettings instance2 = NodySettings.Instance;
		base.m_width = instance2.StartNodeWidth;
	}

	public override float GetDefaultNodeWidth()
	{
		NodySettings instance = NodySettings.Instance;
		return instance.StartNodeWidth;
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
		Socket socket = AddOutputSocket(ConnectionMode.Override, valueType, canBeDeleted: false, canBeReordered);
	}

	public override void CheckForErrors()
	{
	}

	public override void OnEnter(Node previousActiveNode, Connection connection)
	{
		base.OnEnter(previousActiveNode, connection);
		Graph activeGraph = base.m_activeGraph;
		if ((object)base.m_activeGraph != null && ((UnityEngine.Object)activeGraph).m_CachedPtr != (IntPtr)0)
		{
			base.m_activeGraph.ActivateGlobalNodes();
			Socket firstOutputSocket = base.FirstOutputSocket;
			List<Connection> connections = firstOutputSocket.m_connections;
			if (connections._size > 0)
			{
				Socket firstOutputSocket2 = base.FirstOutputSocket;
				Connection firstConnection = firstOutputSocket2.FirstConnection;
				Node nodeById = base.m_activeGraph.GetNodeById(firstConnection.m_inputNodeId);
				base.m_activeGraph.SetActiveNode(nodeById, firstConnection);
			}
		}
	}
}
