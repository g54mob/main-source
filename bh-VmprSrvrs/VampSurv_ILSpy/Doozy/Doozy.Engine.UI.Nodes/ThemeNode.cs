using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Doozy.Engine.Nody.Models;
using Doozy.Engine.Themes;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.UI.Nodes;

public class ThemeNode : Node, ISerializationCallbackReceiver
{
	public Guid ThemeId = Guid.Empty;

	public Guid VariantId = Guid.Empty;

	private byte[] ThemeIdSerializedGuid;

	private byte[] VariantIdSerializedGuid;

	public virtual void OnBeforeSerialize()
	{
		byte[] themeIdSerializedGuid;
		if ((object)ThemeId == (object)Guid.Empty)
		{
			object obj = (object)ThemeId >> 32;
			object obj2 = (object)Guid.Empty >> 32;
			if (obj == obj2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)ThemeId == (object)Guid.Empty)
				{
					object obj3 = (object)ThemeId >> 32;
					object obj4 = (object)Guid.Empty >> 32;
					if (obj3 == obj4)
					{
						themeIdSerializedGuid = null;
						goto IL_00d3;
					}
				}
			}
		}
		Guid guid = default(Guid);
		themeIdSerializedGuid = guid.ToByteArray();
		goto IL_00d3;
		IL_00d3:
		ThemeIdSerializedGuid = themeIdSerializedGuid;
		byte[] variantIdSerializedGuid;
		if ((object)VariantId == (object)Guid.Empty)
		{
			object obj5 = (object)VariantId >> 32;
			object obj6 = (object)Guid.Empty >> 32;
			if (obj5 == obj6)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)VariantId == (object)Guid.Empty)
				{
					object obj7 = (object)VariantId >> 32;
					object obj8 = (object)Guid.Empty >> 32;
					bool flag = obj7 == obj8;
					variantIdSerializedGuid = null;
					if (flag)
					{
						goto IL_01fa;
					}
				}
			}
		}
		Guid guid2 = default(Guid);
		byte[] array = guid2.ToByteArray();
		variantIdSerializedGuid = array;
		goto IL_01fa;
		IL_01fa:
		VariantIdSerializedGuid = variantIdSerializedGuid;
	}

	public unsafe virtual void OnAfterDeserialize()
	{
		//IL_00a3: Expected O, but got Ref
		//IL_00d6: Expected O, but got Ref
		byte[] themeIdSerializedGuid = ThemeIdSerializedGuid;
		Guid themeId;
		object obj = default(object);
		Guid guid;
		if (ThemeIdSerializedGuid == null || themeIdSerializedGuid.Length != 16)
		{
			themeId = Guid.Empty;
		}
		else
		{
			guid = new Guid((ReadOnlySpan<byte>)(&obj));
			themeId = guid;
		}
		byte[] variantIdSerializedGuid = VariantIdSerializedGuid;
		ThemeId = themeId;
		if (VariantIdSerializedGuid == null || variantIdSerializedGuid.Length != 16)
		{
			VariantId = Guid.Empty;
			return;
		}
		guid = new Guid((ReadOnlySpan<byte>)(&obj));
		VariantId = guid;
	}

	public override void OnCreate()
	{
		base.m_canBeDeleted = true;
		base.m_nodeType = NodeType.General;
		UILanguagePack instance = UILanguagePack.Instance;
		base.m_name = instance.ThemeNode;
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
		//IL_00aa: Expected O, but got I
		//IL_00bc: Expected O, but got I
		//IL_00f8: Expected O, but got I
		base.CopyNode(original);
		nint num = (nint)typeof(ThemeNode);
		nint num2 = (nint)original;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdx_v2 (Il2CppClass<Doozy.Engine.UI.Nodes.ThemeNode>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v3 (Il2CppClass<Doozy.Engine.Nody.Models.Node>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdx_v2 (Il2CppClass<Doozy.Engine.UI.Nodes.ThemeNode>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v3 (Il2CppClass<Doozy.Engine.Nody.Models.Node>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v7+FFFFFFF8+v48 @ rax_v6*8]");
			if (0 == (nint)typeof(ThemeNode))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+80]");
				ThemeId = (Guid)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+90]");
				VariantId = (Guid)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+A0]");
				ThemeIdSerializedGuid = (byte[])0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+A8]");
				VariantIdSerializedGuid = (byte[])0;
				return;
			}
		}
		throw new InvalidCastException();
	}

	public unsafe override void OnEnter(Node previousActiveNode, Connection connection)
	{
		//IL_0048: Expected O, but got Ref
		//IL_0048: Expected O, but got Ref
		base.OnEnter(previousActiveNode, connection);
		Graph activeGraph = base.m_activeGraph;
		if ((object)base.m_activeGraph != null && ((UnityEngine.Object)activeGraph).m_CachedPtr != (IntPtr)0)
		{
			Guid guid = default(Guid);
			Guid guid2 = default(Guid);
			ThemeManager.ActivateVariant((Guid)(&guid), (Guid)(&guid2));
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

	private unsafe void ExecuteActions()
	{
		//IL_0012: Expected O, but got Ref
		//IL_0012: Expected O, but got Ref
		Guid guid = default(Guid);
		Guid guid2 = default(Guid);
		ThemeManager.ActivateVariant((Guid)(&guid), (Guid)(&guid2));
	}
}
