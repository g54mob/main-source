using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Doozy.Engine.Nody.Models;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.Nody.Nodes;

public class SubGraphNode : Node
{
	private Graph m_subGraph;

	public bool ErrorNoGraphReferenced;

	public bool ErrorReferencedGraphIsNotSubGraph;

	public Graph SubGraph => m_subGraph;

	public override void OnCreate()
	{
		base.m_canBeDeleted = true;
		base.m_nodeType = NodeType.SubGraph;
		UILanguagePack instance = UILanguagePack.Instance;
		base.m_name = instance.SubGraphNodeName;
		NodySettings instance2 = NodySettings.Instance;
		base.m_width = instance2.SubGraphNodeWidth;
	}

	public override float GetDefaultNodeWidth()
	{
		NodySettings instance = NodySettings.Instance;
		return instance.SubGraphNodeWidth;
	}

	public override void AddDefaultSockets()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type valueType = default(Type);
		bool canBeReordered = default(bool);
		Socket socket = AddInputSocket(ConnectionMode.Multiple, valueType, canBeDeleted: false, canBeReordered);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type valueType2 = default(Type);
		Socket socket2 = AddOutputSocket(ConnectionMode.Override, valueType2, canBeDeleted: false, canBeReordered);
	}

	public override void CheckForErrors()
	{
		Graph subGraph = m_subGraph;
		bool errorNoGraphReferenced;
		if ((object)m_subGraph != null)
		{
			bool flag = ((UnityEngine.Object)subGraph).m_CachedPtr == (IntPtr)0;
			errorNoGraphReferenced = flag;
		}
		else
		{
			errorNoGraphReferenced = true;
		}
		Graph subGraph2 = m_subGraph;
		ErrorNoGraphReferenced = errorNoGraphReferenced;
		if ((object)m_subGraph != null && ((UnityEngine.Object)subGraph2).m_CachedPtr != (IntPtr)0)
		{
			Graph subGraph3 = m_subGraph;
			bool errorReferencedGraphIsNotSubGraph = !subGraph3.m_isSubGraph;
			ErrorReferencedGraphIsNotSubGraph = errorReferencedGraphIsNotSubGraph;
		}
		else
		{
			ErrorReferencedGraphIsNotSubGraph = true;
		}
	}

	public override void CopyNode(Node original)
	{
		//IL_00b6: Expected I, but got O
		//IL_000d: Expected I, but got O
		//IL_001d: Expected O, but got I
		//IL_0059: Expected O, but got I
		//IL_0098: Expected O, but got I
		base.CopyNode(original);
		nint num = (nint)typeof(SubGraphNode);
		nint num2 = (nint)original;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdx_v2 (Il2CppClass<Doozy.Engine.Nody.Nodes.SubGraphNode>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v3 (Il2CppClass<Doozy.Engine.Nody.Models.Node>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdx_v2 (Il2CppClass<Doozy.Engine.Nody.Nodes.SubGraphNode>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v3 (Il2CppClass<Doozy.Engine.Nody.Models.Node>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v7+FFFFFFF8+v48 @ rax_v6*8]");
			if (0 == (nint)typeof(SubGraphNode))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+80]");
				m_subGraph = (Graph)0;
				return;
			}
		}
		throw new InvalidCastException();
	}

	public override void OnEnter(Node previousActiveNode, Connection connection)
	{
		//IL_00bb: Expected I, but got O
		//IL_00c9: Expected I, but got O
		//IL_00d9: Expected O, but got I
		//IL_0159: Expected O, but got I4
		//IL_0115: Expected O, but got I
		//IL_014b: Expected O, but got I4
		base.OnEnter(previousActiveNode, connection);
		Graph activeGraph = base.m_activeGraph;
		if ((object)base.m_activeGraph == null || ((UnityEngine.Object)activeGraph).m_CachedPtr == (IntPtr)0 || ErrorNoGraphReferenced || ErrorReferencedGraphIsNotSubGraph)
		{
			return;
		}
		Node enterNode = m_subGraph.GetEnterNode();
		Node node;
		if ((object)enterNode == null)
		{
			node = null;
			goto IL_029e;
		}
		nint num = (nint)enterNode;
		nint num2 = (nint)typeof(EnterNode);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rdx_v10 (Il2CppClass<Doozy.Engine.Nody.Nodes.EnterNode>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ r9_v6 (Il2CppClass<Doozy.Engine.Nody.Models.Node>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rdx_v10 (Il2CppClass<Doozy.Engine.Nody.Nodes.EnterNode>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ r9_v6 (Il2CppClass<Doozy.Engine.Nody.Models.Node>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ rax_v35+FFFFFFF8+v371 @ rax_v31*8]");
			if (0 == (nint)typeof(EnterNode))
			{
				obj3 = 1;
				goto IL_0277;
			}
		}
		obj3 = 0;
		goto IL_0277;
		IL_0277:
		bool flag = obj3 == null;
		node = null;
		if (!flag)
		{
			node = enterNode;
		}
		goto IL_029e;
		IL_029e:
		if ((object)node != null && ((UnityEngine.Object)node).m_CachedPtr != (IntPtr)0)
		{
			base.m_activeGraph.DeactivateGlobalNodes();
			base.m_activeGraph.ActiveSubGraph = m_subGraph;
			Graph activeGraph2 = base.m_activeGraph;
			activeGraph2._003CActiveSubGraph_003Ek__BackingField.Enabled = true;
			Graph subGraph = m_subGraph;
			subGraph.ParentGraph = base.m_activeGraph;
			Graph subGraph2 = m_subGraph;
			subGraph2.ParentSubGraphNode = this;
			m_subGraph.SetActiveNode(node);
		}
	}

	public void ExitSubGraphNode()
	{
		Socket firstOutputSocket = base.FirstOutputSocket;
		List<Connection> connections = firstOutputSocket.m_connections;
		if (connections._size > 0)
		{
			Graph activeGraph = base.m_activeGraph;
			activeGraph._003CActiveSubGraph_003Ek__BackingField.Enabled = false;
			Graph activeGraph2 = base.m_activeGraph;
			activeGraph2._003CActiveSubGraph_003Ek__BackingField = null;
			base.m_activeGraph.ActivateGlobalNodes();
			Socket firstOutputSocket2 = base.FirstOutputSocket;
			Connection firstConnection = firstOutputSocket2.FirstConnection;
			Node nodeById = base.m_activeGraph.GetNodeById(firstConnection.m_inputNodeId);
			base.m_activeGraph.SetActiveNode(nodeById, firstConnection);
		}
	}
}
