using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Doozy.Engine.Nody.Models;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.Nody.Nodes;

public class SwitchBackNode : Node
{
	[Serializable]
	public class SourceInfo
	{
		public string SourceName;

		public string InputSocketId;

		public string OutputSocketId;

		public bool InputSocketIsConnected;

		public bool OutputSocketIsConnected;

		public bool IsConnected
		{
			get
			{
				if (!InputSocketIsConnected)
				{
					return false;
				}
				return OutputSocketIsConnected;
			}
		}

		public SourceInfo(string sourceName, string inputSocketId, string outputSocketId)
		{
			SourceName = sourceName;
			InputSocketId = inputSocketId;
			OutputSocketId = outputSocketId;
		}
	}

	[NonSerialized]
	private Graph m_targetGraph;

	[NonSerialized]
	private string m_returnSourceOutputSocketId;

	public List<SourceInfo> Sources;

	public Socket TargetInputSocket
	{
		get
		{
			List<Socket> inputSockets = base.InputSockets;
			if (inputSockets._size > 0)
			{
				Socket[] items = inputSockets._items;
				return items[0];
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			Socket result = default(Socket);
			return result;
		}
	}

	public Socket TargetOutputSocket
	{
		get
		{
			List<Socket> outputSockets = base.OutputSockets;
			if (outputSockets._size > 0)
			{
				Socket[] items = outputSockets._items;
				return items[0];
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			Socket result = default(Socket);
			return result;
		}
	}

	public string ReturnSourceOutputSocketId => m_returnSourceOutputSocketId;

	public override void OnCreate()
	{
		base.m_canBeDeleted = true;
		base.m_nodeType = NodeType.General;
		UILanguagePack instance = UILanguagePack.Instance;
		base.m_name = instance.SwitchBackNodeName;
		NodySettings instance2 = NodySettings.Instance;
		base.m_width = instance2.SwitchBackNodeWidth;
		base.m_minimumInputSocketsCount = 2;
		base.m_minimumOutputSocketsCount = 2;
	}

	public override float GetDefaultNodeWidth()
	{
		NodySettings instance = NodySettings.Instance;
		return instance.SwitchBackNodeWidth;
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
		Socket socket = AddInputSocket(ConnectionMode.Override, valueType, canBeDeleted: false, canBeReordered);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type valueType2 = default(Type);
		Socket socket2 = AddOutputSocket(ConnectionMode.Override, valueType2, canBeDeleted: false, canBeReordered);
		AddSourceSocketPair();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 124 Invalid \"Jump target not found in method: 0x182C385F0\"");
	}

	public unsafe void AddSourceSocketPair()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_00b5: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type valueType = default(Type);
		bool canBeReordered = default(bool);
		Socket socket = AddInputSocket(ConnectionMode.Override, valueType, canBeDeleted: false, canBeReordered);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type valueType2 = default(Type);
		Socket socket2 = AddOutputSocket(ConnectionMode.Override, valueType2, canBeDeleted: false, canBeReordered);
		UILanguagePack instance = UILanguagePack.Instance;
		List<SourceInfo> sources = Sources;
		int value = sources._size + 1;
		object obj5 = default(object);
		string text = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&obj5), null);
		string sourceName = instance.SourceName + " " + text;
		SourceInfo sourceInfo = new SourceInfo(sourceName, socket.m_id, socket2.m_id);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D440");
	}

	protected override void OnEnable()
	{
		//IL_0010: Expected O, but got I
		//IL_0020: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rax_v1+B8]");
		object returnSourceOutputSocketId = 0;
		m_returnSourceOutputSocketId = (string)returnSourceOutputSocketId;
	}

	private void OnDisable()
	{
		//IL_0010: Expected O, but got I
		//IL_0020: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rax_v1+B8]");
		object returnSourceOutputSocketId = 0;
		m_returnSourceOutputSocketId = (string)returnSourceOutputSocketId;
	}

	private unsafe SourceInfo GetSource(Connection connection)
	{
		//IL_0021: Expected O, but got Ref
		//IL_0049: Expected O, but got Ref
		List<SourceInfo>.Enumerator enumerator = default(List<SourceInfo>.Enumerator);
		if (enumerator.MoveNext())
		{
			bool flag = connection == null;
			List<SourceInfo>.Enumerator enumerator2 = (List<SourceInfo>.Enumerator)(&enumerator);
			if (!flag)
			{
				string inputSocketId = connection.m_inputSocketId;
				SourceInfo sourceInfo = null;
				enumerator2 = (List<SourceInfo>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		return null;
	}

	public override void CopyNode(Node original)
	{
		//IL_033d: Expected I, but got O
		//IL_000d: Expected I, but got O
		//IL_001d: Expected O, but got I
		//IL_00ad: Expected O, but got I4
		//IL_00b6: Expected O, but got I4
		//IL_0388: Expected O, but got I
		//IL_0059: Expected O, but got I
		//IL_0123: Expected O, but got I
		//IL_0138: Expected O, but got I
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected O, but got Unknown
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Expected O, but got Unknown
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Expected O, but got Unknown
		//IL_0258: Expected O, but got I
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		//IL_0317: Expected O, but got Unknown
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Expected O, but got Unknown
		base.CopyNode(original);
		nint num = (nint)typeof(SwitchBackNode);
		if ((object)original != null)
		{
			nint num2 = (nint)original;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdx_v2 (Il2CppClass<Doozy.Engine.Nody.Nodes.SwitchBackNode>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ r8_v15 (Il2CppClass<Doozy.Engine.Nody.Models.Node>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdx_v2 (Il2CppClass<Doozy.Engine.Nody.Nodes.SwitchBackNode>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ r8_v15 (Il2CppClass<Doozy.Engine.Nody.Models.Node>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v38+FFFFFFF8+v56 @ rax_v37*8]");
				if (0 == (nint)typeof(SwitchBackNode))
				{
					goto IL_0086;
				}
			}
			throw new InvalidCastException();
		}
		goto IL_0086;
		IL_0086:
		List<SourceInfo> sources = new List<SourceInfo>();
		Sources = sources;
		object obj3 = 0;
		object obj4 = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+90]");
			object obj5 = 0;
			object obj6 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rax_v10+18]");
			if ((nint)obj6 < 0)
			{
				List<object> sources2 = (List<object>)(object)Sources;
				object obj7 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rax_v10+18]");
				if ((nint)obj7 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rax_v10+10]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rcx_v13+20+v334 @ rdi_v3*8]");
				object obj9 = 0;
				List<Socket> inputSockets = base.InputSockets;
				object obj10 = obj3 + 1;
				if ((nint)obj10 >= inputSockets._size)
				{
					break;
				}
				Socket[] items = inputSockets._items;
				object obj11 = obj3 + 1;
				Socket socket = items[obj11];
				List<Socket> outputSockets = base.OutputSockets;
				object obj12 = obj3 + 1;
				if ((nint)obj12 >= outputSockets._size)
				{
					break;
				}
				Socket[] items2 = outputSockets._items;
				object obj13 = obj3 + 1;
				Socket socket2 = items2[obj13];
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rdx_v9+10]");
				SourceInfo item = new SourceInfo((string)0, socket.m_id, socket2.m_id);
				int version = sources2._version + 1;
				sources2._version = version;
				object[] items3 = sources2._items;
				if (sources2._size >= items3.Length)
				{
					sources2.AddWithResize((object)item);
					obj3++;
					obj4 = obj3;
				}
				else
				{
					int size = sources2._size + 1;
					sources2._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					obj3++;
					obj4 = obj3;
				}
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	public unsafe override void OnEnter(Node previousActiveNode, Connection connection)
	{
		//IL_02ff: Expected O, but got I4
		//IL_0307: Expected O, but got Ref
		//IL_0129: Expected O, but got I
		//IL_0139: Expected O, but got I
		//IL_05f0: Expected O, but got I
		//IL_0600: Expected O, but got I
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		base.OnEnter(previousActiveNode, connection);
		Graph activeGraph = base.m_activeGraph;
		if ((object)base.m_activeGraph == null || ((UnityEngine.Object)activeGraph).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		SourceInfo source = GetSource(connection);
		Node nodeById2;
		Connection connection2;
		Graph activeGraph2;
		if (source != null)
		{
			Socket targetOutputSocket = TargetOutputSocket;
			if (targetOutputSocket != null)
			{
				List<Connection> connections = targetOutputSocket.m_connections;
				if (targetOutputSocket.m_connections != null)
				{
					if (connections._size <= 0)
					{
						goto IL_0550;
					}
					string outputSocketId = source.OutputSocketId;
					object returnSourceOutputSocketId;
					if (source.OutputSocketId != null && outputSocketId._stringLength > 0)
					{
						returnSourceOutputSocketId = source + 32;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v878 @ rax_v64+B8]");
						returnSourceOutputSocketId = 0;
					}
					m_returnSourceOutputSocketId = (string)returnSourceOutputSocketId;
					Socket targetOutputSocket2 = TargetOutputSocket;
					if (targetOutputSocket2 != null)
					{
						Connection firstConnection = targetOutputSocket2.FirstConnection;
						if ((object)base.m_activeGraph != null && firstConnection != null)
						{
							Node nodeById = base.m_activeGraph.GetNodeById(firstConnection.m_inputNodeId);
							base.m_activeGraph.SetActiveNode(nodeById, firstConnection);
							return;
						}
					}
				}
			}
		}
		else
		{
			string returnSourceOutputSocketId2 = m_returnSourceOutputSocketId;
			if (m_returnSourceOutputSocketId != null && returnSourceOutputSocketId2._stringLength > 0)
			{
				Socket socketFromId = GetSocketFromId(m_returnSourceOutputSocketId);
				if (socketFromId != null && socketFromId.IsConnected)
				{
					Connection firstConnection2 = socketFromId.FirstConnection;
					if ((object)base.m_activeGraph == null || firstConnection2 == null)
					{
						goto IL_04b9;
					}
					nodeById2 = base.m_activeGraph.GetNodeById(firstConnection2.m_inputNodeId);
					connection2 = firstConnection2;
					activeGraph2 = base.m_activeGraph;
					goto IL_05cf;
				}
			}
			if (Sources != null)
			{
				List<SourceInfo>.Enumerator enumerator = default(List<SourceInfo>.Enumerator);
				if (enumerator.MoveNext())
				{
					object obj2 = 0;
					Socket socket = (Socket)(&enumerator);
					throw new NullReferenceException();
				}
				goto IL_0550;
			}
		}
		goto IL_04b9;
		IL_05cf:
		activeGraph2.SetActiveNode(nodeById2, connection2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v917 @ rax_v12+B8]");
		object returnSourceOutputSocketId3 = 0;
		m_returnSourceOutputSocketId = (string)returnSourceOutputSocketId3;
		return;
		IL_0550:
		if (connection == null || (object)base.m_activeGraph == null)
		{
			goto IL_04b9;
		}
		nodeById2 = base.m_activeGraph.GetNodeById(connection.m_outputNodeId);
		connection2 = null;
		activeGraph2 = base.m_activeGraph;
		goto IL_05cf;
		IL_04b9:
		throw new NullReferenceException();
	}

	public override void CheckForErrors()
	{
	}

	public void RegenerateSourcesSocketIds()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0246: Expected O, but got I4
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_028c: Expected O, but got I4
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Expected O, but got Unknown
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Expected O, but got Unknown
		List<Socket> inputSockets = base.InputSockets;
		object obj = 1;
		object obj2 = 1;
		while (true)
		{
			List<SourceInfo> sources = Sources;
			if ((nint)obj2 < inputSockets._size)
			{
				object obj3 = obj - 1;
				if ((nint)obj3 < sources._size)
				{
					SourceInfo[] items = sources._items;
					object obj4 = obj - 1;
					SourceInfo sourceInfo = items[obj4];
					List<Socket> inputSockets2 = base.InputSockets;
					if ((nint)obj < inputSockets2._size)
					{
						Socket[] items2 = inputSockets2._items;
						Socket socket = items2[obj];
						sourceInfo.InputSocketId = socket.m_id;
						List<SourceInfo> sources2 = Sources;
						object obj5 = obj - 1;
						if ((nint)obj5 < sources2._size)
						{
							SourceInfo[] items3 = sources2._items;
							object obj6 = obj - 1;
							SourceInfo sourceInfo2 = items3[obj6];
							List<Socket> outputSockets = base.OutputSockets;
							if ((nint)obj < outputSockets._size)
							{
								Socket[] items4 = outputSockets._items;
								Socket socket2 = items4[obj];
								sourceInfo2.OutputSocketId = socket2.m_id;
								obj++;
								inputSockets = base.InputSockets;
								bool flag = inputSockets != null;
								obj2 = obj;
								if (!flag)
								{
									break;
								}
								continue;
							}
						}
					}
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				break;
			}
			List<Socket> inputSockets3 = base.InputSockets;
			object obj7 = inputSockets3._size - 1;
			if (sources._size <= (nint)obj7)
			{
				return;
			}
			List<SourceInfo> sources3 = Sources;
			while (true)
			{
				List<Socket> inputSockets4 = base.InputSockets;
				object obj8 = inputSockets4._size - 1;
				if (sources3._size > (nint)obj8)
				{
					List<SourceInfo> sources4 = Sources;
					int index = sources4._size - 1;
					Sources.RemoveAt(index);
					sources3 = Sources;
					continue;
				}
				break;
			}
			return;
		}
		throw new NullReferenceException();
	}

	public SwitchBackNode()
	{
		List<SourceInfo> sources = new List<SourceInfo>();
		Sources = sources;
		((ScriptableObject)this)._002Ector();
	}
}
