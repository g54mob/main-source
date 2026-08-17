using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Doozy.Engine.Nody.Models;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.UI.Nodes;

public class UIDrawerNode : Node
{
	public enum DrawerAction
	{
		Open,
		Close,
		Toggle
	}

	public string DrawerName;

	public bool CustomDrawerName;

	public DrawerAction Action;

	public override void OnCreate()
	{
		base.m_canBeDeleted = true;
		base.m_nodeType = NodeType.General;
		UILanguagePack instance = UILanguagePack.Instance;
		base.m_name = instance.UIDrawerNodeName;
		base.m_allowDuplicateNodeName = true;
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

	public override void CopyNode(Node original)
	{
		//IL_00da: Expected I, but got O
		//IL_000d: Expected I, but got O
		//IL_001d: Expected O, but got I
		//IL_0059: Expected O, but got I
		//IL_0098: Expected O, but got I
		base.CopyNode(original);
		nint num = (nint)typeof(UIDrawerNode);
		nint num2 = (nint)original;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdx_v2 (Il2CppClass<Doozy.Engine.UI.Nodes.UIDrawerNode>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v3 (Il2CppClass<Doozy.Engine.Nody.Models.Node>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdx_v2 (Il2CppClass<Doozy.Engine.UI.Nodes.UIDrawerNode>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v3 (Il2CppClass<Doozy.Engine.Nody.Models.Node>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v7+FFFFFFF8+v48 @ rax_v6*8]");
			if (0 == (nint)typeof(UIDrawerNode))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+80]");
				DrawerName = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+88]");
				CustomDrawerName = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+8C]");
				Action = DrawerAction.Open;
				return;
			}
		}
		throw new InvalidCastException();
	}

	public override void OnEnter(Node previousActiveNode, Connection connection)
	{
		base.OnEnter(previousActiveNode, connection);
		Graph activeGraph = base.m_activeGraph;
		if ((object)base.m_activeGraph != null && ((UnityEngine.Object)activeGraph).m_CachedPtr != (IntPtr)0)
		{
			ExecuteActions();
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

	private void ExecuteActions()
	{
		//IL_0015: Expected O, but got I4
		//IL_00ca: Expected O, but got I4
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected O, but got Unknown
		bool flag = Action == DrawerAction.Open;
		UIDrawer uIDrawer;
		if (!flag)
		{
			object obj = Action - 1;
			if (!flag)
			{
				if ((nint)obj != 1)
				{
					return;
				}
				uIDrawer = UIDrawer.Get(DrawerName);
				if ((object)uIDrawer != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rax_v12 (Doozy.Engine.UI.UIDrawer)+10]");
					if ((nint)0 != 0)
					{
						bool flag2 = uIDrawer.m_visibility == VisibilityState.Visible;
						if (!flag2)
						{
							object obj2 = uIDrawer.m_visibility - 1;
							if (!flag2)
							{
								object obj3 = obj2 - 1;
								if (!flag2)
								{
									if ((nint)obj3 != 1)
									{
										return;
									}
									goto IL_0120;
								}
							}
							uIDrawer.Open();
							return;
						}
						goto IL_0120;
					}
				}
				if (~(base.m_debugMode ? 1u : 0u) == 0)
				{
					string message = "Unable to toggle the '" + DrawerName + "' drawer because no such UIDrawer was found in the Database.";
					DDebug.LogError(message);
				}
			}
			else
			{
				UIDrawer.Close(DrawerName, base.m_debugMode);
			}
		}
		else
		{
			UIDrawer.Open(DrawerName, base.m_debugMode);
		}
		return;
		IL_0120:
		uIDrawer.Close();
	}

	public override void CheckForErrors()
	{
	}

	public UIDrawerNode()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998069B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		DrawerName = "Unnamed";
		((ScriptableObject)this)._002Ector();
	}
}
