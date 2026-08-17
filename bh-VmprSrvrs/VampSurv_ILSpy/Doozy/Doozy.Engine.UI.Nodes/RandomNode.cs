using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Doozy.Engine.Nody.Models;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.UI.Nodes;

public class RandomNode : Node
{
	private readonly List<int> m_selectChances;

	private int _003CMaxChance_003Ek__BackingField;

	private int _003CConnectedOutputSockets_003Ek__BackingField;

	public int MaxChance
	{
		get
		{
			return _003CMaxChance_003Ek__BackingField;
		}
		private set
		{
			_003CMaxChance_003Ek__BackingField = value;
		}
	}

	public int ConnectedOutputSockets
	{
		get
		{
			return _003CConnectedOutputSockets_003Ek__BackingField;
		}
		private set
		{
			_003CConnectedOutputSockets_003Ek__BackingField = value;
		}
	}

	public override void OnCreate()
	{
		base.m_canBeDeleted = true;
		base.m_nodeType = NodeType.General;
		UILanguagePack instance = UILanguagePack.Instance;
		base.m_name = instance.RandomNodeName;
		base.m_allowDuplicateNodeName = true;
	}

	public override void AddDefaultSockets()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
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
		Socket socket2 = AddOutputSocket(ConnectionMode.Override, valueType2, canBeDeleted: true, canBeReordered);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type valueType3 = default(Type);
		Socket socket3 = AddOutputSocket(ConnectionMode.Override, valueType3, canBeDeleted: true, canBeReordered);
	}

	public override void OnEnter(Node previousActiveNode, Connection connection)
	{
		base.OnEnter(previousActiveNode, connection);
		Graph activeGraph = base.m_activeGraph;
		if ((object)base.m_activeGraph != null && ((UnityEngine.Object)activeGraph).m_CachedPtr != (IntPtr)0)
		{
			SelectRandomOutputSocket();
		}
	}

	public unsafe void UpdateMaxChance()
	{
		//IL_0017: Expected O, but got Ref
		_003CMaxChance_003Ek__BackingField = 0;
		List<Socket> outputSockets = base.OutputSockets;
		List<Socket>.Enumerator enumerator = default(List<Socket>.Enumerator);
		if (enumerator.MoveNext())
		{
			Socket socket = null;
			List<Socket>.Enumerator enumerator2 = (List<Socket>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	public unsafe void UpdateConnectedOutputSockets()
	{
		//IL_0021: Expected O, but got I4
		//IL_0029: Expected O, but got Ref
		List<Socket> outputSockets = base.OutputSockets;
		int num = 0;
		List<Socket>.Enumerator enumerator = default(List<Socket>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<Socket>.Enumerator enumerator2 = (List<Socket>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		if (num != _003CConnectedOutputSockets_003Ek__BackingField)
		{
			_003CConnectedOutputSockets_003Ek__BackingField = num;
			UpdateMaxChance();
		}
	}

	private unsafe void SelectRandomOutputSocket()
	{
		//IL_004a: Expected O, but got Ref
		//IL_03c1: Expected O, but got I4
		//IL_01ac: Expected O, but got I
		List<int> selectChances = m_selectChances;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		_003CMaxChance_003Ek__BackingField = 0;
		List<Socket> outputSockets = base.OutputSockets;
		List<Socket>.Enumerator enumerator = default(List<Socket>.Enumerator);
		if (enumerator.MoveNext())
		{
			Socket socket = null;
			List<Socket>.Enumerator enumerator2 = (List<Socket>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		object obj = UnityEngine.Random.RandomRangeInt(0, _003CMaxChance_003Ek__BackingField);
		List<int> selectChances2 = m_selectChances;
		int num = 0;
		int num2 = 0;
		object obj3 = default(object);
		while (true)
		{
			int num3 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rcx_v20 (System.Collections.Generic.List`1<System.Int32>)+18]");
			bool flag = (nint)num3 >= (nint)0;
			int num4 = 0;
			if (!flag)
			{
				List<int> selectChances3 = m_selectChances;
				int num5 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rax_v39 (System.Collections.Generic.List`1<System.Int32>)+18]");
				if ((nint)num5 >= (nint)0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rax_v39 (System.Collections.Generic.List`1<System.Int32>)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rcx_v29+20+v64 @ rbx_v12 (System.Int32)*4]");
				if ((nint)0 == -1)
				{
					goto IL_0204;
				}
				m_selectChances.Add(num);
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
				{
					goto IL_0204;
				}
				num4 = num;
			}
			List<Socket> outputSockets2 = base.OutputSockets;
			if (num4 >= outputSockets2._size)
			{
				break;
			}
			Socket[] items = outputSockets2._items;
			Connection firstConnection = items[num4].FirstConnection;
			Node nodeById = base.m_activeGraph.GetNodeById(firstConnection.m_inputNodeId);
			base.m_activeGraph.SetActiveNode(nodeById, firstConnection);
			return;
			IL_0204:
			num++;
			selectChances2 = m_selectChances;
			num2 = num;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	public RandomNode()
	{
		List<int> selectChances = new List<int>();
		m_selectChances = selectChances;
		((ScriptableObject)this)._002Ector();
	}
}
